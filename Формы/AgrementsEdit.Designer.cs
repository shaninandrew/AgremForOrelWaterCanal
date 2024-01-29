namespace Doc4Lab
{
    partial class AgreementEditorWindow
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            splitter1 = new Splitter();
            Split_Agrems = new SplitContainer();
            SplitterDocs = new SplitContainer();
            listView_Clients = new ListView();
            listView_agreemtns = new ListView();
            Agr_control = new Panel();
            CreateNewAgrForThisCleint = new Button();
            label3 = new Label();
            New_Client_Date = new MaskedTextBox();
            New_CLient_Number = new TextBox();
            label2 = new Label();
            label1 = new Label();
            New_Client_Type = new ComboBox();
            CreateNewClient = new Button();
            TabControlFull = new TabControl();
            tabeditor_Client = new TabPage();
            tabeditor_Agreement = new TabPage();
            tabEditor_Servce = new TabPage();
            ((System.ComponentModel.ISupportInitialize)Split_Agrems).BeginInit();
            Split_Agrems.Panel1.SuspendLayout();
            Split_Agrems.Panel2.SuspendLayout();
            Split_Agrems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplitterDocs).BeginInit();
            SplitterDocs.Panel1.SuspendLayout();
            SplitterDocs.Panel2.SuspendLayout();
            SplitterDocs.SuspendLayout();
            Agr_control.SuspendLayout();
            TabControlFull.SuspendLayout();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Margin = new Padding(3, 4, 3, 4);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 975);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
            // 
            // Split_Agrems
            // 
            Split_Agrems.BackColor = Color.DeepSkyBlue;
            Split_Agrems.Dock = DockStyle.Fill;
            Split_Agrems.FixedPanel = FixedPanel.Panel1;
            Split_Agrems.Location = new Point(3, 0);
            Split_Agrems.Margin = new Padding(3, 4, 3, 4);
            Split_Agrems.MinimumSize = new Size(600, 600);
            Split_Agrems.Name = "Split_Agrems";
            Split_Agrems.Orientation = Orientation.Horizontal;
            // 
            // Split_Agrems.Panel1
            // 
            Split_Agrems.Panel1.AutoScroll = true;
            Split_Agrems.Panel1.BackColor = Color.LightSkyBlue;
            Split_Agrems.Panel1.Controls.Add(SplitterDocs);
            Split_Agrems.Panel1.Controls.Add(Agr_control);
            Split_Agrems.Panel1.ForeColor = Color.Black;
            Split_Agrems.Panel1MinSize = 620;
            // 
            // Split_Agrems.Panel2
            // 
            Split_Agrems.Panel2.Controls.Add(TabControlFull);
            Split_Agrems.Panel2.Paint += Split_Agrems_Panel2_Paint;
            Split_Agrems.Size = new Size(1759, 975);
            Split_Agrems.SplitterDistance = 620;
            Split_Agrems.TabIndex = 3;
            // 
            // SplitterDocs
            // 
            SplitterDocs.BackColor = Color.DeepSkyBlue;
            SplitterDocs.Dock = DockStyle.Fill;
            SplitterDocs.Location = new Point(287, 0);
            SplitterDocs.Name = "SplitterDocs";
            SplitterDocs.Orientation = Orientation.Horizontal;
            // 
            // SplitterDocs.Panel1
            // 
            SplitterDocs.Panel1.Controls.Add(listView_Clients);
            // 
            // SplitterDocs.Panel2
            // 
            SplitterDocs.Panel2.Controls.Add(listView_agreemtns);
            SplitterDocs.Size = new Size(1472, 620);
            SplitterDocs.SplitterDistance = 132;
            SplitterDocs.SplitterWidth = 10;
            SplitterDocs.TabIndex = 2;
            // 
            // listView_Clients
            // 
            listView_Clients.BackColor = Color.LightBlue;
            listView_Clients.Dock = DockStyle.Fill;
            listView_Clients.FullRowSelect = true;
            listView_Clients.Location = new Point(0, 0);
            listView_Clients.Name = "listView_Clients";
            listView_Clients.Size = new Size(1472, 132);
            listView_Clients.TabIndex = 4;
            listView_Clients.UseCompatibleStateImageBehavior = false;
            listView_Clients.View = View.Details;
            listView_Clients.ItemSelectionChanged += listView_Clients_ItemSelectionChanged;
            // 
            // listView_agreemtns
            // 
            listView_agreemtns.BackColor = Color.LightBlue;
            listView_agreemtns.Dock = DockStyle.Fill;
            listView_agreemtns.FullRowSelect = true;
            listView_agreemtns.Location = new Point(0, 0);
            listView_agreemtns.Margin = new Padding(3, 4, 3, 4);
            listView_agreemtns.Name = "listView_agreemtns";
            listView_agreemtns.ShowItemToolTips = true;
            listView_agreemtns.Size = new Size(1472, 478);
            listView_agreemtns.TabIndex = 4;
            listView_agreemtns.UseCompatibleStateImageBehavior = false;
            listView_agreemtns.View = View.Details;
            listView_agreemtns.SelectedIndexChanged += listView_agreemtns_SelectedIndexChanged_1;
            listView_agreemtns.Click += listView_agreemtns_Click;
            // 
            // Agr_control
            // 
            Agr_control.BackColor = Color.DeepSkyBlue;
            Agr_control.BorderStyle = BorderStyle.FixedSingle;
            Agr_control.Controls.Add(CreateNewAgrForThisCleint);
            Agr_control.Controls.Add(label3);
            Agr_control.Controls.Add(New_Client_Date);
            Agr_control.Controls.Add(New_CLient_Number);
            Agr_control.Controls.Add(label2);
            Agr_control.Controls.Add(label1);
            Agr_control.Controls.Add(New_Client_Type);
            Agr_control.Controls.Add(CreateNewClient);
            Agr_control.Dock = DockStyle.Left;
            Agr_control.Location = new Point(0, 0);
            Agr_control.Margin = new Padding(3, 4, 3, 4);
            Agr_control.Name = "Agr_control";
            Agr_control.Size = new Size(287, 620);
            Agr_control.TabIndex = 1;
            // 
            // CreateNewAgrForThisCleint
            // 
            CreateNewAgrForThisCleint.Enabled = false;
            CreateNewAgrForThisCleint.FlatAppearance.BorderColor = Color.RosyBrown;
            CreateNewAgrForThisCleint.Location = new Point(9, 191);
            CreateNewAgrForThisCleint.Margin = new Padding(3, 4, 3, 4);
            CreateNewAgrForThisCleint.MaximumSize = new Size(120, 75);
            CreateNewAgrForThisCleint.Name = "CreateNewAgrForThisCleint";
            CreateNewAgrForThisCleint.Size = new Size(120, 55);
            CreateNewAgrForThisCleint.TabIndex = 8;
            CreateNewAgrForThisCleint.Text = "Новый договор к этому клиенту";
            CreateNewAgrForThisCleint.UseVisualStyleBackColor = true;
            CreateNewAgrForThisCleint.Click += CreateNewAgrForThisCleint_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 125);
            label3.Name = "label3";
            label3.Size = new Size(124, 23);
            label3.TabIndex = 7;
            label3.Text = "Дата договора";
            // 
            // New_Client_Date
            // 
            New_Client_Date.InsertKeyMode = InsertKeyMode.Overwrite;
            New_Client_Date.Location = new Point(11, 151);
            New_Client_Date.Mask = "00/00/0000";
            New_Client_Date.Name = "New_Client_Date";
            New_Client_Date.Size = new Size(254, 30);
            New_Client_Date.TabIndex = 6;
            New_Client_Date.ValidatingType = typeof(DateTime);
            // 
            // New_CLient_Number
            // 
            New_CLient_Number.Location = new Point(9, 92);
            New_CLient_Number.Name = "New_CLient_Number";
            New_CLient_Number.Size = new Size(256, 30);
            New_CLient_Number.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 66);
            label2.Name = "label2";
            label2.Size = new Size(137, 23);
            label2.TabIndex = 3;
            label2.Text = "Номер договора";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(106, 23);
            label1.TabIndex = 2;
            label1.Text = "Тип клиента";
            // 
            // New_Client_Type
            // 
            New_Client_Type.DropDownStyle = ComboBoxStyle.DropDownList;
            New_Client_Type.FlatStyle = FlatStyle.Flat;
            New_Client_Type.FormattingEnabled = true;
            New_Client_Type.Items.AddRange(new object[] { "Физическое лицо", "Юридическое лицо" });
            New_Client_Type.Location = new Point(11, 32);
            New_Client_Type.Name = "New_Client_Type";
            New_Client_Type.Size = new Size(254, 31);
            New_Client_Type.TabIndex = 1;
            // 
            // CreateNewClient
            // 
            CreateNewClient.FlatAppearance.BorderColor = Color.RosyBrown;
            CreateNewClient.Location = new Point(145, 191);
            CreateNewClient.Margin = new Padding(3, 4, 3, 4);
            CreateNewClient.MaximumSize = new Size(120, 75);
            CreateNewClient.Name = "CreateNewClient";
            CreateNewClient.Size = new Size(120, 57);
            CreateNewClient.TabIndex = 0;
            CreateNewClient.Text = "Новый договор +новый клиент";
            CreateNewClient.UseVisualStyleBackColor = true;
            CreateNewClient.Click += Create_New_ClientNAgreement;
            // 
            // TabControlFull
            // 
            TabControlFull.Controls.Add(tabeditor_Client);
            TabControlFull.Controls.Add(tabeditor_Agreement);
            TabControlFull.Controls.Add(tabEditor_Servce);
            TabControlFull.Dock = DockStyle.Fill;
            TabControlFull.Location = new Point(0, 0);
            TabControlFull.Name = "TabControlFull";
            TabControlFull.SelectedIndex = 0;
            TabControlFull.Size = new Size(1759, 351);
            TabControlFull.TabIndex = 0;
            // 
            // tabeditor_Client
            // 
            tabeditor_Client.Location = new Point(4, 32);
            tabeditor_Client.Name = "tabeditor_Client";
            tabeditor_Client.Padding = new Padding(3);
            tabeditor_Client.Size = new Size(1751, 315);
            tabeditor_Client.TabIndex = 0;
            tabeditor_Client.Text = "Клиенты";
            tabeditor_Client.UseVisualStyleBackColor = true;
            // 
            // tabeditor_Agreement
            // 
            tabeditor_Agreement.Location = new Point(4, 29);
            tabeditor_Agreement.Name = "tabeditor_Agreement";
            tabeditor_Agreement.Padding = new Padding(3);
            tabeditor_Agreement.Size = new Size(1751, 318);
            tabeditor_Agreement.TabIndex = 1;
            tabeditor_Agreement.Text = "Положение договора";
            tabeditor_Agreement.UseVisualStyleBackColor = true;
            // 
            // tabEditor_Servce
            // 
            tabEditor_Servce.Location = new Point(4, 29);
            tabEditor_Servce.Name = "tabEditor_Servce";
            tabEditor_Servce.Padding = new Padding(3);
            tabEditor_Servce.Size = new Size(1751, 318);
            tabEditor_Servce.TabIndex = 2;
            tabEditor_Servce.Text = "Услуги по прайс-листу";
            tabEditor_Servce.UseVisualStyleBackColor = true;
            // 
            // AgreementEditorWindow
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1762, 975);
            Controls.Add(Split_Agrems);
            Controls.Add(splitter1);
            Font = new Font("Arial Unicode MS", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AgreementEditorWindow";
            Text = "Документы анализа качества воды";
            Load += MainForm_Load;
            Split_Agrems.Panel1.ResumeLayout(false);
            Split_Agrems.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Split_Agrems).EndInit();
            Split_Agrems.ResumeLayout(false);
            SplitterDocs.Panel1.ResumeLayout(false);
            SplitterDocs.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitterDocs).EndInit();
            SplitterDocs.ResumeLayout(false);
            Agr_control.ResumeLayout(false);
            Agr_control.PerformLayout();
            TabControlFull.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem подключениеToolStripMenuItem;
        private ToolStripMenuItem подключитьсяКБазеДанныхToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ToolStripMenuItem обновитьДанныеToolStripMenuItem;
        private ToolStripMenuItem шаблоныToolStripMenuItem;
        private ToolStripMenuItem открытьПапкуСШаблонамиToolStripMenuItem;
        private ToolStripMenuItem файлыToolStripMenuItem;
        private ToolStripMenuItem открытьХранилищеФайToolStripMenuItem;
        private Splitter splitter1;
        private ToolStripMenuItem отобразитьДоговораToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem выпуститьБумажныйВариантДоговораToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem новыйДоговорToolStripMenuItem;
        private SplitContainer Split_Agrems;
        private Panel Agr_control;
        private Button CreateNewClient;
        private Label label1;
        private ComboBox New_Client_Type;
        private TextBox New_CLient_Number;
        private Label label2;
        private Label label3;
        private MaskedTextBox New_Client_Date;
        private Button CreateNewAgrForThisCleint;
        private TabControl TabControlFull;
        private TabPage tabeditor_Client;
        private TabPage tabeditor_Agreement;
        private SplitContainer SplitterDocs;
        public ListView listView_agreemtns;
        public ListView listView_Clients;
        private TabPage tabEditor_Servce;
    }
}

