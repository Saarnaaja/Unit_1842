using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1842.Navigator
{
    class NavigatorPreviousCommand : INavigatorCommand
    {
        private INavigator _navigator;
        public NavigatorPreviousCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public ConsoleKey GetKey() => ConsoleKey.W;

        public void Execute() => _navigator.Previous();
    }
}
