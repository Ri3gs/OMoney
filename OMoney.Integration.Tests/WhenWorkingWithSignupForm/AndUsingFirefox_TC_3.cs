using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace OMoney.Integration.Tests.WhenWorkingWithSignupForm
{

    [TestFixture]
    public class AndUsingFirefoxTc3
    {
        [Test]
        public void testcase_3()
        {
            //3. Login: new_user_test.1#expexted@mail.ru   Pass: 111111 Confirm:111111

            IWebDriver driver = new FirefoxDriver();

            driver.Url = "http://localhost:4598/#/signup";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            var submit = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
            submit.Click();

            Assert.IsFalse(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            Assert.IsTrue(driver.PageSource.Contains("Обязательное поле"));


            var mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_user_test.1#expexted@mail.ru");
            Assert.IsFalse(driver.PageSource.Contains("Неверный адрес электронной почты"));

            submit.Click();
            Assert.IsFalse(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));


            var pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");

            submit.Click();
            Assert.IsFalse(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            Assert.IsFalse(driver.PageSource.Contains("Неверный адрес электронной почты"));
            Assert.IsTrue(driver.PageSource.Contains("Обязательное поле"));


            var confirm = driver.FindElement(By.Id("Confirmpassword"));
            confirm.SendKeys("111111");
            Assert.IsFalse(driver.PageSource.Contains("Пароли не совпадают"));
            Assert.IsFalse(driver.PageSource.Contains("Неверный адрес электронной почты"));
            Assert.IsFalse(driver.PageSource.Contains("Обязательное поле"));

            submit.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            Assert.IsTrue(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            driver.Close();

            
         
        }


    }
}
