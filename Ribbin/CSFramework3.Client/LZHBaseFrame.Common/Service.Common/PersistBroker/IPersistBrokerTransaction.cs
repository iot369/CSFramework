using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Common.PersistBroker
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