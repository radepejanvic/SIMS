using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.EventArgument;

namespace Library.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public event EventHandler<ExecutionCompletedEventArgs>? ExcecutionCompleted;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        protected void OnExecutionCompleted(bool isSuccessfull, string message)
        {
            ExcecutionCompleted?.Invoke(this, new ExecutionCompletedEventArgs { IsSuccessfull = isSuccessfull, Message = message });
        }

    }
}
