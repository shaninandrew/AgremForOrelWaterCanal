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
            SuspendLayout();
            // 
            // SaveIt
            // 
            SaveIt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SaveIt.FlatStyle = FlatStyle.Flat;
            SaveIt.Location = new Point(576, 3);
            SaveIt.Name = "SaveIt";
            SaveIt.Size = new Size(259, 35);
            SaveIt.TabIndex = 0;
            SaveIt.Text = "Сохранить данные";
            SaveIt.UseVisualStyleBackColor = true;
            SaveIt.Click += SaveIt_Click;
            // 
            // UC_Editor_Row_In_DB
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(SaveIt);
            MinimumSize = new Size(457, 532);
            Name = "UC_Editor_Row_In_DB";
            Size = new Size(838, 528);
            Load += UC_Editor_Row_In_DB_Load;
            MouseEnter += UC_Editor_Row_In_DB_MouseEnter;
            MouseLeave += UC_Editor_Row_In_DB_MouseLeave;
            ResumeLayout(false);
        }

        #endregion

        private Button SaveIt;
    }
}
