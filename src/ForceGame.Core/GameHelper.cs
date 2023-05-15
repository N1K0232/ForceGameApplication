using System.Timers;
using Timer = System.Timers.Timer;

namespace ForceGame.Core;

public partial class Game
{
    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (_timer.Enabled)
        {
            _timeCount++;
        }
    }

    private void StopCore()
    {
        if (_gameActive)
        {
            _timer.Stop();
            _gameActive = false;
        }
    }

    private bool CheckSpace(int row, int column) => !CheckSpace(row, column, 0);

    private bool CheckSpace(int row, int column, int color) => _field[row, column] == color;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            StopCore();
            ClearField();

            _firstPlayer = null;
            _secondPlayer = null;

            _field = null;

            _timer.Dispose();
            _timer = null;

            _disposed = true;
        }
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(GetType().FullName);
        }
    }

    private void Initialize()
    {
        _timer = new Timer(1000);
        _field = new int[7, 6];

        ClearField();
    }

    private void ClearField()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                _field[i, j] = 0;
            }
        }
    }
}