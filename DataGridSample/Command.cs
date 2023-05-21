using System;
using System.Windows.Input;

namespace DataGridSample
{
    internal class Command : ICommand
    {
        readonly Action<object?> action;

        public event EventHandler? CanExecuteChanged { add { } remove { } }

        public Command(Action<object?> action) => this.action = action;

        public bool CanExecute(object? _) => true;

        public void Execute(object? parameter) => action(parameter);
    }
}
