using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.WpfApp.Command
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return canExecute != null ? canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            execute?.Invoke(parameter);
        }
    }
}
