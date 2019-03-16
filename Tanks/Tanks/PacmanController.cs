using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tanks.Properties;

namespace Tanks
{
    public class PacmanController
    {
        private Bitmap backgroundMap;
        private Graphics mapGraphics;
        private PictureBox map;
        public List<FixedObject> Obstacles { get; set; } = new List<FixedObject>();
        private string[] mapFix = {"      XX      XX          ",
                                    "      XX      XX          ",
                                    "  XX  XX      XX  XX  XX  ",
                                    "  XX  XX      XX  XX  XX  ",
                                    "  XX    YY  XXXX  XXXXXX  ",
                                    "  XX    YY  XXXX  XXXXXX  ",
                                    "      XX    XXXX  XX      ",
                                    "      XX    XXXX  XX      ",
                                    "      XX  XXXX    XX  XXXX",
                                    "      XX  XXXX    XX  XXXX",
                                    "      XXXXXX    XXXX      ",
                                    "      XXXXXX    XXXX      ",
                                    "XXXXXXXXXX    XXXXXX  XX  ",
                                    "XXXXXXXXXX    XXXXXX  XX  ",
                                    "      XX  XX  XX  XX  XX  ",
                                    "      XX  XX  XX  XX  XX  ",
                                    "XXXXYYXX  XX  XX  YYYYXXYY",
                                    "XXXXYYXX  XX  XX  YYYYXXYY",
                                    "  XX  XX  XXXXXX  XXXXXXYY",
                                    "  XX  XX  XXXXXX  XXXXXXYY",
                                    "  XX  XX  XXXXXX        YY",
                                    "  XX  XX  XXXXXX        YY",
                                    "  XX      YYYYYY  XX  XXYY",
                                    "  XX      YYYYYY  XX  XXYY",
                                    "  XX  XX    XX    XXXXXX  ",
                                    "  XX  XX    XX    XXXXXX  "};
        public List<Apple> Apples { get; protected set; } = new List<Apple>();
        public List<ShotView> ShotsKolobok { get; protected set; } = new List<ShotView>();
        public List<ShotView> ShotsTanks { get; protected set; } = new List<ShotView>();
        public List<TankView> Tanks { get; protected set; } = new List<TankView>();

        public KolobokView kolobok;
        private int applesCount = 5;
        private int tanksCount = 5;
        public int Delta { get; protected set; } = 30;
        public int DeltaShots { get; protected set; } = 30;
        public int Score { get; protected set; }
        public bool gameOver { get; protected set; } = false;
        public PacmanController() { }

        public PacmanController(int applesCount, int tanksCount)
        {
            this.applesCount = applesCount;
            this.tanksCount = tanksCount;
        }

        public void Start(MainForm main_f)
        {
            UnSubscribe();
            Apples.Clear();
            Tanks.Clear();
            Obstacles.Clear();
            ShotsKolobok.Clear();
            ShotsTanks.Clear();
            kolobok = null;
            gameOver = false;
            Score = 0;
            Delta = 30;
            DeltaShots = 30;
            map = main_f.map;
            backgroundMap = new Bitmap(map.Width, map.Height);
            mapGraphics = Graphics.FromImage(backgroundMap);
            mapGraphics.FillRectangle(Brushes.Black, 0, 0, map.Width, map.Height);
            for (int i = 0; i < mapFix.Count(); i++)
            {
                for (int j = 0; j < mapFix[i].Length; j++)
                {
                    if (mapFix[i][j] == 'X')
                    {
                        Obstacles.Add(new FixedObject(j, i, 0));
                        mapGraphics.DrawImage(Obstacles.Last().Img, Obstacles.Last().X * MainForm.sizeCell, Obstacles.Last().Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                    }
                    if (mapFix[i][j] == 'Y')
                    {
                        Obstacles.Add(new FixedObject(j, i, 1));
                        mapGraphics.DrawImage(Obstacles.Last().Img, Obstacles.Last().X * MainForm.sizeCell, Obstacles.Last().Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);

                    }
                }

            }

            RespOfApples();

            while (Tanks.Count < tanksCount)
            {
                Tanks.Add(new TankView());
                foreach (var item in Obstacles)
                {
                    if (Tanks.Last().Collide(item))
                    {
                        Tanks.RemoveAt(Tanks.Count - 1);
                        break;
                    }
                }
            }

            for (int i = 0; i < Apples.Count; i++)
            {
                mapGraphics.DrawImage(Apples[i].Img, Apples[i].X * MainForm.sizeCell, Apples[i].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
            }

            for (int i = 0; i < Tanks.Count; i++)
            {
                mapGraphics.DrawImage(Tanks[i].Img, Tanks[i].X * MainForm.sizeCell, Tanks[i].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
            }

            while (true)
            {
                kolobok = new KolobokView();
                if (!kolobok.CollideWithFixedObjects(Obstacles))
                {
                    break;
                }
            }

            Subscribe();
            mapGraphics.DrawImage(kolobok.Img, kolobok.X * MainForm.sizeCell, kolobok.Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
            map.Image = backgroundMap;
        }

        public void RespOfApples()
        {
            while (Apples.Count < applesCount)
            {
                Apples.Add(new Apple());
                foreach (var item in Obstacles)
                {
                    if (Apples.Last().Collide(item))
                    {
                        Apples.RemoveAt(Apples.Count - 1);
                        break;
                    }
                }

                for (int i = 0; i < Apples.Count; i++)
                {
                    if (Apples.Last().Collide(Apples[i]) && Apples.Last() != Apples[i])
                    {
                        Apples.RemoveAt(Apples.Count - 1);
                        break;
                    }
                }
            }
        }

        public void GameOver()
        {
            mapGraphics.DrawImage(new Bitmap(Resources.gameOver), 0, 0, 650, 650);
            map.Image = backgroundMap;
            UnSubscribe();
        }

        private event KeyEventHandler KeyPress;

        public void OnKeyPress(Keys key)
        {
            KeyPress?.Invoke(kolobok, new KeyEventArgs(key));
        }

        public void Subscribe()
        {
            KeyPress += new KeyEventHandler(kolobok.OnKeyPress);
            kolobok.Shooting += CreateShotKolobok;
            for (int i = 0; i < Tanks.Count; i++)
            {
                Tanks[i].Shooting += CreateShotTank;
            }
        }

        public void UnSubscribe()
        {
            if (KeyPress != null)
            {
                KeyPress -= new KeyEventHandler(kolobok.OnKeyPress);
            }
        }

        public void CreateShotKolobok(MovingObject sender)
        {
            switch (sender.MovementDirection)
            {
                case (int)Direction.DOWN:
                    {
                        ShotsKolobok.Add(new ShotView(sender.X, sender.Y + 1, sender.MovementDirection, sender));
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        ShotsKolobok.Add(new ShotView(sender.X - 1, sender.Y, sender.MovementDirection, sender));
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        ShotsKolobok.Add(new ShotView(sender.X + 1, sender.Y, sender.MovementDirection, sender));
                        break;
                    }
                case (int)Direction.UP:
                    {
                        ShotsKolobok.Add(new ShotView(sender.X, sender.Y - 1, sender.MovementDirection, sender));
                        break;
                    }
                default:
                    break;
            }
            for (int i = 0; i < ShotsKolobok.Count - 1; i++)
            {
                if (ShotsKolobok.Last().Collide(ShotsKolobok[i]))
                {
                    ShotsKolobok.RemoveAt(ShotsKolobok.Count - 1);
                    return;
                }
            }
             var index = ShotsKolobok.Last().InteractWithFixedObjects(Obstacles);
            if (index>0)
            {
                mapGraphics.FillRectangle(Brushes.Black, Obstacles[index].X * MainForm.sizeCell, Obstacles[index].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                Obstacles.RemoveAt(index);
                ShotsKolobok.RemoveAt(ShotsKolobok.Count - 1);
            }
        }


        public void CreateShotTank(MovingObject sender)
        {
            switch (sender.MovementDirection)
            {
                case (int)Direction.DOWN:
                    {
                        ShotsTanks.Add(new ShotView(sender.X, sender.Y + 1, sender.MovementDirection, sender));
                        break;
                    }
                case (int)Direction.LEFT:
                    {
                        ShotsTanks.Add(new ShotView(sender.X - 1, sender.Y, sender.MovementDirection, sender));
                        break;
                    }
                case (int)Direction.RIGHT:
                    {
                        ShotsTanks.Add(new ShotView(sender.X + 1, sender.Y, sender.MovementDirection, sender));
                        break;
                    }
                case (int)Direction.UP:
                    {
                        ShotsTanks.Add(new ShotView(sender.X, sender.Y - 1, sender.MovementDirection, sender));
                        break;
                    }
                default:
                    break;
            }

            var index = ShotsTanks.Last().InteractWithFixedObjects(Obstacles);
            if (index > 0)
            {
               mapGraphics.FillRectangle(Brushes.Black, Obstacles[index].X * MainForm.sizeCell, Obstacles[index].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                Obstacles.RemoveAt(index);
                ShotsTanks.RemoveAt(ShotsTanks.Count - 1);
            }
        }


        public void StepOfShots()
        {
            while (DeltaShots != MainForm.sizeCell + 5)
            {
                for (int i = 0; i < ShotsKolobok.Count; i++)
                {
                    Move(ShotsKolobok[i], DeltaShots);
                }

                for (int i = 0; i < ShotsTanks.Count; i++)
                {
                    Move(ShotsTanks[i], DeltaShots);
                }

                for (int i = 0; i < Apples.Count; i++)
                {
                    mapGraphics.DrawImage(Apples[i].Img, Apples[i].X * MainForm.sizeCell, Apples[i].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                }
                for (int i = 0; i < Obstacles.Count; i++)
                {
                    if (Obstacles[i].Ability == 1)
                    {
                        mapGraphics.DrawImage(Obstacles[i].Img, Obstacles[i].X * MainForm.sizeCell, Obstacles[i].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                    }
                }

                DeltaShots += 5;
                map.Image = backgroundMap;
                return;
            }


            DeltaShots = 5;

            for (int j = 0; j < ShotsTanks.Count; j++)
            {
                if (kolobok.Collide(ShotsTanks[j]))
                {
                    gameOver = true;
                    break;
                }
            }

            for (int i = 0; i < Tanks.Count; i++)
            {

                for (int j = 0; j < ShotsKolobok.Count; j++)
                {
                    if (Tanks[i].Collide(ShotsKolobok[j]))
                    {
                        mapGraphics.FillRectangle(Brushes.Black, Tanks[i].PrevX * MainForm.sizeCell, Tanks[i].PrevY * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                        mapGraphics.FillRectangle(Brushes.Black, ShotsKolobok[j].X * MainForm.sizeCell, ShotsKolobok[j].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                        mapGraphics.FillRectangle(Brushes.Black, Tanks[i].X * MainForm.sizeCell, Tanks[i].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                        mapGraphics.FillRectangle(Brushes.Black, ShotsKolobok[j].PrevX * MainForm.sizeCell, ShotsKolobok[j].PrevY * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                        Tanks.RemoveAt(i);
                        ShotsKolobok.RemoveAt(j);
                        i--;
                        j--;
                        break;
                    }
                }

            }


            for (int i = 0; i < ShotsKolobok.Count; i++)
            {
                ShotsKolobok[i].Move();
                var index = ShotsKolobok[i].InteractWithFixedObjects(Obstacles);
                if (index > 0)
                {
                    mapGraphics.FillRectangle(Brushes.Black, ShotsKolobok[i].PrevX * MainForm.sizeCell, ShotsKolobok[i].PrevY * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                    mapGraphics.FillRectangle(Brushes.Black, Obstacles[index].X * MainForm.sizeCell, Obstacles[index].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                    Obstacles.RemoveAt(index);
                    ShotsKolobok.RemoveAt(i);
                }
            }

            for (int i = 0; i < ShotsTanks.Count; i++)
            {
                ShotsTanks[i].Move();
                /*if (ShotsTanks[i].CollideWithFixedObjects(Obstacles))
                {
                    mapGraphics.FillRectangle(Brushes.Black, ShotsTanks[i].PrevX * MainForm.sizeCell, ShotsTanks[i].PrevY * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                    ShotsTanks.RemoveAt(i);
                    i--;
                    continue;
                }*/
                var index = ShotsTanks[i].InteractWithFixedObjects(Obstacles);
                if (index > 0)
                {
                    mapGraphics.FillRectangle(Brushes.Black, ShotsTanks[i].PrevX * MainForm.sizeCell, ShotsTanks[i].PrevY * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                    mapGraphics.FillRectangle(Brushes.Black, Obstacles[index].X * MainForm.sizeCell, Obstacles[index].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                    Obstacles.RemoveAt(index);
                    ShotsTanks.RemoveAt(i);
                    i--;
                    continue;
                }
                if (kolobok.Collide(ShotsTanks[i]))
                {
                    gameOver = true;
                    break;
                }
            }


            for (int i = 0; i < Tanks.Count; i++)
            {
                for (int j = 0; j < ShotsKolobok.Count; j++)
                {
                    if (Tanks[i].Collide(ShotsKolobok[j]))
                    {
                        mapGraphics.FillRectangle(Brushes.Black, Tanks[i].PrevX * MainForm.sizeCell, Tanks[i].PrevY * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                        mapGraphics.FillRectangle(Brushes.Black, ShotsKolobok[j].X * MainForm.sizeCell, ShotsKolobok[j].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                        mapGraphics.FillRectangle(Brushes.Black, Tanks[i].X * MainForm.sizeCell, Tanks[i].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                        mapGraphics.FillRectangle(Brushes.Black, ShotsKolobok[j].PrevX * MainForm.sizeCell, ShotsKolobok[j].PrevY * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                        Tanks.RemoveAt(i);
                        ShotsKolobok.RemoveAt(j);
                        i--;
                        j--;
                        break;
                    }
                }
            }



            for (int i = 0; i < Apples.Count; i++)
            {
                if (Apples[i].Collide(kolobok))
                {
                    Apples.RemoveAt(i);
                    Score++;
                    break;
                }
                mapGraphics.DrawImage(Apples[i].Img, Apples[i].X * MainForm.sizeCell, Apples[i].Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
            }

            RespOfApples();
            DeltaShots += 5;
            map.Image = backgroundMap;
        }

        public void Step()
        {

            while (Delta != MainForm.sizeCell + 5)
            {


                Move(kolobok, Delta);

                for (int i = 0; i < Tanks.Count; i++)
                {
                    Move(Tanks[i], Delta);
                }


                Delta += 5;
                map.Image = backgroundMap;
                return;
            }

            kolobok.Move(Obstacles);
            Delta = 5;
            Move(kolobok, Delta);


            for (int i = 0; i < Tanks.Count; i++)
            {
                if (Tanks[i].Collide(kolobok))
                {
                    gameOver = true;
                    return;
                }
                Tanks[i].Move(Obstacles, Tanks);

                if (Tanks[i].Collide(kolobok))
                {
                    gameOver = true;
                    return;
                }
                Move(Tanks[i], Delta);
            }

            Delta += 5;
            map.Image = backgroundMap;
        }


        public void Move(MovingObject obj, int delta)
        {
            if (obj.PrevX < obj.X)
            {
                mapGraphics.FillRectangle(Brushes.Black, obj.PrevX * MainForm.sizeCell + delta - 5, obj.PrevY * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                mapGraphics.DrawImage(obj.Img, obj.PrevX * MainForm.sizeCell + delta, obj.PrevY * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                return;
            }
            if (obj.PrevX > obj.X)
            {
                mapGraphics.FillRectangle(Brushes.Black, obj.PrevX * MainForm.sizeCell - delta + 5, obj.PrevY * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                mapGraphics.DrawImage(obj.Img, obj.PrevX * MainForm.sizeCell - delta, obj.PrevY * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                return;
            }
            if (obj.PrevY < obj.Y)
            {
                mapGraphics.FillRectangle(Brushes.Black, obj.PrevX * MainForm.sizeCell, obj.PrevY * MainForm.sizeCell + delta - 5, MainForm.sizeCell, MainForm.sizeCell);
                mapGraphics.DrawImage(obj.Img, obj.PrevX * MainForm.sizeCell, obj.PrevY * MainForm.sizeCell + delta, MainForm.sizeCell, MainForm.sizeCell);
                return;
            }
            if (obj.PrevY > obj.Y)
            {
                mapGraphics.FillRectangle(Brushes.Black, obj.PrevX * MainForm.sizeCell, obj.PrevY * MainForm.sizeCell - delta + 5, MainForm.sizeCell, MainForm.sizeCell);
                mapGraphics.DrawImage(obj.Img, obj.PrevX * MainForm.sizeCell, obj.PrevY * MainForm.sizeCell - delta, MainForm.sizeCell, MainForm.sizeCell);
                return;
            }
            if (obj.PrevY == obj.Y && obj.PrevX > obj.X)
            {
                mapGraphics.FillRectangle(Brushes.Black, obj.PrevX * MainForm.sizeCell, obj.Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                mapGraphics.DrawImage(obj.Img, obj.X * MainForm.sizeCell, obj.Y * MainForm.sizeCell, MainForm.sizeCell, MainForm.sizeCell);
                return;
            }

        }

    }
}
