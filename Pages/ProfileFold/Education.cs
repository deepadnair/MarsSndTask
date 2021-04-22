using AventStack.ExtentReports;
using MarsSndTask.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MarsSndTask.Global.GlobalDefinitions;
using static MarsSndTask.Global.Base;
using NUnit.Framework;

namespace MarsSndTask.Pages.Profile
{
    class Education
    {
        public IWebDriver Driver { get; }
        public Education(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement EdTab => Driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[3]"));
        public IWebElement AddEdu => Driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[21]"));
        public IWebElement InstName => Driver.FindElement(By.XPath("//input[@name ='instituteName']"));
        public IWebElement Degree => Driver.FindElement(By.XPath("//input[@name='degree']"));
        public IWebElement AddDegrBtn => Driver.FindElement(By.XPath("//input[@value='Add']"));
        public void AddEducation()
        {
            #region Add your Education
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileEducation");
            //click on Education tab
            EdTab.Click();
            IList<IWebElement> Tablerows = Driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= 3; i++)
            {
                //Click on Add New button
                AddEdu.Click();
                Thread.Sleep(3000);
                // Enter collage Name
                InstName.SendKeys(ExcelLib.ReadData(i+1, "University"));
                // Select Country of College
                Thread.Sleep(3000);
                SelectElement selectcountry = new SelectElement(Driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='country']")));
                selectcountry.SelectByValue(ExcelLib.ReadData(i + 1, "CountryOfCollege"));
                Thread.Sleep(3000);
                // Select Title
                SelectElement Title = new SelectElement(Driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='title']")));
                Title.SelectByValue(ExcelLib.ReadData(i + 1, "Title"));
                Thread.Sleep(3000);
                //Enter the Degree
                Degree.SendKeys(ExcelLib.ReadData(i + 1, "Degree"));
                //Select the Year of Passing.
                SelectElement selectYear = new SelectElement(Driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name= 'yearOfGraduation']")));
                selectYear.SelectByValue(ExcelLib.ReadData(i + 1, "YearOfPassing"));
                //Click on Add
                AddDegrBtn.Click();
                #endregion
            }
           
                    }

        public void UpdateEducation()
        {
            #region Update the given Education
            Thread.Sleep(3000);
            // Populate Login page test data collection  
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileEducation");
            String expectedValue = ExcelLib.ReadData(2, "Title");
            //Get the table list
            IList<IWebElement> Tablerows = Driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            //Get the row count in table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row Title
                String actualValue = Driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                //check if the editLanguage Parameter matches with ith row Title
                if (actualValue.Equals(expectedValue))
                {
                    //CliCk on Edit icon
                    Driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[1]/i")).Click();
                    //Send University name to update
                    IWebElement editRowValue = Driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    //Clear Previous text 
                    editRowValue.Clear();
                    editRowValue.SendKeys(ExcelLib.ReadData(i+1, "UpdUniversity"));
                    // update Country of College
                    SelectElement selectcountry = new SelectElement(Driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[1]/div[2]/select")));
                    selectcountry.SelectByValue(ExcelLib.ReadData(i+1, "UpdCountryOfCollege"));
                    // update Title
                    SelectElement Title = new SelectElement(Driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[1]/select")));
                    Title.SelectByValue(ExcelLib.ReadData(i+1, "UpdTitle"));
                    //update the Degree
                    IWebElement EditDegree = Driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[2]/input"));
                    // Clear Previous text
                    EditDegree.Clear();
                    EditDegree.SendKeys(ExcelLib.ReadData(i+1, "UpdDegree"));
                    //update the Year of Passing.
                    SelectElement selectYear = new SelectElement(Driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[3]/select")));
                    selectYear.SelectByValue(ExcelLib.ReadData(i+1, "UpdYearOfPassing"));

                    // Click on update button
                    Driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[3]/input[1]")).Click();
                    #endregion

                    #region validate updated Education
                    try
                    {
                        //Start the Reports
                        test = extent.CreateTest("Edit Education");
                        test.Log(Status.Info, "Editing Education");
                        String expectedValue1 = ExcelLib.ReadData(i+1, "UpdTitle");
                        //Get the table list
                        IList<IWebElement> UpdatedTablerows = Driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
                        //Get the row count in table
                        var UpdatedrowCount1 = UpdatedTablerows.Count;
                        for (var j = 1; j < UpdatedrowCount1; j++)
                        {
                            string actualValue1 = Driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;

                            //Check if expected value is equal to actual value
                            if (expectedValue1 == actualValue1)
                            {
                                test.Log(Status.Pass, "Education updated Successful");
                                SaveScreenShotClass.SaveScreenshot(Driver, "EditEducation");
                                Assert.IsTrue(true);
                            }
                            else
                                test.Log(Status.Fail, "Test Failed");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Thread.Sleep(3000);
                }
            }
            #endregion
        }

        //Delete a given Education
        public void DeleteEdu()
        {
            #region Delete given Education
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileEducation");
            String expectedValue = ExcelLib.ReadData(2, "DeleteUniversity");
            //Get the table row list
            IList<IWebElement> Tablerows = Driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row SkillName
                String actualValue = Driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]")).Text;
                //check if the DeleteSkill parameter matches with ith Row SkillName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    Driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[2]/i")).Click();

                }
            }
            #endregion

            #region validate Deleted Education
            try
            {
                //Start the Reports
                test = extent.CreateTest("Delete Education");
                test.Log(Status.Info, "Deleting Education");
                String expectedValue1 = ExcelLib.ReadData(2, "DeleteUniversity");
                //Get the table list
                IList<IWebElement> UpdatedTablerows = Driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var UpdatedrowCount1 = UpdatedTablerows.Count;
                for (var j = 1; j < UpdatedrowCount1; j++)
                {
                    string actualValue1 = Driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + j + "]/tr/td[2]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue1 != actualValue1)
                    {
                        test.Log(Status.Pass, "Education deleted Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver, "DeleteEducation");
                        Assert.IsTrue(true);
                    }
                    else
                        test.Log(Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
        }
    }
}
#endregion
