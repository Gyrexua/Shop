using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Mappers
{
    public static class WalletMappers
    {
        public static Dtos.Wallet.WalletDto ToWalletDto(this Models.Wallet wallet)
        {
            if (wallet == null) return null;

            return new Dtos.Wallet.WalletDto
            {

                Balance = wallet.Balance,
            };
        }
        public static Models.Wallet ToWalletFromUpdateDto (this Dtos.Wallet.DepositDto DepositDto)
        {
            if (DepositDto == null) return null;

            return new Models.Wallet
            {
                UserId = DepositDto.UserId
            };
        }
    }
}