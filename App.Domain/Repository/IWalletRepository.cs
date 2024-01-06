using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Domain.Interfaces.Services;

namespace App.Domain.Repository
{
    public interface IWalletRepository : IRepository<WalletEntity>
    {
        Task<IEnumerable<WalletEntity>> GetByUserId(int userId);
    }
}