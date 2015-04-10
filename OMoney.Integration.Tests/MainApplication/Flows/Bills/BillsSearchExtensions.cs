using System;
using OMoney.Integration.Tests.Extensions;
using OpenQA.Selenium;

namespace OMoney.Integration.Tests.MainApplication.Flows.Bills
{
   public static class BillsSearchExtensions
    {
      
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
    }
}
