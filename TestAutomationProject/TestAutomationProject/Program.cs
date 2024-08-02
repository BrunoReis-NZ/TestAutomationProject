using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
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

    }
}