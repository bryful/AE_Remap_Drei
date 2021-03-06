﻿namespace AE_RemapExceed
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSepa1 = new System.Windows.Forms.ToolStripSeparator();
			this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSaveToClip = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSepa2 = new System.Windows.Forms.ToolStripSeparator();
			this.scriptToFile = new System.Windows.Forms.ToolStripMenuItem();
			this.ScriptToClip = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSepa4 = new System.Windows.Forms.ToolStripSeparator();
			this.FileQuit = new System.Windows.Forms.ToolStripMenuItem();
			this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.EditCopyMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.EditCutMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.EditPasteMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSepa5 = new System.Windows.Forms.ToolStripSeparator();
			this.SettingMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.cmSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.LayoutSettingDlg = new System.Windows.Forms.ToolStripMenuItem();
			this.ColorSettingDlg = new System.Windows.Forms.ToolStripMenuItem();
			this.KeySettingDlg = new System.Windows.Forms.ToolStripMenuItem();
			this.RemapSettingDlg = new System.Windows.Forms.ToolStripMenuItem();
			this.SystemSettingDlg = new System.Windows.Forms.ToolStripMenuItem();
			this.LayerMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.cmLayer = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cellToClip = new System.Windows.Forms.ToolStripMenuItem();
			this.scriptToClipLayer = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSepa6 = new System.Windows.Forms.ToolStripSeparator();
			this.layerInsert = new System.Windows.Forms.ToolStripMenuItem();
			this.layerRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.LayerRename = new System.Windows.Forms.ToolStripMenuItem();
			this.FrameMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.cmFrame = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.FrameDisp = new System.Windows.Forms.ToolStripMenuItem();
			this.cmFrameDisp = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmFrameDisp_Frame = new System.Windows.Forms.ToolStripMenuItem();
			this.cmFrameDisp_PageFrame = new System.Windows.Forms.ToolStripMenuItem();
			this.cmFrameDisp_PageSecFrame = new System.Windows.Forms.ToolStripMenuItem();
			this.cmFrameDisp_SecFrame = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSepa7 = new System.Windows.Forms.ToolStripSeparator();
			this.frameEnabledON = new System.Windows.Forms.ToolStripMenuItem();
			this.frameEnabledOFF = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSepa8 = new System.Windows.Forms.ToolStripSeparator();
			this.frameInsert = new System.Windows.Forms.ToolStripMenuItem();
			this.frameDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.autoInput = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.ScriptToClipMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.tsNav1 = new AE_RemapExceed.TSNav();
			this.tsGrid1 = new AE_RemapExceed.TSGrid();
			this.tsCellCaption1 = new AE_RemapExceed.TSCellCaption();
			this.tsFrame1 = new AE_RemapExceed.TSFrame();
			this.tsInfo1 = new AE_RemapExceed.TSInfo();
			this.tsInput1 = new AE_RemapExceed.TSInput();
			this.tsMemo1 = new AE_RemapExceed.TSMemo();
			this.menuStrip1.SuspendLayout();
			this.cmSettings.SuspendLayout();
			this.cmLayer.SuspendLayout();
			this.cmFrame.SuspendLayout();
			this.cmFrameDisp.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.LayerMenu,
            this.FrameMenu,
            this.HelpMenu});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(484, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Enter += new System.EventHandler(this.MainForm_Enter);
			// 
			// FileMenu
			// 
			this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNew,
            this.MenuSepa1,
            this.FileOpen,
            this.FileSave,
            this.FileSaveAs,
            this.FileSaveToClip,
            this.MenuSepa2,
            this.scriptToFile,
            this.ScriptToClip,
            this.MenuSepa4,
            this.FileQuit});
			this.FileMenu.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FileMenu.Name = "FileMenu";
			this.FileMenu.Size = new System.Drawing.Size(56, 20);
			this.FileMenu.Text = "ファイル";
			this.FileMenu.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
			// 
			// FileNew
			// 
			this.FileNew.Name = "FileNew";
			this.FileNew.Size = new System.Drawing.Size(144, 22);
			this.FileNew.Text = "シート設定";
			this.FileNew.Click += new System.EventHandler(this.menu_Click);
			// 
			// MenuSepa1
			// 
			this.MenuSepa1.Name = "MenuSepa1";
			this.MenuSepa1.Size = new System.Drawing.Size(141, 6);
			// 
			// FileOpen
			// 
			this.FileOpen.Name = "FileOpen";
			this.FileOpen.Size = new System.Drawing.Size(144, 22);
			this.FileOpen.Text = "開く";
			this.FileOpen.Click += new System.EventHandler(this.menu_Click);
			// 
			// FileSave
			// 
			this.FileSave.Name = "FileSave";
			this.FileSave.Size = new System.Drawing.Size(144, 22);
			this.FileSave.Text = "保存";
			this.FileSave.Click += new System.EventHandler(this.menu_Click);
			// 
			// FileSaveAs
			// 
			this.FileSaveAs.Name = "FileSaveAs";
			this.FileSaveAs.Size = new System.Drawing.Size(144, 22);
			this.FileSaveAs.Text = "別名で保存";
			this.FileSaveAs.Click += new System.EventHandler(this.menu_Click);
			// 
			// FileSaveToClip
			// 
			this.FileSaveToClip.Enabled = false;
			this.FileSaveToClip.Name = "FileSaveToClip";
			this.FileSaveToClip.Size = new System.Drawing.Size(144, 22);
			this.FileSaveToClip.Text = "SaveToClip";
			this.FileSaveToClip.Click += new System.EventHandler(this.menu_Click);
			// 
			// MenuSepa2
			// 
			this.MenuSepa2.Name = "MenuSepa2";
			this.MenuSepa2.Size = new System.Drawing.Size(141, 6);
			// 
			// scriptToFile
			// 
			this.scriptToFile.Name = "scriptToFile";
			this.scriptToFile.Size = new System.Drawing.Size(144, 22);
			this.scriptToFile.Text = "ScriptToFile";
			this.scriptToFile.Click += new System.EventHandler(this.menu_Click);
			// 
			// ScriptToClip
			// 
			this.ScriptToClip.Name = "ScriptToClip";
			this.ScriptToClip.Size = new System.Drawing.Size(144, 22);
			this.ScriptToClip.Text = "ScriptToClip";
			this.ScriptToClip.Click += new System.EventHandler(this.menu_Click);
			// 
			// MenuSepa4
			// 
			this.MenuSepa4.Name = "MenuSepa4";
			this.MenuSepa4.Size = new System.Drawing.Size(141, 6);
			// 
			// FileQuit
			// 
			this.FileQuit.Name = "FileQuit";
			this.FileQuit.Size = new System.Drawing.Size(144, 22);
			this.FileQuit.Text = "終了";
			this.FileQuit.Click += new System.EventHandler(this.menu_Click);
			// 
			// EditMenu
			// 
			this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditCopyMenu,
            this.EditCutMenu,
            this.EditPasteMenu,
            this.MenuSepa5,
            this.SettingMenu});
			this.EditMenu.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.EditMenu.Name = "EditMenu";
			this.EditMenu.Size = new System.Drawing.Size(45, 20);
			this.EditMenu.Text = "編集";
			this.EditMenu.Click += new System.EventHandler(this.EditMenu_Click);
			// 
			// EditCopyMenu
			// 
			this.EditCopyMenu.Name = "EditCopyMenu";
			this.EditCopyMenu.Size = new System.Drawing.Size(119, 22);
			this.EditCopyMenu.Text = "コピー";
			this.EditCopyMenu.Click += new System.EventHandler(this.menu_Click);
			// 
			// EditCutMenu
			// 
			this.EditCutMenu.Name = "EditCutMenu";
			this.EditCutMenu.Size = new System.Drawing.Size(119, 22);
			this.EditCutMenu.Text = "カット";
			this.EditCutMenu.Click += new System.EventHandler(this.menu_Click);
			// 
			// EditPasteMenu
			// 
			this.EditPasteMenu.Name = "EditPasteMenu";
			this.EditPasteMenu.Size = new System.Drawing.Size(119, 22);
			this.EditPasteMenu.Text = "貼り付け";
			this.EditPasteMenu.Click += new System.EventHandler(this.menu_Click);
			// 
			// MenuSepa5
			// 
			this.MenuSepa5.Name = "MenuSepa5";
			this.MenuSepa5.Size = new System.Drawing.Size(116, 6);
			// 
			// SettingMenu
			// 
			this.SettingMenu.DropDown = this.cmSettings;
			this.SettingMenu.Name = "SettingMenu";
			this.SettingMenu.Size = new System.Drawing.Size(119, 22);
			this.SettingMenu.Text = "設定...";
			// 
			// cmSettings
			// 
			this.cmSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LayoutSettingDlg,
            this.ColorSettingDlg,
            this.KeySettingDlg,
            this.RemapSettingDlg,
            this.SystemSettingDlg});
			this.cmSettings.Name = "cmSettings";
			this.cmSettings.OwnerItem = this.SettingMenu;
			this.cmSettings.Size = new System.Drawing.Size(154, 114);
			// 
			// LayoutSettingDlg
			// 
			this.LayoutSettingDlg.Name = "LayoutSettingDlg";
			this.LayoutSettingDlg.Size = new System.Drawing.Size(153, 22);
			this.LayoutSettingDlg.Text = "グリッド";
			this.LayoutSettingDlg.Click += new System.EventHandler(this.menu_Click);
			// 
			// ColorSettingDlg
			// 
			this.ColorSettingDlg.Name = "ColorSettingDlg";
			this.ColorSettingDlg.Size = new System.Drawing.Size(153, 22);
			this.ColorSettingDlg.Text = "カラー設定...";
			this.ColorSettingDlg.Click += new System.EventHandler(this.menu_Click);
			// 
			// KeySettingDlg
			// 
			this.KeySettingDlg.Name = "KeySettingDlg";
			this.KeySettingDlg.Size = new System.Drawing.Size(153, 22);
			this.KeySettingDlg.Text = "キーボード設定...";
			this.KeySettingDlg.Click += new System.EventHandler(this.menu_Click);
			// 
			// RemapSettingDlg
			// 
			this.RemapSettingDlg.Name = "RemapSettingDlg";
			this.RemapSettingDlg.Size = new System.Drawing.Size(153, 22);
			this.RemapSettingDlg.Text = "RemapSettings...";
			this.RemapSettingDlg.Click += new System.EventHandler(this.menu_Click);
			// 
			// SystemSettingDlg
			// 
			this.SystemSettingDlg.Name = "SystemSettingDlg";
			this.SystemSettingDlg.Size = new System.Drawing.Size(153, 22);
			this.SystemSettingDlg.Text = "SystemSetting";
			this.SystemSettingDlg.Click += new System.EventHandler(this.menu_Click);
			// 
			// LayerMenu
			// 
			this.LayerMenu.DropDown = this.cmLayer;
			this.LayerMenu.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LayerMenu.Name = "LayerMenu";
			this.LayerMenu.Size = new System.Drawing.Size(49, 20);
			this.LayerMenu.Text = "レイヤ";
			// 
			// cmLayer
			// 
			this.cmLayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cellToClip,
            this.scriptToClipLayer,
            this.MenuSepa6,
            this.layerInsert,
            this.layerRemove,
            this.LayerRename});
			this.cmLayer.Name = "cmLayer";
			this.cmLayer.OwnerItem = this.LayerMenu;
			this.cmLayer.Size = new System.Drawing.Size(186, 120);
			this.cmLayer.Opening += new System.ComponentModel.CancelEventHandler(this.cmLayer_Opening);
			// 
			// cellToClip
			// 
			this.cellToClip.Name = "cellToClip";
			this.cellToClip.Size = new System.Drawing.Size(185, 22);
			this.cellToClip.Text = "CellToClip";
			this.cellToClip.Click += new System.EventHandler(this.menu_Click);
			// 
			// scriptToClipLayer
			// 
			this.scriptToClipLayer.Name = "scriptToClipLayer";
			this.scriptToClipLayer.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.scriptToClipLayer.Size = new System.Drawing.Size(185, 22);
			this.scriptToClipLayer.Text = "ScriptToClipLayer";
			this.scriptToClipLayer.Click += new System.EventHandler(this.menu_Click);
			// 
			// MenuSepa6
			// 
			this.MenuSepa6.Name = "MenuSepa6";
			this.MenuSepa6.Size = new System.Drawing.Size(182, 6);
			// 
			// layerInsert
			// 
			this.layerInsert.Name = "layerInsert";
			this.layerInsert.Size = new System.Drawing.Size(185, 22);
			this.layerInsert.Text = "LayerInsert";
			this.layerInsert.Click += new System.EventHandler(this.menu_Click);
			// 
			// layerRemove
			// 
			this.layerRemove.Name = "layerRemove";
			this.layerRemove.Size = new System.Drawing.Size(185, 22);
			this.layerRemove.Text = "LayerRemove";
			this.layerRemove.Click += new System.EventHandler(this.menu_Click);
			// 
			// LayerRename
			// 
			this.LayerRename.Name = "LayerRename";
			this.LayerRename.Size = new System.Drawing.Size(185, 22);
			this.LayerRename.Text = "LayerRename";
			this.LayerRename.Click += new System.EventHandler(this.menu_Click);
			// 
			// FrameMenu
			// 
			this.FrameMenu.DropDown = this.cmFrame;
			this.FrameMenu.Name = "FrameMenu";
			this.FrameMenu.Size = new System.Drawing.Size(60, 20);
			this.FrameMenu.Text = "フレーム";
			// 
			// cmFrame
			// 
			this.cmFrame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FrameDisp,
            this.MenuSepa7,
            this.frameEnabledON,
            this.frameEnabledOFF,
            this.MenuSepa8,
            this.frameInsert,
            this.frameDelete,
            this.autoInput});
			this.cmFrame.Name = "contextMenuStrip1";
			this.cmFrame.OwnerItem = this.FrameMenu;
			this.cmFrame.Size = new System.Drawing.Size(165, 148);
			// 
			// FrameDisp
			// 
			this.FrameDisp.DropDown = this.cmFrameDisp;
			this.FrameDisp.Name = "FrameDisp";
			this.FrameDisp.Size = new System.Drawing.Size(164, 22);
			this.FrameDisp.Text = "フレーム表示";
			// 
			// cmFrameDisp
			// 
			this.cmFrameDisp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmFrameDisp_Frame,
            this.cmFrameDisp_PageFrame,
            this.cmFrameDisp_PageSecFrame,
            this.cmFrameDisp_SecFrame});
			this.cmFrameDisp.Name = "cmFrameDisp";
			this.cmFrameDisp.OwnerItem = this.FrameDisp;
			this.cmFrameDisp.Size = new System.Drawing.Size(206, 92);
			// 
			// cmFrameDisp_Frame
			// 
			this.cmFrameDisp_Frame.Name = "cmFrameDisp_Frame";
			this.cmFrameDisp_Frame.Size = new System.Drawing.Size(205, 22);
			this.cmFrameDisp_Frame.Text = "FrameDsip_Frame";
			this.cmFrameDisp_Frame.Click += new System.EventHandler(this.FrameDisp_Frame_Click);
			// 
			// cmFrameDisp_PageFrame
			// 
			this.cmFrameDisp_PageFrame.Name = "cmFrameDisp_PageFrame";
			this.cmFrameDisp_PageFrame.Size = new System.Drawing.Size(205, 22);
			this.cmFrameDisp_PageFrame.Text = "FrameDsip_PageFrame";
			this.cmFrameDisp_PageFrame.Click += new System.EventHandler(this.FrameDisp_PageFrame_Click);
			// 
			// cmFrameDisp_PageSecFrame
			// 
			this.cmFrameDisp_PageSecFrame.Name = "cmFrameDisp_PageSecFrame";
			this.cmFrameDisp_PageSecFrame.Size = new System.Drawing.Size(205, 22);
			this.cmFrameDisp_PageSecFrame.Text = "FrameDsip_PageSecFrame";
			this.cmFrameDisp_PageSecFrame.Click += new System.EventHandler(this.FrameDisp_PageSecFrame_Click);
			// 
			// cmFrameDisp_SecFrame
			// 
			this.cmFrameDisp_SecFrame.Name = "cmFrameDisp_SecFrame";
			this.cmFrameDisp_SecFrame.Size = new System.Drawing.Size(205, 22);
			this.cmFrameDisp_SecFrame.Text = "FrameDsip_SecFrame";
			this.cmFrameDisp_SecFrame.Click += new System.EventHandler(this.FrameDisp_SecFrame_Click);
			// 
			// MenuSepa7
			// 
			this.MenuSepa7.Name = "MenuSepa7";
			this.MenuSepa7.Size = new System.Drawing.Size(161, 6);
			// 
			// frameEnabledON
			// 
			this.frameEnabledON.Name = "frameEnabledON";
			this.frameEnabledON.Size = new System.Drawing.Size(164, 22);
			this.frameEnabledON.Text = "FrameEnabledON";
			this.frameEnabledON.Click += new System.EventHandler(this.frameEnabledONToolStripMenuItem_Click);
			// 
			// frameEnabledOFF
			// 
			this.frameEnabledOFF.Name = "frameEnabledOFF";
			this.frameEnabledOFF.Size = new System.Drawing.Size(164, 22);
			this.frameEnabledOFF.Text = "FrameEnabledOFF";
			this.frameEnabledOFF.Click += new System.EventHandler(this.frameEnabledOFFToolStripMenuItem_Click);
			// 
			// MenuSepa8
			// 
			this.MenuSepa8.Name = "MenuSepa8";
			this.MenuSepa8.Size = new System.Drawing.Size(161, 6);
			// 
			// frameInsert
			// 
			this.frameInsert.Name = "frameInsert";
			this.frameInsert.Size = new System.Drawing.Size(164, 22);
			this.frameInsert.Text = "FrameInsert";
			this.frameInsert.Click += new System.EventHandler(this.menu_Click);
			// 
			// frameDelete
			// 
			this.frameDelete.Name = "frameDelete";
			this.frameDelete.Size = new System.Drawing.Size(164, 22);
			this.frameDelete.Text = "FrameDelete";
			this.frameDelete.Click += new System.EventHandler(this.menu_Click);
			// 
			// autoInput
			// 
			this.autoInput.Name = "autoInput";
			this.autoInput.Size = new System.Drawing.Size(164, 22);
			this.autoInput.Text = "AutoInput";
			this.autoInput.Click += new System.EventHandler(this.menu_Click);
			// 
			// HelpMenu
			// 
			this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpAbout});
			this.HelpMenu.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.HelpMenu.Name = "HelpMenu";
			this.HelpMenu.Size = new System.Drawing.Size(43, 20);
			this.HelpMenu.Text = "Help";
			// 
			// HelpAbout
			// 
			this.HelpAbout.Name = "HelpAbout";
			this.HelpAbout.Size = new System.Drawing.Size(116, 22);
			this.HelpAbout.Text = "About...";
			this.HelpAbout.Click += new System.EventHandler(this.menu_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 522);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(484, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			this.statusStrip1.Enter += new System.EventHandler(this.MainForm_Enter);
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.AutoSize = false;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(150, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// ScriptToClipMenu
			// 
			this.ScriptToClipMenu.Name = "ScriptToClipMenu";
			this.ScriptToClipMenu.Size = new System.Drawing.Size(152, 22);
			this.ScriptToClipMenu.Text = "ScriptToClip";
			this.ScriptToClipMenu.Click += new System.EventHandler(this.menu_Click);
			// 
			// tsNav1
			// 
			this.tsNav1.Font = new System.Drawing.Font("MS UI Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tsNav1.Location = new System.Drawing.Point(449, 53);
			this.tsNav1.Name = "tsNav1";
			this.tsNav1.Size = new System.Drawing.Size(21, 446);
			this.tsNav1.TabIndex = 12;
			this.tsNav1.TabStop = false;
			this.tsNav1.Text = "tsNav1";
			this.tsNav1.TSGrid = this.tsGrid1;
			// 
			// tsGrid1
			// 
			this.tsGrid1.CausesValidation = false;
			this.tsGrid1.CellIndex = 0;
			this.tsGrid1.ContextMenuStrip = this.cmFrame;
			this.tsGrid1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tsGrid1.Location = new System.Drawing.Point(87, 51);
			this.tsGrid1.Name = "tsGrid1";
			this.tsGrid1.OffsetY = 0;
			this.tsGrid1.Size = new System.Drawing.Size(280, 448);
			this.tsGrid1.TabIndex = 4;
			this.tsGrid1.TabStop = false;
			this.tsGrid1.Text = "tsGrid1";
			this.tsGrid1.TSCellCaption = this.tsCellCaption1;
			this.tsGrid1.TSFrame = this.tsFrame1;
			this.tsGrid1.TSInfo = this.tsInfo1;
			this.tsGrid1.TSInput = this.tsInput1;
			this.tsGrid1.TSMemo = this.tsMemo1;
			this.tsGrid1.TSNav = this.tsNav1;
			this.tsGrid1.SelectionChanged += new System.EventHandler(this.tsGrid1_SelectionChanged);
			this.tsGrid1.KeyBindChanged += new System.EventHandler(this.tsGrid1_KeyBindChanged);
			this.tsGrid1.SizeChanged += new System.EventHandler(this.tsGrid1_SizeChanged);
			// 
			// tsCellCaption1
			// 
			this.tsCellCaption1.ContextMenuStrip = this.cmLayer;
			this.tsCellCaption1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tsCellCaption1.Location = new System.Drawing.Point(87, 27);
			this.tsCellCaption1.Name = "tsCellCaption1";
			this.tsCellCaption1.Size = new System.Drawing.Size(280, 21);
			this.tsCellCaption1.TabIndex = 8;
			this.tsCellCaption1.TabStop = false;
			this.tsCellCaption1.Text = "メモ";
			this.tsCellCaption1.TSGrid = this.tsGrid1;
			// 
			// tsFrame1
			// 
			this.tsFrame1.ContextMenuStrip = this.cmFrame;
			this.tsFrame1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.tsFrame1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tsFrame1.Location = new System.Drawing.Point(0, 53);
			this.tsFrame1.Name = "tsFrame1";
			this.tsFrame1.Size = new System.Drawing.Size(80, 446);
			this.tsFrame1.TabIndex = 7;
			this.tsFrame1.TabStop = false;
			this.tsFrame1.Text = "tsFrame1";
			this.tsFrame1.TSGrid = this.tsGrid1;
			this.tsFrame1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tsFrame1_MouseDoubleClick);
			// 
			// tsInfo1
			// 
			this.tsInfo1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tsInfo1.FrameCount = 288;
			this.tsInfo1.FrameRate = AE_RemapExceed.TSFps.fps24;
			this.tsInfo1.Location = new System.Drawing.Point(373, 28);
			this.tsInfo1.Name = "tsInfo1";
			this.tsInfo1.Size = new System.Drawing.Size(69, 20);
			this.tsInfo1.TabIndex = 13;
			this.tsInfo1.TabStop = false;
			this.tsInfo1.Text = "tsInfo1";
			this.tsInfo1.TSGrid = this.tsGrid1;
			// 
			// tsInput1
			// 
			this.tsInput1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tsInput1.Location = new System.Drawing.Point(0, 25);
			this.tsInput1.Name = "tsInput1";
			this.tsInput1.Size = new System.Drawing.Size(80, 20);
			this.tsInput1.TabIndex = 10;
			this.tsInput1.TabStop = false;
			this.tsInput1.Text = "tsInput1";
			this.tsInput1.TSGrid = this.tsGrid1;
			// 
			// tsMemo1
			// 
			this.tsMemo1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.tsMemo1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tsMemo1.Location = new System.Drawing.Point(373, 53);
			this.tsMemo1.Name = "tsMemo1";
			this.tsMemo1.Size = new System.Drawing.Size(69, 446);
			this.tsMemo1.TabIndex = 11;
			this.tsMemo1.TabStop = false;
			this.tsMemo1.Text = "tsMemo1";
			this.tsMemo1.TSGrid = this.tsGrid1;
			this.tsMemo1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tsMemo1_MouseDoubleClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 544);
			this.Controls.Add(this.tsNav1);
			this.Controls.Add(this.tsMemo1);
			this.Controls.Add(this.tsInput1);
			this.Controls.Add(this.tsCellCaption1);
			this.Controls.Add(this.tsGrid1);
			this.Controls.Add(this.tsFrame1);
			this.Controls.Add(this.tsInfo1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "AE_Remap Exceed Beta3";
			this.Enter += new System.EventHandler(this.MainForm_Enter);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.cmSettings.ResumeLayout(false);
			this.cmLayer.ResumeLayout(false);
			this.cmFrame.ResumeLayout(false);
			this.cmFrameDisp.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private TSGrid tsGrid1;
		private TSFrame tsFrame1;
		private TSCellCaption tsCellCaption1;
		private System.Windows.Forms.ToolStripMenuItem FileMenu;
		private System.Windows.Forms.ToolStripMenuItem FileOpen;
		private System.Windows.Forms.ToolStripMenuItem FileSave;
		private System.Windows.Forms.ToolStripMenuItem FileQuit;
		private System.Windows.Forms.ToolStripMenuItem EditMenu;
		private TSInput tsInput1;
		private TSMemo tsMemo1;
		private System.Windows.Forms.ToolStripMenuItem EditCopyMenu;
		private System.Windows.Forms.ToolStripMenuItem EditCutMenu;
		private System.Windows.Forms.ToolStripMenuItem EditPasteMenu;
		private System.Windows.Forms.ToolStripSeparator MenuSepa5;
		private System.Windows.Forms.ToolStripMenuItem LayerMenu;
		private System.Windows.Forms.ToolStripMenuItem HelpMenu;
		private System.Windows.Forms.ToolStripMenuItem FrameMenu;
		private TSNav tsNav1;
		private System.Windows.Forms.ToolStripMenuItem HelpAbout;
		private System.Windows.Forms.ToolStripMenuItem FileSaveAs;
		private System.Windows.Forms.ToolStripMenuItem FileNew;
		private System.Windows.Forms.ToolStripSeparator MenuSepa1;
		private System.Windows.Forms.ContextMenuStrip cmFrame;
		private System.Windows.Forms.ToolStripSeparator MenuSepa7;
		private System.Windows.Forms.ToolStripMenuItem frameEnabledON;
		private System.Windows.Forms.ToolStripMenuItem frameEnabledOFF;
		private System.Windows.Forms.ContextMenuStrip cmSettings;
		private System.Windows.Forms.ToolStripMenuItem ColorSettingDlg;
		private System.Windows.Forms.ToolStripMenuItem LayoutSettingDlg;
		private System.Windows.Forms.ToolStripMenuItem KeySettingDlg;
		private System.Windows.Forms.ToolStripMenuItem SettingMenu;
		private System.Windows.Forms.ToolStripMenuItem FileSaveToClip;
		private System.Windows.Forms.ToolStripMenuItem RemapSettingDlg;
		private System.Windows.Forms.ContextMenuStrip cmLayer;
		private System.Windows.Forms.ToolStripMenuItem cellToClip;
		private System.Windows.Forms.ToolStripMenuItem layerInsert;
		private System.Windows.Forms.ToolStripMenuItem layerRemove;
		private System.Windows.Forms.ToolStripMenuItem LayerRename;
		private System.Windows.Forms.ToolStripSeparator MenuSepa8;
		private System.Windows.Forms.ToolStripMenuItem frameInsert;
		private System.Windows.Forms.ToolStripMenuItem frameDelete;
		private System.Windows.Forms.ToolStripMenuItem autoInput;
		private TSInfo tsInfo1;
		private System.Windows.Forms.ToolStripSeparator MenuSepa4;
		private System.Windows.Forms.ToolStripSeparator MenuSepa6;
		private System.Windows.Forms.ToolStripSeparator MenuSepa2;
		private System.Windows.Forms.ToolStripMenuItem scriptToFile;
		private System.Windows.Forms.ToolStripMenuItem ScriptToClip;
		private System.Windows.Forms.ToolStripMenuItem ScriptToClipMenu;
		private System.Windows.Forms.ContextMenuStrip cmFrameDisp;
		private System.Windows.Forms.ToolStripMenuItem cmFrameDisp_Frame;
		private System.Windows.Forms.ToolStripMenuItem cmFrameDisp_PageFrame;
		private System.Windows.Forms.ToolStripMenuItem cmFrameDisp_PageSecFrame;
		private System.Windows.Forms.ToolStripMenuItem cmFrameDisp_SecFrame;
		private System.Windows.Forms.ToolStripMenuItem FrameDisp;
		private System.Windows.Forms.ToolStripMenuItem SystemSettingDlg;
		private System.Windows.Forms.ToolStripMenuItem scriptToClipLayer;
	}
}

