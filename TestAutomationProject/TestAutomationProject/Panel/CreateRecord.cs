using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationProject.Utilities;

namespace TestAutomationProject.Panel
{
    public class CreateRecord
    {
        String code = "TestCode";
        String description = "TestDescription";
        String price = "100";

        public void CreateMaterialRecord (IWebDriver driver)
        {
            // Identify the Code field
            IWebElement codeField = driver.FindElement(By.Id("Code"));

            // Type code in the Code field
            codeField.SendKeys(code);

            // Identify the Description field
            IWebElement descriptionField = driver.FindElement(By.Id("Description"));

            // Type description in the Description field
            descriptionField.SendKeys(description);

            // Identify the Price per unit field (Overlap)
            IWebElement pricePerUnitFieldOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));

            // Click the Price per unit field
            pricePerUnitFieldOverlap.Click();

            // Identify the Price per unit field
            IWebElement pricePerUnitField = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));

            // Type price in the Price per unit field
            pricePerUnitField.SendKeys(price);

            // Īdentify the Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));

            // Click the Save button
            saveButton.Click();

        }

        public void CreateTimeRecord (IWebDriver driver)
        {
            // Select Time from dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            
            // Click the TypeCode dropdown
            typeCodeDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 3);

            // Select Time option from dropdown
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            
            // Click the Time option
            timeOption.Click();

            // Identify the Code field
            IWebElement codeField = driver.FindElement(By.Id("Code"));

            // Type code in the Code field
            codeField.SendKeys(code);

            // Identify the Description field
            IWebElement descriptionField = driver.FindElement(By.Id("Description"));

            // Type description in the Description field
            descriptionField.SendKeys(description);

            // Identify the Price per unit field (Overlap)
            IWebElement pricePerUnitFieldOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));

            // Click the Price per unit field
            pricePerUnitFieldOverlap.Click();

            // Identify the Price per unit field
            IWebElement pricePerUnitField = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));

            // Type price in the Price per unit field
            pricePerUnitField.SendKeys(price);

            // Īdentify the Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));

            // Click the Save button
            saveButton.Click();

            // Wait for 1 second
            Thread.Sleep(1000);
        }

        public void VerifyIfRecordWasCreatedSuccessfully(IWebDriver driver)
        {
            // Wait for 10 seconds
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);

            // Identify the last page button
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

            // Click the last page button
            lastPageButton.Click();

            // Wait for 10 seconds
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 10);

            // Identify the last record
            IWebElement lastRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement lastRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement lastRecordPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            if (lastRecordCode.Text == code
                && lastRecordDescription.Text == description
                && lastRecordPrice.Text == "$" + price + ".00")
            {
                Console.WriteLine("Record has been created. Test Passed");
            }
            else
            {
                Console.WriteLine("Record has not been created. Test Failed");
            }
        }
            
    }
}
