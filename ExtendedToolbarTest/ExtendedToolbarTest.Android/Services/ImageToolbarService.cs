using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ExtendedToolbarTest.Services;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;
using View = Xamarin.Forms.View;

namespace ExtendedToolbarTest.Droid.Services
{
    public class ImageToolbarService : IImageToolbarService
    {
        public void PutView(View view)
        {
            view = (view as ContentView)?.Content;
             var coef = CrossCurrentActivity.Current.Activity.Resources.DisplayMetrics.Density;
          //  var size = CrossCurrentActivity.Current.Activity.Resources.GetDimensionPixelSize()

            view.Layout(new Rectangle(0, 0, (int)54, (int)54));
            if (Platform.GetRenderer(view) == null)
            {
                Platform.SetRenderer(view,Platform.CreateRendererWithContext(view, CrossCurrentActivity.Current.Activity));
            }

            var renderer = Platform.GetRenderer(view);

            renderer.Tracker.UpdateLayout();
           
            var viewToAdd =
                CrossCurrentActivity.Current.Activity.FindViewById<LinearLayout>(Resource.Id.toolbar_button_layout);
           
            var viewGroup = renderer.View;

            var layoutParams = new ViewGroup.LayoutParams((int)54 * (int)coef, (int)54 * (int)coef);
            viewGroup.LayoutParameters = layoutParams;
            viewGroup.Layout(0, 0, (int)54 * (int)coef, (int)54 * (int)coef);
           // viewToAdd.Invalidate();
           // viewToAdd.RequestLayout();
           // viewGroup.SetBackgroundColor(Color.Black);
            viewToAdd.AddView(viewGroup);
           
        }
    }
}