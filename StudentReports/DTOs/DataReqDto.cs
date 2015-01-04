using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentReports.DTOs
{
    [Route("/datareq", Verbs="GET")]
    public class DataReqDto
    {
        public string SomeProp { get; set; }
    }
}