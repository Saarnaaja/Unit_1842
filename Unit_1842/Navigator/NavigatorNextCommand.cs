using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1842.Navigator
{
    class NavigatorNextCommand : INavigatorCommand
    {
        private INavigator _navigator;
        public NavigatorNextCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public ConsoleKey GetKey() => ConsoleKey.S;

        public void Execute() => _navigator.Next();
    }
}
