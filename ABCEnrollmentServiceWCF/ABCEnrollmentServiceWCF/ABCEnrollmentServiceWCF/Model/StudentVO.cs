﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ABCEnrollmentServiceWCF.Model
{
    [DataContract]
    public class StudentVO
    {
        [DataMember]
        public string StudentID { get; set; }
        [DataMember]
        public string StduentName { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DateEnrolled { get; set; }
    }
}