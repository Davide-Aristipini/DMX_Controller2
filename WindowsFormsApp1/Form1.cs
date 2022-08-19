using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string dataOut;
        public Form1()
        {
            InitializeComponent();
            if (serialPort1.IsOpen)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                dataOut = textBox1.Text;
                serialPort1.WriteLine(dataOut);
                label2.Text = serialPort1.ReadLine();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string message =
                "Vuoi collegarti alla porta:"+comboBox1.Text+"? ";
                string caption = "Form Closing";
                var result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

                // If the no button was pressed ...
                if (result == DialogResult.No)
                {
                   
                } else if(result == DialogResult.Yes)
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = Convert.ToInt32("9600");
                    serialPort1.DataBits = Convert.ToInt32("8");
                    serialPort1.Open();
                }
            }

            catch
            {
                MessageBox.Show("errore");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Crea crea = new Crea();
            crea.Show();
        }

        public void scrivi(int canale, int valore)
        {
            if (serialPort1.IsOpen)
            {
                string stampa = canale.ToString()+"c"+valore.ToString()+"w";
                serialPort1.WriteLine(stampa);
                label2.Text = serialPort1.ReadLine();
            } else
            {
                
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            scrivi(1, trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            scrivi(2, trackBar2.Value);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            scrivi(7, trackBar4.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            scrivi(5, trackBar3.Value);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            scrivi(8, trackBar5.Value);
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            scrivi(9, trackBar6.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(button3.BackColor == Color.Red)
            {
                scrivi(3, 100);
                scrivi(4, 100);
                button3.BackColor = Color.Green;
            } else
            {
                scrivi(3, 0);
                scrivi(4, 0);
                button3.BackColor = Color.Red;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 13; i++)
            {
                scrivi(i + 1, 0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Red)
            {
                scrivi(6, 100);
                button5.BackColor = Color.Green;
            }
            else
            {
                scrivi(6, 0);
                button5.BackColor = Color.Red;
            }
        }
    }
}
