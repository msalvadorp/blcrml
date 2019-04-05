using System;
using System.Collections.Generic;
using System.Text;

namespace Belcorp.ML.Entity.Request
{
    public class PredictionDataReq
    {
        public string BankId { get; set; }
        public string InputDataConfig { get; set; }
        public string OutputDataConfig { get; set; }
      
    }
}
