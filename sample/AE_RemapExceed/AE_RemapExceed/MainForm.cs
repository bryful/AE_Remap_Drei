﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AE_RemapExceed
{
	public partial class MainForm : Form
	{
		public bool m_LayoutFlag = true;
		//--------------------------------------------------------------------------------------
		public MainForm()
		{
			InitializeComponent();
			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.m_MouseWheel);

			
			TSPref p = new TSPref(tsGrid1);
			if (p.PrefLoad())
			{
				this.Left = p.Left;
				this.Top = p.Top;
				this.Height = p.Height;
				tsGrid1.tsd.SetSize(p.CellCount, p.FrameCount);
				tsGrid1.GetStatus();
			}
			else
			{
				this.Left = 100;
				this.Top = 100;
				tsGrid1.GetStatus();
			}
			SetFrameDisp(tsGrid1.tsd.FrameDisp);
			SetLayout();
			toolStripStatusLabel1.Text = tsGrid1.SelInfo;
			ShortCutPre();

			string[] cmds;
			cmds = System.Environment.GetCommandLineArgs();
			//MessageBox.Show(System.Environment.CommandLine);
			//コマンドライン引数の表示
			if (cmds.Length > 1)
			{
				for (int i = 1; i < cmds.Length; i++)
				{
					string cmd = cmds[i];
					if ((cmd != "") && (cmd[0] != '-') && (cmd[0] != '/'))
					{
						string s = cmd;
						string e = Path.GetExtension(s);
						if (e == "") s += ".ard";
						if (File.Exists(s))
						{
							if (tsGrid1.LoadFromFile(s))
							{
								//MessageBox.Show("OK:" + s);
								break;
							}
							else
							{
								//MessageBox.Show("NG:" + s);
							}
						}
					}
				}
			}

		}
		//--------------------------------------------------------------------------------------
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (tsGrid1.SaveFlag)
			{
				DialogResult r = MessageBox.Show("ファイルを保存しますか？", "AE_Remap Exceed", MessageBoxButtons.YesNoCancel);
				switch (r)
				{
					case DialogResult.OK:
						tsGrid1.SaveAs();
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						return;
					case DialogResult.No:
						break;
				}
			}

		}
		//--------------------------------------------------------------------------------------
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			TSPref p = new TSPref(tsGrid1);
			p.Left = this.Left;
			p.Top = this.Top;
			p.Height = this.Height;
			p.PrefSave();
		}
		//--------------------------------------------------------------------------------------
		private void tsGrid1_SizeChanged(object sender, EventArgs e)
		{
			SetLayout();
		}
		//**********************************************************************************
		//コントロールの配置
		//**********************************************************************************
		public void SetLayout()
		{
			if (m_LayoutFlag == false) return;
			bool bak = m_LayoutFlag;
			m_LayoutFlag = false;

			this.SuspendLayout();
			int ww = this.Width - this.ClientSize.Width;
			int hh = this.Height - this.ClientSize.Height;
			int SP = 2;

			//最大値を計算
			int wMax = tsGrid1.tsd.widthMax + tsGrid1.tsd.FrameWidth + tsGrid1.tsd.MemoWidth + SP*5 + ww + tsNav1.Width;
			int hMax = tsGrid1.tsd.heightMax + tsGrid1.tsd.CaptionHeight + statusStrip1.Height + menuStrip1.Height + SP * 3 + hh ;
			int hMin = tsGrid1.tsd.CellHeight + tsGrid1.tsd.CaptionHeight + statusStrip1.Height + menuStrip1.Height + SP * 3 + hh;
			
			this.MaximumSize = new Size(wMax, hMax);
			this.MinimumSize = new Size(wMax, hMin);
			

			int h = this.ClientSize.Height - (statusStrip1.Height + menuStrip1.Height +  SP*3);
			int t = menuStrip1.Top + menuStrip1.Height +SP;

			tsInput1.Top = t;
			tsInput1.Left = SP;
			tsInput1.Width = tsGrid1.tsd.FrameWidth;
			tsInput1.Height = tsGrid1.tsd.CaptionHeight;

			tsCellCaption1.Top = tsInput1.Top;
			tsCellCaption1.Left = tsInput1.Left + tsInput1.Width + SP;
			tsCellCaption1.Width = tsGrid1.tsd.widthMax;
			tsCellCaption1.Height = tsInput1.Height;

			tsGrid1.Top = tsInput1.Top + tsInput1.Height + SP;
			tsGrid1.Left = tsCellCaption1.Left;
			tsGrid1.Width = tsCellCaption1.Width;
			tsGrid1.Height = h - (tsInput1.Height);



			tsFrame1.Left = tsInput1.Left;
			tsFrame1.Top = tsGrid1.Top;
			tsFrame1.Width = tsInput1.Width;
			tsFrame1.Height = tsGrid1.Height;

			tsMemo1.Left = tsGrid1.Left + tsGrid1.Width +SP;
			tsMemo1.Top = tsGrid1.Top;
			tsMemo1.Height = tsGrid1.Height;
			tsMemo1.Width = tsGrid1.tsd.MemoWidth;

			tsInfo1.Left = tsMemo1.Left;
			tsInfo1.Top = tsCellCaption1.Top;
			tsInfo1.Width = tsMemo1.Width;
			tsInfo1.Height = tsCellCaption1.Height;

			tsNav1.Top = tsGrid1.Top;
			tsNav1.Left = tsMemo1.Left + tsMemo1.Width + SP;
			tsNav1.Height = tsGrid1.Height;

			tsGrid1.GetStatus();
			m_LayoutFlag = bak;
			tsGrid1.Focus();
			this.ResumeLayout();
		}
		//--------------------------------------------------------------------------------------
		private void m_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int offsetY = tsGrid1.OffsetY;
			int ch = tsGrid1.tsd.CellHeight;
			int oY = offsetY / ch;
			if ((offsetY % ch) > 0)
				oY++;
			int y = oY * ch;
			y -= (e.Delta / 120) * ch;
			if (offsetY != y)
				tsGrid1.OffsetY = y;
		}
		//--------------------------------------------------------------------------------------
		private void MainForm_Resize(object sender, EventArgs e)
		{
			SetLayout();
			this.Invalidate();
		}

		private void MainForm_Enter(object sender, EventArgs e)
		{
			tsGrid1.Focus();
		}
		private void tsMemo1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int f = (e.Y + tsGrid1.OffsetY) / tsGrid1.tsd.CellHeight;
			MemoEdit me = new MemoEdit();
			me.Memo = tsGrid1.tsd.Memo(f);
			me.setFrame(tsGrid1.tsd, f);
			if (me.ShowDialog() == DialogResult.OK)
			{
				tsGrid1.tsd.Memo(f, me.Memo);
				//MessageBox.Show(me.Memo);
				tsMemo1.Invalidate();
			}
		}
		//**********************************************************************************
		//Fileメニュー
		//**********************************************************************************
		private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileSave.Enabled = tsGrid1.SaveFlag;
			FileSaveToClip.Enabled = tsGrid1.SaveFlag;
		}
		//**********************************************************************************
		//Editメニュー
		//**********************************************************************************
		private void EditMenu_Click(object sender, EventArgs e)
		{
			EditPasteMenu.Enabled = tsGrid1.ClipEnabled;
		}
		//**********************************************************************************
		//ページ
		//**********************************************************************************
		private void FrameDisp_Frame_Click(object sender, EventArgs e)
		{
			SetFrameDisp(TSFrameDisp.frame);
			this.Refresh();
		}
		//----------------------------------------------------------------------------------
		private void FrameDisp_PageFrame_Click(object sender, EventArgs e)
		{
			SetFrameDisp(TSFrameDisp.pageFrame);
			this.Refresh();
		}
		//----------------------------------------------------------------------------------
		private void FrameDisp_PageSecFrame_Click(object sender, EventArgs e)
		{
			SetFrameDisp(TSFrameDisp.paseSecFrame);
			this.Refresh();
		}
		//----------------------------------------------------------------------------------
		private void FrameDisp_SecFrame_Click(object sender, EventArgs e)
		{
			SetFrameDisp(TSFrameDisp.SecFrame);
			this.Refresh();
		}
		//**********************************************************************************
		//ショートカット処理
		//**********************************************************************************
		private void setMenuItem(ToolStripMenuItem menu, funcCmd cmd)
		{
			try
			{
				menu.ShortcutKeys = tsGrid1.funcs.getKeyTable(cmd);
			}
			catch
			{
				menu.ShortcutKeys = Keys.None;
			}
			menu.Text = tsGrid1.funcs.funcName[(int)cmd, 1];
			menu.Tag = (int)cmd;
		}
		public void ShortCutPre()
		{
			if (tsGrid1.funcs != null)
			{
				//File
				setMenuItem(FileNew, funcCmd.New);
				setMenuItem(FileOpen, funcCmd.Open);
				setMenuItem(FileSave, funcCmd.Save);
				setMenuItem(FileSaveAs, funcCmd.SaveAs);
				setMenuItem(FileSaveToClip, funcCmd.SaveToClip);
				setMenuItem(FileQuit, funcCmd.Quit);
				setMenuItem(ScriptToClip, funcCmd.ScriptToClip);
				setMenuItem(scriptToFile, funcCmd.ScriptToFile);

				//Edit
				setMenuItem(EditCopyMenu, funcCmd.Copy);
				setMenuItem(EditCutMenu, funcCmd.Cut);
				setMenuItem(EditPasteMenu, funcCmd.Paste);
				setMenuItem(ColorSettingDlg, funcCmd.ColorSetting);
				setMenuItem(LayoutSettingDlg, funcCmd.LayoutSetting);
				setMenuItem(KeySettingDlg, funcCmd.KeySetting);
				setMenuItem(RemapSettingDlg, funcCmd.RemapSetting);
				setMenuItem(SystemSettingDlg, funcCmd.SystemSetting);
				//Layer
				setMenuItem(cellToClip, funcCmd.LayerDataToClipboard);
				setMenuItem(scriptToClipLayer, funcCmd.ScriptToClipLayer);
				setMenuItem(layerInsert, funcCmd.LayerInsert);
				setMenuItem(layerRemove, funcCmd.LayerRemove);
				setMenuItem(LayerRename, funcCmd.LayerRename);
				//Frame
				setMenuItem(frameDelete, funcCmd.FrameDelete);
				setMenuItem(frameInsert, funcCmd.FrameInsert);
				setMenuItem(autoInput, funcCmd.AutoInput);
				setMenuItem(HelpAbout, funcCmd.About);

			}
		}
		private void menu_Click(object sender, EventArgs e)
		{
			tsGrid1.funcs.exec( (funcCmd)((ToolStripMenuItem)sender).Tag);
		}
		//----------------------------------------------------------------------------------
		public void SetFrameDisp(TSFrameDisp m)
		{
			cmFrameDisp_Frame.Checked = false;
			cmFrameDisp_PageFrame.Checked = false;
			cmFrameDisp_PageSecFrame.Checked = false;
			cmFrameDisp_SecFrame.Checked = false;
			
			tsGrid1.tsd.FrameDisp = m;
			switch (m)
			{
				case TSFrameDisp.frame:
					cmFrameDisp_Frame.Checked = true;
					break;
				case TSFrameDisp.pageFrame:
					cmFrameDisp_PageFrame.Checked = true;
					break;
				case TSFrameDisp.paseSecFrame:
					cmFrameDisp_PageSecFrame.Checked = true;
					break;
				case TSFrameDisp.SecFrame:
					cmFrameDisp_SecFrame.Checked = true;
					break;
			}
		}

		//----------------------------------------------------------------------------------
		private void frameEnabledONToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tsGrid1.SetFrameEnabledON();
		}
		//----------------------------------------------------------------------------------
		private void frameEnabledOFFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tsGrid1.SetFrameEnabledOFF();
		}

		//**********************************************************************************
 		//
		//**********************************************************************************

		private void tsGrid1_SelectionChanged(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text = tsGrid1.SelInfo;
		}

		private void tsGrid1_KeyBindChanged(object sender, EventArgs e)
		{
			ShortCutPre();
		}
		//----------------------------------------------------------------------------------
		private void tsFrame1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int v = (int)tsGrid1.tsd.FrameDisp;
			v += 1;
			if ((int)TSFrameDisp.Count <= v) { v = 0; }
			SetFrameDisp((TSFrameDisp)v);
			tsFrame1.Refresh();
			//MessageBox.Show("a");

		}

		private void cmLayer_Opening(object sender, CancelEventArgs e)
		{

		}

		private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			tsGrid1.KeyExec(e.KeyData);
		}

	


		//----------------------------------------------------------------------------------
	}
}
