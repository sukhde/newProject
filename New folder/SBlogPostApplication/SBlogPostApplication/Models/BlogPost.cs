using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBlogPostApplication.Models
{
    public class BlogPost
    {
        public BlogPost()

        {
            this.Created = DateTime.Now;
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public string MediaURL { get; set; }
        public bool Published { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }


    }
}