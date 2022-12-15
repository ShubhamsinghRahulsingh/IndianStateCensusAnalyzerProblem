using IndianStateCensusAnalyzer;
namespace IndianStateCensusTest
{
    public class Tests
    {
        public static string stateCensusCSVFilePath = @"D:\GitRepository\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\Files\StateCensusData.csv";
        public static string stateCensusIncorrectCSVFilePath = @"D:\GitRepository\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\Files\StateCensus.csv";
        public static string stateCensusIncorrectTypeCSVFilePath = @"D:\GitRepository\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\Files\StateCensusData.txt";
        [Test]
        //TC1.1
        public void GivenStateCensusData_WhenAnalyzed_ShouldReturnNoOfRecordsMatches()
        {
            StateCensusAnalyzer analyzer = new StateCensusAnalyzer();
            CSVStateCensus stateCensus = new CSVStateCensus();
            Assert.AreEqual(stateCensus.ReadStateCensusData(stateCensusCSVFilePath),analyzer.ReadStateCensusData(stateCensusCSVFilePath));
        }
        [Test]
        //TC1.2
        public void GivenStateCensusDataFileIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            StateCensusAnalyzer analyzer = new StateCensusAnalyzer();
            try
            {
                int records=analyzer.ReadStateCensusData(stateCensusIncorrectCSVFilePath);
            }
            catch(StateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect File Path");
            }
        }
        [Test]
        //TC1.3
        public void GivenStateCensusDataFileTypeIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            StateCensusAnalyzer analyzer = new StateCensusAnalyzer();
            try
            {
                int records = analyzer.ReadStateCensusData(stateCensusIncorrectTypeCSVFilePath);
            }
            catch (StateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect File Type");
            }
        }
    }
}