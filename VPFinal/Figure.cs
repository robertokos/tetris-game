using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPFinal
{
    abstract public class Figure
    {
        abstract public void Draw(Graphics g);

        abstract public void SetLocation(Point point);

        abstract public void SetRect(int index, Rectangle rect);

        abstract public void MoveDown();

        abstract public void MoveLeft();

        abstract public void MoveRight();

        abstract public void Rotate();

        abstract public Rectangle Rectangle(int index);

        abstract public Rectangle[] Rectangle();

        abstract public Point Location();
    }
}
