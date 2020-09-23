@echo off
if not exist "bin\server\Locadora.Tools.exe" call build DryBuild "/p:Configuration=Debug"
util\Simple.Launcher bin\server Locadora.Tools.exe
pause