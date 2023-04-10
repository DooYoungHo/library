using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;


//한줄요약 : Panel을 상속받아 override를 통해 새로운 컨트롤 패널을 생성


//프로젝트 내부에서 새로운 클래스 cs파일을 만든후 복붙
//솔루션 다시 빌드하면 생성완료


namespace GradientPanelTest
{
    public class GrandientPanel : Panel
    {
        [Browsable(true)]
        public Color GraColorA
        {
            get;
            set;
        }

        [Browsable(true)]
        public Color GraColorB
        {
            get;
            set;
        }

        [Browsable(true)]
        public LinearGradientMode GradientFillStyle
        {
            get;
            set;
        }

        private Brush GradientBrush;

        public GrandientPanel()
        {
            handlerGradietnChanged = new EventHandler(GradientChanged);
            ResizeRedraw = true;
        }

        private EventHandler handlerGradietnChanged;

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            GradientBrush = new LinearGradientBrush(ClientRectangle, GraColorA, GraColorB, GradientFillStyle);
            e.Graphics.FillRectangle(GradientBrush, ClientRectangle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (GradientBrush != null)
                {
                    GradientBrush.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        protected void GradientChanged(object sender, EventArgs e)
        {
            if (GradientBrush != null)
            {
                GradientBrush.Dispose();
                GradientBrush = null;
                Invalidate();
            }
        }


    }
}