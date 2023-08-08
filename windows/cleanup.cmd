@echo off

cls
echo navigation to %USERPROFILE%\AppData\Local\Temp
cd %USERPROFILE%\AppData\Local\Temp

del *.log
del *.tmp
del *.dat
del *.diagsession

pause

