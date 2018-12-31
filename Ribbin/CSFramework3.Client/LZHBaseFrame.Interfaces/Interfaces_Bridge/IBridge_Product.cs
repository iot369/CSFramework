using System;
using System.Collections.Generic;
using System.Text;

namespace LZHBaseFrame.Interfaces
{
    public interface IBridge_Product
    {
        System.Data.DataTable FuzzySearch(string content);
    }
}
