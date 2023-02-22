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
* Roles Define Application Privilegs
* * dotnet ef migrations add CreateAppRole -p .\GloboTicket.Infrastructure -s .\GloboTicket.API
* * dotnet ef database update -p .\GloboTicket.Infrastructure -s .\GloboTicket.API
* **  create login app with password='viGlob@l3.1415926'

* **  use globoticket
* **  create user app for login app
* **  alter role globoticket_app add member app
* Shift Left
* User Secrets Store Developer Credentials
## Section 4: Automating Schema Evolution with Migration Bundles and Docker
* Migration Bundles Encapsulate Schema Evolution
* * -p: migrations project; -s: startup project
* * dotnet ef migrations bundle -p .\GloboTicket.Infrastructure -s .\GloboTicket.API
* docker build -t globoticket/integration-test:latest -f IntegrationTest/IntegrationTest.Dockerfile .
* docker run -it --rm --entrypoint /bin/bash globoticket/integration-test:latest
*$ dotnet ef migrations bundle -p ./GloboTicket.Infrastructure -s ./GloboTicket.API --configuration  Release --no-build
*$ dotnet tool install --global dotnet-ef
*$ export PATH="$PATH:/root/.dotnet/tools"
*$ export GLOBOTICKET_ADMIN_CONNECTION_STRING="sERVER=tcp:mssql;Database=GloboTicket;User=sa;Password=notused;TrustServerCertificate=True;"
** docker compose -f IntegrationTest\docker-compose.yaml up --exit-code-from test --renew-anon-volumes

## Section 5: Building Safer Code by Controlling Nullability
* Declare Optional Columns as Nullable Types
* Declare Constructors for Navigation Properties
* Declare Non-Nullable DbSets
## Section 6: Identifying and Resolving Performance Issues
* dotnet ef dbcontext optimize -p ./GloboTicket.Infrastructure -s ./GloboTicket.API
* Compile Models for Faster Startup
## Section 7: Delivering Large Result Sets with Asynchronous Streams
