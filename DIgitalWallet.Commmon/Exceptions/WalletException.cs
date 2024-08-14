using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIgitalWallet.Commmon.Exceptions;

public sealed class AppException : Exception
{
    public readonly string CustomMessage;

    public AppException(string customeMesssage, Exception? innerException = null)
        : base(customeMesssage, innerException)
    {
        CustomMessage = customeMesssage;
    }
}

