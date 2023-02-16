using System.Threading.Tasks;
using Teste.Models.TokenAuth;
using Teste.Web.Controllers;
using Shouldly;
using Xunit;

namespace Teste.Web.Tests.Controllers
{
    public class HomeController_Tests: TesteWebTestBase
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