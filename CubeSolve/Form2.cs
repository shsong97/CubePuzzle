using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CubeSolve
{
    public partial class Cube : Form
    {
        Graphics g;
        CubeDraw cd=new CubeDraw();
        CubeSolution cs = new CubeSolution();
        CubeMatrix[] resultList;
        int index = 0;
        public Cube()
        {
            InitializeComponent();
        }


        public void setCube(CubeMatrix mat)
        {
            cd.setCube(mat);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            cd.Cube2D(g,20,20,20);
            cd.Cube3D(g, 40, 220, 20);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            cd.c.Rotate((int)Shape.UP, true);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnUpBack_Click(object sender, EventArgs e)
        {
            cd.c.Rotate((int)Shape.UP, false);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnFront_Click(object sender, EventArgs e)
        {
            cd.c.Rotate((int)Shape.FRONT, true);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnFrontBack_Click(object sender, EventArgs e)
        {
            cd.c.Rotate((int)Shape.FRONT, false);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            cd.c.Rotate((int)Shape.RIGHT, true);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnRightBack_Click(object sender, EventArgs e)
        {
            cd.c.Rotate((int)Shape.RIGHT, false);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            cd.c.Rotate((int)Shape.LEFT, true);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnLeftBack_Click(object sender, EventArgs e)
        {
            cd.c.Rotate((int)Shape.LEFT, false);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnDownBack_Click(object sender, EventArgs e)
        {
            cd.c.Rotate((int)Shape.DOWN, true);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            cd.c.Rotate((int)Shape.DOWN, false);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnLeftTrans_Click(object sender, EventArgs e)
        {
            cd.c.Transform(3);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnUpTrans_Click(object sender, EventArgs e)
        {
            cd.c.Transform(0);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnRightTrans_Click(object sender, EventArgs e)
        {
            cd.c.Transform(2);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnDownTrans_Click(object sender, EventArgs e)
        {
            cd.c.Transform(1);
            txtMatrix.Text = cd.c.Print();
            Invalidate();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            cs.Solve();
            resultList = cs.GetList();
            txtMatrix.Text = "결과는 " + resultList.Count() + "회입니다";
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (index < 0)
                return;
            if (resultList.Count() == 0)
                return;

            txtMatrix.Text = resultList[index].Print();
            cd.setCube(resultList[index]);
            Invalidate();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index >= resultList.Count())
                return;
            if (resultList.Count() == 0)
                return;

            txtMatrix.Text = resultList[index].Print();
            cd.setCube(resultList[index]);
            Invalidate();
        } 
    }
}
