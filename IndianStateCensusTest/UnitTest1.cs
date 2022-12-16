using IndianStateCensusAnalyzer;
namespace IndianStateCensusTest
{
    public class Tests
    {
        public static string stateCensusCSVFilePath = @"D:\GitRepository\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\Files\StateCensusData.csv";
        public static string stateCensusIncorrectCSVFilePath = @"D:\GitRepository\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\Files\StateCensus.csv";
        public static string stateCensusIncorrectTypeCSVFilePath = @"D:\GitRepository\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\Files\StateCensusData.txt";
        public static string stateCensusIncorrectDelimeterFilePath = @"D:\GitRepository\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\Files\StateCensusDataDelimeter.csv";
        public static string stateCodeCSVFilePath = @"D:\GitRepository\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\Files\StateCodeData.csv";
        public static string stateCodeIncorrectCSVFilePath = @"D:\GitRepository\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\Files\StateCode.csv";
        public static string stateCodeIncorrectTypeCSVFilePath = @"D:\GitRepository\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\Files\StateCodeData.txt";
        public static string stateCodeIncorrectDelimeterFilePath = @"D:\GitRepository\IndianStateCensusAnalyzerProblem\IndianStateCensusAnalyzer\Files\StateCodeDataDelimeter.csv";
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
            catch(StateCensusAndCodeException ex)
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
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect File Type");
            }
        }
        [Test]
        //TC1.4
        public void GivenStateCensusDataFileDelimeterIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            StateCensusAnalyzer analyzer = new StateCensusAnalyzer();
            try
            {
                int records = analyzer.ReadStateCensusData(stateCensusIncorrectDelimeterFilePath);
            }
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Delimeter is Incorrect");
            }
        }
        //TC1.5
        [Test]
        public void GivenStateCensusDataFileIncorrectHeader_WhenAnalyzed_ShouldReturnException()
        {
            StateCensusAnalyzer analyzer = new StateCensusAnalyzer();
            try
            {
                bool records = analyzer.ReadStateCensusData(stateCensusIncorrectDelimeterFilePath, "State,Population,AreaInSqKm,DensityPerSqKm");
                Assert.IsTrue(records);
            }
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Header is Incorrect");
            }
        }
        [Test]
        //TC2.1
        public void GivenStateCodeData_WhenAnalyzed_ShouldReturnNoOfRecordsMatches()
        {
            StateCodeAnalyzer codeAnalyzer = new StateCodeAnalyzer();
            CSVStateCode stateCode = new CSVStateCode();
            Assert.AreEqual(stateCode.ReadStateCodeData(stateCodeCSVFilePath), codeAnalyzer.ReadStateCodeData(stateCodeCSVFilePath));
        }
        [Test]
        //TC2.2
        public void GivenStateCodeDataFileIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            StateCodeAnalyzer codeAnalyzer = new StateCodeAnalyzer();
            try
            {
                int records = codeAnalyzer.ReadStateCodeData(stateCodeIncorrectCSVFilePath);
            }
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect File Path");
            }
        }
        [Test]
        //TC2.3
        public void GivenStateCodeDataFileTypeIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            StateCodeAnalyzer codeAnalyzer = new StateCodeAnalyzer();
            try
            {
                int records = codeAnalyzer.ReadStateCodeData(stateCodeIncorrectTypeCSVFilePath);
            }
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect File Type");
            }
        }
        [Test]
        //TC2.4
        public void GivenStateCodeDataFileDelimeterIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            StateCodeAnalyzer codeAnalyzer = new StateCodeAnalyzer();
            try
            {
                int records = codeAnalyzer.ReadStateCodeData(stateCodeIncorrectDelimeterFilePath);
            }
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Delimeter is Incorrect");
            }
        }
    }
}