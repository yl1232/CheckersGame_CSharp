namespace Ex05
{
    public class Program
    {
        public static void Main()
        {
            GameSettingsForm gameSettingsForm = new GameSettingsForm();

            gameSettingsForm.ShowDialog();
            if(gameSettingsForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                GameForm startGameForm = new GameForm(gameSettingsForm.ChosenBoardSize, 
                    gameSettingsForm.FirstPlayerName, gameSettingsForm.SecondPlayerName, 
                    gameSettingsForm.PlayVsComputer);

                startGameForm.ShowDialog();
            }
        }
    }
}
