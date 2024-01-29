﻿namespace DocGen7.Кастомные_контролы
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
            DeleteExists = new Button();
            AddNew = new Button();
            LVC_Title = new Label();
            LVC = new ListView();
            PanelForEditor = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DodgerBlue;
            panel1.Controls.Add(DeleteExists);
            panel1.Controls.Add(AddNew);
            panel1.Controls.Add(LVC_Title);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(945, 66);
            panel1.TabIndex = 0;
            // 
            // DeleteExists
            // 
            DeleteExists.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DeleteExists.Location = new Point(720, 13);
            DeleteExists.Name = "DeleteExists";
            DeleteExists.Size = new Size(201, 46);
            DeleteExists.TabIndex = 2;
            DeleteExists.Text = "Удалить позицию";
            DeleteExists.UseVisualStyleBackColor = true;
            DeleteExists.Click += DeleteExists_Click;
            // 
            // AddNew
            // 
            AddNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AddNew.Location = new Point(503, 13);
            AddNew.Name = "AddNew";
            AddNew.Size = new Size(201, 46);
            AddNew.TabIndex = 1;
            AddNew.Text = "+Новая позиция";
            AddNew.UseVisualStyleBackColor = true;
            AddNew.Click += AddNew_Click;
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
            LVC.Location = new Point(0, 66);
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
            PanelForEditor.Location = new Point(0, 347);
            PanelForEditor.Name = "PanelForEditor";
            PanelForEditor.Size = new Size(945, 327);
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
        private Button DeleteExists;
        private Button AddNew;
    }
}
