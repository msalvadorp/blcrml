using System;
using System.Collections.Generic;
using System.Text;

namespace Belcorp.ML.Entity.Request
{
    public class CreateTrainingJobReq
    {
        public string BankId { get; set; }
        public string InputDataConfig { get; set; }

    }
}
