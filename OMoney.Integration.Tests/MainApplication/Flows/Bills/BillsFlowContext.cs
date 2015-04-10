using System.Threading;
using OpenQA.Selenium;

namespace OMoney.Integration.Tests.MainApplication.Flows.Bills
{
    public class BillsFlowContext : BaseFlowContext 
    {
        public BillsFlowContext(IWebDriver webDriver) : base(webDriver)
        {
        }

        public const string Name = "1";
        public const string Amount = "1";

        public BillsFlowContext CreatNewBill()
        {
            WebDriver
                .FindCreateNewOneButton()
                .Click();
            return this;
        }

        public BillsFlowContext InputName()
        {
            WebDriver
                .FindInputBillName()
                .SendKeys(Name);
            return this;
        }
        public BillsFlowContext InputAmount()
        {
            WebDriver
                .FindInputBillAmount()
                .SendKeys(Amount);
            return this;
        }
        public BillsFlowContext SubmitBill()
        {
            //Thread.Sleep(1000);
            WebDriver
                .FindCreatBill()
                .Click();
            return this;
        }

    }
}
