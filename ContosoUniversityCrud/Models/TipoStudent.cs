using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversityCrud.Models
{
    public class TipoStudent
    {
        public int  Cod  { get; set; }

        public string Modalidad { get; set; }
        public string Jornada { get; set; }
        
        public long ID { get; set; }
        public virtual Student Student { get; set; }
    }
}