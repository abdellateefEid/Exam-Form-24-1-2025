﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_Form.Models
{
    public partial class GetInstructorCoursesResult
    {
        [StringLength(255)]
        public string Course_Name { get; set; }
        public int? number_of_students { get; set; }
    }
}
