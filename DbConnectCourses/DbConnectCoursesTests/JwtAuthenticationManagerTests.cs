using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbConnectCourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbConnectCourses.Controllers;
using Azure.Identity;

namespace DbConnectCourses.Tests
{
    [TestClass()]
    public class JwtAuthenticationManagerTests
    {
        [TestMethod()]
        public void AuthenticateTest()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("fakekeynotlegit1111!");

            User user = new User
            {
               username = "testusername",
               password = "testpassword!!!"
            };

            var ret = manager.Authenticate(user.username, user.password);

            Assert.IsNull(ret);
        }
    }
}