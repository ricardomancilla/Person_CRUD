# Person_CRUD

First of all, the NuGet Packages need to be restored, this process might take some minutes.

Next, the migration needs to be run, so to accomplish this follow the steps below:

	* In the Visual Studio Solution Explorer set the Data project as StartUp Project
	* In the NuGet Package Manager Console, select Data as the default project, then type and run the code Update-Database

This code creates the database and inserts a first record in the PERSON table.

In the Visual Studio Solution Explorer set the UI project as StartUp Project, now the solution is ready to be executed.
