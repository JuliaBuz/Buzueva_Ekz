using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Buzueva_Ekzamen.Pages
{
    /// <summary>
    /// Логика взаимодействия для Korzina.xaml
    /// </summary>
    public partial class Korzina : Page
    {
        List<BooksCatalog> bo = new List<BooksCatalog>();
        int Sale, x = 0, tc = 0, itogc = 0, itogtc = 0;
        public Korzina(List<BooksCatalog> books, int sale)
        {
            InitializeComponent();
            ListZak.ItemsSource = books;
            ListZak.Items.Refresh();
            Sale = sale;
            bo = books;
            foreach (BooksCatalog b in books)
            {

                if (b.CountInCart == 1)
                {
                    b.Visible = "Collapsed";
                }
                if (sale == 0)
                {
                    b.Visible2 = "Collapsed";
                }
                b.TotalPriseZak = (decimal)(b.Price * b.CountInCart);
                b.TotalPriseZakWithSale = b.TotalPriseZak - (b.TotalPriseZak * sale / 100);
                b.decor = "Strikethrough";
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            PagesChange.switchPage.Navigate(new Catalog());
        }

        private void AllDelit(object sender, RoutedEventArgs e)
        {
            ListZak.ItemsSource = null;
            ListZak.Items.Refresh();
        }

        private void Delit(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Uid);
            BooksCatalog prov = DataBase.BaseModel.BooksCatalog.FirstOrDefault(x => x.ID == id);
            bo.Remove(prov);
            ListZak.Items.Refresh();
        }
        private void NewZakaz(object sender, RoutedEventArgs e)
        {
            DateTime today = DateTime.Now;
            foreach (BooksCatalog b in bo)
            {
                x = b.CountInCart;
                tc = Convert.ToInt32(b.TotalPriseZakWithSale);
                itogc += x;
                itogtc += tc;
            }
            Zakaz zakaz = new Zakaz()
            {
                Date = today.AddHours(72),
                Count = itogc,
                TotalPrice = itogtc,
                Sale = Sale,
                Reserv = today.AddDays(7),
            };
            DataBase.BaseModel.Zakaz.Add(zakaz);
            DataBase.BaseModel.SaveChanges();
            DataBase.BaseModel = new Entities();

            ListZak.ItemsSource = null;
            ListZak.Items.Refresh();
            MessageBox.Show("Следующие данные о заказе добавлены в БД:\n Номер заказа:" + zakaz.ID.ToString() + "\n Можно забирать:" + today.AddHours(72).ToString() +
            "\n Конец срока резервирования продукции:" + today.AddDays(7).ToString() + "\n Цена заказа со скидкой:" + itogtc.ToString() + "\n Процент скидки:" + Sale.ToString() +
            "\n Итоговое количество:" + itogc.ToString());
        }
        private void Plus(object sender, RoutedEventArgs e)
        {
            foreach (BooksCatalog b in bo)
            {
                b.CountInCart += 1;
                if (b.CountInCart == 1)
                {
                    b.Visible = "Collapsed";
                }
                if (Sale == 0)
                {
                    b.Visible2 = "Collapsed";
                }
                b.TotalPriseZak = ((decimal)(b.Price * b.CountInCart));
                b.TotalPriseZakWithSale = b.TotalPriseZak - (b.TotalPriseZak * Sale / 100);
                b.decor = "Strikethrough";
            }
            ListZak.Items.Refresh();
        }

        private void Minus(object sender, RoutedEventArgs e)
        {
            try
            {
                BooksCatalog prov = new BooksCatalog();
                foreach (BooksCatalog b in bo)
                {
                    b.CountInCart -= 1;
                    if ((b.CountInCart > 0) && (b.CountInCart < (b.NumberStok + b.NumberStok)))
                    {
                        if (b.CountInCart == 1)
                        {
                            b.Visible = "Collapsed";
                        }
                        if (Sale == 0)
                        {
                            b.Visible2 = "Collapsed";
                        }
                        b.TotalPriseZak = ((decimal)(b.Price * b.CountInCart));
                        b.TotalPriseZakWithSale = b.TotalPriseZak - (b.TotalPriseZak * Sale / 100);
                        b.decor = "Strikethrough";
                        ListZak.Items.Refresh();
                    }
                    else if (b.CountInCart == 0)
                    {
                        prov = b;
                    }
                    else
                    {
                        throw new Exception("Количество не может быть");
                    }
                }
                bo.Remove(prov);
                ListZak.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}