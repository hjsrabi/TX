using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Text = y.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                button3.Text = "Connect";
            }
            else
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                button3.Text = "Disonnect";
                y = serialPort1.BaudRate;
                label3.Text = y.ToString();
            }
            button2.Enabled = serialPort1.IsOpen;
            button4.Enabled = serialPort1.IsOpen;
            button5.Enabled = serialPort1.IsOpen;
            textBox1.Enabled = serialPort1.IsOpen;
            textBox2.Enabled = serialPort1.IsOpen;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
        }
        int y = 0;
        private void button2_Click(object sender, EventArgs e)
        {

            y = int.Parse(textBox1.Text);
            serialPort1.BaudRate = y;
            textBox1.Text = "";
            label3.Text = y.ToString();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox2.Text = openFileDialog1.FileName;
        }

        private void button5_Click(object sender, EventArgs e)
        {


            byte[] data = File.ReadAllBytes(textBox2.Text);
            serialPort1.Write(data, 0, data.Length);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}