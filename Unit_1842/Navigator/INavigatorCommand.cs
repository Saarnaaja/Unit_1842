using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1842.Navigator
{
    interface INavigatorCommand
    {
        ConsoleKey GetKey();
        void Execute();
    }
}
