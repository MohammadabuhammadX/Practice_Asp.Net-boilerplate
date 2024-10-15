using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Practice.EntityFrameworkCore
{
    public static class PracticeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PracticeDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PracticeDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
