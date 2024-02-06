using Doc4Lab;

namespace OWC_Aggreems
{
    public partial class Bootstrap : Form
    {

        private AgreementEditorWindow agr = null;

        public Bootstrap()
        {
            InitializeComponent();
            agr = new AgreementEditorWindow(this);
            agr.TopLevel = false;
            agr.Parent = MainSplit.Panel2;
            agr.FormBorderStyle = FormBorderStyle.None;

        }


        public EventHandler OnLoad(object sender, EventArgs e)
        {

            return (null);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_CallAgreements_Click(object sender, EventArgs e)
        {
            agr.Show();

        }

        private void MainSplit_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string SQL = @$"select * from [dbo].[SelectAgreementsMainPoint] (1000)
                           where [Guid] in (
                                            SELECT [Guid] FROM [dbo].[SelectAgreementsByString] ('{SearchText.Text}')
                                            )";


                agr.UpdateMainScreen(SQL);

            }
        }
    }
}
