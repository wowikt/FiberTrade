using FifteenGame.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifteenGameAspNet.Models
{
    public class ButtonViewModel
    {
        public int Value { get; set; }

        public bool IsVisible { get; set; }

        public MoveDirection MoveDirection { get; set; }

        public string Text => Value.ToString();

        public bool IsEnabled => MoveDirection != MoveDirection.None;
    }
}