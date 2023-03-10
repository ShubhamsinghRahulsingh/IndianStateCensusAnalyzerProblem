using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyzer
{
    public class StateCensusAndCodeException:Exception
    {
        public enum ExceptionType
        {
            FILE_INCORRECT,TYPE_INCORRECT,DELIMETER_INCORRECT, HEADER_INCORRECT
        }
        public ExceptionType Type;
        public StateCensusAndCodeException(ExceptionType type, string message) : base(message)
        {
            Type = type;
        }   
    }
}
