using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les7
{
    public class WorkPlaceTable
    {
        List<List<string>> _rowTable;
        List<EmployeeLoading> _listEmployeeLoading; 
        int _countAllTechnicalTask = 0;
        int _countAllOrderPassport = 0;
        int _totalTimeRanTechnicalTaskAllEmployees = 0;
        int _totalTimeRanOrderPassportAllEmployees = 0;

        public List<EmployeeLoading> ListEmployeeLoading { get { return _listEmployeeLoading; } }
        /// <summary>
        /// Кол-во ТЗ у всех инженеров
        /// </summary>
        public int CountAllTechnicalTask { get { return _countAllTechnicalTask; } }
        /// <summary>
        /// Кол-во ПЗ у всех инженеров
        /// </summary>
        public int CountAllOrderPassport { get { return _countAllOrderPassport; } }
        /// <summary>
        /// Суммарное время ТЗ у всех инженеров
        /// </summary>
        public int TotalTimeRanTechnicalTaskAllEmployees { get { return _totalTimeRanTechnicalTaskAllEmployees; } }
        /// <summary>
        /// Суммарное время ПЗ у всех инженеров
        /// </summary>
        public int TotalTimeRanOrderPassportAllEmployees { get { return _totalTimeRanOrderPassportAllEmployees; } }
        public WorkPlaceTable(List<List<string>> rowsTable)
        {
            _rowTable = rowsTable;
            _listEmployeeLoading = new List<EmployeeLoading>();
            GetlistEmployeeLoading();
            _listEmployeeLoading.Sort((x, y) => x.Name.CompareTo(y.Name));
            GetCountAllTechnicalTask();
        }

        void GetlistEmployeeLoading()
        {
            foreach (var item in _rowTable)
            {
                _listEmployeeLoading.Add(new EmployeeLoading(item));
            }
        }

        void GetCountAllTechnicalTask()
        {
            foreach (var item in _listEmployeeLoading)
            {
                _countAllTechnicalTask += item.CountTechnicalTask;
                _countAllOrderPassport += item.CountOrderPassport;
                _totalTimeRanTechnicalTaskAllEmployees += item.TotalTimeRanTechnicalTask;
                _totalTimeRanOrderPassportAllEmployees += item.TotalTimeRanOrderPassport;
            }
        }
    }
}
