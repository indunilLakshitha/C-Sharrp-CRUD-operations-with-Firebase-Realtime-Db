using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.IO;
using System.Drawing.Imaging;

namespace firebase_trial
{
   
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "lJ00CGCubk8WK0tl0zD2ZUULDmVkUfVA1fXqqs0V",
            BasePath = "https://c-sharp-2a4aa.firebaseio.com/"
        };
        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
           /* if (client != null)
            {
                MessageBox.Show("connected");
            }*/
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                id=textBox1.Text,
                name=textBox2.Text,
                adress=textBox3.Text,
                mobile=textBox4.Text
            };
            SetResponse response = await client.SetTaskAsync( "information/"+textBox1.Text, data);
            Data result = response.ResultAs<Data>();
            MessageBox.Show("Data inserted of id no " + result.id);

        }

        private async void btnRetriev_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetTaskAsync("information/" +textBox1.Text);
            Data obj = response.ResultAs<Data>();
            textBox2.Text = obj.name;
            textBox3.Text = obj.adress;
            textBox4.Text = obj.adress;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                id = textBox1.Text,
                name = textBox2.Text,
                adress = textBox3.Text,
                mobile = textBox4.Text
            };
            FirebaseResponse response = await client.UpdateTaskAsync("information/" + textBox1.Text, data);
            Data result = response.ResultAs<Data>();
            MessageBox.Show("Data inserted of id no " + result.id);
        }

        private async void btnDelRec_Click(object sender, EventArgs e)
        {

        }

        private async void btnDelAll_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.DeleteTaskAsync("information/" + textBox1.Text);

        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select An Image";
            ofd.Filter = "Image Filters(*.jpg) | *.jpg";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
               
                Image img = new Bitmap(ofd.FileName);
                pictureBox1.Image = img.GetThumbnailImage(350,200,null,new IntPtr());
            }
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            //in this we convert image in the pictureBox to memory stream --> byte array --> toBase64String

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
            byte[] a = ms.GetBuffer();
            String output = Convert.ToBase64String(a);
            var data = new Image_Modal
            {
                Img=output

            };
            SetResponse response =await client.SetTaskAsync ("Image/",data);
            Image_Modal results = response.ResultAs<Image_Modal>();

        }

        private async void btnView_Click(object sender, EventArgs e)
        {
            //convert base64String --> byte array --> memory stream --> bitemap

            FirebaseResponse response = await client.GetTaskAsync("Image/");
            Image_Modal image = response.ResultAs<Image_Modal>();
            byte[] b = Convert.FromBase64String(image.Img);
            MemoryStream ms = new MemoryStream();
            ms.Write(b, 0, Convert.ToInt32(b.Length));

            Bitmap bm = new Bitmap(ms, false);
            ms.Dispose();

            pictureBox1.Image = bm;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
