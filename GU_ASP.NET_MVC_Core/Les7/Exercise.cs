using System;

namespace Les7
{
    public class Exercise
    {
        int _timeRun;
        int _age;
        int _number;
        /// <summary>
        /// Время на выполнение задания в минутах
        /// </summary>
        public int TimeRun { get { return _timeRun; } }
        /// <summary>
        /// Возраст заданий в часах
        /// </summary>
        public int Age { get { return _age; } }
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Number { get { return _number; } }

        public Exercise(int number, int age, int timeRun)
        {
            _number = number;
            _timeRun = timeRun;
            _age = age;
        }
    }
}
