using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeSolve
{
    class CubeSolution
    {
        public CubeMatrix c;
        private int solve_state = 0;//현재 풀린상태를 저장한다.
        private List<CubeMatrix> solution=new List<CubeMatrix>();// 푸는 과정을 담아둔다.

        public void setCube(CubeMatrix mat)
        {
            this.c = mat;
        }
        public void Solve()
        {
            int count = 0;
            while (count < 20 && solve_state<7)
            {
                solve_state = SolutionCheck();
                switch (solve_state)
                {
                    case 0:
                        Solve1();
                        break;
                    case 1:
                        Solve2();
                        break;
                    case 2:
                        Solve3();
                        break;
                    case 3:
                        Solve4();
                        break;
                    case 4:
                        Solve5();
                        break;
                    case 5:
                        Solve6();
                        break;
                    case 6:
                        Solve7();
                        break;
                }
            }
        }
        public void Print()
        {
            int count = solution.Count;
            CubeMatrix[] list = solution.ToArray();
            for (int i = 0; i < count; i++)
            {
                list[i].Print();
            }
        }
        public CubeMatrix[] GetList()
        {
            return solution.ToArray();
        }

        private void Solve1()
        {
            //1단계 하얀면맞추기
            //하얀색 중앙이 윗면으로 오도록 이동후
            
            //십자 맞추고 각 모서리 맞춘다.
            //R' D' R D
            
            //완성되면 2단계로 진행
        }
        private void Solve2()
        {
            //2단계 2층면 맞추기
            //하얀색 면이 아래로 향하게 하고 2층단면을 색을 일치시킨다.
            // 맞추는 방법 :
            // 노란색을 제외한 나머지 면을 찾고 
            // case1 위쪽가운데를 오른쪽으로 보내기
            //  U R U' R' U' F' U F
            // case2 위쪽가운데를 왼쪽으로 보내기
            //  U' L' U L U F U 'F'
            //완성되면 3단계로 진행

            // 하얀색 윗면을 아래로 이동
            c.Transform(1); // down
            solution.Add(c);
            c.Transform(1); // down
            solution.Add(c);
            // 2층의 모서리 맞추기
            // 1층중 노란색 제외한 색 찾고 유사면으로 회전하여 이동
            // case1, case2를 적용하여 모서리 맞추기
        }
        private void Solve3()
        {
            //3단계 상단면 노란십자가 만들기
            //2층단면이 맞춰진 화면에서
            //case1 : 가운데 노란색
            //case2 : 왼쪽 니은자모양
            //case3 : 일자모양
            //case4 : 십자모양
            // 맞추는 방법 :
            // F R U R' U' F'
            //완성되면 4단계로 진행
        }
        private void Solve4()
        {
            //4단계 상단 노란면 맞추기
            //2층단면이 맞춰진 화면에서
            //case1 : 십자면 R1, B2, L1
            //case2 : 십자면 R2, L2
            //case3 : 왼쪽탱크면 F1, B1
            //case4 : 앞쪽탱크면 F2
            //case5 : 사각2면 F1, R1
            // 맞추는 방법 :
            // R U R' U R U U R'
            //완성되면 5단계로 진행
        }
        private void Solve5()
        {
            //5단계 상단 노란면 맞추기
            //2층단면이 맞춰진 화면에서 쪽지모양인경우
            //case1 : 왼쪽하단쪽지 F1, R1, B1
            // R U R' U R U U R'
            //case2 : 오른쪽하단쪽지 F1, L1, B1
            // L U' L' U' L' U' U' L
            //완성되면 6단계로 진행
        }
        private void Solve6()
        {
            //6단계 상단노란면이 다 맞춰지고 각 모서리가 맞지 않은 경우
            //대각선 또는 위아래로 맞지않는 경우 오른쪽 하단으로 맞추고 돌린다.
            // R U R' U' R' F R R U' R' U' R U R' F'
            //완성되면 6단계로 진행
        }
        private void Solve7()
        {
            //7단계 각 변면이 맞지 않는 경우
            //case1:모든면이 맞지않음
            //case2:앞면빼고 맞지않음
            //case2상태로 만들고 수행함
            // R R U' R' U' R U R U R U'R
            //완성
        }
        private bool Check1()
        {
            //현재 상태가 Solve1을 푼상태인가?
            int[][][] mat = c.getMatrix();
            int up=(int)Shape.UP;
            int front=(int)Shape.FRONT;
            int left=(int)Shape.LEFT;
            int right=(int)Shape.RIGHT;
            int back=(int)Shape.BACK;

            // 윗면이 하얀색으로 맞고
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (mat[up][i][j] != (int)CubeColor.White)
                        return false;
                }
            }
            // 각면의 0열이 모두 같은색으로 1열 중앙값과 동일
            if (mat[front][1][1] != mat[front][0][0] || 
                mat[front][1][1] != mat[front][0][1] ||
                mat[front][1][1] != mat[front][0][2])
                return false;

            if (mat[left][1][1] != mat[left][0][0] || 
                mat[left][1][1] != mat[left][0][1] ||
                mat[left][1][1] != mat[left][0][2])
                return false;

            if (mat[right][1][1] != mat[right][0][0] || 
                mat[right][1][1] != mat[right][0][1] ||
                mat[right][1][1] != mat[right][0][2])
                return false;

            if (mat[back][1][1] != mat[back][2][0] || 
                mat[back][1][1] != mat[back][2][1] ||
                mat[back][1][1] != mat[back][2][2])
                return false;

            return true;
        }
        private bool Check2()
        {
            //현재 상태가 Solve2을 푼상태인가?
            int[][][] mat = c.getMatrix();
            // Botton이 white로 모두 맞음
            //int up = (int)Shape.UP;
            int front = (int)Shape.FRONT;
            int left = (int)Shape.LEFT;
            int right = (int)Shape.RIGHT;
            int back = (int)Shape.BACK;
            int down = (int)Shape.DOWN;
            // 아랫면이 하얀색으로 맞고
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (mat[down][i][j] != (int)CubeColor.White)
                        return false;
                }
            }
            // Up을 제외한 나머지 4면이 1,2열이 모두 같은색으로 맞음
            if (mat[front][1][1] != mat[front][1][0] || 
                mat[front][1][1] != mat[front][1][2] ||
                mat[front][1][1] != mat[front][2][0] ||
                mat[front][1][1] != mat[front][2][1] ||
                mat[front][1][1] != mat[front][2][2])
                return false;

            if (mat[left][1][1] != mat[left][1][0] ||
                mat[left][1][1] != mat[left][1][2] ||
                mat[left][1][1] != mat[left][2][0] ||
                mat[left][1][1] != mat[left][2][1] ||
                mat[left][1][1] != mat[left][2][2])
                return false;

            if (mat[right][1][1] != mat[right][1][0] ||
                mat[right][1][1] != mat[right][1][2] ||
                mat[right][1][1] != mat[right][2][0] ||
                mat[right][1][1] != mat[right][2][1] ||
                mat[right][1][1] != mat[right][2][2])
                return false;

            if (mat[back][1][1] != mat[back][1][0] ||
                mat[back][1][1] != mat[back][1][2] ||
                mat[back][1][1] != mat[back][0][0] ||
                mat[back][1][1] != mat[back][0][1] ||
                mat[back][1][1] != mat[back][0][2])
                return false;

            return true;
        }
        private bool Check3()
        {
            //현재 상태가 Solve3을 푼상태인가?
            int[][][] mat = c.getMatrix();
            int up = (int)Shape.UP;

            // Botton이 white로 모두 맞음
            // Up을 제외한 나머지 4면이 1,2열이 모두 같은색으로 맞음
            if (!Check2())
                return false;

            // Up면이 십자가로 맞음
            if (mat[up][1][1] != mat[up][0][1] ||
                mat[up][1][1] != mat[up][1][0] ||
                mat[up][1][1] != mat[up][1][2] ||
                mat[up][1][1] != mat[up][2][1])
                return false;

            return true;
        }
        private bool Check4()
        {
            //현재 상태가 Solve4을 푼상태인가?
            int[][][] mat = c.getMatrix();
            int up = (int)Shape.UP;
            int front = (int)Shape.FRONT;
            int left = (int)Shape.LEFT;
            int right = (int)Shape.RIGHT;
            int back = (int)Shape.BACK;
            //int down = (int)Shape.DOWN;
            // Botton이 white로 모두 맞음
            // Up을 제외한 나머지 4면이 1,2열이 모두 같은색으로 맞음
            if (!Check2())
                return false;

            // Up면이 십자가로 맞음
            if (mat[up][1][1] != mat[up][0][1] ||
                mat[up][1][1] != mat[up][1][0] ||
                mat[up][1][1] != mat[up][1][2] ||
                mat[up][1][1] != mat[up][2][1])
                return false;

            // Up면이 5 케이스에 해당한다.
            int yellow=(int)CubeColor.Yellow;
            if ((mat[left][0][2] == yellow && mat[right][0][1] == yellow && mat[back][2][0] == yellow && mat[back][2][2] == yellow) || // case1
                (mat[left][0][0] == yellow && mat[left][0][2] == yellow && mat[right][0][0] == yellow && mat[right][0][2] == yellow) || // case2
                (mat[front][0][0] == yellow && mat[up][0][2] == yellow && mat[up][2][2] == yellow && mat[back][2][0] == yellow) || // case3
                (mat[front][0][0] == yellow && mat[front][0][2] == yellow && mat[up][0][0] == yellow && mat[up][0][2] == yellow) || // case4
                (mat[front][0][0] == yellow && mat[right][0][2] == yellow && mat[up][0][0] == yellow && mat[up][2][2] == yellow)) // case5
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool Check5()
        {
            //현재 상태가 Solve5을 푼상태인가?
            int[][][] mat = c.getMatrix();
            int up = (int)Shape.UP;
            // Botton이 white로 모두 맞음
            // Up을 제외한 나머지 4면이 1,2열이 모두 같은색으로 맞음
            if (!Check2())
                return false;

            // Up면의 노란색으로 맞음
            if (mat[up][1][1] != mat[up][0][0] ||
                mat[up][1][1] != mat[up][0][1] ||
                mat[up][1][1] != mat[up][0][2] ||
                mat[up][1][1] != mat[up][1][0] ||
                mat[up][1][1] != mat[up][1][2] ||
                mat[up][1][1] != mat[up][2][0] ||
                mat[up][1][1] != mat[up][2][1] ||
                mat[up][1][1] != mat[up][2][2])
                return false;

            return true;
        }
        private bool Check6()
        {
            //현재 상태가 Solve6을 푼상태인가?
            int[][][] mat = c.getMatrix();
            int up = (int)Shape.UP;
            int front = (int)Shape.FRONT;
            int left = (int)Shape.LEFT;
            int right = (int)Shape.RIGHT;
            int back = (int)Shape.BACK;
            //int down = (int)Shape.DOWN;
            // Botton이 white로 모두 맞음
            // Up을 제외한 나머지 4면이 1,2열이 모두 같은색으로 맞음
            if (!Check2())
                return false;
            
            // Up 면의 1열의 모서리가 각면의 중앙색과 맞음
            if (mat[front][1][1] != mat[front][0][0] ||
                mat[front][1][1] != mat[front][0][2])
                return false;

            if (mat[left][1][1] != mat[left][0][0] ||
                mat[left][1][1] != mat[left][0][2])
                return false;

            if (mat[right][1][1] != mat[right][0][0] ||
                mat[right][1][1] != mat[right][0][2])
                return false;

            if (mat[back][1][1] != mat[back][2][0] ||
                mat[back][1][1] != mat[back][2][2])
                return false;

            // Up면의 노란색으로 맞음
            if (mat[up][1][1] != mat[up][0][0] ||
                mat[up][1][1] != mat[up][0][1] ||
                mat[up][1][1] != mat[up][0][2] ||
                mat[up][1][1] != mat[up][1][0] ||
                mat[up][1][1] != mat[up][1][2] ||
                mat[up][1][1] != mat[up][2][0] ||
                mat[up][1][1] != mat[up][2][1] ||
                mat[up][1][1] != mat[up][2][2])
                return false;

            return true;
        }
        private bool Check7()
        {
            //현재 상태가 Solve7을 푼상태인가?
            return c.Validation();
        }
        private int SolutionCheck()
        {
            int stat = 0;
            if (Check7())
                stat = 7;
            else if (Check6())
                stat = 6;
            else if (Check5())
                stat = 5;
            else if (Check4())
                stat = 4;
            else if (Check3())
                stat = 3;
            else if (Check2())
                stat = 2;
            else if (Check1())
                stat = 1;
            else
                stat = 0;
            return stat;
        }
    }
}
