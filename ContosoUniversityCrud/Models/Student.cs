using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversityCrud.Models
{
    public class Student
    {
        public long ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int Active { get; set; } = 1;

        public virtual ICollection<TipoStudent> TipoStudents  { get; set;}

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}