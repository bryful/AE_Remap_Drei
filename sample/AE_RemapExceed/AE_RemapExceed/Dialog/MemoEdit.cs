using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AE_RemapExceed
{
	public partial class MemoEdit : Form
	{
		public MemoEdit()
		{
			InitializeComponent();
		}
		//---------------------------------------------------
		public string Memo
		{
			get { return tbMemo.Text; }
			set { tbMemo.Text = tbOrg.Text = value; }
		}
		//---------------------------------------------------
		public void setFrame(TSData tsd, int f)
		{
			groupBox1.Text = tsd.FrameStr2(f);
		}
		//---------------------------------------------------
	}
}
