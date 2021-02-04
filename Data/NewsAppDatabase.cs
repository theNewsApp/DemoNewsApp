using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNewsApp
{
    public class NewsAppDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public NewsAppDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(User).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(User)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<User>> GetUsersAsync()
        {
            return Database.QueryAsync<User>("SELECT * FROM [User] ORDER BY [Name] ASC");
        }



        public Task<int> SaveUserAsync(User user)
        {
                return Database.InsertAsync(user);
            
        }

       
    }
}
