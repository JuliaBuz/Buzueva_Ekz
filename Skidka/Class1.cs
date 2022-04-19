using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skidka
{
    public class Class1
    {
        public int sale(int count, int prise)
        {
            int sale = 0;
            if (count > 2)
            {
                sale = 5;
                sale = sale + (prise / 500);
            }
            if (count > 4)
            {
                sale = 10;
                sale = sale + (prise / 500);
            }
            if (count > 9)
            {
                sale = 15;
                sale = sale + (prise / 500);
            }

            return sale;
        }
    }
}