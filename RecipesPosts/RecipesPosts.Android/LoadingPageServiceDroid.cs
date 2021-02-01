﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using RecipesPosts.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFPlatform = Xamarin.Forms.Platform.Android.Platform;


[assembly: Xamarin.Forms.Dependency(typeof(LoadingPageServiceDroid))]

namespace RecipesPosts.Droid
{

    public class LoadingPageServiceDroid : ILoadingPageService
    {

        private Android.Views.View _nativeView;
        private Dialog _dialog;
        private bool _isInitialized;
        public void HideLoadingPage()
        {
            // Hide the page

            _dialog.Hide();
        }

        public void InitLoadingPage(ContentPage loadingIndicatorPage = null)
        {
            // check if the page parameter is available
            if (loadingIndicatorPage != null)
            {
                // build the loading page with native base
                loadingIndicatorPage.Parent = Xamarin.Forms.Application.Current.MainPage;
                loadingIndicatorPage.Layout(new Rectangle(0, 0,
                Xamarin.Forms.Application.Current.MainPage.Width,
                Xamarin.Forms.Application.Current.MainPage.Height));
                var renderer = loadingIndicatorPage.GetOrCreateRenderer();
                _nativeView = renderer.View;
                _dialog = new Dialog(CrossCurrentActivity.Current.Activity);

                _dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);

                _dialog.SetCancelable(false);

                _dialog.SetContentView(_nativeView);

                Window window = _dialog.Window;

                window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

                window.ClearFlags(WindowManagerFlags.DimBehind);

                window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));
                _isInitialized = true;
            }
        }

        public void ShowLoadingPage()
        {
            // check if the user has set the page or not
            if (!_isInitialized)
                InitLoadingPage(new LoginPage()); // set the default page

            // showing the native loading page

            _dialog.Show();
        }
    }
    internal static class PlatformExtension
    {
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement bindable)
        {
            var renderer = XFPlatform.GetRenderer(bindable);
            if (renderer == null)
            {
                renderer = XFPlatform.CreateRendererWithContext(bindable, CrossCurrentActivity.Current.Activity);

                XFPlatform.SetRenderer(bindable, renderer);

            }

            return renderer;

        }

    }
}