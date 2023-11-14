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
            Boolean syntaxValid = commandParser.SyntaxCheckProgram(multiLineConsole.Text);
            if (syntaxValid == true)
            {
                errorConsole.Text = "Syntax is correct.";
                commandParser.ParseMultipleCommands(multiLineConsole.Text);
            }
            else
            {
                errorConsole.Text = commandParser.errorLog;
            }
        }

        private void syntaxButton_Click(object sender, EventArgs e)
        {
            Boolean syntaxValid = commandParser.SyntaxCheckProgram(multiLineConsole.Text);
            if (syntaxValid == true)
            {
                errorConsole.Text = "Syntax is correct.";
            }
            else
            {
                errorConsole.Text = commandParser.errorLog;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveProgramDialog.ShowDialog() == DialogResult.OK)
            {
                string[] program = commandParser.ProgramArray(multiLineConsole.Text);
                commandParser.SaveProgram(saveProgramDialog.FileName, program);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (loadProgramDialog.ShowDialog() == DialogResult.OK)
            {
                string loadedProgram = commandParser.LoadProgram(loadProgramDialog.FileName);
                multiLineConsole.Text = loadedProgram;
            }
        }
    }
}