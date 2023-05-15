namespace ForceGame.Core;

public interface IGame : IDisposable
{
    Player FirstPlayer { get; set; }

    Player SecondPlayer { get; set; }

    int Turn { get; }

    bool IsGameActive { get; }

    void Start();

    void Stop();

    void Resume();

    bool Play(int row, int column, int color);

    bool CheckWin(int row, int column);

    bool CheckParity();
}