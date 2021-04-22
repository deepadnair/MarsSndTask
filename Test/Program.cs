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
using MarsSndTask.Pages.Profile;
using MarsSndTask.Pages.ProfileFold;

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
        public void ProfileLang()
        {
            test = extent.CreateTest("Languages");
            test.Log(Status.Info, "Languages");
            // taking Screenshots of adding Profileskills
            SaveScreenShotClass.SaveScreenshot(driver, "Languages");
          
            // create object for add language
            Language obj = new Language(driver);
            obj.AddLang();
            obj.UpdateLang();
            obj.DeleteLang();
        }
       

        [Test]
        [Obsolete]
        public void ProfileEdu()
        {
            //Create Extent Report
            test = extent.CreateTest("Education");
            test.Log(Status.Info, "Education");
            // taking Screenshots of adding education
            SaveScreenShotClass.SaveScreenshot(driver, "Education");
            
            // create object for add Education
            Education obj = new Education(driver);
            obj.AddEducation();
            obj.UpdateEducation();
            obj.DeleteEdu();
        }
        [Test]
        [Obsolete]
        public void ProfileCer()
        {
            //Create Extent Report
            test = extent.CreateTest("Certificate");
            test.Log(Status.Info, "Certificate");
            // taking Screenshots of adding skills
            SaveScreenShotClass.SaveScreenshot(driver, "Certificate");
            // create object for add Certificate
            Certificate obj = new Certificate(driver);
            obj.AddCertificate();
            obj.UpdateCertificate();
            obj.DeleteCertificate();
        }
        [Test]
        [Obsolete]
        public void ProfileSkill()
        {
         /*   //Create Extent Report
            test = extent.CreateTest("ProfileSkills");
            test.Log(Status.Info, "ProfileSkills");
            // taking Screenshots of adding Profileskills
            SaveScreenShotClass.SaveScreenshot(driver, "ProfileSkills");
            // create object for add ProfileSkills*/

            SkillPage obj = new SkillPage(driver);
            obj.AddSkill();
            obj.UpdateSkill();
            obj.DeleteSkill();
        }

        [Test]
        [Obsolete]
        public void ProfileStatus()
        {
            //Create Extent Report
            test = extent.CreateTest("ProfilePage");
            test.Log(Status.Info, "Profile");
            // taking Screenshots of adding skills
            SaveScreenShotClass.SaveScreenshot(driver, "ProfilePage");
            // create object for ProfilePage
            Profile obj = new Profile(driver);
       //     obj.ClickProTab();
       //     obj.AvailabiTimeLnk();
       //     obj.AvailabiHourLnk();
       //     obj.AvailabiTargetLnk();
       //     obj.AvailabiDesLnk();
         //   obj.ChangePassword();
       //     obj.Chatt();
            obj.RefinSrchSkills();
            obj.FilterSerachSkills();

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

