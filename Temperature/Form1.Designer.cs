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
            this.comboBoxInputScale = new System.Windows.Forms.ComboBox();
            this.comboBoxOutputScale = new System.Windows.Forms.ComboBox();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTemperatureInput
            // 
            this.textBoxTemperatureInput.Location = new System.Drawing.Point(12, 36);
            this.textBoxTemperatureInput.Name = "textBoxTemperatureInput";
            this.textBoxTemperatureInput.Size = new System.Drawing.Size(270, 20);
            this.textBoxTemperatureInput.TabIndex = 0;
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
            // comboBoxInputScale
            // 
            this.comboBoxInputScale.FormattingEnabled = true;
            this.comboBoxInputScale.Location = new System.Drawing.Point(12, 87);
            this.comboBoxInputScale.Name = "comboBoxInputScale";
            this.comboBoxInputScale.Size = new System.Drawing.Size(270, 21);
            this.comboBoxInputScale.TabIndex = 2;
            // 
            // comboBoxOutputScale
            // 
            this.comboBoxOutputScale.FormattingEnabled = true;
            this.comboBoxOutputScale.Location = new System.Drawing.Point(366, 87);
            this.comboBoxOutputScale.Name = "comboBoxOutputScale";
            this.comboBoxOutputScale.Size = new System.Drawing.Size(270, 21);
            this.comboBoxOutputScale.TabIndex = 3;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.comboBoxOutputScale);
            this.Controls.Add(this.comboBoxInputScale);
            this.Controls.Add(this.labelTemperatureOutput);
            this.Controls.Add(this.textBoxTemperatureInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTemperatureInput;
        private System.Windows.Forms.Label labelTemperatureOutput;
        private System.Windows.Forms.ComboBox comboBoxInputScale;
        private System.Windows.Forms.ComboBox comboBoxOutputScale;
        private System.Windows.Forms.Button buttonConvert;
    }
}

