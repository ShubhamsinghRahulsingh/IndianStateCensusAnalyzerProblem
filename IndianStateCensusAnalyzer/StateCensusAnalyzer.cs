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
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.FILE_INCORRECT, "Incorrect File Path");
            if (!filepath.EndsWith(".csv"))
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.TYPE_INCORRECT, "Incorrect File Type");
            var read = File.ReadAllLines(filepath);
            string header = read[0];
            if (header.Contains("/"))
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.DELIMETER_INCORRECT,"Delimeter is Incorrect");
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
        public bool ReadStateCensusData(string filepath,string actualHeader)
        {
            var read = File.ReadAllLines(filepath);
            string header = read[0];
            if (header.Equals(actualHeader))
                return true;
            else
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.HEADER_INCORRECT, "Header is Incorrect");
        }
    }
}
