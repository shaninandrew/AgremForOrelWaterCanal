namespace wfa_symple
{
    partial class MainWindoiw
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            splitContainer1 = new SplitContainer();
            button3 = new Button();
            ShowGenerator = new Button();
            ShowPrice = new Button();
            Main_Split_Conatainer = new SplitContainer();
            menuStrip1 = new MenuStrip();
            подключениеToolStripMenuItem = new ToolStripMenuItem();
            настрйокиToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            выходToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Main_Split_Conatainer).BeginInit();
            Main_Split_Conatainer.Panel1.SuspendLayout();
            Main_Split_Conatainer.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 518);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 18, 0);
            statusStrip1.Size = new Size(1029, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.RoyalBlue;
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(ShowGenerator);
            splitContainer1.Panel1.Controls.Add(ShowPrice);
            splitContainer1.Panel1MinSize = 30;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(Main_Split_Conatainer);
            splitContainer1.Size = new Size(1029, 518);
            splitContainer1.SplitterDistance = 111;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 1;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(0, 86);
            button3.Name = "button3";
            button3.Padding = new Padding(2);
            button3.Size = new Size(107, 48);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            // 
            // ShowGenerator
            // 
            ShowGenerator.BackColor = Color.RoyalBlue;
            ShowGenerator.BackgroundImageLayout = ImageLayout.None;
            ShowGenerator.Dock = DockStyle.Top;
            ShowGenerator.FlatStyle = FlatStyle.Flat;
            ShowGenerator.ForeColor = Color.White;
            ShowGenerator.Location = new Point(0, 40);
            ShowGenerator.Name = "ShowGenerator";
            ShowGenerator.Padding = new Padding(2);
            ShowGenerator.Size = new Size(107, 46);
            ShowGenerator.TabIndex = 1;
            ShowGenerator.Text = "Документ";
            ShowGenerator.TextAlign = ContentAlignment.MiddleLeft;
            ShowGenerator.UseVisualStyleBackColor = false;
            ShowGenerator.Click += button2_Click;
            // 
            // ShowPrice
            // 
            ShowPrice.BackColor = Color.RoyalBlue;
            ShowPrice.Dock = DockStyle.Top;
            ShowPrice.FlatStyle = FlatStyle.Flat;
            ShowPrice.ForeColor = Color.White;
            ShowPrice.Location = new Point(0, 0);
            ShowPrice.Margin = new Padding(5);
            ShowPrice.Name = "ShowPrice";
            ShowPrice.Padding = new Padding(2);
            ShowPrice.Size = new Size(107, 40);
            ShowPrice.TabIndex = 0;
            ShowPrice.Text = "Прайс";
            ShowPrice.TextAlign = ContentAlignment.MiddleLeft;
            ShowPrice.UseVisualStyleBackColor = false;
            ShowPrice.Click += ShowPrice_Click;
            // 
            // Main_Split_Conatainer
            // 
            Main_Split_Conatainer.BorderStyle = BorderStyle.FixedSingle;
            Main_Split_Conatainer.Dock = DockStyle.Fill;
            Main_Split_Conatainer.Location = new Point(0, 0);
            Main_Split_Conatainer.Margin = new Padding(4);
            Main_Split_Conatainer.Name = "Main_Split_Conatainer";
            Main_Split_Conatainer.Orientation = Orientation.Horizontal;
            // 
            // Main_Split_Conatainer.Panel1
            // 
            Main_Split_Conatainer.Panel1.BackColor = Color.LightSteelBlue;
            Main_Split_Conatainer.Panel1.Controls.Add(menuStrip1);
            // 
            // Main_Split_Conatainer.Panel2
            // 
            Main_Split_Conatainer.Panel2.BackColor = Color.LightCoral;
            Main_Split_Conatainer.Size = new Size(909, 514);
            Main_Split_Conatainer.SplitterDistance = 93;
            Main_Split_Conatainer.SplitterWidth = 5;
            Main_Split_Conatainer.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { подключениеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(907, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // подключениеToolStripMenuItem
            // 
            подключениеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { настрйокиToolStripMenuItem, toolStripMenuItem1, выходToolStripMenuItem });
            подключениеToolStripMenuItem.Name = "подключениеToolStripMenuItem";
            подключениеToolStripMenuItem.Size = new Size(97, 20);
            подключениеToolStripMenuItem.Text = "Подключение";
            // 
            // настрйокиToolStripMenuItem
            // 
            настрйокиToolStripMenuItem.Name = "настрйокиToolStripMenuItem";
            настрйокиToolStripMenuItem.Size = new Size(180, 22);
            настрйокиToolStripMenuItem.Text = "Настрйоки";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(177, 6);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(180, 22);
            выходToolStripMenuItem.Text = "Выход";
            // 
            // MainWindoiw
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaShell;
            ClientSize = new Size(1029, 540);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            DoubleBuffered = true;
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "MainWindoiw";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            Main_Split_Conatainer.Panel1.ResumeLayout(false);
            Main_Split_Conatainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Main_Split_Conatainer).EndInit();
            Main_Split_Conatainer.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private SplitContainer splitContainer1;
        private SplitContainer Main_Split_Conatainer;
        private Button button3;
        private Button ShowGenerator;
        private Button ShowPrice;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem подключениеToolStripMenuItem;
        private ToolStripMenuItem настрйокиToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem выходToolStripMenuItem;
    }
}
