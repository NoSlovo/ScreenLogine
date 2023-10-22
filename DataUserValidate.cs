using System.Text.RegularExpressions;

namespace LogineScreen
{
    public class DataUserValidate
    {
        private string regMail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        private string regPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$";

        private Regex rx;
        
        public bool MailValidate(string Mail)
        {
            rx = new Regex(regMail);
            
            if (!rx.Match(Mail).Success)
            {
                return true;
            }

            return false;
        }

        public bool PasswordWalidate(string password)
        {
            rx = new Regex(regPassword);
            
            if (!rx.Match(regPassword).Success)
            {
                return true;
            }

            return false;
        }
    }
}