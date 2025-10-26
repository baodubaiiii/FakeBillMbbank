using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var formData = new Dictionary<string, string>
{
    {"tennguoinhan", "NGUYEN GIA BAO"},
    {"stk", "901399999999"},
    {"sotienchuyen", "50,000,000"},
    {"nganhangnhan", "mbbank"},
    {"thoigianchuyen", "10:25 - 26/10/2025"},
    {"thoigiantrendt", "10:25"},
    {"noidungchuyen", "ngon"},
    {"stkchinh", "0987654321"},
    {"soduchinh", "7000000"},
    {"kieuchuyen", "macdinh"}
};

            Bitmap img = RenderBill.Render(formData);
            pictureBox1.Image = img;


            img.Save("123.png");
        }
    }
}
