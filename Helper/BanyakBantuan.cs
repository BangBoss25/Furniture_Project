using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Helper
{
    public class BanyakBantuan
    {
        public int BuatOtp()
        {
            Random start = new Random();

            int valuenya = start.Next(1000, 9999);

            return valuenya;
        }
    }
}
