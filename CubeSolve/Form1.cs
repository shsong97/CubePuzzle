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
    public partial class Form1 : Form
    {
        int cubeSize = 3;
        int cubeWidth = 30;
        //enum CubeColor { White, Yellow, Green, Blue, Red, Orange };
        CubeColor currentColor = CubeColor.White;
        Color colorValue = Color.White;
        CubeMatrix c = new CubeMatrix();
        DataGridView[] gridArray = new DataGridView[6];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridArray[0] = dataGridView1;
            gridArray[1] = dataGridView2;
            gridArray[2] = dataGridView3;
            gridArray[3] = dataGridView4;
            gridArray[4] = dataGridView5;
            gridArray[5] = dataGridView6;

            for (int k = 0; k < 6; k++)
            {
                gridArray[k].RowCount = cubeSize;
                for (int i = 0; i < cubeSize; i++)
                {
                    gridArray[k].Rows[i].Height = cubeWidth;
                    gridArray[k].Columns[i].Width = cubeWidth;
                }
                gridArray[k].Size = new System.Drawing.Size(cubeSize * cubeWidth, cubeSize * cubeWidth);
            }
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            currentColor = CubeColor.White;
            colorValue = Color.White;
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            currentColor = CubeColor.Yellow;
            colorValue = Color.Yellow;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            currentColor = CubeColor.Green;
            colorValue = Color.Green;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            currentColor = CubeColor.Blue;
            colorValue = Color.Blue;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            currentColor = CubeColor.Red;
            colorValue = Color.Red;
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            currentColor = CubeColor.Orange;
            colorValue = Color.OrangeRed;
        }

        private void btnValidation_Click(object sender, EventArgs e)
        {
            if (!c.Validation())
            {
                MessageBox.Show("값이 잘못 할당된게 있습니다");
            }
            else
            {
                MessageBox.Show("정상입니다");
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            Cube f = new Cube();
            f.setCube(c);
            f.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            colorSet(0, e.RowIndex, e.ColumnIndex);
        }

        private void colorSet(int gridIndex, int row, int col)
        {
            c.setMatrix(gridIndex, row, col, (int)currentColor);
            gridArray[gridIndex].Rows[row].Cells[col].Style.BackColor = colorValue;
            txtMatrix.Text = c.Print();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            colorSet(4, e.RowIndex, e.ColumnIndex);
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            colorSet(2, e.RowIndex, e.ColumnIndex);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            colorSet(1, e.RowIndex, e.ColumnIndex);
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            colorSet(3, e.RowIndex, e.ColumnIndex);
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            colorSet(5, e.RowIndex, e.ColumnIndex);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PaintCube();
        }
        private void PaintCube()
        {
            for (int k = 0; k < 6; k++)
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        gridArray[k].Rows[row].Cells[col].Style.BackColor = c.GetColor(k, row, col);
                    }
                }
            }
        }
    }
}
