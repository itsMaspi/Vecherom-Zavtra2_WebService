//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vecherom_Zavtra2_WebService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserCfg
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public string cfg { get; set; }
    
        public virtual User User { get; set; }
    }
}
