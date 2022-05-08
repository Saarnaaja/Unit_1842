using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1842
{
    static class ConsoleWriter
    {
        /// <summary>
        /// Отображение текста на консоли в указанных координатах, предварительно очищая строку.
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="text"></param>
        public static void WriteConsoleText(int posX, int posY, string text)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, posY);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(posX, posY);
            Console.Write(text);
            Console.CursorVisible = true;
        }
    }
}
