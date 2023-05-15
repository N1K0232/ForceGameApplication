using System.Timers;
using Timer = System.Timers.Timer;

namespace ForceGame.Core;

public class Game : IGame
{
    private Player _firstPlayer = null;
    private Player _secondPlayer = null;

    private Timer _timer = null;

    private int[,] _field = null;

    private int _currentTurn = 0; //1 for player 1 otherwise 2 for player 2
    private int _timeCount = 0;

    private bool _gameActive = false;
    private bool _disposed = false;


    public Game()
    {
        Initialize();
    }

    public Player FirstPlayer
    {
        get
        {
            return _firstPlayer;
        }
        set
        {
            Player firstPlayer = value;
            ArgumentNullException.ThrowIfNull(firstPlayer, nameof(FirstPlayer));

            if (firstPlayer == FirstPlayer)
            {
                return;
            }

            _firstPlayer = firstPlayer;
        }
    }

    public Player SecondPlayer
    {
        get
        {
            return _secondPlayer;
        }
        set
        {
            Player secondPlayer = value;
            ArgumentNullException.ThrowIfNull(secondPlayer, nameof(SecondPlayer));

            if (secondPlayer == SecondPlayer)
            {
                return;
            }

            _secondPlayer = secondPlayer;
        }
    }

    public int Turn => _currentTurn;

    public bool IsGameActive => _gameActive;

    public TimeSpan TotalTime
    {
        get
        {
            if (!_gameActive && !_timer.Enabled)
            {
                return TimeSpan.FromTicks(_timeCount);
            }

            return TimeSpan.Zero;
        }
    }

    public void Start()
    {
        ThrowIfDisposed();

        if (!_gameActive)
        {
            Random random = new();
            _currentTurn = random.Next(1, 3);

            _timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            _timer.Start();

            _gameActive = true;
        }
    }

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (_timer.Enabled)
        {
            _timeCount++;
        }
    }

    public void Stop()
    {
        ThrowIfDisposed();
        StopCore();
    }

    private void StopCore()
    {
        if (_gameActive)
        {
            _timer.Stop();
            _gameActive = false;
        }
    }

    public bool Play(int row, int column, int color)
    {
        if (row < 0 || row > _field.GetLength(0))
        {
            throw new ArgumentOutOfRangeException(nameof(row), "the row is invalid");
        }

        if (column < 0 || column > _field.GetLength(1))
        {
            throw new ArgumentOutOfRangeException(nameof(column), "the column is invalid");
        }

        if (color < 0 || color > 2)
        {
            throw new ArgumentOutOfRangeException(nameof(color), "invalid color");
        }

        bool hasColor = CheckSpace(row, column, color);
        if (hasColor)
        {
            return false;
        }

        _field[row, column] = color;
        return true;
    }

    public bool CheckWin(int row, int column)
    {
        return CheckSpace(row, column);
    }

    public bool CheckParity()
    {
        int totalCount = 0;

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                bool hasValue = CheckSpace(i, j);
                if (hasValue)
                {
                    totalCount++;
                }
            }
        }

        return totalCount == 42;
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