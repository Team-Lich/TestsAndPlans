1.Required:
	Path to MSTest.exe in your enviroment or user paths.
	Python 3.* installed with path to it in your enviroment or user paths.
	Create subfolder Results in folder TeamLichTestAutomation 



RunTestPriority.bat can run all test with priority smaller than the argument.
Example:
RunTestPriority.bat 1
This will run all tests with priority 1

RunTestPriority.bat 3
This will run all tests with priority 3, 2 and 1

RunTestPriority.bat 4
This will run all

RunTestSuite.bat can run all test from a test suite.
Example:
RunTestSuite.bat Login
This will run all tests with attribute [TestCategory("Login")]

RunTestSuite.bat Login
This will run all tests with attribute [TestCategory("AdministrationLabels")]

Results are saved to Results folder. Excel and raw files are created.