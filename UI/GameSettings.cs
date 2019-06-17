namespace UI
{
    using System;
    using System.Windows.Forms;

    public partial class GameSettings : Form
    {
        private int m_BoardSize = 6;
        private int m_NumberOfHumanPlayers;
        private GameWindow m_GameWindow;

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }

            set
            {
                m_BoardSize = value;
            }
        }

        public int NumberOfHumanPlayers
        {
            get
            {
                return m_NumberOfHumanPlayers;
            }

            set
            {
                m_NumberOfHumanPlayers = value;
            }
        }

        public GameSettings()
        {
            InitializeComponent();
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            if (BoardSize < 12)
            {
                BoardSize += 2; 
            }
            else
            {
                BoardSize = 6;
            }

            buttonBoardSize.Text = string.Format("Board Size: {0}X{0} (click to increase)", BoardSize);
        }

        private void buttonOnePlayer_Click(object sender, EventArgs e)
        {
            NumberOfHumanPlayers = 1;
            createGameWindow();
        }

        private void buttonTwoPlayers_Click(object sender, EventArgs e)
        {
            NumberOfHumanPlayers = 2;
            createGameWindow();
        }

        private void createGameWindow()
        {
            m_GameWindow = new GameWindow(BoardSize, NumberOfHumanPlayers);
            this.Hide();
            m_GameWindow.ShowDialog();
            this.Close();
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
        }
    }
}
