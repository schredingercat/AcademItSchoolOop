using System;
using System.Windows.Forms;
using Temperature.Controller;

namespace Temperature
{
    public partial class TemperatureConverterForm : Form
    {
        private readonly TemperatureController _controller = new TemperatureController();

        public TemperatureConverterForm()
        {
            InitializeComponent();
            radioButtonInputCelsius.Checked = true;
            radioButtonOutputFaringate.Checked = true;

            labelTemperatureOutput.DataBindings.Add("Text", _controller, "OutputTemperature", false, DataSourceUpdateMode.OnPropertyChanged);

            _controller.Convert();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.InputTemperature = textBoxTemperatureInput.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _controller.Convert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}