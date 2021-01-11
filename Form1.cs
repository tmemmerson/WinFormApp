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
            var searchQuerySuffix = "&hl=en&source=lnms&tbm=isch&sa=X&ved=2ahUKEwi7gvj575LuAhXjK30KHSNMBRoQ_AUoAXoECBYQAw&cshid=1610333569422809&biw=1671&bih=1514";
            var titleText = textBox1.Text;

            var bodyText = richTextBox1.Text;

            var allStringInTextbox = bodyText.Split(" ");
            var allStringInTitlebox = titleText.Split(" ");

            var finalSearchWords = new List<string>();

            foreach (var word in allStringInTextbox)
            {
                if (word.Any(char.IsLower))
                {
                    continue;
                }

                finalSearchWords.Add(word);
            }

            var imageSearchPhrase = titleText.Replace(" ", "+");

            foreach (var word in finalSearchWords)
            {
                imageSearchPhrase += "+" + word;
            }

            var finalPrintout = imageSearchPhrase;
            
            string requestUrl = "https://www.google.com/search?q=" + finalPrintout + "&tbm=isch";
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
        

    }
}
