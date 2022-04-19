using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buzueva_Ekzamen
{
    public partial class BooksCatalog
    {
        public int CountInCart { get; set; } = 0;
        public decimal TotalPriseZak { get; set; } = 0;
        public decimal TotalPriseZakWithSale { get; set; } = 0;

        private string writer;

        public string AuthorName
        {
            get { return writer; }
            set { writer = value; }
        }

        private string genre;

        public string GenreName
        {
            get { return genre; }
            set { genre = value; }
        }
        private dynamic countStock;

        public dynamic Stock
        {
            get { return countStock; }
            set { countStock = value; }
        }

        private dynamic countStore;

        public dynamic Store
        {
            get { return countStore; }
            set { countStore = value; }
        }

        public string Visible { get; set; }
        public string Visible2 { get; set; }
        
        public string decor { get; set; } = "None";
    }
}
