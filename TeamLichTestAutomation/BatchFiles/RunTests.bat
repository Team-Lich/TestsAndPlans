SET TESTSFILE=C:\Users\Decho\Desktop\TestsAndPlans\TeamLichTestAutomation\TeamLichTestAutomation.Tests\bin\Debug\TeamLichTestAutomation.Tests.dll
SET RESULTFILE=C:\Users\Decho\Desktop\TestsAndPlans\TeamLichTestAutomation\BatchFiles\Results.trx

del C:\Users\Decho\Desktop\TestsAndPlans\TeamLichTestAutomation\BatchFiles\Results.trx
MSTest.exe /testcontainer:%TESTSFILE% /category:"AdministrationUniversities" /resultsfile:%RESULTFILE%
python ResultParser.py