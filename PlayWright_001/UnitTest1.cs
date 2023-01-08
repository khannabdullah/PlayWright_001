using Microsoft.Playwright;

namespace PlayWright_001
{
    [TestClass]
    public class UnitTest1 
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 10 });

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            
            //await page.GotoAsync("https://playwright.dev");

            // Stop tracing and export it into a zip archive.
            //// await page.Locator(".header").ScreenshotAsync(new() { Path = "snapshot.png" });

             await page.GotoAsync("https://adactinhotelapp.com/");
             await page.Locator("#username").ScreenshotAsync(new() { Path = "snapshot.png" });
             await page.FillAsync("#username", "Amirtester"); 


             await page.FillAsync("#password", "Amirtester");
             await page.GetByRole(AriaRole.Button, new() { NameString = "Login" }).ClickAsync();

            await context.Tracing.StopAsync(new()
            {
                Path = "trace.zip"
            });
            await page.CloseAsync();
            await browser.CloseAsync();

          


        }
    }
}