﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamificationApp.Shared.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int SubjectTeacher { get; set; }

        [Required(ErrorMessage ="A mező kitöltése kötelező!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public string A { get; set; }

        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public string B { get; set; }

        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public string C { get; set; }

        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public string D { get; set; }

        [Required(ErrorMessage = "A mező kitöltése kötelező!"), StringLength(1, ErrorMessage = "A helyes válasz betűjele 1 karakter lehet!")]
        public string GoodAnswer { get; set; }
        public bool IsApproved { get; set; }
    }
}
