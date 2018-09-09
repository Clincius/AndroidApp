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

namespace App1
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string mFirstName;
        private string mEmail;
        private string mPassword;

        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }
        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }
        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public OnSignUpEventArgs(string firstName, string email, string password) : base()
        {
            FirstName = firstName;
            Email = email;
            Password = password;
        }
        public OnSignUpEventArgs( string email, string password) : base()
        {
            
            Email = email;
            Password = password;
        }


    }
    class dialog_SignUp : DialogFragment
    {
        private EditText txtFirstName;
        private EditText txtEmail;
        private EditText txtPassword;
        private Button btnSignUp;

        public event EventHandler<OnSignUpEventArgs> MOnSignUpComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog, container, false);

            txtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            btnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            btnSignUp.Click += BtnSignUp_Click;
            return view;
        }

         void BtnSignUp_Click(object sender, EventArgs e)
        {
            //User has clicked the sign up button
            MOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(txtFirstName.Text, txtEmail.Text, txtPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }


    class dialog_SignIn : DialogFragment
    {
        
        private EditText txtEmail;
        private EditText txtPassword;
        private Button btnSignIn;

        public event EventHandler<OnSignUpEventArgs> MOnSignInComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialogSignIn, container, false);

            
            txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            btnSignIn = view.FindViewById<Button>(Resource.Id.btnSignIn);

            btnSignIn.Click += BtnSignIn_Click;
            return view;
        }

        void BtnSignIn_Click(object sender, EventArgs e)
        {
            //User has clicked the sign in button
            MOnSignInComplete.Invoke(this, new OnSignUpEventArgs(txtEmail.Text, txtPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animationDown;
        }
    }
}