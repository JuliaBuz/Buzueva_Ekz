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
using Skidka;
namespace Buzueva_Ekzamen.Pages
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        public int CountTakedBooks { get; set; }
        List<int> korzina = new List<int>();
        Otobrazhenie viewModel = new Otobrazhenie();
        int TotalCost = 0;
        int TotalSale = 0;
        public List<BooksCatalog> buf3 = new List<BooksCatalog>();
        public BooksCatalog buf4;
        public string skid { get; set; }
        public Catalog()
        {
            InitializeComponent();
            Allbooks.ItemsSource = viewModel.catolog.ToList();
            Allbooks.Items.Refresh();
            skid = "None";
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                CountTakedBooks = 0;
                Button button = (Button)sender;
                int id = Convert.ToInt32(button.Uid);
                BooksCatalog books = DataBase.BaseModel.BooksCatalog.FirstOrDefault(x => x.ID == id);
                int ss = (int)(books.NumberStok + books.NumberMagazine);
                if (books.NumberStok == 0 && books.NumberMagazine == 0)
                {
                    throw new Exception("Данной книги нет в наличии.");
                }
                books.CountInCart++;
                if (books.CountInCart > ss)
                {
                    throw new Exception("Превышен лимит товара");
                }
                korzina.Add(id);
                CountTakedBooks = korzina.Count;
                TotalCost += Convert.ToInt32(books.Price);
                Class1 class1 = new Class1();
                TotalSale = class1.sale(korzina.Count, TotalCost);
                shtuk.Text = korzina.Count.ToString();
                price.Text = TotalCost.ToString();
                sale.Text = TotalSale.ToString();
                if (TotalSale > 0)
                {
                    price.TextDecorations = TextDecorations.Strikethrough;
                    newprice.Visibility = Visibility.Visible;
                }
                double itog = TotalCost - (TotalCost * TotalSale / 100);
                newprice.Text = Math.Floor(itog).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void PerexKorzin(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (int y in korzina.Distinct().ToList())
                {
                    buf4 = DataBase.BaseModel.BooksCatalog.FirstOrDefault(x => x.ID == y);
                    buf3.Add(buf4);
                }
                PagesChange.switchPage.Navigate(new Korzina(buf3, TotalSale));
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
