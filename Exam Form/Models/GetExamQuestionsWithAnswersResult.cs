﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_Form.Models
{
    public partial class GetExamQuestionsWithAnswersResult
    {
        [StringLength(255)]
        public string Question_Head { get; set; }
        [StringLength(255)]
        public string Model_Answer { get; set; }
        [StringLength(255)]
        public string Student_Answer { get; set; }
    }
}
