using MarsSndTask.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MarsSndTask.Global.GlobalDefinitions;
using static MarsSndTask.Global.Base;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace MarsSndTask.Pages.Profile
{
    class Language
    {
        public IWebDriver Driver { get; }
        public Language(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement LangTab => Driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[1]"));
        //Click on Add New button
        public IWebElement AddNew => Driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[11]"));
        //Enter the language
        public IWebElement LangName => Driver.FindElement(By.XPath("//input[@name ='name']"));

        //Click on Add
        public IWebElement LangNamBtn => Driver.FindElement(By.XPath("//input[@value='Add']"));
        public IWebElement UpdateLg => Driver.FindElement(By.XPath("//input[@value='Update']"));
   
        


        public void AddLang()
        {
            #region Add New Language
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileLanguage");
            //click on Language
            LangTab.Click();
            for (int i = 1; i <= 4; i++)
            {
                //Click on Add New button
                AddNew.Click();
                Thread.Sleep(3000);
                //Enter the language
                LangName.SendKeys(ExcelLib.ReadData(i+1, "Language"));
                //Select the language level.
                SelectElement select = new SelectElement(Driver.FindElement(By.XPath("//select[@name ='level']")));
                select.SelectByValue(ExcelLib.ReadData(i + 1, "LanguageLevel"));
                //Click on Add
                LangNamBtn.Click();
            }
            #endregion

        }

        // Update the given Language
        public void UpdateLang()
        {
            #region Update the given Language
            Thread.Sleep(3000);
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileLanguage");
            String expectedValue = ExcelLib.ReadData(2, "Language");
            //Get the table list
            IList<IWebElement> Tablerows = Driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
            //Get the row count in table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row Language name
                String actualValue = Driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the editLanguage Parameter matches with ith row Language name
                if (actualValue.Equals(expectedValue))
                {
                    //CliCk on Edit icon
                    Driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();
                    //Send Language name to update
                    IWebElement editRowValue = Driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    //Clear Previous text 
                    editRowValue.Clear();
                    editRowValue.SendKeys(ExcelLib.ReadData(2, "UpdateLanguage"));
                    //Select Language Level to update
                    var langLevelList = Driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                    var selectElement = new SelectElement(langLevelList);
                    selectElement.SelectByValue(ExcelLib.ReadData(2, "UpdLanguageLevel"));
                    // Click on update button

                    Thread.Sleep(3000);
                    // form/div/div/div/div/table/tbody[" + i +"]/tr/ td[1] / div[1] / span[1] / input[1].Click();
                   
                    Driver.FindElement(By.XPath("//form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[" + i +"]/tr[1]/td[1]/div[1]/span[1]/input[1]")).Click();

                }
                #endregion
            }

        }
        //Delete a given language
        public void DeleteLang()
        {
            #region Delete given language
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileLanguage");
            String expectedValue = ExcelLib.ReadData(2, "DeleteLanguage");
            //Get the table row list
            IList<IWebElement> Tablerows = Driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row LanguageName
                String actualValue = Driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the DeleteLanguage parameter matches with ith Row LanguageName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    Driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();

                }
            }
            #endregion

        }
    }
}
    