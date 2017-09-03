using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace JS.ProjectBase
{
    public class CreateProjectContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
    public static class UserDetails
    {

        public static bool AddUser()
        {
            try
            {
                using (var db = new CreateProjectContext())
                {
                    var user = new User();
                    user.UserID = "1";
                    user.UserName = "Test";
                    db.Users.Add(user);
                    db.SaveChanges();

                    return true;
                }
            }
            catch(Exception ex)
            {

            }

            return false;
        }
        public static void  PrintUser()
        {
            using (var db = new CreateProjectContext())
            {
                var query = from b in db.Users
                            orderby b.UserName
                            select b;


                foreach (var item in query)
                {
                    Console.WriteLine(item.UserName);
                }

            }


        }
    }

}
