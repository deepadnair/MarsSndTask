using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using MarsSndTask.Config;
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
using AventStack.ExtentReports.Reporter;
using static MarsSndTask.Global.Base;


namespace MarsSndTask.Pages.Profile
{
    public class Certificate
    {
        public IWebDriver Driver { get; }
        public Certificate(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement CertTab => Driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[4]"));
        //Click on Add New button
        public IWebElement AddCert => Driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[26]"));
        // Enter Certificate Name
        public IWebElement CertNam => Driver.FindElement(By.XPath("//input[@name ='certificationName']"));
        // Enter Certified from
        public IWebElement CertFrm => Driver.FindElement(By.XPath("//input[@name ='certificationFrom']"));

        //Click on Add
        public IWebElement AddCerbtn => Driver.FindElement(By.XPath("//input[@value='Add']"));

        public void AddCertificate()
        {
            #region Add Certificate
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileCertificate");
                CertTab.Click();
          
              for (int i = 1; i <= 3; i++)
                {
                    //Click on Add New button
                    AddCert.Click();
                Thread.Sleep(2000);
                // Enter Certificate Name
                CertNam.SendKeys(ExcelLib.ReadData(i + 1, "Certificate"));
                    // Enter Certified from
                CertFrm.SendKeys(ExcelLib.ReadData(i + 1, "Certifiedfrom"));
                    // Select Year
                SelectElement Title = new SelectElement(Driver.FindElement(By.XPath("//select[@name ='certificationYear']")));
                Title.SelectByValue(ExcelLib.ReadData(i + 1, "Year"));
           
                //Click on Add
                AddCerbtn.Click();
                Thread.Sleep(3000);
                }
            String ActualCert = Driver.FindElement(By.XPath("//td[contains(text(),'Test Analyst')]")).Text;
            Assert.AreEqual(ActualCert, ExcelLib.ReadData(2, "Certificate"));
            Console.WriteLine("Certificate" + " " + ActualCert + " " + "is added");

            String ActualCert1 = Driver.FindElement(By.XPath("//td[contains(text(),'ISTQB')]")).Text;
            Assert.AreEqual(ActualCert1, ExcelLib.ReadData(3, "Certificate"));
            Console.WriteLine("Certificate" + " " + ActualCert1 + " " + "is added");

            String ActualCert2 = Driver.FindElement(By.XPath("//td[contains(text(),'ScrumMaster')]")).Text;
            Assert.AreEqual(ActualCert2, ExcelLib.ReadData(4, "Certificate"));
            Console.WriteLine("Certificate" + " " + ActualCert2 + " " + "is added");
            #endregion
        }
        public void UpdateCertificate()
        {
            #region Update the given Certificate
            Thread.Sleep(3000);
            // Populate Login page test data collection  
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileCertificate");
            String expectedValue = ExcelLib.ReadData(2, "Certificate");
            Console.WriteLine("ExpectedValue is:" + expectedValue);
            //Get the table list
             IList <IWebElement> Tablerows = Driver.FindElements(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody/tr"));
            //Get the row count in table
              var rowCount = Tablerows.Count;
              for (var i = 1; i < rowCount; i++)
            //    for (int i = 1; i <= 6; i++)
                 {
                //Get the xpath of ith row Certificate
               
                String actualValue = Driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                Console.WriteLine("ActualValue is:"+ actualValue);
                //check if the edit certificate Parameter matches with ith row Title
                if (actualValue.Equals(expectedValue))
                {
                    //CliCk on Edit icon
                    Driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[4]/span[1]/i")).Click();
                    // Update Certificate Name
                    IWebElement Certificate = Driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td/div/div/div[1]/input"));
                    Certificate.Clear();
                    Certificate.SendKeys(ExcelLib.ReadData(2, "UpdCertificate"));
                    // Update Certified from
                    IWebElement CertifiedFrom = Driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td/div/div/div[2]/input"));
                    CertifiedFrom.Clear();
                    CertifiedFrom.SendKeys(ExcelLib.ReadData(2, "UpdCertifiedFrom "));
                    // Update Year
                    SelectElement Year = new SelectElement(Driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td/div/div/div[3]/select")));
                    Year.SelectByValue(ExcelLib.ReadData(2, "UpdYear"));
                    // Click on update button
                    Driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]")).Click();

                }
            }
            #endregion
        }

        //Delete a given Certificate
        
        public void DeleteCertificate()
        {
            #region Delete given Certificate
            Thread.Sleep(3000);
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileCertificate");
            String expectedValue = ExcelLib.ReadData(2, "DeleteCertificate");
            //Get the table row list
            IList<IWebElement> Tablerows = Driver.FindElements(By.XPath("//form/div[5]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row Certificate name
                String actualValue = Driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the DeleteCertificete parameter matches with ith Row CertificateName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                  Driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[4]/span[2]/i")).Click();

                }
            }
            #endregion


        }
    }
}

