using System;
using Firebase.Auth;

namespace hyperios.iOS.Helpers
{
    public static class FirebaseError
    {

        public static void Log(Foundation.NSError error)
        {
			AuthErrorCode errorCode;
			if (IntPtr.Size == 8) // 64 bits devices
				errorCode = (AuthErrorCode)((long)error.Code);
			else // 32 bits devices
				errorCode = (AuthErrorCode)((int)error.Code);

			// Posible error codes that SignIn method with email and password could throw
			// Visit https://firebase.google.com/docs/auth/ios/errors for more information
			switch (errorCode)
			{
				case AuthErrorCode.OperationNotAllowed:
					Console.WriteLine("Operation Not Allowed!!!");
					break;
				case AuthErrorCode.InvalidEmail:
					Console.WriteLine("Invalid Email!!!");
					break;
				case AuthErrorCode.UserDisabled:
					Console.WriteLine("User Disabled!!!");
					break;
				case AuthErrorCode.WrongPassword:
					Console.WriteLine("Wrong Password!!!");
					break;
				case AuthErrorCode.KeychainError:
					Console.WriteLine("Keychain Error!!!");
					break;
				default:
                    Console.WriteLine("Facing error: " + error);
					break;
			}
        }


        public static string GetError(Foundation.NSError error)
        {
			AuthErrorCode errorCode;
			if (IntPtr.Size == 8) // 64 bits devices
				errorCode = (AuthErrorCode)((long)error.Code);
			else // 32 bits devices
				errorCode = (AuthErrorCode)((int)error.Code);

			// Posible error codes that SignIn method with credentials could throw
			switch (errorCode)
			{
				case AuthErrorCode.InvalidCredential:
                    return "Invalid credential";
				case AuthErrorCode.InvalidEmail:
                    return "Invalid email";
				case AuthErrorCode.OperationNotAllowed:
                    return "Operation not allowed";
				case AuthErrorCode.EmailAlreadyInUse:
                    return "Email already in use";
				case AuthErrorCode.UserDisabled:
                    return "Your account is disabled";
				case AuthErrorCode.WrongPassword:
                    return "Wrong password!";
				case AuthErrorCode.WeakPassword:
					return "Weak password, require at least 6 characters";
				default:
					Console.WriteLine("unknown error: " + error);
					return "Unknown Error";
			}
        }

    }
}
