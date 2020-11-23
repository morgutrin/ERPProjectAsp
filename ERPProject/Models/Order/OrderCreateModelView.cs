﻿using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Order
{
    public class OrderCreateModelView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int ContractorId { get; set; }
        [DataType(DataType.Date)]
        public DateTime RealizationDate { get; set; }
        public Status Status { get; set; }

    }
}