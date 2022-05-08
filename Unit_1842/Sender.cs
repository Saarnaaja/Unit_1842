using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1842
{
    class Sender
    {
        private List<Command> _commands;

        public Sender()
        {
            _commands = new List<Command>();
        }
        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }

        public void Run()
        {
            foreach (var command in _commands)
            {
                command.Run();
            }
        }
    }
}
