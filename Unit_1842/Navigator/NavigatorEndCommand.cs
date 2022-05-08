using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1842.Navigator
{
    class NavigatorEndCommand : INavigatorCommand
    {
        private INavigator _navigator;
        public NavigatorEndCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public ConsoleKey GetKey() => ConsoleKey.Enter;

        public void Execute() => _navigator.Stop();
    }
}
