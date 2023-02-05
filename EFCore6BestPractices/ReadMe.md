## Section 2: Structuring Your Project for Cleanliness and Testability
* The Domain Project Contains Entities
* The nfrastructure Project Configures SQL
* The API Project Adds Services to the Container
* The Shared Kernel Inverts Dependencies
* The In-Memory Provider Supports Unit Tests
## Section 3: Designing Security Into Your Application and Process
* Design-Time DbContext Factories Control Deployment Credentials
* * [System.Environment]::SetEnvironmentVariable('GLOBOTICKET_ADMIN_CONNECTION_STRING','Data Source=(localdb)\mssqllocaldb; Initial Catalog=Globoticket;Trusted_Connection=True;')
* * dotnet ef migrations add AddedVenueActAndShow -p .\GloboTicket.Infrastructure -s .\GloboTicket.API
* * dotnet ef database update -p .\GloboTicket.Infrastructure -s .\GloboTicket.API