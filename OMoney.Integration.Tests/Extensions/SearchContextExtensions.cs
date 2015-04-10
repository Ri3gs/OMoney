using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace OMoney.Integration.Tests.Extensions
{
    public static class SearchContextExtensions
    {
        public static int WaitForInSeconds
        {
            get
            {
                return 10;
            }
        }

        //ForceClick

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

        //FindInputField no Home Page

        public static IWebElement FindInputFieldForEmailOnHomeLogin(this ISearchContext element)
        {
            return element.FindElementByXPath("//*[@id='Email']");
        }
        public static IWebElement FindInputFieldForPassOnHomeLogin(this ISearchContext element)
        {
            return element.FindElementByXPath("//*[@id='Password']");
        }
        public static IWebElement FindInputFieldForConfirmPassOnHomeLogin(this ISearchContext element)
        {
            return element.FindElementByXPath("//*[@id='Confirmpassword']");
        }


        //FindButtons

        public static IWebElement FindSignUpButtonOnHomeLogin(this ISearchContext element)
        {
            return element.WaitForElement(By.XPath(String.Format("//*[@id='signup']/div/div[1]/div[1]"))); 
            
        }


        public static IWebElement FindeLoginButton(this ISearchContext element)
        {
            return element.WaitForElement(By.XPath(String.Format("/html/body/div/div[2]")));
            
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


        public static IWebElement FindCreateNewOneButton(this ISearchContext element)
        {
            return element.WaitForElement(By.XPath(String.Format("//a[contains(@href, '#/createaccount')]")));

        }

        public static IWebElement FindInputBillName(this ISearchContext element)
        {
            return element.WaitForElement(By.XPath("//input[@id='Name']"));
        }
        public static IWebElement FindInputBillAmount(this ISearchContext element)
        {
            return element.WaitForElement(By.XPath("//input[@id='Amount']"));
        }
        public static IWebElement FindCreatBill(this ISearchContext element)
        {
            return element.WaitForElement(By.XPath("//button[@type='submit']"));
        }
        //public static IWebElement FindTodayButton(this ISearchContext element)
        //{
        //    return element.FindElementByXPath("//*[@id='nav-accordion']/li[2]/a");
        //}
        //public static IWebElement FindNextWeekButton(this ISearchContext element)
        //{
        //    return element.FindElementByXPath("//*[@id='nav-accordion']/li[3]/a");
        //}
        //public static IWebElement FindAddNewTaskOnTodayPage(this ISearchContext element)
        //{
        //    return element.FindElementByXPath("//*[@id='main-content']/section/div/div[1]/a");
        //}
        //public static IWebElement FindEditButtonForOneTaskForTodayPage(this ISearchContext element)
        //{
        //    return element.FindElementByXPath("//*[@id='main-content']/section/div/div[1]/div/section/div/div[1]/ul/li/div[2]/div/a");
        //}
        //public static IWebElement FindSaveEditButtonForOneTaskForTodayPage(this ISearchContext element)
        //{
        //    return element.FindElementByXPath("//*[@id='main-content']/section/div/div/div/section/div[2]/div/div/form/button");
        //}
        //public static IWebElement FindDoneButtonForOneTaskForTodayPage(this ISearchContext element)
        //{
        //    return element.FindElementByXPath("//*[@id='main-content']/section/div/div[1]/div/section/div/div[1]/ul/li/div[1]/a");
        //}
        //public static IWebElement FindDeleteButtonOnArchivePage(this ISearchContext element)
        //{
        //    return element.FindElementByXPath("//*[@id='main-content']/section/div/div[1]/div/section/div/div[1]/ul/li/div[2]/div/a[2]");
        //}
        //public static IWebElement FindInputForNameOnTodayPage(this ISearchContext element)
        //{
        //    return element.FindElementByXPath("//*[@id='myModal']/div[2]/div/div[2]/form/input[1]");
        //}
        //public static IWebElement FindInputForNameOnEditPage(this ISearchContext element)
        //{
        //    return element.FindElementByXPath("//*[@id='main-content']/section/div/div/div/section/div[2]/div/div/form/input[1]");
        //}
        //public static IWebElement FindCreateNewTaskButtonOnTodayPage(this ISearchContext element)
        //{
        //    return element.FindElementByXPath("//*[@id='myModal']/div[2]/div/div[2]/form/button");
        //}
        //public static IWebElement FindInputForDateOnTodayPage(this ISearchContext element)
        //{
        //    return element.FindElementByXPath("//*[@id='myModal']/div[2]/div/div[2]/form/input[2]");
        //}
        //public static IWebElement FindInputForDateOnEditePage(this ISearchContext element)
        //{
        //    return element.FindElementByXPath("//*[@id='main-content']/section/div/div/div/section/div[2]/div/div/form/input[2]");
        //}

        //public static IWebElement FindTostersDiv(this ISearchContext element)
        //{
        //    return element.WaitForElement(By.XPath(String.Format("//*[@id='toast-container']/div/div[3]")));
        //}
        //public static IWebElement FindDueDateOnArchivePage(this ISearchContext element)
        //{
        //    return element.WaitForElement(By.XPath(String.Format("//*[@id='main-content']/section/div/div[1]/div/section/div/div[1]/ul/li[1]/div[2]/div/span")));
        //}


        // FindDivByText/FindElementByXPath/FindSpanByText/ WaitForElement / EnterField

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

        public static IWebElement WaitForElement(this ISearchContext webDriver, By by, Func<IList<IWebElement>, bool> func = null)
        {
            for (int second = 0; second < WaitForInSeconds; second++)
            {
                Thread.Sleep(1000);
                var el = webDriver.FindElements(by).Where(x => x.Displayed);

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
    }
}
