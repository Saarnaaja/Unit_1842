using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1842.Navigator
{
    interface INavigator
    {
        void Next();
        void Previous();
        void Run();
        void Stop();
        object GetCurrentSelected();
    }
}
