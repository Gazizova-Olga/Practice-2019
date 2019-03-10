using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class MainForm : Form
    {
        public static Random rnd = new Random();
        public static int sizeCell = 25;
        private Stats form;
        private PacmanController pacman;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            StatsBeat.Interval = GameBeat.Interval * 6;
            StatsBeat.Enabled = true;
            form = new Stats();
            form.Show();
            Activate();
            form.FormClosed += Form_FormClosed;
            btnStats.Enabled = false;
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnStats.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            map.Width = 650;
            map.Height = 650;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            ConfigForm config = new ConfigForm();
            config.ShowDialog();
            if (config.DialogResult == DialogResult.OK)
            {
                pacman = new PacmanController(config.ApplesCount, config.TanksCount);
                switch (config.Speed)
                {
                    case 0:
                        GameBeat.Interval = 70;
                        break;
                    case 1:
                        GameBeat.Interval = 60;
                        break;
                    case 2:
                        GameBeat.Interval = 50;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                return;
            }
            ShotBeat.Interval = GameBeat.Interval / 2;
            btnStats.Enabled = true;
            pacman.Start(this);
            GameBeat.Enabled = true;
            ShotBeat.Enabled = true;
        }

        private void RefreshStats()
        {
            form.ctrlStats.Rows.Clear();
            form.ctrlStats.Rows.Add(pacman.kolobok.GetType(), pacman.kolobok.X, pacman.kolobok.Y);
            for (int i = 0; i < pacman.Tanks.Count; i++)
            {
                form.ctrlStats.Rows.Add(pacman.Tanks[i].GetType(), pacman.Tanks[i].X, pacman.Tanks[i].Y);
            }

            for (int i = 0; i < pacman.Apples.Count; i++)
            {
                form.ctrlStats.Rows.Add(pacman.Apples[i].GetType(), pacman.Apples[i].X, pacman.Apples[i].Y);
            }

            for (int i = 0; i < pacman.ShotsKolobok.Count; i++)
            {
                form.ctrlStats.Rows.Add(pacman.ShotsKolobok[i].GetType(), pacman.ShotsKolobok[i].X, pacman.ShotsKolobok[i].Y);
            }

            for (int i = 0; i < pacman.ShotsTanks.Count; i++)
            {
                form.ctrlStats.Rows.Add(pacman.ShotsTanks[i].GetType(), pacman.ShotsTanks[i].X, pacman.ShotsTanks[i].Y);
            }
        }

        private void GameBeat_Tick(object sender, EventArgs e)
        {
            pacman.Step();
            lblScore.Text = pacman.Score.ToString();
            if (pacman.gameOver && pacman.Delta == 30)
            {
                GameBeat.Enabled = false;
                ShotBeat.Enabled = false;
                StatsBeat.Enabled = false;
                pacman.GameOver();
            }
        }

        private void ShotBeat_Tick(object sender, EventArgs e)
        {
            pacman.StepOfShots();
        }

        private void StatsBeat_Tick(object sender, EventArgs e)
        {
            if (form != null)
            {
                if (!form.IsDisposed)
                {
                    RefreshStats();
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            pacman.OnKeyPress(e.KeyCode);
        }
    }
}
