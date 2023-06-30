using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Config
{
    public interface IResourceConfig<T>
    {
        string GetResourcePath();
    }
}
