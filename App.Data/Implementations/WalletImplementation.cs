using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data.Context;
using App.Data.Repository;
using App.Domain.Entities;
using App.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Implementations
{
    public class WalletImplementation : BaseRepository<WalletEntity>, IWalletRepository
    {
        private DbSet<WalletEntity> _dataSet;

        public WalletImplementation(StockAnalysisContext context) : base(context)
        {
            _dataSet = _context.Set<WalletEntity>();
        }
        
        public async Task<IEnumerable<WalletEntity>> GetByUserId(int userId)
        {
            return await _dataSet.Where(f => f.UserId.Equals(userId)).ToListAsync();
        }
    }
}