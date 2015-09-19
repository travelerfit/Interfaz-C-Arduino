using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmTurnONTurnOFFLED : Form
    {
        public frmTurnONTurnOFFLED()
        {
            InitializeComponent();
        }
        private void btnTurnON_Click(object sender, EventArgs e)
        {
            try
            {

                string d = textBox1.Text;

                //serialPort1.Write("1"); //send 1 to Arduino
                byte[] mBuffer = Encoding.ASCII.GetBytes(d);
                serialPort.Write(mBuffer, 0, mBuffer.Length);


                int intReturnASCII = 0;
                int count = serialPort.BytesToRead;
                string returnMessage = "";
                while (count > 0)
                {
                    intReturnASCII = serialPort.ReadByte();
                    returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                    count--;
                }

                               
                string result = returnMessage;

                //serialPort.Read(mBuffer, 0, mBuffer.Length);

                

                label1.Text= result;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTurnOFF_Click(object sender, EventArgs e)
        {
            try
            {
                //serialPort1.Write("0"); //send 0 to Arduino
                byte[] mBuffer = Encoding.ASCII.GetBytes("apagar");
                serialPort.Write(mBuffer, 0, mBuffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmTurnONTurnOFFLED_Load(object sender, EventArgs e)
        {
            serialPort.Open(); //open serialPort
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {
            serialPort.Close(); //close serialPort
        }

        private void btnTurnON_Click_1(object sender, EventArgs e)
        {

        }
       
     
    }
}
