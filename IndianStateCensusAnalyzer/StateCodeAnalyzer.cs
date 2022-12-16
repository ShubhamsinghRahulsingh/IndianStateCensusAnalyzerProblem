using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyzer
{
    public class StateCodeAnalyzer
    {
        public int ReadStateCodeData(string filePath)
        {
            if (!File.Exists(filePath))
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.FILE_INCORRECT, "Incorrect File Path");
            if (!filePath.EndsWith(".csv"))
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.TYPE_INCORRECT, "Incorrect File Type");
            var read = File.ReadAllLines(filePath);
            string header = read[0];
            if (header.Contains("/"))
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.DELIMETER_INCORRECT, "Delimeter is Incorrect");
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<StateCodeDAO>().ToList();
                foreach (var data in records)
                {
                    Console.WriteLine(data);
                }
                return records.Count() - 1;
            }
        }
    }
}
