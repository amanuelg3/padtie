Dim objShell
set objShell = wscript.createObject("wscript.shell") 

objShell.Run "msiexec /package SlimDXRuntime.msi /passive", 1, TRUE
objShell.Run "setup.exe", 1, TRUE