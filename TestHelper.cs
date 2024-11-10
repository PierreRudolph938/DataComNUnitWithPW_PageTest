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
}
