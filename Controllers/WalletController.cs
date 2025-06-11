using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Wallet;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("wallet")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletRepository  _walletRepo;
        private readonly ApplicationDBContext _context;

        public WalletController(IWalletRepository walletRepo, ApplicationDBContext context)
        {
            _walletRepo = walletRepo;
            _context = context;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetWallet([FromRoute] string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var wallets = await _walletRepo.GetWalletAsync(userId);
            if (wallets == null)
            {
                return NotFound("Wallet not found.");
            }
            return Ok(wallets);
        }
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositDto depositDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var wallet = await _walletRepo.GetWalletAsync(depositDto.UserId);
            if (wallet == null)
            {
                return NotFound("Wallet not found.");
            }

            wallet.Balance += depositDto.Amount;
            await _walletRepo.UpdateAsync(wallet);

            return Ok(new { Message = "Deposit successful", NewBalance = wallet.Balance });
        }
    
        [HttpPost("buy/{id:int}")]
        public async Task<IActionResult> Buy([FromRoute] int id, [FromBody] BuyDto buyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var alreadyBought = await _context.UserLibraries
            .AnyAsync(user => user.UserId == buyDto.UserId && user.GameId == id);
            if (alreadyBought)
            {
                return BadRequest("Гра вже куплена.");
            } 
            var wallet = await _walletRepo.GetWalletAsync(buyDto.UserId);
            if (wallet == null)
            {
                return NotFound("Wallet not found.");
            }

            if (buyDto.Amount > wallet.Balance)
            {
                return BadRequest("Insufficient balance.");
            }

            wallet.Balance -= buyDto.Amount;
            await _walletRepo.UpdateAsync(wallet);

            await _walletRepo.AddGameToUserLibraryAsync(buyDto.UserId, id);
            

            return Ok(new { Message = "Purchase successful", NewBalance = wallet.Balance });
        }
    }
}