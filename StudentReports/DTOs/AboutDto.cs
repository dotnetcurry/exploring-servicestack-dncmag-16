using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentReports.DTOs
{
    [Route("/about")]
    public class AboutDto
    {
        
    }

    public class AboutResponse
    {
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}