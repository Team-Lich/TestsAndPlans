:: Check WMIC is available
@ECHO OFF
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

Set logtimestamp=%_yyyy%-%_mm%-%_dd%_%_hour%h%_minute%m%_second%s
goto make_dump

:s_error
echo WMIC is not available, using default log filename
Set logtimestamp=_

:make_dump
SET FILENAME=database_dump_%logtimestamp%.sql

SET SUITENAME=%1
SET "LOCALPATH=%~dp0"
SET SEPARATOR=-----------------------------------------------------------------------------------------------------

ECHO Starting Tets run of %SUITENAME% suite

::SET TESTSFILE=C:\Users\Decho\Desktop\TestPlan\TeamLichTestAutomation\TeamLichTestAutomation.Tests\bin\Debug\TeamLichTestAutomation.Tests.dll
SET TESTSFILE=%LOCALPATH%TeamLichTestAutomation.Tests\bin\Debug\TeamLichTestAutomation.Tests.dll
SET RESULTFILE=%LOCALPATH%Results\%logtimestamp%_%SUITENAME%TestSuite.trx

ECHO %SEPARATOR%
ECHO Running tests in assembly - %TESTSFILE%
ECHO %SEPARATOR%
ECHO Find raw results in - %RESULTFILE%
ECHO %SEPARATOR%
ECHO Executing tests...
ECHO %SEPARATOR%

@ECHO ON
MSTest.exe /testcontainer:%TESTSFILE% /category:%1 /resultsfile:%RESULTFILE%
python ResultParser.py %~dp0Results\%logtimestamp%_%SUITENAME%TestSuite %logtimestamp%