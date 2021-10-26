using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLibrary
{

    // Создайте класс-обертку над List<T>, что бы можно было добавлять и удалять элементы из разных потоков без ошибок.
    public class ListWrapper<T>
    {
        List<T> _list; 
        object _lock = new object();

        public ListWrapper()
        {
            _list = new List<T>();
        }

        public ListWrapper(List<T> list)
        {
            _list = list;
        }

        public void Add(T item)
        {
            lock (_lock)
            {
                _list.Add(item);
            }
        }
        public void Remove(T item)
        {
            lock (_lock)
            {
                if (_list.Count < 1) return;
                _list.Remove(item);
            }
        }
    }
}
