using ScannerDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ScanStrategy
{
    public sealed class ScannerContext : IScannerContext
    {
        private readonly IScannerDevice _device;
        private IScanOutputStrategy _currentStrategy;
        private readonly ILogger _logger;

        public ScannerContext(IScannerDevice device, ILogger logger = null)
        {
            _logger = logger;
            _logger?.Info("Создан контект устройства");
            _device = device;
        }

        public void SetupOutputScanStrategy(IScanOutputStrategy strategy)
        {
            _currentStrategy = strategy;
            _logger?.Info($"Задана стретегия выполнения {_currentStrategy.GetType().Name}");
        }

        public void Execute(string outputFileName = "")
        {
            if (_device is null)
            {
                _logger?.Warn("Девайс не задан");
                return;
            }
            if (_currentStrategy is null)
            {
                _logger?.Warn("Стратегия не задана");
                return;
            }
            if (string.IsNullOrWhiteSpace(outputFileName))
            {
                _logger?.Info("Имя файла было сгенерировано");
                outputFileName = Guid.NewGuid().ToString();
            }
            _logger?.Info($"Запуск метода ScanAndSave с использованием стратегии: {_currentStrategy.GetType().Name}");
            _currentStrategy.ScanAndSave(_device, outputFileName, _logger);
        }
    }

    public interface IScannerContext
    {
        void SetupOutputScanStrategy(IScanOutputStrategy strategy);
        void Execute(string outputFileName);
    }
}
