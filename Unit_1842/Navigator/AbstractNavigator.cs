using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1842.Navigator
{
    abstract class AbstractNavigator<TCollection, TCollectionElement> : INavigator
            where TCollection : IEnumerable<TCollectionElement>
    {
        private int _index;
        private bool _isRun;

        protected int CursorTop { private set; get; }
        protected TCollection Collection;
        protected List<INavigatorCommand> Commands;

        protected abstract void ShowCollection();
        protected abstract void ExecuteCommand();

        public AbstractNavigator()
        {
            //Создаем список команд по умолчанию
            //Вверх, вниз, выбрать
            Commands = new List<INavigatorCommand>()
            {
                new NavigatorNextCommand(this),
                new NavigatorPreviousCommand(this),
                new NavigatorEndCommand(this)
            };
        }

        /// <summary>
        /// Выбрать следующий элемент в списке
        /// </summary>
        public void Next()
        {
            if (Collection == null) return;
            if (_index < Collection.Count() - 1)
            {
                ShowSelectedRow(_index, _index + 1);
                _index++;
            }
        }

        /// <summary>
        /// Выбрать предыдущий элемент в списке
        /// </summary>
        public void Previous()
        {
            if (Collection == null) return;
            if (_index > 0)
            {
                ShowSelectedRow(_index, _index - 1);
                _index--;
            }
        }

        /// <summary>
        /// Запуск навигатора.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Run()
        {
            if (Collection == null || Collection.Count() == 0)
                throw new Exception("Нет данных для отображения");

            CursorTop = Console.CursorTop;
            _isRun = true;

            ShowCollection();
            ShowSelectedRow(0, 0);

            while (_isRun)
            {
                ExecuteCommand();
            }

            Console.SetCursorPosition(0, CursorTop + Collection.Count());
        }

        /// <summary>
        /// Получает последний выбранный элемент из списка.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public object GetCurrentSelected()
        {
            if (Collection == null || Collection.Count() == 0)
                throw new Exception("Нет данных");
            return Collection.ElementAt(_index);
        }

        public void Stop()
        {
            _isRun = false;
        }

        protected virtual void ShowSelectedRow(int oldIndex, int newIndex)
        {
            Console.SetCursorPosition(0, CursorTop + oldIndex);
            Console.Write(" ");
            Console.SetCursorPosition(0, CursorTop + newIndex);
            Console.Write(">");
        }
    }
}
