namespace UI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Logic;

    public partial class GameWindow : Form
    {
        private const int k_Gap = 3;
        private const int k_CellSize = 50;
        private const int k_Empty = 0;
        private const int k_BlackPlayer = 1;
        private const int k_WhitePlayer = 2;
        private const string k_Disk = "o";
        private const string k_BlackName = "Black";
        private const string k_WhiteName = "White";
        private readonly Color r_BlackBackColor = Color.Black;
        private readonly Color r_BlackForeColor = Color.White;
        private readonly Color r_WhiteBackColor = Color.White;
        private readonly Color r_WhiteForeColor = Color.Black;
        private readonly Color r_SetableColor = Color.Green;
        private readonly Color r_EmptyCellColor = Color.Gray;
        private int m_BoardSize;
        private string m_CurrentPlayerName = k_WhiteName;
        private int m_NumberOfHumanPlayers;
        private int m_DistanceBetweenButtons = k_CellSize + 1;
        private Cell[,] m_AllCells;
        private Game game;
        private int m_BlackScore = 0;
        private int m_WhiteScore = 0;
        private int m_NumOfBlackWins = 0;
        private int m_NumOfWhiteWins = 0;
        private int m_NumberOfGames = 0;

        public GameWindow(int i_BoardSize, int i_NumberOfHumanPlayers)
        {
            InitializeComponent();
            m_BoardSize = i_BoardSize;
            m_NumberOfHumanPlayers = i_NumberOfHumanPlayers;
            game = new Game(i_BoardSize, i_NumberOfHumanPlayers);
        }

        internal void GameWindow_Load(object sender, EventArgs e)
        {
            m_AllCells = new Cell[m_BoardSize, m_BoardSize];
            int x, y, i, j;
            for (y = k_Gap + ((m_BoardSize - 1) * m_DistanceBetweenButtons), i = 0; i < m_BoardSize; y -= m_DistanceBetweenButtons, i++)
            {
                for (x = k_Gap, j = 0; j < m_BoardSize; x += m_DistanceBetweenButtons, j++)
                {
                    Cell cell = new Cell(string.Empty, true, false);
                    cell.Location = new Point(x, y);
                    cell.Size = new Size(k_CellSize, k_CellSize);
                    cell.Click += Cell_Click;
                    m_AllCells[i, j] = cell;
                    Controls.Add(cell);
                }
            }

            setWindowSize();
            updateBoard();
        }

        internal void Cell_Click(object sender, EventArgs e)
        {
            Cell clickedCell = sender as Cell;
            if (clickedCell.Name.Equals(string.Empty))
            {
                bool isMoveDone = false;
                for (int i = 0; i < m_BoardSize; i++)
                {
                    for (int j = 0; j < m_BoardSize; j++)
                    {
                        if (m_AllCells[i, j].Location == clickedCell.Location)
                        {
                            isMoveDone = game.DoMove(i, j);
                            break;
                        }
                    }

                    if (isMoveDone)
                    {
                        break;
                    }
                }

                updateBoard();

                if (m_NumberOfHumanPlayers == 1)
                {
                    doComputerMover();
                }

                if (isGameOver())
                {
                    doWhenGameOver();
                }
                else if (isPlayerStuck())
                {
                    doWhenPlayerStuck();
                }
            }
        }

        private void updateBoard()
        {
            Logic.Cell[,] cells = game.GameBoard;
            int cellValue = 0;
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_AllCells[i, j].Enabled = false;
                    m_AllCells[i, j].BackColor = r_EmptyCellColor;
                    m_AllCells[i, j].Text = string.Empty;
                    cellValue = cells[i, j].Value;
                    m_AllCells[i, j].IsSelectable = cells[i, j].IsSettable;
                    if (cellValue != k_Empty)
                    {
                        if (cellValue == k_BlackPlayer)
                        {
                            updateCell(k_BlackName, r_BlackBackColor, r_BlackForeColor, m_AllCells[i, j]);
                        }
                        else if (cellValue == k_WhitePlayer)
                        {
                            updateCell(k_WhiteName, r_WhiteBackColor, r_WhiteForeColor, m_AllCells[i, j]);
                        }
                    }
                    else
                    {
                        if (cells[i, j].IsSettable)
                        {
                            m_AllCells[i, j].BackColor = r_SetableColor;
                            m_AllCells[i, j].Enabled = true;
                        }
                    }
                }  
            }

            setTitle();
        }

        private void setTitle()
        {
            m_CurrentPlayerName = game.CurrentPlayer.Name;
            this.Text = string.Format("Othello - {0}'s Turn", m_CurrentPlayerName);
        }

        private void updateCell(string i_Name, Color i_BackColor, Color i_ForeColor, Cell cell)
        {
            cell.Enabled = true;
            cell.PlayerName = i_Name;
            cell.BackColor = i_BackColor;
            cell.ForeColor = i_ForeColor;
            cell.IsFree = false;
            cell.Text = k_Disk;
            cell.Refresh();
        }

        private void setWindowSize()
        {
            int size = (2 * k_Gap) + (m_DistanceBetweenButtons * m_BoardSize); 
            this.ClientSize = new Size(size, size);
        }

        private bool isPlayerStuck()
        {
            bool isStuck = true;
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (m_AllCells[i, j].IsSelectable)
                    {
                        isStuck = false;
                        break;
                    }
                }

                if (!isStuck)
                {
                    break;
                }
            }

            return isStuck;
        }

        private bool isGameOver()
        {
            return game.IsGameOver();
        }

        private void doWhenGameOver()
        {
            m_BlackScore = game.Player1Score();
            m_WhiteScore = game.Player2Score();
            string winnerName = game.GetWinnerName();
            string message = string.Empty;
            string question = "Would you like another round?";
            int winnerScore = 0;
            int winnerTotalWins = 0;
            int looserScore = 0;
            m_NumberOfGames++;
            if (m_BlackScore > m_WhiteScore)
            {
                m_NumOfBlackWins++;
                winnerScore = m_BlackScore;
                looserScore = m_WhiteScore;
                winnerTotalWins = m_NumOfBlackWins;
            }
            else if (m_WhiteScore > m_BlackScore)
            {
                m_NumOfWhiteWins += 1;
                winnerScore = m_WhiteScore;
                looserScore = m_BlackScore;
                winnerTotalWins = m_NumOfWhiteWins;
            }

            message = string.Format(
                "{0} Won!! ({1}/{2}) ({3}/{4}){5}",
                winnerName,
                winnerScore,
                looserScore,
                winnerTotalWins,
                m_NumberOfGames,
                Environment.NewLine);
            if(m_WhiteScore == m_BlackScore)
            {       
                message = "It's draw!";
            }

            message += question;

            DialogResult dialogResult = MessageBox.Show(message, "Othello", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                game.RestartGame();
                updateBoard();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }

        private void doComputerMover()
        {
            game.PlayComputerTurn();
            updateBoard();
        }

        private void doWhenPlayerStuck()
        {
            MessageBox.Show("You have no legal moves. Turn over to the next player");
            game.SwitchTurn();
            updateBoard();
            if (m_NumberOfHumanPlayers == 1 && m_CurrentPlayerName.Equals(k_WhiteName))
            {
                doComputerMover();
            }
            else
            {
                game.EvaluateAll();
            }

            updateBoard();
        }
    }
}
