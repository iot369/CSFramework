
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

using Service.Common.PersistBroker;

namespace Service.Common.Domain
{
    [Serializable]
    public class DomainObject
    {
        private bool _isBlobIgnored = true;

        public DomainObject()
        {
        }

        public bool IsBlobIgnored
        {
            get
            {
                return _isBlobIgnored;
            }
            set
            {
                _isBlobIgnored = value;
            }
        }

        public bool Check()
        {
            return true;
        }

    }
}
