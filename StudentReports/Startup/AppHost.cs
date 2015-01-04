using Funq;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Caching;
using ServiceStack.Configuration;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Razor;
using StudentReports.Models;
using StudentReports.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace StudentReports.Startup
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("Student report Service", typeof(StudentService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
            Plugins.Add(new RazorFormat());
            Plugins.Add(new AuthFeature(() => new AuthUserSession(), new IAuthProvider[]{
                new CredentialsAuthProvider(),
                new TwitterAuthProvider(new AppSettings())
            }));
            Plugins.Add(new RegistrationFeature());

            var ormLiteConnectionFactory = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["studentDbConn"].ConnectionString,
                                                                            ServiceStack.OrmLite.SqlServer.SqlServerOrmLiteDialectProvider.Instance);

       
            container.Register<IDbConnectionFactory>(ormLiteConnectionFactory);
            container.Register(c => new StudentDbRepository()).ReusedWithin(ReuseScope.Request);

            container.RegisterAutoWired<StudentDbRepository>();

            var repository = new OrmLiteAuthRepository(ormLiteConnectionFactory);
            container.Register<IAuthRepository>(repository);

            using (var db = ormLiteConnectionFactory.Open())
            {
                if (!db.TableExists("UserAuth"))
                {
                    repository.DropAndReCreateTables();                                        
                }

                if (repository.GetUserAuthByUserName("Admin") == null)
                {
                    repository.CreateUserAuth(new UserAuth()
                    {
                        UserName = "Admin",
                        FirstName = "Admin",
                        LastName = "User",
                        DisplayName = "Admin",
                        Roles = new List<string>() { RoleNames.Admin }
                    }, "adminpass");
                }
            }

            DbInitializer.InitializeDb(ormLiteConnectionFactory);
        }
    }
}