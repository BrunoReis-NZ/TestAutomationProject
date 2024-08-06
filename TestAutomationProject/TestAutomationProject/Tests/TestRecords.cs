using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationProject.Pages;
using TestAutomationProject.Panel;
using TestAutomationProject.Utilities;

namespace TestAutomationProject.Tests
{
    [TestFixture]
    public class TestRecords : CommonDriver
    {
        [SetUp]
        public void SetUpTests() 
        {
            // Open the browser (Chrome)
            driver = new ChromeDriver();

            // Login page object initialization and definition
            Login login = new();

            // Login page object method call
            login.LoginSteps(driver);

            // Home page object initialization and definition
            Home home = new();

            // Home page object methods call
            //home.VerifyIfUserLoggedIn(driver);
            home.NavigateToTimeAndMaterialPage(driver);
        }

        [Test, Order(1)]
        public void CreateRecordTest()
        {
            // TimeAndMaterial page object initialization and definition
            TimeAndMaterial timeAndMaterial = new();

            // TimeAndMaterial page object method call
            timeAndMaterial.OpenCreatePage(driver);

            // CreateRecord page object initialization and definition
            CreateRecord createRecord = new();

            // CreateRecord page object methods call
            createRecord.CreateTimeRecord(driver);
            createRecord.VerifyIfRecordWasCreatedSuccessfully(driver);
        }

        [Test, Order(2)]
        public void EditRecordTest()
        {
            // EditRecord page object initialization and definition
            EditRecord editRecord = new();

            // EditRecord page object methods call
            editRecord.editRecord(driver);
            editRecord.verifyIfRecordWasEditedSuccessfully(driver);
        }

        [Test, Order(3)]
        public void DeleteRecordTest()
        {
            // DeleteRecord page object initialization and definition
            DeleteRecord deleteRecord = new();

            // DeleteRecord page object method call
            deleteRecord.deleteRecord(driver);
            deleteRecord.verifyIfRecordWasDeletedSuccessfully(driver);
        }

        [TearDown]
        public void CloseTest()
        {
            // Close the browser
            driver.Quit();

        }

    }
}
