﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamificationApp.Shared.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }

        public int SubjectID { get; set; }
        [ForeignKey("SubjectID")]
        public virtual Subject? Subject { get; set; }

        public string Title { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string GoodAnswer { get; set; }
        public bool IsApproved { get; set; }
    }
}
