using System.Windows.Forms;

namespace UI
{
    public partial class Cell : Button
    {
        private string m_PlayerName = string.Empty;
        private bool m_isFree = true;
        private bool m_isSelectable = false;

        public string PlayerName
        {
            get
            {
                return m_PlayerName;
            }

            set
            {
                m_PlayerName = value;
            }
        }

        public bool IsFree
        {
            get
            {
                return m_isFree;
            }

            set
            {
                m_isFree = value;
            }
        }

        public bool IsSelectable
        {
            get
            {
                return m_isSelectable;
            }

            set
            {
                m_isSelectable = value;
            }
        }

        public Cell(string i_PlayerName, bool i_IsFree, bool i_IsSelectable)
        {
            m_PlayerName = i_PlayerName;
            m_isFree = i_IsFree;
            m_isSelectable = i_IsSelectable;
        }
    }
}
