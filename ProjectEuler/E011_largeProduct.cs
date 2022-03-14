using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HackRank
{
    public class GridPoint
    {
        public GridPoint() { }
        public GridPoint (int row, int col) { this.row = row; this.col = col; }
        //public void set  (int row, int col) { this.row = row; this.col = col; }
        public int row { get; set; }
        public int col { get; set; }
        public int val { get; set; }
    }

    public class E011_largeProduct
    {
        static int[,] grid = GetGrid();
        enum direction { side, down, diagRight, diagLeft }

        public static void runProc()
        {
            Console.WriteLine("Problem011 Started");
            long maxProduct = 0;

            //scan each point for 4 directions, horz, vert, diag to right, diag to left
            for (int row = 0; row < grid.GetLength(1); row++)
            {
                Console.WriteLine("row: {0}", row);
                for (int col = 0; col < grid.GetLength(0); col++)
                {
                    Console.WriteLine("row:col {0}:{1} ", row.ToString("D2"), col.ToString("D2"));
                    List<GridPoint[]> pointValues = GetAllSums(row, col);
                    long tmpMax = GetMaxProduct(pointValues);
                    if (tmpMax > maxProduct) {
                        maxProduct = tmpMax;
                    }
                    Console.WriteLine("tmpMax: {0}", tmpMax);
                }
            }

            Console.WriteLine("Problem011 Finished: {0}", maxProduct);
        }

        // ----------------------------------------------------------------------------------------------------------
        private static List<GridPoint[]> GetAllSums(int row, int col)
        {
            List<GridPoint[]> gridPoints = new List<GridPoint[]>();

            GridPoint[] sidePoints = GetPointsArray(new GridPoint(row, col), direction.side);
            GetValues(sidePoints);
            gridPoints.Add(sidePoints);
            DispSet(direction.side, sidePoints);

            GridPoint[] downPoints = GetPointsArray(new GridPoint(row, col), direction.down);
            GetValues(downPoints);
            gridPoints.Add(downPoints);
            DispSet(direction.down, downPoints);

            GridPoint[] diagRightPoints = GetPointsArray(new GridPoint(row, col), direction.diagRight);
            GetValues(diagRightPoints);
            gridPoints.Add(diagRightPoints);
            DispSet(direction.diagRight, diagRightPoints);

            GridPoint[] diagLeftPoints = GetPointsArray(new GridPoint(row, col), direction.diagLeft);
            GetValues(diagLeftPoints);
            gridPoints.Add(diagLeftPoints);
            DispSet(direction.diagLeft, diagLeftPoints);

            return gridPoints;

        }

        // ----------------------------------------------------------------------------------------------------------
        private static long GetMaxProduct(List<GridPoint[]> iArr)
        {
            long tmp0 = GetProduct(iArr[0]);
            long tmp1 = GetProduct(iArr[1]);
            long tmp2 = GetProduct(iArr[2]);
            long tmp3 = GetProduct(iArr[3]);
            return Math.Max(tmp0, Math.Max(tmp1, Math.Max(tmp2, tmp3)));
        }

        // ----------------------------------------------------------------------------------------------------------
        private static long GetProduct(GridPoint[] iArr) {
            return iArr[0].val * iArr[1].val * iArr[2].val * iArr[3].val;
        }

        // ----------------------------------------------------------------------------------------------------------
        private static void DispSet(direction direct, GridPoint[] iArr)
        {
            string dispTmp = direct.ToString().PadLeft(10, ' ');
            Console.WriteLine(dispTmp + ": {{ {0}:{1} }} {{ {2}:{3} }} {{ {4}:{5} }} {{ {6}:{7} }}  {{ {8} {9} {10} {11}}}",
                ValidateCoordinate(iArr[0].row), ValidateCoordinate(iArr[0].col),
                ValidateCoordinate(iArr[1].row), ValidateCoordinate(iArr[1].col),
                ValidateCoordinate(iArr[2].row), ValidateCoordinate(iArr[2].col),
                ValidateCoordinate(iArr[3].row), ValidateCoordinate(iArr[3].col),
                iArr[0].val.ToString("D2"),
                iArr[1].val.ToString("D2"),
                iArr[2].val.ToString("D2"),
                iArr[3].val.ToString("D2")
                );
        }

        // ----------------------------------------------------------------------------------------------------------
        private static string ValidateCoordinate(int coord) {
            if (coord <= grid.GetLength(1)-1 && coord >= 0)
            {
                return coord.ToString("D2");
            }
            else {
                return "xx";
            }
        }

        // ----------------------------------------------------------------------------------------------------------
        private static GridPoint[] GetPointsArray(GridPoint p, direction direct)
        {
            GridPoint[] pArr = new GridPoint[4];
            switch (direct)
            {
                case direction.side:
                    pArr[0] = new GridPoint(p.row, p.col);
                    pArr[1] = new GridPoint(p.row, p.col + 1);
                    pArr[2] = new GridPoint(p.row, p.col + 2);
                    pArr[3] = new GridPoint(p.row, p.col + 3);
                    break;
                case direction.down:
                    pArr[0] = new GridPoint(p.row, p.col);
                    pArr[1] = new GridPoint(p.row + 1, p.col);
                    pArr[2] = new GridPoint(p.row + 2, p.col);
                    pArr[3] = new GridPoint(p.row + 3, p.col);
                    break;
                case direction.diagRight:
                    pArr[0] = new GridPoint(p.row, p.col);
                    pArr[1] = new GridPoint(p.row + 1, p.col + 1);
                    pArr[2] = new GridPoint(p.row + 2, p.col + 2);
                    pArr[3] = new GridPoint(p.row + 3, p.col + 3);
                    break;
                case direction.diagLeft:
                    pArr[0] = new GridPoint(p.row, p.col);
                    pArr[1] = new GridPoint(p.row + 1, p.col - 1);
                    pArr[2] = new GridPoint(p.row + 2, p.col - 2);
                    pArr[3] = new GridPoint(p.row + 3, p.col - 3);
                    break;
                default:
                    break;
            }
            return pArr;
        }

        // ----------------------------------------------------------------------------------------------------------
        private static void GetValues(GridPoint[] gridPoints)
        {
            foreach (GridPoint gridPoint in gridPoints) {
                try
                {
                    if ((gridPoint.row <= grid.GetLength(0) - 1 && gridPoint.col >= 0) &&
                        (gridPoint.col <= grid.GetLength(1) - 1 && gridPoint.col >= 0))
                    {
                        gridPoint.val = grid[gridPoint.row, gridPoint.col];
                    }
                    else
                    {
                        gridPoint.val = -1;
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // ----------------------------------------------------------------------------------------------------------
        private static int[,] GetGrid()
        {
            int[,] a = new int[20, 20] {
                {08,02,22,97,38,15,00,40,00,75,04,05,07,78,52,12,50,77,91,08},
                {49,49,99,40,17,81,18,57,60,87,17,40,98,43,69,48,04,56,62,00},
                {81,49,31,73,55,79,14,29,93,71,40,67,53,88,30,03,49,13,36,65},
                {52,70,95,23,04,60,11,42,69,24,68,56,01,32,56,71,37,02,36,91},
                {22,31,16,71,51,67,63,89,41,92,36,54,22,40,40,28,66,33,13,80},
                {24,47,32,60,99,03,45,02,44,75,33,53,78,36,84,20,35,17,12,50},
                {32,98,81,28,64,23,67,10,26,38,40,67,59,54,70,66,18,38,64,70},
                {67,26,20,68,02,62,12,20,95,63,94,39,63,08,40,91,66,49,94,21},
                {24,55,58,05,66,73,99,26,97,17,78,78,96,83,14,88,34,89,63,72},
                {21,36,23,09,75,00,76,44,20,45,35,14,00,61,33,97,34,31,33,95},
                {78,17,53,28,22,75,31,67,15,94,03,80,04,62,16,14,09,53,56,92},
                {16,39,05,42,96,35,31,47,55,58,88,24,00,17,54,24,36,29,85,57},
                {86,56,00,48,35,71,89,07,05,44,44,37,44,60,21,58,51,54,17,58},
                {19,80,81,68,05,94,47,69,28,73,92,13,86,52,17,77,04,89,55,40},
                {04,52,08,83,97,35,99,16,07,97,57,32,16,26,26,79,33,27,98,66},
                {88,36,68,87,57,62,20,72,03,46,33,67,46,55,12,32,63,93,53,69},
                {04,42,16,73,38,25,39,11,24,94,72,18,08,46,29,32,40,62,76,36},
                {20,69,36,41,72,30,23,88,34,62,99,69,82,67,59,85,74,04,36,16},
                {20,73,35,29,78,31,90,01,74,31,49,71,48,86,81,16,23,57,05,54},
                {01,70,54,71,83,51,54,69,16,92,33,48,61,43,52,01,89,19,67,48}
                };
            return a;

        }


        //private static int GetValue(int x, int y)
        //{
        //    return grid[x, y];
        //}


    }
}
