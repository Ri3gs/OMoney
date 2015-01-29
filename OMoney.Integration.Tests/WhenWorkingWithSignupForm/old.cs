using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace OMoney.Integration.Tests.WhenWorkingWithSignupForm
{

    [TestFixture]
    public class AndUsingFirefoxold
    {
        [Test]
        public void testcase_old()
        {
            //6. ALERT Login: new_usertest@.mail.ru   Pass: 111111 Confirm:111111

            IWebDriver driver = new FirefoxDriver();

            driver.Url = "http://localhost:4598/#/signup";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            var submit = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
            submit.Click();

            Assert.IsFalse(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            Assert.IsTrue(driver.PageSource.Contains("Обязательное поле"));


            var mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_usertest@.mail.ru");
            Assert.IsTrue(driver.PageSource.Contains("Неверный адрес электронной почты"));

            submit.Click();
            Assert.IsFalse(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));


            var pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");

            submit.Click();
            Assert.IsFalse(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            Assert.IsTrue(driver.PageSource.Contains("Неверный адрес электронной почты"));
            Assert.IsTrue(driver.PageSource.Contains("Обязательное поле"));


            var confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("111111");
            Assert.IsFalse(driver.PageSource.Contains("Пароли не совпадают"));
            Assert.IsTrue(driver.PageSource.Contains("Неверный адрес электронной почты"));
            Assert.IsFalse(driver.PageSource.Contains("Обязательное поле"));

            submit.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            Assert.IsFalse(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            driver.Close();




            //5. ALERT Login: empty   Pass: empty Confirm: empty
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys(null);
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys(null);
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys(null);
            submit = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
            submit.Click();
            Assert.IsTrue(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            driver.Close();

            //6. ALERT Login: new_user1@mail.ru   Pass: empty Confirm: empty
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_user1@mail.ru");
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys(null);
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys(null);
            submit = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
            submit.Click();
            Assert.IsTrue(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            driver.Close();

            //7. ALERT Login: empty   Pass: 111111 Confirm: empty
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys(null);
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys(null);
            submit = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
            submit.Click();
            Assert.IsTrue(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            driver.Close();


            //8. ALERT Login: empty   Pass: 111111 Confirm: 111111
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys(null);
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("111111");
            submit = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
            submit.Click();
            Assert.IsTrue(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            driver.Close();

            //9. ALERT Login: new_user2@mail.ru   Pass: new_user2@mail.ru Confirm: new_user2@mail.ru
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_user2@mail.ru");
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("new_user2@mail.ru");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("new_user2@mail.ru");
            submit = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
            submit.Click();
            Assert.IsTrue(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            driver.Close();


            //10. ALERT Login: empty   Pass: 111111 Confirm: 111111aaa
            driver = new FirefoxDriver();
            driver.Url = "http://localhost:4598/#/signup";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys(null);
            pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");
            confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("111111aaa");
            submit = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
            submit.Click();
            Assert.IsTrue(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            driver.Close();
        }


    }
}
