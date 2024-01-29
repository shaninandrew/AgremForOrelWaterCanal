namespace DocGen7.Кастомные_контролы
{
    partial class ListViewForDataPoint
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
            panel1 = new Panel();
            LVC_Title = new Label();
            LVC = new ListView();
            PanelForEditor = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(LVC_Title);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(945, 39);
            panel1.TabIndex = 0;
            // 
            // LVC_Title
            // 
            LVC_Title.AutoSize = true;
            LVC_Title.Location = new Point(13, 11);
            LVC_Title.Name = "LVC_Title";
            LVC_Title.Size = new Size(50, 20);
            LVC_Title.TabIndex = 0;
            LVC_Title.Text = "label1";
            // 
            // LVC
            // 
            LVC.BackColor = Color.LightBlue;
            LVC.BorderStyle = BorderStyle.None;
            LVC.Dock = DockStyle.Top;
            LVC.FullRowSelect = true;
            LVC.Location = new Point(0, 39);
            LVC.Margin = new Padding(3, 4, 3, 4);
            LVC.Name = "LVC";
            LVC.Size = new Size(945, 281);
            LVC.TabIndex = 1;
            LVC.UseCompatibleStateImageBehavior = false;
            LVC.View = View.List;
            LVC.SelectedIndexChanged += LVC_SelectedIndexChanged;
            // 
            // PanelForEditor
            // 
            PanelForEditor.Dock = DockStyle.Fill;
            PanelForEditor.Location = new Point(0, 320);
            PanelForEditor.Name = "PanelForEditor";
            PanelForEditor.Size = new Size(945, 354);
            PanelForEditor.TabIndex = 2;
            PanelForEditor.Paint += PanelForEditor_Paint;
            // 
            // ListViewForDataPoint
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            Controls.Add(PanelForEditor);
            Controls.Add(LVC);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ListViewForDataPoint";
            Size = new Size(945, 674);
            Load += ListViewForDataPoint_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ListView LVC;
        public Label LVC_Title;
        private Panel PanelForEditor;
    }
}
