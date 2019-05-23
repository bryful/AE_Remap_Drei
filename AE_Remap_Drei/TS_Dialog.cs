using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AE_Remap_Drei
{
    #region 定数
    /// <summary>
    /// アニメーションの種類
    /// </summary>
    public enum FormAnimationStyle
    {
        /// <summary>
        /// アニメーションなし
        /// </summary>
        None,
        /// <summary>
        /// ロール
        /// </summary>
        Roll,
        /// <summary>
        /// スライド
        /// </summary>
        Slide,
        /// <summary>
        /// フェードイン/フェードアウト
        /// </summary>
        Blend
    }
    /// <summary>
    /// アニメーションする方向
    /// </summary>
    public enum FormAnimationDirection
    {
        /// <summary>
        /// 無指定
        /// </summary>
        None,
        /// <summary>
        /// 中央
        /// </summary>
        Center,
        /// <summary>
        /// →方向
        /// </summary>
        LeftToRight,
        /// <summary>
        /// ←方向
        /// </summary>
        RightToLeft,
        /// <summary>
        /// ↓方向
        /// </summary>
        TopToBottom,
        /// <summary>
        /// ↑方向
        /// </summary>
        BottomToTop,
        /// <summary>
        /// 右下方向へ
        /// </summary>
        LeftTopToRightBottom,
        /// <summary>
        /// 右上方向へ
        /// </summary>
        LeftBottomToRightTop,
        /// <summary>
        /// 左下方向へ
        /// </summary>
        RightTopToLeftBottom,
        /// <summary>
        /// 左上方向へ
        /// </summary>
        RightBottomToTopLeft
    }
    #endregion
    public partial class TS_Dialog : Form
    {
        private Form m_ParentForm = null;
        private Point m_mouseDown;
        public TS_Dialog()
        {
            InitializeComponent();
        }
        public Form form
        {
            get { return m_ParentForm; }
            set { m_ParentForm = value; }
        }
        #region 変数宣言
        private FormAnimationStyle[] _animationStyle = new FormAnimationStyle[2]{
            FormAnimationStyle.None, FormAnimationStyle.None
        };
        private FormAnimationDirection[] _animationDirection = new FormAnimationDirection[2]{
            FormAnimationDirection.None, FormAnimationDirection.None
        };
        private UInt32[] _animationSpeedMSec = new UInt32[2] { 0, 0 };

        /// <summary>
        /// 表示時アニメーションの種類
        /// </summary>
        [DefaultValue(FormAnimationStyle.None)]
        public FormAnimationStyle ShowAnimationStyle
        {
            get
            {
                return _animationStyle[1];
            }
            set
            {
                _animationStyle[1] = value;
            }
        }
        /// <summary>
        /// 表示時アニメーションの方向
        /// </summary>
        [DefaultValue(FormAnimationDirection.None)]
        public FormAnimationDirection ShowAnimationDirection
        {
            get
            {
                return _animationDirection[1];
            }
            set
            {
                _animationDirection[1] = value;
            }
        }
        /// <summary>
        /// 表示時アニメーションの速度(単位:ミリ秒)
        /// </summary>
        [DefaultValue(0)]
        public UInt32 ShowAnimationSpeedMSec
        {
            get
            {
                return _animationSpeedMSec[1];
            }
            set
            {
                _animationSpeedMSec[1] = value;
            }
        }
        /// <summary>
        /// 閉じる時のアニメーションの種類
        /// </summary>
        [DefaultValue(FormAnimationStyle.None)]
        public FormAnimationStyle HideAnimationStyle
        {
            get
            {
                return _animationStyle[0];
            }
            set
            {
                _animationStyle[0] = value;
            }
        }
        /// <summary>
        /// 閉じる時のアニメーションの方向
        /// </summary>
        [DefaultValue(FormAnimationDirection.None)]
        public FormAnimationDirection HideAnimationDirection
        {
            get
            {
                return _animationDirection[0];
            }
            set
            {
                _animationDirection[0] = value;
            }
        }
        /// <summary>
        /// 閉じる時のアニメーションの速度(単位:ミリ秒)
        /// </summary>
        [DefaultValue(0)]
        public UInt32 HideAnimationSpeedMSec
        {
            get
            {
                return _animationSpeedMSec[0];
            }
            set
            {
                _animationSpeedMSec[0] = value;
            }
        }
        #endregion

        #region Windowメッセージに依存する処理

        [Flags]
        private enum AnimationStyle
        {
            AW_NONE = 0,
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000
        }
        [DllImport("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hWnd, UInt32 dwTimeMSec, AnimationStyle dwFlags);

        private const int WM_SHOWWINDOW = 0x0018;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SHOWWINDOW)
            {
                WMShowWindow(ref m);
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        #endregion

        #region AnimateWindowを使ったフォームの表示/非表示時のアニメーション処理
        private static AnimationStyle[] FormAnimationStyleToStyle = {
            AnimationStyle.AW_NONE,    // None
            AnimationStyle.AW_NONE,    // Roll
            AnimationStyle.AW_SLIDE,   // Slide
            AnimationStyle.AW_BLEND,   // Blend
        };
        private static AnimationStyle[] FormAnimationDirectionToStyle = {
            AnimationStyle.AW_NONE,            // None
            AnimationStyle.AW_CENTER,          // Center
            AnimationStyle.AW_HOR_POSITIVE,    // LeftToRight
            AnimationStyle.AW_HOR_NEGATIVE,    // RightToLeft
            AnimationStyle.AW_VER_POSITIVE,    // TopToBottom
            AnimationStyle.AW_VER_NEGATIVE,    // BottomToTop
            AnimationStyle.AW_HOR_POSITIVE | AnimationStyle.AW_VER_POSITIVE,  // LeftTopToRightBottom
            AnimationStyle.AW_HOR_POSITIVE | AnimationStyle.AW_VER_NEGATIVE,  // LeftBottomToRightTop
            AnimationStyle.AW_HOR_NEGATIVE | AnimationStyle.AW_VER_POSITIVE,  // RightTopToLeftBottom
            AnimationStyle.AW_HOR_NEGATIVE | AnimationStyle.AW_VER_NEGATIVE,  // RightBottomToTopLeft
        };
        private bool AnimationEnabled(bool value)
        {
            int v = value ? 1 : 0;
            return (_animationStyle[v] != FormAnimationStyle.None)
                && (_animationDirection[v] != FormAnimationDirection.None);
        }
        private bool TryAnimateWindow(bool value)
        {
            if (AnimationEnabled(value))
            {
                int v = value ? 1 : 0;
                AnimationStyle flags = (value ? AnimationStyle.AW_ACTIVATE : AnimationStyle.AW_HIDE)
                    | FormAnimationStyleToStyle[(int)_animationStyle[v]]
                    | FormAnimationDirectionToStyle[(int)_animationDirection[v]];
                return AnimateWindow(Handle, _animationSpeedMSec[v], flags);
            }
            return false;
        }
        private void WMShowWindow(ref Message m)
        {
            base.WndProc(ref m);
            if (!DesignMode && m.LParam.ToInt32() == 0)
            {
                TryAnimateWindow(m.WParam.ToInt32() != 0);
            }
            return;
        }
        #endregion

        //-----------------------------------------------------------------
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                m_mouseDown = new Point(e.X, e.Y);
            }
        }
        //-----------------------------------------------------------------
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                int dx = e.X - m_mouseDown.X;
                int dy = e.Y - m_mouseDown.Y;
                this.Left = this.Left + dx;
                this.Top = this.Top + dy;
                if (m_ParentForm!=null)
                {
                    m_ParentForm.Left = m_ParentForm.Left + dx;
                    m_ParentForm.Top = m_ParentForm.Top + dy;
                }
            }
        }
        //-----------------------------------------------------------------
        public DialogResult ShowDlg(Form fm)
        {
            m_ParentForm = fm;

            if (m_ParentForm!=null)
            {

            }

            return ShowDialog();
        }
        //-----------------------------------------------------------------
    }
}
