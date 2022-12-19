## Section 3: Controlling Database Creation and Schema Changes
* Adding Your First Migration
** add Microsoft.EntityFrameworkCore.Tools 3.1.31 to ConsoleApp (.net core 3.1)
** Add-Migration init => SamuraiApp.Data
* Inspecting Your First Migration
* Using Migrations to Script or Directly Create the Database
** Script-Migration => generate script.sql
** Update-Database -Verbose
* Reverse Engineering an Existing Database
** scaffold-dbcontext -provider Microsoft.EntityFrameworkCore.SqlServer -connection "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=SamuraiAppData31"
## Section 4: Mapping Many-to-Many and One-to-One Relationships
* Setting up the many-to-many relationship
* Adding a One-to-One relationship
* Visualizing How EF Core Sees Your Model
* Controlling Table Names with Mappings
* Running Migrations for the Model Changes
** add-migration newrelationships
** Update-Database
## Section 5: Interacting with Your EF Core Data Model
* Adding Logging to EF Core's Workload
* Persisting Data in Disconnected Scenarios
* Enhancing Performance in Disconnected Apps with No-Tracking Settings
## Section 6: Interacting with Related Data
## Section 7: Working with Views and Stored Procedures and Raw SQL
## Using EF Core with ASP.NET Core
* Running the Controller to See the Output
* Exploring and Debugging Insert, Update & Delete Controller Methods
## Section 8: Testing with the InMemory Provider Instead of a Real Database
* Creating Your First Test and Using it Against the Database