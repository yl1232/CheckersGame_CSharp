using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public partial class GameForm : Form
    {
        private const int k_BtnSize = 40;
        private const int k_BtnStartPosition = 20;
        private const int k_ButtonWidth = 40;
        private const int k_ButtonHeight = 40;
        private const int k_Distance = 10;
        private readonly CheckersGame m_GameLogic;
        private CheckersButton[,] m_GameBoardButtonMatrix;
        private bool m_IsButtonClicked;

        public GameForm(int i_BoardSize, string i_FirstPlayerName, string i_SecondPlayerName, 
                    bool i_VsComputer)
        {
            m_GameBoardButtonMatrix = new CheckersButton[i_BoardSize, i_BoardSize];
            m_GameLogic = new CheckersGame();
            m_GameLogic.GameBoard = new GameBoard(i_BoardSize);
            m_GameLogic.TwoPlayers = !i_VsComputer;
            InitializePlayers(i_FirstPlayerName, i_SecondPlayerName);
            m_IsButtonClicked = false;
            InitializeComponent();
            InitializeForm();
            CreateAndDisplayBoard();
            InitializeRound();   
        }

        public CheckersButton[,] GameBoardButtonMatrix
        {
            get
            {
                return m_GameBoardButtonMatrix;
            }

            set
            {
                m_GameBoardButtonMatrix = value;
            }
        }

        public CheckersGame GameLogic
        {
            get
            {
                return m_GameLogic;
            }
        }

        public bool IsButtonClicked
        {
            get
            {
                return m_IsButtonClicked;
            }

            set
            {
                m_IsButtonClicked = value;
            }
        }

        private void InitializeForm()
        {
            int boardSize = GameLogic.GameBoard.BoardSize;

            Width = (boardSize * k_BtnSize) + (k_BtnStartPosition * 3);
            Height = (boardSize * k_BtnSize) + (k_BtnStartPosition * 5);
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = "Checkers";
            player1Label = new System.Windows.Forms.Label();
            player1PointsLabel = new System.Windows.Forms.Label();
            player2Label = new System.Windows.Forms.Label();
            player2PointsLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            player1Label.AutoSize = true;
            player1Label.Name = "player1Label";
            player1Label.Top = 2 * k_Distance;
            player1Label.Left = (boardSize * k_Distance) - k_Distance;
            player1Label.Text = GameLogic.FirstPlayer.Name + 
                        ":" + GameLogic.FirstPlayer.Points.ToString();
            Controls.Add(player1Label);
            player2Label.AutoSize = true;
            player2Label.Name = "player2Label";
            player2Label.Top = 2 * k_Distance;
            player2Label.Left = (3 * boardSize * k_Distance) - (2 * k_Distance);
            player2Label.Text = GameLogic.SecondPlayer.Name + 
                        ":" + GameLogic.SecondPlayer.Points.ToString();
            Controls.Add(player2Label);
        }

        private void InitializePlayers(string i_FirstPlayerName,
                            string i_SecondPlayerName)
        {
            GameLogic.FirstPlayer = new Player(i_FirstPlayerName, eCoin.O, eCoin.U, eDirection.Up);
            GameLogic.SecondPlayer = new Player(i_SecondPlayerName, eCoin.X, eCoin.K, eDirection.Down);
        }

        public void CreateAndDisplayBoard()
        {
            int boardSize = GameLogic.GameBoard.BoardSize;
            int start_i = 40;
            int start_j = 10;

            for(int i = 0; i < boardSize; i++)
            {
                for(int j = 0; j < boardSize; j++)
                {
                    CheckersButton button = new CheckersButton(i, j);
                    button.Top = start_i + ((i * k_ButtonHeight) + k_Distance);
                    button.Left = start_j + ((j * k_ButtonWidth) + k_Distance);
                    button.Width = k_ButtonWidth;
                    button.Height = k_ButtonHeight;
                    button.Enabled = false;
                    button.TabStop = false;
                    button.Click += new EventHandler(Button_Click);
                    if((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        button.BackColor = Color.White;
                    }
                    else
                    {
                        button.BackColor = Color.Gray;
                    }

                    GameBoardButtonMatrix[i, j] = button;
                }
            }

            for(int i = 0; i < (boardSize - 2) / 2; i++)
            {
                for(int j = 0; j < boardSize; j++)
                {
                    if(i % 2 == 0)
                    {
                        GameBoardButtonMatrix[i, j + 1].Text = "O";
                        j += 1;
                    }
                    else
                    {
                        GameBoardButtonMatrix[i, j].Text = "O";
                        j += 1;
                    }
                }
            }

            for(int i = boardSize - 1; i > (((boardSize - 2) / 2) + 1); i--)
            {
                for(int j = 0; j < boardSize; j++)
                {
                    if(i % 2 == 0)
                    {
                        GameBoardButtonMatrix[i, j + 1].Text = "X";
                        j += 1;
                    }
                    else
                    {
                        GameBoardButtonMatrix[i, j].Text = "X";
                        j += 1;
                    }
                }
            }

            DisplayBoard();
        }

        private void InitializeRound()
        {
            GameLogic.GameBoard.InitializeCoinsOnGameBoard();
            GameLogic.FirstPlayer.Points = 0;
            GameLogic.SecondPlayer.Points = 0;
            GameLogic.PlayerTurn = GameLogic.FirstPlayer;
            UpdateBoard();
            EnableCurrentPlayerButtons();
        }

        private void DeclareTie()
        {
            string message = string.Format(@"Tie!
Another Round?");
            string caption = "Checkers";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult playerChoice = MessageBox.Show(this, message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if(playerChoice == DialogResult.Yes)
            {
                InitializeRound();
            }
            else if(playerChoice == DialogResult.No)
            {
                Close();
            }
        }

        private void DeclareWin(Player winner)
        {
            string message = string.Format(@"{0} Won!
Another Round?", winner.Name);
            string caption = "Checkers";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult playerChoice = MessageBox.Show(this, message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
           
            if(playerChoice == DialogResult.Yes)
            {
                InitializeRound();
            }
            else if(playerChoice == DialogResult.No)
            {
                Close();
            }
        }

        private void EnableCurrentPlayerButtons()
        {
            for(int i = 0; i < GameLogic.GameBoard.BoardSize; i++)
            {
                for(int j = 0; j < GameLogic.GameBoard.BoardSize; j++)
                {
                    if(GameBoardButtonMatrix[i, j].Text != GameLogic.PlayerTurn.RegularCoin.ToString()
                        && GameBoardButtonMatrix[i, j].Text != GameLogic.PlayerTurn.KingCoin.ToString())
                    {
                        GameBoardButtonMatrix[i, j].Enabled = false;
                    }
                    else
                    {
                        GameBoardButtonMatrix[i, j].Enabled = true;
                    }
                }
            }
        }

        private void EnableEmptyButtons()
        {
            for(int i = 0; i < GameLogic.GameBoard.BoardSize; i++)
            {
                for(int j = 0; j < GameLogic.GameBoard.BoardSize; j++)
                {
                    if(GameBoardButtonMatrix[i, j].Text == string.Empty &&
                        GameBoardButtonMatrix[i, j].BackColor == Color.White)
                    {
                        GameBoardButtonMatrix[i, j].Enabled = true;
                    }
                    else
                    {
                        GameBoardButtonMatrix[i, j].Enabled = false;
                    }
                }
            }
        }

        private void DisableBoardButtons()
        {
            for(int i = 0; i < GameLogic.GameBoard.BoardSize; i++)
            {
                for(int j = 0; j < GameLogic.GameBoard.BoardSize; j++)
                {
                    GameBoardButtonMatrix[i, j].Enabled = false;
                }
            }
        }

        private void UpdateBoard()
        {
            for(int i = 0; i < GameLogic.GameBoard.BoardSize; i++)
            {
                for(int j = 0; j < GameLogic.GameBoard.BoardSize; j++)
                {
                    if(GameLogic.GameBoard.GameBoardMatrix[i, j] == eCoin.E)
                    {
                        GameBoardButtonMatrix[i, j].Text = string.Empty;
                    }
                    else
                    {
                        GameBoardButtonMatrix[i, j].Text = 
                                GameLogic.GameBoard.GameBoardMatrix[i, j].ToString();
                        if(GameLogic.GameBoard.GameBoardMatrix[i, j] == GameLogic.PlayerTurn.RegularCoin ||
                           GameLogic.GameBoard.GameBoardMatrix[i, j] == GameLogic.PlayerTurn.KingCoin)
                        {
                            GameBoardButtonMatrix[i, j].Font = 
                                new Font(GameBoardButtonMatrix[i, j].Font.Name,
                                        SystemFonts.MessageBoxFont.Size + 2, FontStyle.Bold);
                        }
                        else
                        {
                            GameBoardButtonMatrix[i, j].Font = 
                                new Font(GameBoardButtonMatrix[i, j].Font.Name, 
                                        SystemFonts.MessageBoxFont.Size);
                        }
                    }
                }
            }

            player1Label.Text = GameLogic.FirstPlayer.Name + 
                        ":" + GameLogic.FirstPlayer.Points.ToString();
            player2Label.Text = GameLogic.SecondPlayer.Name + 
                        ":" + GameLogic.SecondPlayer.Points.ToString();
            if(GameLogic.PlayerTurn == GameLogic.FirstPlayer)
            {
                player1Label.Font = new Font(player1Label.Font.Name, 
                            player1Label.Font.Size, FontStyle.Bold);
                player2Label.Font = new Font(player2Label.Font.Name, 
                            player2Label.Font.Size);
            }
            else
            {
                player2Label.Font = new Font(player2Label.Font.Name, 
                            player2Label.Font.Size, FontStyle.Bold);
                player1Label.Font = new Font(player1Label.Font.Name, 
                            player1Label.Font.Size);
            }

            Refresh();
        }

        private void DisplayBoard()
        {
            for(int i = 0; i < GameLogic.GameBoard.BoardSize; i++)
            {
                for(int j = 0; j < GameLogic.GameBoard.BoardSize; j++)
                {
                    Controls.Add(GameBoardButtonMatrix[i, j]);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            CheckersButton clickedButton = (CheckersButton)sender;

            if(clickedButton.BackColor == Color.White && !string.IsNullOrEmpty(clickedButton.Text) &&
                        !IsButtonClicked)
            {
                IsButtonClicked = true;
                clickedButton.BackColor = Color.LightBlue;
                GameLogic.PlayerTurn.NextMove = new Move(clickedButton.Coordinates);
                EnableEmptyButtons();
                clickedButton.Enabled = true;
            }
            else if(clickedButton.BackColor == Color.White && 
                        string.IsNullOrEmpty(clickedButton.Text) && IsButtonClicked)
            {
                Move playerNextMove = GameLogic.PlayerTurn.NextMove;
                Square previousButtonClickedCoordinates = GameLogic.PlayerTurn.NextMove.From;
                CheckersButton previousButtonClicked = 
                                    GameBoardButtonMatrix[previousButtonClickedCoordinates.Row,
                                    previousButtonClickedCoordinates.Column];

                previousButtonClicked.BackColor = Color.White;
                IsButtonClicked = false;
                GameLogic.PlayerTurn.NextMove.To = clickedButton.Coordinates;
                if(GameLogic.PlayerTurn.MoveInputPossible(GameLogic.GameBoard,
                                            ref playerNextMove))
                {
                    PlayMove(playerNextMove);
                }
                else
                {
                    string message = string.Format(@"Your move is illegal!
Please try again");

                    GameLogic.PlayerTurn.NextMove = null;
                    MessageBox.Show(message, "Checkers", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EnableCurrentPlayerButtons();
                }
            }
            else if(clickedButton.BackColor == Color.LightBlue)
            {
                clickedButton.BackColor = Color.White;
                IsButtonClicked = false;
                GameLogic.PlayerTurn.NextMove = null;
                EnableCurrentPlayerButtons();
            }
        }

        private void PlayMove(Move i_PlayerNextMove)
        {
            GameLogic.PlayerTurn.PlayRegularPlayerMove(GameLogic.GameBoard, i_PlayerNextMove);
            GameLogic.PlayerTurn.NextMove = null;
            GameLogic.ChangePlayerTurn();
            UpdateBoard();
            DisableBoardButtons();
            if(!GameLogic.PlayerTurn.PlayerHasLegalMoves(GameLogic.GameBoard))
            {
                EndRound();
            }
            else
            {
                if(GameLogic.PlayerTurn.Name == "computer")
                {
                    System.Threading.Thread.Sleep(1500);
                    GameLogic.PlayerTurn.PlayComputerMove(GameLogic.GameBoard);
                    GameLogic.ChangePlayerTurn();
                    UpdateBoard();
                    if(!GameLogic.PlayerTurn.PlayerHasLegalMoves(GameLogic.GameBoard))
                    {
                        EndRound();
                    }
                    else
                    {
                        EnableCurrentPlayerButtons();
                    }
                }
            }
        }

        private void EndRound()
        {
            GameLogic.ChangePlayerTurn();
            if(GameLogic.PlayerTurn.PlayerHasLegalMoves(GameLogic.GameBoard))
            {
                Player winner = GameLogic.PlayerTurn;
                DeclareWin(winner);
            }
            else
            {
                DeclareTie();
            }
        }
    }
}
