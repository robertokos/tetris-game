using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPFinal
{
    public class Square : Figure
    {
        Rectangle[] rectangle;

        Point location;

        public Square(Point location)
        {
            this.location = location;
            
            rectangle = new Rectangle[4];

            rectangle[0] = new Rectangle(location.X, location.Y, 21, 21);
            rectangle[1] = new Rectangle(location.X + 21, location.Y, 21, 21);
            rectangle[2] = new Rectangle(location.X, location.Y + 21, 21, 21);
            rectangle[3] = new Rectangle(location.X + 21, location.Y + 21, 21, 21);
        }

        public override Rectangle Rectangle(int index)
        {
            return rectangle[index];
        }

        public override void SetLocation(Point point)
        {
            location = point;
        }

        public override Point Location()
        {
            return location;
        }

        public override Rectangle[] Rectangle()
        {
            return rectangle;
        }

        public override void Draw(Graphics g)
        {
            foreach (Rectangle rect in rectangle)
            {
                Brush brush = new SolidBrush(SystemColors.ControlDark);
                g.FillRectangle(brush, rect.X + 1, rect.Y + 1, 19, 19);
                g.DrawRectangle(Pens.Black, rect.X + 1, rect.Y + 1, 19, 19);
            }
        }
        
        public override void MoveDown()
        {
            if(location.Y + 42 < 396)
            {
                for(int i = 0; i < 4; ++i)
                {
                    rectangle[i].Y += 7;
                }

                location.Y += 7;
            }
        }

        public override void MoveRight()
        {
            if(location.X + 42 < 215)
            {
                for (int i = 0; i < 4; ++i)
                {
                    rectangle[i].X += 21;
                }

                location.X += 21;
            }
        }

        public override void MoveLeft()
        {
            if(location.X > 5)
            {
                for (int i = 0; i < 4; ++i)
                {
                    rectangle[i].X -= 21;
                }

                location.X -= 21;
            }
            
        }

        public override void SetRect(int index, Rectangle rect)
        {
            rectangle[index] = rect;
        }

        public override void Rotate()
        {

        }
    }
}
