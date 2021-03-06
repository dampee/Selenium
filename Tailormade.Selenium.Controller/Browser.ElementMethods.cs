﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailormade.Selenium.Controller
{
    public partial class Browser
    {
        public bool ClickByLinkText(string linkText, OpenQA.Selenium.IWebElement parentElement = null, int index = 0, int sleep = 0, string checkString = "||||||||||||||||")
        {
            var el = parentElement != null ? parentElement.FindElements(By.LinkText(linkText)) : Driver.FindElementsByLinkText(linkText);
            if (el.Count == 0)
            {
                return false;
            }
            el.ElementAt(index).Click();
            return IsBrowserReady(sleep, checkString);
        }

        public bool ClickByClassName(string className, OpenQA.Selenium.IWebElement parentElement = null, int index = 0, int sleep = 0, string checkString = "||||||||||||||||")
        {
            var el = parentElement != null ? parentElement.FindElements(By.ClassName(className)) : Driver.FindElementsByClassName(className);
            if (el.Count == 0)
            {
                return false;
            }
            el.ElementAt(index).Click();
            return IsBrowserReady(sleep, checkString);
        }
        public bool ClickByName(string name, OpenQA.Selenium.IWebElement parentElement = null, int index = 0, int sleep = 0, string checkString = "||||||||||||||||")
        {
            var el = parentElement != null ? parentElement.FindElements(By.Name(name)) : Driver.FindElementsByName(name);
            if (el.Count == 0)
            {
                return false;
            }
            el.ElementAt(index).Click();
            return IsBrowserReady(sleep, checkString);
        }
        public bool ClickButtonWithText(string text, OpenQA.Selenium.IWebElement parentElement = null, int sleep = 0, string checkString = "||||||||||||||||")
        {
            var el = parentElement != null ? parentElement.FindElement(By.XPath(string.Format(".//button[contains(text(),'{0}')]", text))) : Driver.FindElementByXPath(string.Format("//button[contains(text(),'{0}')]", text));
            if (el == null)
            {
                return false;
            }
            el.Click();
            return IsBrowserReady(sleep, checkString);
        }
        public bool ClickButtonWithClassName(string text, int sleep = 0, string checkString = "||||||||||||||||")
        {
            var el = Driver.FindElementByXPath(string.Format("//button[contains(@class,'{0}')]", text));
            if (el == null)
            {
                return false;
            }
            el.Click();
            return IsBrowserReady(sleep, checkString);
        }
        public bool ClickElementWithText(string tagName, string text, OpenQA.Selenium.IWebElement parentElement = null, int sleep = 0, string checkString = "||||||||||||||||")
        {
            var el = parentElement!=null?parentElement.FindElement(By.XPath(string.Format(".//{0}[contains(text(),'{1}')]", tagName, text))) : Driver.FindElementByXPath(string.Format("//{0}[contains(text(),'{1}')]", tagName, text));
            if (el == null)
            {
                return false;
            }
            el.Click();
            return IsBrowserReady(sleep, checkString);
        }
        public bool ClickById(string name, OpenQA.Selenium.IWebElement parentElement = null, int index = 0, int sleep = 0, string checkString = "||||||||||||||||")
        {
            var el = parentElement != null ? parentElement.FindElements(By.Id(name)) : Driver.FindElementsById(name);
            if (el.Count == 0)
            {
                return false;
            }
            el.ElementAt(index).Click();
            return IsBrowserReady(sleep, checkString);
        }

        public IWebElement WaitForElementByName(string name, OpenQA.Selenium.IWebElement parentElement = null)
        {
            IWebElement el = null;
            DateTime dt = DateTime.Now.AddMilliseconds(MaxRenderWait);
            while (DateTime.Now < dt)
            {
                try
                {
                    el = (parentElement != null) ? parentElement.FindElement(By.Name(name)) : Driver.FindElementByName(name);
                    if (el != null)
                    {
                        return el;
                    }
                }
                catch (Exception e)
                {
                }
                Task.Delay(100).Wait();
            }
            return Driver.FindElementByName(name);
        }

        public IWebElement WaitForElementByClassName(string name, OpenQA.Selenium.IWebElement parentElement = null)
        {
            IWebElement el = null;
            DateTime dt = DateTime.Now.AddMilliseconds(MaxRenderWait);
            while (DateTime.Now < dt)
            {
                try
                {
                    el = (parentElement != null) ? parentElement.FindElement(By.ClassName(name)) : Driver.FindElementByClassName(name);
                    if (el != null)
                    {
                        return el;
                    }
                }
                catch (Exception e)
                {
                }
                Task.Delay(100).Wait();
            }
            return Driver.FindElementByClassName(name);
        }
        public IWebElement WaitForElementById(string name, OpenQA.Selenium.IWebElement parentElement = null)
        {
            IWebElement el = null;
            DateTime dt = DateTime.Now.AddMilliseconds(MaxRenderWait);
            while (DateTime.Now < dt)
            {
                try
                {
                    el = (parentElement != null) ? parentElement.FindElement(By.Id(name)) : Driver.FindElementById(name);

                    if (el != null)
                    {
                        return el;
                    }
                }
                catch (Exception e)
                {
                }
                Task.Delay(100).Wait();
            }
            return Driver.FindElementById(name);
        }
        public bool PageContains(string s)
        {
            return Driver.PageSource.IndexOf(s, StringComparison.InvariantCultureIgnoreCase) > -1;
        }
        public IWebElement WaitForElementByAttributeWithValue(string tagName, string attributeName, string text, OpenQA.Selenium.IWebElement parentElement = null)
        {
            IWebElement el = null;
            DateTime dt = DateTime.Now.AddMilliseconds(MaxRenderWait);
            while (DateTime.Now < dt)
            {
                try
                {
                    el = (parentElement != null) ? parentElement.FindElement(By.XPath(string.Format(".//{0}[contains(@{1},'{2}')]", tagName, attributeName, text))) : Driver.FindElementByXPath(string.Format("//{0}[contains(@{1},'{2}')]", tagName, attributeName, text));

                    if (el != null)
                    {
                        return el;
                    }
                }
                catch (Exception e)
                {
                }
                Task.Delay(100).Wait();
            }
            return Driver.FindElementByXPath(string.Format("//{0}[contains(@{1},'{2}')]", tagName, attributeName, text));
        }
        public IWebElement WaitForElementWithText(string tagName, string text, OpenQA.Selenium.IWebElement parentElement = null)
        {
            IWebElement el = null;
            DateTime dt = DateTime.Now.AddMilliseconds(MaxRenderWait);
            while (DateTime.Now < dt)
            {
                try
                {
                    el = (parentElement != null) ? parentElement.FindElement(By.XPath(string.Format(".//{0}[contains(text(),'{1}')]", tagName, text))) : Driver.FindElementByXPath(string.Format("//{0}[contains(text(),'{1}')]", tagName, text));

                    if (el != null)
                    {
                        return el;
                    }
                }
                catch (Exception e)
                {
                }
                Task.Delay(100).Wait();
            }
            return Driver.FindElementByXPath(string.Format("//{0}[contains(text(),'{1}')]", tagName, text));

        }
        public IWebElement GetElement(OpenQA.Selenium.IWebElement sourceElement, string xpath="..") // default parent
        {
            return sourceElement.FindElement(By.XPath(xpath));

        }
    }
}
