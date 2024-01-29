namespace wfa_symple
{
    partial class Editor_Price
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
            Add_Price = new Button();
            Delete_Price = new Button();
            SuspendLayout();
            // 
            // Add_Price
            // 
            Add_Price.Location = new Point(12, 12);
            Add_Price.Name = "Add_Price";
            Add_Price.Size = new Size(115, 38);
            Add_Price.TabIndex = 0;
            Add_Price.Text = "Добавить услугу";
            Add_Price.UseVisualStyleBackColor = true;
            // 
            // Delete_Price
            // 
            Delete_Price.Location = new Point(133, 12);
            Delete_Price.Name = "Delete_Price";
            Delete_Price.Size = new Size(115, 38);
            Delete_Price.TabIndex = 1;
            Delete_Price.Text = "Удалить услугу";
            Delete_Price.UseVisualStyleBackColor = true;
            // 
            // Editor_Price
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Delete_Price);
            Controls.Add(Add_Price);
            Name = "Editor_Price";
            Text = "Редактор_прайса";
            ResumeLayout(false);
        }

        #endregion

        private Button Add_Price;
        private Button Delete_Price;
    }
}