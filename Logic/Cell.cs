namespace Logic
{
        public class Cell
        {
            private readonly int r_Row;
            private readonly int r_Column;
            private int m_Value;
            private bool m_IsSettable;
       
            public Cell(int i_Row, int i_Column, int i_Value, bool i_IsSettable)
            {
                r_Row = i_Row;
                r_Column = i_Column;
                m_Value = i_Value;
                m_IsSettable = i_IsSettable;
            }

            public int Row
            {
                get
                {
                    return r_Row;
                }
            }

            public int Column
            {
                get
                {
                    return r_Column;
                }
            }

            public int Value
            {
                get
                {
                    return m_Value;
                }

                set
                {
                    m_Value = value;
                }
            }

            public bool IsSettable
            {
                get
                {
                    return m_IsSettable;
                }

                set
                {
                    m_IsSettable = value;
                }
            }
        }
}
