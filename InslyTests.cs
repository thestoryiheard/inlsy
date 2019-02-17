using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace DemoWebAppTests
{
    #region Insly tests definition 
    public class InslyTests
    {
        [Fact]
        public void SignUpTest()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("https://signup.insly.com/signup");

                IWebElement title = driver.FindElement(By.XPath("//h1[contains(text(),'Sign up and start using')]"));

                Assert.Equal("Sign up and start using", title.Text);

                IWebElement pageElement = driver.FindElement(By.Id("broker_admin_email"));

                if (pageElement != null)
                {
                    System.Diagnostics.Debug.WriteLine("Element is visible!");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Element is not visible!");
                }

                List<IWebElement> elementList = new List<IWebElement>();
                elementList.AddRange(driver.FindElements(By.XPath("//*[contains(@id, 'broker')]")));

                if(elementList.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("Elements are present");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Elements are not present");
                }

            }

        }

        [Fact]
         public void FillInTests()
         {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("https://signup.insly.com/signup");

                IWebElement companyInput = driver.FindElement(By.Id("broker_name"));

                companyInput.SendKeys("MRK_Company");

                SelectElement countrySelection = new SelectElement (driver.FindElement(By.Name("broker_address_country")));

                countrySelection.SelectByText("Estonia");

                driver.FindElement(By.Id("broker_tag")).SendKeys("testwebsite");

                SelectElement companyProfileSelection = new SelectElement (driver.FindElement(By.Id("prop_company_profile")));

                companyProfileSelection.SelectByText("Software Development Company");

                SelectElement numberOfEmploeeysSelection = new SelectElement (driver.FindElement(By.Id("prop_company_no_employees")));

                numberOfEmploeeysSelection.SelectByText("500 -");

                SelectElement howWouldYouDescYour = new SelectElement (driver.FindElement(By.Id("prop_company_person_description")));

                howWouldYouDescYour.SelectByText("I am a tech guy");



            }
         }
        
    }
}
#endregion