@echo off

cls
echo navigation to " %USERPROFILE%\AppData\Local\Temp "

C:
cd \
cd %USERPROFILE%
cd AppData
cd Local
cd Temp

echo ====== Deleting old *.log files ====== 
del *.log

echo ====== Deleting old *.tmp files ====== 
del *.tmp

echo ====== Deleting old *.dat files ====== 
del *.dat
del *.diagsession

pause

