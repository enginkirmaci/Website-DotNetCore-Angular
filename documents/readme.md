Run under website projects
--------------------------
dotnet ef dbcontext scaffold --output-dir ../../Website.Models/ "Data Source=localhost;Initial Catalog=enginkirmaci;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer


Run under Package Manager Console as Layers/Website.Core.Models
--------------------------
Add-Migration initial -Context WebsiteDbContext

Angular Commands
--------------------------
ng generate component [name] (generates a component)
ng generate module [name]
ng generate component [name] --skip-import