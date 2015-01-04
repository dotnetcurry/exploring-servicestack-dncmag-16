using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentReports.DTOs
{
    [Route("/login", Verbs="GET")]
    public class LoginDto
    {
        public string Redirect { get; set; }
    }
}