using System;
using System.Collections.Generic;
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

namespace Kharrasov41
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
public partial class ProductPage : Page
{
    List<Product> CurrentPageList = new List<Product>();
    List<Product> TableList;
    int CountPage;
    int CurrentCountPage;

    private int EveryPage { get; set; }
    public ProductPage()
    {
        InitializeComponent();
        var currentProducts = Kharrasov41Entities.GetContext().Product.ToList();
        ProductListView.ItemsSource = currentProducts;
        ComboBoxFilter.SelectedIndex = 0;
        CurrentCountPage = TableList.Count;
        EveryPages.Text = CurrentCountPage.ToString();
        UpdateProduct();

    }
    private void UpdateProduct()
        {
            var currentProducts = Kharrasov41Entities.GetContext().Product.ToList();

            if (ComboBoxFilter.SelectedIndex == 1)
            {
                currentProducts = currentProducts.Where(p => p.ProductDiscountAmount <= 9.99).ToList();
            }
            if (ComboBoxFilter.SelectedIndex == 2)
            {
                currentProducts = currentProducts.Where(p => p.ProductDiscountAmount > 10 && p.ProductDiscountAmount < 14.99).ToList();
            }
            if (ComboBoxFilter.SelectedIndex == 3)
            {
                currentProducts = currentProducts.Where(p => p.ProductDiscountAmount >= 15).ToList();
            }



            if (RButtonBiggist.IsChecked.Value)
            {
                currentProducts = currentProducts.OrderByDescending(p => p.ProductCost).ToList();
            }

            if (RbutttonSmallist.IsChecked.Value)
            {
                currentProducts = currentProducts.OrderBy(p => p.ProductCost).ToList();
            }

            currentProducts = currentProducts.Where(p => p.ProductName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();


            ProductListView.ItemsSource = currentProducts.ToList();
            ProductListView.ItemsSource = currentProducts;
            TableList = currentProducts;
            ChangeText();
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();

        }
        private void ComboBoxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }
        private void RButtonBiggist_Checked(object sender, RoutedEventArgs e)
        {
            UpdateProduct();
        }

        private void RbutttonSmallist_Checked(object sender, RoutedEventArgs e)
        {
            UpdateProduct();
        }

        private void ChangeText()
        {
            CurrentPageList.Clear();
            CountPage = TableList.Count;
            currentPages.Text = CountPage.ToString();
        }
    }
}
