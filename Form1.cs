using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAFL
{
    public partial class Form1 : Form
    {

        int port;
        public Form1(){
  
            InitializeComponent();
         
            this.AcceptButton = button1;
        }

        public void printDirect()
        {

            // Printer IP Address and communication portv

            string ipAddress = textBox1.Text;
            port = Int32.Parse(textBox2.Text);

            StringBuilder sb;
            sb = new StringBuilder();

            if (textBox3.Text != "")
            {
                string barcode = textBox4.Text + textBox3.Text;
                string dpi300 = "";

                sb.AppendLine("^XA^LH0,0^PQ1^PON");
                if (checkBox1.Checked)
                {
                    sb.AppendLine("^BY3");
                    sb.AppendLine("^FO100,56^BCN,40,Y^FH^FD>;" + barcode + "^FS");
                    sb.AppendLine("^BY2");
                }
                else
                {
                    sb.AppendLine("^BY2");
                    sb.AppendLine("^FO100,56^BCN,40,Y^FH^FD>;" + barcode + "^FS");
                }   
                sb.AppendLine("^XZ");

            }

            try {
                // Open connection
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                client.Connect(ipAddress, port);


                // Write ZPL String to connection
                System.IO.StreamWriter writer = new System.IO.StreamWriter(client.GetStream());
                writer.Write(sb);
                writer.Flush();

                // Close Connection
                writer.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void barcodeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
          
        }

        private void nameBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                    printDirect();
                    Console.Out.WriteLine("Printing Single");
                }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
