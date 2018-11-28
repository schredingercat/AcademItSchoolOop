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
            this.groupBoxAddScale = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxScaleName = new System.Windows.Forms.TextBox();
            this.textBoxScaleFactor = new System.Windows.Forms.TextBox();
            this.textBoxScaleOffset = new System.Windows.Forms.TextBox();
            this.buttonAddScale = new System.Windows.Forms.Button();
            this.groupBoxInputScale.SuspendLayout();
            this.groupBoxOutputScale.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxAddScale.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTemperatureInput
            // 
            this.textBoxTemperatureInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxTemperatureInput, 2);
            this.textBoxTemperatureInput.Location = new System.Drawing.Point(15, 34);
            this.textBoxTemperatureInput.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.textBoxTemperatureInput.Name = "textBoxTemperatureInput";
            this.textBoxTemperatureInput.Size = new System.Drawing.Size(394, 20);
            this.textBoxTemperatureInput.TabIndex = 0;
            this.textBoxTemperatureInput.Text = "0";
            this.textBoxTemperatureInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTemperatureInput_KeyPress);
            // 
            // labelTemperatureOutput
            // 
            this.labelTemperatureOutput.AutoSize = true;
            this.labelTemperatureOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTemperatureOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTemperatureOutput.Location = new System.Drawing.Point(427, 0);
            this.labelTemperatureOutput.Name = "labelTemperatureOutput";
            this.labelTemperatureOutput.Size = new System.Drawing.Size(194, 88);
            this.labelTemperatureOutput.TabIndex = 1;
            this.labelTemperatureOutput.Text = "451 °F";
            this.labelTemperatureOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonConvert.Location = new System.Drawing.Point(454, 118);
            this.buttonConvert.Margin = new System.Windows.Forms.Padding(30);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(140, 70);
            this.buttonConvert.TabIndex = 4;
            this.buttonConvert.Text = "Конвертировать";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // groupBoxInputScale
            // 
            this.groupBoxInputScale.Controls.Add(this.comboBoxInputScale);
            this.groupBoxInputScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInputScale.Location = new System.Drawing.Point(15, 103);
            this.groupBoxInputScale.Margin = new System.Windows.Forms.Padding(15);
            this.groupBoxInputScale.Name = "groupBoxInputScale";
            this.groupBoxInputScale.Size = new System.Drawing.Size(182, 124);
            this.groupBoxInputScale.TabIndex = 5;
            this.groupBoxInputScale.TabStop = false;
            this.groupBoxInputScale.Text = "Из шкалы";
            // 
            // groupBoxOutputScale
            // 
            this.groupBoxOutputScale.Controls.Add(this.comboBoxOutputScale);
            this.groupBoxOutputScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOutputScale.Location = new System.Drawing.Point(227, 103);
            this.groupBoxOutputScale.Margin = new System.Windows.Forms.Padding(15);
            this.groupBoxOutputScale.Name = "groupBoxOutputScale";
            this.groupBoxOutputScale.Size = new System.Drawing.Size(182, 124);
            this.groupBoxOutputScale.TabIndex = 6;
            this.groupBoxOutputScale.TabStop = false;
            this.groupBoxOutputScale.Text = "В шкалу";
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
            this.tableLayoutPanel1.Controls.Add(this.groupBoxAddScale, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 441);
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
            // groupBoxAddScale
            // 
            this.groupBoxAddScale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBoxAddScale, 3);
            this.groupBoxAddScale.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxAddScale.Location = new System.Drawing.Point(15, 257);
            this.groupBoxAddScale.Margin = new System.Windows.Forms.Padding(15);
            this.groupBoxAddScale.Name = "groupBoxAddScale";
            this.groupBoxAddScale.Size = new System.Drawing.Size(594, 169);
            this.groupBoxAddScale.TabIndex = 7;
            this.groupBoxAddScale.TabStop = false;
            this.groupBoxAddScale.Text = "Добавить свою шкалу";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxScaleName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxScaleFactor, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBoxScaleOffset, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonAddScale, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(588, 150);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "0°C по новой шкале";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "100°C по новой шкале";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Название шкалы";
            // 
            // textBoxScaleName
            // 
            this.textBoxScaleName.Location = new System.Drawing.Point(234, 3);
            this.textBoxScaleName.Name = "textBoxScaleName";
            this.textBoxScaleName.Size = new System.Drawing.Size(100, 20);
            this.textBoxScaleName.TabIndex = 3;
            this.textBoxScaleName.Text = "Реомюра";
            // 
            // textBoxScaleFactor
            // 
            this.textBoxScaleFactor.Location = new System.Drawing.Point(234, 44);
            this.textBoxScaleFactor.Name = "textBoxScaleFactor";
            this.textBoxScaleFactor.Size = new System.Drawing.Size(100, 20);
            this.textBoxScaleFactor.TabIndex = 4;
            this.textBoxScaleFactor.Text = "0";
            // 
            // textBoxScaleOffset
            // 
            this.textBoxScaleOffset.Location = new System.Drawing.Point(234, 85);
            this.textBoxScaleOffset.Name = "textBoxScaleOffset";
            this.textBoxScaleOffset.Size = new System.Drawing.Size(100, 20);
            this.textBoxScaleOffset.TabIndex = 5;
            this.textBoxScaleOffset.Text = "80";
            // 
            // buttonAddScale
            // 
            this.buttonAddScale.Location = new System.Drawing.Point(465, 85);
            this.buttonAddScale.Name = "buttonAddScale";
            this.buttonAddScale.Size = new System.Drawing.Size(75, 23);
            this.buttonAddScale.TabIndex = 6;
            this.buttonAddScale.Text = "Добавить";
            this.buttonAddScale.UseVisualStyleBackColor = true;
            this.buttonAddScale.Click += new System.EventHandler(this.buttonAddScale_Click);
            // 
            // TemperatureConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "TemperatureConverterForm";
            this.Text = "Перевод температуры";
            this.groupBoxInputScale.ResumeLayout(false);
            this.groupBoxOutputScale.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxAddScale.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxAddScale;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxScaleName;
        private System.Windows.Forms.TextBox textBoxScaleFactor;
        private System.Windows.Forms.TextBox textBoxScaleOffset;
        private System.Windows.Forms.Button buttonAddScale;
    }
}

