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
                                                                               
            var mail = driver.FindElement(By.Id("Email"));                            
            mail.SendKeys("new_user@mail.ru");                                         
            var pass = driver.FindElement(By.Id("Password"));                          
            pass.SendKeys("111111");                                                   
            var confirm = driver.FindElement(By.Id("Confirmpassword"));                
            confirm.SendKeys("111111");                                                
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));       
            var submit = driver.FindElement(By.CssSelector("button.btn.btn-primary")); 
            submit.Click();                                                           
            // driver.SwitchTo().Alert().Accept();                                        
            driver.Close();

            //2. Login: new_user_1test@mail.ru   Pass: 111111 Confirm:111111
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_user_1test@mail.ru");
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("111111");
            submit = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
            submit.Click();
            // driver.SwitchTo().Alert().Accept();
            driver.Close();

            //3. Login: new_user_test.1#expexted@mail.ru   Pass: 111111 Confirm:111111
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_user_test.1#expected@mail.ru");
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("111111");
            submit = driver.FindElement(By.CssSelector("btn btn-primary"));
            submit.Click();
            driver.Close();

            //4. ALERT Login: new_user@test.expexted@@mail.ru   Pass: 111111 Confirm:111111
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_user@test.expected@@mail.ru");
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("111111");
            submit = driver.FindElement(By.CssSelector("btn btn-primary"));
            submit.Click();
            driver.Close();

            //4.1 ALERT Login: new_user@test.expexted@@mail.   Pass: 111111 Confirm:111111
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_user@test.expected@@mail.");
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("111111");
            submit = driver.FindElement(By.CssSelector("btn btn-primary"));
            submit.Click();
            driver.Close();

            //4.2 ALERT Login: new_usertest@mail.   Pass: 111111 Confirm:111111
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_usertest@mail.");
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("111111");
            submit = driver.FindElement(By.CssSelector("btn btn-primary"));
            submit.Click();
            driver.Close();

            //5. ALERT Login: empty   Pass: empty Confirm: empty
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys(null);
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys(null);
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys(null);
            submit = driver.FindElement(By.CssSelector("btn btn-primary"));
            submit.Click();
            driver.Close();

            //6. ALERT Login: new_user1@mail.ru   Pass: empty Confirm: empty
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_user1@mail.ru");
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys(null);
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys(null);
            submit = driver.FindElement(By.CssSelector("btn btn-primary"));
            submit.Click();
            driver.Close();

            //7. ALERT Login: empty   Pass: 111111 Confirm: empty
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys(null);
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys(null);
            submit = driver.FindElement(By.CssSelector("btn btn-primary"));
            submit.Click();
            driver.Close();


            //8. ALERT Login: empty   Pass: 111111 Confirm: 111111
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys(null);
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("111111");
            submit = driver.FindElement(By.CssSelector("btn btn-primary"));
            submit.Click();
            driver.Close();

            //9. ALERT Login: new_user2@mail.ru   Pass: new_user2@mail.ru Confirm: new_user2@mail.ru
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_user2@mail.ru");
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("new_user2@mail.ru");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("new_user2@mail.ru");
            submit = driver.FindElement(By.CssSelector("btn btn-primary"));
            submit.Click();
            driver.Close();


            //10. ALERT Login: empty   Pass: 111111 Confirm: 111111aaa
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys(null);
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("111111aaa");
            submit = driver.FindElement(By.CssSelector("btn btn-primary"));
            submit.Click();
            driver.Close();
        }

   
    }
}
