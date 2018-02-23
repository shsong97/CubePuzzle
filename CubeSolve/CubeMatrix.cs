using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CubeSolve
{
    enum CubeColor { White=0, Yellow, Green, Blue, Red, Orange };
    enum Shape { UP=0, FRONT, LEFT, RIGHT, DOWN, BACK };

    public class CubeMatrix
    {
        #region variable
        int[][][] matrix=new int[6][][]; // 매트릭스의 색값 저장
        string[] shape = new string[] { "U", "F", "L", "R", "D", "B" }; // 각면의 명칭
        int[] shapeInt = new int[] { 0, 1, 2, 3, 4, 5 }; // 각면에 대한 1차원 배열
        #endregion

        #region public function
        // public function
        public CubeMatrix()
        {
            for (int i = 0; i < 6; i++)
            {// 각면
                matrix[i] = new int[3][];
                for (int j = 0; j < 3; j++)
                {
                    matrix[i][j] = new int[3] { i, i, i }; //각면의 색으로 통일
                }
            }
        }
        public string Print()
        {
            string matrix_string = "";
            for (int i = 0; i < 6; i++)
            {
                matrix_string+=shape[i]+"\n";
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        matrix_string += matrix[i][j][k] + " ";
                    }
                    matrix_string += "\n";
                }
                matrix_string += "\n";
            }
            return matrix_string;
        }
        public bool Validation()
        {
            int[] count = new int[6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        count[matrix[i][j][k]]++;
                    }
                }
            }

            // 모든 면의 색이 9개 값을 가지면 정상 아니면 에러
            for (int i = 0; i < 6; i++)
            {
                if (count[i] != 9)
                    return false;
            }

            return true;
        }
        public void setMatrix(int i, int j, int k, int value)
        {
            // 육면에 값이 아니면 변경하지 않음
            if(value>=0 && value<=5)
                matrix[i][j][k] = value;
        }
        public int[][][] getMatrix()
        {
            return matrix;
        }
        public void Rotate(int direction, bool clockwise)
        {
            // direction : Up(0), Front(1), Left(2), Right(3), Back(4), Down(5)
            rotateFront(direction, clockwise);
            rotateSide(direction, clockwise);
        }
        public void Transform(int direction)
        {
            int[][] temp = new int[3][];
            temp[0] = new int[3];
            temp[1] = new int[3];
            temp[2] = new int[3];

            switch (direction)
            {
                case 0://up
                    // U->B->D->F
                    temp = getShape((int)Shape.FRONT);
                    transShape((int)Shape.DOWN, (int)Shape.FRONT);
                    transShape((int)Shape.BACK, (int)Shape.DOWN);
                    transShape((int)Shape.UP, (int)Shape.BACK);
                    setShape((int)Shape.UP, temp, 0);

                    rotateFront((int)Shape.RIGHT, true);
                    rotateFront((int)Shape.LEFT, false);
                    break;
                case 1://down
                    // U->F->D->B
                    temp = getShape((int)Shape.BACK);
                    transShape((int)Shape.DOWN, (int)Shape.BACK);
                    transShape((int)Shape.FRONT, (int)Shape.DOWN);
                    transShape((int)Shape.UP, (int)Shape.FRONT);
                    setShape((int)Shape.UP, temp, 0);

                    rotateFront((int)Shape.RIGHT, false);
                    rotateFront((int)Shape.LEFT, true);
                    break;
                case 2://right
                    // L->F->R->B
                    temp = getShape((int)Shape.BACK);
                    transShape2((int)Shape.RIGHT, (int)Shape.BACK);
                    transShape((int)Shape.FRONT, (int)Shape.RIGHT);
                    transShape((int)Shape.LEFT, (int)Shape.FRONT);
                    setShape2((int)Shape.LEFT, temp, 0);

                    rotateFront((int)Shape.UP, false);
                    rotateFront((int)Shape.DOWN, true);
                    break;
                case 3://left
                    // R->F->L->B
                    temp = getShape((int)Shape.BACK);
                    transShape2((int)Shape.LEFT, (int)Shape.BACK);
                    transShape((int)Shape.FRONT, (int)Shape.LEFT);
                    transShape((int)Shape.RIGHT, (int)Shape.FRONT);
                    setShape2((int)Shape.RIGHT, temp, 0);

                    rotateFront((int)Shape.UP, true);
                    rotateFront((int)Shape.DOWN, false);
                    break;
            }
        }
        public int GetValue(int shape, int row, int col)
        {
            return matrix[shape][row][col];
        }
        public Color GetColor(int shape, int row, int col)
        {
            System.Drawing.Color color = System.Drawing.Color.White;
            switch (matrix[shape][row][col])
            { //White=0, Yellow, Green, Blue, Red, Orange
                case 0:
                    color = Color.White;
                    break;
                case 1:
                    color = Color.Yellow;
                    break;
                case 2:
                    color = Color.Green;
                    break;
                case 3:
                    color = Color.Blue;
                    break;
                case 4:
                    color = Color.Red;
                    break;
                case 5:
                    color = Color.Orange;
                    break;
            }
            return color;
        }
        #endregion

        #region private function
        // private function
        private void rotateFront(int currentShape, bool clockwise)
        {
            // 현재면의 값을 참고하여 정면 값 회전
            int [][]copyArray=new int[3][];
            for (int i = 0; i < 3; i++)
                copyArray[i] = new int[3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    copyArray[i][j] = matrix[currentShape][i][j];
                }
            }
            if (clockwise) // 시계방향
            {
                matrix[currentShape][0][2] = copyArray[0][0];
                matrix[currentShape][1][2] = copyArray[0][1];
                matrix[currentShape][2][2] = copyArray[0][2];

                matrix[currentShape][0][1] = copyArray[1][0];
                matrix[currentShape][1][1] = copyArray[1][1];
                matrix[currentShape][2][1] = copyArray[1][2];

                matrix[currentShape][0][0] = copyArray[2][0];
                matrix[currentShape][1][0] = copyArray[2][1];
                matrix[currentShape][2][0] = copyArray[2][2];
            }
            else
            {
                matrix[currentShape][2][0] = copyArray[0][0];
                matrix[currentShape][1][0] = copyArray[0][1];
                matrix[currentShape][0][0] = copyArray[0][2];

                matrix[currentShape][0][1] = copyArray[1][0];
                matrix[currentShape][1][1] = copyArray[1][1];
                matrix[currentShape][2][1] = copyArray[1][2];

                matrix[currentShape][0][0] = copyArray[2][0];
                matrix[currentShape][1][0] = copyArray[2][1];
                matrix[currentShape][2][0] = copyArray[2][2];
            }
        }
        private void rotateSide(int direction, bool clockwise)
        {
            // 어느 방향으로 회전하는지와 정/반대 방향인지를 가지고 회전
            // direction : Up(0), Front(1), Left(2), Right(3), Down(4), Back(5)
            // clockwise : clockwise(0) / counterclockwise(1)
            if (direction == 3)
            {   // Right
                if (clockwise)
                {
                    // F->U->B->D ( 뒤에서 부터 할당 )
                    int[] temp = getCol((int)Shape.DOWN, 2);
                    colMove((int)Shape.BACK, (int)Shape.DOWN, 2);
                    colMove((int)Shape.UP, (int)Shape.BACK, 2);
                    colMove((int)Shape.FRONT, (int)Shape.UP, 2);
                    setCol((int)Shape.FRONT, 2, temp, 0);
                }
                else
                {
                    // F->D->B->U ( 뒤에서 부터 할당 )
                    int[] temp = getCol((int)Shape.UP, 2);
                    colMove((int)Shape.BACK, (int)Shape.UP, 2);
                    colMove((int)Shape.DOWN, (int)Shape.BACK, 2);
                    colMove((int)Shape.FRONT, (int)Shape.DOWN, 2);
                    setCol((int)Shape.FRONT, 2, temp, 0);
                }
            }
            else if (direction == 2)
            {   // Left
                if (clockwise)
                {
                    // F->D->B->U ( 뒤에서 부터 할당 )
                    int[] temp = getCol((int)Shape.UP, 0);
                    colMove((int)Shape.BACK, (int)Shape.UP, 0);
                    colMove((int)Shape.DOWN, (int)Shape.BACK, 0);
                    colMove((int)Shape.FRONT, (int)Shape.DOWN, 0);
                    setCol((int)Shape.FRONT, 0, temp, 0);
                }
                else
                {
                    // F->U->B->D ( 뒤에서 부터 할당 )
                    int[] temp = getCol((int)Shape.DOWN, 0);
                    colMove((int)Shape.BACK, (int)Shape.DOWN, 0);
                    colMove((int)Shape.UP, (int)Shape.BACK, 0);
                    colMove((int)Shape.FRONT, (int)Shape.UP, 0);
                    setCol((int)Shape.FRONT, 0, temp, 0);
                }
            }
            else if (direction == 0)
            {   // Up
                if (clockwise)
                {
                    // F->L->B->R ( 뒤에서 부터 할당 )
                    int[] temp = getRow((int)Shape.RIGHT, 0);
                    rowMoveBack((int)Shape.BACK, (int)Shape.RIGHT, 2, 0);
                    rowMoveBack((int)Shape.LEFT, (int)Shape.BACK, 0, 2);
                    rowMove((int)Shape.FRONT, (int)Shape.LEFT, 0);
                    setRow((int)Shape.FRONT, 0, temp, 0);
                }
                else
                {
                    // F->R->B->L ( 뒤에서 부터 할당 )
                    int[] temp = getRow((int)Shape.LEFT, 0);
                    rowMoveBack((int)Shape.BACK, (int)Shape.LEFT, 2, 0);
                    rowMoveBack((int)Shape.RIGHT, (int)Shape.BACK, 0, 2);
                    rowMove((int)Shape.FRONT, (int)Shape.RIGHT, 0);
                    setRow((int)Shape.FRONT, 0, temp, 0);
                }
            }
            else if (direction == 4)
            {   // down
                if (clockwise)
                {
                    // F->R->B->L ( 뒤에서 부터 할당 )
                    int[] temp = getRow((int)Shape.LEFT, 2);
                    rowMoveBack((int)Shape.BACK, (int)Shape.LEFT, 0, 2);
                    rowMoveBack((int)Shape.RIGHT, (int)Shape.BACK, 2, 0);
                    rowMove((int)Shape.FRONT, (int)Shape.RIGHT, 2);
                    setRow((int)Shape.FRONT, 2, temp, 0);
                }
                else
                {
                    // F->L->B->R ( 뒤에서 부터 할당 )
                    int[] temp = getRow((int)Shape.RIGHT, 2);
                    rowMoveBack((int)Shape.BACK, (int)Shape.RIGHT, 0, 2);
                    rowMoveBack((int)Shape.LEFT, (int)Shape.BACK, 2, 0);
                    rowMove((int)Shape.FRONT, (int)Shape.LEFT, 2);
                    setRow((int)Shape.FRONT, 2, temp,0);
                }
            }
            else if (direction == 1)
            {   // front
                if (clockwise)
                {
                    // U->R->D->L ( 뒤에서 부터 할당 )
                    int[] temp = getCol((int)Shape.LEFT, 2);
                    trans1((int)Shape.DOWN, (int)Shape.LEFT, 0, 2, 0);
                    trans2((int)Shape.RIGHT, (int)Shape.DOWN, 0, 0, 1);
                    trans1((int)Shape.UP, (int)Shape.RIGHT, 2, 0, 0);
                    setRow((int)Shape.UP, 2, temp, 1);
                }
                else
                {
                    // U->L->D->R ( 뒤에서 부터 할당 )
                    int[] temp = getCol((int)Shape.RIGHT, 0);
                    trans1((int)Shape.DOWN, (int)Shape.RIGHT, 0, 0, 1);
                    trans2((int)Shape.LEFT, (int)Shape.DOWN, 2, 0, 0);
                    trans1((int)Shape.UP, (int)Shape.LEFT, 2, 2, 1);
                    setRow((int)Shape.UP, 2, temp, 0);
                }
            }
        }
        private int[] getCol(int shape, int col)
        {
            int[] result = new int[3];
            for (int i = 0; i < 3; i++)
                result[i] = matrix[shape][i][col];
            return result;
        }
        private void setCol(int shape, int col, int[] temp, int direction)
        {
            for (int i = 0; i < 3; i++)
            {
                if (direction == 0)
                    matrix[shape][i][col] = temp[i];
                else
                    matrix[shape][2 - i][col] = temp[i];
            }
        }
        private int[] getRow(int shape, int row)
        {
            int[] result = new int[3];
            for (int i = 0; i < 3; i++)
                result[i] = matrix[shape][row][i];
            return result;
        }
        private void setRow(int shape, int row, int[] temp, int direction)
        {
            for (int i = 0; i < 3; i++)
            {
                if (direction == 0)
                    matrix[shape][row][i] = temp[i];
                else
                    matrix[shape][row][2-i] = temp[i];
            }
        }
        private void rowMove(int fromShae, int toShape, int row)
        {
            // 열의 값을 다른 면으로 이동할때 : Front, Down 회전시
            for(int i=0;i<3;i++)
                matrix[toShape][row][i] = matrix[fromShae][row][i];
        }
        private void rowMoveFront(int fromShae, int toShape, int from_row, int to_row)
        {
            // 열의 값을 다른 면으로 이동할때 : back 면은 좌표계가 달라짐
            for (int i = 0; i < 3; i++)
                matrix[toShape][to_row][i] = matrix[fromShae][from_row][i];
        }
        private void rowMoveBack(int fromShae, int toShape, int from_row, int to_row)
        {
            // 열의 값을 다른 면으로 이동할때 : back 면은 좌표계가 달라짐
            for (int i = 0; i < 3; i++)
                matrix[toShape][to_row][2 - i] = matrix[fromShae][from_row][i];
        }
        private void colMove(int fromShae, int toShape, int col)
        {
            // 행의 값을 다른 면으로 이동할때 : Right, Left 회전시
            for (int i = 0; i < 3; i++)
                matrix[toShape][i][col] = matrix[fromShae][i][col];
        }
        private void trans1(int fromShae, int toShape, int from, int to, int direction)
        {
            // 행이 열로 변경됨
            // direction == 0 이면 값 증가 아니면 감소
            // UP->RIGHT
            // DOWN->LEFT
            for (int i = 0; i < 3; i++)
            {
                if (direction == 0)
                    matrix[toShape][i][to] = matrix[fromShae][from][i];
                else
                    matrix[toShape][2-i][to] = matrix[fromShae][from][i];
            }
        }
        private void trans2(int fromShae, int toShape, int from, int to, int direction)
        {
            // 행이 열로 변경됨
            // direction == 0 이면 값 증가 아니면 감소
            // RIGHT->DOWN
            // LEFT->UP
            for (int i = 0; i < 3; i++)
            {
                if (direction == 0)
                    matrix[toShape][to][i] = matrix[fromShae][i][from];
                else
                    matrix[toShape][to][2-i] = matrix[fromShae][i][from];
            }
        }
        private int[][] getShape(int shape)
        {
            int[][] result = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                result[i] = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    result[i][j] = matrix[shape][i][j];
                }
            }
            return result;
        }
        private void setShape(int shape, int[][] temp, int direction)
        {
            // 순면 전환
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[shape][i][j] = temp[i][j];
                }
            }
        }
        private void transShape(int fromShape, int toShape)
        {
            // 순면 전환
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[toShape][i][j] = matrix[fromShape][i][j];
                }
            }
        }
        private void setShape2(int shape, int[][] temp, int direction)
        {
            // 회전 전환
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[shape][2 - i][2 - j] = temp[i][j];
                }
            }
        }
        private void transShape2(int fromShape, int toShape)
        {
            // 회전 전환
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[toShape][2 - i][2 - j] = matrix[fromShape][i][j];
                }
            }
        }
        #endregion
    }
}
