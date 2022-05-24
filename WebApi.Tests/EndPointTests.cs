using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;
using DataAccess.Models;

namespace WebApi.Tests
{
    public class EndPointTests
    {
        private readonly IUserData _userData = Substitute.For<IUserData>();
    
        [Fact]
        public async Task GetUserById_ReturnUser_WhenUserExist()
        {
            //Arrange
            var id = 1;
            var user = new UserModel
            {
                Id = id,
                FirstName = "TestName",
                LastName = "TestSurename"
            };
            _userData.GetUser(Arg.Is(id)).Returns(user);



        }
    }
}
