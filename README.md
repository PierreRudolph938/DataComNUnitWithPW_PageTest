Microsoft Visual Studio Community 2022 (64-bit) - Version 17.11.5
Playwright ver. 1.48.0
1. Contains Playwright.runsettings to specify browser type and headed/headless
2. TestHelper.cs - start of a helper class
3. override BrowserNewContextOptions ContextOptions() to handle geo location grant/deny
4. AddLocatorHandlerAsync to the Setup routine, to accept cookies
