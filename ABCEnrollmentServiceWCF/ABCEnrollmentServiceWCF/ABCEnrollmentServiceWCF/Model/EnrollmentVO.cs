﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ABCEnrollmentServiceWCF.Model
{
    [DataContract]
    public class EnrollmentVO
    {
        [DataMember]
        public string StudentID { get; set; }
        [DataMember]
        public string CourseID { get; set; }
        [DataMember]
        public string Grade { get; set; }
    }
}