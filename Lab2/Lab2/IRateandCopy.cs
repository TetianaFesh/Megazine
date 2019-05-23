using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    interface IRateandCopy
    {
        double _Rating { get; }
        object DeepCopy();
    }
}
