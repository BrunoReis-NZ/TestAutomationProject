using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {

        // ## Step 1: Login to the application

        // Open the browser (Chrome)
        IWebDriver driver = new ChromeDriver();

        // Navigate to the URL
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
        driver.Manage().Window.Maximize(); // Maximize the browser window

        // Identify the username field
        IWebElement username = driver.FindElement(By.Id("UserName"));

        // Enter the username
        username.SendKeys("hari");

        // Identify the password field 
        IWebElement password = driver.FindElement(By.Id("Password"));

        // Enter the password
        password.SendKeys("123123");

        // Identify the login button
        IWebElement loginButton = driver.FindElement(By.XPath("//input[@type='submit']"));

        // Click the login button
        loginButton.Click();

        // ## Step 2: Verify that the user has successfully logged in

        // Verify that the user has successfully logged in
        IWebElement userGreeting = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if (userGreeting.Text == "Hello hari!")
        {
            Console.WriteLine("User has successfully logged in. Test Passed");
        }
        else
        {
            Console.WriteLine("User has not successfully logged in. Test Failed");
        }       
        
        // ## Step 3: Navigate to the Time and Material page

        // Navigate to the Time and Material page

        // Identify the Administration tab
        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));

        // Click the Administration tab
        administrationTab.Click();

        // Identify the Time & Materials option
        IWebElement timeAndMaterialsOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));

        // Click the Time & Materials option
        timeAndMaterialsOption.Click();

        // ## Step 4: Create a new Time Record

        // Identify the Create New button
        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));

        // Click the Create New button
        createNewButton.Click();

        // Identify the TypeCode dropdown
        IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));

        // Click the TypeCode dropdown
        typeCodeDropdown.Click();

        // Select Time from the dropdown
        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));

        // Click the Time option
        timeOption.Click();

        // Identify the Code field
        IWebElement codeField = driver.FindElement(By.Id("Code"));

        // Type code in the Code field
        codeField.SendKeys("Test Code");

        // Identify the Description field
        IWebElement descriptionField = driver.FindElement(By.Id("Description"));

        // Type description in the Description field
        descriptionField.SendKeys("Test Description");

        // Identify the Price per unit field (Overlap)
        IWebElement pricePerUnitFieldOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));

        // Click the Price per unit field
        pricePerUnitFieldOverlap.Click();

        // Identify the Price per unit field
        IWebElement pricePerUnitField = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));

        // Type price in the Price per unit field
        pricePerUnitField.SendKeys("100");

        // Īdentify the Save button
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));

        // Click the Save button
        saveButton.Click();
        
        // ## Step 5: Verify that the Time Record has been created

        // Verify that the Time Record has been created

        // Wait for 1 second
        Thread.Sleep(1000);

        // Identify the last page button
        IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

        // Click the last page button
        lastPageButton.Click();

        // Identify the last record
        IWebElement lastRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        IWebElement lastRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
        IWebElement lastRecordPricePerUnit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

        if (lastRecordCode.Text == "Test Code" 
            && lastRecordDescription.Text == "Test Description" 
            && lastRecordPricePerUnit.Text == "$100.00")
        {
            Console.WriteLine("Time Record has been created. Test Passed");
        }
        else
        {
            Console.WriteLine("Time Record has not been created. Test Failed");
        }

        // ## Step 6: Edit a Time Record

        // Identify the last page button
        lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

        // Click the last page button
        lastPageButton.Click();

        // Identify the last record Edit button
        IWebElement lastRecordEditButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));

        // Click the last record Edit button
        lastRecordEditButton.Click();

        // Identify the Code field
        IWebElement toBeEditedCodeField = driver.FindElement(By.Id("Code"));

        // Clear the Code field
        toBeEditedCodeField.Clear();

        // Type code in the Code field
        toBeEditedCodeField.SendKeys("Edited Test Code");

        // Identify the Description field
        IWebElement toBeEditedDescriptionField = driver.FindElement(By.Id("Description"));

        // Clear the Description field
        toBeEditedDescriptionField.Clear();

        // Type description in the Description field
        toBeEditedDescriptionField.SendKeys("Edited Test Description");

        // Identify the Price per unit field (Overlap)
        IWebElement toBeEditedPricePerUnitFieldOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));

        // Click the Price per unit field
        toBeEditedPricePerUnitFieldOverlap.Click();

        // Identify the Price per unit field
        IWebElement toBeEditedPricePerUnitField = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));

        // Clear the Price per unit field
        toBeEditedPricePerUnitField.Clear();

        // Identify the Price per unit field (Overlap)
        toBeEditedPricePerUnitFieldOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));

        // Click the Price per unit field
        toBeEditedPricePerUnitFieldOverlap.Click();

        // Type price in the Price per unit field
        toBeEditedPricePerUnitField.SendKeys("200");

        // Īdentify the Save button
        saveButton = driver.FindElement(By.Id("SaveButton"));

        // Click the Save button
        saveButton.Click();

        // ## Step 7: Verify that the Time Record has been edited

        // Verify that the Time Record has been edited

        // Wait for 1 second
        Thread.Sleep(1000);

        // Identify the last page button
        lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

        // Click the last page button
        lastPageButton.Click();

        // Identify the last record
        lastRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        lastRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
        lastRecordPricePerUnit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

        if (lastRecordCode.Text == "Edited Test Code"
            && lastRecordDescription.Text == "Edited Test Description"
            && lastRecordPricePerUnit.Text == "$200.00")
        {
            Console.WriteLine("Time Record has been edited. Test Passed");
        }
        else
        {
            Console.WriteLine("Time Record has not been edited. Test Failed");
        }

        // ## Step 8: Delete a Time Record

        // Identify the last page button
        lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

        // Click the last page button
        lastPageButton.Click();

        // Identify the last record Delete button
        IWebElement lastRecordDeleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));

        // Click the last record Edit button
        lastRecordDeleteButton.Click();

        // Switch to the alert
        driver.SwitchTo().Alert().Accept();
        
        // ## Step 9: Verify that the Time Record has been deleted

        // Verify that the Time Record has been deleted

        // Wait for 1 second
        Thread.Sleep(1000);

        // Identify the last page button
        lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

        // Click the last page button
        lastPageButton.Click();

        // Identify the last record
        lastRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        lastRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
        lastRecordPricePerUnit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

        if (lastRecordCode.Text != "Edited Test Code"
            || lastRecordDescription.Text != "Edited Test Description"
            || lastRecordPricePerUnit.Text != "$200.00")
        {
            Console.WriteLine("Time Record has been deleted. Test Passed");
        }
        else
        {
            Console.WriteLine("Time Record has not been deleted. Test Failed");
        }

    }
}