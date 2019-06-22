using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class SignIn
    {
        #region PageFactory has obselete in new  - so not using the pagefactory code
        //public SignIn()
        //{
        //    PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        //}

        ///////////////  Initialize Web Elements 
        ////Finding the Sign Link
        //[FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div[1]/div[1]/div/a[2]")]
        //private IWebElement SignIntab { get; set; }

        //// Finding the Email Field
        //[FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/div[1]/form/div[1]/input")]
        //private IWebElement Email { get; set; }

        ////Finding the Password Field
        //[FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/div[1]/form/div[2]/input")]
        //private IWebElement Password { get; set; }

        ////Finding the Login Button
        //[FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/div[1]/form/div[4]/div")]
        //private IWebElement LoginBtn { get; set; }

        #endregion

        //Objects:
        string signInXpath = "//a[text() = 'Sign In']";
        string userNameXpath = "//input[@name = 'email']";
        string passwordXpath = "//input[@name = 'password']";
        string loginBtnXpath = "//button[text() = 'Login']";
        string signInFormXpath = "//div[@class = 'ui tiny modal transition visible active']";
        string verificationFormXpath = "//div[@class = 'ui tiny modal transition visible active']";

        internal void LoginSteps()
        {
            //extent Reports
           // Base.test = Base.extent.StartTest("Login Test");

            launchUrlClickSignin();
            
            Thread.Sleep(500);

            //Enter the data in Username textbox
            GlobalDefinitions.driver.FindElement(By.XPath(userNameXpath)).SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2,"Username"));
            Thread.Sleep(500);

            //Enter the password 
            GlobalDefinitions.driver.FindElement(By.XPath(passwordXpath)).SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Click on Login button
            GlobalDefinitions.driver.FindElement(By.XPath(loginBtnXpath)).Click();
            Thread.Sleep(3000);

            //string text = Global.GlobalDefinitions.driver.FindElement(By.XPath("//a[text() = 'Mars Logo']")).Text;

            //if (text == "MarsLogo")
            //{
            //    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successful");
            //}
            //else
            //    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Login Unsuccessful");

        }
        internal void launchUrlClickSignin()
        {
            
                //Populate the Excel sheet
                Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "SignIn");


                //Navigate to the Url
                Global.GlobalDefinitions.driver.Navigate().GoToUrl(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

                Thread.Sleep(2000);
                //Click on Sign In tab
                GlobalDefinitions.driver.FindElement(By.XPath(signInXpath)).Click();

        }
        internal void incorrectLogindetails()
        {
           // Base.test = Base.extent.StartTest("Login Test");

            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "SignIn");


            //Navigate to the Url
            Global.GlobalDefinitions.driver.Navigate().GoToUrl(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            Thread.Sleep(2000);
            //Click on Sign In tab
            GlobalDefinitions.driver.FindElement(By.XPath(signInXpath)).Click();

            Thread.Sleep(500);

            //Enter the data in Username textbox
            GlobalDefinitions.driver.FindElement(By.XPath(userNameXpath)).SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            Thread.Sleep(500);

            //Enter the password 
            GlobalDefinitions.driver.FindElement(By.XPath(passwordXpath)).SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "WrongPassword"));

            //Click on Login button
            GlobalDefinitions.driver.FindElement(By.XPath(loginBtnXpath)).Click();
            Thread.Sleep(3000);


        }
        internal bool IsSigninFormVisible()
        { 

            return GlobalDefinitions.driver.FindElement(By.XPath(signInFormXpath)).Displayed;

        }
        internal bool IsVerificationMailFormVisible()
        {
            return GlobalDefinitions.driver.FindElement(By.XPath(verificationFormXpath)).Displayed;
        }
    }
}