//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelCompany.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class PriceList
    {
        public int Id { get; set; }
        public Nullable<int> TourId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Tour Tour { get; set; }
    }
}