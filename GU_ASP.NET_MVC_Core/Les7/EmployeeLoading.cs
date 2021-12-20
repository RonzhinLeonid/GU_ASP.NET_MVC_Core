using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Les7
{
    public class EmployeeLoading
    {
        Regex _technicalTask = new Regex(@"^(ТЗ.+)");
        Regex _orderPassport = new Regex(@"^(ПЗ.+)");
        string _name;
        List<Exercise> _listTechnicalTasks;
        List<Exercise> _listOrderPassports;
        int _countTechnicalTask;
        int _countOrderPassport;
        int _countAllTask;
        int _totalTimeRanTechnicalTask;
        int _totalTimeRanOrderPassport;
        int _totalTimeRanAllTask;
        double _averageAgeTechnicalTask;
        double _averageAgeOrderPassport;
        double _averageAgeAllTask;

        /// <summary>
        /// Имя инженера
        /// </summary>
        public string Name { get { return _name; } }
        /// <summary>
        /// Кол-во ТЗ у инженера
        /// </summary>
        public int CountTechnicalTask { get { return _countTechnicalTask; } }
        /// <summary>
        /// Кол-во ПЗ у инженера
        /// </summary>
        public int CountOrderPassport { get { return _countOrderPassport; } }
        /// <summary>
        /// Кол-во всех задач у инженера
        /// </summary>
        public int CountAllTask { get { return _countAllTask; } }
        /// <summary>
        /// Суммарное время ТЗ
        /// </summary>
        public int TotalTimeRanTechnicalTask { get { return _totalTimeRanTechnicalTask; } }
        /// <summary>
        /// Суммарное время ПЗ
        /// </summary>
        public int TotalTimeRanOrderPassport { get { return _totalTimeRanOrderPassport; } }
        /// <summary>
        /// Суммарное время всех задач у инженера
        /// </summary>
        public int TotalTimeRanAllTask { get { return _totalTimeRanAllTask; } }
        /// <summary>
        /// Средний возраст ТЗ у инженера
        /// </summary>
        public double AverageAgeTechnicalTask { get { return _averageAgeTechnicalTask; } }
        /// <summary>
        /// Средний возраст ПЗ у инженера
        /// </summary>
        public double AverageAgeOrderPassport { get { return _averageAgeOrderPassport; } }
        /// <summary>
        /// Средний возраст всех задач у инженера
        /// </summary>
        public double AverageAgeAllTask { get { return _averageAgeAllTask; } }

        public EmployeeLoading(List<string> rowTable)
        {
            _listTechnicalTasks = new List<Exercise>();
            _listOrderPassports = new List<Exercise>();
            _name = rowTable[0].Trim(' ');
            GetTaskLists(rowTable); // заполнение списков ТЗ и ПЗ
            _countTechnicalTask = _listTechnicalTasks.Count;
            _countOrderPassport = _listOrderPassports.Count;
            _countAllTask = _countTechnicalTask + _countOrderPassport;
            _totalTimeRanTechnicalTask = GetSumTimeRunTechnicalTask(_listTechnicalTasks);
            _totalTimeRanOrderPassport = GetSumTimeRunTechnicalTask(_listOrderPassports);
            _totalTimeRanAllTask = _totalTimeRanTechnicalTask + _totalTimeRanOrderPassport;
            _averageAgeTechnicalTask = GetAverageAgeTechnicalTask(_listTechnicalTasks);
            _averageAgeOrderPassport = GetAverageAgeTechnicalTask(_listOrderPassports);
            _averageAgeAllTask = GetAverageAgeAllTask();
        }


        /// <summary>
        /// Получение среднего возраста ТЗ и ТЗ
        /// </summary>
        /// <returns></returns>
        double GetAverageAgeAllTask()
        {
            if (_listTechnicalTasks.Count == 0 && _listOrderPassports.Count == 0) return 0;
            double sum = 0;
            foreach (var item in _listTechnicalTasks)
            {
                sum += item.Age;
            }
            foreach (var item in _listOrderPassports)
            {
                sum += item.Age;
            }
            return sum / (_listTechnicalTasks.Count + _listOrderPassports.Count);
        }

        /// <summary>
        /// Получение среднего возраста
        /// </summary>
        /// <param name="listTechnicalTasks"></param>
        /// <returns></returns>
        double GetAverageAgeTechnicalTask(List<Exercise> listTechnicalTasks)
        {
            var sum = 0;
            if (listTechnicalTasks.Count == 0) return 0;
            foreach (var item in listTechnicalTasks)
            {
                sum += item.Age;
            }
            return sum / listTechnicalTasks.Count;
        }

        /// <summary>
        /// Заполнение списков ТЗ и ПЗ
        /// </summary>
        /// <param name="rowTable"></param>
        void GetTaskLists(List<string> rowTable)
        {
            int number = 0;
            for (int i = 1; i < rowTable.Count; i++)
            {
                string[] data = rowTable[i].Split('|');
                if (_technicalTask.IsMatch(data[0]))
                {
                    _listTechnicalTasks.Add(new Exercise(++number, Convert.ToInt32(data[1]), Convert.ToInt32(data[2])));
                }
                if (_orderPassport.IsMatch(data[0]))
                {
                    _listOrderPassports.Add(new Exercise(++number, Convert.ToInt32(data[1]), Convert.ToInt32(data[2])));
                }
            }
        }

        /// <summary>
        /// Получение суммарного времени на выполнение
        /// </summary>
        /// <param name="ListTechnicalTasks"></param>
        /// <returns></returns>
        int GetSumTimeRunTechnicalTask(List<Exercise> ListTechnicalTasks)
        {
            int sum = 0;
            foreach (var item in ListTechnicalTasks)
            {
                sum += item.TimeRun;
            }
            return sum;
        }

    }
}
