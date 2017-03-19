using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    interface INameable
    {
        string Importance
        {
            get;
            set;
        }

        string Description
        {
            get;
            set;
        }
    }
}
