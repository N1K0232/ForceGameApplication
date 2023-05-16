using System.ComponentModel;

namespace ForceGame;

public partial class GameForm : Form
{
    private IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new Container();

        CreateGameField();

        SuspendLayout();

        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 800);
        Name = "GameForm";
        Text = "Force game";

        ResumeLayout(false);
        PerformLayout();
    }

    private void CreateGameField()
    {
        for(int i = 0; i < 7; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                Button fieldButton = new Button();
                fieldButton.Tag = $"{i}{j}";
                fieldButton.Text = $"{i}{j}";
                fieldButton.Width = 80;
                fieldButton.Height = 80;
                fieldButton.Top = 80 * j;
                fieldButton.Left = 80 * i;
                fieldButton.Visible = true;
                fieldButton.Enabled = true;
                fieldButton.Click += new EventHandler(FieldButton_Click);

                Controls.Add(fieldButton);
            }
        }
    }
}