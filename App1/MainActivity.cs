using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Threading;
using Android.Content;

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
            //Sign In Click
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_SignIn signInDialog = new dialog_SignIn();
            signInDialog.Show(transaction, "dialog fragment");

            signInDialog.MOnSignInComplete += SignInDialog_MOnSignInComplete;
        }


        private void SignInDialog_MOnSignInComplete(object sender, OnSignUpEventArgs e)
        {

            // Sign In complete
            // TODO ---> check login
            // check if e.Email is in DB, in not says to Sign Up
            // if e.Email in DB check if e.Password == password in DB
            // if it does start ActivitySignedIn, if not says wrong data and send back to login
            Intent intent = new Intent(this, typeof(ActivitySignedIn));
            this.StartActivity(intent);
            this.Finish();
            //mProgressBar.Visibility = Android.Views.ViewStates.Visible;
            //Thread thread = new Thread(serverLike);
            
            //thread.Start();
        }


        void btnSignUp_Click(object sender, EventArgs e)
        {
            //Sign Up Click
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_SignUp signUpDialog = new dialog_SignUp();
            signUpDialog.Show(transaction, "dialog fragment");
            
            
            signUpDialog.MOnSignUpComplete += signUpDialog_MOnSignUpComplete;
        }


         void signUpDialog_MOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            //Sign Up Complete
            //check that arguments are not ""
            // check if in db already exists email e.Email, if not create new user
            User newUser = new User(e.FirstName, e.Email, e.Password);
            //insert new user in DB
            //send to login

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

