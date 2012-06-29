using MbUnit.Framework;
using System;
using eSelenium.Framework;
using eSelenium.PageObjects.OpenClass;
using eSelenium.PageObjects.DigitalVellum;
using eSelenium.PageObjects.Widgets;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using eSelenium.PageObjects;
using Gallio.Framework;

namespace eSelenium.FEMA.BerlinE2EBVT
{
    public class E2ETests : SeleniumTestBaseClass
    {
        #region properties
        //string prof = "Instructor Bre...";
        string profEmail = "RENATOSPRINGER@testedu.info";
        //string studEmail = "MILANHEINZ@testedu.info";
        string studEmail = "KASEYKATZ@testedu.info";
        public string profusername = "RENATOSPRINGER";
        public string studusername = "KASEYKATZ";
        public string password = "Berlin4$";
        public string OCSuperAdminName = "ocsuperadmin5@ecollege.com";
        public string OCSuperAdminPassword = "12345";
        public string InstitutionName = "FEMA";
        #endregion

        private WebPage WebPage
        {
            get
            {
                return new WebPage(selenium);
            }
        }


        #region Login to whittaker admin pages
        [Test]
        public void a_LoginToWhittakerAdminPages()
        {


            WebPage.GoToBerlinLoginPage().LoginAsSuperAdmin(OCSuperAdminName, OCSuperAdminPassword).GoToInstitution(InstitutionName);
               
           
        }

        #endregion  

        #region Login to Open Class
        [Test]
        public void b_LoginToOpenClass()
        {

            WebPage.GoToGoogleLoginPage().LoginAsGoogleInstructor(profEmail, profusername, password);
           
        }

        #endregion  

        #region Launching the Course
        [Test]
        public void c_CourseEntry()
        {

            WebPage.GoToGoogleLoginPage().LoginAsGoogleInstructor(profEmail, profusername, password).
                    GoToCourse(Config.GetConfigString("CourseName"));
           
        }
        #endregion

        #region Loading Social Course Home
        [Test]
        public void d_SocialCourseHome()
        {

            WebPage.GoToGoogleLoginPage().LoginAsGoogleInstructor(profEmail, profusername, password).
                    GoToCourse(Config.GetConfigString("CourseName")).
                    GoToSocialCourseHomePage();
            
        }

        #endregion    

        

      

        //#region Create Gradebook Only Content menu Item

        //[Test]
        //public void e_CreateContentItems()
        //{



        //    WebPage.GoToGoogleLoginPage().LoginAsGoogleInstructor(profEmail, profusername, password).
        //            GoToCourse(Config.GetConfigString("CourseName")).GoToSocialCourseHomePage();

        //        DVLightBoxAddPage lightboxAddpage = new DVLightBoxAddPage(selenium);
        //        lightboxAddpage.isModifyLinkPresent().GoToLightBoxPage().goToAddTabPage()
        //            .createGBOnlyItem("Gradebook-only Item");
           
        //}
        //#endregion

        #region Load Exams menu Item
        [Test]
        public void f_LoadExams()
        {

            WebPage.GoToGoogleLoginPage().LoginAsGoogleInstructor(profEmail, profusername, password).
                    GoToCourse(Config.GetConfigString("CourseName")).
                    GoToExamsPage().goToManage();
           


           
        }
        #endregion



        #region Loading Collaborations menu Item
        [Test]
        public void i_Collaborations()
        {

            WebPage.GoToGoogleLoginPage().LoginAsGoogleInstructor(profEmail, profusername, password).
                    GoToCourse(Config.GetConfigString("CourseName")).GoToCollaborationsPage();
                   




        }
        #endregion

      


       

        #region verifying Berlin toolbar
        [Test]
        public void h_BerlinToolbar()
        {

            WebPage.GoToGoogleLoginPage().LoginAsGoogleInstructor(profEmail, profusername, password).
                GoToCourse(Config.GetConfigString("CourseName")).verifyCourseTitle();

                var BerlinToolbar = new BerlinToolbar(selenium);
                BerlinToolbar.areToolBarPageElementsPresent();
           
        }
        #endregion   

       

       


        #region Clicking the Submissions

        [Test]
        public void i_SubmissionsPage()
        {

            WebPage.GoToGoogleLoginPage().LoginAsGoogleInstructor(profEmail, profusername, password).
                    GoToCourse(Config.GetConfigString("CourseName")).verifyCourseTitle().
                    GoToSubmissionsPage();
            
        }

        #endregion     

       



        #region Switch Between Gradebook Views

        [Test]
        public void j_LoadingGradebook()
        {


            WebPage.GoToGoogleLoginPage().LoginAsGoogleInstructor(profEmail, profusername, password).
                GoToCourse(Config.GetConfigString("CourseName")).goToGradeBook()
                   .goToGBAssignment().enterGradesinGBA()
                    .goToGBSetup();
           
        }

        #endregion

        //#region Student Login to Course

        //[Test]
        //public void k_StudentLogin()
        //{


        //    WebPage.GoToGoogleLoginPage().LoginAsGoogleStudent(studEmail, studusername, password).
        //        GoToCourse(Config.GetConfigString("CourseName")).GoToSocialCourseHomePage().goToGradeBook()
        //           .GoToExamsPage().GoToCollaborationsPage().GoToSubmissionsPage();

        //}

        //#endregion

        //#region Verifying the Chat Functionality 
        //[Test]
        //public void h_ChatWizard()
        //{
           
        //        ISeleniumCommands selenium2 = Common.StartSelenium(Config.seleniumHost, Config.seleniumPort, Config.seleniumBrowser, Config.LSTestSite);
        //        WebPage WebPage2 = new WebPage(selenium2);


        //        BerlinPhPage studPage = WebPage2.
        //            GoToGoogleLoginPage().
        //            LoginAsGoogleStudent(studEmail, studusername, password);



        //        WebPage.GoToGoogleLoginPage().LoginAsGoogleInstructor(profEmail, profusername, password).
        //            GoToCourse(Config.GetConfigString("CourseName"));


        //        BerlinInstructorPhPage profPage = new BerlinInstructorPhPage(selenium);

        //        profPage.toolbar.OpenWhosOnlineWidget().

        //       // GoToPeopleWidget().
        //        ChatWithUser("MILAN HEINZ").
        //        SendMessage("This is a message from the prof");

        //        Assert.IsTrue(studPage.toolbar.GoToChatWindow().isChatMessageVisible("This is a message from the prof"), "Could not validate the chat message was received");


        //        selenium2.Close();
        //        selenium.Close();
           
        //}

        //#endregion
    }
}

