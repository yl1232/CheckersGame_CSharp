using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex05
{
    public enum eDirection
    {
        Up = 1,
        Down = -1,
        Right = 1,
        Left = -1
    }

    public class Player
    {
        private readonly string m_Name;
        private readonly eCoin m_RegularCoin;
        private readonly eCoin m_KingCoin;
        private readonly eDirection m_DirectionOfPlay;
        private Move m_NextMove;
        private int m_Points;

        public Player(string i_PlayerName, eCoin i_RegularCoin, eCoin i_KingCoin, eDirection i_DirectionOfPlay)
        {
            m_Name = i_PlayerName;
            m_RegularCoin = i_RegularCoin;
            m_KingCoin = i_KingCoin;
            m_DirectionOfPlay = i_DirectionOfPlay;
            m_NextMove = null;
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        public int Points
        {
            get
            {
                return m_Points;
            }

            set
            {
                m_Points = value;
            }
        }

        public eCoin RegularCoin
        {
            get
            {
                return m_RegularCoin;
            }
        }

        public eCoin KingCoin
        {
            get
            {
                return m_KingCoin;
            }
        }

        public eDirection DirectionOfPlay
        {
            get
            {
                return m_DirectionOfPlay;
            }
        }

        public Move NextMove
        {
            get
            {
                return m_NextMove;
            }

            set
            {
                m_NextMove = value;
            }
        }

        public void PlayComputerMove(GameBoard i_GameBoard)
        {
            List<Move> playerLegalCaptureMoves = GetPlayerLegalCaptureMoves(i_GameBoard);
            List<Move> playerLegalMovesWithoutCapture = GetPlayerLegalMovesWithoutCapture(i_GameBoard);
            Random randomMove = new Random();

            if(!IsListEmpty<Move>(playerLegalCaptureMoves))
            {
                int randomMoveIndex = randomMove.Next(0, playerLegalCaptureMoves.Count - 1);
                MakeMove(i_GameBoard, playerLegalCaptureMoves[randomMoveIndex]);
            }
            else
            {
                int randomMoveIndex = randomMove.Next(0, playerLegalMovesWithoutCapture.Count - 1);
                MakeMove(i_GameBoard, playerLegalMovesWithoutCapture[randomMoveIndex]);
            }
        }

        public void PlayRegularPlayerMove(GameBoard i_GameBoard, Move i_PlayerMove)
        {
            MakeMove(i_GameBoard, i_PlayerMove);
        }

        public bool MoveInputPossible(GameBoard i_GameBoard, ref Move io_Move)
        {
            bool isMoveLegal = false;
            List<Move> playerCaptureMoves = GetPlayerLegalCaptureMoves(i_GameBoard);
            List<Move> playerMovesWithoutCapture = GetPlayerLegalMovesWithoutCapture(i_GameBoard);

            foreach(Move move in playerCaptureMoves)
            {
                if(io_Move.From.Equals(move.From) && io_Move.To.Equals(move.To))
                {
                    isMoveLegal = true;
                    io_Move = move;
                    break;
                }
            }

            if(!isMoveLegal)
            {
                if(IsListEmpty<Move>(playerCaptureMoves))
                {
                    foreach(Move move in playerMovesWithoutCapture)
                    {
                        if(io_Move.From.Equals(move.From) && io_Move.To.Equals(move.To))
                        {
                            isMoveLegal = true;
                            break;
                        }
                    }
                }
            }

            return isMoveLegal;
        }

        private List<Move> GetPlayerLegalMoves(GameBoard i_GameBoard)
        {
            List<Move> playerLegalMoves = new List<Move>();
            List<Move> currentSquareLegalCaptureMoves;
            List<Move> currentSquareLegalMovesWithoutCapture;
            Square currentSquare;

            for(int i = 0; i < i_GameBoard.BoardSize; i++)
            {
                for(int j = 0; j < i_GameBoard.BoardSize; j++)
                {
                    if(i_GameBoard.GameBoardMatrix[i, j] == this.RegularCoin ||
                       i_GameBoard.GameBoardMatrix[i, j] == this.KingCoin)
                    {
                        currentSquare = new Square(i, j);
                        currentSquareLegalCaptureMoves = GetAllCaptureMovesPerSquare(i_GameBoard, currentSquare);
                        if(!IsListEmpty<Move>(currentSquareLegalCaptureMoves))
                        {
                            playerLegalMoves.AddRange(currentSquareLegalCaptureMoves);
                        }

                        currentSquareLegalMovesWithoutCapture = GetMovesWithoutCapturePerSquare(i_GameBoard, 
                                                                        currentSquare);
                        if(!IsListEmpty<Move>(currentSquareLegalMovesWithoutCapture))
                        {
                            playerLegalMoves.AddRange(currentSquareLegalMovesWithoutCapture);
                        }
                    }
                }
            }

            return playerLegalMoves;
        }

        private List<Move> GetPlayerLegalCaptureMoves(GameBoard i_GameBoard)
        {
            List<Move> playerLegalCaptureMoves = new List<Move>();
            List<Move> currentSquareLegalCaptureMoves;
            Square currentSquare;

            for(int i = 0; i < i_GameBoard.BoardSize; i++)
            {
                for(int j = 0; j < i_GameBoard.BoardSize; j++)
                {
                    if(i_GameBoard.GameBoardMatrix[i, j] == this.RegularCoin ||
                       i_GameBoard.GameBoardMatrix[i, j] == this.KingCoin)
                    {
                        currentSquare = new Square(i, j);
                        currentSquareLegalCaptureMoves = GetAllCaptureMovesPerSquare(i_GameBoard, currentSquare);
                        if(!IsListEmpty<Move>(currentSquareLegalCaptureMoves))
                        {
                            playerLegalCaptureMoves.AddRange(currentSquareLegalCaptureMoves);
                        }
                    }
                }
            }

            return playerLegalCaptureMoves;
        }

        private List<Move> GetPlayerLegalMovesWithoutCapture(GameBoard i_GameBoard)
        {
            List<Move> playerLegalMovesWithoutCapture = new List<Move>();
            List<Move> currentSquareLegalMovesWithoutCapture;
            Square currentSquare; 

            for(int i = 0; i < i_GameBoard.BoardSize; i++)
            {
                for(int j = 0; j < i_GameBoard.BoardSize; j++)
                {
                    if(i_GameBoard.GameBoardMatrix[i, j] == this.RegularCoin ||
                       i_GameBoard.GameBoardMatrix[i, j] == this.KingCoin)
                    {
                        currentSquare = new Square(i, j);
                        currentSquareLegalMovesWithoutCapture = GetMovesWithoutCapturePerSquare(i_GameBoard, currentSquare);
                        if(!IsListEmpty<Move>(currentSquareLegalMovesWithoutCapture))
                        {
                            playerLegalMovesWithoutCapture.AddRange(currentSquareLegalMovesWithoutCapture);
                        }
                    }
                }
            }

            return playerLegalMovesWithoutCapture;
        }

        public bool PlayerHasLegalMoves(GameBoard i_GameBoard)
        {
            bool playerHasLegalMoves = false;

            if(!IsListEmpty<Move>(GetPlayerLegalMoves(i_GameBoard)))
            {
                playerHasLegalMoves = true;
            }

            return playerHasLegalMoves;
        }

        private bool IsLegalSingleCaptureMove(GameBoard i_GameBoard, Square i_CapturedSquare,
                            Square i_DestinationSquare)
        {
            bool isLegalSingleCaptureMove = false;

            if(i_GameBoard.IsValidOccupiedSquare(i_CapturedSquare) &&
               i_GameBoard.GameBoardMatrix[i_CapturedSquare.Row, i_CapturedSquare.Column] != this.RegularCoin &&
               i_GameBoard.GameBoardMatrix[i_CapturedSquare.Row, i_CapturedSquare.Column] != this.KingCoin &&
               i_GameBoard.IsValidEmptySquare(i_DestinationSquare))
            {
                isLegalSingleCaptureMove = true;
            }

            return isLegalSingleCaptureMove;
        }

        private void AddSingleCaptureMoveToList(List<Move> singleCaptures, Square i_SourceSquare,
                        Square i_DestinationSquare, Square i_CapturedSquare)
        {
            Move captureMove = new Move(i_SourceSquare, i_DestinationSquare);
            
            captureMove.AddCapturedSquare(i_CapturedSquare);
            singleCaptures.Add(captureMove);
        }

        private List<Move> GetSingleCaptureMovesPerSquare(GameBoard i_GameBoard, Square i_SourceSquare)
        {
            List<Move> singleCaptureMoves = new List<Move>();
            int directionOfPlay = (int)DirectionOfPlay;
            int directionOfCapture;

            directionOfCapture = (int)eDirection.Right;
            CheckAndAddSingleCaptureMoveToList(i_GameBoard, i_SourceSquare, directionOfPlay, directionOfCapture, ref singleCaptureMoves);
            directionOfCapture = (int)eDirection.Left;
            CheckAndAddSingleCaptureMoveToList(i_GameBoard, i_SourceSquare, directionOfPlay, directionOfCapture, ref singleCaptureMoves);
            if(i_GameBoard.GameBoardMatrix[i_SourceSquare.Row, i_SourceSquare.Column] == KingCoin)
            {
                directionOfPlay *= -1;
                directionOfCapture = (int)eDirection.Right;
                CheckAndAddSingleCaptureMoveToList(i_GameBoard, i_SourceSquare, directionOfPlay, directionOfCapture, ref singleCaptureMoves);
                directionOfCapture = (int)eDirection.Left;
                CheckAndAddSingleCaptureMoveToList(i_GameBoard, i_SourceSquare, directionOfPlay, directionOfCapture, ref singleCaptureMoves);
            }

            return singleCaptureMoves;
        }

        private void CheckAndAddSingleCaptureMoveToList(GameBoard i_GameBoard, Square i_SourceSquare,
                            int i_DirectionOfPlay, int i_DirectionOfCapture, ref List<Move> io_SingleCaptureMoves)
        {
            Square capturedSquare = new Square(i_SourceSquare.Row + i_DirectionOfPlay,
                i_SourceSquare.Column + i_DirectionOfCapture);
            Square destinationSquare = new Square(i_SourceSquare.Row + (2 * i_DirectionOfPlay),
                i_SourceSquare.Column + (2 * i_DirectionOfCapture));
            if(IsLegalSingleCaptureMove(i_GameBoard, capturedSquare, destinationSquare))
            {
                AddSingleCaptureMoveToList(io_SingleCaptureMoves, i_SourceSquare, destinationSquare, capturedSquare);
            }
        }

        private bool IsCaptureMove(Move i_Move)
        {
            bool isCaptureMove = false;
            List<Square> capturedSquares = i_Move.CapturedSquares;
            
            if(!IsListEmpty(capturedSquares))
            {
                isCaptureMove = true;
            }

            return isCaptureMove;
        }

        private void MakeMove(GameBoard i_GameBoard, Move i_Move)
        {
            eCoin playedCoin;

            if(IsCaptureMove(i_Move))
            {
                foreach(Square capturedSquare in i_Move.CapturedSquares)
                {
                    eCoin capturedSquareCoin = 
                                i_GameBoard.GameBoardMatrix[capturedSquare.Row, capturedSquare.Column];
                    if(capturedSquareCoin == eCoin.X || capturedSquareCoin == eCoin.O)
                    {
                        Points++;
                    }
                    else if(capturedSquareCoin == eCoin.U || capturedSquareCoin == eCoin.K)
                    {
                        Points += 4;
                    }
                    
                    i_GameBoard.GameBoardMatrix[capturedSquare.Row, capturedSquare.Column] = eCoin.E;
                }
            }

            playedCoin = i_GameBoard.GameBoardMatrix[i_Move.From.Row, i_Move.From.Column];
            i_GameBoard.GameBoardMatrix[i_Move.From.Row, i_Move.From.Column] = eCoin.E;
            if(playedCoin == RegularCoin && IsSquareThatTurnsCoinIntoKing(i_GameBoard, i_Move.To))
            {
                playedCoin = KingCoin;
            }

            i_GameBoard.GameBoardMatrix[i_Move.To.Row, i_Move.To.Column] = playedCoin;
        }

        private bool IsSquareThatTurnsCoinIntoKing(GameBoard i_GameBoard, Square i_Square)
        {
            bool isSquareThatTurnsCoinIntoKing = false;

            if(DirectionOfPlay == eDirection.Up)
            {
                if(i_Square.Row == i_GameBoard.BoardSize - 1)
                {
                    isSquareThatTurnsCoinIntoKing = true;
                }
            }
            else if(DirectionOfPlay == eDirection.Down)
            {
                if(i_Square.Row == 0)
                {
                    isSquareThatTurnsCoinIntoKing = true;
                }
            }

            return isSquareThatTurnsCoinIntoKing;
        }

        public bool IsListEmpty<T>(List<T> list)
        {
            bool isListEmpty = false;

            if(list == null)
            {
                isListEmpty = true;
            }
            else
            {
                isListEmpty = !list.Any<T>();
            }

            return isListEmpty;
        }

        private void FindAllCaptureMovesPerSquare(GameBoard i_GameBoard, Square i_CurrentSquare, Move i_Move,
                            List<Move> io_PossibleCaptures)
        {
            List<Move> simpleCaptureMoves = GetSingleCaptureMovesPerSquare(i_GameBoard, i_CurrentSquare);
            if(IsListEmpty<Move>(simpleCaptureMoves))
            {
                i_Move.To = i_CurrentSquare;
                if(!i_Move.From.Equals(i_Move.To))
                {
                    io_PossibleCaptures.Add(i_Move);
                }

                return;
            }

            foreach(Move captureMove in simpleCaptureMoves)
            {
                Move j = new Move(i_Move);
                j.AddCapturedSquare(captureMove.CapturedSquares[0]);
                FindAllCaptureMovesPerSquare(i_GameBoard, captureMove.To, j, io_PossibleCaptures);
            }
        }

        private List<Move> GetAllCaptureMovesPerSquare(GameBoard i_Gameboard, Square i_SourceSquare)
        {
            List<Move> allCaptureMoves = new List<Move>();
            Move captureMove = new Move(i_SourceSquare);

            FindAllCaptureMovesPerSquare(i_Gameboard, i_SourceSquare, captureMove, allCaptureMoves);

            return allCaptureMoves;
        }

        private List<Move> GetMovesWithoutCapturePerSquare(GameBoard i_GameBoard, Square i_SourceSquare)
        {
            List<Move> movesWithoutCaptures = new List<Move>();
            int oppositeDirectionOfPlay = (int)DirectionOfPlay;
            int diagonalDirectionOfPlay;

            diagonalDirectionOfPlay = (int)eDirection.Right;
            CheckAndAddMoveWithoutCaptureToList(i_GameBoard, i_SourceSquare, oppositeDirectionOfPlay,
                                    diagonalDirectionOfPlay, ref movesWithoutCaptures);
            diagonalDirectionOfPlay = (int)eDirection.Left;
            CheckAndAddMoveWithoutCaptureToList(i_GameBoard, i_SourceSquare, oppositeDirectionOfPlay,
                                    diagonalDirectionOfPlay, ref movesWithoutCaptures);
            if(i_GameBoard.GameBoardMatrix[i_SourceSquare.Row, i_SourceSquare.Column] == this.KingCoin)
            {
                oppositeDirectionOfPlay *= -1;
                diagonalDirectionOfPlay = (int)eDirection.Right;
                CheckAndAddMoveWithoutCaptureToList(i_GameBoard, i_SourceSquare, oppositeDirectionOfPlay,
                                        diagonalDirectionOfPlay, ref movesWithoutCaptures);
                diagonalDirectionOfPlay = (int)eDirection.Left;
                CheckAndAddMoveWithoutCaptureToList(i_GameBoard, i_SourceSquare, oppositeDirectionOfPlay,
                                        diagonalDirectionOfPlay, ref movesWithoutCaptures);
            }
            
            return movesWithoutCaptures;
        }
        
        private void CheckAndAddMoveWithoutCaptureToList(GameBoard i_GameBoard, Square i_SourceSquare, int o_OppositeDirectionOfPlay,
                                    int i_DiagonalDirectionOfPlay, ref List<Move> io_MovesWithoutCaptures)
        {
            Move move;
            Square destinationSquare = new Square(i_SourceSquare.Row + o_OppositeDirectionOfPlay,
                i_SourceSquare.Column + i_DiagonalDirectionOfPlay);
            if(i_GameBoard.IsValidEmptySquare(destinationSquare))
            {
                move = new Move(i_SourceSquare, destinationSquare);
                io_MovesWithoutCaptures.Add(move);
            }
        }
    }
}
