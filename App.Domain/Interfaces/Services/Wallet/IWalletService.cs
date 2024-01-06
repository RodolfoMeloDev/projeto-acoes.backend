using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Dtos.Wallet;

namespace App.Domain.Interfaces.Services.Wallet
{
    public interface IWalletService
    {
        Task<WalletDto> GetById(int id);
        Task<IEnumerable<WalletDto>> GetByUser(int userId);
        Task<WalletDtoCreateResult> Insert(WalletDtoCreate wallet);
        Task<WalletDtoUpdateResult> Update(WalletDtoUpdate wallet);
        Task<bool> Delete(int id);
    }
}