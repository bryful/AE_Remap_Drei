using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE_Remap_Drei
{
	public partial class MainForm : System.Windows.Forms.Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

        private void tS_Grid1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TS_Dialog w = new TS_Dialog();
            w.ShowAnimationStyle = FormAnimationStyle.Roll;
            w.ShowAnimationDirection = FormAnimationDirection.TopToBottom;
            w.ShowAnimationSpeedMSec = 70;
            w.HideAnimationDirection = FormAnimationDirection.BottomToTop;
            w.HideAnimationSpeedMSec = 50;
            w.HideAnimationStyle = FormAnimationStyle.Roll;
            w.form = this;
            w.StartPosition = FormStartPosition.Manual;
            Point f = this.PointToScreen(new Point(0,100));
            w.Location = f;
            w.ShowDialog();
        }
    }
}
