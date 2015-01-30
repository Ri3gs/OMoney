using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace OMoney.Integration.Tests.WhenWorkingWithSignupForm
{

    [TestFixture]
    public class AndUsingFirefoxTc4
    {
        [Test]
        public void testcase_4()
        {
            //4. ALERT Login: new_user@test.expexted@@mail.ru   Pass: 111111 Confirm:111111

            IWebDriver driver = new FirefoxDriver();

            driver.Url = "http://localhost:4598/#/signup";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            var submit = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
            submit.Click();

            Assert.IsFalse(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            Assert.IsTrue(driver.PageSource.Contains("Обязательное поле"));


            var mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_user@test.expexted@@mail.ru");
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

         
        }


    }
}
