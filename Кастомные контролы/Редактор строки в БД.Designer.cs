namespace DocGen7.Кастомные_контролы
{
    partial class UC_Editor_Row_In_DB
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            SaveIt = new Button();
            maskedTextBox1 = new MaskedTextBox();
            SuspendLayout();
            // 
            // SaveIt
            // 
            SaveIt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SaveIt.FlatStyle = FlatStyle.Flat;
            SaveIt.Location = new Point(16, 364);
            SaveIt.Name = "SaveIt";
            SaveIt.Size = new Size(355, 35);
            SaveIt.TabIndex = 0;
            SaveIt.Text = "Сохранить данные";
            SaveIt.UseVisualStyleBackColor = true;
            SaveIt.Click += SaveIt_Click;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(651, 371);
            maskedTextBox1.Mask = "#####0.00";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(125, 27);
            maskedTextBox1.TabIndex = 1;
            // 
            // UC_Editor_Row_In_DB
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(maskedTextBox1);
            Controls.Add(SaveIt);
            Name = "UC_Editor_Row_In_DB";
            Size = new Size(842, 415);
            Load += UC_Editor_Row_In_DB_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveIt;
        private MaskedTextBox maskedTextBox1;
    }
}
