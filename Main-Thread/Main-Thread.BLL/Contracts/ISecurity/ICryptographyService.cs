using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Main_Thread.BLL.Contracts.ISecurity
{
    public interface ICryptographyService
    {
        string ComputeSha256Hash(string rawData);
    }
}
