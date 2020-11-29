using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace IViR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LogOutputtextBox1.Text = "Ready.\r\n";
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            LogOutputtextBox1.Clear();
            LogOutputtextBox1.AppendText("Requesting..\r\n");
            LoadPageWithDigestAuthentication(CamURLtextBox.Text, UsernametextBox.Text, PasswordtextBox.Text);
            LogOutputtextBox1.AppendText("Finished Request.");
        }

        private void LoadPageWithDigestAuthentication(string url, string username, string password)
        {
            Uri myUri = new Uri(url);
            WebRequest myWebRequest = HttpWebRequest.Create(myUri);
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;
            NetworkCredential myNetworkCredential = new NetworkCredential(username, password);
            CredentialCache myCredentialCache = new CredentialCache();
            myCredentialCache.Add(myUri, "Digest", myNetworkCredential);

            myHttpWebRequest.PreAuthenticate = true;
            myHttpWebRequest.Credentials = myCredentialCache;

            LogOutputtextBox1.AppendText("Querying camera..\r\n");
            WebResponse myWebResponse = myWebRequest.GetResponse();
            LogOutputtextBox1.AppendText("Got response..\r\n");

            Image img = Image.FromStream(myWebResponse.GetResponseStream());
            LogOutputtextBox1.AppendText("Saving image..\r\n");

            img.Save(Application.StartupPath + @"\" + DateTime.Now.ToString("ddMMyyyy-HHmmss") + ".png");
            LogOutputtextBox1.AppendText("Image saved..\r\n");

            pictureBox1.Image = img;
            LogOutputtextBox1.AppendText("Picturebox image loaded..\r\n");

            myWebResponse.Close();
            LogOutputtextBox1.AppendText("Close request stream..\r\n");

        }

    }
}
