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
            TabMenu_Control = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Main_Split_Conatainer).BeginInit();
            Main_Split_Conatainer.Panel1.SuspendLayout();
            Main_Split_Conatainer.SuspendLayout();
            TabMenu_Control.SuspendLayout();
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
            button3.Location = new Point(0, 86);
            button3.Name = "button3";
            button3.Size = new Size(107, 48);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // ShowGenerator
            // 
            ShowGenerator.BackColor = Color.RoyalBlue;
            ShowGenerator.BackgroundImageLayout = ImageLayout.None;
            ShowGenerator.Dock = DockStyle.Top;
            ShowGenerator.FlatStyle = FlatStyle.Popup;
            ShowGenerator.ForeColor = Color.White;
            ShowGenerator.Location = new Point(0, 40);
            ShowGenerator.Name = "ShowGenerator";
            ShowGenerator.Size = new Size(107, 46);
            ShowGenerator.TabIndex = 1;
            ShowGenerator.Text = "Документ";
            ShowGenerator.UseVisualStyleBackColor = false;
            ShowGenerator.Click += button2_Click;
            // 
            // ShowPrice
            // 
            ShowPrice.BackColor = Color.RoyalBlue;
            ShowPrice.Dock = DockStyle.Top;
            ShowPrice.FlatStyle = FlatStyle.Popup;
            ShowPrice.ForeColor = Color.White;
            ShowPrice.Location = new Point(0, 0);
            ShowPrice.Name = "ShowPrice";
            ShowPrice.Size = new Size(107, 40);
            ShowPrice.TabIndex = 0;
            ShowPrice.Text = "Прайс";
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
            Main_Split_Conatainer.Panel1.Controls.Add(TabMenu_Control);
            // 
            // Main_Split_Conatainer.Panel2
            // 
            Main_Split_Conatainer.Panel2.BackColor = Color.LightCoral;
            Main_Split_Conatainer.Size = new Size(909, 514);
            Main_Split_Conatainer.SplitterDistance = 93;
            Main_Split_Conatainer.SplitterWidth = 5;
            Main_Split_Conatainer.TabIndex = 0;
            // 
            // TabMenu_Control
            // 
            TabMenu_Control.Controls.Add(tabPage1);
            TabMenu_Control.Controls.Add(tabPage2);
            TabMenu_Control.Cursor = Cursors.Hand;
            TabMenu_Control.Dock = DockStyle.Fill;
            TabMenu_Control.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TabMenu_Control.HotTrack = true;
            TabMenu_Control.Location = new Point(0, 0);
            TabMenu_Control.Margin = new Padding(0);
            TabMenu_Control.Name = "TabMenu_Control";
            TabMenu_Control.SelectedIndex = 0;
            TabMenu_Control.ShowToolTips = true;
            TabMenu_Control.Size = new Size(907, 91);
            TabMenu_Control.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.AutoScroll = true;
            tabPage1.BackColor = Color.LightSteelBlue;
            tabPage1.Location = new Point(4, 28);
            tabPage1.Margin = new Padding(0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(899, 59);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Главное";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.LightSteelBlue;
            tabPage2.Location = new Point(4, 28);
            tabPage2.Margin = new Padding(0);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(899, 59);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Вспомогательное";
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
            ((System.ComponentModel.ISupportInitialize)Main_Split_Conatainer).EndInit();
            Main_Split_Conatainer.ResumeLayout(false);
            TabMenu_Control.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private SplitContainer splitContainer1;
        private SplitContainer Main_Split_Conatainer;
        private TabControl TabMenu_Control;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button3;
        private Button ShowGenerator;
        private Button ShowPrice;
    }
}
