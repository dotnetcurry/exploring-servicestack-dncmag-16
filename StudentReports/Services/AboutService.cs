using ServiceStack;
using StudentReports.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentReports.Services
{
    public class AboutService : Service
    {
        public object Get(AboutDto dto)
        {
            return new AboutResponse() { Name = "Ravi", ModifiedDate = DateTime.Today };
        }
    }
}