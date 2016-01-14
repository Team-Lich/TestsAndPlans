:: Check WMIC is available
WMIC.EXE Alias /? >NUL 2>&1 || GOTO s_error

:: Use WMIC to retrieve date and time
FOR /F "skip=1 tokens=1-6" %%G IN ('WMIC Path Win32_LocalTime Get Day^,Hour^,Minute^,Month^,Second^,Year /Format:table') DO (
   IF "%%~L"=="" goto s_done
      Set _yyyy=%%L
      Set _mm=00%%J
      Set _dd=00%%G
      Set _hour=00%%H
      SET _minute=00%%I
      SET _second=00%%K
)
:s_done

:: Pad digits with leading zeros
      Set _mm=%_mm:~-2%
      Set _dd=%_dd:~-2%
      Set _hour=%_hour:~-2%
      Set _minute=%_minute:~-2%
      Set _second=%_second:~-2%

Set logtimestamp=%_yyyy%-%_mm%-%_dd%_%_hour%_%_minute%_%_second%
goto make_dump

:s_error
echo WMIC is not available, using default log filename
Set logtimestamp=_

:make_dump
set FILENAME=database_dump_%logtimestamp%.sql


set SUITENAME=%1
SET TESTSFILE=C:\Users\Decho\Desktop\TestPlan\TeamLichTestAutomation\TeamLichTestAutomation.Tests\bin\Debug\TeamLichTestAutomation.Tests.dll
SET RESULTFILE=C:\Users\Decho\Desktop\TestPlan\TeamLichTestAutomation\BatchFiles\%SUITENAME%TestSuite_%logtimestamp%.trx

del C:\Users\Decho\Desktop\TestPlan\TeamLichTestAutomation\BatchFiles\Results.trx
MSTest.exe /testcontainer:%TESTSFILE% /category:%1 /resultsfile:%RESULTFILE%
python ResultParser.py C:\Users\Decho\Desktop\TestPlan\TeamLichTestAutomation\BatchFiles\%SUITENAME%TestSuite_%logtimestamp% %logtimestamp%