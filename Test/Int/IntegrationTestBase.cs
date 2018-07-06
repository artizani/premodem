using System;
using EfData;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;


namespace Int
{
    public class IntegrationTestBase
    {
        protected static PremodemContext GivenPremodemContext(bool beginTransaction = true)
        {

            var context = new PremodemContext(new DbContextOptionsBuilder<PremodemContext>()
                .UseSqlServer(Premodem.ConnectionString).Options);
                
            if (beginTransaction)
                context.Database.BeginTransaction();
            return context;
        }

        private static SqlConnectionStringBuilder Premodem =>
            new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                InitialCatalog = "Premodem",
                IntegratedSecurity = true
            };
    }
    
}