namespace Ex05
{
    public enum eCoin
    {
        O,
        U,
        X,
        K,
        E
    }

    public class GameBoard
    {
        private readonly int m_BoardSize;
        private readonly eCoin[,] m_GameBoardMatrix;

        public GameBoard(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            m_GameBoardMatrix = new eCoin[i_BoardSize, i_BoardSize];
        }

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }
        }

        public eCoin[,] GameBoardMatrix
        {
            get
            {
                return m_GameBoardMatrix;
            }
        }

        public void InitializeCoinsOnGameBoard()
        {
            for(int i = 0; i < BoardSize; i++)
            {
                for(int j = 0; j < BoardSize; j++)
                {
                    GameBoardMatrix[i, j] = eCoin.E;
                }
            }

            for(int i = 0; i < (BoardSize - 2) / 2; i++)
            {
                for(int j = 0; j < BoardSize; j++)
                {
                    if(i % 2 == 0)
                    {
                        GameBoardMatrix[i, j + 1] = eCoin.O;
                        j += 1;
                    }
                    else
                    {
                        GameBoardMatrix[i, j] = eCoin.O;
                        j += 1;
                    }
                }
            }

            for(int i = BoardSize - 1; i > (((BoardSize - 2) / 2) + 1); i--)
            {
                for(int j = 0; j < BoardSize; j++)
                {
                    if(i % 2 == 0)
                    {
                        GameBoardMatrix[i, j + 1] = eCoin.X;
                        j += 1;
                    }
                    else
                    {
                        GameBoardMatrix[i, j] = eCoin.X;
                        j += 1;
                    }
                }
            }
        }

        private bool IsSquareOutOfBoardBoundaries(Square i_Square)
        {
            bool isSquareOutOfBoardBoundaries = true;

            if((i_Square.Row >= 0 && i_Square.Row < BoardSize) &&
                (i_Square.Column >= 0 && i_Square.Column < BoardSize))
            {
                isSquareOutOfBoardBoundaries = false;
            }

            return isSquareOutOfBoardBoundaries;
        }

        private bool IsSquareEmpty(Square i_Square)
        {
            bool isSquareEmpty = false;

            if(GameBoardMatrix[i_Square.Row, i_Square.Column] == eCoin.E)
            {
                isSquareEmpty = true;
            }

            return isSquareEmpty;
        }

        public bool IsValidOccupiedSquare(Square i_Square)
        {
            bool isValidOccupiedSquare = false;

            if(!IsSquareOutOfBoardBoundaries(i_Square) && !IsSquareEmpty(i_Square))
            {
                isValidOccupiedSquare = true;
            }

            return isValidOccupiedSquare;
        }

        public bool IsValidEmptySquare(Square i_Square)
        {
            bool isValidEmptySquare = false;

            if(!IsSquareOutOfBoardBoundaries(i_Square) && IsSquareEmpty(i_Square))
            {
                isValidEmptySquare = true;
            }

            return isValidEmptySquare;
        }
    }
}
