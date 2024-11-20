using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComNUnitWithPW_PageTest
{
    public static class TestHelper
    {
        public static async Task<ILocator> SelectOption(IPage page, string locator, string optionText)
        {
            var howHelp = page.Locator(locator);
            await howHelp.FocusAsync();
            await howHelp.SelectOptionAsync(optionText);

            return howHelp;
        }
    }

    public static class ContactUsComponent
    {
        //Titles
        public static ILocator OurLocationsTitle(IPage page) => page.Locator("h2.cmp-title__text");
        public static ILocator OurLocationsDescription(IPage page) => page.Locator("div.body-text > div.cmp-text p:has-text('Contact one of our global offices')");

        //Region menu locators
        public static ILocator RegionNewZealand(IPage page) => page.Locator("ul > li[data-tab-section-id='.item0']:has-text('New Zealand')");  //Check
        public static ILocator RegionAustralia(IPage page) => page.Locator("ul > li[data-tab-section-id='.item1']:has-text('Australia')");   //Check
        public static ILocator RegionAsia(IPage page) => page.Locator("ul > li[data-tab-section-id='.item2']:has-text('Asia')");

        //Auckland contact detail locators
        public static ILocator AucklandContactsMenuItem(IPage page) => page.Locator("div[region='New Zealand'] > div#section-0 > div.cmp-location__location__name:has-text('Auckland')");
        public static ILocator AucklandAddress(IPage page) => page.Locator("div[region='New Zealand'] > div#section-0 > div > div > p.cmp-location__location__address");
        public static ILocator AucklandPhone(IPage page) => page.Locator("div[region='New Zealand'] > div#section-0 > div > p.cmp-location__location__phone > a.focus-underline-animated");
        public static ILocator AucklandEmail(IPage page) => page.Locator("div[region='New Zealand'] > div#section-0 > div > p.cmp-location__location__email > a.focus-underline-animated");

        //Christchurch contact detail locators
        public static ILocator ChristchurchContactsMenuItem(IPage page) => page.Locator("div[region='New Zealand'] > div#section-1 > div.cmp-location__location__name:has-text('Christchurch')");
        public static ILocator ChristchurchAddress(IPage page) => page.Locator("div[region='New Zealand'] > div#section-1 > div > div > p.cmp-location__location__address");
        public static ILocator ChristchurchPhone(IPage page) => page.Locator("div[region='New Zealand'] > div#section-1 > div > p.cmp-location__location__phone > a.focus-underline-animated");
        public static ILocator ChristchurchEmail(IPage page) => page.Locator("div[region='New Zealand'] > div#section-1 > div > p.cmp-location__location__email > a.focus-underline-animated");

        //Wellington contact detail locators
        public static ILocator WellingtonContactsMenuItem(IPage page) => page.Locator("div[region='New Zealand'] > div#section-9 > div.cmp-location__location__name:has-text('Wellington')");
        public static ILocator WellingtonAddress(IPage page) => page.Locator("div[region='New Zealand'] > div#section-9 > div > div > p.cmp-location__location__address");
        public static ILocator WellingtonPhone(IPage page) => page.Locator("div[region='New Zealand'] > div#section-9 > div > p.cmp-location__location__phone > a.focus-underline-animated");
        public static ILocator WellingtonEmail(IPage page) => page.Locator("div[region='New Zealand'] > div#section-9 > div > p.cmp-location__location__email > a.focus-underline-animated");

        //Adelaide contact detail locators
        public static ILocator AdelaideContactsMenuItem(IPage page) => page.Locator("div[region='Australia'] > div#section-0 > div.cmp-location__location__name:has-text('Adelaide')");
        public static ILocator AdelaideAddress(IPage page) => page.Locator("div[region='Australia'] > div#section-0 > div > div > p.cmp-location__location__address");
        public static ILocator AdelaidePhone(IPage page) => page.Locator("div[region='Australia'] > div#section-0 > div > p.cmp-location__location__phone > a.focus-underline-animated");
        public static ILocator AdelaideEmail(IPage page) => page.Locator("div[region='Australia'] > div#section-0 > div > p.cmp-location__location__email > a.focus-underline-animated");

        //Sydney contact detail locators
        public static ILocator SydneyContactsMenuItem(IPage page) => page.Locator("div[region='Australia'] > div#section-6 > div.cmp-location__location__name:has-text('Adelaide')");
        public static ILocator SydneyAddress(IPage page) => page.Locator("div[region='Australia'] > div#section-6 > div > div > p.cmp-location__location__address");
        public static ILocator SydneyPhone(IPage page) => page.Locator("div[region='Australia'] > div#section-6 > div > p.cmp-location__location__phone > a.focus-underline-animated");
        public static ILocator SydneyEmail(IPage page) => page.Locator("div[region='Australia'] > div#section-6 > div > p.cmp-location__location__email > a.focus-underline-animated");

        //Malayasia contact detail locators
        public static ILocator MalaysiaContactsMenuItem(IPage page) => page.Locator("div[region='Asia'] > div#section-0 > div.cmp-location__location__name:has-text('Malaysia')");
        public static ILocator MalaysiaAddress(IPage page) => page.Locator("div[region='Asia'] > div#section-0 > div > div > p.cmp-location__location__address");
        public static ILocator MalaysiaPhone(IPage page) => page.Locator("div[region='Asia'] > div#section-0 > div > p.cmp-location__location__phone > a.focus-underline-animated");
        public static ILocator MalaysiaEmail(IPage page) => page.Locator("div[region='Asia'] > div#section-0 > div > p.cmp-location__location__email > a.focus-underline-animated");

        //Singapore contact detail locators
        public static ILocator SingaporeContactsMenuItem(IPage page) => page.Locator("div[region='Asia'] > div#section-2 > div.cmp-location__location__name:has-text('Singapore')");
        public static ILocator SingaporeAddress(IPage page) => page.Locator("div[region='Asia'] > div#section-2 > div > div > p.cmp-location__location__address");
        public static ILocator SingaporePhone(IPage page) => page.Locator("div[region='Asia'] > div#section-2 > div > p.cmp-location__location__phone > a.focus-underline-animated");
        public static ILocator SingaporeEmail(IPage page) => page.Locator("div[region='Asia'] > div#section-2 > div > p.cmp-location__location__email > a.focus-underline-animated");

        //Contact Us Dialog
        public static ILocator ContactusButton(IPage page) => page.Locator("div[data-launchid='launchId']", new() { HasText = "Contact us" });
        public static ILocator ThankYouForContactUsDialog(IPage page) => page.GetByRole(AriaRole.Heading, new() { NameString = "Thank you for getting in" });

        public static async Task FillContactUsPage(IPage page)
        {
            await page.GetByLabel("*First name").ClickAsync();
            await page.GetByLabel("*First name").FillAsync("Anton");
            await page.GetByLabel("*Last name").ClickAsync();
            await page.GetByLabel("*Last name").FillAsync("Ohlson");
            await page.GetByLabel("*Business email").ClickAsync();
            await page.GetByLabel("*Business email").FillAsync("anton.Ohlson@yahoo.com");
            await page.GetByLabel("*Phone number").ClickAsync();
            await page.GetByLabel("*Phone number").FillAsync("0210687777");
            await page.GetByLabel("*Job title").ClickAsync();
            await page.GetByLabel("*Job title").FillAsync("QA Analyst");
            await page.GetByLabel("*Company name").ClickAsync();
            await page.GetByLabel("*Company name").FillAsync("ABC");

            await TestHelper.SelectOption(page, "select#Country[aria-labelledby='LblCountry InstructCountry']", "New Zealand");
            await TestHelper.SelectOption(page, "select#State[aria-labelledby='LblState InstructState']", "Christchurch");
            await TestHelper.SelectOption(page, "select#custom2[aria-labelledby='Lblcustom2 Instructcustom2']", "Careers");
            await TestHelper.SelectOption(page, "select#custom5[aria-labelledby='Lblcustom5 Instructcustom5']", "Internship");

            await page.Locator("input#custom7[aria-labelledby='Lblcustom7 Instructcustom7']").FillAsync("QA Analyst");
            await page.GetByLabel("*Company name").FocusAsync();

            var buttonLocator = page.Locator("button[type='submit']", new() { HasText = "Submit" });
            await buttonLocator.ClickAsync();
        }
    }
}
