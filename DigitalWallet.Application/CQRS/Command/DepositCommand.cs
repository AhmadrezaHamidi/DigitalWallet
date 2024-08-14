using DigitalWallet.Core.Entities;
using DigitalWallet.Infrastructure;
using DIgitalWallet.Commmon.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWallet.Application.CQRS.Command
{

    /// <summary>
    /// Command va Command Handler behtare joda beshe 
    /// </summary>

    //وقتی یه مند به async m awaite چیائده سازی میشه باید تا لانتها async باشه 

    public record DepositCommand(int walletId, decimal amount) : IRequest<string>
    {}

    public class DepositCommandHandler : IRequestHandler<DepositCommand, string>
    {
        private readonly DB _context;

        public DepositCommandHandler(DB context)
        {
            _context = context;
        }

        public async Task<string> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _context.Wallets.FindAsync(request.walletId);

            if (wallet is null)
                throw new AppException("Wallet not found");

            wallet.Deposit(request.amount);

            await _context.Transactions.AddAsync(new Transaction
            {
                WalletId = request.walletId,
                Amount = request.amount,
                Date = DateTime.Now,
                Type = "Deposit",
                Status = "Completed"
            });

            await _context.SaveChangesAsync(cancellationToken);

            return "Deposit successful";
        }
    }
}
