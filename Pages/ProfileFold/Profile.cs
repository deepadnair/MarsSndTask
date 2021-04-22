using MarsSndTask.Config;
using MarsSndTask.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MarsSndTask.Global.GlobalDefinitions;

namespace MarsSndTask.Pages.Profile
{
    class Profile
    {

        public IWebDriver Driver { get; }
        public Profile(IWebDriver driver)
        {
            Driver = driver;
        }
       
        public IWebElement ProfTab => Driver.FindElement(By.LinkText("Profile"));
    
        public IWebElement Availtimeicon => Driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/span[1]/i[1]"));
        public IWebElement Availhouricon => Driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
        public IWebElement AvailTargicon => Driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
        public IWebElement AvailTargetClose => Driver.FindElement(By.XPath("//div[@class='four wide column']//div[4]//div[1]//span[1]//i[1]"));
      //  public IWebElement AvailDesicon => Driver.FindElement(By.CssSelector("h3[class='ui dividing header'] i[class='outline write icon']"));
     //Profile Description 
        public IWebElement AvailDesicon => Driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
        public IWebElement Descriptiontxt => Driver.FindElement(By.XPath("//textarea[@placeholder='Please tell us about any hobbies, additional expertise, or anything else you’d like to add.']"));
        public IWebElement BtnDesSave => Driver.FindElement(By.CssSelector("button[type='button']"));
      //Profile Chat
        public IWebElement Chat => Driver.FindElement(By.XPath(" //a[normalize-space()='Chat']"));
     // SearchSkills
        public IWebElement SrchSkill => Driver.FindElement(By.XPath("(//input[@placeholder='Search skills'])[1]"));
        public IWebElement SrchIcon => Driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]"));
        public IWebElement RefSrchSkil => Driver.FindElement(By.XPath("//div[@class='four wide column']//input[@placeholder='Search skills']"));
        public IWebElement RfSrchIcon => Driver.FindElement(By.XPath("//div[@class='four wide column']//i[@class='search link icon']"));
        public IWebElement SearchUser => Driver.FindElement(By.XPath("//input[@placeholder='Search user']"));
        // Change Password
        public IWebElement Chngpstab => Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
       
        public IWebElement Chngpaslnk => Driver.FindElement(By.LinkText("Change Password"));
        public IWebElement Chngpass => Driver.FindElement(By.XPath("//a[text()='Change Password']"));

        public IWebElement Oldpass => Driver.FindElement(By.XPath("//input[@name='oldPassword']"));
        public IWebElement Newpass => Driver.FindElement(By.XPath("//input[@name='newPassword']"));

        public IWebElement Cnfmpass => Driver.FindElement(By.XPath("//input[@name='confirmPassword']"));
        // click on save button
        public IWebElement PassSave => Driver.FindElement(By.XPath("//button[@type='button' and text()='Save']"));
        
     

        public void ClickProTab()

        {
           
            ProfTab.Click();
        }
       
        public void AvailabiTimeLnk()
        {
            Thread.Sleep(3000);
            Availtimeicon.Click();
            var Worktype = Driver.FindElement(By.Name("availabiltyType"));
            var selectElementh = new SelectElement(Worktype);
            selectElementh.SelectByValue("0");

            Thread.Sleep(5000);
        }
        public void AvailabiHourLnk()
        {
            Availhouricon.Click();
            var Workhour = Driver.FindElement(By.Name("availabiltyHour"));
            var selectElementh = new SelectElement(Workhour);
            selectElementh.SelectByValue("0");
            Thread.Sleep(5000);
        }
        public void AvailabiTargetLnk()
        {

            AvailTargicon.Click();
            var Target = Driver.FindElement(By.Name("availabiltyTarget"));
            var selectElementt = new SelectElement(Target);
            selectElementt.SelectByValue("0");
            Thread.Sleep(5000);

        }
        public void AvailabiDesLnk()
        {
           // AvailDesicon.WaitForElementClickable(Global.Base.driver, 60).Click();
             
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");
            Thread.Sleep(2000);
            AvailDesicon.Click();
            Thread.Sleep(1000);
            Descriptiontxt.SendKeys(Keys.Control + "a");
            Descriptiontxt.SendKeys(Keys.Delete);
            Descriptiontxt.SendKeys(ExcelLib.ReadData(2, "Description"));
            BtnDesSave.Click();
            Thread.Sleep(5000);
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            // verify Description is save successfully 
            Assert.AreEqual(Driver.FindElement(By.XPath("/html/body/div[1]/div")).Text, "Description has been saved successfully");
            Driver.SwitchTo().DefaultContent();

        }

        public void ChangePassword()
        {
            #region Click on ChangePassword
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");
            Thread.Sleep(2000);
            // Navigate to change password page
            Chngpstab.Click();
            Thread.Sleep(2000);
            Chngpaslnk.Click();
            Oldpass.SendKeys(ExcelLib.ReadData(2, "CurrentPassword"));
            Newpass.SendKeys(ExcelLib.ReadData(2, "NewPassword"));
            Thread.Sleep(2000);
            Cnfmpass.SendKeys(ExcelLib.ReadData(2, "CnfPassword"));
            // click on save button
            PassSave.Click();
            Thread.Sleep(5000);
            #endregion
        }

         public void Chatt() => Chat.Click();
        
        public void RefinSrchSkills()
        {
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");
            // Search skills through type keys
            SrchSkill.SendKeys(ExcelLib.ReadData(2, "SearchSkills"));
            //click on search button
            SrchIcon.Click();
            Thread.Sleep(2000);
            RefSrchSkil.SendKeys(ExcelLib.ReadData(2, "RefineSearch"));
            RfSrchIcon.Click();
            Thread.Sleep(2000);
            SearchUser.SendKeys(ExcelLib.ReadData(2, "SearchUser"));
            Thread.Sleep(3000);
            SearchUser.SendKeys(Keys.ArrowDown + Keys.Enter);
            Thread.Sleep(3000);
        }


        public void FilterSerachSkills()
        {
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");
            // Search skills through type keys
            SrchSkill.SendKeys(ExcelLib.ReadData(2, "SearchSkills"));
            //click on search button
            SrchIcon.Click();
        
              RefSrchSkil.SendKeys(ExcelLib.ReadData(2, "RefineSearch"));
            RfSrchIcon.Click();
            // Search skills using filter
            string value1 = ExcelLib.ReadData(2, "FilterButtons");
            string value2 = ExcelLib.ReadData(3, "FilterButtons");
            string value3 = ExcelLib.ReadData(4, "FilterButtons");
            // Click on button
            string Button = Driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]")).Text;
         

            Thread.Sleep(3000);
            for (int i = 1; i <= 3; i++)
            {
                // Click on ith button
                string actualvalue = Driver.FindElement(By.XPath("//div/section/div/div[1]/div[5]/button[" + i + "]")).Text;
                if (actualvalue == value1)
                {
                    Thread.Sleep(3000);
                    Driver.FindElement(By.XPath("//button[normalize-space()='Online']")).Click();
                    Console.WriteLine("Test Passed for Online Filter");
                    Thread.Sleep(2000);
                }
                else if (actualvalue == value2)
                {
                    Thread.Sleep(3000);
                    Driver.FindElement(By.XPath("//button[normalize-space()='Onsite']")).Click();
                    Console.WriteLine("Test Passed for Onsite Filter");
                    Thread.Sleep(2000);
                }
                else if (actualvalue == value3)
                {
                    Thread.Sleep(3000);
                    Driver.FindElement(By.XPath("//button[normalize-space()='ShowAll']")).Click();
                    Console.WriteLine("Test Passed for ShowAll Filter");
                    Thread.Sleep(2000);
                }
            }


        }

    }


}

