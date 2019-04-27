using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CalculatorChallenge.ViewModels
{
    public abstract class ViewModelBase : 
        INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;

            NotifyPropertyChanged(propertyName);

            return true;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
