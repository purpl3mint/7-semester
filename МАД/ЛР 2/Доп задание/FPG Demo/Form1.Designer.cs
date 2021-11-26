
namespace FPG_Demo
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.idRule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conditionRule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consequenceRule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supportRule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confidenceRule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(281, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Открыть файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idData,
            this.valueData});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(272, 210);
            this.dataGridView1.TabIndex = 1;
            // 
            // idData
            // 
            this.idData.HeaderText = "ID";
            this.idData.Name = "idData";
            this.idData.ReadOnly = true;
            // 
            // valueData
            // 
            this.valueData.HeaderText = "Значение";
            this.valueData.Name = "valueData";
            this.valueData.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTransaction,
            this.valueTransaction});
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(272, 210);
            this.dataGridView2.TabIndex = 0;
            // 
            // idTransaction
            // 
            this.idTransaction.HeaderText = "ID";
            this.idTransaction.Name = "idTransaction";
            this.idTransaction.ReadOnly = true;
            // 
            // valueTransaction
            // 
            this.valueTransaction.HeaderText = "Значение";
            this.valueTransaction.Name = "valueTransaction";
            this.valueTransaction.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(280, 236);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(272, 210);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Данные";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(272, 210);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Транзакции";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar4);
            this.groupBox1.Controls.Add(this.progressBar3);
            this.groupBox1.Controls.Add(this.progressBar2);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDown4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDown3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(13, 274);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 196);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // progressBar4
            // 
            this.progressBar4.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar4.ForeColor = System.Drawing.Color.DarkOrange;
            this.progressBar4.Location = new System.Drawing.Point(150, 171);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(120, 10);
            this.progressBar4.Step = 1;
            this.progressBar4.TabIndex = 11;
            this.progressBar4.Value = 90;
            // 
            // progressBar3
            // 
            this.progressBar3.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar3.ForeColor = System.Drawing.Color.DarkOrange;
            this.progressBar3.Location = new System.Drawing.Point(150, 129);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(120, 10);
            this.progressBar3.Step = 1;
            this.progressBar3.TabIndex = 10;
            this.progressBar3.Value = 40;
            // 
            // progressBar2
            // 
            this.progressBar2.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar2.ForeColor = System.Drawing.Color.DarkOrange;
            this.progressBar2.Location = new System.Drawing.Point(150, 87);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(120, 10);
            this.progressBar2.Step = 1;
            this.progressBar2.TabIndex = 9;
            this.progressBar2.Value = 20;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.DarkOrange;
            this.progressBar1.Location = new System.Drawing.Point(150, 45);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(120, 10);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Value = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Max. Достоверность, %";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown4.Location = new System.Drawing.Point(150, 145);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown4.TabIndex = 6;
            this.numericUpDown4.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Min. Достоверность, %";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown3.Location = new System.Drawing.Point(150, 103);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown3.TabIndex = 4;
            this.numericUpDown3.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max. Поддержка, %";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown2.Location = new System.Drawing.Point(150, 61);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 2;
            this.numericUpDown2.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Min. Поддержка, %";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(150, 19);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 476);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(276, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Найти правила";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView3);
            this.groupBox2.Location = new System.Drawing.Point(299, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 496);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ассоциативные правила";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRule,
            this.conditionRule,
            this.consequenceRule,
            this.supportRule,
            this.confidenceRule});
            this.dataGridView3.Location = new System.Drawing.Point(6, 19);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(477, 471);
            this.dataGridView3.TabIndex = 0;
            // 
            // idRule
            // 
            this.idRule.HeaderText = "№ правила";
            this.idRule.Name = "idRule";
            this.idRule.ReadOnly = true;
            this.idRule.Width = 55;
            // 
            // conditionRule
            // 
            this.conditionRule.HeaderText = "Условие";
            this.conditionRule.Name = "conditionRule";
            this.conditionRule.ReadOnly = true;
            this.conditionRule.Width = 90;
            // 
            // consequenceRule
            // 
            this.consequenceRule.HeaderText = "Следствие";
            this.consequenceRule.Name = "consequenceRule";
            this.consequenceRule.ReadOnly = true;
            this.consequenceRule.Width = 90;
            // 
            // supportRule
            // 
            this.supportRule.HeaderText = "Поддержка, %";
            this.supportRule.Name = "supportRule";
            this.supportRule.ReadOnly = true;
            this.supportRule.Width = 80;
            // 
            // confidenceRule
            // 
            this.confidenceRule.HeaderText = "Достоверность, %";
            this.confidenceRule.Name = "confidenceRule";
            this.confidenceRule.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "FPG Demo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idData;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueData;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueTransaction;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn conditionRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn consequenceRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn supportRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn confidenceRule;
    }
}

