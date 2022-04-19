using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buzueva_Ekzamen
{
    class Otobrazhenie
    {
        public List<BooksCatalog> catolog;

        public Otobrazhenie()
        {
            catolog = newbook();
        }

        public List<BooksCatalog> newbook()
        {
            List<BooksCatalog> allbook = new List<BooksCatalog>();
            BooksCatalog buff;
            List<BooksCatalog> bdbooks = DataBase.BaseModel.BooksCatalog.ToList();

            foreach (BooksCatalog book in bdbooks)
            {
                buff = new BooksCatalog();
                buff.ID = book.ID;
                buff.Titile = book.Titile;
                buff.Genre = book.Genre;
                buff.Writer = book.Writer;
                buff.Description = book.Description;
                buff.Image = book.Image;
                buff.NumberStok = book.NumberStok;
                buff.NumberMagazine = book.NumberMagazine;
                buff.Price = book.Price;

                Authors authors = DataBase.BaseModel.Authors.FirstOrDefault(x => x.ID == book.Writer);
                buff.AuthorName = authors.AuthorName;

                Genre genre = DataBase.BaseModel.Genre.FirstOrDefault(x => x.ID == book.Genre);
                buff.GenreName = genre.GenderName;

                if (book.NumberStok > 5)
                {
                    buff.Stock = "много";
                }
                else if (book.NumberStok == 0)
                {
                    buff.Stock = "нет";
                }
                else
                {
                    buff.Stock = book.NumberStok;
                }

                if (book.NumberMagazine > 5)
                {
                    buff.Store = "много";
                }
                else if (book.NumberMagazine == 0)
                {
                    buff.Store = "нет";
                }
                else
                {
                    buff.Store = book.NumberMagazine;
                }
                allbook.Add(buff);
            }
            return allbook;
        }
    }
}