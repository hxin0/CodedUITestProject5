using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace HandCodingCUIT
    {
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CUITHandcoding
    {
        public CUITHandcoding()
        {
        }
        private BrowserWindow browser;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            browser = BrowserWindow.Launch("http://www.ssgsonline.net");
            browser.Maximized = true;
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            browser.Close();
        }

        [TestMethod]
        public void StartURL()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            //BrowserWindow browser = BrowserWindow.Launch("http://www.ssgsonline.net");
            //browser.Maximized = true;
            UITestControl uiLinkAboutUs = new UITestControl(browser);
            uiLinkAboutUs.TechnologyName = "Web";
            uiLinkAboutUs.SearchProperties.Add("ControlType", "Image");
            uiLinkAboutUs.SearchProperties.Add("Id", "Image62");
            //Playback.Wait(5000);
            uiLinkAboutUs.DrawHighlight();
            Mouse.Click(uiLinkAboutUs);
            Playback.Wait(1000);
            
        }

        [TestMethod]
        public void ChangeURL()
        {
            //StartURL();
            UITestControl uiChgUrl = new UITestControl(browser);
            uiChgUrl.TechnologyName = "Web";
            uiChgUrl.SearchProperties.Add("ControlType", "Cell");
            uiChgUrl.SearchProperties.Add("InnerText", "To read all articles visit http://www.dotnetcurry.com/BrowseArticles.aspx?CatID=60");
            string ChangeStr = uiChgUrl.GetProperty("InnerText").ToString();
            string[] words = ChangeStr.Split(' ');
            int ctr = 0;
            for (int i=0; i<words.Length; i++)
            {
                if (words[i].Contains("http"))
                {
                    ctr = i;
                    break;
                }
            }
            browser = BrowserWindow.Launch(words[ctr]);
        }

        [TestMethod]
        public void SearchWebsite()
        {
            ChangeURL();
            UITestControl uiSearch = new UITestControl(browser);
            uiSearch.TechnologyName = "Web";
            uiSearch.SearchProperties.Add("ControlType", "Edit");
            uiSearch.SearchProperties.Add("Id", "ctl00_searchbox");
            uiSearch.SetFocus();
            uiSearch.SetProperty("Text", "Coded UI");

            UITestControl uiButtonSearch = new UITestControl(browser);
            uiButtonSearch.TechnologyName = "Web";
            uiButtonSearch.SearchProperties.Add("ControlType", "Button");
            uiButtonSearch.SearchProperties.Add("Id", "ctl00_SearchButton");
            Mouse.Click(uiButtonSearch);

            UITestControl uiSearchResult = new UITestControl(browser);
            uiSearchResult.TechnologyName = "Web";
            uiSearchResult.SearchProperties.Add("ControlType", "Pane");
            uiSearchResult.SearchProperties.Add("Id", "results");
            string SearchStr = uiSearchResult.GetProperty("InnerText").ToString();
            string[] words = SearchStr.Split(' ');
            Console.WriteLine(SearchStr);
            if (Convert.ToInt16(words.Length) < 500)
            {
                Assert.AreEqual(true, true);
            }
            else
            {
                Assert.AreEqual(true, false);

            }
        }
        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        //private object browser;
    }
}
