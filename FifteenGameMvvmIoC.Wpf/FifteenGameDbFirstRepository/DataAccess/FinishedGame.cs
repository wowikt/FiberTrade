//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FifteenGameDbFirstRepository.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class FinishedGame
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public System.DateTime GameFinishDate { get; set; }
        public int MoveCount { get; set; }
        public Nullable<System.TimeSpan> GameTime { get; set; }
    
        public virtual User User { get; set; }
    }
}
