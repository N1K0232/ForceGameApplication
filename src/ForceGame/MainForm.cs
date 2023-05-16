using ForceGame.Core;

namespace ForceGame;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void OnPlayButtonClick(object sender, EventArgs e)
    {
        string firstPlayerName = txtFirstPlayer.Text;
        string secondPlayerName = txtSecondPlayer.Text;

        if (string.IsNullOrWhiteSpace(firstPlayerName))
        {
            MessageBox.Show("the first player name is required", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(secondPlayerName))
        {
            MessageBox.Show("the second player name is required", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var firstPlayer = new Player { Name = firstPlayerName };
        var secondPlayer = new Player { Name = secondPlayerName };

        var game = new Game(firstPlayer, secondPlayer);
        var gameForm = new GameForm(game);

        Hide();
        gameForm.ShowDialog();
    }
}