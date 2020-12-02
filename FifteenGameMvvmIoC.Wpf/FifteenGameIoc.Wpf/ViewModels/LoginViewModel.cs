using FifteenGame.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameIoc.Wpf.ViewModels
{
    public class LoginViewModel
    {
        private readonly IUserService _userService;

        public string Login { get; set; }

        public string Password { get; set; }

        public GameViewModel ParentViewModel { get; set; }

        public LoginViewModel (IUserService userService)
        {
            _userService = userService;
        }

        public bool DoLogin()
        {
            var user = _userService.Login(Login, Password);
            if (user != null)
            {
                ParentViewModel.User = user;
                return true;
            }

            return false;
        }

        public void DoCancel()
        {
            ParentViewModel.CloseView();
        }
    }
}
