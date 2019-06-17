namespace Logic
{
    internal class CellResult
    {
        private bool m_IsFlipped;
        private int m_NumOfFlippedCoins;

        public bool IsFlipped
        {
            get
            {
                return m_IsFlipped;
            }

            set
            {
                m_IsFlipped = value;
            }
        }

        public int NumOfFlippedCoins
        {
            get
            {
                return m_NumOfFlippedCoins;
            }

            set
            {
                m_NumOfFlippedCoins = value;
            }
        }
    }
}
