using Framework.Base;
using NUnit.Framework;
using System;
using System.Threading;
using TCGplayerUI.PageObjects.MarketPlace;

namespace TCGplayerUI.TestCases.MarketPlace.ProdSmokeTests
{
    public class MP_DesktopProductProd : StartBrowser
    {
        public MP_DesktopProductProd() : base(SetUpClass.extent) { }
        NewPDPage pdpage;
        ListosPDPage listospdpage;
        DeckbuilderPage deckbuilderPage;
        public MP_DesktopProductProd(string profile, string environment) : base(profile, environment, SetUpClass.extent) { }

        [Test]
        [Category("Marketplace")]
        [Category("ProdSmoke")]
        public void MagicPDPage()
        {
           
                Setup(SetUpClass.extent, "newPDpageUrl");
                pdpage = new NewPDPage(driver);

                StartBrowser.childTest = StartBrowser.parentTest.CreateNode("Test Magic in stock detail Page");

                Thread.Sleep(3000);
                //Verify All Elements present on PD page
                pdpage.ISProductTitleExist();
                Thread.Sleep(2000);
                pdpage.IsSpotlightExist();
                Thread.Sleep(2000);
                pdpage.IsDirectspotlightBannerExist();
                Thread.Sleep(2000);
                pdpage.IsImageExist();
                pdpage.IsProductdetailsExist();
                pdpage.IsFiltersExist();
                pdpage.IsPricelistingsExist();
                pdpage.IsListingstoolbarExist();
           
        }

        [Test]
        [Category("Marketplace")]
        [Category("ProdSmoke")]
        public void NonMagicPDPage()
        {
           
                Setup(SetUpClass.extent, "nonMagicPDPageUrl");
                pdpage = new NewPDPage(driver);
                StartBrowser.childTest = StartBrowser.parentTest.CreateNode("Test non Magic in stock detail Page");
                Thread.Sleep(5000);
                //Verify All Elements present on PD page
                pdpage.ISProductTitleExist();
                Thread.Sleep(2000);
                pdpage.IsSpotlightExist();
                Thread.Sleep(2000);
                pdpage.IsImageExist();
                pdpage.IsProductdetailsExist();
                pdpage.IsFiltersExist();
                pdpage.IsPricelistingsExist();
                pdpage.IsListingstoolbarExist();
            

        }

        [Test]
        [Category("Marketplace")]
        [Category("ProdSmoke")]
        public void ListosPDPage()
        {
           
                Setup(SetUpClass.extent, "listosPDpageUrl");
                listospdpage = new ListosPDPage(driver);
                StartBrowser.childTest = StartBrowser.parentTest.CreateNode("Test Listos Product Details Page");
                Thread.Sleep(4000);
                listospdpage.IsCustomTitleExist();
                listospdpage.IsAddToCartExist();
                listospdpage.IsCustompricingExist();
                listospdpage.IsSellerNameExist();
                listospdpage.IsReportTabExist();
                listospdpage.ClickOnDetailsTab();
                Thread.Sleep(2000);
                listospdpage.IsProductSetnameExist();
                Thread.Sleep(2000);
                listospdpage.IsConditionExist();
                Thread.Sleep(2000);
                listospdpage.IsProductDescriptionExist();
                Thread.Sleep(2000);


        }

    

        [Test]
        [Category("Marketplace")]
        [Category("ProdSmoke")]
        public void DeckbuilderPage()
        {
           
                Setup(SetUpClass.extent, "deckbuilderUrl");
                StartBrowser.childTest = StartBrowser.parentTest.CreateNode("Test Deckbuilder Page");
                deckbuilderPage = new DeckbuilderPage(driver);
                Thread.Sleep(4000);
                //Deckbuilder Homepage contentverification
                deckbuilderPage.IsPromoWidgetExist();
                deckbuilderPage.IsEnteraDeckExist();
                //Deckbuilder search page verification
                deckbuilderPage.ClickOnSearchDecks();
                Thread.Sleep(2000);
                deckbuilderPage.IsSearchMagicDecksExist();
                deckbuilderPage.IsFormatExist();
                deckbuilderPage.IsContainsExist();
                deckbuilderPage.IsResetbtnExist();
                deckbuilderPage.IsSearchbtnExist();
                deckbuilderPage.TextContains();
                deckbuilderPage.ClickOnSearchbtn();
                Thread.Sleep(2000);
                deckbuilderPage.IsTitleExit();
                deckbuilderPage.IssearchpageExit();   
                //Deckbuilder Standard Deck verification
                deckbuilderPage.ClickOnStandardDecks();
                Thread.Sleep(4000);
                deckbuilderPage.IsSearchresultsstandarddecksTitleExist();
                deckbuilderPage.IsStandarddecksdatatableExist();
                //Deckbuilder Modern Deck Verification
                deckbuilderPage.ClickOnModernDecks();
                Thread.Sleep(4000);
                deckbuilderPage.IsSearchresultsMordendecksTitleExist();
                deckbuilderPage.IsMordendecksdatatableExist();
            
        }

    }
}
