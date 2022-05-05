﻿using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinFirebaseApp
{
    public class UserRepository
    {
        string webAPIKey = "AIzaSyCTJth0-c-fan6T6tl0sLHglOiymBb5xsw"; 
        FirebaseAuthProvider authProvider ;

        public UserRepository()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIKey)); 
        }
        public async Task<bool> Register(string email , string name , string password)
        {
            var token =await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, name);

            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return true;  
            }
            return false;
        }
        
        public async Task<string> SignIn(string email, string name, string password)
        {
            var token =await authProvider.SignInWithEmailAndPasswordAsync (email, password, name);
           
            //var uid = token.User.LocalId;

            if (string.IsNullOrEmpty(token.FirebaseToken))
            {
                return token.FirebaseToken; 
            }
            return "";


        }

        


       
    } 

}
