using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Contractor
{
    public class ContractorDetailsViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string TIN { get; set; }
        public CountrySign CountrySign { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public string PostCode { get; set; }
        public Country Country { get; set; }
    }
}