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
        bool isValid = ValidateForm();
        if (!isValid)
        {
            return;
        }

        string firstPlayerName = txtFirstPlayer.Text;
        string secondPlayerName = txtSecondPlayer.Text;

        var firstPlayer = new Player { Name = firstPlayerName };
        var secondPlayer = new Player { Name = secondPlayerName };

        var game = new Game(firstPlayer, secondPlayer);
        var gameForm = new GameForm(game);

        Hide();
        gameForm.ShowDialog();
    }

    private bool ValidateForm()
    {
        if (string.IsNullOrWhiteSpace(txtFirstPlayer.Text))
        {
            MessageBox.Show("the first player name is required", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtSecondPlayer.Text))
        {
            MessageBox.Show("the second player name is required", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }
}