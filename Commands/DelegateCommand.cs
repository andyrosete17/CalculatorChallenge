﻿using System;
using System.Windows.Input;

namespace CalculatorChallenge.Commands
{
    public class DelegateCommand : 
        ICommand
    {
        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Members

        private readonly Action _executeMethod = null;

        #endregion

        #region CTor

        public DelegateCommand(Action executeMethod)
        {
            _executeMethod = executeMethod ?? throw new ArgumentNullException(nameof(executeMethod));
        }

        #endregion

        #region Methods

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            _executeMethod?.Invoke();
        }

        #endregion
    }

    public class DelegateCommand<T> : 
        ICommand
    {
        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Members

        private readonly Action<T> _executeMethod = null;

        #endregion

        #region CTor

        public DelegateCommand(Action<T> executeMethod)
        {
            _executeMethod = executeMethod ?? throw new ArgumentNullException(nameof(executeMethod));
        }

        #endregion

        #region Methods

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            _executeMethod?.Invoke((T)parameter);
        }

        #endregion
    }
}