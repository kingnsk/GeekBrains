using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_Strategy_1
{
    public sealed class ScannerContext
    {
        private readonly IScannerDevice _device;
        private IScanOutputStrategy _currentStrategy;

        public ScannerContext(IScannerDevice device)
        {
            _device = device;
        }

        public void SetupOutputScanStrategy(IScanOutputStrategy strategy)
        {
            _currentStrategy = strategy;
        }

        public void Execute(string outputFilename = "")
        {
            if(_device is null)
            {
                throw new ArgumentNullException("Device can not be null");
            }

            if(_currentStrategy is null)
            {
                throw new ArgumentNullException("Current scan strategy can not be null");
            }

            if (string.IsNullOrWhiteSpace(outputFilename))
            {
                outputFilename = Guid.NewGuid().ToString();
            }

            _currentStrategy.ScanAndSave(_device, outputFilename);
        }
    }
}
