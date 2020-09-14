using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Data.OleDb;

namespace twitterBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\veriler.accdb");
           


        private void Form1_Load(object sender, EventArgs e)
        {

            timer1.Interval = 840000;
            timer1.Enabled = true;

            timer2.Interval = 900000;
            timer2.Enabled = true;

        }



        private void button3_Click(object sender, EventArgs e)
        {

            baglantim.Open();
   

            Random s = new Random();
            int sayi = s.Next(1000, 70000);

            OleDbCommand listele = new OleDbCommand("select * from film where kimlik= " + sayi + "", baglantim);
            OleDbDataReader okuma = listele.ExecuteReader();
            while (okuma.Read()) 
            {
                textBox3.Text = okuma["filmseolink"].ToString();

            }
            baglantim.Close();

          
        }

        private void button2_Click(object sender, EventArgs e)
        {

          


            string ad = "", sifre = "";
            string hastang = "";
            string gelen = "";
            string tweet = "";

            gelen = textBox3.Text;

            tweet = hastang + gelen;


            ad = textBox1.Text;
            sifre = textBox2.Text;

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.twitter.com/login");
            Thread.Sleep(3000);


            IWebElement userName = driver.FindElement(By.Name("session[username_or_email]"));
            IWebElement password = driver.FindElement(By.Name("session[password]"));
            IWebElement loginBtn = driver.FindElement(By.XPath("//*[@id='react-root']/div/div/div[2]/main/div/div/div[1]/form/div/div[3]/div"));

            Thread.Sleep(2000);
            userName.SendKeys(ad);
            Thread.Sleep(2000);
            password.SendKeys(sifre);
            Thread.Sleep(2000);
            loginBtn.Click();

            Thread.Sleep(3000);

            driver.Navigate().GoToUrl("https://twitter.com/home");

            Thread.Sleep(3000);


            IWebElement tweeetText = driver.FindElement(By.XPath("//*[@id='react-root']/div/div/div[2]/main/div/div/div/div/div/div[2]/div/div[2]/div[1]/div/div/div/div[2]/div[1]/div/div/div/div/div/div/div/div/div/div[1]/div/div/div/div[2]/div/div/div/div"));

            Thread.Sleep(2000);

            tweeetText.SendKeys(tweet);

            Thread.Sleep(2000);

            IWebElement tweetButton = driver.FindElement(By.XPath("//*[@id='react-root']/div/div/div[2]/main/div/div/div/div/div/div[2]/div/div[2]/div[1]/div/div/div/div[2]/div[4]/div/div/div[2]/div[3]/div"));
            tweetButton.Click();


            Thread.Sleep(1500);

            IWebElement tkpBtnbir = driver.FindElement(By.XPath("//*[@id='react-root']/div/div/div[2]/main/div/div/div/div[2]/div/div[2]/div/div/div/div[4]/aside/div[2]/div[1]/div/div[2]/div/div[2]/div"));

            Thread.Sleep(1500);

            tkpBtnbir.Click();

            Thread.Sleep(1500);

            IWebElement tkpBtniki = driver.FindElement(By.XPath("//*[@id='react-root']/div/div/div[2]/main/div/div/div/div[2]/div/div[2]/div/div/div/div[4]/aside/div[2]/div[2]/div/div[2]/div/div[2]/div"));

            Thread.Sleep(1500);

            tkpBtniki.Click();

            Thread.Sleep(1500);


            IWebElement tkpBtnuc = driver.FindElement(By.XPath("//*[@id='react-root']/div/div/div[2]/main/div/div/div/div[2]/div/div[2]/div/div/div/div[4]/aside/div[2]/div[3]/div/div[2]/div/div[2]/div"));

            tkpBtnuc.Click();

            Thread.Sleep(1500);

          

            

            Thread.Sleep(1500);
            driver.Close();
            driver.Quit();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button2.PerformClick();
        }



    }
}
