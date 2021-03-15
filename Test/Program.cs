using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using MarsSndTask.Global;
using MarsSndTask.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsSndTask.Global.GlobalDefinitions;


namespace MarsSndTask
{
    [TestFixture(BrowserType.Firefox)]
    [TestFixture(BrowserType.Chrome)]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("Sprint1")]
    public class Program : Base
    {
        public Program(BrowserType browser) : base(browser)
        {
        }
        static void Main(string[] args)
        {

        }
        
       
        [Test]
        [Obsolete]
        public void CreatNewSkill()
        {
            //Create Extent Report
            test = extent.CreateTest("ShareSkill");
            test.Log(Status.Info, "Adding ShareSkills");
            // taking Screenshots of adding skills
            SaveScreenShotClass.SaveScreenshot(driver, "ShareSkill");
            // Create Share Skills      
            ShareSkills SKobj = new ShareSkills();
            SKobj.AddNewSkill();

        }

        [Test]
        [Obsolete]
        public void ManageListing()
        {
            //Create Extent Report
            test = extent.CreateTest("ManageListing");
            test.Log(Status.Info, "Managing listing");
            // taking Screenshots of adding skills
            SaveScreenShotClass.SaveScreenshot(driver, "ManageList");
            // Create Share Skills      
            ManageListings MLobj = new ManageListings();
            MLobj.ViewServiceList();
            MLobj.EditServiceList();
            MLobj.DeleteServiceList();
          
        }
       
        }

    }

