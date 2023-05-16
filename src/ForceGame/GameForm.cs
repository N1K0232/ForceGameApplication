using ForceGame.Core;

namespace ForceGame;

public partial class GameForm : Form
{
    private Game _game;

    public GameForm(Game game)
    {
        _game = game;
        InitializeComponent();
    }

    private void FieldButton_Click(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        string tag = Convert.ToString(clickedButton.Tag);

        int row = int.Parse(tag.Substring(0, 1));
        int column = int.Parse(tag.Substring(1, 1));
        int color = GetColor(clickedButton);

        _game.Play(row, column, color);
    }

    private int GetColor(Button button)
    {
        int turn = _game.Turn;

        if (turn == 1)
        {
            button.BackColor = Color.Red;
            return 1;
        }
        else
        {
            button.BackColor = Color.Yellow;
            return 2;
        }
    }
}