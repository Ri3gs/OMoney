using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace OMoney.Integration.Tests.WhenWorkingWithSignupForm
{

    [TestFixture]
    public class AndUsingFirefoxTc8
    {
        [Test]
        public void testcase_8()
        {
            //8. ALERT Login: new_user@mail.ru   Pass: 111111  Confirm:empty

            IWebDriver driver = new FirefoxDriver();

            driver.Url = "http://localhost:4598/#/signup";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            var submit = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
            submit.Click();

            Assert.IsFalse(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            Assert.IsTrue(driver.PageSource.Contains("Обязательное поле"));


            var mail = driver.FindElement(By.Id("Email"));
            mail.SendKeys("new_user@mail.ru");
            Assert.IsFalse(driver.PageSource.Contains("Неверный адрес электронной почты"));

            submit.Click();
            Assert.IsFalse(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            Assert.IsTrue(driver.PageSource.Contains("Обязательное поле"));

            var pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("111111");

            submit.Click();
            Assert.IsFalse(driver.PageSource.Contains("Регистрация прошла успешно. На указанный адрес электронной почты выслано письмо со ссылкой для активации."));
            Assert.IsFalse(driver.PageSource.Contains("Неверный адрес электронной почты"));
            Assert.IsTrue(driver.PageSource.Contains("Обязательное поле"));
            Assert.IsFalse(driver.PageSource.Contains("Пароли не совпадают"));

            driver.Close();
          
        }


    }
}
