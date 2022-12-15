using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyzer
{
    public class StateCensusAnalyzer
    {
        public int ReadStateCensusData(string filepath)
        {
            if (!File.Exists(filepath))
                throw new StateCensusException(StateCensusException.ExceptionType.FILE_INCORRECT, "Incorrect File Path");
            if (!filepath.EndsWith(".csv"))
                throw new StateCensusException(StateCensusException.ExceptionType.TYPE_INCORRECT, "Incorrect File Type");
            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<StateCensusDAO>().ToList();
                foreach (var data in records)
                {
                    Console.WriteLine(data);
                }
                return records.Count() - 1;
            }
        }
    }
}
