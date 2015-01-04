using ServiceStack;
using StudentReports.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentReports.Services
{
    public class LoginService : Service
    {
        public object Get(LoginDto request)
        {
            var session = this.GetSession();
            
            if (session.IsAuthenticated)
            {
                var redirectionUrl = (request.Redirect == string.Empty || request.Redirect == null) ? "students" : request.Redirect;
                return this.Redirect(redirectionUrl);
            }
            
            return request;
        }
    }
}