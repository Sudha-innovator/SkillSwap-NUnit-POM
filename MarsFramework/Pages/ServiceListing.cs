using OpenQA.Selenium;
using MarsFramework.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ServiceListing
    {
        #region Initialise Web elements

        IWebElement ManageListingMenu => GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(), 'Manage Listings')]"));

        IWebElement ShareSkillBtn => GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(), 'Share Skill')]"));

        IWebElement TitleName => GlobalDefinitions.driver.FindElement(By.XPath("//input[@type = 'text'  and @name = 'title']"));
        IWebElement Description => GlobalDefinitions.driver.FindElement(By.XPath("//textarea[@name = 'description']"));
        IWebElement CategList => GlobalDefinitions.driver.FindElement(By.XPath("//select[@name = 'categoryId']"));
        IWebElement SubCategList => GlobalDefinitions.driver.FindElement(By.XPath("//select[@name = 'subcategoryId']"));

        IWebElement Tags => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(text(), 'Tags')]/parent::div/following-sibling::div//input"));

        IWebElement HourlyBasisServiceType => GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(), 'Hourly basis service')]/preceding-sibling::input[@name = 'serviceType']"));
        IWebElement OneOffServiceType => GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(), 'One-off service')]/preceding-sibling::input[@name = 'serviceType']"));

        IWebElement OnsiteLocationType => GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(), 'On-site')]/preceding-sibling::input[@name = 'locationType']"));
        IWebElement OnlineLocationType => GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(), 'Online')]/preceding-sibling::input[@name = 'locationType']"));

        //need to add available days in calender and time
        IWebElement StartDate => GlobalDefinitions.driver.FindElement(By.XPath("//input[@name = 'startDate']"));

        IWebElement SkillExchangeTrade => GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(), 'Skill-exchange')]/preceding-sibling::input[@name = 'skillTrades']"));
        IWebElement CreditSkillTrade => GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(), 'Credit')]/preceding-sibling::input[@name = 'skillTrades']"));


        IWebElement NewTagSkillExchange => GlobalDefinitions.driver.FindElement(By.XPath("//h3[contains(text(), 'Skill-Exchange')]/parent::div/following-sibling::div//input"));


        IWebElement CreditCharge => GlobalDefinitions.driver.FindElement(By.XPath("//input[@name = 'charge']"));

        IWebElement WorkSamplesUpload => GlobalDefinitions.driver.FindElement(By.XPath("//i[@class = 'huge plus circle icon padding-25']"));
        int WorkSamplesDocCount => GlobalDefinitions.driver.FindElements(By.XPath("//div[@class = 'serviceListing worksampleFile']//a")).Count();

        IWebElement ActiveRBtn => GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(), 'Active')]/preceding-sibling::input[@name = 'isActive']"));
        IWebElement HiddenRBtn => GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(), 'Hidden')]/preceding-sibling::input[@name = 'isActive']"));

        IWebElement SaveBtn => GlobalDefinitions.driver.FindElement(By.XPath("//input[@value = 'Save']"));
        IWebElement CancelBtn => GlobalDefinitions.driver.FindElement(By.XPath("//input[@value = 'Cancel']"));

        IWebElement DateErrMsg => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class = 'ui basic red prompt label transition visible']"));

        
        #endregion 

        internal void ManageListingsMenuClick()
        {
                //Click on the Manage Listings Menu item
                ManageListingMenu.Click();

        }
        internal bool IsShareSkillBtnClickable()
        {
            return (GlobalDefinitions.IsElementVisible(ShareSkillBtn));
        }
        internal void ShareSkillBtnClick()
        {
            ShareSkillBtn.Click();  //Click on the share skill button
        }

        internal string ShareSkillPageTitle()
        {
            return (GlobalDefinitions.driver.Title);
        }
        internal void inputTitleDescription(string title, string description)
        {
            // enter Title and Description values
            TitleName.SendKeys(title);
            Description.SendKeys(description);

        }
        internal void SelectCategSubcateg(string category, string subcategory)
        {
            // Select category from the dropdown - Programming & Tech option
            SelectElement categSelect = new SelectElement(CategList);
            categSelect.SelectByText(category);

            // Select sub category from the drop down - QA
            SelectElement subCategSelect = new SelectElement(SubCategList);
            subCategSelect.SelectByText(subcategory);
        }

        internal void InputTags(string tags)
        {
            Tags.SendKeys(tags);
            Tags.SendKeys(Keys.Enter);
        }

        internal void ServiceAndLocationTypeSelect(string servicetype, string locationtype)
        {
            //service type
            if (servicetype.Equals("HourlyBasis"))
            {
                HourlyBasisServiceType.Click();
            }
            else
                OneOffServiceType.Click();
            // Location type
            if (locationtype.Equals("Online"))
                OnlineLocationType.Click();
            else
                OnsiteLocationType.Click();

        }

        internal void inputSkillExchangeTradeDetails(string skilltag)
        {
            //enter skill exchange trade and the corresponding details
            SkillExchangeTrade.Click();
            NewTagSkillExchange.SendKeys(skilltag);
            NewTagSkillExchange.SendKeys(Keys.Enter);

        }
        internal void inputCreditTradeDetails(string chargeamt)
        {
            CreditSkillTrade.Click();
            CreditCharge.SendKeys(chargeamt);
        }

        internal void ActiveBtnClick()
        {
            ActiveRBtn.Click();
        }
        internal void SaveBtnClick()
        {
            SaveBtn.Click();
        }
        internal void WorkSamplesUploadClick()
        {

            //IJavaScriptExecutor js = GlobalDefinitions.driver as IJavaScriptExecutor;
            Thread.Sleep(3000);
            //js.ExecuteScript("window.scrollBy(0,1250);");
            WorkSamplesUpload.Click();
            
        }

        //Check whether document attached to the form or not
        // returns true - if document attached
        // returns false - if no document attached
        internal bool IsWorkSamplesDocUpload()
        {
            try
            {
                if (WorkSamplesDocCount > 0)
                    return true;
                else
                    return false;

            }
            catch(Exception)
            {
                return false;
            }
        }
        internal void StartDateSelect(string date)
        {
            //DateTime today = DateTime.Today;
            // if (date < today) 
            //string today = DateTime.Today.ToString("dd-MM-yyyy");
            //string tomorrow = DateTime.Today.AddDays(1).ToString("dd-MM-yyyy");
            // string yesterday = DateTime.Today.AddDays(-1).ToString("dd-MM-yyyy");
            //StartDate.SendKeys("27/05/2019");
            // StartDate.SendKeys(today);
            //StartDate.SendKeys(date.ToString("dd-MM-yyyy"));

            StartDate.SendKeys(date);
        }
        internal string IsErrorDateMsg()
        {
            //returns error message that system should not accept the past date as the Start date in Available days fields
            return DateErrMsg.Text;
          
        }
    }
}
