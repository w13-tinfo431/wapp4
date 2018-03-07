using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace LibrarySystem.DAL
{
    public class LibraryConfiguration : DbConfiguration
    {
        public LibraryConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}