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