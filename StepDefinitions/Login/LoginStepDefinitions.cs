using Microsoft.Playwright;
using SFA_TEST.Drivers;
using SFA_TEST.Pages;
using System.Reflection;
using TechTalk.SpecFlow.Assist;

namespace SFA_TEST.StepDefinitions.Login
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private readonly Driver _driver;
        private readonly LoginPage _loginPage;

        public LoginStepDefinitions(Driver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver.Page);
        }

        [Given(@"I navigate to Login Info page")]
        public void GivenINavigateToLoginInfoPage()
        {
            _driver.Page.GotoAsync("http://62.171.176.21:801/Login");           
        }

        [Given(@"I enter the following login details")]
        public async Task GivenIEnterTheFollowingLoginDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            string password = (data.Password).ToString();
            await _loginPage.Login((string)data.UserName, password);

            // For Screenshot in Login Page in the screenshots/Login folder
            var currentDirectory = Directory.GetCurrentDirectory();            
            string screenshotFolder = Path.Combine(currentDirectory, "..", "..", "..", "screenshots", "Login");           
            Directory.CreateDirectory(screenshotFolder);            
            string screenshotPath = Path.Combine(screenshotFolder, "Login.jpg");
            await _driver.Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = screenshotPath
            });
        }

        [Given(@"I click the Login button")]
        [Obsolete]
        public async Task GivenIClickTheLoginButton()
        {
            await _loginPage.ClickLogin();
        }

        [Then(@"Successfully Logged into the system")]
        public async Task ThenSuccessfullyLoggedIntoTheSystem()
        {
            var isExist = await _loginPage.IsEmployeeDetailsExist();
            isExist.Should().BeTrue();
        }

    }
}
