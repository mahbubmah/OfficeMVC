//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OfficeMvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOffice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public int Basic { get; set; }
        public int Conveyance { get; set; }
        public int HouseRent { get; set; }
        public int EmployeeId { get; set; }
    }
}