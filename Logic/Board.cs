using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Board
    {
        private readonly int r_Empty = 0;
        private readonly int r_FirstPlayer = 1;
        private readonly int r_SecondPlayer = 2;
        private readonly int r_Size;
        private Cell[,] m_Board;

        public Board(int i_Size)
        {
            r_Size = i_Size;
            m_Board = new Cell[r_Size, r_Size];
            initBoard();
        }

        public Cell[,] GameBoard
        {
            get
            {
                return m_Board;
            }
        }

        public int Size
        {
            get
            {
                return r_Size;
            }
        }

        private void initBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    m_Board[i, j] = new Cell(i, j, r_Empty, false);

                    if (((i == ((Size / 2) - 1)) && (j == ((Size / 2) - 1))) || ((i == (Size / 2)) && (j == (Size / 2))))
                    {
                        m_Board[i, j].Value = r_FirstPlayer;
                    }
                    else if (((i == ((Size / 2) - 1)) && (j == (Size / 2))) || ((i == (Size / 2)) && (j == ((Size / 2) - 1))))
                    {
                        m_Board[i, j].Value = r_SecondPlayer;
                    }
                }
            }

            EvaluateAllCells(r_FirstPlayer);
        }

        public char GetValue(int i_Row, int i_Col)
        {
            char value = ' ';

            if (m_Board[i_Row, i_Col].Value == 1)
            {
                value = 'o';
            }
            else if (m_Board[i_Row, i_Col].Value == 2)
            {
                value = 'x';
            }

            return value;
        }

        public void SetValue(int i_Row, int i_Col, int i_Value)
        {
            m_Board[i_Row, i_Col].Value = i_Value;
        }

        public bool IsValueSettable(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col].IsSettable;
        }

        private void checkAndSetValue(int i_Row, int i_Col, int i_Value, ref CellResult o_Result, bool i_IsFlipCoins)
        {
            if (o_Result.IsFlipped == true)
            {
                o_Result.NumOfFlippedCoins++;
                if (i_IsFlipCoins)
                {
                    SetValue(i_Row, i_Col, i_Value);
                }
            }
        }

        private void setResultFalse(ref CellResult o_Result)
        {
            o_Result.IsFlipped = false;
            o_Result.NumOfFlippedCoins = 0;
        }

        private void setResultTrue(ref CellResult o_Result)
        {
            o_Result.IsFlipped = true;
            o_Result.NumOfFlippedCoins = 0;
        }

        public void EvaluateAllCells(int i_Value)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (EvaluateCell(i, j, i_Value, false) > 0)
                    {
                        m_Board[i, j].IsSettable = true;
                    }
                    else
                    {
                        m_Board[i, j].IsSettable = false;
                    }
                }
            }
        }

        public int EvaluateCell(int i_Row, int i_Col, int i_Value, bool i_IsFlipCoins)
        {
            int flippedCoins = 0;

            if (m_Board[i_Row, i_Col].Value == r_Empty)
            {
                flippedCoins += evalUp(i_Row - 1, i_Col, i_Value, i_IsFlipCoins).NumOfFlippedCoins;
                flippedCoins += evalDown(i_Row + 1, i_Col, i_Value, i_IsFlipCoins).NumOfFlippedCoins;
                flippedCoins += evalLeft(i_Row, i_Col - 1, i_Value, i_IsFlipCoins).NumOfFlippedCoins;
                flippedCoins += evalRight(i_Row, i_Col + 1, i_Value, i_IsFlipCoins).NumOfFlippedCoins;
                flippedCoins += evalUpLeft(i_Row - 1, i_Col - 1, i_Value, i_IsFlipCoins).NumOfFlippedCoins;
                flippedCoins += evalUpRight(i_Row - 1, i_Col + 1, i_Value, i_IsFlipCoins).NumOfFlippedCoins;
                flippedCoins += evalDownLeft(i_Row + 1, i_Col - 1, i_Value, i_IsFlipCoins).NumOfFlippedCoins;
                flippedCoins += evalDownRight(i_Row + 1, i_Col + 1, i_Value, i_IsFlipCoins).NumOfFlippedCoins;
            }

            return flippedCoins;
        }

        private CellResult evalUp(int i_Row, int i_Col, int i_Value, bool i_IsFlipCoins)
        {
            CellResult result = new CellResult();

            if (isOutOfBounds(i_Row, i_Col) || m_Board[i_Row, i_Col].Value == r_Empty)
            {
                setResultFalse(ref result);
            }
            else if (m_Board[i_Row, i_Col].Value == i_Value)
            {
                setResultTrue(ref result);
            }
            else
            {
                result = evalUp(i_Row - 1, i_Col, i_Value, i_IsFlipCoins);
                checkAndSetValue(i_Row, i_Col, i_Value, ref result, i_IsFlipCoins);
            }

            return result;
        }

        private CellResult evalDown(int i_Row, int i_Col, int i_Value, bool i_IsFlipCoins)
        {
            CellResult result = new CellResult();

            if (isOutOfBounds(i_Row, i_Col) || m_Board[i_Row, i_Col].Value == r_Empty)
            {
                setResultFalse(ref result);
            }
            else if (m_Board[i_Row, i_Col].Value == i_Value)
            {
                setResultTrue(ref result);
            }
            else
            {
                result = evalDown(i_Row + 1, i_Col, i_Value, i_IsFlipCoins);
                checkAndSetValue(i_Row, i_Col, i_Value, ref result, i_IsFlipCoins);
            }

            return result;
        }

        private CellResult evalRight(int i_Row, int i_Col, int i_Value, bool i_IsFlipCoins)
        {
            CellResult result = new CellResult();

            if (isOutOfBounds(i_Row, i_Col) || m_Board[i_Row, i_Col].Value == r_Empty)
            {
                setResultFalse(ref result);
            }
            else if (m_Board[i_Row, i_Col].Value == i_Value)
            {
                setResultTrue(ref result);
            }
            else
            {
                result = evalRight(i_Row, i_Col + 1, i_Value, i_IsFlipCoins);
                checkAndSetValue(i_Row, i_Col, i_Value, ref result, i_IsFlipCoins);
            }

            return result;
        }

        private CellResult evalLeft(int i_Row, int i_Col, int i_Value, bool i_IsFlipCoins)
        {
            CellResult result = new CellResult();

            if (isOutOfBounds(i_Row, i_Col) || m_Board[i_Row, i_Col].Value == r_Empty)
            {
                setResultFalse(ref result);
            }
            else if (m_Board[i_Row, i_Col].Value == i_Value)
            {
                setResultTrue(ref result);
            }
            else
            {
                result = evalLeft(i_Row, i_Col - 1, i_Value, i_IsFlipCoins);
                checkAndSetValue(i_Row, i_Col, i_Value, ref result, i_IsFlipCoins);
            }

            return result;
        }

        private CellResult evalUpLeft(int i_Row, int i_Col, int i_Value, bool i_IsFlipCoins)
        {
            CellResult result = new CellResult();

            if (isOutOfBounds(i_Row, i_Col) || m_Board[i_Row, i_Col].Value == r_Empty)
            {
                setResultFalse(ref result);
            }
            else if (m_Board[i_Row, i_Col].Value == i_Value)
            {
                setResultTrue(ref result);
            }
            else
            {
                result = evalUpLeft(i_Row - 1, i_Col - 1, i_Value, i_IsFlipCoins);
                checkAndSetValue(i_Row, i_Col, i_Value, ref result, i_IsFlipCoins);
            }

            return result;
        }

        private CellResult evalUpRight(int i_Row, int i_Col, int i_Value, bool i_IsFlipCoins)
        {
            CellResult result = new CellResult();

            if (isOutOfBounds(i_Row, i_Col) || m_Board[i_Row, i_Col].Value == r_Empty)
            {
                setResultFalse(ref result);
            }
            else if (m_Board[i_Row, i_Col].Value == i_Value)
            {
                setResultTrue(ref result);
            }
            else
            {
                result = evalUpRight(i_Row - 1, i_Col + 1, i_Value, i_IsFlipCoins);
                checkAndSetValue(i_Row, i_Col, i_Value, ref result, i_IsFlipCoins);
            }

            return result;
        }

        private CellResult evalDownRight(int i_Row, int i_Col, int i_Value, bool i_IsFlipCoins)
        {
            CellResult result = new CellResult();

            if (isOutOfBounds(i_Row, i_Col) || m_Board[i_Row, i_Col].Value == r_Empty)
            {
                setResultFalse(ref result);
            }
            else if (m_Board[i_Row, i_Col].Value == i_Value)
            {
                setResultTrue(ref result);
            }
            else
            {
                result = evalUpRight(i_Row + 1, i_Col + 1, i_Value, i_IsFlipCoins);
                checkAndSetValue(i_Row, i_Col, i_Value, ref result, i_IsFlipCoins);
            }

            return result;
        }

        private CellResult evalDownLeft(int i_Row, int i_Col, int i_Value, bool i_IsFlipCoins)
        {
            CellResult result = new CellResult();

            if (isOutOfBounds(i_Row, i_Col) || m_Board[i_Row, i_Col].Value == r_Empty)
            {
                setResultFalse(ref result);
            }
            else if (m_Board[i_Row, i_Col].Value == i_Value)
            {
                setResultTrue(ref result);
            }
            else
            {
                result = evalUpRight(i_Row + 1, i_Col - 1, i_Value, i_IsFlipCoins);
                checkAndSetValue(i_Row, i_Col, i_Value, ref result, i_IsFlipCoins);
            }

            return result;
        }

        public bool IsPlayerStuck(int i_Value)
        {
            bool result = true;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (EvaluateCell(i, j, i_Value, false) > 0)
                    {
                        result = false;
                        break;
                    }
                }

                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        public int GetScore(int i_Value)
        {
            int score = 0;

            foreach (Cell cell in m_Board)
            {
                if (cell.Value == i_Value)
                {
                    score++;
                }
            }

            return score;
        }

        private bool isOutOfBounds(int i_Row, int i_Col)
        {
            bool result = false;

            if (i_Row < 0 || i_Col < 0 || i_Row >= Size || i_Col >= Size)
            {
                result = true;
            }

            return result;
        }

        public bool FindEmptyCell(out int o_Row, out int o_Col)
        {
            bool isFound = false;

            o_Row = -1;
            o_Col = -1;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (m_Board[i, j].IsSettable == true)
                    {
                        o_Row = i;
                        o_Col = j;
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            return isFound;
        }

        internal void CleanBoard()
        {
            initBoard();
        }
    }
}
