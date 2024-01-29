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
            LVCX = new DocGen7.Кастомные_контролы.ListViewForDataPoint(_main);
            SuspendLayout();
            // 
            // LVCX
            // 
            LVCX.BackColor = Color.LightSkyBlue;
            LVCX.Dock = DockStyle.Top;
            LVCX.Location = new Point(0, 0);
            LVCX.Margin = new Padding(3, 4, 3, 4);
            LVCX.Name = "LVCX";
            LVCX.Size = new Size(1119, 384);
            LVCX.TabIndex = 0;
            LVCX.Click += LVCX_Click;
            // 
            // Editor_Price
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 679);
            Controls.Add(LVCX);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Editor_Price";
            Text = "Редактор_прайса";
            Load += Editor_Price_Load;
            ResumeLayout(false);
        }

        #endregion

        public DocGen7.Кастомные_контролы.ListViewForDataPoint LVC;
        private DocGen7.Кастомные_контролы.ListViewForDataPoint listViewForDataPoint1;
        public DocGen7.Кастомные_контролы.ListViewForDataPoint LVCX;
    }
}