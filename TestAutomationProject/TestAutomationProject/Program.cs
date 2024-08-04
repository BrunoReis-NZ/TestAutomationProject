using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAutomationProject.Pages;
using TestAutomationProject.Panel;

public class Program
{
    private static void Main(string[] args)
    {
        // Open the browser (Chrome)
        IWebDriver driver = new ChromeDriver();
        
        // Login page object initialization and definition
        Login login = new();

        // Login page object method call
        login.LoginSteps(driver);

        // Home page object initialization and definition
        Home home = new();

        // Home page object methods call
        home.VerifyIfUserLoggedIn(driver);
        home.NavigateToTimeAndMaterialPage(driver);

        // TimeAndMaterial page object initialization and definition
        TimeAndMaterial timeAndMaterial = new();

        // TimeAndMaterial page object method call
        timeAndMaterial.OpenCreatePage(driver);

        // CreateRecord page object initialization and definition
        CreateRecord createRecord = new();

        // CreateRecord page object methods call
        createRecord.CreateTimeRecord(driver);
        createRecord.VerifyIfRecordWasCreatedSuccessfully(driver);

        // EditRecord page object initialization and definition
        EditRecord editRecord = new();

        // EditRecord page object methods call
        editRecord.editRecord(driver);
        editRecord.verifyIfRecordWasEditedSuccessfully(driver);
        
        // DeleteRecord page object initialization and definition
        DeleteRecord deleteRecord = new();

        // DeleteRecord page object method call
        deleteRecord.deleteRecord(driver);
        deleteRecord.verifyIfRecordWasDeletedSuccessfully(driver);       
    }
}
