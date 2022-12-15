using IndianStateCensusAnalyzer;
namespace IndianStateCensusTest
{
    public class Tests
    {
        public static string stateCensusCSVFilePath = @"D:\GitRepository\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\Files\StateCensusData.csv";
        [Test]
        public void GivenStateCensusData_WhenAnalyzed_ShouldReturnNoOfRecordsMatches ()
        {
            StateCensusAnalyzer analyzer = new StateCensusAnalyzer();
            CSVStateCensus stateCensus = new CSVStateCensus();
            Assert.AreEqual(stateCensus.ReadStateCensusData(stateCensusCSVFilePath),analyzer.ReadStateCensusData(stateCensusCSVFilePath));
        }
    }
}