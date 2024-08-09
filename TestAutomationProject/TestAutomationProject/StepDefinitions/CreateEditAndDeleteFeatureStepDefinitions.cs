using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TestAutomationProject.Pages;
using TestAutomationProject.Panel;
using TestAutomationProject.Utilities;

namespace TestAutomationProject.StepDefinitions
{
    [Binding]
    public class CreateEditAndDeleteFeatureStepDefinitions : CommonDriver
    {
        [Given(@"I login to the TurnUp portal successfully")]
        public void GivenILoginToTheTurnUpPortalSuccessfully()
        {
            // Open the browser (Chrome)
            driver = new ChromeDriver();

            // Login page object initialization and definition
            Login login = new();

            // Login page object method call
            login.LoginSteps(driver);

        }

        [When(@"I navigate to the record page")]
        public void WhenINavigateToTheRecordPage()
        {
            // Home page object initialization and definition
            Home home = new();

            // Home page object methods call
            home.NavigateToTimeAndMaterialPage(driver);
        }

        [When(@"I create a new record with valid data")]
        public void WhenICreateANewRecordWithValidData()
        {
            // TimeAndMaterial page object initialization and definition
            TimeAndMaterial timeAndMaterial = new();

            // TimeAndMaterial page object method call
            timeAndMaterial.OpenCreatePage(driver);

            // CreateRecord page object initialization and definition
            CreateRecord createRecord = new();

            // CreateRecord page object methods call
            createRecord.CreateTimeRecord(driver);
        }

        [Then(@"The record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            // CreateRecord page object initialization and definition
            CreateRecord createRecord = new();

            // Verify if the record was created successfully
            createRecord.VerifyIfRecordWasCreatedSuccessfully(driver);           
        }

        [When(@"I update the'([^']*)', the '([^']*)' and the '([^']*)' on an existing record")]
        public void WhenIUpdateTheOnAndExistingRecord(string editedCode, string editedDescription, string editedPrice)
        {
            // EditRecord page object initialization and definition
            EditRecord editRecord = new();

            // EditRecord page object methods call
            editRecord.editRecord(driver, editedCode, editedDescription, editedPrice);
        }

        [Then(@"The record should have the updated '([^']*)', the '([^']*)' and the '([^']*)' on an existing record")]
        public void ThenTheRecordShouldHaveTheUpdated(string editedCode, string editedDescription, string editedPrice)
        {
            // EditRecord page object initialization and definition
            EditRecord editRecord = new();

            // Verify if the record was edited successfully
            editRecord.verifyIfRecordWasEditedSuccessfully(driver, editedCode, editedDescription, editedPrice);
        }

        [When(@"I delete an existing record")]
        public void WhenIDeleteAnExistingRecord()
        {
            // DeleteRecord page object initialization and definition
            DeleteRecord deleteRecord = new();

            // DeleteRecord page object method call
            deleteRecord.deleteRecord(driver);
        }

        [Then(@"The record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {
            // DeleteRecord page object initialization and definition
            DeleteRecord deleteRecord = new();

            // Verify if the record was deleted successfully
            deleteRecord.verifyIfRecordWasDeletedSuccessfully(driver);
        }

    }
}
