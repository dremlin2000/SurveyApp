The following commands should be executed in command prompt (cmd.exe) in Survey.Repository folder

How to add a new migration:
	dotnet ef migrations add InitialCreate --startup-project ..\SurveyApp.Web

How to apply a new migration into database:
	dotnet ef database update --startup-project ..\SurveyApp.Web