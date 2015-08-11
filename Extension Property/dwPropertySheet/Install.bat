REM RUN FROM VS.NET PROMPT
@PAUSE
REM UNREGISTER COM OBJECTS, THEN REGISTER
REM FOR INSTALL IN GLOBAL ASSEMBLY, SIGN 
regasm /u bin\debug\dwPropertySheet.dll
REM gacutil /u dwPropertySheet.dll
regasm bin\debug\dwPropertySheet.dll
REM gacutil /i bin\debug\dwPropertySheet.dll
REM REGISTER AS SHELL OBJECTS IN REGISTRY
REM FOR Active Directory registration, see MS-AD documentation!
regApproved.reg
regBindToEXE.reg
REM COPY DWWRAPPER TO SYSTEM
COPY dwWrapper.dll %WINDIR%\SYSTEM32


