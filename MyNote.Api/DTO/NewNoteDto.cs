using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyNote.Api.DTO
{
    public class NewNoteDto
    {
        [Display(Name = "Title"), Required(ErrorMessage = "{0} is requared"), StringLength(100, ErrorMessage = "{0} cannot be longer then {1} characters")]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}