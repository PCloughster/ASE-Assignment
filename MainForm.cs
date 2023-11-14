namespace ase_assignment
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private void singleLineConsole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CommandParser commandParser = new CommandParser();

                commandParser.ParseSingleCommand(singleLineConsole.Text);
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            // foreach loop to get all of the text from here
        }

        private void syntaxButton_Click(object sender, EventArgs e)
        {
            // just calls check syntax class
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // open window to save current text in multiLineConsole
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            // open file select window to load text into multiLineConsole
        }
    }
}