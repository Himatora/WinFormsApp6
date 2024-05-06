using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp6.Objects
{
    class MyCircle : BaseObject
    {
        private int size=30;
        public MyCircle(float x,float y,float angle,int size):base(x,y,angle) { 
        this.size = size;
        }
        public int Size
        {
            get { return size; }
            set { size = value; } 
        }
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.GreenYellow), -size/2, -size/2, size, size);
            g.DrawEllipse(new Pen(Color.Green,2), -size / 2, -size / 2, size, size);
        }
        public void DescreaseSize(int amount)
        {
            size -= amount;
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }

    }
}
