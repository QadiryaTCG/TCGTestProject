using Framework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using TCGplayerUI.CustomMethods;

namespace TCGplayerUI.PageObjects.MarketPlace
{
   public class DeckbuilderPage : StartBrowser
    {
          private ActionMethods _actionMethods;
        public DeckbuilderPage(ThreadLocal<IWebDriver> driver)
        {
            DeckbuilderPage.driver = driver;
            _actionMethods = new ActionMethods();
        }

        // After login verify Welcome back for user name 
        By WelcomebackOnDeck = By.XPath("//p[contains(text(),'Welcome back, ')]");
        public void IsWelcomebackExist()
        {
             _actionMethods.AssertElementIsDisplayedWithWait(WelcomebackOnDeck, "Welcome back", 20);
        }
        // promo widget display
        By PromoWidget = By.XPath("//div[@class='db-promo-widget']");
        public void IsPromoWidgetExist()
        {
            _actionMethods.AssertElementIsDisplayed(PromoWidget, "Welcome To DECK BUILDER");
        }
        //Enter a deck display
        By EnteraDeck = By.XPath("//button[text()='Enter a deck!']");
        public void IsEnteraDeckExist()
        {
            _actionMethods.AssertElementIsDisplayed(EnteraDeck, "Enter a deck");
        }
        //click on Search Decks
        By SearchDecks = By.XPath("//a[@href='/magic/deck']");
        public void ClickOnSearchDecks()
        {
            _actionMethods.Click(SearchDecks, "Search Decks");
        }
        // Search Magic Decks display
        By SearchMagicDecks = By.XPath("//h2[text()='Search Magic Decks']");
        public void IsSearchMagicDecksExist()
        {
             _actionMethods.AssertElementIsDisplayed(SearchMagicDecks, "Search Magic Decks");
        }
        //Format display
        By Format = By.XPath("//*[@id='Format']");
        public void IsFormatExist()
        {
             _actionMethods.AssertElementIsDisplayed(Format, "Format");
        }
        //Contains Cards display
        By Contains = By.XPath("//*[@id='Contains']");
        public void IsContainsExist()
        {
             _actionMethods.AssertElementIsDisplayed(Contains, "Contains");
        }
        //Reset button display
        By Reset = By.XPath("//*[@id='ResetButton']");
        public void IsResetbtnExist()
        {
             _actionMethods.AssertElementIsDisplayed(Reset, "Reset");
        }
        //Search button display
        By Search = By.XPath("//*[@id='SearchButton']");
        public void IsSearchbtnExist()
        {
            _actionMethods.AssertElementIsDisplayed(Search, "Search");
        }
        //Type in Contains
        IWebElement TypeContains => driver.Value.FindElement(By.XPath("//*[@id='Contains']"));
        public void TextContains()
        {
            TypeContains.SendKeys("trop");
        }
        //Click on Search button
        By Searchbtn = By.XPath("//*[@id='SearchButton']");
        public void ClickOnSearchbtn()
        {
            _actionMethods.Click(Searchbtn, "Search");
        }
        //Verify element display after clicking Search 
        By TitleSearchResults = By.XPath("//*[@class='search-title']");
        public void IsTitleExit()
        {
             _actionMethods.AssertElementIsDisplayed(TitleSearchResults, "Search Results for Magic Decks");
        }
        //page display
        By Searchpages = By.XPath("//div[@class='pageXofY']");
        public void IssearchpageExit()
        {
             _actionMethods.AssertElementIsDisplayed(Searchpages, "Page View");
        }
        //Click on Submit deck
        By SubmitADeck = By.XPath("//a[@href='/magic/deck/edit/0']");
        public void ClicOnSubmitDeckbtn()
        {
            _actionMethods.Click(SubmitADeck, "Submit A Deck");
        }
        //Submit Deck title display
        By SubmitDeckTitle = By.XPath("//h2[@class='bottomBuffer db-page-title']");
        public void IsSubmitdeckTitleExist()
        {
            _actionMethods.AssertElementIsDisplayed(SubmitDeckTitle, "Submit Deck");
         }
        // Deck name display
        By Deckname = By.XPath("//*[@id='DeckName']");
        public void IsDeckNameExist()
        {
             _actionMethods.AssertElementIsDisplayed(Deckname, "Deck Name");
        }
        //Format display
        By Formatdisplay = By.XPath("//*[@id='Format']");
        public void IsFormatonSubmitdeckExist()
        {
             _actionMethods.AssertElementIsDisplayed(Formatdisplay, "Format");
        }
        //LatestSet display
        By LatestSet = By.XPath("//*[@id='LatestSet']");
        public void IsLatestSetDisplayExist()
        {
             _actionMethods.AssertElementIsDisplayed(LatestSet, "Latest Set");
        }
        //Cancel button display
        By Cancelbtn = By.XPath("//*[@id='CancelButton']");
        public void IsCancelbtnExist()
        {
             _actionMethods.AssertElementIsDisplayed(Cancelbtn, "Cancel");
        }
        //Submit Deck button display
        By SubmitDeckbtn = By.XPath("//*[@id='CancelButton']");
        public void IsSubmitDeckbtnExist()
        {
             _actionMethods.AssertElementIsDisplayed(SubmitDeckbtn, "Submit Deck");
        }
        //Standard Deck verification
        // Click on Standard Decks
        By StandardDecks = By.XPath("//a[@href='/magic/deck/search?format=standard']");
        public void ClickOnStandardDecks()
        {
            _actionMethods.Click(StandardDecks, "Standard Decks");
        }
        //Search Results for standard decks display
        By Searchresultsstandarddecks = By.XPath("//h2[@class='search-title']");
        public void IsSearchresultsstandarddecksTitleExist()
        {
             _actionMethods.AssertElementIsDisplayed(Searchresultsstandarddecks, "Search Results for Standard Magic Decks");
        }
        //data table display for Standard decks
        By Standarddecksdatatable = By.XPath("//table[@class='dataTable fullWidth']");
        public void IsStandarddecksdatatableExist()
        {
             _actionMethods.AssertElementIsDisplayed(Standarddecksdatatable, "Data Table");

        }
        // Modern decks Verification
        //Click on Modern Decks
        By ModernDecks = By.XPath("//a[@href='/magic/deck/search?format=modern']");
        public void ClickOnModernDecks()
        {
            _actionMethods.Click(ModernDecks, "Modern Decks");
        }
        // Search Results for Modern decks title display 
        By SearchresultsMordendecks = By.XPath("//h2[@class='search-title']");
        public void IsSearchresultsMordendecksTitleExist()
        {
            _actionMethods.AssertElementIsDisplayed(SearchresultsMordendecks, "Search Results for Modern Magic Decks");
        }
        //Data table for Modern Decks display
        By Moderndecksdatatable = By.XPath("//table[@class='dataTable fullWidth']");
        public void IsMordendecksdatatableExist()
        {
             _actionMethods.AssertElementIsDisplayed(Moderndecksdatatable, "Data Table");
        }
    }
}
