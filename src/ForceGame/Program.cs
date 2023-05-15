namespace ForceGame;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();

        var mainForm = new MainForm();
        Application.Run(mainForm);
    }
}