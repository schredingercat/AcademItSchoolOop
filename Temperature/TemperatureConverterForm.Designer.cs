namespace Temperature
{
    partial class TemperatureConverterForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxInputScale.SuspendLayout();
            this.groupBoxOutputScale.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTemperatureInput
            // 
            this.textBoxTemperatureInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxTemperatureInput, 2);
            this.textBoxTemperatureInput.Location = new System.Drawing.Point(15, 15);
            this.textBoxTemperatureInput.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.textBoxTemperatureInput.Name = "textBoxTemperatureInput";
            this.textBoxTemperatureInput.Size = new System.Drawing.Size(394, 20);
            this.textBoxTemperatureInput.TabIndex = 0;
            this.textBoxTemperatureInput.Text = "0";
            // 
            // labelTemperatureOutput
            // 
            this.labelTemperatureOutput.AutoSize = true;
            this.labelTemperatureOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTemperatureOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTemperatureOutput.Location = new System.Drawing.Point(427, 0);
            this.labelTemperatureOutput.Name = "labelTemperatureOutput";
            this.labelTemperatureOutput.Size = new System.Drawing.Size(194, 50);
            this.labelTemperatureOutput.TabIndex = 1;
            this.labelTemperatureOutput.Text = "451 °F";
            this.labelTemperatureOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonConvert.Location = new System.Drawing.Point(454, 90);
            this.buttonConvert.Margin = new System.Windows.Forms.Padding(30, 40, 30, 40);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(140, 70);
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
            this.groupBoxInputScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInputScale.Location = new System.Drawing.Point(15, 65);
            this.groupBoxInputScale.Margin = new System.Windows.Forms.Padding(15);
            this.groupBoxInputScale.Name = "groupBoxInputScale";
            this.groupBoxInputScale.Size = new System.Drawing.Size(182, 121);
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
            this.groupBoxOutputScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOutputScale.Location = new System.Drawing.Point(227, 65);
            this.groupBoxOutputScale.Margin = new System.Windows.Forms.Padding(15);
            this.groupBoxOutputScale.Name = "groupBoxOutputScale";
            this.groupBoxOutputScale.Size = new System.Drawing.Size(182, 121);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxTemperatureInput, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonConvert, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxOutputScale, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTemperatureOutput, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxInputScale, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 201);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // TemperatureConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 201);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(640, 240);
            this.Name = "TemperatureConverterForm";
            this.Text = "Перевод температуры";
            this.groupBoxInputScale.ResumeLayout(false);
            this.groupBoxInputScale.PerformLayout();
            this.groupBoxOutputScale.ResumeLayout(false);
            this.groupBoxOutputScale.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

