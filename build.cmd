@echo off

cd /d "%~dp0"

if not exist bin mkdir bin

"%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /nologo /target:exe /out:bin\CourseBlog.exe /r:System.Xml.dll Program.cs Menu.cs BlogData.cs ViewArticles.cs AddArticle.cs Comments.cs

if errorlevel 1 exit /b 1

echo Build OK

