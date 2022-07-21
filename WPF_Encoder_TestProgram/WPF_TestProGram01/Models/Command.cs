using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_TestProgram01.Models
{
    public class Command : ICommand
    {
        Action<object> _executeMethod;
        Func<object, bool> _canexecuteMethod;

        public Command(Action<object> executeMethod, Func<object, bool> canexecuteMethod)
        {
            _executeMethod = executeMethod;
            _canexecuteMethod = canexecuteMethod;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _executeMethod(parameter);
        }
    }
}
