using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyzer
{
    public class StateCensusException:Exception
    {
        public enum ExceptionType
        {
            FILE_INCORRECT,TYPE_INCORRECT
        }
        public ExceptionType Type;
        public StateCensusException(ExceptionType type, string message) : base(message)
        {
            Type = type;
        }   
    }
}
