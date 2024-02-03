namespace FastCore.User
{
    partial class Form1
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
            RunTest = new Button();
            listBox1 = new ListBox();
            trackBar1 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // RunTest
            // 
            RunTest.Location = new Point(12, 12);
            RunTest.Name = "RunTest";
            RunTest.Size = new Size(149, 56);
            RunTest.TabIndex = 0;
            RunTest.Text = "Test";
            RunTest.UseVisualStyleBackColor = true;
            RunTest.Click += RunTest_Click;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(184, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(596, 424);
            listBox1.TabIndex = 1;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(12, 90);
            trackBar1.Maximum = 50;
            trackBar1.Minimum = 5;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(149, 45);
            trackBar1.TabIndex = 2;
            trackBar1.Value = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(trackBar1);
            Controls.Add(listBox1);
            Controls.Add(RunTest);
            Name = "Form1";
            Text = "Бенчмарк";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RunTest;
        private ListBox listBox1;
        private TrackBar trackBar1;
    }
}
