namespace M014
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			label1.Text += "Test";
			Form2 f = new Form2();
			if (f.ShowDialog() == DialogResult.OK)
			{
				label1.Text = f.Name;
			}
		}
	}
}