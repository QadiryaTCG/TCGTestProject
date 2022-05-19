
# **FEAT - Front-end Automation Testing**

A .NET Core Page object model based framework that utilizes Selenium Web Driver for automated UI testing.


#
**Build Status:**

The build status can be found in the following Jenkins project : TBD


#
**Technology Used : C#, NUnit, Selenium**

Framework Used: Page Object Model Features: Here you need to add features of your project. For Example: This project will help Automation Testing Companies to test their application using automation to reduce the manual time.

FE-Automated-Testing Solution has 2 Projects

--Framekwork: Framework project has following folders



*   Base
*   Config
*   Helpers

--TCGplayerUI: TCGplayerUI project has following folders



*   BusinessMethods
*   CustomMethods
*   Data
*   PageObjects
*   Queries
*   Result
*   TestCases

#
**Code Example:**


Provide a short and concise example of your code in this section.

Code is written in C#

**Page Object Model: **Used to identify objects. Action methods are used to perform actions on the objects.

**Page Object Example: **

By btnSignIn = By.Id("login-button");

public void ClickSignInButton()

        {

            _actionMethods.Click(btnSignIn, "SignIn button");

        }

**Action Method Example:**

public void Click(By locator, string element)

        {

            try

            {

                driver.FindElement(locator).Click();

                StartBrowser.childTest.Pass("Sucessfully clicked on :" + element);

            }

            catch (Exception e)

            {

                StartBrowser.childTest.Fail("Unable to click on :" + element,

                MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot()).Build());

                StartBrowser.childTest.Info(e);

                throw e;

            }

        }

**Business Methods: **Reusable code that works with the objects

**Business Method Example:**

umbracoHomePage**.**ClickSignInButton();


#
**Installation:**

Here you need to provide the steps to get the project running.



1. Install Visual Studio
2. Select Git from menu bar> Clone a Repository
3. Repository Location: Enter:  [https://github.com/TCGplayer/FE-Automated-Testing.git](https://github.com/TCGplayer/FE-Automated-Testing.git)
4. Path: enter path where you would like to the repository to reside on the local machine
5. Click the Clone button.

This will install the solution which contains the ‘Framework’  and ‘TCGplayerUI’ projects.  All package dependencies will be installed when the solution is cloned.


#
**Tests:**

Provide example on how to run the code. For Example: how to run from a command line.

**On Local Machine:**

Access a command line



1. Change the directory to the directory that contains the FE-Automated-Testing Solution on the local machine.
2. Type in the following command so the tests will run in the appropriate environment:

    _set ASPNETCORE_ENVIRONMENT=qa_


    or


    _set ASPNETCORE_ENVIRONMENT=Staging_

3. Type in the following command to run the tests contained in the class file. (Note: In the example ‘TestName’ is the name of the class that is to be executed.  Change according.)

    _dotnet test --filter Name~TestName_    


#
**Contribute:**


Provide the description about what people can add in your project.

The FE-Automated-Testing Solution is used to test various UIs used at TCGplayer.

The solution is broken down into a folder structure that allows easy access to



*   Business Methods
*   Custom Methods
*   Data
*   Page Objects
*   Queries
*   Tests

Within the solution folders there are more folders that break out the applications.



*   Marketplace Store
*   Admin Panel
*   Umbraco
*   Kiosk
*   MassPrice

Users can add code to any of  the appropriate areas.  This will contribute to the reusable code base and assure that it is well organized.

**Page Objects**

Use the following when identifying an object.  Use camelCaseToNameAnObject.

•	btn   Button

•	img   Image on a page

•	lbl   Test on a page

•	lnk   Link on a page

•	rad   Radio button

•	txt   Text input field




