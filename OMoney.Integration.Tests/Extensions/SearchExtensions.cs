using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace OMoney.Integration.Tests.Extensions
{
    public static class SearchExtensions
    {
        #region Login Page
        public static IWebElement FindEmailField(this ISearchContext searchContext)
        {
            return searchContext.WaitForElement(By.Id("Email"));
        }

        public static IWebElement FindPasswordField(this ISearchContext searchContext)
        {
            return searchContext.WaitForElement(By.Id("Password"));
        }

        public static IWebElement FindSubmitButton(this ISearchContext searchContext)
        {
            return searchContext.FindButtonByText("submit");
        }
        #endregion
        #region Functions
        public static int WaitForInSeconds
        {
            get
            {
                return 10;
            }
        }
        public static IWebElement FindButtonById(this ISearchContext element, string id)
        {
            return element.WaitForElement(By.XPath(String.Format("//button[@id='{0}']", id)));
        }
        public static IWebElement FindButtonByText(this ISearchContext element, string text)
        {
            return element.WaitForElement(By.XPath(String.Format("//button[contains(text(),'{0}')]", text)));
        }
        public static IWebElement FindButtonByTextInDiv(this ISearchContext element, string text)
        {
            return element.WaitForElement(By.XPath(String.Format(".//div//button[contains(text(),'{0}')]", text)));
        }
        public static IWebElement FindDivByText(this ISearchContext element, string textValue)
        {
            return element.WaitForElement(By.XPath(String.Format("//div[text()='{0}']", textValue)));
        }
        public static IWebElement FindElementByXPath(this ISearchContext element, string path)
        {
            return element.WaitForElement(By.XPath(String.Format("{0}", path)));
        }
        public static IWebElement FindSpanByText(this ISearchContext element, string textValue)
        {
            return element.WaitForElement(By.XPath(String.Format("//span[text()='{0}']", textValue)));
        }
        public static IWebElement FindButtonByType(this ISearchContext element, string text)
        {
            return element.WaitForElement(By.XPath(String.Format("//button[@type='{0}']", text)));
        }
        public static void ForceClick(this IWebElement element)
        {
            for (int second = 0; second < WaitForInSeconds; second++)
            {
                try
                {
                    element.Click();
                    return;
                }
                catch (InvalidOperationException)
                {
                    Thread.Sleep(1000);
                }
            }
        }
        public static IWebElement WaitForElement(this ISearchContext webDriver, By by, Func<IList<IWebElement>, bool> func = null)
        {
            for (int second = 0; second < WaitForInSeconds; second++)
            {
                Thread.Sleep(1000);
                var el = webDriver.FindElements(@by).Where(x => x.Displayed);

                if (null == func && el.Count() > 0)
                {
                    return el.First();
                }
                else if (null != func && func(el.ToList()))
                {
                    return el.First();
                }
                Thread.Sleep(1000);
            }
            return null;
        }
        public static IWebElement EnterField(this IWebElement element, string value)
        {
            Thread.Sleep(500);
            element.SendKeys(value);
            return element;
        }
        #endregion
    }
}
