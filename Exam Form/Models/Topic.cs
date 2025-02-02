﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam_Form.Models;

[PrimaryKey("CourseId", "TopicName")]
[Table("Topic")]
public partial class Topic
{
    [Key]
    [Column("Course_Id")]
    public int CourseId { get; set; }

    [Key]
    [Column("Topic_Name")]
    [StringLength(255)]
    [Unicode(false)]
    public string TopicName { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Topics")]
    public virtual Course Course { get; set; }
}