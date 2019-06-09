using System;
using System.Collections.Generic;
using System.Text;

namespace DataQueryWriter.Interfaces
{
    public interface ITemplate
    {
        string CreateDataQuery(string path);
        void GenerateLazyImages(string from, string to);
    }
}
