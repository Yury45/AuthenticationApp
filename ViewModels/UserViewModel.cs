using AuthenticationApp.Models;
using System;
using System.Net.Mail;

namespace AuthenticationApp.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public bool FromRussia { get; set; }
        public UserViewModel(User user)
        {
            Id = user.Id;

            FullName = GetFullName(user.Firstname, user.Lastname);

            FromRussia = IsFromRussia(user.Email);
        }

        private string GetFullName(string firstname, string lastname)
        {
            return String.Concat(firstname, " ", lastname);
        }

        private bool IsFromRussia(string email)
        {
            MailAddress address = new MailAddress(email);

            if (address.Host.Contains(".ru"))
                return true;
            return false;
        }
    }
}
