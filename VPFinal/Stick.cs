using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPFinal
{
    class Stick : Figure
    {
        Rectangle[] rectangle;

        Point location;

        bool isDefault;

        public Stick(Point location)
        {
            this.location = location;

            rectangle = new Rectangle[4];

            rectangle[0] = new Rectangle(location.X, location.Y, 21, 21);
            rectangle[1] = new Rectangle(location.X + 21, location.Y, 21, 21);
            rectangle[2] = new Rectangle(location.X + 42, location.Y, 21, 21);
            rectangle[3] = new Rectangle(location.X + 63, location.Y, 21, 21);

            isDefault = true;
        }

        public override void Draw(Graphics g)
        {
            foreach(Rectangle rect in rectangle)
            {
                g.FillRectangle(Brushes.DarkOrange, rect.X + 1, rect.Y + 1, 19, 19);
                g.DrawRectangle(Pens.Black, rect.X + 1, rect.Y + 1, 19, 19);
            }
        }

        public override void SetLocation(Point point)
        {
            location = point;
        }

        public override Point Location()
        {
            return location;
        }

        public override Rectangle Rectangle(int index)
        {
            return rectangle[index];
        }

        public override Rectangle[] Rectangle()
        {
            return rectangle;
        }

        public override void MoveDown()
        {
            if ((isDefault && location.Y + 21 < 396) || (!isDefault && location.Y + 63 < 396))
            {
                for (int i = 0; i < 4; ++i)
                {
                    rectangle[i].Y += 7;
                }

                location.Y += 7;
            }
        }

        public override void SetRect(int index, Rectangle rect)
        {
            rectangle[index] = rect;
        }

        public override void Rotate()
        {
            if(isDefault && location.Y + 84 < 396)
            {
                rectangle[3] = new Rectangle(location.X + 42, location.Y - 21, 21, 21);
                rectangle[2] = new Rectangle(location.X + 42, location.Y, 21, 21);
                rectangle[1] = new Rectangle(location.X + 42, location.Y + 21, 21, 21);
                rectangle[0] = new Rectangle(location.X + 42, location.Y + 42, 21, 21);

                isDefault = false;
            }

            else if(!isDefault && location.X >= 5 && location.X + 63 < 215)
            {
                rectangle[0] = new Rectangle(location.X, location.Y, 21, 21);
                rectangle[1] = new Rectangle(location.X + 21, location.Y, 21, 21);
                rectangle[2] = new Rectangle(location.X + 42, location.Y, 21, 21);
                rectangle[3] = new Rectangle(location.X + 63, location.Y, 21, 21);

                isDefault = true;
            }
        }

        public override void MoveLeft()
        {
            if ((isDefault && location.X > 5) || (!isDefault && location.X + 42 > 5))
            {
                for (int i = 0; i < 4; ++i)
                {
                    rectangle[i].X -= 21;
                }

                location.X -= 21;
            }
        }

        public override void MoveRight()
        {
            if ((isDefault && location.X + 84 < 215) || (!isDefault && location.X + 63 < 215))
            {
                for (int i = 0; i < 4; ++i)
                {
                    rectangle[i].X += 21;
                }

                location.X += 21;
            }
        }
    }
}
