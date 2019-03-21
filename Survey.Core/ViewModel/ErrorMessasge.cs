using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Core.ViewModel
{
    public class ErrorMessage
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
    }
}
