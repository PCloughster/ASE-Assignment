namespace ase_assignment
{
    public partial class MainForm : Form
    {
        CommandParser commandParser = new CommandParser();
        public MainForm()
        {
            InitializeComponent();

        }

        private void singleLineConsole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                commandParser.ParseSingleCommand(singleLineConsole.Text);
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            commandParser.ParseMultipleCommands(multiLineConsole.Text);
        }

        private void syntaxButton_Click(object sender, EventArgs e)
        {
            commandParser.SyntaxCheckProgram(multiLineConsole.Text);
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