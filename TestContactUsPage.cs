using Microsoft.Playwright;
using NUnit.Framework.Interfaces;
using System;
using System.Data;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataComNUnitWithPW_PageTest
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions()
            {
                ColorScheme = ColorScheme.Light,
                ViewportSize = new()
                {
                    Width = 1920,
                    Height = 1080
                },
                Locale = "en-US",                                       //added to be similar to base class
                //Permissions = new[] { "geolocation" },                //Grant Geo permissions
                Permissions = Array.Empty<string>(),                    //Deny Geo permissions
                //BaseURL = "https://datacom.com/nz/en/contact-us",     //change base URL

            };
        }

        [SetUp]
        public async Task Setup()
        {
            //Setup detail
            await Page.GotoAsync("https://datacom.com/nz/en/contact-us");

            await Page.AddLocatorHandlerAsync(Page.Locator("div#onetrust-policy"),
                async () =>
                {
                    await Page.Locator("button#onetrust-accept-btn-handler", new() { HasText = "Accept all" }).ClickAsync();
                });
        }

        [TearDown]
        public async Task Teardown()
        {
            //Close down detail
            await Page.CloseAsync();
        }

        [Test]
        public async Task TestLoadOurLocations()
        {
            //await Page.GotoAsync("https://datacom.com/nz/en/contact-us");

            //Main Logo
            var logoLocator = Page.Locator("img[alt='Datacom logo']");
            await Expect(logoLocator).ToBeVisibleAsync();
            await Expect(logoLocator).ToHaveAttributeAsync("src", "https://assets.datacom.com/is/content/datacom/Datacom-Primary-Logo-RGB?$header-mega-logo$");

            //Header Our Locations and text description
            var locationHdrLocator = Page.Locator("h2.cmp-title__text");
            await Expect(locationHdrLocator).ToBeVisibleAsync();

            var locationText = Page.Locator("div.cmp-text p:has-text('Contact one of our global offices')");
            await Expect(locationText).ToContainTextAsync("Contact one of our global offices or one of our teams to find out more about how we can help you, or to answer any query you may have.");

            //Location tab elements - New Zealand, Australia, Asia
            var defaultLocation = Page.Locator("li.cmp-location__nav__items__item[data-tab-section-id='.item0']");
            await Expect(defaultLocation).ToHaveTextAsync("New Zealand");
            await Expect(defaultLocation).ToHaveClassAsync("cmp-location__nav__items__item active focus-border-bottom");
            await Expect(defaultLocation).ToBeVisibleAsync();
        }

        [Test]
        public async Task TestNewZealandContactDetail()
        {
            //Adress detail in New Zealand list
            var addressLocator = Page.Locator("div.item0.cmp-location__location[region = 'New Zealand'] >> p.cmp-location__location__address");
            await Expect(addressLocator).ToHaveCountAsync(10);
            await Expect(addressLocator.First).ToHaveTextAsync("58 Gaunt Street, Auckland CBD, Auckland 1010");
            await Expect(addressLocator.Nth(1)).ToHaveTextAsync("67 Gloucester Street, Christchurch 8013");
            await Expect(addressLocator.Nth(2)).ToHaveTextAsync("Level 1, 77 Vogel Street, Dunedin 9011");
            await Expect(addressLocator.Nth(3)).ToHaveTextAsync("Level 2, 94 Bryce Street, Hamilton 3204");
            await Expect(addressLocator.Nth(4)).ToHaveTextAsync("2/117 Heretaunga Street East, Hastings 4122");
            await Expect(addressLocator.Nth(5)).ToHaveTextAsync("Level 1, 190 Trafalgar Street, Nelson 7010");
            await Expect(addressLocator.Nth(6)).ToHaveTextAsync("Level 1, 2 Devon Street East, New Plymouth 4310");
            await Expect(addressLocator.Nth(7)).ToHaveTextAsync("8 Railway Road, Rotorua 3015");
            await Expect(addressLocator.Nth(8)).ToHaveTextAsync("15-17 Harington Street, Tauranga 3110");
            await Expect(addressLocator.Nth(9)).ToHaveTextAsync("55 Featherston Street, Pipitea, Wellington 6011,");

            //Phone detail in New Zealand list
            var phoneLocator = Page.Locator("div.item0.cmp-location__location[region = 'New Zealand'] >> p.cmp-location__location__phone");
            await Expect(phoneLocator).ToHaveCountAsync(10);
            await Expect(phoneLocator.First).ToHaveTextAsync("+64 9 303 1489");
            await Expect(phoneLocator.Nth(1)).ToHaveTextAsync("+64 3 379 7775");
            await Expect(phoneLocator.Nth(2)).ToHaveTextAsync("+64 3 379 7775");
            await Expect(phoneLocator.Nth(3)).ToHaveTextAsync("+64 7 834 1666");
            await Expect(phoneLocator.Nth(4)).ToHaveTextAsync("+64 6 835 0793");
            await Expect(phoneLocator.Nth(5)).ToHaveTextAsync("+64 3 546 5558");
            await Expect(phoneLocator.Nth(6)).ToHaveTextAsync("+64 7 834 1666");
            await Expect(phoneLocator.Nth(7)).ToHaveTextAsync("+64 7 834 1666");
            await Expect(phoneLocator.Nth(8)).ToHaveTextAsync("+64 7 834 1666");
            await Expect(phoneLocator.Nth(9)).ToHaveTextAsync("+64 4 460 1500");

            //Email detail in New Zealand list
            var emailLocator = Page.Locator("div.item0.cmp-location__location[region = 'New Zealand'] >> p.cmp-location__location__email");
            await Expect(emailLocator).ToHaveCountAsync(10);
            await Expect(emailLocator.First).ToHaveTextAsync("reception.gaunt@datacom.co.nz");
            await Expect(emailLocator.Nth(1)).ToHaveTextAsync("reception.christchurch@datacom.co.nz");
            await Expect(emailLocator.Nth(2)).ToHaveTextAsync("reception.christchurch@datacom.co.nz");
            await Expect(emailLocator.Nth(3)).ToHaveTextAsync("reception.hamilton@datacom.co.nz");
            await Expect(emailLocator.Nth(4)).ToHaveTextAsync("reception.hamilton@datacom.co.nz");
            await Expect(emailLocator.Nth(5)).ToHaveTextAsync("reception.nelson@datacom.co.nz");
            await Expect(emailLocator.Nth(6)).ToHaveTextAsync("reception.hamilton@datacom.co.nz");
            await Expect(emailLocator.Nth(7)).ToHaveTextAsync("reception.hamilton@datacom.co.nz");
            await Expect(emailLocator.Nth(8)).ToHaveTextAsync("reception.tauranga@datacom.co.nz");
            await Expect(emailLocator.Nth(9)).ToHaveTextAsync("reception.wellington@datacom.co.nz");
        }

        [Test]
        public async Task TestAustraliaContactDetail()
        {
            //Adress detail in Australia list
            var addressLocator = Page.Locator("div.item1.cmp-location__location[region = 'Australia'] >> p.cmp-location__location__address");
            await Expect(addressLocator).ToHaveCountAsync(8);
            await Expect(addressLocator.First).ToHaveTextAsync("118 Franklin Street, Adelaide, South Australia 5000");
            await Expect(addressLocator.Nth(1)).ToHaveTextAsync("501 Ann Street, Fortitude Valley, Brisbane, Queensland 4006");
            await Expect(addressLocator.Nth(2)).ToHaveTextAsync("Level 12, Civic Quarter, 68 Northbourne Ave, Canberra, ACT 2601");
            await Expect(addressLocator.Nth(3)).ToHaveTextAsync("Level 11, Two Melbourne Quarter, 697 Collins Street, Docklands, Victoria 3008");
            await Expect(addressLocator.Nth(4)).ToHaveTextAsync("100 Smart Road, Modbury, South Australia 5092");
            await Expect(addressLocator.Nth(5)).ToHaveTextAsync("Level 11, 66 St. George's Terrace, Perth, Western Australia 6000");
            await Expect(addressLocator.Nth(6)).ToHaveTextAsync("Level 31, 1 Denison Street, North Sydney, Sydney, NSW 2060");
            await Expect(addressLocator.Nth(7)).ToHaveTextAsync(new Regex(@"^\s*Lot 2, 264-278 Woolcock Street, Townsville, Queensland 4810\s*$"));    //Returns leading and trailing whitespace on thsi element

            //Phone detail in Australia list
            var phoneLocator = Page.Locator("div.item1.cmp-location__location[region = 'Australia'] >> p.cmp-location__location__phone");
            await Expect(phoneLocator).ToHaveCountAsync(8);
            await Expect(phoneLocator.First).ToHaveTextAsync("+61 8 7221 7900");
            await Expect(phoneLocator.Nth(1)).ToHaveTextAsync("+61 7 3842 8888");
            await Expect(phoneLocator.Nth(2)).ToHaveTextAsync("+61 2 6112 0200");
            await Expect(phoneLocator.Nth(3)).ToHaveTextAsync("+61 3 9626 9600");
            await Expect(phoneLocator.Nth(4)).ToHaveTextAsync("+61 8 8164 7600");
            await Expect(phoneLocator.Nth(5)).ToHaveTextAsync("+61 8 6466 6888");
            await Expect(phoneLocator.Nth(6)).ToHaveTextAsync("+61 2 9023 5000");
            await Expect(phoneLocator.Nth(7)).ToHaveTextAsync("+61 7 4728 7800");

            //Email detail in Australia list
            var emailLocator = Page.Locator("div.item1.cmp-location__location[region = 'Australia'] >> p.cmp-location__location__email");
            await Expect(emailLocator).ToHaveCountAsync(8);
            await Expect(emailLocator.First).ToHaveTextAsync("contactsa@datacom.com.au");
            await Expect(emailLocator.Nth(1)).ToHaveTextAsync("qldsales@datacom.com.au");
            await Expect(emailLocator.Nth(2)).ToHaveTextAsync("contactact@datacom.com.au");
            await Expect(emailLocator.Nth(3)).ToHaveTextAsync("vic-reception@datacom.com.au");
            await Expect(emailLocator.Nth(4)).ToHaveTextAsync("reception.adel@datacom.com.au");
            await Expect(emailLocator.Nth(5)).ToHaveTextAsync("wa.clientservices@datacom.com.au");
            await Expect(emailLocator.Nth(6)).ToHaveTextAsync("reception.denison@datacom.com.au");
            await Expect(emailLocator.Nth(7)).ToHaveTextAsync("townsville@datacom.com.au");
        }

        [Test]
        public async Task TestAsiaRegionalContactNavigation()
        {
            var listItem = Page.Locator("ul.cmp-location__nav__items > li[data-tab-section-id='.item2']").Filter(new() { HasText = "Asia" });
            await listItem.ClickAsync();
            await Expect(Page.GetByText("Level 3A, 1 Sentral, Jalan Rakyat")).ToBeVisibleAsync();

            var singaporeContact = Page.Locator("div.item2[region='Asia'] > div#section-2 > div.cmp-location__location__name.focus-outline-no-offset-location");
            await singaporeContact.ClickAsync();

            await Expect(Page.GetByText("38 Beach Road, South Beach Tower, #29-11 Singapore 189767")).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "+60 3 2109 1000" }).First).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "+60 3 2109 1000" }).Nth(1)).ToBeVisibleAsync();
            await Expect(Page.GetByText("felicisimo.gadaingan@datacom.com.au")).ToBeVisibleAsync();
        }

        [Test]
        public async Task TestContactUs()
        {
            var contactUs = Page.Locator("div[data-launchid='launchId']", new() { HasText = "Contact us" });
            await contactUs.ClickAsync();

            await Page.GetByLabel("*First name").ClickAsync();
            await Page.GetByLabel("*First name").FillAsync("Anton");
            await Page.GetByLabel("*Last name").ClickAsync();
            await Page.GetByLabel("*Last name").FillAsync("Ohlson");
            await Page.GetByLabel("*Business email").ClickAsync();
            await Page.GetByLabel("*Business email").FillAsync("anton.Ohlson@yahoo.com");
            await Page.GetByLabel("*Phone number").ClickAsync();
            await Page.GetByLabel("*Phone number").FillAsync("0210687777");
            await Page.GetByLabel("*Job title").ClickAsync();
            await Page.GetByLabel("*Job title").FillAsync("QA Analyst");
            await Page.GetByLabel("*Company name").ClickAsync();
            await Page.GetByLabel("*Company name").FillAsync("ABC");

            await TestHelper.SelectOption(Page, "select#Country[aria-labelledby='LblCountry InstructCountry']", "New Zealand");
            await TestHelper.SelectOption(Page, "select#State[aria-labelledby='LblState InstructState']", "Christchurch");
            await TestHelper.SelectOption(Page, "select#custom2[aria-labelledby='Lblcustom2 Instructcustom2']", "Careers");
            await TestHelper.SelectOption(Page, "select#custom5[aria-labelledby='Lblcustom5 Instructcustom5']", "Internship");

            await Page.Locator("input#custom7[aria-labelledby='Lblcustom7 Instructcustom7']").FillAsync("QA Analyst");
            await Page.GetByLabel("*Company name").FocusAsync();

            var buttonLocator = Page.Locator("button[type='submit']", new() { HasText = "Submit" });
            await buttonLocator.ClickAsync();

            await Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = "Thank you for getting in" })).ToBeVisibleAsync();
            await Page.GetByRole(AriaRole.Link, new() { NameString = "Return to homepage" }).ClickAsync();

            var logoLocator = Page.Locator("img[alt='Datacom logo']");
            await Expect(Page.Locator("img[alt='Datacom logo']")).ToBeVisibleAsync();
            //await Expect(Page.GetByRole(AriaRole.Link, new() { NameString = "Datacom logo" })).ToBeVisibleAsync();  //Alternative
        }

        [Test]
        public async Task TestSignOn()
        {
            var signInButton = Page.Locator("a[data-launchid='launchId'][href='/nz/en/sign-in']:has-text('Sign in')");
            await signInButton.ClickAsync();

            var signInHdr = Page.Locator("div.cmp-title h2.cmp-title__text:has-text('Sign in to Datacom')");
            await Expect(signInHdr).ToBeVisibleAsync();
            var signInHdrDescription = Page.Locator("div.body-text.text >> div.cmp-text >> p").Nth(2);
            await Expect(signInHdrDescription).ToHaveTextAsync("Get access to Datacom's payroll applications and specific marketplace platforms for your region.");

            //Filtering on { HasText = "Direct Access Direct Access" } will be better than using the index.
            var directAxisSignIn = Page.Locator("a[href = 'https://datacomdirectaccess.co.nz/login'][adobe-analytics = 'SignInPortalClicked']").Nth(1);
            //var filteredButton = directAxisSignIn.Filter(new() { HasText = "Sign in" });
            await directAxisSignIn.ClickAsync();

            await Page.GetByPlaceholder("Username").ClickAsync();
            await Page.GetByPlaceholder("Username").FillAsync("WongUser");
            await Page.GetByPlaceholder("Password").ClickAsync();
            await Page.GetByPlaceholder("Password").FillAsync("WrongPassword");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Log In" }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();
        }

        [Test]
        public async Task TestAsiaDefaultMalaysiaNavigation_BDD()
        {
            // Given: The user is on the contact-us page (https://datacom.com/nz/en/contact-us).
            var locationsTitle = Page.Locator("h2.cmp-title__text");
            await Expect(locationsTitle).ToBeVisibleAsync();
            await Expect(locationsTitle).ToHaveTextAsync("Our locations");
            Assert.That(await Page.TitleAsync(), Is.EqualTo("Contact Us — Get In Touch"));

            // When: The user clicks Asia.
            var regionsAsia = Page.Locator("ul > li[data-tab-section-id='.item2']:has-text('Asia')");
            await regionsAsia.ClickAsync();

            // Then: The Malasian contact details should be shown.
            var malaysiaAddress = Page.Locator("#section-0 > div:has-text('Malaysia')");
            await Expect(malaysiaAddress).ToBeVisibleAsync();
            var addressMalaysia = Page.Locator("div[region='Asia'] > div#section-0 > div > div > p.cmp-location__location__address");
            await Expect(addressMalaysia).ToHaveTextAsync("Level 3A, 1 Sentral, Jalan Rakyat, Kuala Lumpur Sentral, Kuala Lumpur 50470");
        }

        [Test]
        public async Task TestAsiaSingaporeNavigation_BDD()
        {
            // (https://datacom.com/nz/en/contact-us)
            // Given: The user is on the contact-us page and has navigated to Asia, showing the Malalsian contact details and the Asia contact options. 
            var regionsAsia = Page.Locator("ul > li[data-tab-section-id='.item2']:has-text('Asia')");
            await regionsAsia.ClickAsync();

            // When: The user clicks on Singapore.   //div[region='Asia'] > div#section-2 > div:has-text('Singapore')
            var singaporeContacts = Page.Locator("div[region='Asia'] > div#section-2 > div.cmp-location__location__name:has-text('Singapore')");
            await singaporeContacts.ClickAsync();

            // Then: The Singapore address, phone and email details should be shown.
            //div#section-2.cmp-location__location-container div.cmp-location__location__details
            var singaporeAddress = Page.Locator("div.cmp-location__location__details > div > p.cmp-location__location__address:has-text('38 Beach Road, South Beach Tower, #29-11 Singapore 189767')");
            await Expect(singaporeAddress).ToBeVisibleAsync();
            var singaporePhone = Page.Locator("div.cmp-location__location__details > p.cmp-location__location__phone > a.focus-underline-animated:Has-Text('+60 3 2109 1000')");
            await Expect(singaporePhone).ToBeVisibleAsync();
            var singaporeEmail = Page.Locator("div.cmp-location__location__details > p.cmp-location__location__email > a.focus-underline-animated:Has-Text('felicisimo.gadaingan@datacom.com.au')");
            await Expect(singaporeEmail).ToBeVisibleAsync();
        }
    }
}

