using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Bank.Data.Repositories
{
    public interface IRepository<Table> where Table : BaseEntity
    {
        Task<IEnumerable<Table>> SelectAsync();
        Task<Table?> SelectAsync(int id);
        Task<Table> InsertAsync(Table entity);
        Task<Table?> UpdateAsync(int id,Table entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistAsync(int id);
    }
}