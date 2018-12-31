using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LZHBaseFrame.Interfaces.Interfaces_Bridge
{
    public interface IBridge_AttachFile
    {
        DataTable GetData(string docID);
    }
}
