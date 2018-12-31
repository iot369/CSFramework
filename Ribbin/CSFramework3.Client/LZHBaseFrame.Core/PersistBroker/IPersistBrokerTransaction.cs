using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LZHBaseFrame.Core.PersistBroker
{
    public interface IPersistBrokerTransaction
    {
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        bool IsInTransaction
        { get; }
    }
}