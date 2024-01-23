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
            listView_Clients = new ListView();
            Agr_control = new Panel();
            label3 = new Label();
            New_Client_Date = new MaskedTextBox();
            New_CLient_Number = new TextBox();
            label2 = new Label();
            label1 = new Label();
            New_Client_Type = new ComboBox();
            CreateNewClient = new Button();
            listView_agreemtns = new ListView();
            ((System.ComponentModel.ISupportInitialize)Split_Agrems).BeginInit();
            Split_Agrems.Panel1.SuspendLayout();
            Split_Agrems.SuspendLayout();
            Agr_control.SuspendLayout();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Margin = new Padding(3, 4, 3, 4);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 944);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
            // 
            // Split_Agrems
            // 
            Split_Agrems.Dock = DockStyle.Fill;
            Split_Agrems.FixedPanel = FixedPanel.Panel1;
            Split_Agrems.Location = new Point(3, 0);
            Split_Agrems.Margin = new Padding(3, 4, 3, 4);
            Split_Agrems.Name = "Split_Agrems";
            // 
            // Split_Agrems.Panel1
            // 
            Split_Agrems.Panel1.BackColor = Color.LightSalmon;
            Split_Agrems.Panel1.Controls.Add(listView_Clients);
            Split_Agrems.Panel1.Controls.Add(Agr_control);
            Split_Agrems.Panel1.Controls.Add(listView_agreemtns);
            // 
            // Split_Agrems.Panel2
            // 
            Split_Agrems.Panel2.Paint += Split_Agrems_Panel2_Paint;
            Split_Agrems.Size = new Size(1094, 944);
            Split_Agrems.SplitterDistance = 592;
            Split_Agrems.TabIndex = 3;
            // 
            // listView_Clients
            // 
            listView_Clients.Dock = DockStyle.Top;
            listView_Clients.FullRowSelect = true;
            listView_Clients.Location = new Point(0, 122);
            listView_Clients.Name = "listView_Clients";
            listView_Clients.Size = new Size(592, 156);
            listView_Clients.TabIndex = 2;
            listView_Clients.UseCompatibleStateImageBehavior = false;
            listView_Clients.View = View.Details;
            // 
            // Agr_control
            // 
            Agr_control.BackColor = Color.Salmon;
            Agr_control.Controls.Add(label3);
            Agr_control.Controls.Add(New_Client_Date);
            Agr_control.Controls.Add(New_CLient_Number);
            Agr_control.Controls.Add(label2);
            Agr_control.Controls.Add(label1);
            Agr_control.Controls.Add(New_Client_Type);
            Agr_control.Controls.Add(CreateNewClient);
            Agr_control.Dock = DockStyle.Top;
            Agr_control.Location = new Point(0, 0);
            Agr_control.Margin = new Padding(3, 4, 3, 4);
            Agr_control.Name = "Agr_control";
            Agr_control.Size = new Size(592, 122);
            Agr_control.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 90);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 7;
            label3.Text = "Дата договора";
            // 
            // New_Client_Date
            // 
            New_Client_Date.InsertKeyMode = InsertKeyMode.Overwrite;
            New_Client_Date.Location = new Point(170, 87);
            New_Client_Date.Mask = "00/00/0000";
            New_Client_Date.Name = "New_Client_Date";
            New_Client_Date.Size = new Size(132, 27);
            New_Client_Date.TabIndex = 6;
            New_Client_Date.ValidatingType = typeof(DateTime);
            // 
            // New_CLient_Number
            // 
            New_CLient_Number.Location = new Point(170, 48);
            New_CLient_Number.Name = "New_CLient_Number";
            New_CLient_Number.Size = new Size(220, 27);
            New_CLient_Number.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 51);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 3;
            label2.Text = "Номер договора";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 2;
            label1.Text = "Тип клиента";
            // 
            // New_Client_Type
            // 
            New_Client_Type.DropDownStyle = ComboBoxStyle.DropDownList;
            New_Client_Type.FlatStyle = FlatStyle.Flat;
            New_Client_Type.FormattingEnabled = true;
            New_Client_Type.Items.AddRange(new object[] { "Физическое лицо", "Юридическое лицо" });
            New_Client_Type.Location = new Point(170, 9);
            New_Client_Type.Name = "New_Client_Type";
            New_Client_Type.Size = new Size(220, 28);
            New_Client_Type.TabIndex = 1;
            // 
            // CreateNewClient
            // 
            CreateNewClient.Location = new Point(396, 9);
            CreateNewClient.Margin = new Padding(3, 4, 3, 4);
            CreateNewClient.Name = "CreateNewClient";
            CreateNewClient.Size = new Size(193, 106);
            CreateNewClient.TabIndex = 0;
            CreateNewClient.Text = "Новый договор +новый клиент";
            CreateNewClient.UseVisualStyleBackColor = true;
            CreateNewClient.Click += Create_New_ClientNAgreement;
            // 
            // listView_agreemtns
            // 
            listView_agreemtns.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView_agreemtns.FullRowSelect = true;
            listView_agreemtns.Location = new Point(0, 285);
            listView_agreemtns.Margin = new Padding(3, 4, 3, 4);
            listView_agreemtns.Name = "listView_agreemtns";
            listView_agreemtns.Size = new Size(592, 659);
            listView_agreemtns.Sorting = SortOrder.Ascending;
            listView_agreemtns.TabIndex = 0;
            listView_agreemtns.UseCompatibleStateImageBehavior = false;
            listView_agreemtns.View = View.Details;
            // 
            // AgreementEditorWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1097, 944);
            Controls.Add(Split_Agrems);
            Controls.Add(splitter1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AgreementEditorWindow";
            Text = "Документы анализа качества воды";
            Load += MainForm_Load;
            Split_Agrems.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Split_Agrems).EndInit();
            Split_Agrems.ResumeLayout(false);
            Agr_control.ResumeLayout(false);
            Agr_control.PerformLayout();
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
        public ListView listView_agreemtns;
        private ListView listView_Clients;
        private Label label1;
        private ComboBox New_Client_Type;
        private TextBox New_CLient_Number;
        private Label label2;
        private Label label3;
        private MaskedTextBox New_Client_Date;
    }
}

