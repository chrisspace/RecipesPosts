using RecipesPosts.Helpers;
using RecipesPosts.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipesPosts
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    //public partial class RegisterPage : ContentPage
    //{
    //    User user = new User();
    //    UserDatabase userDatabase = new UserDatabase();
    //    //public RegisterPage()
    //    //{
    //    //    InitializeComponent();
    //    //    NavigationPage.SetHasBackButton(this, false);
    //    //    emailEntry.ReturnCommand = new Command(() => userNameEntry.Focus());
    //    //    userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
    //    //    passwordEntry.ReturnCommand = new Command(() => confirmPasswordEntry.Focus());
    //    //    confirmPasswordEntry.ReturnCommand = new Command(() => phoneEntry.Focus());
    //    //}
    //    private async void RegisterButton_Clicked(object sender, EventArgs e)
    //    {
    //        if ((string.IsNullOrWhiteSpace(userNameEntry.Text)) || (string.IsNullOrWhiteSpace(emailEntry.Text)) ||
    //         (string.IsNullOrWhiteSpace(passwordEntry.Text)) || (string.IsNullOrWhiteSpace(phoneEntry.Text)) ||
    //         (string.IsNullOrEmpty(userNameEntry.Text)) || (string.IsNullOrEmpty(emailEntry.Text)) ||
    //         (string.IsNullOrEmpty(passwordEntry.Text)) || (string.IsNullOrEmpty(phoneEntry.Text)))
    //        {
    //            await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
    //        }
    //        else if (!string.Equals(passwordEntry.Text, confirmPasswordEntry.Text))
    //        {
    //            warningLabel.Text = "Enter Same Password";
    //            passwordEntry.Text = string.Empty;
    //            confirmPasswordEntry.Text = string.Empty;
    //            warningLabel.TextColor = Color.IndianRed;
    //            warningLabel.IsVisible = true;
    //        }
    //        else if (phoneEntry.Text.Length < 10)
    //        {
    //            phoneEntry.Text = string.Empty;
    //            phoneWarLabel.Text = "Enter 10 digit Number";
    //            phoneWarLabel.TextColor = Color.IndianRed;
    //            phoneWarLabel.IsVisible = true;
    //        }
    //        else
    //        {
    //            user.Email = emailEntry.Text;
    //            user.Username = userNameEntry.Text;
    //            user.Password = passwordEntry.Text;
    //            user.Phone = phoneEntry.Text.ToString();
    //            try
    //            {
    //                var returnvalue = userDatabase.AddUser(user);
    //                if (returnvalue == "Sucessfully Added")
    //                {
    //                    await DisplayAlert("User Add", returnvalue, "OK");
    //                    await Navigation.PushAsync(new LoginPage());
    //                }
    //                else
    //                {
    //                    await DisplayAlert("User Add", returnvalue, "OK");
    //                    warningLabel.IsVisible = false;
    //                    emailEntry.Text = string.Empty;
    //                    userNameEntry.Text = string.Empty;
    //                    passwordEntry.Text = string.Empty;
    //                    confirmPasswordEntry.Text = string.Empty;
    //                    phoneEntry.Text = string.Empty;
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                Debug.WriteLine(ex);
    //            }
    //        }
    //    }
    //    //private async void login_ClickedEvent(object sender, EventArgs e)
    //    //{
    //    //    await Navigation.PushAsync(new LoginPage());
    //    //}




    //    // apo do k kato ta dika moy prin paro ton kodika apo internet https://xmonkeys360.com/2019/07/10/register-login-and-update-using-sqlite-in-xamarin-forms/

    //    public RegisterPage()
    //    {
    //        InitializeComponent();
    //    }


    //    //private async void RegisterButton_Clicked(object sender, EventArgs e)
    //    //{
    //    //    if (passwordEntry.Text == confirmPasswordEntry.Text)
    //    //    {
    //    //        //we can register the user
    //    //        await Navigation.PushAsync(new HomePage());
    //    //    }
    //    //    else
    //    //    {
    //    //        await DisplayAlert("Error", "The passwords do not match", "Ok");
    //    //    }
    //    //}

    //    //private async void login_ClickedEvent(object sender, EventArgs e)
    //    //{
    //    //    await Navigation.PushAsync(new HomePage());

    //    //}

    //    //private void SignupValidation_ButtonClicked(object sender, EventArgs e)
    //    //{

    //    //}

    //}
}