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
            MainSplit = new SplitContainer();
            btn_CallAgreements = new Button();
            Header = new Panel();
            label1 = new Label();
            SearchText = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)MainSplit).BeginInit();
            MainSplit.Panel1.SuspendLayout();
            MainSplit.SuspendLayout();
            Header.SuspendLayout();
            SuspendLayout();
            // 
            // MainSplit
            // 
            MainSplit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainSplit.Location = new Point(0, 52);
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
            MainSplit.Size = new Size(889, 460);
            MainSplit.SplitterDistance = 115;
            MainSplit.TabIndex = 0;
            // 
            // btn_CallAgreements
            // 
            btn_CallAgreements.Cursor = Cursors.Hand;
            btn_CallAgreements.Dock = DockStyle.Top;
            btn_CallAgreements.Location = new Point(0, 0);
            btn_CallAgreements.Name = "btn_CallAgreements";
            btn_CallAgreements.Size = new Size(115, 66);
            btn_CallAgreements.TabIndex = 0;
            btn_CallAgreements.Text = "Договора";
            btn_CallAgreements.UseVisualStyleBackColor = true;
            btn_CallAgreements.Click += btn_CallAgreements_Click;
            // 
            // Header
            // 
            Header.Controls.Add(SearchText);
            Header.Controls.Add(label1);
            Header.Dock = DockStyle.Top;
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Size = new Size(889, 46);
            Header.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 0;
            label1.Text = "Поиск";
            // 
            // SearchText
            // 
            SearchText.FlatStyle = FlatStyle.Flat;
            SearchText.FormattingEnabled = true;
            SearchText.Location = new Point(121, 9);
            SearchText.Name = "SearchText";
            SearchText.Size = new Size(756, 28);
            SearchText.TabIndex = 1;
            SearchText.KeyDown += SearchText_KeyDown;
            // 
            // Bootstrap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(889, 512);
            Controls.Add(Header);
            Controls.Add(MainSplit);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Bootstrap";
            ShowInTaskbar = false;
            Text = "Информационное ядро";
            WindowState = FormWindowState.Maximized;
            MainSplit.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainSplit).EndInit();
            MainSplit.ResumeLayout(false);
            Header.ResumeLayout(false);
            Header.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer MainSplit;
        private Button btn_CallAgreements;
        private Panel Header;
        private ComboBox SearchText;
        private Label label1;
    }
}
