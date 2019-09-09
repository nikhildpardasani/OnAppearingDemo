using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OnAppearingDemo.Models;
using OnAppearingDemo.Views;
using OnAppearingDemo.ViewModels;

namespace OnAppearingDemo.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
            Btn1.Clicked += Btn1_Clicked;
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }

        //I need to call this Method whenever this Page Appears(Navigation.PushAsync() or Navigation.PopAsync() is called.)
        //This is not fired when I return back from a Page2 in Android but it does in iOS.
        //Hence I am stuck Because for iOS this works well but Android doesn't.
        //Put a breakpoint on this method and observe the behaviour in both Android and iOS.
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}