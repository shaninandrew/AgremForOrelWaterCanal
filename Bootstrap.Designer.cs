namespace OWC_Aggreems
{
    partial class Bootstrap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bootstrap));
            MainSplit = new SplitContainer();
            btn_CallAgreements = new Button();
            Header = new Panel();
            btn_Quit = new Button();
            SearchText = new ComboBox();
            label1 = new Label();
            MainMenu = new MenuStrip();
            подключениеToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            выходToolStripMenuItem = new ToolStripMenuItem();
            данныеToolStripMenuItem = new ToolStripMenuItem();
            обновитьToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)MainSplit).BeginInit();
            MainSplit.Panel1.SuspendLayout();
            MainSplit.SuspendLayout();
            Header.SuspendLayout();
            MainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // MainSplit
            // 
            MainSplit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainSplit.Location = new Point(0, 48);
            MainSplit.Margin = new Padding(3, 2, 3, 2);
            MainSplit.Name = "MainSplit";
            // 
            // MainSplit.Panel1
            // 
            MainSplit.Panel1.BackColor = Color.LightSkyBlue;
            MainSplit.Panel1.Controls.Add(btn_CallAgreements);
            MainSplit.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // MainSplit.Panel2
            // 
            MainSplit.Panel2.BackColor = Color.AliceBlue;
            MainSplit.Panel2.Paint += MainSplit_Panel2_Paint;
            MainSplit.Size = new Size(862, 336);
            MainSplit.SplitterDistance = 110;
            MainSplit.TabIndex = 0;
            // 
            // btn_CallAgreements
            // 
            btn_CallAgreements.Cursor = Cursors.Hand;
            btn_CallAgreements.Dock = DockStyle.Top;
            btn_CallAgreements.Location = new Point(0, 0);
            btn_CallAgreements.Margin = new Padding(3, 2, 3, 2);
            btn_CallAgreements.Name = "btn_CallAgreements";
            btn_CallAgreements.Size = new Size(110, 50);
            btn_CallAgreements.TabIndex = 0;
            btn_CallAgreements.Text = "Договора";
            btn_CallAgreements.UseVisualStyleBackColor = true;
            btn_CallAgreements.Click += btn_CallAgreements_Click;
            // 
            // Header
            // 
            Header.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Header.BackColor = Color.CornflowerBlue;
            Header.BorderStyle = BorderStyle.Fixed3D;
            Header.Controls.Add(btn_Quit);
            Header.Controls.Add(SearchText);
            Header.Controls.Add(label1);
            Header.Controls.Add(MainMenu);
            Header.Location = new Point(0, 0);
            Header.Margin = new Padding(3, 2, 3, 2);
            Header.Name = "Header";
            Header.Size = new Size(862, 46);
            Header.TabIndex = 1;
            // 
            // btn_Quit
            // 
            btn_Quit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Quit.BackColor = Color.Salmon;
            btn_Quit.FlatStyle = FlatStyle.Flat;
            btn_Quit.ForeColor = Color.Black;
            btn_Quit.Location = new Point(825, 9);
            btn_Quit.Name = "btn_Quit";
            btn_Quit.Size = new Size(30, 25);
            btn_Quit.TabIndex = 2;
            btn_Quit.Text = "X";
            btn_Quit.UseVisualStyleBackColor = false;
            btn_Quit.Click += btn_Quit_Click;
            // 
            // SearchText
            // 
            SearchText.ForeColor = Color.Black;
            SearchText.FormattingEnabled = true;
            SearchText.Location = new Point(286, 11);
            SearchText.Margin = new Padding(3, 2, 3, 2);
            SearchText.Name = "SearchText";
            SearchText.Size = new Size(482, 23);
            SearchText.TabIndex = 1;
            SearchText.KeyDown += SearchText_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(236, 14);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "Поиск";
            // 
            // MainMenu
            // 
            MainMenu.AllowMerge = false;
            MainMenu.BackColor = Color.CornflowerBlue;
            MainMenu.Dock = DockStyle.Left;
            MainMenu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            MainMenu.GripStyle = ToolStripGripStyle.Visible;
            MainMenu.Items.AddRange(new ToolStripItem[] { подключениеToolStripMenuItem, данныеToolStripMenuItem });
            MainMenu.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.RenderMode = ToolStripRenderMode.Professional;
            MainMenu.ShowItemToolTips = true;
            MainMenu.Size = new Size(180, 42);
            MainMenu.Stretch = false;
            MainMenu.TabIndex = 3;
            MainMenu.Text = "menuStrip1";
            // 
            // подключениеToolStripMenuItem
            // 
            подключениеToolStripMenuItem.AutoToolTip = true;
            подключениеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { настройкиToolStripMenuItem, toolStripMenuItem1, выходToolStripMenuItem });
            подключениеToolStripMenuItem.Name = "подключениеToolStripMenuItem";
            подключениеToolStripMenuItem.Size = new Size(103, 38);
            подключениеToolStripMenuItem.Text = "Подключение";
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(137, 22);
            настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(134, 6);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(137, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // данныеToolStripMenuItem
            // 
            данныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { обновитьToolStripMenuItem });
            данныеToolStripMenuItem.Name = "данныеToolStripMenuItem";
            данныеToolStripMenuItem.Size = new Size(65, 38);
            данныеToolStripMenuItem.Text = "Данные";
            // 
            // обновитьToolStripMenuItem
            // 
            обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            обновитьToolStripMenuItem.Size = new Size(131, 22);
            обновитьToolStripMenuItem.Text = "Обновить";
            // 
            // Bootstrap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 384);
            Controls.Add(Header);
            Controls.Add(MainSplit);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MainMenu;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Bootstrap";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Информационное ядро";
            WindowState = FormWindowState.Maximized;
            FormClosed += Bootstrap_FormClosed;
            Shown += Bootstrap_Shown;
            MainSplit.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainSplit).EndInit();
            MainSplit.ResumeLayout(false);
            Header.ResumeLayout(false);
            Header.PerformLayout();
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer MainSplit;
        private Button btn_CallAgreements;
        private Panel Header;
        private ComboBox SearchText;
        private Label label1;
        private Button btn_Quit;
        private MenuStrip MainMenu;
        private ToolStripMenuItem подключениеToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem данныеToolStripMenuItem;
        private ToolStripMenuItem обновитьToolStripMenuItem;
    }
}
