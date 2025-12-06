using AOC2025;

namespace AdventOfCode_2025_Interface
{
    public partial class ScaffolderForm : Form
    {
        public ScaffolderForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDay.Text))
            {
                MessageBox.Show(
                    "Day is empty!",
                    "Day Empty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show(
                    "Title is empty!",
                    "Title Empty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            if (string.IsNullOrWhiteSpace(txtPart.Text))
            {
                MessageBox.Show(
                    "Part is empty!",
                    "Part is Empty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            new AdventPuzzleScaffolder(txtDay.Text, txtTitle.Text, txtPart.Text).ScaffoldPuzzle();
        }
    }
}
