using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPFinal
{
    public enum DIRECTION
    {
        LEFT, RIGHT, DOWN
    }

    class Grid
    {
        List<Rectangle> list;

        static readonly int[] array = {5, 26, 47, 68, 89, 110, 131, 152, 173};

        Random random;

        Figure obj;

        int M;

        public Grid()
        {
            random = new Random();

            list = new List<Rectangle>();
            
            M = random.Next(7);
            
            if (M == 0)
            {
                int N = random.Next(9);
                obj = new Square(new Point(array[N], 18));
            }

            else if (M == 1)
            {
                int N = random.Next(7);
                obj = new Stick(new Point(array[N], 18));
            }

            else if(M == 2)
            {
                int N = random.Next(8);
                obj = new LThunder(new Point(array[N], 18));
            }

            else if(M == 3)
            {
                int N = random.Next(8);
                obj = new RThunder(new Point(array[N], 18));
            }

            else if (M == 4)
            {
                int N = random.Next(8);
                obj = new LeftT(new Point(array[N], 18));
            }

            else if (M == 5)
            {
                int N = random.Next(8);
                obj = new RightT(new Point(array[N], 18));
            }

            else if (M == 6)
            {
                int N = random.Next(8);
                obj = new Triangle(new Point(array[N], 18));
            }
        }

        public int RemoveFilledLines()
        {
            int q = 0;

            for(int k = 375; k >= 0; )
            {
                int c = 0;

                foreach (Rectangle rect in list)
                {
                    if (rect.Y == k)
                    {
                        c++;
                    }
                }

                if (c == 10)
                {
                    q++;

                    for (int i = 0; i < list.Count;)
                    {
                        if (list[i].Y == k)
                        {
                            list.Remove(list[i]);
                        }

                        else
                        {
                            ++i;
                        }
                    }

                    for (int i = 0; i < list.Count; ++i)
                    {
                        if (list[i].Y < k)
                        {
                            list[i] = new Rectangle(list[i].X, list[i].Y + 21, 21, 21);
                        }
                    }
                }

                else
                {
                    k -= 21;
                }
            }

            return q;
        }

        public bool CreateObject()
        {
            foreach(Rectangle rect in obj.Rectangle())
            {
                if(rect.Y == 18)
                {
                    list.Clear();
                    return false;           
                }
            }

            list.AddRange(obj.Rectangle());

            M = random.Next(7);
            
            if(M == 0)
            {
                int N = random.Next(9);
                obj = new Square(new Point(array[N], 18));
            }

            else if(M == 1)
            {
                int N = random.Next(7);
                obj = new Stick(new Point(array[N], 18));
            }

            else if (M == 2)
            {
                int N = random.Next(8);
                obj = new LThunder(new Point(array[N], 18));
            }

            else if (M == 3)
            {
                int N = random.Next(8);
                obj = new RThunder(new Point(array[N], 18));
            }

            else if (M == 4)
            {
                int N = random.Next(8);
                obj = new LeftT(new Point(array[N], 18));
            }

            else if (M == 5)
            {
                int N = random.Next(8);
                obj = new RightT(new Point(array[N], 18));
            }

            else if (M == 6)
            {
                int N = random.Next(8);
                obj = new Triangle(new Point(array[N], 18));
            }

            return true;
        }

        private bool MovingCheck(DIRECTION dir)
        {
            Figure fig = null;

            if (M == 0)
            {
                fig = new Square(obj.Location());
            }

            else if(M == 1)
            {
                fig = new Stick(obj.Location());
            }

            else if(M == 2)
            {
                fig = new LThunder(obj.Location());
            }

            else if (M == 3)
            {
                fig = new RThunder(obj.Location());
            }

            else if (M == 4)
            {
                fig = new LeftT(obj.Location());
            }

            else if (M == 5)
            {
                fig = new RightT(obj.Location());
            }

            else if (M == 6)
            {
                fig = new Triangle(obj.Location());
            }

            fig.SetRect(0, obj.Rectangle(0));
            fig.SetRect(1, obj.Rectangle(1));
            fig.SetRect(2, obj.Rectangle(2));
            fig.SetRect(3, obj.Rectangle(3));

            if (dir == DIRECTION.LEFT)
            {
                fig.MoveLeft();
            }

            else if(dir == DIRECTION.RIGHT)
            {
                fig.MoveRight();
            }

            else if(dir == DIRECTION.DOWN)
            {
                fig.MoveDown();
            }

            foreach (Rectangle rect in fig.Rectangle())
            {
                foreach(Rectangle r in list)
                {
                    if(rect.IntersectsWith(r))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Draw(Graphics g)
        {
            obj.Draw(g);
            
            foreach(Rectangle rect in list)
            {
                Brush brush = new SolidBrush(SystemColors.ControlDark);
                g.FillRectangle(brush, rect.X + 1, rect.Y + 1, 19, 19);
                g.DrawRectangle(Pens.Black, rect.X + 1, rect.Y + 1, 19, 19);
                brush.Dispose();
            }
        }

        public void MoveDown()
        {
            if(MovingCheck(DIRECTION.DOWN))
            {
                obj.MoveDown();
            }
        }

        public void MoveRight()
        {
            if(MovingCheck(DIRECTION.RIGHT))
            {
                obj.MoveRight();
            }
        }

        public void MoveLeft()
        {
            if(MovingCheck(DIRECTION.LEFT))
            {
                obj.MoveLeft();
            }
        }

        public bool canRotate()
        {
            Figure fig = null;

            if (M == 0)
            {
                fig = new Square(obj.Location());
            }

            else if (M == 1)
            {
                fig = new Stick(obj.Location());
            }

            else if (M == 2)
            {
                fig = new LThunder(obj.Location());
            }

            else if (M == 3)
            {
                fig = new RThunder(obj.Location());
            }

            else if (M == 4)
            {
                fig = new LeftT(obj.Location());
            }

            else if (M == 5)
            {
                fig = new RightT(obj.Location());
            }

            else if (M == 6)
            {
                fig = new Triangle(obj.Location());
            }

            //fig.SetRect()
            foreach(Rectangle rect in fig.Rectangle())
            {
                foreach(Rectangle r in list)
                {
                    if(rect.IntersectsWith(r))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Rotate()
        {
            if(canRotate())
            {
                obj.Rotate();
            }
        }
    }
}
