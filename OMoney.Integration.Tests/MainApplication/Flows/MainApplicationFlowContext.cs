using OMoney.Integration.Tests.Extensions;
using OpenQA.Selenium;

namespace OMoney.Integration.Tests.MainApplication.Flows
{
    public class MainApplicationFlowContext : BaseFlowContext
    {
        public MainApplicationFlowContext(IWebDriver webDriver)
            : base(webDriver)
        {

        }
        //EditField On Home and Login Page

        public MainApplicationFlowContext EditeEmailFieldForNewUserOnHomeLogin()
        {
            WebDriver.FindInputFieldForEmailOnHomeLogin()
               .EnterField("nikolo@mail.ru");
            return this;
        }
        public MainApplicationFlowContext EditePasslFieldForNewUserOnHomeLogin()
        {
            WebDriver.FindInputFieldForPassOnHomeLogin()
               .EnterField("111111");
            return this;
        }
        public MainApplicationFlowContext EditeConfirmPassFieldForNewUserOnHomeLogin()
        {
            WebDriver.FindInputFieldForConfirmPassOnHomeLogin()
               .EnterField("111111");
            return this;
        }


        // PressButtons

        public MainApplicationFlowContext PressSignUpButtonOnHomeLogin()
        {
            WebDriver.FindSignUpButtonOnHomeLogin().Click();
            return this;
        }


        public const string Name = "1";
        public const string Amount = "1";

        public MainApplicationFlowContext CreatNewBill()
        {
            WebDriver
                .FindCreateNewOneButton()
                .Click();
            return this;
        }

        public MainApplicationFlowContext InputName()
        {
            WebDriver
                .FindInputBillName()
                .SendKeys(Name);
            return this;
        }
        public MainApplicationFlowContext InputAmount()
        {
            WebDriver
                .FindInputBillAmount()
                .SendKeys(Amount);
            return this;
        }
        public MainApplicationFlowContext SubmitBill()
        {
            WebDriver
                .FindCreatBill()
                .Click();
            return this;
        }

        //public MainApplicationFlowContext PressArchiveButton()
        //{
        //    WebDriver.FindArchiveButton().Click();
        //    return this;
        //}
        //public MainApplicationFlowContext PressTodayButton()
        //{
        //    WebDriver.FindTodayButton().Click();
        //    return this;
        //}
        //public MainApplicationFlowContext PressNextWeekButton()
        //{
        //    WebDriver.FindNextWeekButton().Click();
        //    return this;
        //}
        //public MainApplicationFlowContext PressAddNewTaskButtonOnTodayPage()
        //{
        //    WebDriver.FindAddNewTaskOnTodayPage().Click();
        //    return this;
        //}
        //public MainApplicationFlowContext PressEditButtonForOneTaskOnTodayPage()
        //{
        //    WebDriver.FindEditButtonForOneTaskForTodayPage().Click();
        //    return this;
        //}
        //public MainApplicationFlowContext PressDoneButtonForOneTaskOnTodayPage()
        //{
        //    WebDriver.FindDoneButtonForOneTaskForTodayPage().Click();
        //    return this;
        //}
        //public MainApplicationFlowContext PressDeleteButtonForOneTaskOnToArchivePage()
        //{
        //    WebDriver.FindDeleteButtonOnArchivePage().Click();
        //    return this;
        //}
        //public MainApplicationFlowContext EditeNameFieldForNewTaskOnTodayPage()
        //{
        //    WebDriver.FindInputForNameOnTodayPage()
        //        .EnterField("С framework былобы гораздо быстрее писать тесты :)");
        //    return this;
        //}
        //public MainApplicationFlowContext EditeNameFieldForExistingTaskOnEditPage(string text)
        //{
        //    WebDriver.FindInputForNameOnEditPage()
        //        .EnterField(text);
        //    return this;
        //}
        //public MainApplicationFlowContext PressSaveEditeForExistingTaskOnEditPage()
        //{
        //    WebDriver.FindSaveEditButtonForOneTaskForTodayPage().Click();
        //    return this;
        //}
        //public MainApplicationFlowContext PressCreateNewTaskButtonOnTodayPage()
        //{
        //    WebDriver
        //        .FindCreateNewTaskButtonOnTodayPage()
        //        .Click();
        //    Thread.Sleep(1000);
        //    return this;
        //}
        //public MainApplicationFlowContext EditeDateFieldForNewTaskOnTodayPage(DateTime date)
        //{
        //    WebDriver.FindInputForDateOnTodayPage().EnterField(date.ToShortDateString());
        //    return this;
        //}
        //public MainApplicationFlowContext EditeDateFieldForExistingTaskOnEditePage(DateTime date)
        //{
        //    WebDriver.FindInputForDateOnEditePage().EnterField(date.ToShortDateString());
        //    return this;
        //}
        //public MainApplicationFlowContext EnshureTaskCreatedOnTodayPage()
        //{
        //    Assert.IsNotNull(WebDriver.FindSpanByText("С framework былобы гораздо быстрее писать тесты :)"));
        //    return this;
        //}
        //public MainApplicationFlowContext EnshureTaskCreatedOnTodayPage(string text)
        //{
        //    Assert.IsNotNull(WebDriver.FindSpanByText(text));
        //    return this;
        //}
        //public MainApplicationFlowContext EnshureTaskIsDoneOnArchivePage()
        //{
        //    Assert.IsNotNull(WebDriver.FindSpanByText("Done"));
        //    return this;
        //}
        //public MainApplicationFlowContext EnshureNoTasksOnArchivePage()
        //{
        //    Assert.IsNotNull(WebDriver.FindAddNewTaskOnTodayPage());
        //    return this;
        //}
        //public MainApplicationFlowContext EnshureToster(string text)
        //{
        //    Assert.IsNotNull(WebDriver.FindTostersDiv());
        //    Assert.IsNotNull(WebDriver.FindDivByText(text));
        //    return this;
        //}
        //public MainApplicationFlowContext EnshureTaskIsEditedOnArchivePage()
        //{
        //    Assert.IsNotNull(WebDriver.FindSpanByText("С framework былобы гораздо быстрее писать тесты :):)"));
        //    Assert.IsNotNull(WebDriver.FindSpanByText("Done"));
        //    var actualdate = DateTime.Parse(WebDriver.FindDueDateOnArchivePage().Text.Substring(5));
        //    Assert.IsTrue(actualdate.ToShortDateString() == DateTime.Today.AddDays(2).ToShortDateString());
        //    return this;
        //}
    }
}
