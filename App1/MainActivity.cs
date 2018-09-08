using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Threading;

namespace App1
{
    [Activity(Label = "Login", MainLauncher = true)]
    public class MainActivity : Activity
    {

        private Button btnSignUp;
        private Button btnSignIn;
        private ProgressBar mProgressBar;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnSignUp = FindViewById<Button>(Resource.Id.SignUp);
            btnSignIn = FindViewById<Button>(Resource.Id.SignIn);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            
            btnSignUp.Click += btnSignUp_Click;
            btnSignIn.Click += BtnSignIn_Click;


        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btnSignUp_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_SignUp signUpDialog = new dialog_SignUp();
            signUpDialog.Show(transaction, "dialog fragment");
            

            signUpDialog.MOnSignUpComplete += signUpDialog_MOnSignUpComplete;
        }

         void signUpDialog_MOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            mProgressBar.Visibility = Android.Views.ViewStates.Visible;
            Thread thread = new Thread(serverLike);
            thread.Start();
            
        }

         void serverLike()
        {
            Thread.Sleep(5000);
            RunOnUiThread(() => { mProgressBar.Visibility = Android.Views.ViewStates.Invisible; });
        }
    }
}

