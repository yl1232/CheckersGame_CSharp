using System;
using System.Windows.Forms;

namespace Ex05
{
    public partial class GameSettingsForm : Form
    {
        private int m_ChosenBoardSize;
        private bool m_PlayVsComputer = true;
        private string m_FirstPlayerName;
        private string m_SecondPlayerName;

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public bool PlayVsComputer
        {
            get
            {
                return m_PlayVsComputer;
            }
        }

        public int ChosenBoardSize
        {
            get
            {
                return m_ChosenBoardSize;
            }
        }

        public string FirstPlayerName
        {
            get
            {
                return m_FirstPlayerName;
            }
        }

        public string SecondPlayerName
        {
            get
            {
                return m_SecondPlayerName;
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if(!setSize6.Checked && !setSize8.Checked && !setSize10.Checked)
            {
                MessageBox.Show("Please chose the size of the gameboard");
            }
            else if(player1Name.Text == string.Empty)
            {
                MessageBox.Show("Please enter the name of the Player 1");
            }
            else if(player2CheckBox.Checked && player2Name.Text == string.Empty)
            {
                MessageBox.Show("Please enter the name of the Player 2");
            }
            else
            {
                MessageBox.Show("You start the game. Good luck!");
                m_FirstPlayerName = player1Name.Text;
                if(m_PlayVsComputer)
                {
                    m_SecondPlayerName = "computer";
                }
                else
                {
                    m_SecondPlayerName = player2Name.Text;
                }
                
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BoardSizeRadioButton_Click(object sender, EventArgs e)
        { 
            if(setSize6.Checked)
            {
                m_ChosenBoardSize = 6;
            }
            else if(setSize8.Checked)
            {
                m_ChosenBoardSize = 8;
            }
            else 
            {
                m_ChosenBoardSize = 10;
            }
        }

        private void SecondPlayerCheckBox_Click(object sender, EventArgs e)
        {
            if(player2CheckBox.Checked)
            {
                m_PlayVsComputer = false;
                player2Name.Enabled = true;
                player2Name.Text = string.Empty;
            }
            else
            {
                player2Name.Enabled = false;
                player2Name.Text = "[Computer]";
                m_SecondPlayerName = "computer";
            }
        }
    }
}
