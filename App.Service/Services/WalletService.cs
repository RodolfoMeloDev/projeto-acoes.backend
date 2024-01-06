using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using App.Domain.Dtos.Wallet;
using App.Domain.Entities;
using App.Domain.Interfaces.Services.Wallet;
using App.Domain.Models;
using App.Domain.Repository;
using App.Service.Services.Exceptions;
using AutoMapper;

namespace App.Service.Services
{
    public class WalletService : IWalletService
    {
        private IWalletRepository _repository;
        private readonly IMapper _mapper;

        public WalletService(IWalletRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<WalletDto>> GetByUser(int userId)
        {
            return _mapper.Map<IEnumerable<WalletDto>>(await _repository.GetByUserId(userId));
        }

        public async Task<WalletDtoCreateResult> Insert(WalletDtoCreate wallet)
        {
            var allWallet = await _repository.GetByUserId(wallet.UserId);

            if (allWallet.Any(f => f.Default == true) && wallet.Default)
                throw new WalletException("Já existe uma carteira como principal");

            if (!allWallet.Any())
                wallet.Default = true;

            var model = _mapper.Map<WalletModel>(wallet);
            var entity = _mapper.Map<WalletEntity>(model);
            return _mapper.Map<WalletDtoCreateResult>(await _repository.InsertAsync(entity));
        }

        public async Task<WalletDtoUpdateResult> Update(WalletDtoUpdate wallet)
        {
            var oldEntity = await _repository.SelectAsync(wallet.Id);

            if (wallet.Default == false)
                throw new WalletException($"Não é possível desmarcar a carteira como principal!");

            if (oldEntity == null) 
                throw new WalletException($"O Id: {wallet.Id} não foi encontrado");

            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                        new TransactionOptions
                                                        {
                                                            IsolationLevel = IsolationLevel.ReadCommitted
                                                        },
                                                        TransactionScopeAsyncFlowOption.Enabled
                                                       ))
            {
                if (oldEntity.Default != wallet.Default)
                {
                    var allWallet = await _repository.GetByUserId(oldEntity.UserId);
                    var mainWallet = allWallet.FirstOrDefault(f => f.Default == true);

                    if (mainWallet == null)
                        throw new WalletException("Não foi possível encontrar a carteira principal");

                    mainWallet.Default = false;
                    _ = await _repository.UpdateAsync(mainWallet);
                }

                oldEntity.Description = wallet.Description;
                oldEntity.Default = wallet.Default == null ? oldEntity.Default : (bool)wallet.Default;

                var model = _mapper.Map<WalletModel>(oldEntity);
                var entity = _mapper.Map<WalletEntity>(model);
                var result = await _repository.UpdateAsync(entity);

                scope.Complete();

                return _mapper.Map<WalletDtoUpdateResult>(result);
            }
        }

        public async Task<WalletDto> GetById(int id)
        {
            return _mapper.Map<WalletDto>(await _repository.SelectAsync(id));
        }
    }
}