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
    public partial class ConfigForm : Form
    {
        public int ApplesCount { get; private set; }
        public int TanksCount { get; private set; }
        public int Speed { get; private set; }


        public ConfigForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ApplesCount = int.Parse(ctrlApples.Value.ToString());
            TanksCount = int.Parse(ctrlTanks.Value.ToString());
            Speed = int.Parse(ctrlSpeed.Value.ToString());
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }
    }
}
