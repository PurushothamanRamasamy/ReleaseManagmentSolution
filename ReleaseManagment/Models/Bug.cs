using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReleaseManagment.Models
{
    public class Bug
    {
        
        public string Module_Name { get; set; }
        [ForeignKey("Module_Name")]
        public Module module { get; set; }

        [Key]
        public string Module_Id { get; set; }
        public bool Bug_Status{ get; internal set; }

        public string Bug_Description { get; internal set; }

    }
}