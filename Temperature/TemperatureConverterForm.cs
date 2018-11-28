using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Temperature.Controller;
using Temperature.Model;

namespace Temperature
{
    public partial class TemperatureConverterForm : Form
    {
        private readonly TemperatureController _controller = new TemperatureController();

        public TemperatureConverterForm()
        {
            InitializeComponent();

            comboBoxInputScale.DataSource = _controller.InputScales;
            comboBoxInputScale.DisplayMember = "Name";
            comboBoxInputScale.DataBindings.Add("SelectedItem", _controller, "SelectedInputScale", true,
                DataSourceUpdateMode.OnPropertyChanged);

            comboBoxOutputScale.DataSource = _controller.OutputScales;
            comboBoxOutputScale.DisplayMember = "Name";
            comboBoxOutputScale.DataBindings.Add("SelectedItem", _controller, "SelectedOutputScale", true,
                DataSourceUpdateMode.OnPropertyChanged);

            labelTemperatureOutput.DataBindings.Add("Text", _controller, "OutputTemperature", false, DataSourceUpdateMode.OnPropertyChanged);

            _controller.Convert();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            _controller.TryConvert(textBoxTemperatureInput.Text);
        }
        

        private void textBoxTemperatureInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                _controller.TryConvert(textBoxTemperatureInput.Text);
            }
        }
    }
}