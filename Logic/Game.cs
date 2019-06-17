namespace Logic
{
    public class Game
    {
        private Board m_Board;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;
        private int m_NumOfMoves;
        private int m_MaxNumOfMoves;

        public Game(int i_SizeOfBoard, int i_NumberOfHumanPlayers)
        {
            string playerOneName = "Black";
            string playerTwoName = "White";
            bool isSecondPlayerHuman = false;
            if (i_NumberOfHumanPlayers == 2)
            {
                isSecondPlayerHuman = true;
            }

            m_Board = new Board(i_SizeOfBoard);
            m_Player1 = new Player(playerOneName, 1, 'x', true);
            m_Player2 = new Player(playerTwoName, 2, 'o', isSecondPlayerHuman);
            m_CurrentPlayer = m_Player1;
            m_NumOfMoves = 0;
            m_MaxNumOfMoves = (Board.Size * Board.Size) - 4;
        }

        public void RestartGame()
        {
            m_CurrentPlayer = m_Player1;
            m_NumOfMoves = 0;
            Board.CleanBoard();
        }

        public Board Board
        {
            get
            {
                return m_Board;
            }
        }

        public Cell[,] GameBoard
        {
            get
            {
                return m_Board.GameBoard;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }

            set
            {
                m_CurrentPlayer = value;
            }
        }

        public Player Player1
        {
            get
            {
                return m_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }
        }

        public bool DoMove(int i_Row, int i_Col)
        {
            bool isMoveDone = false;

            if (CurrentPlayer.IsHuman)
            {
                isMoveDone = playHumanTurn(i_Row, i_Col);
            }

            return isMoveDone;
        }

        private bool playHumanTurn(int i_Row, int i_Col)
        {
            bool isMoveDone = false;

            EvaluateAll();
            if (m_Board.IsValueSettable(i_Row, i_Col) == true)
            {
                Board.EvaluateCell(i_Row, i_Col, CurrentPlayer.Id, true);
                Board.SetValue(i_Row, i_Col, CurrentPlayer.Id);
                SwitchTurn();
                isMoveDone = true;
                m_NumOfMoves++;
            }

            EvaluateAll();
            return isMoveDone;
        }

        private bool isBoardFull()
        {
            return m_NumOfMoves == m_MaxNumOfMoves;
        }

        public void PlayComputerTurn()
        {
            int row, col;

            EvaluateAll();
            if (Board.FindEmptyCell(out row, out col))
            {
                Board.EvaluateCell(row, col, CurrentPlayer.Id, true);
                Board.SetValue(row, col, CurrentPlayer.Id);
                m_NumOfMoves++;
            }

            SwitchTurn();
            EvaluateAll();
        }

        public void SwitchTurn()
        {
            CurrentPlayer = CurrentPlayer == m_Player1 ? m_Player2 : m_Player1;
        }

        public bool IsGameOver()
        {
            bool isGameOver = false;

            if (isBoardFull())
            {
                isGameOver = true;
            }
            else if (Board.IsPlayerStuck(Player1.Id) && Board.IsPlayerStuck(Player2.Id))
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        public bool IsPlayerStuck(string i_Name)
        {
            int playerValue;
            if (i_Name.Equals(Player1.Name))
            {
                playerValue = Player1.Disc;
            }
            else
            {
                playerValue = Player2.Disc;
            }

            return Board.IsPlayerStuck(playerValue);
        }

        public string GetWinnerName()
        {
            string winner = string.Empty;
            int playerOneScore = Board.GetScore(Player1.Id);
            int playerTwoScore = Board.GetScore(Player2.Id);

            if (playerOneScore > playerTwoScore)
            {
                winner = Player1.Name;
            }
            else if (playerOneScore < playerTwoScore)
            {
                winner = Player2.Name;
            }

            return winner;
        }

        public int Player1Score()
        {
            return Board.GetScore(Player1.Id);
        }

        public int Player2Score()
        {
            return Board.GetScore(Player2.Id);
        }

        public void EvaluateAll()
        {
            Board.EvaluateAllCells(CurrentPlayer.Id);
        }
    }
}
