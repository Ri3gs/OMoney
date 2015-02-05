using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;



namespace OMoney.Integration.Tests.WhenWorkingWithSignupForm
{

    [TestFixture]
    public class AndUsingFirefox
    {
        [Test]
        public void testcase_1()
        {
            //1. Login: new_user@mail.ru   Pass: 111111 Confirm:111111

            IWebDriver driver = new FirefoxDriver();       
                            
            driver.Url = "http://localhost:4598/#/signup";                             
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            var submit = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
            submit.Click();
        
            var mail = driver.FindElement(By.Id("Email"));                            
            mail.SendKeys("new_user@mail.ru");
           
            submit.Click();
           
            var pass = driver.FindElement(By.Id("Password"));                          
            pass.SendKeys("111111");

            submit.Click();
           
            var confirm = driver.FindElement(By.Id("Confirmpassword"));                
            confirm.SendKeys("111111");
           // Assert.IsFalse(driver.PageSource.Contains("Пароли не совпадают"));
          //  Assert.IsFalse(driver.PageSource.Contains("Неверный адрес электронной почты"));
            

            submit.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Assert.IsTrue(driver.FindElement(By.CssSelector("html body.ng-scope div.container div.ng-scope div.ng-scope")).Displayed);
            driver.Close();
                                                    
            

        }

    }
}
