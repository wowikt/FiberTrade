using FifteenGame.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifteenGameWebApi.Models
{
    public class MoveInputModel
    {
        public IEnumerable<int> State { get; set; }

        public MoveDirection Direction { get; set; }
    }
}