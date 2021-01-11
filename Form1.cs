using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

// I need a title field
// I need a body field
// I need a submission button for content
// I need a url query prefix variable to append keywords

// On submission SPLIT title on spaces and PUSH to QUERY ARRAY (potentially filter out a list of extraneous words/articles/conjunctions)
// On submission SPLIT body on spaces and PUSH to intermediateARRAY
// LOOP through intermediateARRAY and PUSH all bold items into QUERY ARRAY
// Append all elements in QUERY ARRAY to url string


namespace CodeChallenge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(57, 134, 219);
            
 
            
        }

        private void btnClickThis_Click(object sender, EventArgs e)
        {
            var searchQueryPrefix = "http://www.google.com/search?q=";
            var titleText = textBox1.Text;
            var bodyText = richTextBox1.Text;

            // split user input on spaces to iterate through
            var allStringInTextbox = bodyText.Split(" ");
            var allStringInTitlebox = titleText.Split(" ");

            //instantiate new list to push validated elements to
            var finalSearchWords = new List<string>();

            //loop through user input body
            foreach (var word in allStringInTextbox)
            {
                //validation through IsLower method
                if (word.Any(char.IsLower))
                {
                    continue;
                }

                finalSearchWords.Add(word);
            }

            //replace spaces with + for query syntax and iterate through title in similar fashion including all elements though
            var imageSearchPhrase = titleText.Replace(" ", "+");

            foreach (var word in finalSearchWords)
            {
                imageSearchPhrase += "+" + word;
            }

            var finalPrintout = imageSearchPhrase;

            /////////////

            //request string construction
            string requestUrl = "https://www.google.com/search?q=" + finalPrintout + "&tbm=isch";

            //open stream connection to retrieve html response object
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            string resultPage = string.Empty;
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = httpWebResponse.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        resultPage = reader.ReadToEnd();
                    }
                }
            }

            var url = requestUrl;
            var web = new HtmlWeb();
            var doc = web.Load(url);

            //using agility parse response
            var imageNodes = doc.DocumentNode.Descendants("img").ToList();

            var displayImageLinks = new List<string>();
            //excise only first 4 instances of found url in response
            for (int i = 0; i < 4; i++)
            {
                //locate response slices needed using IndexOf and Substring to build the URL
                var imgString = imageNodes[i].OuterHtml;
                var picIndexStart = imgString.IndexOf("data-src=", 0) + 10;
                var picEnd = imgString.IndexOf("jsaction") - 17;
                var imageLinkString = imgString.Substring(picIndexStart, picEnd);
                displayImageLinks.Add(imageLinkString);
            }

            //pictureBox2.Image = urlDownload(imageNodes[0]);
            //pictureBox2.Image = urlDownload(imageNodes[1]);
            //pictureBox3.Image = urlDownload(imageNodes[2]);
            //pictureBox4.Image = urlDownload(imageNodes[3]);

            /////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////IN SUMMATION /////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////


            // ran out of time, but I was attempting to use the pictureBox1-4 and iterate through the list to display image content
            // from there I would add logic to each images' respective checkbox to validate inclusion in file export
            // lastly export items to MS PP
            // this was a fun first-go-round with WinForms. thanks for the mental exercise! :-)

        }




        private void lblHelloWorld_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click_1(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
