using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void btnClickThis_Click(object sender, EventArgs e)
        {
            lblHelloWorld.Text = "Hello World!";
        }
    }
}
