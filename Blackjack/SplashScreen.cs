using System.Windows.Forms;
using System;
using System.Drawing;

public class SplashScreen : Form
{
    public SplashScreen()
    {
        this.Text = "MagicTurtels-BlackJack";
        this.Width = 600;
        this.Height = 600;
        this.StartPosition = FormStartPosition.CenterScreen;

        this.FormBorderStyle = FormBorderStyle.None;
        this.ShowInTaskbar = false;


        string imagePath = Path.Combine(
            AppContext.BaseDirectory,
            "MagicTurtelsBlackJack.png"
        );
        //Console.WriteLine("Bildens sökväg: " + imagePath);                 //Användes när jag fel sökte när bilden ej funka.
        //Console.WriteLine("Finns bilden? " + File.Exists(imagePath));

        this.BackgroundImage = Image.FromFile(imagePath);
        this.BackgroundImageLayout = ImageLayout.Zoom;
        Button startButton = new Button();
        startButton.Text = "START GAME";
        startButton.Width = 200;
        startButton.Height = 50;

        startButton.Left = (this.ClientSize.Width - startButton.Width) / 2;
        startButton.Top = this.ClientSize.Height - 80;
        startButton.BackColor = Color.Black;
        startButton.ForeColor = Color.Gold;
        startButton.FlatStyle = FlatStyle.Flat;
        startButton.FlatAppearance.BorderColor = Color.Gold;
        startButton.FlatAppearance.BorderSize = 2;
        startButton.Font = new Font("Arial", 14, FontStyle.Bold);

        startButton.Click += (sender, e) => this.Close();

        this.Controls.Add(startButton);
    }


    private void InitializeComponent()
    {

    }
}
