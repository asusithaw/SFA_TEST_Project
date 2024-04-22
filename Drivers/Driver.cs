using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA_TEST.Drivers
{
    public class Driver : IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;

        public Driver()
        {
            _page = InitializePlaywright();
        }

        public IPage Page => _page.Result;

        private async Task<IPage> InitializePlaywright()
        {
            //Playwright
            var playwright = await Playwright.CreateAsync();
            //Browser
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            //Page
            return await _browser.NewPageAsync();
        }

        public void Dispose() => _browser?.CloseAsync();

    }
}
