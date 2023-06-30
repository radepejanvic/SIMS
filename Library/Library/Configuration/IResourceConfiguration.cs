using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Configuration
{
    public interface IResourceConfiguration<T> 
    {
        public string GetResourcePath();
    }
}
