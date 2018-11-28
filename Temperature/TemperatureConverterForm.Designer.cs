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
            this.groupBoxOutputScale = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxInputScale = new System.Windows.Forms.ComboBox();
            this.comboBoxOutputScale = new System.Windows.Forms.ComboBox();
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
            this.textBoxTemperatureInput.Size = new System.Drawing.Size(422, 20);
            this.textBoxTemperatureInput.TabIndex = 0;
            this.textBoxTemperatureInput.Text = "0";
            this.textBoxTemperatureInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTemperatureInput_KeyPress);
            // 
            // labelTemperatureOutput
            // 
            this.labelTemperatureOutput.AutoSize = true;
            this.labelTemperatureOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTemperatureOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTemperatureOutput.Location = new System.Drawing.Point(455, 0);
            this.labelTemperatureOutput.Name = "labelTemperatureOutput";
            this.labelTemperatureOutput.Size = new System.Drawing.Size(170, 50);
            this.labelTemperatureOutput.TabIndex = 1;
            this.labelTemperatureOutput.Text = "451 °F";
            this.labelTemperatureOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonConvert.Location = new System.Drawing.Point(482, 90);
            this.buttonConvert.Margin = new System.Windows.Forms.Padding(30, 40, 30, 40);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(116, 70);
            this.buttonConvert.TabIndex = 4;
            this.buttonConvert.Text = "Конвертировать";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // groupBoxInputScale
            // 
            this.groupBoxInputScale.Controls.Add(this.comboBoxInputScale);
            this.groupBoxInputScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInputScale.Location = new System.Drawing.Point(15, 65);
            this.groupBoxInputScale.Margin = new System.Windows.Forms.Padding(15);
            this.groupBoxInputScale.Name = "groupBoxInputScale";
            this.groupBoxInputScale.Size = new System.Drawing.Size(196, 121);
            this.groupBoxInputScale.TabIndex = 5;
            this.groupBoxInputScale.TabStop = false;
            this.groupBoxInputScale.Text = "Из шкалы";
            // 
            // groupBoxOutputScale
            // 
            this.groupBoxOutputScale.Controls.Add(this.comboBoxOutputScale);
            this.groupBoxOutputScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOutputScale.Location = new System.Drawing.Point(241, 65);
            this.groupBoxOutputScale.Margin = new System.Windows.Forms.Padding(15);
            this.groupBoxOutputScale.Name = "groupBoxOutputScale";
            this.groupBoxOutputScale.Size = new System.Drawing.Size(196, 121);
            this.groupBoxOutputScale.TabIndex = 6;
            this.groupBoxOutputScale.TabStop = false;
            this.groupBoxOutputScale.Text = "В шкалу";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 201);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // comboBoxInputScale
            // 
            this.comboBoxInputScale.FormattingEnabled = true;
            this.comboBoxInputScale.Location = new System.Drawing.Point(6, 19);
            this.comboBoxInputScale.Name = "comboBoxInputScale";
            this.comboBoxInputScale.Size = new System.Drawing.Size(141, 21);
            this.comboBoxInputScale.TabIndex = 7;
            // 
            // comboBoxOutputScale
            // 
            this.comboBoxOutputScale.FormattingEnabled = true;
            this.comboBoxOutputScale.Location = new System.Drawing.Point(6, 19);
            this.comboBoxOutputScale.Name = "comboBoxOutputScale";
            this.comboBoxOutputScale.Size = new System.Drawing.Size(141, 21);
            this.comboBoxOutputScale.TabIndex = 8;
            // 
            // TemperatureConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 201);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(640, 240);
            this.Name = "TemperatureConverterForm";
            this.Text = "Перевод температуры";
            this.groupBoxInputScale.ResumeLayout(false);
            this.groupBoxOutputScale.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTemperatureInput;
        private System.Windows.Forms.Label labelTemperatureOutput;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.GroupBox groupBoxInputScale;
        private System.Windows.Forms.GroupBox groupBoxOutputScale;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxInputScale;
        private System.Windows.Forms.ComboBox comboBoxOutputScale;
    }
}

