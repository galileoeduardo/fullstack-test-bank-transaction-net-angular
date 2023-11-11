using Api.Domain.Entities;
using Bank.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data.Repositories
{
    public class BaseRepository<Table> : IRepository<Table> where Table : BaseEntity
    {
        protected readonly BankDbContext _context;
        private DbSet<Table> _dataset;
        public BaseRepository(BankDbContext context)
        {
            _context = context;
            _dataset = _context.Set<Table>();
        }

        public async Task<IEnumerable<Table>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (DbUpdateException e)
            {

                if (e.InnerException is not null)
                {
                    e.Data.Add("Source", e.InnerException.Source);
                    e.Data.Add("Message", e.InnerException.Message);
                }
                throw;
            }
        }

        public async Task<Table?> SelectAsync(int id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                    return null;

                return result;
            }
            catch (DbUpdateException e)
            {

                if (e.InnerException is not null)
                {
                    e.Data.Add("Source", e.InnerException.Source);
                    e.Data.Add("Message", e.InnerException.Message);
                }
                throw;
            }
        }

        public async Task<Table> InsertAsync(Table entity)
        {
            try
            {
                _dataset.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {

                if (e.InnerException is not null)
                {
                    e.Data.Add("Source", e.InnerException.Source);
                    e.Data.Add("Message", e.InnerException.Message);
                }
                throw;
            }

            return entity;
        }

        public async Task<Table?> UpdateAsync(int id, Table entity)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null) return null;

                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException e)
            {

                if (e.InnerException is not null)
                {
                    e.Data.Add("Source", e.InnerException.Source);
                    e.Data.Add("Message", e.InnerException.Message);
                }
                throw;
            }

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null) return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {

                if (e.InnerException is not null)
                {
                    e.Data.Add("Source", e.InnerException.Source);
                    e.Data.Add("Message", e.InnerException.Message);
                }
                throw;
            }

            return true;

        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }
    }
}