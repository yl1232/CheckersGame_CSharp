namespace Ex05
{
    public class CheckersGame
    {
        private GameBoard m_GameBoard;
        private bool m_TwoPlayers;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Player m_PlayerTurn;

        public CheckersGame()
        {
            m_GameBoard = null;
            m_TwoPlayers = false;
            m_FirstPlayer = null;
            m_SecondPlayer = null;
            m_PlayerTurn = null;
        }

        public GameBoard GameBoard
        {
            get
            {
                return m_GameBoard;
            }

            set
            {
                m_GameBoard = value;
            }
        }

        public Player FirstPlayer
        {
            get
            {
                return m_FirstPlayer;
            }

            set
            {
                m_FirstPlayer = value;
            }
        }

        public Player SecondPlayer
        {
            get
            {
                return m_SecondPlayer;
            }

            set
            {
                m_SecondPlayer = value;
            }
        }

        public bool TwoPlayers
        {
            get
            {
                return m_TwoPlayers;
            }

            set
            {
                m_TwoPlayers = value;
            }
        }

        public Player PlayerTurn
        {
            get
            {
                return m_PlayerTurn;
            }

            set
            {
                m_PlayerTurn = value;
            }
        }

        public void ChangePlayerTurn()
        {
            if(PlayerTurn == FirstPlayer)
            {
                PlayerTurn = SecondPlayer;
            }
            else
            {
                PlayerTurn = FirstPlayer;
            }
        }
    }
}
