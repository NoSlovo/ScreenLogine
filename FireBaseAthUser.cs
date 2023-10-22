using System;
using Firebase;
using Firebase.Auth;
using UnityEngine;


public class FireBaseAthUser : MonoBehaviour
{
   private FirebaseAuth Auth;

   private void Start()
   {
      FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
      {
         DependencyStatus result = task.Result;
         if (result == DependencyStatus.Available)
         {
            Auth = FirebaseAuth.DefaultInstance;
         }
      });
   }

   public async void RegisteUser(string mail,string _password)
   {
      await Auth.CreateUserWithEmailAndPasswordAsync(mail,  _password)
         .ContinueWith(task =>
         {
            if (task.IsCanceled) {
               Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
               return;
            }
            if (task.IsFaulted) {
               Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
               return;
            }
                    
            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
               result.User.DisplayName, result.User.UserId);
         } );
   }
}
