using System.Collections.Generic;
using System.Threading.Tasks;
using slimWallet.Contracts;
using SQLite;

namespace slimWallet.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database()
        {
            _database = new SQLiteAsyncConnection(FileHelper.DatabasePath);
            _database.CreateTableAsync<Card>().Wait();
        }

        public async Task<List<Card>> GetItemsAsync() => await _database.Table<Card>().ToListAsync();

        public async Task<Card> GetItemAsync(int id) => await _database.Table<Card>().Where(i => i.ID == id).FirstOrDefaultAsync();

        public async Task<int> SaveItemAsync(Card item) => item.ID != 0 ? await _database.UpdateAsync(item) : await _database.InsertAsync(item);

        public async Task<int> DeleteItemAsync(Card item) => item.ID != 0 ? await _database.DeleteAsync(item) : 0;
    }
}
