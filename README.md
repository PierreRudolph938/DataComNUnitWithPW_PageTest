Microsoft Visual Studio Community 2022 (64-bit) - Version 17.11.5
Playwright ver. 1.48.0
1. Contains Playwright.runsettings to specify browser type and headed/headless
2. TestHelper.cs - start of a helper class
3. override BrowserNewContextOptions ContextOptions() to handle geo location grant/deny
4. AddLocatorHandlerAsync to the Setup routine, to accept cookies
5. Important: For VS2022 Community Edition, the runsettings file had to be set following menu: Test > Configure Run Settings > Select Solution-Wide Run Settings File
6. (Test > Test Settings > Processor Architecture (set to Auto Detect) / Test > Processor Architecture for AnyCPU Projects (set to Auto)
