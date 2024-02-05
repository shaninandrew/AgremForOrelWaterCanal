﻿namespace wfa_symple
{
    partial class MainWindow
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
            MSG_Status = new ToolStripStatusLabel();
            Progresso = new ToolStripProgressBar();
            splitContainer1 = new SplitContainer();
            ShowAgrs = new Button();
            Show_Settings = new Button();
            ShowGenerator = new Button();
            ShowPrice = new Button();
            Main_Split_Conatainer = new SplitContainer();
            SearchData = new Button();
            label1 = new Label();
            InputFilterText = new TextBox();
            menuStrip1 = new MenuStrip();
            подключениеToolStripMenuItem = new ToolStripMenuItem();
            настрйокиToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            выходToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1.SuspendLayout();
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
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { MSG_Status, Progresso });
            statusStrip1.Location = new Point(0, 516);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 18, 0);
            statusStrip1.Size = new Size(1122, 24);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // MSG_Status
            // 
            MSG_Status.Name = "MSG_Status";
            MSG_Status.Size = new Size(43, 19);
            MSG_Status.Text = "Статус";
            // 
            // Progresso
            // 
            Progresso.Name = "Progresso";
            Progresso.Size = new Size(300, 18);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.BackColor = Color.DeepSkyBlue;
            splitContainer1.Panel1.Controls.Add(ShowAgrs);
            splitContainer1.Panel1.Controls.Add(Show_Settings);
            splitContainer1.Panel1.Controls.Add(ShowGenerator);
            splitContainer1.Panel1.Controls.Add(ShowPrice);
            splitContainer1.Panel1.Cursor = Cursors.Hand;
            splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(Main_Split_Conatainer);
            splitContainer1.Size = new Size(1122, 516);
            splitContainer1.SplitterDistance = 157;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 1;
            // 
            // ShowAgrs
            // 
            ShowAgrs.BackColor = Color.Navy;
            ShowAgrs.Dock = DockStyle.Top;
            ShowAgrs.FlatStyle = FlatStyle.Flat;
            ShowAgrs.ForeColor = Color.Azure;
            ShowAgrs.ImageAlign = ContentAlignment.MiddleLeft;
            ShowAgrs.Location = new Point(0, 0);
            ShowAgrs.MaximumSize = new Size(0, 50);
            ShowAgrs.Name = "ShowAgrs";
            ShowAgrs.Padding = new Padding(2);
            ShowAgrs.Size = new Size(157, 50);
            ShowAgrs.TabIndex = 3;
            ShowAgrs.Text = "Договора";
            ShowAgrs.TextAlign = ContentAlignment.MiddleLeft;
            ShowAgrs.UseVisualStyleBackColor = false;
            ShowAgrs.Click += ShowAgreements_Click;
            // 
            // Show_Settings
            // 
            Show_Settings.BackColor = Color.DodgerBlue;
            Show_Settings.Dock = DockStyle.Bottom;
            Show_Settings.FlatStyle = FlatStyle.Flat;
            Show_Settings.ForeColor = Color.Navy;
            Show_Settings.Location = new Point(0, 366);
            Show_Settings.MaximumSize = new Size(0, 50);
            Show_Settings.Name = "Show_Settings";
            Show_Settings.Padding = new Padding(2);
            Show_Settings.Size = new Size(157, 50);
            Show_Settings.TabIndex = 2;
            Show_Settings.Text = "Настройки";
            Show_Settings.TextAlign = ContentAlignment.MiddleLeft;
            Show_Settings.UseVisualStyleBackColor = false;
            Show_Settings.Click += button3_Click;
            // 
            // ShowGenerator
            // 
            ShowGenerator.BackColor = Color.DodgerBlue;
            ShowGenerator.BackgroundImageLayout = ImageLayout.None;
            ShowGenerator.Dock = DockStyle.Bottom;
            ShowGenerator.FlatStyle = FlatStyle.Flat;
            ShowGenerator.ForeColor = Color.Navy;
            ShowGenerator.Location = new Point(0, 416);
            ShowGenerator.MaximumSize = new Size(0, 50);
            ShowGenerator.Name = "ShowGenerator";
            ShowGenerator.Padding = new Padding(2);
            ShowGenerator.Size = new Size(157, 50);
            ShowGenerator.TabIndex = 1;
            ShowGenerator.Text = "Печать";
            ShowGenerator.TextAlign = ContentAlignment.MiddleLeft;
            ShowGenerator.UseVisualStyleBackColor = false;
            ShowGenerator.Click += button2_Click;
            // 
            // ShowPrice
            // 
            ShowPrice.BackColor = Color.DodgerBlue;
            ShowPrice.Dock = DockStyle.Bottom;
            ShowPrice.FlatStyle = FlatStyle.Flat;
            ShowPrice.ForeColor = Color.Navy;
            ShowPrice.Location = new Point(0, 466);
            ShowPrice.Margin = new Padding(5);
            ShowPrice.MaximumSize = new Size(0, 50);
            ShowPrice.Name = "ShowPrice";
            ShowPrice.Padding = new Padding(2);
            ShowPrice.Size = new Size(157, 50);
            ShowPrice.TabIndex = 0;
            ShowPrice.Text = "Прайс";
            ShowPrice.TextAlign = ContentAlignment.MiddleLeft;
            ShowPrice.UseVisualStyleBackColor = false;
            ShowPrice.Click += ShowPrice_Click;
            // 
            // Main_Split_Conatainer
            // 
            Main_Split_Conatainer.Dock = DockStyle.Fill;
            Main_Split_Conatainer.FixedPanel = FixedPanel.Panel1;
            Main_Split_Conatainer.IsSplitterFixed = true;
            Main_Split_Conatainer.Location = new Point(0, 0);
            Main_Split_Conatainer.Margin = new Padding(4);
            Main_Split_Conatainer.Name = "Main_Split_Conatainer";
            Main_Split_Conatainer.Orientation = Orientation.Horizontal;
            // 
            // Main_Split_Conatainer.Panel1
            // 
            Main_Split_Conatainer.Panel1.AutoScroll = true;
            Main_Split_Conatainer.Panel1.BackColor = Color.LightSteelBlue;
            Main_Split_Conatainer.Panel1.Controls.Add(SearchData);
            Main_Split_Conatainer.Panel1.Controls.Add(label1);
            Main_Split_Conatainer.Panel1.Controls.Add(InputFilterText);
            Main_Split_Conatainer.Panel1.Controls.Add(menuStrip1);
            Main_Split_Conatainer.Panel1MinSize = 120;
            // 
            // Main_Split_Conatainer.Panel2
            // 
            Main_Split_Conatainer.Panel2.AutoScroll = true;
            Main_Split_Conatainer.Panel2.BackColor = Color.LightSkyBlue;
            Main_Split_Conatainer.Panel2.Paint += Main_Split_Conatainer_Panel2_Paint;
            Main_Split_Conatainer.Size = new Size(960, 516);
            Main_Split_Conatainer.SplitterDistance = 120;
            Main_Split_Conatainer.SplitterWidth = 5;
            Main_Split_Conatainer.TabIndex = 0;
            // 
            // SearchData
            // 
            SearchData.Location = new Point(760, 51);
            SearchData.Name = "SearchData";
            SearchData.Size = new Size(158, 33);
            SearchData.TabIndex = 3;
            SearchData.Text = "Поиск";
            SearchData.UseVisualStyleBackColor = true;
            SearchData.Click += SearchData_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 55);
            label1.Name = "label1";
            label1.Size = new Size(209, 20);
            label1.TabIndex = 2;
            label1.Text = "Поиск договоров  и клиентов";
            // 
            // InputFilterText
            // 
            InputFilterText.Location = new Point(288, 53);
            InputFilterText.Name = "InputFilterText";
            InputFilterText.Size = new Size(453, 27);
            InputFilterText.TabIndex = 1;
            InputFilterText.PreviewKeyDown += InputFilterText_PreviewKeyDown;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Arial Unicode MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { подключениеToolStripMenuItem });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.Table;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Margin = new Padding(2);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.ShowItemToolTips = true;
            menuStrip1.Size = new Size(960, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "MainMenu";
            // 
            // подключениеToolStripMenuItem
            // 
            подключениеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { настрйокиToolStripMenuItem, toolStripMenuItem1, выходToolStripMenuItem });
            подключениеToolStripMenuItem.Name = "подключениеToolStripMenuItem";
            подключениеToolStripMenuItem.Size = new Size(125, 25);
            подключениеToolStripMenuItem.Text = "Подключение";
            // 
            // настрйокиToolStripMenuItem
            // 
            настрйокиToolStripMenuItem.Name = "настрйокиToolStripMenuItem";
            настрйокиToolStripMenuItem.Size = new Size(193, 26);
            настрйокиToolStripMenuItem.Text = "Настройки";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(190, 6);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F10;
            выходToolStripMenuItem.Size = new Size(193, 26);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.SeaShell;
            ClientSize = new Size(1122, 540);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            DoubleBuffered = true;
            Font = new Font("Arial Unicode MS", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "MainWindow";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
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
        private Button Show_Settings;
        private Button ShowGenerator;
        private Button ShowPrice;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem подключениеToolStripMenuItem;
        private ToolStripMenuItem настрйокиToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private Label label1;
        private TextBox InputFilterText;
        private Button ShowAgrs;
        public Button SearchData;
        public ToolStripProgressBar Progresso;
        public ToolStripStatusLabel MSG_Status;
    }
}
