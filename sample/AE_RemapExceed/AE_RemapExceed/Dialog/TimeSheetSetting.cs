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
	public partial class TimeSheetSetting : Form
	{
		private bool m_IsSecInput = false;

		//---------------------------------------------------------------------
		public TimeSheetSetting()
		{

			InitializeComponent();
			m_IsSecInput = false;

			SetSecInput();
			
			FrameRate = TSdef.FrameRate;
			CellCount = TSdef.CellCount;
			PageSec = TSdef.PageSec;
			FrameCount = TSdef.FrameCount;
			ZeroStart = TSdef.ZeroStart;
			FrameOffset = TSdef.FrameOffset;
		}
		//---------------------------------------------------------------------
		public void SetSecInput()
		{
			edSec.Enabled = edKoma.Enabled = lbSec.Enabled = lbKoma.Enabled = m_IsSecInput;
			edFrame.Enabled = lbFrame.Enabled = !m_IsSecInput;
		}
		//---------------------------------------------------------------------
		public bool SecInputMode
		{
			get { return m_IsSecInput; }
			set
			{
				m_IsSecInput = value;
				rbSec.Checked = value;
				rbFrame.Checked = !value;
				SetSecInput();
			}
		}
		//---------------------------------------------------------------------
		private void rfFrame_Click(object sender, EventArgs e)
		{
			SecInputMode = false;
		}
		//---------------------------------------------------------------------
		private void rbSec_Click(object sender, EventArgs e)
		{
			SecInputMode = true;
		}
		//---------------------------------------------------------------------
		public TSPageSec PageSec
		{
			get
			{
				if (cmbPageSec.SelectedIndex != 0) { return TSPageSec.sec3; }
				else { return TSPageSec.sec6; }
			}
			set
			{
				if (value == TSPageSec.sec6)
				{
					cmbPageSec.SelectedIndex = 0;
				}
				else
				{
					cmbPageSec.SelectedIndex = 1;
				}
			}
		}
		//---------------------------------------------------------------------
		public TSFps FrameRate
		{
			get {
				TSFps ret = TSFps.fps24;
				switch (cmbFps.SelectedIndex)
				{
					case 0: ret = TSFps.fps12; break;
					case 1: ret = TSFps.fps15; break;
					case 2: ret = TSFps.fps24; break;
					case 3: ret = TSFps.fps30; break;
				}
				return ret;
			}
			set { 
				switch (value)
				{
					case TSFps.fps12: cmbFps.SelectedIndex = 0; break;
					case TSFps.fps15: cmbFps.SelectedIndex = 1; break;
					case TSFps.fps24: cmbFps.SelectedIndex = 2; break;
					case TSFps.fps30: cmbFps.SelectedIndex = 3; break;
					default: cmbFps.SelectedIndex = 2; break;
				}
			}
		}
		//---------------------------------------------------------------------
		public int FrameCount
		{
			get {
				if (m_IsSecInput)
				{
					return edSec.Value * (int)FrameRate + edKoma.Value;
				}
				else
				{
					return edFrame.Value;
				}
			}
			set
			{
				edFrame.Value = value;
				edSec.Value = value / (int)FrameRate;
				edKoma.Value = value % (int)FrameRate;
			}
		}
		//---------------------------------------------------------------------
		public int CellCount
		{
			get { return edCellCount.Value; }
			set { 
				edCellCount.Value = value;
			}
		}
		//---------------------------------------------------------------------
		public bool ZeroStart
		{
			get { return cbZeroStart.Checked; }
			set { cbZeroStart.Checked = value; }
		}
		//---------------------------------------------------------------------
		public int FrameOffset
		{
			get { return edFrameOffset.Value; }
			set { edFrameOffset.Value = value; }
		}
		//---------------------------------------------------------------------
		//コメント入力時のリターン対策
		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex != 2)
			{
				this.AcceptButton = btnOK;
			}
			else
			{
				this.AcceptButton = null;
			}
		}
		//---------------------------------------------------------------------
		public void AddCmbText(ComboBox cmb, string s)
		{
			string ss = s.Trim();
			if (ss == "")
				return;
			if (cmb.Items.Count == 0)
			{
				cmb.Items.Add(ss);
				cmb.SelectedIndex = 0;
			}
			else
			{
				int si = -1;
				for (int i = 0; i < cmb.Items.Count; i++)
				{
					if (cmb.Items[i].ToString() == ss)
					{
						si = i;
						break;
					}
				}
				if (si >= 0)
				{
					cmb.Items.RemoveAt(si);
				}
				cmb.Items.Insert(0, ss);
				cmb.SelectedIndex = 0;
			}

		}
		//---------------------------------------------------------------------
		public string Title
		{
			get { return cmbTitle.Text; }
			set { AddCmbText(cmbTitle , value); }
		}
		//---------------------------------------------------------------------
		public string SubTitle
		{
			get { return cmbSubTitle.Text; }
			set { AddCmbText(cmbSubTitle, value); }
		}
		public string OPUS
		{
			get { return cmbOPUS.Text; }
			set { AddCmbText(cmbOPUS, value); }
		}
		public string SCECNE
		{
			get { return cmbSCECNE.Text; }
			set { AddCmbText(cmbSCECNE, value); }
		}
		public string CUT
		{
			get { return cmbCutNo.Text; }
			set { AddCmbText(cmbCutNo, value); }
		}
		public string CREATE_USER
		{
			get { return cmbCREATE_USER.Text; }
			set { AddCmbText(cmbCREATE_USER, value); }
		}
		public string UPDATE_USER
		{
			get { return cmbUPDATE_USER.Text; }
			set { AddCmbText(cmbUPDATE_USER, value); }
		}
		public string[] Comment
		{
			get { return textBox1.Lines; }
			set { textBox1.Lines = value; }
		}
	
		//---------------------------------------------------------------------
	}
}
