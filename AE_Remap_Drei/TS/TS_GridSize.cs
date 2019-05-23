﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TS
{
	public class TS_GridSize 
	{
		public event EventHandler ChangeGridSize;
		public event EventHandler ChangeDispMax;
		public event EventHandler ChangeDisp;

		private int m_CellWidth;
		private int m_CellHeight;
		private int m_CaptionHeight;
		private int m_CaptionHeight2;
		private int m_FrameWidth;
        private int m_FrameWidth2;



        private int m_InterWidth;
		private int m_InterHeight;

		private Point m_Disp;
		private Point m_DispMax;
		private Rectangle m_DispCell;

		private Size m_DispSize;
		private int m_LayerCount;
		private int m_FrameCount;

		//-----------------------------------------------------
		public TS_GridSize()
		{
			m_CellWidth = 30;
			m_CellHeight = 16;
			m_FrameWidth = 90;
            m_FrameWidth2 = 20;
            m_CaptionHeight = 25;
			m_CaptionHeight2 = 20;

			m_Disp = new Point(0, 0);
			m_DispMax = new Point(0, 0);
			m_DispCell = new Rectangle(0, 0, 0, 0);

			m_DispSize = new Size(0, 0);
			m_FrameCount = 0;
			m_LayerCount = 0;

			m_InterWidth = 4;
			m_InterHeight = 4;

		}
		//---------------------------------------
		protected virtual void OnChangeGridSize(EventArgs e)
		{
			if (ChangeGridSize != null)
			{
				ChangeGridSize(this, e);
			}
		}
		//---------------------------------------
		protected virtual void OnChangeDispMax(EventArgs e)
		{
			if (ChangeDispMax != null)
			{
				ChangeDispMax(this, e);
			}
		}
		//---------------------------------------
		protected virtual void OnChangeDisp(EventArgs e)
		{
			if (ChangeDisp != null)
			{
				ChangeDisp(this, e);
			}
		}
		//---------------------------------------
		public int CellWidth
		{
			get { return m_CellWidth; }
			set { m_CellWidth = value; OnChangeGridSize(new EventArgs()); }
		}
		//---------------------------------------
		public int CellHeight
		{
			get { return m_CellHeight; }
			set { m_CellHeight = value; OnChangeGridSize(new EventArgs()); }
		}

		//---------------------------------------
		public int CaptionHeight
		{
			get { return m_CaptionHeight; }
			set { m_CaptionHeight = value; OnChangeGridSize(new EventArgs()); }
		}
		//---------------------------------------
		public int CaptionHeight2
		{
			get { return m_CaptionHeight2; }
			set { m_CaptionHeight2 = value; OnChangeGridSize(new EventArgs()); }
		}
		//---------------------------------------
		public int FrameWidth
		{
			get { return m_FrameWidth; }
			set { m_FrameWidth = value; OnChangeGridSize(new EventArgs()); }
		}
        //---------------------------------------
        public int FrameWidth2
        {
            get { return m_FrameWidth2; }
            set { m_FrameWidth2 = value; OnChangeGridSize(new EventArgs()); }
        }
        //---------------------------------------
        public int InterWidth
		{
			get { return m_InterWidth; }
			set { m_InterWidth = value; OnChangeGridSize(new EventArgs()); }
		}
		//---------------------------------------
		public int InterHeight
		{
			get { return m_InterHeight; }
			set { m_InterHeight = value; OnChangeGridSize(new EventArgs()); }
		}
		//---------------------------------------
		public void SetSize(Size sz,TS_CellData cd)
		{
			m_DispSize = sz;
			m_FrameCount = cd.FrameCount;
			m_LayerCount = cd.LayerCount;

			int ax = m_CellWidth * m_LayerCount - m_DispSize.Width;
			int ay = m_CellHeight * m_FrameCount - m_DispSize.Height;
			if (ax < 0) ax = 0;
			if (ay < 0) ay = 0;

			bool b = ((m_DispMax.X != ax) || (m_DispMax.Y != ay));
			m_DispMax.X = ax;
			m_DispMax.Y = ay;

			bool b2 = false;
			if (m_Disp.X > m_DispMax.X)
			{
				m_Disp.X = m_DispMax.X;
				b2 = true;
			}
			if (m_Disp.Y > m_DispMax.Y)
			{
				m_Disp.Y = m_DispMax.Y;
				b2 = true;
			}

			ChkDisp();



			if (b == true) OnChangeDispMax(new EventArgs());
			if (b2 == true) OnChangeDisp(new EventArgs());

		}
		//---------------------------------------
		public void ChkDisp()
		{
			m_DispCell.X = m_Disp.X / m_CellWidth -1;
			if (m_DispCell.X < 0) m_DispCell.X = 0;
			m_DispCell.Y = m_Disp.Y / m_CellHeight-1;
			if (m_DispCell.Y < 0) m_DispCell.Y = 0;

			m_DispCell.Width = m_DispSize.Width / m_CellWidth + 1;
			if (m_DispCell.Width > m_LayerCount) m_DispCell.Width = m_LayerCount;

			m_DispCell.Height = m_DispSize.Height / m_CellHeight +1;
			if (m_DispCell.Height > m_FrameCount) m_DispCell.Height = m_FrameCount;
		}
		//---------------------------------------
		public int DispX
		{
			get { return m_Disp.X; }
			set
			{
				int v = value;
				if (v < 0) v = 0;
				else if (v > m_DispMax.X) v = m_DispMax.X;
				if (m_Disp.X !=v)
				{
					m_Disp.X = v;
					ChkDisp();
					OnChangeDisp(new EventArgs());
				}
			}
		}
		//---------------------------------------
		public int DispY
		{
			get { return m_Disp.Y; }
			set
			{
				int v = value;
				if (v < 0) v = 0;
				else if (v > m_DispMax.Y) v = m_DispMax.Y;
				if (m_Disp.Y != v)
				{
					m_Disp.Y = v;
					ChkDisp();
					OnChangeDisp(new EventArgs()); 
				}
			}
		}
		//---------------------------------------
		public Point Disp
		{
			get { return m_Disp; }
		}
		//---------------------------------------
		public Point DispMax
		{
			get { return m_DispMax; }
		}
		public Rectangle DispCell
		{
			get { return m_DispCell; }
		}
		//---------------------------------------

	}
}
