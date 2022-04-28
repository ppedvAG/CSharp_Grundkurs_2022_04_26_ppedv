namespace M014
{
	public partial class Form2 : Form
	{
		public string Name { get; private set; }

		public Form2() => InitializeComponent();

		private void OkClicked(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show($"Ist dein Name so korrekt: {textBox1.Text}", "Bestätigen", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (dr == DialogResult.OK)
			{
				Name = textBox1.Text;
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void AbbrechenClicked(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
