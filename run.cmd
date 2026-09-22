@echo off

cd /d "%~dp0"

if not exist bin\CourseBlog.exe call build.cmd

if errorlevel 1 exit /b 1

bin\CourseBlog.exe

pause

