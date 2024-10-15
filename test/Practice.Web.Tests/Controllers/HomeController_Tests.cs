using System.Threading.Tasks;
using Practice.Models.TokenAuth;
using Practice.Web.Controllers;
using Shouldly;
using Xunit;

namespace Practice.Web.Tests.Controllers
{
    public class HomeController_Tests: PracticeWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}