using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;

namespace DemoWebAppTests
{
    #region Insly tests definition 
    public class InslyTestsTest
    {
        [Fact]
        public void SignUpTest()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                // Start browser in maximized view
                driver.Manage().Window.Maximize();

                // Go to specified URL
                driver.Navigate().GoToUrl("https://signup.insly.com/signup");

                //"Sign up and start using" title is shown

                IWebElement title = driver.FindElement(By.XPath("//h1[contains(text(),'Sign up and start using')]"));

                Assert.Equal("Sign up and start using", title.Text);

                // Check elements on the page
                List<IWebElement> elementList = new List<IWebElement>();
                elementList.AddRange(driver.FindElements(By.XPath("//*[contains(@id, 'broker')]")));

                if(elementList.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("Elements are present");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Some of the specified elements are not present");
                }

                //Fill some random unique name in Company name field

                driver.FindElement(By.Id("broker_name")).SendKeys("MRK_Company");

                // Chose any country
                SelectElement countrySelection = new SelectElement (driver.FindElement(By.Name("broker_address_country")));

                countrySelection.SelectByText("Estonia");

                //Check address e.g. yourname.incly.com

                driver.FindElement(By.Id("broker_tag")).SendKeys("testwebsite");

                // Select any "Company profile"
                SelectElement companyProfileSelection = new SelectElement (driver.FindElement(By.Id("prop_company_profile")));

                companyProfileSelection.SelectByText("Software Development Company");

                // Select any "Number of Employees"
                SelectElement numberOfEmploeeysSelection = new SelectElement (driver.FindElement(By.Id("prop_company_no_employees")));

                numberOfEmploeeysSelection.SelectByText("500 -");

                //Select any "HOW WOULD YOU DESCRIBE YOURSELF?"
                SelectElement howWouldYouDescYour = new SelectElement (driver.FindElement(By.Id("prop_company_person_description")));

                howWouldYouDescYour.SelectByText("I am a tech guy");

                // Fill in "Work e-mail"
                driver.FindElement(By.Id("broker_admin_email")).SendKeys("mykhailo_R@gmail.com");

                //Fill in "Account manager name"
                driver.FindElement(By.Id("broker_admin_name")).SendKeys("TestManger_");

                //Press "suggest a secure password" and remember it
                driver.FindElement(By.LinkText("suggest a secure password")).Click();
                driver.SwitchTo().DefaultContent();
                IWebElement password = driver.FindElement(By.CssSelector(".ui-dialog-buttonset > button:nth-child(1)"));
                driver.FindElement(By.XPath("//div[@class='ui-dialog-buttonset']")).Click();

                //Enter your phone number
                driver.FindElement(By.Id("broker_admin_phone")).SendKeys("0009912");

                //Tick agree terms and conditions (not finished, because I cannot click on Agree button)
                /*
                driver.FindElement(By.XPath("//a[contains(text(),'terms and conditions')]")).Click();
                driver.SwitchTo().DefaultContent();
                IJavaScriptExecutor jsExc = driver as IJavaScriptExecutor;
                jsExc.ExecuteAsyncScript("window.scrollBy(0,950);");
                driver.SwitchTo().DefaultContent();
                driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div/button[1]")).Click();
                 */
                var termsAndConditions = driver.FindElement(By.Id("agree_termsandconditions"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(termsAndConditions);
                actions.Click();
                var agreePrivacyPolicy = driver.FindElement(By.Id("agree_privacypolicy"));
                actions.MoveToElement(termsAndConditions);
                actions.Click();
                var personalData = driver.FindElement(By.Id("agree_data_processing"));
                actions.MoveToElement(personalData);
                actions.Click();

                // Press "Sign up" button

                driver.FindElement(By.Id("submit_save")).Click();

                /*
                 driver.FindElement(By.LinkText("privacy policy")).Click();
                var termsAndConditions= driver.FindElement(By.Id("agree_termsandconditions"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(termsAndConditions);
                var privacyPolicy = driver.FindElement(By.Id("agree_privacypolicy"));
                var dataProcessing = driver.FindElement(By.Id("agree_data_processing"));
                actions.Click();
                 */
               
                
                
                
                
            }

        }
    }
}
#endregion