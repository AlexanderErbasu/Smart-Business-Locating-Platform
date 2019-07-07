//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BPP_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class UsersAnalyzedElement
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        public int AnalyzedElementId { get; set; }
        
        [DisplayName("Chosen Value")]
        public decimal ChosenValue { get; set; }

        [Range(0, 10)]
        public decimal Importance { get; set; }
        
        public virtual AnalyzedElement AnalyzedElement { get; set; }
        public virtual User User { get; set; }
    }
}