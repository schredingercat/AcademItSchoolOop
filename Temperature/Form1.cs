using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temperature
{
    public partial class Form1 : Form
    {
        private readonly TemperatureController _controller = new TemperatureController();
        public Form1()
        {
            InitializeComponent();
            radioButtonInputCelsius.Checked = true;
            radioButtonOutputFaringate.Checked = true;

            labelTemperatureOutput.DataBindings.Add("Text", _controller, "OutputTemperature", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.InputTemperature = textBoxTemperatureInput.Text;
                _controller.Convert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void radioButtonsInput_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonInputCelsius.Checked)
            {
                _controller.InputScale = Temperature.Scale.Celsius;
            }
            else if (radioButtonInputFaringate.Checked)
            {
                _controller.InputScale = Temperature.Scale.Faringate;
            }
            else if (radioButtonInputKelvin.Checked)
            {
                _controller.InputScale = Temperature.Scale.Kelvin;
            }
        }

        private void radioButtonsOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOutputCelsius.Checked)
            {
                _controller.OutputScale = Temperature.Scale.Celsius;
            }
            else if (radioButtonOutputFaringate.Checked)
            {
                _controller.OutputScale = Temperature.Scale.Faringate;
            }
            else if (radioButtonOutputKelvin.Checked)
            {
                _controller.OutputScale = Temperature.Scale.Kelvin;
            }
        }

        private void textBoxTemperatureInput_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    controller.InputTemperature = textBoxTemperatureInput.Text;
            //}
            //catch (Exception ex)
            //{
            //    textBoxTemperatureInput.Text = 0.0.ToString();
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
