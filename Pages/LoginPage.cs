using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA_TEST.Pages
{
    internal class LoginPage
    {
        private IPage _page;       

        public LoginPage(IPage page) => _page = page;        

        private ILocator _txtUserName => _page.GetByPlaceholder("Username");

        private ILocator _txtPassword => _page.GetByPlaceholder("Password");

        private ILocator _btnLogin => _page.GetByRole(AriaRole.Button, new() { Name = "Login" });       

        private ILocator _lnkSystemName => _page.GetByRole(AriaRole.Link, new() { Name = "SFA System - Test System" });       

        [Obsolete]
        public async Task ClickLogin()
        {
            await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await _btnLogin.ClickAsync();
            }, new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**/Dashboard1"
            });
        }

        public async Task Login(string username, string password)
        {
            await _txtUserName.ClickAsync();
            await _txtUserName.ClearAsync();
            await _txtUserName.FillAsync(username);
            await _txtPassword.ClickAsync();
            await _txtPassword.ClearAsync();            
            await _txtPassword.FillAsync(password);         
        }       

        public async Task<bool> IsEmployeeDetailsExist() => await _lnkSystemName.IsVisibleAsync();
    }
}
