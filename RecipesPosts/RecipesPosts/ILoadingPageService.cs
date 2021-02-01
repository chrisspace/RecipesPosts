﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RecipesPosts
{
    public interface ILoadingPageService
    {
        void InitLoadingPage(ContentPage loadingIndicatorPage = null);
        void ShowLoadingPage();
        void HideLoadingPage();

    }
}
