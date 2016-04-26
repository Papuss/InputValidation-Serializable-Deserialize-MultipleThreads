using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace InputValidation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void nameTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private static string ReformatPhoneString(string s)
        {
            Match m = Regex.Match(s, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");
            return String.Format("({0}) {1}-{2}", m.Groups[1], m.Groups[2], m.Groups[3]);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(nameTextbox.Text, @"^([A-Za-z]*\s*)*$"))
            {
                MessageBox.Show("The name is invalid (only alphabetical characters are allowed)");
            } 

            if (!Regex.IsMatch(phoneTextbox.Text, @"^((\d{3}?)|(\d{3}-))?\d{3}-\d{4}$"))
            {
                MessageBox.Show("The phone number is not a valid US phone number");
            }
            else
            {
                phoneTextbox.Text = ReformatPhoneString(phoneTextbox.Text);
            }

            
            if (!Regex.IsMatch(emailTextbox.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=
            ?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"))
            {
                MessageBox.Show("The e-mail address is not valid.");
            }
                



        }
    }
}
