using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CubeSolve
{
    public class CubeDraw
    {
        public CubeMatrix c;
        public void Cube2D(Graphics g, int size, int startx, int starty)
        {
            FillShape(g, 0, startx + size * 3, starty + 0, size);
            FillShape(g, 1, startx + size * 3, starty + size * 3, size);
            FillShape(g, 2, startx + 0, startx + size * 3, size);
            FillShape(g, 3, startx + size * 6, starty + size * 3, size);
            FillShape(g, 4, startx + size * 3, starty + size * 6, size);
            FillShape(g, 5, startx + size * 3, starty + size * 9, size);
        }
        public void Cube3D(Graphics g, int size, int startx, int starty)
        {
            int degree = 45;
            FillShapeSign(g, 0, startx + size * 3, starty + 0, size, degree);
            FillShape(g, 1, startx + size * 3, starty + size * 3, size);
            FillShapeSign2(g, 3, startx + size * 6, starty + size * 3, size, degree);            
        }
        public void setCube(CubeMatrix mat)
        {
            this.c = mat;
        }

        private void FillShape(Graphics g, int shape, int x, int y, int size)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    FillRect(g, c.GetColor(shape, i, j), x + j * size, y + i * size, size);
                }
            }
        }
        private void FillShapeSign(Graphics g, int shape, int x, int y, int size, int radian)
        {
            double rad = Math.PI * radian / 180.0;
            int cos = (int)(Math.Cos(rad) * size);
            int sign = (int)(Math.Sign(rad) * size);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    FillRectSign(g, c.GetColor(shape, i, j), x + (2-i) * cos+ j*size, y + i * sign, size, radian);
                }
            }
        }
        private void FillShapeSign2(Graphics g, int shape, int x, int y, int size, int radian)
        {
            double rad = Math.PI * radian / 180.0;
            int cos = (int)(Math.Cos(rad) * size);
            int sign = (int)(Math.Sign(rad) * size);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    FillRectSign2(g, c.GetColor(shape, i, j), x + j * cos, y - j * sign + i * size, size, radian);
                }
            }
        }
        private void FillRect(Graphics g, Color color, int x, int y, int size)
        {
            // Create solid brush.
            SolidBrush brush = new SolidBrush(color);
            
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 1);

            // Create rectangle.
            Rectangle rect = new Rectangle(x, y, size, size);

            // Fill rectangle to screen.
            g.FillRectangle(brush, rect);

            // Draw rectangle to screen.
            g.DrawRectangle(blackPen, rect);
        }
        private void FillRectSign(Graphics g, Color color, int x, int y, int size, int radian)
        {
            // 오른쪽 회전(x축변화)
            // Create solid brush.
            SolidBrush brush = new SolidBrush(color);
            // Create pen.
            Pen pen = new Pen(Color.Black, 1);
            double rad = Math.PI * radian / 180.0;
            int cos = (int)(Math.Cos(rad) * size);
            int sign = (int)(Math.Sign(rad) * size);
            // Create points that define polygon.
            Point point1 = new Point(x + cos, y - sign + size);
            Point point2 = new Point(x + cos + size, y - sign + size);
            Point point3 = new Point(x+size, y+size);
            Point point4 = new Point(x, y+size);
            
            Point[] curvePoints = { point1, point2, point3, point4};

            // Draw polygon to screen.
            g.FillPolygon(brush, curvePoints);
            g.DrawPolygon(pen, curvePoints);

        }
        private void FillRectSign2(Graphics g, Color color, int x, int y, int size, int radian)
        {
            // 왼쪽 회전(y축변화)
            // Create solid brush.
            SolidBrush brush = new SolidBrush(color);
            // Create pen.
            Pen pen = new Pen(Color.Black, 1);
            double rad = Math.PI * radian / 180.0;
            int cos = (int)(Math.Cos(rad) * size);
            int sign = (int)(Math.Sign(rad) * size);
            // Create points that define polygon.
            Point point1 = new Point(x, y);
            Point point2 = new Point(x + cos, y - sign);
            Point point3 = new Point(x + cos, y - sign + size);
            Point point4 = new Point(x, y + size);

            Point[] curvePoints = { point1, point2, point3, point4 };

            // Draw polygon to screen.
            g.FillPolygon(brush, curvePoints);
            g.DrawPolygon(pen, curvePoints);

        }
    }
}
