﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using MarsSndTask.Pages;
using System;
using static MarsSndTask.Global.GlobalDefinitions;
using MarsSndTask.Config;
using OpenQA.Selenium.Edge;

namespace MarsSndTask.Global
{
    public enum BrowserType
    {
        Firefox,
        Chrome,
         
    }

    [TestFixture]
    public class Base
    {
        private BrowserType _BrowserType;
        public Base(BrowserType browser)
        {
            _BrowserType = browser;
        }
        // Initialize the browser
        public static IWebDriver driver { get; set; }
        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;

        #endregion

        #region setup and tear down
        [SetUp]
        [Obsolete]
        public void InititalizeTest()
        {
            ChooseBrowser(_BrowserType);

            void ChooseBrowser(BrowserType browserType)
            {
                if (browserType == BrowserType.Firefox)
                {
                    driver = new FirefoxDriver();
                }
                else if (browserType == BrowserType.Chrome)
                {
                    driver = new ChromeDriver();
                }
               
            }
            #region Initialize Reports 
            if (extent == null)
            {
                string reportPath = MarsResources.ReportPath;
                string reportFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(".", "_");
                htmlReporter = new ExtentHtmlReporter(reportPath + reportFile);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddTestRunnerLogs(reportPath + "Extent Config.xml");
            }
            #endregion

            #region          
            // Maximize browser
            driver.Manage().Window.Maximize();
            // Navigate to Url
            driver.Navigate().GoToUrl(MarsResources.Url);
            #endregion

            if (MarsResources.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.SignInStep(driver);
            }
            else
            {
                SignUp signUp = new SignUp();
                signUp.register();
            }

                  
        } 

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                // Screenshot
                String img = SaveScreenShotClass.SaveScreenshot(driver, "Report");
                test.Log(Status.Error, "Image example: " + img);
            }
            // end test. (Reports)
            extent.RemoveTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :)   
          
            driver.Close();
        }
        #endregion
    }
}



