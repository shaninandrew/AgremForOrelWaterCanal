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
            dgv_Clients = new DataGridView();
            dgv_Agreements = new DataGridView();
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
            tabEditor_Service = new TabPage();
            dgv_Service = new DataGridView();
            panel1 = new Panel();
            AddService = new Button();
            btn_RefreshService = new Button();
            btn_DeleteService = new Button();
            AddNewService = new Button();
            DefaultServices = new Button();
            ((System.ComponentModel.ISupportInitialize)Split_Agrems).BeginInit();
            Split_Agrems.Panel1.SuspendLayout();
            Split_Agrems.Panel2.SuspendLayout();
            Split_Agrems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplitterDocs).BeginInit();
            SplitterDocs.Panel1.SuspendLayout();
            SplitterDocs.Panel2.SuspendLayout();
            SplitterDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Clients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Agreements).BeginInit();
            Agr_control.SuspendLayout();
            TabControlFull.SuspendLayout();
            tabEditor_Service.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Service).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Margin = new Padding(3, 4, 3, 4);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 845);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
            // 
            // Split_Agrems
            // 
            Split_Agrems.BackColor = Color.DeepSkyBlue;
            Split_Agrems.Dock = DockStyle.Fill;
            Split_Agrems.Location = new Point(3, 0);
            Split_Agrems.Margin = new Padding(3, 4, 3, 4);
            Split_Agrems.MinimumSize = new Size(600, 500);
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
            Split_Agrems.Panel1MinSize = 500;
            // 
            // Split_Agrems.Panel2
            // 
            Split_Agrems.Panel2.Controls.Add(TabControlFull);
            Split_Agrems.Panel2.Font = new Font("Arial Unicode MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Split_Agrems.Size = new Size(1759, 845);
            Split_Agrems.SplitterDistance = 500;
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
            SplitterDocs.Panel1.Controls.Add(dgv_Clients);
            // 
            // SplitterDocs.Panel2
            // 
            SplitterDocs.Panel2.Controls.Add(dgv_Agreements);
            SplitterDocs.Size = new Size(1472, 500);
            SplitterDocs.SplitterDistance = 106;
            SplitterDocs.SplitterWidth = 10;
            SplitterDocs.TabIndex = 2;
            // 
            // dgv_Clients
            // 
            dgv_Clients.AllowUserToAddRows = false;
            dgv_Clients.AllowUserToDeleteRows = false;
            dgv_Clients.AllowUserToOrderColumns = true;
            dgv_Clients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Clients.BackgroundColor = Color.LightSkyBlue;
            dgv_Clients.BorderStyle = BorderStyle.None;
            dgv_Clients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Clients.Dock = DockStyle.Fill;
            dgv_Clients.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgv_Clients.EnableHeadersVisualStyles = false;
            dgv_Clients.GridColor = Color.MidnightBlue;
            dgv_Clients.Location = new Point(0, 0);
            dgv_Clients.Name = "dgv_Clients";
            dgv_Clients.RowHeadersWidth = 51;
            dgv_Clients.Size = new Size(1472, 106);
            dgv_Clients.TabIndex = 0;
            dgv_Clients.Click += dgv_Clients_Click;
            // 
            // dgv_Agreements
            // 
            dgv_Agreements.AllowUserToAddRows = false;
            dgv_Agreements.AllowUserToDeleteRows = false;
            dgv_Agreements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Agreements.BackgroundColor = Color.LightSkyBlue;
            dgv_Agreements.BorderStyle = BorderStyle.None;
            dgv_Agreements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Agreements.Dock = DockStyle.Fill;
            dgv_Agreements.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgv_Agreements.EnableHeadersVisualStyles = false;
            dgv_Agreements.GridColor = Color.MidnightBlue;
            dgv_Agreements.Location = new Point(0, 0);
            dgv_Agreements.Name = "dgv_Agreements";
            dgv_Agreements.RowHeadersWidth = 51;
            dgv_Agreements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Agreements.Size = new Size(1472, 384);
            dgv_Agreements.TabIndex = 0;
            dgv_Agreements.SelectionChanged += dgv_Agreements_SelectionChanged;
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
            Agr_control.Size = new Size(287, 500);
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
            label3.Size = new Size(91, 16);
            label3.TabIndex = 7;
            label3.Text = "Дата договора";
            // 
            // New_Client_Date
            // 
            New_Client_Date.InsertKeyMode = InsertKeyMode.Overwrite;
            New_Client_Date.Location = new Point(11, 151);
            New_Client_Date.Mask = "00/00/0000";
            New_Client_Date.Name = "New_Client_Date";
            New_Client_Date.Size = new Size(254, 24);
            New_Client_Date.TabIndex = 6;
            New_Client_Date.ValidatingType = typeof(DateTime);
            // 
            // New_CLient_Number
            // 
            New_CLient_Number.Location = new Point(9, 92);
            New_CLient_Number.Name = "New_CLient_Number";
            New_CLient_Number.Size = new Size(256, 24);
            New_CLient_Number.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 66);
            label2.Name = "label2";
            label2.Size = new Size(101, 16);
            label2.TabIndex = 3;
            label2.Text = "Номер договора";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(77, 16);
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
            New_Client_Type.Size = new Size(254, 24);
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
            TabControlFull.Controls.Add(tabEditor_Service);
            TabControlFull.Dock = DockStyle.Fill;
            TabControlFull.Font = new Font("Arial Unicode MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TabControlFull.Location = new Point(0, 0);
            TabControlFull.Name = "TabControlFull";
            TabControlFull.SelectedIndex = 0;
            TabControlFull.Size = new Size(1759, 341);
            TabControlFull.TabIndex = 0;
            // 
            // tabeditor_Client
            // 
            tabeditor_Client.AutoScroll = true;
            tabeditor_Client.Location = new Point(4, 25);
            tabeditor_Client.Name = "tabeditor_Client";
            tabeditor_Client.Padding = new Padding(3);
            tabeditor_Client.Size = new Size(1751, 312);
            tabeditor_Client.TabIndex = 0;
            tabeditor_Client.Text = "Клиенты";
            tabeditor_Client.UseVisualStyleBackColor = true;
            // 
            // tabeditor_Agreement
            // 
            tabeditor_Agreement.AutoScroll = true;
            tabeditor_Agreement.Location = new Point(4, 25);
            tabeditor_Agreement.Name = "tabeditor_Agreement";
            tabeditor_Agreement.Padding = new Padding(3);
            tabeditor_Agreement.Size = new Size(1751, 312);
            tabeditor_Agreement.TabIndex = 1;
            tabeditor_Agreement.Text = "Положение договора";
            tabeditor_Agreement.UseVisualStyleBackColor = true;
            // 
            // tabEditor_Service
            // 
            tabEditor_Service.AutoScroll = true;
            tabEditor_Service.Controls.Add(dgv_Service);
            tabEditor_Service.Controls.Add(panel1);
            tabEditor_Service.Location = new Point(4, 25);
            tabEditor_Service.Name = "tabEditor_Service";
            tabEditor_Service.Padding = new Padding(3);
            tabEditor_Service.Size = new Size(1751, 312);
            tabEditor_Service.TabIndex = 2;
            tabEditor_Service.Text = "Услуги по прайс-листу";
            tabEditor_Service.UseVisualStyleBackColor = true;
            // 
            // dgv_Service
            // 
            dgv_Service.AllowUserToAddRows = false;
            dgv_Service.AllowUserToDeleteRows = false;
            dgv_Service.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Service.BackgroundColor = Color.LightSkyBlue;
            dgv_Service.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Service.Dock = DockStyle.Fill;
            dgv_Service.GridColor = Color.WhiteSmoke;
            dgv_Service.Location = new Point(3, 53);
            dgv_Service.Name = "dgv_Service";
            dgv_Service.RowHeadersWidth = 51;
            dgv_Service.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Service.Size = new Size(1745, 256);
            dgv_Service.StandardTab = true;
            dgv_Service.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(DefaultServices);
            panel1.Controls.Add(AddService);
            panel1.Controls.Add(btn_RefreshService);
            panel1.Controls.Add(btn_DeleteService);
            panel1.Controls.Add(AddNewService);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1745, 50);
            panel1.TabIndex = 0;
            // 
            // AddService
            // 
            AddService.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            AddService.FlatStyle = FlatStyle.Popup;
            AddService.Location = new Point(391, 3);
            AddService.Name = "AddService";
            AddService.Size = new Size(113, 41);
            AddService.TabIndex = 3;
            AddService.Text = "+1 к услуге";
            AddService.UseVisualStyleBackColor = true;
            AddService.Click += AddService_Click;
            // 
            // btn_RefreshService
            // 
            btn_RefreshService.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_RefreshService.BackColor = Color.AliceBlue;
            btn_RefreshService.FlatStyle = FlatStyle.Popup;
            btn_RefreshService.Font = new Font("Arial Unicode MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn_RefreshService.Location = new Point(176, 3);
            btn_RefreshService.Name = "btn_RefreshService";
            btn_RefreshService.Size = new Size(161, 41);
            btn_RefreshService.TabIndex = 2;
            btn_RefreshService.Text = "🔄 Обновить";
            btn_RefreshService.UseVisualStyleBackColor = false;
            btn_RefreshService.Click += btn_RefreshService_Click;
            // 
            // btn_DeleteService
            // 
            btn_DeleteService.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_DeleteService.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            btn_DeleteService.FlatStyle = FlatStyle.Popup;
            btn_DeleteService.Location = new Point(1580, 3);
            btn_DeleteService.Name = "btn_DeleteService";
            btn_DeleteService.Size = new Size(160, 41);
            btn_DeleteService.TabIndex = 1;
            btn_DeleteService.Text = "❌ Удалить";
            btn_DeleteService.UseVisualStyleBackColor = true;
            btn_DeleteService.Click += btn_DeleteService_Click;
            // 
            // AddNewService
            // 
            AddNewService.FlatStyle = FlatStyle.Flat;
            AddNewService.Location = new Point(5, 3);
            AddNewService.Name = "AddNewService";
            AddNewService.Size = new Size(165, 41);
            AddNewService.TabIndex = 0;
            AddNewService.Text = "➕Добавить услуги";
            AddNewService.UseVisualStyleBackColor = true;
            AddNewService.Click += button1_Click;
            // 
            // DefaultServices
            // 
            DefaultServices.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            DefaultServices.FlatStyle = FlatStyle.Popup;
            DefaultServices.Location = new Point(510, 3);
            DefaultServices.Name = "DefaultServices";
            DefaultServices.Size = new Size(115, 41);
            DefaultServices.TabIndex = 4;
            DefaultServices.Text = "Обнулить кол-во услуг";
            DefaultServices.UseVisualStyleBackColor = true;
            DefaultServices.Click += button1_Click_1;
            // 
            // AgreementEditorWindow
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1762, 845);
            Controls.Add(Split_Agrems);
            Controls.Add(splitter1);
            Font = new Font("Arial Unicode MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AgreementEditorWindow";
            Text = "Документы анализа качества воды";
            WindowState = FormWindowState.Maximized;
            Split_Agrems.Panel1.ResumeLayout(false);
            Split_Agrems.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Split_Agrems).EndInit();
            Split_Agrems.ResumeLayout(false);
            SplitterDocs.Panel1.ResumeLayout(false);
            SplitterDocs.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitterDocs).EndInit();
            SplitterDocs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Clients).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Agreements).EndInit();
            Agr_control.ResumeLayout(false);
            Agr_control.PerformLayout();
            TabControlFull.ResumeLayout(false);
            tabEditor_Service.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Service).EndInit();
            panel1.ResumeLayout(false);
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
        private TabPage tabEditor_Service;
        private DataGridView dgv_Agreements;
        private DataGridView dgv_Clients;
        private DataGridView dgv_Service;
        private Panel panel1;
        private Button btn_DeleteService;
        private Button AddNewService;
        private Button btn_RefreshService;
        private Button AddService;
        private Button DefaultServices;
    }
}

