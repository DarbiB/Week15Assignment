﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DbConnectCourses.Models
{
    public partial class Advisor
    {
        public Advisor()
        {
            Students = new HashSet<Student>();
        }

        public string AdvisorId { get; set; }
        public string AdvisorFirstName { get; set; }
        public string AdvisorLastName { get; set; }
        public string AdvisorPhone { get; set; }
        public string AdvisorEmail { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}