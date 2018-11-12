using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowsProject
{
   public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public void RaiseCanExecuteChangedd()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private Action<object> execute;
        private Func<object, bool> canExecute = (_) => true;

        public RelayCommand(Action<object> action)
        {
            execute = action;
        }

        public RelayCommand(Action<Object> action, Func<object, bool> test)
        {
            execute = action;
            canExecute = test;
        }


    }
}
