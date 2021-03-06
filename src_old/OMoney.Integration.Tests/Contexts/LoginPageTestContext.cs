﻿using System.Threading;
using NUnit.Framework;
using OMoney.Integration.Tests.Configuration;
using OMoney.Integration.Tests.Extensions;
using OpenQA.Selenium;

namespace OMoney.Integration.Tests.Contexts
{
    public class LoginPageTestContext : BaseTestContext
    {
        public LoginPageTestContext(IWebDriver webDriver) : base(webDriver)
        {
        }
        public string Login = "gold@mail.com";
        public string Pass = "golddemo";
        public LoginPageTestContext EnterLogin()
        {
            WebDriver
                .FindEmailField()
                .SendKeys(Login);
            return this;
        }
        public LoginPageTestContext EnterPassword()
        {
           WebDriver
               .FindPasswordField()
               .SendKeys(Pass);
            return this;
        }
        public LoginPageTestContext ClickOnLoginButton()
        {
            WebDriver
                .FindSubmitButton()
                .Click();
            return this;
        }
        public LoginPageTestContext CheckLoginButtonState(ButtonState buttonState)
        {
            return this;
        }
        public LoginPageTestContext EnsureRedirectToProfilePage()
        {
            Thread.Sleep(3000);
            Assert.AreEqual(WebDriver.Url, Config.MainApplicationBaseUrl + "/#/profile");
            return this;
        }
    }
}
