using System.ComponentModel;

namespace ForceGame;

public partial class MainForm : Form
{
    private IContainer components = null;

    private Label lblFirstPlayer;
    private Label lblSecondPlayer;

    private TextBox txtFirstPlayer;
    private TextBox txtSecondPlayer;

    private Button playButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
                components = null;
            }

            lblFirstPlayer.Dispose();
            lblSecondPlayer.Dispose();

            txtFirstPlayer.Dispose();
            txtSecondPlayer.Dispose();

            playButton.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblFirstPlayer = new Label();
        lblSecondPlayer = new Label();

        txtFirstPlayer = new TextBox();
        txtSecondPlayer = new TextBox();

        playButton = new Button();
        
        SuspendLayout();

        txtFirstPlayer.BackColor = Color.White;
        txtFirstPlayer.BorderStyle = BorderStyle.FixedSingle;
        txtFirstPlayer.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
        txtFirstPlayer.ForeColor = Color.Black;
        txtFirstPlayer.Location = new Point(220, 91);
        txtFirstPlayer.Name = "txtFirstPlayer";
        txtFirstPlayer.Size = new Size(280, 36);
        txtFirstPlayer.TabIndex = 0;


        txtSecondPlayer.BackColor = Color.White;
        txtSecondPlayer.BorderStyle = BorderStyle.FixedSingle;
        txtSecondPlayer.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
        txtSecondPlayer.ForeColor = Color.Black;
        txtSecondPlayer.Location = new Point(220, 155);
        txtSecondPlayer.Name = "txtSecondPlayer";
        txtSecondPlayer.Size = new Size(280, 36);
        txtSecondPlayer.TabIndex = 1;


        playButton.FlatAppearance.BorderColor = Color.Blue;
        playButton.FlatAppearance.BorderSize = 2;
        playButton.FlatStyle = FlatStyle.Flat;
        playButton.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
        playButton.ForeColor = Color.Black;
        playButton.Location = new Point(295, 224);
        playButton.Name = "playButton";
        playButton.Size = new Size(131, 61);
        playButton.TabIndex = 2;
        playButton.Text = "Play";
        playButton.UseVisualStyleBackColor = true;
        playButton.Click += new EventHandler(OnPlayButtonClick);


        lblFirstPlayer.AutoSize = true;
        lblFirstPlayer.BorderStyle = BorderStyle.FixedSingle;
        lblFirstPlayer.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
        lblFirstPlayer.ForeColor = Color.Black;
        lblFirstPlayer.Location = new Point(122, 91);
        lblFirstPlayer.Name = "lblFirstPlayer";
        lblFirstPlayer.Size = new Size(92, 32);
        lblFirstPlayer.TabIndex = 3;
        lblFirstPlayer.Text = "Player 1";
        lblFirstPlayer.TextAlign = ContentAlignment.MiddleLeft;


        lblSecondPlayer.AutoSize = true;
        lblSecondPlayer.BorderStyle = BorderStyle.FixedSingle;
        lblSecondPlayer.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
        lblSecondPlayer.ForeColor = Color.Black;
        lblSecondPlayer.Location = new Point(122, 157);
        lblSecondPlayer.Name = "lblSecondPlayer";
        lblSecondPlayer.Size = new Size(92, 32);
        lblSecondPlayer.TabIndex = 4;
        lblSecondPlayer.Text = "Player 2";
        lblSecondPlayer.TextAlign = ContentAlignment.MiddleLeft;


        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(687, 362);
        Controls.Add(lblSecondPlayer);
        Controls.Add(lblFirstPlayer);
        Controls.Add(playButton);
        Controls.Add(txtSecondPlayer);
        Controls.Add(txtFirstPlayer);
        ForeColor = Color.Black;
        Name = "MainForm";
        Text = "Login Form";
        
        ResumeLayout(false);
        PerformLayout();
    }
}