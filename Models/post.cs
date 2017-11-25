using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSapplication.Models
{
    public class post
    {
        [Display(Name ="Post Id")]
        public string Id { get; set; }
        [Display(Name ="Title Of The Post")]
        public string Title { get; set; }
        [Display(Name ="Content Of The Post")]
        public string Content { get; set; }
        [Display(Name ="Date created")]
        public DateTime Created { get; set; }
        [Display(Name ="Date Published")]
        public DateTime? Published { get; set; }
        public int  AuthourId { get; set; }
    }
}