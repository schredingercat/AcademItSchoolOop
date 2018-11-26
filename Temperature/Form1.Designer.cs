namespace Temperature
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTemperatureInput = new System.Windows.Forms.TextBox();
            this.labelTemperatureOutput = new System.Windows.Forms.Label();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.groupBoxInputScale = new System.Windows.Forms.GroupBox();
            this.radioButtonInputKelvin = new System.Windows.Forms.RadioButton();
            this.radioButtonInputFaringate = new System.Windows.Forms.RadioButton();
            this.radioButtonInputCelsius = new System.Windows.Forms.RadioButton();
            this.groupBoxOutputScale = new System.Windows.Forms.GroupBox();
            this.radioButtonOutputKelvin = new System.Windows.Forms.RadioButton();
            this.radioButtonOutputFaringate = new System.Windows.Forms.RadioButton();
            this.radioButtonOutputCelsius = new System.Windows.Forms.RadioButton();
            this.groupBoxInputScale.SuspendLayout();
            this.groupBoxOutputScale.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTemperatureInput
            // 
            this.textBoxTemperatureInput.Location = new System.Drawing.Point(12, 36);
            this.textBoxTemperatureInput.Name = "textBoxTemperatureInput";
            this.textBoxTemperatureInput.Size = new System.Drawing.Size(270, 20);
            this.textBoxTemperatureInput.TabIndex = 0;
            this.textBoxTemperatureInput.Text = "0";
            this.textBoxTemperatureInput.Leave += new System.EventHandler(this.textBoxTemperatureInput_Leave);
            // 
            // labelTemperatureOutput
            // 
            this.labelTemperatureOutput.AutoSize = true;
            this.labelTemperatureOutput.Location = new System.Drawing.Point(511, 36);
            this.labelTemperatureOutput.Name = "labelTemperatureOutput";
            this.labelTemperatureOutput.Size = new System.Drawing.Size(35, 13);
            this.labelTemperatureOutput.TabIndex = 1;
            this.labelTemperatureOutput.Text = "label1";
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(12, 130);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 4;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // groupBoxInputScale
            // 
            this.groupBoxInputScale.Controls.Add(this.radioButtonInputKelvin);
            this.groupBoxInputScale.Controls.Add(this.radioButtonInputFaringate);
            this.groupBoxInputScale.Controls.Add(this.radioButtonInputCelsius);
            this.groupBoxInputScale.Location = new System.Drawing.Point(57, 202);
            this.groupBoxInputScale.Name = "groupBoxInputScale";
            this.groupBoxInputScale.Size = new System.Drawing.Size(200, 100);
            this.groupBoxInputScale.TabIndex = 5;
            this.groupBoxInputScale.TabStop = false;
            this.groupBoxInputScale.Text = "Из шкалы";
            // 
            // radioButtonInputKelvin
            // 
            this.radioButtonInputKelvin.AutoSize = true;
            this.radioButtonInputKelvin.Location = new System.Drawing.Point(6, 65);
            this.radioButtonInputKelvin.Name = "radioButtonInputKelvin";
            this.radioButtonInputKelvin.Size = new System.Drawing.Size(74, 17);
            this.radioButtonInputKelvin.TabIndex = 2;
            this.radioButtonInputKelvin.Text = "Кельвина";
            this.radioButtonInputKelvin.UseVisualStyleBackColor = true;
            this.radioButtonInputKelvin.CheckedChanged += new System.EventHandler(this.radioButtonsInput_CheckedChanged);
            // 
            // radioButtonInputFaringate
            // 
            this.radioButtonInputFaringate.AutoSize = true;
            this.radioButtonInputFaringate.Location = new System.Drawing.Point(6, 42);
            this.radioButtonInputFaringate.Name = "radioButtonInputFaringate";
            this.radioButtonInputFaringate.Size = new System.Drawing.Size(88, 17);
            this.radioButtonInputFaringate.TabIndex = 1;
            this.radioButtonInputFaringate.Text = "Фарингейта";
            this.radioButtonInputFaringate.UseVisualStyleBackColor = true;
            this.radioButtonInputFaringate.CheckedChanged += new System.EventHandler(this.radioButtonsInput_CheckedChanged);
            // 
            // radioButtonInputCelsius
            // 
            this.radioButtonInputCelsius.AutoSize = true;
            this.radioButtonInputCelsius.Location = new System.Drawing.Point(6, 19);
            this.radioButtonInputCelsius.Name = "radioButtonInputCelsius";
            this.radioButtonInputCelsius.Size = new System.Drawing.Size(69, 17);
            this.radioButtonInputCelsius.TabIndex = 0;
            this.radioButtonInputCelsius.Text = "Цельсия";
            this.radioButtonInputCelsius.UseVisualStyleBackColor = true;
            this.radioButtonInputCelsius.CheckedChanged += new System.EventHandler(this.radioButtonsInput_CheckedChanged);
            // 
            // groupBoxOutputScale
            // 
            this.groupBoxOutputScale.Controls.Add(this.radioButtonOutputKelvin);
            this.groupBoxOutputScale.Controls.Add(this.radioButtonOutputFaringate);
            this.groupBoxOutputScale.Controls.Add(this.radioButtonOutputCelsius);
            this.groupBoxOutputScale.Location = new System.Drawing.Point(331, 202);
            this.groupBoxOutputScale.Name = "groupBoxOutputScale";
            this.groupBoxOutputScale.Size = new System.Drawing.Size(200, 100);
            this.groupBoxOutputScale.TabIndex = 6;
            this.groupBoxOutputScale.TabStop = false;
            this.groupBoxOutputScale.Text = "В шкалу";
            // 
            // radioButtonOutputKelvin
            // 
            this.radioButtonOutputKelvin.AutoSize = true;
            this.radioButtonOutputKelvin.Location = new System.Drawing.Point(6, 65);
            this.radioButtonOutputKelvin.Name = "radioButtonOutputKelvin";
            this.radioButtonOutputKelvin.Size = new System.Drawing.Size(74, 17);
            this.radioButtonOutputKelvin.TabIndex = 2;
            this.radioButtonOutputKelvin.Text = "Кельвина";
            this.radioButtonOutputKelvin.UseVisualStyleBackColor = true;
            this.radioButtonOutputKelvin.CheckedChanged += new System.EventHandler(this.radioButtonsOutput_CheckedChanged);
            // 
            // radioButtonOutputFaringate
            // 
            this.radioButtonOutputFaringate.AutoSize = true;
            this.radioButtonOutputFaringate.Location = new System.Drawing.Point(6, 42);
            this.radioButtonOutputFaringate.Name = "radioButtonOutputFaringate";
            this.radioButtonOutputFaringate.Size = new System.Drawing.Size(88, 17);
            this.radioButtonOutputFaringate.TabIndex = 1;
            this.radioButtonOutputFaringate.Text = "Фарингейта";
            this.radioButtonOutputFaringate.UseVisualStyleBackColor = true;
            this.radioButtonOutputFaringate.CheckedChanged += new System.EventHandler(this.radioButtonsOutput_CheckedChanged);
            // 
            // radioButtonOutputCelsius
            // 
            this.radioButtonOutputCelsius.AutoSize = true;
            this.radioButtonOutputCelsius.Location = new System.Drawing.Point(6, 19);
            this.radioButtonOutputCelsius.Name = "radioButtonOutputCelsius";
            this.radioButtonOutputCelsius.Size = new System.Drawing.Size(69, 17);
            this.radioButtonOutputCelsius.TabIndex = 0;
            this.radioButtonOutputCelsius.Text = "Цельсия";
            this.radioButtonOutputCelsius.UseVisualStyleBackColor = true;
            this.radioButtonOutputCelsius.CheckedChanged += new System.EventHandler(this.radioButtonsOutput_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxOutputScale);
            this.Controls.Add(this.groupBoxInputScale);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.labelTemperatureOutput);
            this.Controls.Add(this.textBoxTemperatureInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxInputScale.ResumeLayout(false);
            this.groupBoxInputScale.PerformLayout();
            this.groupBoxOutputScale.ResumeLayout(false);
            this.groupBoxOutputScale.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTemperatureInput;
        private System.Windows.Forms.Label labelTemperatureOutput;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.GroupBox groupBoxInputScale;
        private System.Windows.Forms.RadioButton radioButtonInputKelvin;
        private System.Windows.Forms.RadioButton radioButtonInputFaringate;
        private System.Windows.Forms.RadioButton radioButtonInputCelsius;
        private System.Windows.Forms.GroupBox groupBoxOutputScale;
        private System.Windows.Forms.RadioButton radioButtonOutputKelvin;
        private System.Windows.Forms.RadioButton radioButtonOutputFaringate;
        private System.Windows.Forms.RadioButton radioButtonOutputCelsius;
    }
}

