using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EventArgument
{
    public class ExecutionCompletedEventArgs : EventArgs
    {
        public bool IsSuccessfull { get; set; }
        public string? Message { get; set; }
    }
}
