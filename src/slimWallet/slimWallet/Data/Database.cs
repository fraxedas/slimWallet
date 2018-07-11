using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using slimWallet.Contracts;
using SQLite;

namespace slimWallet.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database()
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "slimWallet.db3");
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<Card>().Wait();
        }

        public async Task<List<Card>> GetItemsAsync()
        {
            return await database.Table<Card>().ToListAsync();
        }

        public async Task<Card> GetItemAsync(int id)
        {
            return await database.Table<Card>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Card item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Card item)
        {
            return database.DeleteAsync(item);
        }
    }
}
