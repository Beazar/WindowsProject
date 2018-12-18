GROEPSLEDEN:
BEAZAR Sander
COTTRELL Billy
VAN NOPPEN Anthony

Instructies:
Bij Solution properties, stel WindowsProjectService in als start up project, 
Verwijder voorgaande migrations uit de map "Migrations"
In de Package Manager Console:
1) Enable-Migrations (indien nodig)
2) Add-Migration Init 
3) Update-Database

Bij Solution properties, kies voor multiple startup projects,
WindowsProject -> Start
WindowsProjectService -> Start Without Debugging

2e upload:
bugfix: account bekijken na registratie had een probleem door initialisatie van een list die ontbrak
github:
https://github.com/Beazar/WindowsProject
commits van anthony en Sander grotendeels samen gebeurd
