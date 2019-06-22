using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsFramework.Global;
using OpenQA.Selenium;

namespace MarsFramework.Pages
{
    class ManageListings
    {
        IWebElement ManageListingMenu => GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(), 'Manage Listings')]"));
        IWebElement editListing => GlobalDefinitions.driver.FindElement(By.XPath("//i[@class = 'outline write icon']"));
        IWebElement viewListing => GlobalDefinitions.driver.FindElement(By.XPath("//i[@class = 'eye icon']"));

        IWebElement deleteListing => GlobalDefinitions.driver.FindElement(By.XPath("//i[@class = 'remove icon']"));

        int noOfRecords = GlobalDefinitions.driver.FindElements(By.XPath("//table[@class = 'ui striped table']//tbody/tr")).Count;
        IWebElement acceptDelListing => GlobalDefinitions.driver.FindElement(By.XPath("//button[@class = 'ui icon positive right labeled button']"));

        internal void ManageListingMenuClick()
        {
            ManageListingMenu.Click();
        }
        internal void EditListing()
        {
            //System is not editing/viewing the records as expected.
            //Need to automate, once the feature has been developed properly
        }

        internal int TotalRecords()
        {
            //return total number of records in Manage Listings table
            return noOfRecords;
        }
        internal bool DeleteListing()
        {
            //deleting the first record in Listings table
             deleteListing.Click();

            Thread.Sleep(2000);
            if(acceptDelListing.Displayed)
            {
                acceptDelListing.Click();
                return true;
            } else
            {
                return false;
            }

        }
    }

}
