using ServiceStack;
using StudentReports.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentReports.Services
{
    public class DataService //:Service
    {
        public object Get(DataReqDto req)
        {
            req.SomeProp = "Some junk in prop!!!";
            return req;
        }
    }
}