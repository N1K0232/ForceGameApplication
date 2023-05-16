﻿using System;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ForceGame.Core
{
    public partial class Game : IGame
    {
        private Player _firstPlayer = null;
        private Player _secondPlayer = null;

        private Timer _timer = null;

        private int[,] _field = null;

        private int _currentTurn = 0; //1 for player 1 otherwise 2 for player 2
        private int _timeCount = 0;

        private bool _gameActive = false;
        private bool _disposed = false;


        public Game(Player firstPlayer, Player secondPlayer)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;

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
                if (firstPlayer == null)
                {
                    throw new ArgumentNullException(nameof(FirstPlayer), "the first player is required");
                }

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
                if (secondPlayer == null)
                {
                    throw new ArgumentNullException(nameof(SecondPlayer), "the second player is required");
                }

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
                Random random = new Random();
                _currentTurn = random.Next(1, 3);

                _timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
                _timer.Start();

                _gameActive = true;
            }
        }

        public void Stop()
        {
            ThrowIfDisposed();
            StopInternal();
        }

        public void Resume()
        {
            _timer.Start();
            _gameActive = true;
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

            bool insertedValue = SetValue(row, column, color);
            if (insertedValue)
            {
                ChangeTurn(color);
            }

            return insertedValue;
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}