using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestApp
{
    public partial class MainPage : ContentPage
    {
        private int[] randomNumbers = new int[] { 11, 5, 13, 11, 4, 5, 20, 20, 6, 2, 16, 20, 14, 1, 7, 5, 5, 11, 17, 1, 9, 11, 7, 6, 11, 8, 11, 14, 20, 3, 3, 1, 17, 20, 6, 16, 16,
17, 5, 11, 18, 15, 2, 20, 10, 9, 3, 8, 20, 5 };
        public MainPage()
        {
            InitializeComponent();
            listView.ItemsSource = this.GetSource(50);
            listView.SwipeOffset = Device.OnPlatform<Thickness>(new Thickness(100, 0, 100, 0), 70, 0);
            listView.LayoutDefinition.ItemLength = Device.OnPlatform<double>(60, -1, -1);
        }
        private System.Collections.IEnumerable GetSource(int count)
        {
            var items = new List<Item>();
            for (int i = 0; i < count; i++)
            {
                items.Add(new Item { Name = string.Format("product {0}", i), Value = randomNumbers[i] });
            }

            return items;
        }

        private void IncreaseButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button.BindingContext as Item;
            item.Value++;
            listView.EndItemSwipe();
        }

        private void DecreaseButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button.BindingContext as Item;
            if (item.Value > 0)
            {
                item.Value--;
            }

            listView.EndItemSwipe();
        }
    }

    internal class Item

    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

}
