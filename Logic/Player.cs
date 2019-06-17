namespace Logic
{
    public class Player
    {
        private readonly string r_PlayerName;
        private readonly int r_Id;
        private readonly char r_Disc;
        private readonly bool r_IsHuman;

        public Player(string i_PlayerName, int i_Id, char i_Disc, bool i_IsHuman)
        {
            r_PlayerName = i_PlayerName;
            r_Id = i_Id;
            r_Disc = i_Disc;
            r_IsHuman = i_IsHuman;
        }

        public char Disc
        {
            get
            {
                return r_Disc;
            }
        }

        public string Name
        {
            get
            {
                return r_PlayerName;
            }
        }

        public int Id
        {
            get
            {
                return r_Id;
            }
        }

        public bool IsHuman
        {
            get
            {
                return r_IsHuman;
            }
        }
    }
}
