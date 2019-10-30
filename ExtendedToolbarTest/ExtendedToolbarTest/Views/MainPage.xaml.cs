using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedToolbarTest.Controls;
using ExtendedToolbarTest.Services;
using Unity;
using Xamarin.Forms;

namespace ExtendedToolbarTest.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var ciew = new UserImageContentView();
            var model = new UserViewModel();
            model.Image =
                "https://bdfss.blob.core.windows.net/shots/2018-07-11_17-39-56-d24849ef-2773-48dc-840d-a81b39c26e40.png";
            ciew.BindingContext = model;
            var imageService = ContainerManager.Container.Resolve<IImageToolbarService>();
            imageService.PutView(ciew);
        }
    }
}