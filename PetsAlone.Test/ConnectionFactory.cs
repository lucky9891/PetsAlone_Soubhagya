using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PetsAlone.Core;
using System;

namespace PetsAlone.Test
{
    public class ConnectionFactory : IDisposable
    {
        private bool disposedValue = false;

        public PetsDbContext CreateContextForSQLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<PetsDbContext>().UseSqlite(connection).Options;

            var context = new PetsDbContext(option);

            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
