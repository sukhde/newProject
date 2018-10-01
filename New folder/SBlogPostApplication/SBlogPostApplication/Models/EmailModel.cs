using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBlogPostApplication.Models
{
        public class EmailModel
        {
            [Required, Display(Name = "Name")]
            public string FromName { get; set; }
            [Required, Display(Name = "Email"), EmailAddress]
            public string FromEmail { get; set; }
            [Required,Display (Name = "Subject")]
            public string Subject { get; set; }
            [Required, Display(Name = "Body")]
            public string Body { get; set; }
        }

    }
