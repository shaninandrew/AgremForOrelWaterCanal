namespace wfa_symple
{
    public partial class MainWindoiw : Form
    {
        Color default_Color = Color.White;
        Color default_BackColor = Color.White;


        Editor_Price ep = new Editor_Price();
        AgrmGenerator agrm = new AgrmGenerator();

        public MainWindoiw()
        {
            InitializeComponent();


            //скрытый редактор


            ep.Dock = DockStyle.Fill;
            ep.FormBorderStyle = FormBorderStyle.None;
            ep.TopLevel = false;
            ep.Parent = Main_Split_Conatainer.Panel2;

            agrm.Dock = DockStyle.Fill;
            agrm.FormBorderStyle = FormBorderStyle.None;
            agrm.TopLevel = false;

            agrm.Parent = Main_Split_Conatainer.Panel2;

            ShowPrice_Click(this, new EventArgs());

        }

      

        private void ShowPrice_Click(object sender, EventArgs e)
        {


            agrm.Hide();
            ep.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            agrm.Show();
            ep.Hide();
        }
    }
}
