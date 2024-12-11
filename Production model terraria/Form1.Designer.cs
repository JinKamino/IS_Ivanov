
namespace Product_model
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
            this.downloadRules = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.downloadDescriprion = new System.Windows.Forms.Button();
            this.rulesOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.TextBox();
            this.targetText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.initialText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.backwardOut = new System.Windows.Forms.Button();
            this.forwardOut = new System.Windows.Forms.Button();
            this.fLabel2 = new System.Windows.Forms.Label();
            this.fLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // downloadRules
            // 
            this.downloadRules.Location = new System.Drawing.Point(131, 437);
            this.downloadRules.Name = "downloadRules";
            this.downloadRules.Size = new System.Drawing.Size(75, 23);
            this.downloadRules.TabIndex = 0;
            this.downloadRules.Text = "Загрузить";
            this.downloadRules.UseVisualStyleBackColor = true;
            this.downloadRules.Click += new System.EventHandler(this.downloadRules_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Список правил";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 479);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Описание правил";
            // 
            // downloadDescriprion
            // 
            this.downloadDescriprion.Location = new System.Drawing.Point(131, 474);
            this.downloadDescriprion.Name = "downloadDescriprion";
            this.downloadDescriprion.Size = new System.Drawing.Size(75, 23);
            this.downloadDescriprion.TabIndex = 14;
            this.downloadDescriprion.Text = "Загрузить";
            this.downloadDescriprion.UseVisualStyleBackColor = true;
            this.downloadDescriprion.Click += new System.EventHandler(this.downloadDescriprion_Click);
            // 
            // rulesOutput
            // 
            this.rulesOutput.BackColor = System.Drawing.Color.White;
            this.rulesOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rulesOutput.Location = new System.Drawing.Point(12, 35);
            this.rulesOutput.Multiline = true;
            this.rulesOutput.Name = "rulesOutput";
            this.rulesOutput.ReadOnly = true;
            this.rulesOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rulesOutput.Size = new System.Drawing.Size(324, 300);
            this.rulesOutput.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Список правил";
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.BackColor = System.Drawing.Color.White;
            this.output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.output.Location = new System.Drawing.Point(358, 35);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(631, 506);
            this.output.TabIndex = 19;
            // 
            // targetText
            // 
            this.targetText.Location = new System.Drawing.Point(131, 397);
            this.targetText.Name = "targetText";
            this.targetText.Size = new System.Drawing.Size(36, 20);
            this.targetText.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Целевой факт:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Начальные факты:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // initialText
            // 
            this.initialText.Location = new System.Drawing.Point(131, 357);
            this.initialText.Name = "initialText";
            this.initialText.Size = new System.Drawing.Size(205, 20);
            this.initialText.TabIndex = 22;
            this.initialText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(949, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Вывод";
            // 
            // backwardOut
            // 
            this.backwardOut.Location = new System.Drawing.Point(181, 518);
            this.backwardOut.Name = "backwardOut";
            this.backwardOut.Size = new System.Drawing.Size(160, 23);
            this.backwardOut.TabIndex = 26;
            this.backwardOut.Text = "Обратный вывод";
            this.backwardOut.UseVisualStyleBackColor = true;
            this.backwardOut.Click += new System.EventHandler(this.backwardOut_Click);
            // 
            // forwardOut
            // 
            this.forwardOut.Location = new System.Drawing.Point(15, 518);
            this.forwardOut.Name = "forwardOut";
            this.forwardOut.Size = new System.Drawing.Size(160, 23);
            this.forwardOut.TabIndex = 25;
            this.forwardOut.Text = "Прямой вывод";
            this.forwardOut.UseVisualStyleBackColor = true;
            this.forwardOut.Click += new System.EventHandler(this.forwardOut_Click);
            // 
            // fLabel2
            // 
            this.fLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fLabel2.Location = new System.Drawing.Point(222, 479);
            this.fLabel2.Name = "fLabel2";
            this.fLabel2.Size = new System.Drawing.Size(96, 13);
            this.fLabel2.TabIndex = 28;
            // 
            // fLabel1
            // 
            this.fLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fLabel1.Location = new System.Drawing.Point(222, 442);
            this.fLabel1.Name = "fLabel1";
            this.fLabel1.Size = new System.Drawing.Size(96, 13);
            this.fLabel1.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 565);
            this.Controls.Add(this.fLabel2);
            this.Controls.Add(this.fLabel1);
            this.Controls.Add(this.backwardOut);
            this.Controls.Add(this.forwardOut);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.initialText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.targetText);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rulesOutput);
            this.Controls.Add(this.downloadDescriprion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downloadRules);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadRules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button downloadDescriprion;
        private System.Windows.Forms.TextBox rulesOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.TextBox targetText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox initialText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button backwardOut;
        private System.Windows.Forms.Button forwardOut;
        private System.Windows.Forms.Label fLabel2;
        private System.Windows.Forms.Label fLabel1;
    }
}

