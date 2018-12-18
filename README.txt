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
