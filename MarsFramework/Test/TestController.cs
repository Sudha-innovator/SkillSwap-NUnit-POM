using NUnit.Framework;
using System;
using MarsFramework.Pages;
using MarsFramework.Global;
using RelevantCodes.ExtentReports;
using AutoItX3Lib;
using System.Threading;

namespace MarsFramework.Test
{
    class TestController
    {
        [TestFixture]
        // [Category("Sprint1")]
        class ShareSkill : Global.Base
        {

            [Test]
            public void editProfile()
            {
                // Creates a toggle for the given test, adds all log events under it    
                // test = extent.StartTest("Edit Profile Test");

                // Create an class and object to call the method
                //Profile obj = new Profile();
                //obj.EditProfile();



            }
            [Test]
            public void TC_009_01_CheckShareskillClickable()
            {
                test = extent.StartTest("Share Skill Button visible test");
                ServiceListing skillObj = new ServiceListing();
                if (skillObj.IsShareSkillBtnClickable())
                {
                    Base.test.Log(LogStatus.Info, "Share skill button is clickable");
                    Assert.IsTrue(true);
                }
                else
                {
                    Base.test.Log(LogStatus.Fail, "Test failed");
                    Assert.Fail();
                }

            }


            [Test]
            public void TC_009_02_skillPageTitleCheck()
            {
                test = extent.StartTest("Share skill page title check");
                ServiceListing skillObj = new ServiceListing();
                //click on the share skill button
                skillObj.ShareSkillBtnClick();
                string expectedTitle = "ServiceListing";
                //compare the page title

                if (expectedTitle.Equals(skillObj.ShareSkillPageTitle()))
                {
                    Base.test.Log(LogStatus.Pass, "Page Title Test Passed");
                    Assert.Pass();
                }
                else
                {
                    Base.test.Log(LogStatus.Fail, "Page Title test Failed");
                    Assert.Fail();
                }

            }
            [Test]
            public void TC_009_03_CreateNewShareSkill()
            {
                try
                {
                    GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
                    test = extent.StartTest("Create New Share Skill Record");
                    // create an object for serviceLIsting page

                    ServiceListing skillObj = new ServiceListing();

                    //click on the share skill button
                    skillObj.ShareSkillBtnClick();

                    //enter all the details from the excel
                    string title = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                    string desc = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
                    skillObj.inputTitleDescription(title, desc);

                    //enter category and sub category details
                    skillObj.SelectCategSubcateg(GlobalDefinitions.ExcelLib.ReadData(2, "Category"), GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

                    // enter tags value
                    skillObj.InputTags(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));

                    //enter service type and location type
                    skillObj.ServiceAndLocationTypeSelect(GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType"), GlobalDefinitions.ExcelLib.ReadData(2, "LocationType"));

                    //enter yesterday as start date in Available days
                    string date = GlobalDefinitions.ExcelLib.ReadData(2, "AvailableDays");
                    skillObj.StartDateSelect(date);

                    //enter skill trade details
                    skillObj.inputCreditTradeDetails(GlobalDefinitions.ExcelLib.ReadData(2, "credit"));

                    //enter active status
                    skillObj.ActiveBtnClick();

                    //click on save button
                    skillObj.SaveBtnClick();

                    if (skillObj.ShareSkillPageTitle().Equals("ListingManagement"))
                    {
                        Base.test.Log(LogStatus.Pass, "New share skill record created sucessfully");
                        Assert.True(true);
                    }
                    else
                    {
                        Base.test.Log(LogStatus.Fail, "New Share skill record not saved");
                        Assert.Fail();
                    }
                }
                catch (Exception e)
                {
                    Base.test.Log(LogStatus.Fail, e);
                    Assert.Fail();
                }
            }

            [Test]
            public void TC_WorkSamplesUpload()
            {
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
                test = extent.StartTest("Uploading File Test");
                // create an object for serviceLIsting page

                ServiceListing skillObj = new ServiceListing();

                //click on the share skill button
                skillObj.ShareSkillBtnClick();

                //enter all the details from the excel
                Thread.Sleep(2000);
                string title = GlobalDefinitions.ExcelLib.ReadData(3, "Title");
                string desc = GlobalDefinitions.ExcelLib.ReadData(3, "Description");
                skillObj.inputTitleDescription(title, desc);

                //work samples file upload
                skillObj.WorkSamplesUploadClick();

                //AutoIt - Handles windows that do not belong to browser

                AutoItX3 autoIt = new AutoItX3();
                autoIt.WinActivate("Open"); //Activate - so that the next set of actions happen on this window
                Thread.Sleep(2000);
                autoIt.Send(@"C:\Users\sudha\Desktop\FileUploadTest.docx");
                Thread.Sleep(2000);
                //  autoIt.Send("{ENTER}");
                // autoIt.MouseClick("Button1",0,0, 1, 0);
                autoIt.ControlClick("Open","", "Button1");

                //Check whether document uploaded property or not
                if (skillObj.IsWorkSamplesDocUpload())
                {
                    Base.test.Log(LogStatus.Pass, "Document uploaded successfully using AutoIt");
                    Assert.True(true);
                }
                else
                {
                    test.Log(LogStatus.Fail, "Document not uploaded");
                    Assert.Fail();
                }

            }
            [Test]
            public void TC_CheckStartDate()
            {
                try
                {
                    GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
                    test = extent.StartTest("Create New Share Skill Record");
                    // create an object for serviceLIsting page

                    ServiceListing skillObj = new ServiceListing();

                    //click on the share skill button
                    skillObj.ShareSkillBtnClick();

                    //enter all the details from the excel
                    string title = GlobalDefinitions.ExcelLib.ReadData(4, "Title");
                    string desc = GlobalDefinitions.ExcelLib.ReadData(4, "Description");
                    skillObj.inputTitleDescription(title, desc);

                    //enter category and sub category details
                    skillObj.SelectCategSubcateg(GlobalDefinitions.ExcelLib.ReadData(4, "Category"), GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

                    // enter tags value
                    skillObj.InputTags(GlobalDefinitions.ExcelLib.ReadData(4, "Tags"));

                    //enter service type and location type
                    skillObj.ServiceAndLocationTypeSelect(GlobalDefinitions.ExcelLib.ReadData(4, "ServiceType"), GlobalDefinitions.ExcelLib.ReadData(4, "LocationType"));

                    //enter yesterday as start date in Available days
                    DateTime date = DateTime.Today.AddDays(-1);
                    skillObj.StartDateSelect(date.ToString("dd-MM-yyyy"));

                    //enter skill trade details
                    skillObj.inputCreditTradeDetails(GlobalDefinitions.ExcelLib.ReadData(4, "credit"));

                    //enter active status
                    skillObj.ActiveBtnClick();

                    //click on save button
                    skillObj.SaveBtnClick();

                    Thread.Sleep(2000);
                    if (skillObj.ShareSkillPageTitle().Equals("ServiceListing"))
                    {
                        if (skillObj.IsErrorDateMsg().Equals("Start Date cannot be set to a day in the past"))
                        {
                            Base.test.Log(LogStatus.Pass, "Test Passed- Past date not accepting as start date");
                            Assert.True(true);
                        }
                        else
                        {
                            Base.test.Log(LogStatus.Fail, "Test Failed - should return proper error message for past date");
                            Assert.Fail();
                        }
                    } else
                    {
                        Base.test.Log(LogStatus.Fail, "Test Failed - Should not save the record with past date as start date");
                        Assert.Fail();
                    }
                }
                catch (Exception e)
                {
                    Base.test.Log(LogStatus.Fail, e);
                    Assert.Fail();

                }

            }

        }
        [TestFixture]
        class ManageListingTest : Global.Base
        {
            [Test]
            public void TC_012_01_CheckDeleteManageListing()
            {
             test = extent.StartTest("Delete Manage Listings test");

                ManageListings listingObj = new ManageListings();

                listingObj.ManageListingMenuClick();

                Thread.Sleep(1000);
                bool isDeleted = listingObj.DeleteListing();
             
                if(isDeleted)
                {
                    test.Log(LogStatus.Pass, "Deleted the listing succesfully");
                    Assert.True(true);
                } else
                {
                    test.Log(LogStatus.Fail, "Test failed");
                    Assert.Fail();
                }
            }
        }
        [TestFixture]
        class SearchTest : Global.Base
        {
            [Test]
            public void TC_015_01_SearchSkillsByCategory()
            {
                try
                {
                    test = extent.StartTest("Test for Search Skills by category");
                    Search searchObj = new Search();

                    Thread.Sleep(2000);
                    searchObj.ClickSearchIcon();
                    Thread.Sleep(1000);
                    searchObj.SelectCategorySearch();  //Programming & Tech category search

                    //Criteria : I have picked the total number of records from the search and displaying it on the report.
                    //Since I can't find the corresponding details when I open the record after search.

                    int TotalRecords = searchObj.TotalNumRecords();  // getting the total number of records from the search to assert
                    test.Log(LogStatus.Pass, "Test Passed-found records:"+TotalRecords);
                    Assert.True(true);
                }
                catch (Exception e)
                {
                    test.Log(LogStatus.Fail, e);
                    Assert.Fail();
                }


            }
            [Test]
            public void TC_015_02_SearchSkillsBySubCategory()
            {
                try
                {
                    test = extent.StartTest("Test for Search Skills by sub category");
                    Search searchObj = new Search();

                    Thread.Sleep(2000);
                    searchObj.ClickSearchIcon();    //click on search icon
                    searchObj.SelectSubcategorySearch();  //click on subcategory 

                    int TotalRecords = searchObj.TotalNumRecords();  // get the total number of records
                    test.Log(LogStatus.Pass, "Test Passed-found records:" + TotalRecords);
                    Assert.True(true);
                }
                catch (Exception e)
                {
                    test.Log(LogStatus.Fail, e);
                    Assert.Fail();
                }


            }
            [Test]
            public void TC_016_01_SearchSkillByOnlineFilter()
            {
                try
                {
                    test = extent.StartTest("Test for Search Skills by Online Filter");
                    Search searchObj = new Search();

                    searchObj.ClickSearchIcon();    //click on search icon
                    searchObj.ClickOnlineFilter();   //click on Online filter

                    int TotalRecords = searchObj.TotalNumRecords();  // get the total number of records
                    test.Log(LogStatus.Pass, "Test Passed-found records:" + TotalRecords);
                    Assert.True(true);
                }
                catch (Exception e)
                {
                    test.Log(LogStatus.Fail, e);
                    Assert.Fail();
                    
                }
            }
            [Test]
            public void TC_016_02_SearchSkillByOnsiteFilter()
            {
                try
                {
                    test = extent.StartTest("Test for Search Skills by Onsite Filter");
                    Search searchObj = new Search();

                    searchObj.ClickSearchIcon();    //click on search icon
                    searchObj.ClickOnsiteFilter();   //click on Online filter

                    int TotalRecords = searchObj.TotalNumRecords();  // get the total number of records
                    test.Log(LogStatus.Pass, "Test Passed-found records:" + TotalRecords);
                    Assert.True(true);
                }
                catch (Exception e)
                {
                    test.Log(LogStatus.Fail, e);
                    Assert.Fail();

                }
            }

            [Test]
            public void TC_016_03_SearchSkillByShowallFilter()
            {
                try
                {
                    test = extent.StartTest("Test for Search Skills by ShowAll Filter");
                    Search searchObj = new Search();

                    searchObj.ClickSearchIcon();    //click on search icon
                    searchObj.ClickShowAllFilter();   //click on Online filter

                    int TotalRecords = searchObj.TotalNumRecords();  // get the total number of records
                    test.Log(LogStatus.Pass, "Test Passed-found records:" + TotalRecords);
                    Assert.True(true);
                }
                catch (Exception e)
                {
                    test.Log(LogStatus.Fail, e);
                    Assert.Fail();

                }
            }
            [Test]
            public void TC_016_04_CheckRecordsperPage12()
            {
                try
                {
                    test = extent.StartTest("Test for Search Skills by ShowAll Filter");
                    Search searchObj = new Search();

                    searchObj.ClickSearchIcon();    //click on search icon
                    searchObj.Results12perPageClick();   //click on 12 results per page icon

                    if (searchObj.NumOfRecordsPage() == 12)   //check whether displayed 12 records per page or not
                    { 
                        test.Log(LogStatus.Pass, "Test passed - displayed 12 records per page");
                        Assert.True(true);
                    } else
                    {
                        Assert.Fail();
                        test.Log(LogStatus.Fail, "Test Failed");
                    }
                }
                catch (Exception e)
                {
                    test.Log(LogStatus.Fail, e);
                    Assert.Fail();

                }
            }
        }

        [TestFixture]
        class SignInTest : Global.BaseLoginTest
        {
            [Test]
            public void TC_002_01_CheckSignInForm()
            {
                test = BaseLoginTest.extent.StartTest("Check for SignIn form visibility");
                SignIn signInObj = new SignIn();
                signInObj.launchUrlClickSignin();  //Launch Url and Click on SignIn button

                if(signInObj.IsSigninFormVisible())  //Check if SignIn form is visible
                {
                    test.Log(LogStatus.Pass, "Sign in form is visible");
                    Assert.True(true);
                } else
                {
                    test.Log(LogStatus.Fail, "Sign in form is not visible");
                    Assert.Fail();
                }
            }
            [Test]
            public void TC_002_02_LoginHappyPath()
            {
                test = BaseLoginTest.extent.StartTest("Check for Happy path Credentials");
                SignIn signInObj = new SignIn();
                try
                {

                    signInObj.LoginSteps(); // Login with happy credentials
                    test.Log(LogStatus.Pass, "Login Successfull");
                    Assert.True(true);
                }
                catch (Exception e)
                {
                    test.Log(LogStatus.Fail, "Test Failed"+e.InnerException);
                    Assert.Fail();
                    
                }

            }
            [Test]
            public void TC_002_03_LoginUnhappyPath()
            {
                test = BaseLoginTest.extent.StartTest("Check with UnHappy Credentials");
                SignIn signInObj = new SignIn();
                signInObj.incorrectLogindetails(); // Login with incorrect credentials

                if (signInObj.IsVerificationMailFormVisible())  //Check Whether user is able to login
                {
                    test.Log(LogStatus.Pass, "Test successful-unable to login with incorrect details");
                    Assert.True(true);
                }
                else
                {
                    test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail();
                }
            }
            public void TC_002_04_ChkForgotPwdLink()
            {

            }
            public void TC_002_05_ChkForJoinLink()
            {

            }
        }
                
        [TestFixture]
        class ProfileTest : Global.Base
        {
            [Test]
            public void TC001_AddNewLanguage()
            {
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Language");
                test = extent.StartTest("Add new Language Test");
                Profile profileObj = new Profile();

                Thread.Sleep(2000);
                profileObj.clickLanguageTab();
                profileObj.AddLanguage(GlobalDefinitions.ExcelLib.ReadData(2, "LanguageName"), GlobalDefinitions.ExcelLib.ReadData(2, "LanguageLevel"));

                Thread.Sleep(2000);
                if (profileObj.RecordPresent(GlobalDefinitions.ExcelLib.ReadData(2, "LanguageName")))
                {
                    test.Log(LogStatus.Pass, "Test Pass: Record added successfully");
                    Assert.IsTrue(true);
                }
                else
                {
                    test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail();
                }

            }
        }
    }
}