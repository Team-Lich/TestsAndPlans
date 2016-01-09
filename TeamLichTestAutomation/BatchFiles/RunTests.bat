SET TESTSFILE=C:\Users\Decho\Desktop\TestsAndPlans\TeamLichTestAutomation\TeamLichTestAutomation.Tests\bin\Debug\TeamLichTestAutomation.Tests.dll
SET RESULTFILE=C:\Users\Decho\Desktop\Results.trx

MSTest.exe /testcontainer:%TESTSFILE% /category:"Login" /resultsfile:%RESULTFILE% > testResult.txt