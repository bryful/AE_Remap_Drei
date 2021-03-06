﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AE_RemapExceed
{
	public enum funcCmd
	{
		//File
		New = 0,
		Open,
		Save,
		SaveAs,
		SaveToClip,
		Quit,
		//Edit
		Copy,
		Cut,
		Paste,
		ColorSetting,
		LayoutSetting,
		KeySetting,
		RemapSetting,

		//10Key
		ValueInput,
		ValueAutoInc,
		ValueAutoDec,
		ValueAutoSame,
		ValueBack,
		ValueDelete,
		SelectionALL,
		SelectionToEND,
		LayerMoveToLeft,
		LayerMoveToRight,
		LayerDataToClipboard,
		PageUp,
		PageDown,
		JumpTop,
		JumpEnd,

		SelTailInc,
		SelTailDec,
		SelHeadInc,
		SelHeadDec,

		LayerRemove,
		LayerInsert,
		LayerRename,

		FrameInsert,
		FrameDelete,

		AutoInput,

		ScriptToClip,
		ScriptToClipLayer,
		ScriptToFile,
		SystemSetting,
		About,

		Count
	}

	public delegate void funcEmt();
	public delegate void funcNumEmt(int v);
	public delegate void funcSelMove(Keys k);
	public delegate void menuFunc(object sender, EventArgs e);
	//------------------------------------------------
	public class TSFunctions
	{
		public const string Header = "AE_Remap KeyTable";
		public string[,] funcName = new string[(int)funcCmd.Count,2]
		{
			{"New","シート設定"},
			{"Open","読み込み"},
			{"Save","保存"},
			{"SaveAs","別名で保存"},
			{"SaveToClip","クリップボードへ複写"},
			{"Quit","終了"},

			{"Copy","コピー"},
			{"Cut","切り取り"},
			{"Paste","貼り込み"},

			{"ColorSetting","カラー設定"},
			{"LayoutSetting","グリッドサイズ設定"},
			{"KeySetting","キーボード設定"},
			{"RemapSetting","リマップ設定"},


			{"ValueInput","セル番号入力"},
			{"ValueAutoInc","自動入力＋"},
			{"ValueAutoDec","自動入力－"},
			{"ValueAutoSame","前のコマと同じ値を入力"},
			{"ValueBack","BackSpace"},
			{"ValueDelete","入力値をクリア"},
			{"SelectionALL","全選択"},
			{"SelectionToEND","ラストまで選択"},
			{"LayerMoveToLeft","レイヤを左へ移動"},
			{"LayerMoveToRight","レイヤを右へ移動"},
			{"LayerDataToClipboard","KeyFrameDataをクリップボードへ"},
			{"PageUp","PageUp"},
			{"PageDown","PageDown"},
			{"JumpTop","先頭へ"},
			{"JumpEnd","最後へ"},
			{"SelTailInc","選択範囲の末尾を増やす"},
			{"SelTailDec","選択範囲の末尾を減らす"},
			{"SelHeadInc","選択範囲の先頭を増やす"},
			{"SelHeadDec","選択範囲の先頭を減らす"},
			{"LayerRemove","セルレイヤを削除"},
			{"LayerInsert","セルレイヤを挿入"},
			{"LayerRename","セルレイヤ名を変更"},

			{"FrameInsert","フレームを挿入"},
			{"FrameDelete","フレームを削除"},
			{"AutoInput","セルのリピート入力"},
			{"ScriptToClip","ScriptをClipboardへ"},
			{"ScriptToClipLayer","ScriptをClipboardへ(ターゲットのみ)"},
			{"ScriptToFile","Scriptを書き出し"},
			{"SystemSetting","システム設定"},
			{"About","Aboutダイアログ"}

		};
		//キーバインド関係
		//------------------------------------------------
		public class funcClass
		{
			public Keys key;
			public Keys keySub;
			public funcEmt func;
			public funcClass()
			{
				this.key = Keys.None;
				this.keySub = Keys.None;
				this.func = null;
			}
			public funcClass(Keys km, funcEmt f)
			{
				this.key = km;
				this.keySub = Keys.None;
				this.func = f;
			}
			public void Assign(funcClass c)
			{
				key = c.key;
				keySub = c.keySub;
				func = c.func;
			}
		}
		//------------------------------------------------
		private funcClass[] funcTable = new funcClass[(int)funcCmd.Count];
		//キーコードを修正、テンキー対策
		private int[] keyMap = new int[256];
		//数字入力
		private funcNumEmt NumFunction = null;
		private funcSelMove SelMoveFunction = null;
		//----------------------------------------------------------------------------------------
		public TSFunctions()
		{
			//テーブルの初期化
			for (int i = 0; i < (int)funcCmd.Count; i++)
			{
				funcTable[i] = new funcClass();
			}
			funcKeyInt();
			InitKeyMap();
		}
		//------------------------------------------------
		public void Assign(TSFunctions f)
		{
			for (int i = 0; i < (int)funcCmd.Count; i++)
			{
				funcTable[i].Assign(f.funcTable[i]);
			}
		}
		//------------------------------------------------
		public void funcKeyInt()
		{
			//File
			setKeyTable(funcCmd.New, Keys.Control | Keys.N, Keys.None);
			setKeyTable(funcCmd.Open, Keys.Control | Keys.O, Keys.None);
			setKeyTable(funcCmd.Save, Keys.Control | Keys.S, Keys.None);
			setKeyTable(funcCmd.SaveAs, Keys.Control | Keys.Shift | Keys.S, Keys.None);
			setKeyTable(funcCmd.SaveToClip, Keys.None, Keys.None);
			setKeyTable(funcCmd.Quit, Keys.Control | Keys.Q, Keys.None);
			//Edit
			setKeyTable(funcCmd.Copy, Keys.Control | Keys.C, Keys.None);
			setKeyTable(funcCmd.Cut, Keys.Control | Keys.X, Keys.None);
			setKeyTable(funcCmd.Paste, Keys.Control | Keys.V, Keys.None);
			setKeyTable(funcCmd.ColorSetting, Keys.Control | Keys.Alt | Keys.L, Keys.None);
			setKeyTable(funcCmd.LayoutSetting, Keys.Control | Keys.Alt | Keys.G, Keys.None);
			setKeyTable(funcCmd.KeySetting, Keys.Control | Keys.Alt | Keys.K, Keys.None);
			setKeyTable(funcCmd.RemapSetting, Keys.None, Keys.None);

			//Layer
			setKeyTable(funcCmd.LayerDataToClipboard, Keys.Control | Keys.E, Keys.None);

			setKeyTable(funcCmd.ValueInput, Keys.Return,Keys.None);
			setKeyTable(funcCmd.ValueAutoInc, Keys.Add, Keys.None);
			setKeyTable(funcCmd.ValueAutoDec, Keys.Subtract, Keys.None);
			setKeyTable(funcCmd.ValueAutoSame, Keys.Decimal, Keys.None);
			setKeyTable(funcCmd.ValueBack, Keys.Back, Keys.None);
			setKeyTable(funcCmd.ValueDelete, Keys.Delete, Keys.None);

			setKeyTable(funcCmd.SelectionALL, Keys.A | Keys.Control, Keys.None);
			setKeyTable(funcCmd.SelectionToEND, Keys.End | Keys.Control, Keys.None);

			setKeyTable(funcCmd.LayerMoveToLeft, Keys.Oemcomma, Keys.None);
			setKeyTable(funcCmd.LayerMoveToRight, Keys.OemPeriod, Keys.None);

			setKeyTable(funcCmd.PageUp, Keys.PageUp, Keys.None);
			setKeyTable(funcCmd.PageDown, Keys.PageDown, Keys.None);
			setKeyTable(funcCmd.JumpTop, Keys.Home, Keys.None);
			setKeyTable(funcCmd.JumpEnd, Keys.End, Keys.None);
			setKeyTable(funcCmd.JumpEnd, Keys.End, Keys.None);
			
			setKeyTable(funcCmd.SelTailInc, Keys.X, Keys.Multiply);
			setKeyTable(funcCmd.SelTailDec, Keys.Z, Keys.Divide);
			setKeyTable(funcCmd.SelHeadInc, Keys.None, Keys.None);
			setKeyTable(funcCmd.SelHeadDec, Keys.None, Keys.None);

			setKeyTable(funcCmd.LayerRemove, Keys.None, Keys.None);
			setKeyTable(funcCmd.LayerInsert, Keys.None, Keys.None);
			setKeyTable(funcCmd.LayerRename, Keys.None, Keys.None);

			setKeyTable(funcCmd.FrameInsert, Keys.None, Keys.None);
			setKeyTable(funcCmd.FrameDelete, Keys.None, Keys.None);

			setKeyTable(funcCmd.AutoInput, Keys.Control | Keys.J, Keys.None);
			setKeyTable(funcCmd.ScriptToClip, Keys.None, Keys.None);
			setKeyTable(funcCmd.ScriptToClipLayer, Keys.Alt | Keys.E, Keys.None);
			setKeyTable(funcCmd.ScriptToFile, Keys.None, Keys.None);
			setKeyTable(funcCmd.SystemSetting, Keys.None, Keys.None);
			setKeyTable(funcCmd.About, Keys.None, Keys.None);
	
		}
		//------------------------------------------------
		private void InitKeyMap()
		{
			for (int i = 0; i < 256; i++)
			{
				keyMap[i] = i;
			}
			int j=0;
			for (int i = (int)Keys.NumPad0; i <= (int)Keys.NumPad9; i++)
			{
				keyMap[i] = (int)Keys.D0 + j;
				j++;
			}
			keyMap[(int)Keys.OemQuestion] = (int)Keys.Divide;
			keyMap[(int)Keys.Oem1] = (int)Keys.Multiply;
			keyMap[(int)Keys.OemMinus] = (int)Keys.Subtract;
			keyMap[(int)Keys.Oemplus] = (int)Keys.Add;

		}
		//----------------------------------------------------------------------------------------
		public Keys GetKeyMap(Keys k)
		{
			long h = (long)k & 0xFFFF0000;
			long l = (long)k & 0x000000FF;

			l = keyMap[l];

			return (Keys)(h + l);
		}
		//----------------------------------------------------------------------------------------
		public void exec(Keys k)
		{
			if (k == Keys.None) return;
			Keys k2 = GetKeyMap(k);
			Keys kc = (Keys)((int)k2 & 0xFF);
			if ((kc >= Keys.D0) && (k2 <= Keys.D9))
			{
				if (NumFunction != null) NumFunction((int)k2 - (int)Keys.D0);
				return;
			}
			else if ( (kc >= Keys.Left) &&(kc <= Keys.Down))
			{
				if (SelMoveFunction != null) SelMoveFunction(k2);
				return;
			}

			for (int i = 0; i < (int)funcCmd.Count; i++)
			{
				if ( (funcTable[i].key == k2)||(funcTable[i].keySub == k2) )
				{
					if (funcTable[i].func != null)
					{
						funcTable[i].func();
						return;
					}
				}
			}

		}
		//----------------------------------------------------------------------------------------
		public void exec(funcCmd f)
		{
			if (funcTable[(int)f].func != null)
			{
				funcTable[(int)f].func();
			}
		}
		//----------------------------------------------------------------------------------------
		public void setKey(funcCmd f,Keys k)
		{
			funcTable[(int)f].key = GetKeyMap(k);
		}
		//----------------------------------------------------------------------------------------
		public void setFunc(funcCmd f, funcEmt e)
		{
			funcTable[(int)f].func = e;
		}
		//----------------------------------------------------------------------------------------
		public void setNumFunc(funcNumEmt e)
		{
			NumFunction = e;
		}
		//----------------------------------------------------------------------------------------
		public void setSelMoveFunc(funcSelMove e)
		{
			SelMoveFunction = e;
		}
		//----------------------------------------------------------------------------------------
		public Keys getKeyTable(funcCmd cmd)
		{
			return (Keys)funcTable[(int)cmd].key;
		}
		//----------------------------------------------------------------------------------------
		public Keys getKeyTableSub(funcCmd cmd)
		{
			return funcTable[(int)cmd].keySub;
		}
		//----------------------------------------------------------------------------------------
		public void setKeyTable(funcCmd cmd, Keys k)
		{
			funcTable[(int)cmd].key = k;
		}
		//----------------------------------------------------------------------------------------
		public void setKeyTableSub(funcCmd cmd, Keys k)
		{
			funcTable[(int)cmd].keySub = k;
		}
		//----------------------------------------------------------------------------------------
		public void setKeyTable(funcCmd cmd, Keys km, Keys ks)
		{
			funcTable[(int)cmd].key = km;
			funcTable[(int)cmd].keySub = ks;
		}
		//----------------------------------------------------------------------------------------
		public int FindKeyTable(Keys k)
		{
			for (int i = 0; i < (int)funcCmd.Count; i++)
			{
				if ( (funcTable[i].key == k)||(funcTable[i].keySub == k) )
				{
					return i;
				}
			}
			return -1;
		}
		//----------------------------------------------------------------------------------------
		public string KeyString(Keys k)
		{

			return "0x" +k.ToString("X");

		}
		//----------------------------------------------------------------------------------------
		public bool SaveToFile(string path)
		{
			string s = Header + "\r";
			for (int i = 0; i < funcTable.Length; i++)
			{
				s += funcName[i,0] + " = " + KeyString(funcTable[i].key) + "," + KeyString(funcTable[i].keySub)  + "\r";
			}
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
			System.IO.File.WriteAllText(path, s, enc);

			return true;
		}
		//----------------------------------------------------------------------------------------
		public Keys toKeys(string s)
		{
			Keys k;
			try
			{
				k = (Keys)Convert.ToInt32(s, 16);
			}
			catch
			{
				k = Keys.None;
			}
			return k;

		}
		//----------------------------------------------------------------------------------------
		public void setKeys(funcCmd cmd, string tag)
		{
			string[] sa = tag.Split(',');
			if (sa.Length < 2) return;
			sa[0] = sa[0].Trim();
			sa[1] = sa[1].Trim();

			funcTable[(int)cmd].key = toKeys(sa[0]);
			funcTable[(int)cmd].keySub = toKeys(sa[1]);
		}
		//----------------------------------------------------------------------------------------
		public int FindFuncName(string s)
		{
			int ret = -1;
			string ss = s.Trim();
			if (ss == string.Empty) return ret;
			try
			{
				for (int i = 0; i < funcName.Length; i++)
				{
					if (string.Compare(ss, funcName[i, 0], true) == 0)
					{
						ret = i;
						break;
					}
				}
			}
			catch
			{
			}
			return ret;
		}
		//----------------------------------------------------------------------------------------
		public bool LoadFromFile(string path)
		{
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
			if (File.Exists(path) == false) { return false; }
			string[] lines = System.IO.File.ReadAllLines(path, enc);

			if (lines.Length <= 1) return false;
			if (lines[0] != Header) return false;

			for (int i = 1; i < lines.Length; i++)
			{
				string[] sa = lines[i].Split('=');
				if (sa.Length < 2) continue;
				int idx = FindFuncName(sa[0]);
				if (idx >= 0)
				{
					setKeys((funcCmd)idx, sa[1]); 
				}
			}
			return true;
		}
		//----------------------------------------------------------------------------------------
	}

}
