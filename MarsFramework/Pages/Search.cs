using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsFramework.Global;

namespace MarsFramework.Pages
{
    class Search 
    {
        //Web elements
        IWebElement searchIcon => GlobalDefinitions.driver.FindElement(By.XPath("//i[@class = 'search link icon']"));

        IWebElement category => GlobalDefinitions.driver.FindElement(By.XPath("//a[text() = 'Programming & Tech']")); // Category - Programming & tech
        IWebElement subCategory => GlobalDefinitions.driver.FindElement(By.XPath("//a[text() = 'QA']")); //Sub category - QA
        static int numberRecords => GlobalDefinitions.driver.FindElements(By.XPath("//div[@class = 'ui stackable three cards']/div")).Count;  // number of records per page
        IWebElement resultsPerPage => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class = 'right floated column ']//button[text() = '12']")); // 12 records per page

        IWebElement onlineFilter => GlobalDefinitions.driver.FindElement(By.XPath("//button[text() = 'Online']"));  //Online filter for search
        IWebElement onsiteFilter => GlobalDefinitions.driver.FindElement(By.XPath("//button[text() = 'Onsite']")); //Onsite filter for search
        IWebElement ShowAllFilter => GlobalDefinitions.driver.FindElement(By.XPath("//button[text() = 'ShowAll']"));  // ShowAll filter for search

        IWebElement nextPageBtn => GlobalDefinitions.driver.FindElement(By.XPath("//button[text()='>']"));  // next page button

        int noOfButtons => GlobalDefinitions.driver.FindElements(By.XPath("//button[text()='>']/preceding-sibling::button")).Count; // number of pages in search operation(including previous and next page options)

        //internal string noOfPagesText { get; set; }
        string noOfPagesText => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class = 'ui buttons semantic-ui-react-button-pagination']/button["+noOfButtons+"]")).Text;

        

        //methods
        internal void ClickSearchIcon()
        {
                      
                if (GlobalDefinitions.IsElementVisible(searchIcon))
                {
                    //click on the search icon on home page
                    searchIcon.Click();
                }
       
                         
        }

        internal int NumOfRecordsPage()
        {
            return numberRecords;
        }
        internal int NumOfPages()
        {
            return Int32.Parse(noOfPagesText);
        }
        internal void ClickOnlineFilter()
        {
            onlineFilter.Click();
        }
        internal void ClickOnsiteFilter()
        {
            onsiteFilter.Click();
        }
        internal void ClickShowAllFilter()
        {
            ShowAllFilter.Click();
        }
        internal void SelectCategorySearch()
        {
            category.Click(); //Click on programming&Tech category
        }

        internal void SelectSubcategorySearch()
        {
            category.Click();   //Click on category 
            subCategory.Click();  // Click on QA sub category
        }
        internal void Results12perPageClick()
        {
            resultsPerPage.Click();
        }
        #region Number of records
        internal int TotalNumRecords()
        {
            int noOfPages = 0;
            noOfPages = System.Convert.ToInt32(noOfPagesText);

            int totRecords = 0;
            totRecords = totRecords + numberRecords;
            for (int i =1; i< noOfPages; i++)
            {
                nextPageBtn.Click();     // go to the next pae
                totRecords = totRecords + numberRecords;  // count the records per each page
                               
            }


            return totRecords;
        }

        #endregion

    }
}
