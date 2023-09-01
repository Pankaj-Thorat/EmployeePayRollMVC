﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class EmployeeLogin
    {
        [Required(ErrorMessage = "{0} is required")]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        public String EmpName { get; set; }

        
       
    }
}
