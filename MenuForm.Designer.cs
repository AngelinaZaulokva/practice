namespace KPoject
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.teoryButton = new System.Windows.Forms.Button();
            this.testingButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.marksButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // teoryButton
            // 
            this.teoryButton.Location = new System.Drawing.Point(78, 48);
            this.teoryButton.Name = "teoryButton";
            this.teoryButton.Size = new System.Drawing.Size(220, 64);
            this.teoryButton.TabIndex = 0;
            this.teoryButton.Text = "Теория";
            this.teoryButton.UseVisualStyleBackColor = true;
            this.teoryButton.Click += new System.EventHandler(this.teoryButton_Click);
            // 
            // testingButton
            // 
            this.testingButton.Location = new System.Drawing.Point(78, 160);
            this.testingButton.Name = "testingButton";
            this.testingButton.Size = new System.Drawing.Size(220, 64);
            this.testingButton.TabIndex = 1;
            this.testingButton.Text = "Тестирорвание";
            this.testingButton.UseVisualStyleBackColor = true;
            this.testingButton.Click += new System.EventHandler(this.testingButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.Location = new System.Drawing.Point(78, 384);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(220, 64);
            this.infoButton.TabIndex = 3;
            this.infoButton.Text = "О программе";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // marksButton
            // 
            this.marksButton.Location = new System.Drawing.Point(78, 272);
            this.marksButton.Name = "marksButton";
            this.marksButton.Size = new System.Drawing.Size(220, 64);
            this.marksButton.TabIndex = 2;
            this.marksButton.Text = "Оценки";
            this.marksButton.UseVisualStyleBackColor = true;
            this.marksButton.Click += new System.EventHandler(this.marksButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 497);
            this.Controls.Add(this.marksButton);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.testingButton);
            this.Controls.Add(this.teoryButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(396, 536);
            this.MinimumSize = new System.Drawing.Size(396, 536);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нормализация базы данных";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button teoryButton;
        private System.Windows.Forms.Button testingButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Button marksButton;
    }
}

