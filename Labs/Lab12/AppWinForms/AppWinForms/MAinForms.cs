namespace AppWinForms
{
    public partial class MAinForms : Form
    {
        public MAinForms()
        {
            InitializeComponent();
        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            AnimationPanel.Location = new Point(
                AnimationPanel.Location.X + 5,
                AnimationPanel.Location.Y);
        }
    }
}
