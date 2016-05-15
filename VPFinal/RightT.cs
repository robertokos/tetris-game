using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPFinal
{
    class RightT : Figure
    {
        Rectangle[] rectangle;

        Point location;

        bool[] form;

        public RightT(Point location)
        {
            this.location = location;

            rectangle = new Rectangle[4];

            rectangle[0] = new Rectangle(location.X, location.Y, 21, 21);
            rectangle[1] = new Rectangle(location.X + 21, location.Y, 21, 21);
            rectangle[2] = new Rectangle(location.X + 42, location.Y, 21, 21);
            rectangle[3] = new Rectangle(location.X + 42, location.Y + 21, 21, 21);

            form = new bool[4];

            form[0] = true;
            form[1] = false;
            form[2] = false;
            form[3] = false;
        }

        public override void Draw(Graphics g)
        {
            foreach (Rectangle rect in rectangle)
            {
                g.FillRectangle(Brushes.Violet, rect.X + 1, rect.Y + 1, 19, 19);
                g.DrawRectangle(Pens.Black, rect.X + 1, rect.Y + 1, 19, 19);
            }
        }

        public override Point Location()
        {
            return location;
        }

        public override Rectangle[] Rectangle()
        {
            return rectangle;
        }

        public override Rectangle Rectangle(int index)
        {
            return rectangle[index];
        }

        public override void SetLocation(Point point)
        {
            location = point;
        }

        public override void SetRect(int index, Rectangle rect)
        {
            rectangle[index] = rect;
        }
        public int GetForm()
        {
            for (int i = 0; i < 4; ++i)
            {
                if (form[i] == true) return i;
            }

            return -1;
        }

        public override void MoveDown()
        {
            if ((GetForm() != 2 && location.Y + 42 < 396) || (GetForm() == 2 && location.Y + 21 < 396))
            {
                for (int i = 0; i < 4; ++i)
                {
                    rectangle[i].Y += 7;
                }

                location.Y += 7;
            }
        }

        public override void MoveLeft()
        {
            if ((GetForm() != 3 && location.X > 5) || (GetForm() == 3 && location.X + 21 > 5))
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
            if ((GetForm() != 1 && location.X + 63 < 215) || (GetForm() == 1 && location.X + 42 < 215))
            {
                for (int i = 0; i < 4; ++i)
                {
                    rectangle[i].X += 21;
                }

                location.X += 21;
            }
        }

        public override void Rotate()
        {
            int i = GetForm();

            if (i == 0)
            {
                rectangle[0] = new Rectangle(location.X + 21, location.Y - 21, 21, 21);
                rectangle[1] = new Rectangle(location.X + 21, location.Y, 21, 21);
                rectangle[2] = new Rectangle(location.X + 21, location.Y + 21, 21, 21);
                rectangle[3] = new Rectangle(location.X, location.Y + 21, 21, 21);

                form[i] = false;
                form[i + 1] = true;
            }

            if (i == 1 && location.X + 42 < 215)
            {
                rectangle[0] = new Rectangle(location.X + 42, location.Y, 21, 21);
                rectangle[1] = new Rectangle(location.X + 21, location.Y, 21, 21);
                rectangle[2] = new Rectangle(location.X, location.Y, 21, 21);
                rectangle[3] = new Rectangle(location.X, location.Y - 21, 21, 21);

                form[i] = false;
                form[i + 1] = true;
            }

            if (i == 2 && location.Y + 42 < 396)
            {
                rectangle[0] = new Rectangle(location.X + 21, location.Y + 21, 21, 21);
                rectangle[1] = new Rectangle(location.X + 21, location.Y, 21, 21);
                rectangle[2] = new Rectangle(location.X + 21, location.Y - 21, 21, 21);
                rectangle[3] = new Rectangle(location.X + 42, location.Y - 21, 21, 21);

                form[i] = false;
                form[i + 1] = true;
            }

            if (i == 3 && location.X + 21 > 5)
            {
                rectangle[0] = new Rectangle(location.X, location.Y, 21, 21);
                rectangle[1] = new Rectangle(location.X + 21, location.Y, 21, 21);
                rectangle[2] = new Rectangle(location.X + 42, location.Y, 21, 21);
                rectangle[3] = new Rectangle(location.X + 42, location.Y + 21, 21, 21);

                form[i] = false;
                form[0] = true;
            }
        }
    }
}
