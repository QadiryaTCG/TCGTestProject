using Framework.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using System.Threading;
using TCGplayerUI.CustomMethods;

namespace TCGplayerUI.PageObjects.MarketPlace
{

    public class HomePage : StartBrowser
    {
        private ActionMethods _actionMethods;
        HomePage homepage;

        public HomePage(ThreadLocal<IWebDriver> driver)
        {
            HomePage.driver = driver;
            // PageFactory.InitElements(driver, this);
            _actionMethods = new ActionMethods();
        }

        // Marketplace header display
        By marketplaceHeader = By.XPath("//header[@class='marketplace-header']");
        public void IsmarketplaceHeaderExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(marketplaceHeader, "Marketplace Header", 20);
        }
        //Verify username display Welcome Back after login
        By WelcomeBack = By.XPath("descendant::span[contains(text(),'Welcome Back,')][1]");
        public void ISWelcomeBackExist()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(WelcomeBack, "Welcome Back", 20);
        }

        //get text for email
        By txtWelcome = By.XPath("//span[@data-aid='headerLoggedInUsername']");
        public string GetWelcomeText()
        {
            return _actionMethods.GetText(txtWelcome);
        }

        //Wait for the welcome text to appear on the UI
        public void WaitWelcomeTextIsDisplayed()
        {
            _actionMethods.IsEleDisplayedWithWait(txtWelcome, "Welcome text", 60);
        }

        //Verify username text
        By UserNameText = By.XPath("//span[@data-aid='headerLoggedInUsername']");
        public string UserTitlepresent()
        {
            return _actionMethods.GetText(UserNameText);

        }

        // Sign In button Visible 
        //Click on Sign In
        By SignInlink = By.XPath("//span[@data-aid='headerSignInValue']");

        public void IsSignInbtnExist()
        {
            _actionMethods.AssertElementIsDisplayed(SignInlink, "Sign In");
        }
        public void ClickOnSignIn()
        {
            _actionMethods.ClickWithWait(SignInlink, "SigninLink", 30);
        }

        // Click on autocomplete bar
        By Autobar = By.XPath("//input[@id='autocomplete-input']");
        public void ClickOnAutoBar()
        {
            _actionMethods.Click(Autobar, "Auto Bar");
        }
        // Enter Search term 
        By SearchTerm = By.XPath("//input[@id='autocomplete-input']");
        public void SearchAutocomplete(string searchTerm)
        {
            _actionMethods.EnterText(SearchTerm, "Search Term", searchTerm);
        }
        public void AssertSearchBarDisplayed()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(SearchTerm, "Search Bar", 30);
        }
        // Enter search term for Autocomplete test that way it will type letters one by one
        By AutoSearchTerm = By.XPath("//input[@id='autocomplete-input']");
        public void OnlySearchTermAutocomplete(string searchTerm)
        {

            foreach (char c in searchTerm)
            {
                _actionMethods.EnterText(AutoSearchTerm, "Search Term", c.ToString());
                Thread.Sleep(300);
            }
        }

        /// <summary>
        /// Click on Product in autocomplete drop down
        /// </summary>
        By productAutocomplete = By.XPath("descendant::div[@class='autocomplete-rec__name'][3]");
        public void ClickOnProduct1()
        {
            _actionMethods.Click(productAutocomplete, "Product");
        }
        /// <summary>
        /// Click on other product from autocomplete
        /// </summary>
        By magicAutocomplete = By.XPath("//div[@class='autocomplete-rec__name'][contains(text(),' in Magic: The Gathering ')]");
        public void ClickOnProduct2()
        {
            _actionMethods.Click(magicAutocomplete, "Product");
        }
        // Clear autocomplete text
        By Cleartext = By.XPath("//input[@id='autocomplete-input']");
        public void ClearText1()
        {
            _actionMethods.ClearText(Cleartext, "Text");
        }
        //Click on Spy Glass
        By Spybtn = By.XPath("//button[@class='button search-bar__spyglass']");
        public void ClickOnSpyBtn()
        {
            _actionMethods.ClickWithWait(Spybtn, "Spy Glass", 30);
        }
        public void AssertSpyGlassDisplayed()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(Spybtn, "Spy Glass", 30);
        }
        // Verify My Account person icon display 
        // Click on My Account 
        By MyAcctBtn = By.XPath("//button[@data-aid='headerMyAccount']");
        public void IsMyAcctbtnExist()
        {
            _actionMethods.AssertElementIsDisplayed(MyAcctBtn, "My Account");
        }
        public void ClickOnMyAcct()
        {
            _actionMethods.ClickWithWait(MyAcctBtn, "My Account", 20);
        }
        // Hello text display under My Account
        By txtHello = By.XPath("//span[@data-aid='accountMenuHello']");
        public void IstxtHelloExist()
        {
            _actionMethods.AssertElementIsDisplayed(txtHello, "Hello");
        }
        // After Login Verify Welcome back and User name display under my account
        By txtWelcomeBackUnderMyAcct = By.XPath("//span[@data-aid='accountMenuWelcomeBack']");
        public void IsTxtWelcomeBackUnderMyAcctExist()
        {
            _actionMethods.AssertElementIsDisplayed(txtWelcomeBackUnderMyAcct, "Welcome Back");
        }
        // Get the User Name text under my account
        By txtUserName = By.XPath("//a[@data-aid='accountMenuUserName']");
        public string GetUserName()
        {
            return _actionMethods.GetText(txtUserName);
        }

        // Verify Sign In display under My Account
        // Click On Sign In under My Account
        By lnkSignIn = By.XPath("//a[@data-aid='accountMenuSignIn']");
        public void IsMyAcctSignInExist()
        {
            _actionMethods.AssertElementIsDisplayed(lnkSignIn, "Sign In");
        }
        public void ClickOnMyAcctSignIn()
        {
            _actionMethods.ClickWithWait(lnkSignIn, "Sign In", 20);
        }
        //Click on Sign Up from My account
        By SignUpbtn = By.XPath("//a[@data-aid='accountMenuSignUp']");
        public void ClickOnSignUpbtn()
        {
            _actionMethods.Click(SignUpbtn, "Sign Up");
        }

        By SignOutlink = By.XPath("//span[@data-aid='accountMenuSignOut']");

        public void ClickOnSignout()
        {
            _actionMethods.Click(SignOutlink, "Sign Out");
        }
        //Click on GiftCard Link
        By lkGiftCard = By.XPath("//a[@class='navbar-link is-arrowless']");
        public void ClickOnGiftCard()
        {
            _actionMethods.ClickWithWait(lkGiftCard, "Gift Cards", 30);
        }
        //Click on Trade-in
        By TradeInlink = By.XPath("//a[@data-aid='accountMenuYourAccountTrade-In']");
        public void ClickOnTradeIn()
        {
            _actionMethods.ClickWithWait(TradeInlink, "Trade-In", 30);
        }


        //Click on Manage Addresses from Your Account
        By ManageAddress = By.XPath("//a[@data-aid='accountMenuYourAccountManageAddresses']");
        public void ClickOnManageAddress()
        {
            _actionMethods.Click(ManageAddress, "Manage Addresses");
        }

        // Click on Manage Subcription link from Your Account
        By ManageSubcriptionlink = By.XPath("//a[@data-aid='accountMenuYourAccountManageSubscriptions']");
        public void ClickOnManageSubcriptionlink()
        {
            _actionMethods.Click(ManageSubcriptionlink, "Manage Subcriptions");
        }

        //Click on X for Your account popup to close Your account
        By ClickX = By.XPath("//span[@class='icon is-small']");
        public void ClickOnX()
        {
            _actionMethods.Click(ClickX, "X");
        }

        // Verify Subscriber logo display on homepage 
        By Subscriberlogo = By.XPath("//button[@data-testid='account-actions__infinite-subscriber']");
        public bool IsSubscriberLogoExist()
        {
            return _actionMethods.IsElePresent(Subscriberlogo, "Infinite Subscriber logo");
        }

        // After log out verify Sign In button display
        By SignInbtn = By.XPath("//span[@data-aid='headerSignInValue']");
        public bool IsSigninbtnDisplayed()
        {
            return _actionMethods.IsEleDisplayed(SignInbtn, "Sign In");
        }

        // Click dropdown menu link for Seller Admin Portal
        By SellerAdminPortalLink = By.XPath("//a[@data-aid='accountMenuSellSellerPortal']");

        public void ClickSellerAdminPortal()
        {
            _actionMethods.ClickWithWait(SellerAdminPortalLink, "Seller Admin Portal Link", 30);
        }

        /// Autocomplete verification
        /// Wait to display Autocomplete drop down 
        By WaitAutodropdownDisplay = By.XPath("//div[@class='search-bar__autocomplete']");
        public bool WaitAutodropdownDisplayPresent()
        {
            return _actionMethods.WaitEleVisible(WaitAutodropdownDisplay, "Auto Drop Down", 20);
        }
        /// Autocomplete drop down display
        By AutodropdownDisplay = By.XPath("//div[@class='search-bar__autocomplete']");
        public bool IsAutodropdownDisplayExist()
        {
            return _actionMethods.IsEleDisplayed(AutodropdownDisplay, "Auto Drop Down");
        }

        // Get the first open search text in autocomplete
        By OpenSearchText = By.XPath("//a[@class='autocomplete-rec autocomplete-rec--open-search']");
        public string GetOpenSearchText()
        {
            return _actionMethods.GetText(OpenSearchText);
        }
        // Verify the first open search term matching with search term
        public void Verifyautotext(string AutosearchTerm)
        {
            homepage = new HomePage(driver);
            var autotext = homepage.GetOpenSearchText();
            if (autotext.Contains(AutosearchTerm))
            {
                Assert.IsTrue(true);
                StartBrowser.childTest.Pass("Correct Text is showing");
            }
            else
            {
                Assert.IsTrue(false);
                StartBrowser.childTest.Pass("Correct Text is not showing");
            }
        }
        By lkFirstSearchTerm = By.XPath("descendant::a[@class='autocomplete-rec autocomplete-rec--open-search'][1]");
        public void ClickFirstSearchTerm()
        {
            _actionMethods.MouseOverObject(lkFirstSearchTerm, "First Search Term");
            _actionMethods.Click(lkFirstSearchTerm, "FirstSearchTerm");
        }


        // Get top 3 productlines from autocomplete
        By Productlines = By.XPath("//a[@class='autocomplete-rec autocomplete-rec--product-line']");
        public int ReturnproductlinesCount()
        {
            return _actionMethods.ReturnElementCount(Productlines);
        }

        // Get the productline in loop from Autocomplete 
        public string GetProductlinesAutocomplete(int loop)
        {

            string xpath1 = "descendant::a[@class='autocomplete-rec autocomplete-rec--product-line'][";
            string xpath2 = "]";
            string fullXpath = xpath1 + loop + xpath2;
            string productLineResultLineXpath = fullXpath;
            return productLineResultLineXpath;
        }
        //Click on the producline in the loop from Autocomplete
        public void ProductLineName(int loop)
        {
            string Xpath = GetProductlinesAutocomplete(loop);
            By productline = By.XPath(Xpath);
            _actionMethods.Click(productline, "Product line");
        }

        // Get set count from autocomplete 
        By Sets = By.XPath("//a[@class='autocomplete-rec autocomplete-rec--set']");
        public int ReturnSetCount()
        {
            return _actionMethods.ReturnElementCount(Sets);
        }

        // Get the Set in loop from Autocomplete
        public string GetSetsAutocomplete(int loop)
        {

            string xpath1 = "descendant::a[@class='autocomplete-rec autocomplete-rec--set'][";
            string xpath2 = "]";
            string fullXpath = xpath1 + loop + xpath2;
            string setResultLineXpath = fullXpath;
            return setResultLineXpath;
        }
        //Click on Sets in loop from Autocomplete
        public void SetName(int loop)
        {
            string Xpath = GetSetsAutocomplete(loop);
            Thread.Sleep(3000);
            By setName = By.XPath(Xpath);
            _actionMethods.Click(setName, "Set");
        }

        // Click on Your Account 
        By lkYourAccount = By.XPath("//a[@data-aid='accountMenuYourAccount']");
        public void ClickOnYourAccount()
        {
            _actionMethods.ClickWithWait(lkYourAccount, "Your Account", 30);
        }

        // Click first recommended product name 
        By lkFirstRecProduct = By.XPath("//a[@class='autocomplete-rec']");
        public void ClickRecommendedProduct()
        {
            _actionMethods.ClickWithWait(lkFirstRecProduct, "First recommended Product", 30);
        }

        // Nav Bar 
        //Hover on Magic the drop down opens then click on Gift Cards
        By navMagic = By.XPath("//div[@id='dropdown-Magic']");
        By lnkGiftCardMagic = By.XPath("//a[@id='Magic-More-2']");
        public void HoverOnMagicNav()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navMagic, lnkGiftCardMagic, "Magic", "Gift Card");
        }
        // Hover on Yu-Gi-Oh and click on Gift Cards
        By navYuGiOh = By.XPath("//div[@id='dropdown-Yu-Gi-Oh!']");
        By lnkGiftCardYuGiOh = By.XPath("//a[@id='Yu-Gi-Oh!-More-1']");
        public void HoverOnYuGiOhNav()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navYuGiOh, lnkGiftCardYuGiOh, "Yu-Gi-Oh", "Gift Card");
        }
        // Hover on Pokemon and click on Gift Cards
        By navPokemon = By.XPath("//div[@id='dropdown-Pokémon']");
        By lnkGiftCardPokemon = By.XPath("//a[@id='Pokémon-More-1']");
        public void HoverOnPokemonNav()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navPokemon, lnkGiftCardPokemon, "Pokemon", "Gift Card");
        }
        // Hover on Cardfight and click on Gift Cards 
        By navCardfight = By.XPath("//div[@id='dropdown-Cardfight']");
        By lnkGiftCardCardfight = By.XPath("//a[@id='Cardfight-More-1']");
        public void HoverOnCardfightNav()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navCardfight, lnkGiftCardCardfight, "Cardfight", "Gift Card");
        }
        // Hover on Dragon Ball Super and click on Gift Cards
        By navDrangonBallSuper = By.XPath("//div[@id='dropdown-Dragon Ball Super']");
        By lnkGiftCardDrangonBallSuper = By.XPath("//a[@id='Dragon Ball Super-More-0']");
        public void HoverOnDrangonBallSuperNav()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navDrangonBallSuper, lnkGiftCardDrangonBallSuper, "Drangon Ball Super", "Gift Card");
        }
        // Hover on Flesh and Blood and click on Gift Cards
        By navFleshAndBlood = By.XPath("//div[@id='dropdown-Flesh and Blood']");
        By lnkGiftCardFleshAndBlood = By.XPath("//a[@id='Flesh and Blood-More-0']");
        public void HoverOnFleshAndBloodNav()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navFleshAndBlood, lnkGiftCardFleshAndBlood, "Drangon Ball Super", "Gift Card");
        }
        // Hover on Magic nav and Click on Decks
        By lnkDecks = By.XPath("descendant::a[text()=' Decks '][1]");
        public void HoverOnMagicAndClickOnDecks()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navMagic, lnkDecks, "Magic", "Decks");
        }

        // Hover on Magic nav and Click on Advanced Search
        By lkMagicAdvancedSearch = By.XPath("//a[@id='Magic-advanced-search']");
        public void HoverOnMagicAndClickAdvancedSearch()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navMagic, lkMagicAdvancedSearch, "Magic", "Advanced Search");
        }

        // Hover on YuGiOh nav and Click on Advanced Search
        By lkYuGiOhAdvancedSearch = By.XPath("//a[@id='Yu-Gi-Oh!-advanced-search']");
        public void HoverOnYuGiOhAndClickAdvancedSearch()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navYuGiOh, lkYuGiOhAdvancedSearch, "YuGiOh", "Advanced Search");
        }

        // Hover on Pokemon nav and Click on Advanced Search
        By lkPokemonAdvancedSearch = By.XPath("//a[@id='Pokémon-advanced-search']");
        public void HoverOnPokemonAndClickAdvancedSearch()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navPokemon, lkPokemonAdvancedSearch, "Pokemon", "Advanced Search");
        }

        // Hover on Cardfight nav and Click on Advanced Search
        By lkCardfightAdvancedSearch = By.XPath("//a[@id='Cardfight-advanced-search']");
        public void HoverOnCardfightAndClickAdvancedSearch()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navCardfight, lkCardfightAdvancedSearch, "Cardfight", "Advanced Search");
        }

        // Hover on Dragon Ball Super CCG nav and Click on Advanced Search
        By lkDragonBallSuperAdvancedSearch = By.XPath("//a[@id='Dragon Ball Super-advanced-search']");
        public void HoverOnDragonBallSuperAndClickAdvancedSearch()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navDrangonBallSuper, lkDragonBallSuperAdvancedSearch, "Dragon Ball Super", "Advanced Search");
        }

        // Hover on Flesh and Blood nav and Click on Advanced Search
        By lkFleshAndBloodAdvancedSearch = By.XPath("//a[@id='Flesh and Blood-advanced-search']");
        public void HoverOnFleshAndBloodAndClickAdvancedSearch()
        {
            _actionMethods.MouseHoverAndClickSubMenu(navFleshAndBlood, lkFleshAndBloodAdvancedSearch, "Flesh and Blood", "Advanced Search");
        }

        // Verify Kickback banner display on Homepage
        // Subscriber Kickback banner display
        By txtSubscriberKickback = By.XPath("//div[@class='site-alert notification is-warning kickback-banner'][contains(text(),' Subscriber Kickback ')]");
        public void IsSubscriberKickbackBannerExist()
        {
            _actionMethods.AssertElementIsDisplayed(txtSubscriberKickback, "Subscriber Kickback");
        }

        // Shopping Cart
        By lkShoppingCart = By.XPath("//a[@class='button button--cart']");
        public void AssertShoppingCartDisplayed()
        {
            _actionMethods.AssertElementIsDisplayedWithWait(lkShoppingCart, "Shopping Cart", 30);
        }
        public void ClickShoppingCart()
        {
            _actionMethods.ClickWithWait(lkShoppingCart, "Shopping Cart", 30);
        }

        By lblCartItemCount = By.XPath("//a[@class='button button--cart']/span[@class='tag is-rounded tag--cart-count']");
        By lblCartCountEmpty = By.XPath("//div[@class='marketplace-cart-count is-empty']");
        public string GetShoppingCartCount()
        {
            string cartCount;
            if (_actionMethods.IsElePresent(lblCartCountEmpty, "Cart Count Empty"))
            {
                cartCount = "0";
            }
            else
                cartCount = _actionMethods.GetText(lblCartItemCount);
            return cartCount;
        }



        ///Prod pop up
        By imgPopUp = By.XPath("//a[@class='dfwid-close']");
        public void ClosePopUp()
        {
            if (_actionMethods.IsElePresent(imgPopUp, "Pop Up"))
            {
                _actionMethods.ClickWithWait(imgPopUp, "Close Pop Up", 30);
            }
        }

    }
}