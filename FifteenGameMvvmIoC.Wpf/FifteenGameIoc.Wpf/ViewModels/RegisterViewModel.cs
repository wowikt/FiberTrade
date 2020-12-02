using FifteenGame.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameIoc.Wpf.ViewModels
{
    public class RegisterViewModel
    {
        private readonly IUserService _userService;

        public string Login { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public GameViewModel ParentViewModel { get; set; }

        public RegisterViewModel(IUserService userService)
        {
            _userService = userService;
        }

        public bool DoRegister()
        {
            var user = _userService.Register(Login, Password, UserName);
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
