namespace ase_assignment
{
    partial class MainForm
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
            multiLineConsole = new TextBox();
            runButton = new Button();
            syntaxButton = new Button();
            singleLineConsole = new TextBox();
            loadButton = new Button();
            saveButton = new Button();
            drawingArea = new PictureBox();
            errorConsole = new TextBox();
            saveProgramDialog = new SaveFileDialog();
            loadProgramDialog = new OpenFileDialog();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)drawingArea).BeginInit();
            SuspendLayout();
            // 
            // multiLineConsole
            // 
            multiLineConsole.BackColor = SystemColors.ControlText;
            multiLineConsole.BorderStyle = BorderStyle.FixedSingle;
            multiLineConsole.Cursor = Cursors.IBeam;
            multiLineConsole.Font = new Font("Lucida Console", 11F, FontStyle.Regular, GraphicsUnit.Point);
            multiLineConsole.ForeColor = Color.Lime;
            multiLineConsole.Location = new Point(32, 56);
            multiLineConsole.Multiline = true;
            multiLineConsole.Name = "multiLineConsole";
            multiLineConsole.Size = new Size(900, 900);
            multiLineConsole.TabIndex = 0;
            // 
            // runButton
            // 
            runButton.Location = new Point(32, 1013);
            runButton.Name = "runButton";
            runButton.Size = new Size(112, 34);
            runButton.TabIndex = 1;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // syntaxButton
            // 
            syntaxButton.Location = new Point(150, 1013);
            syntaxButton.Name = "syntaxButton";
            syntaxButton.Size = new Size(112, 34);
            syntaxButton.TabIndex = 2;
            syntaxButton.TabStop = false;
            syntaxButton.Text = "Syntax";
            syntaxButton.UseVisualStyleBackColor = true;
            syntaxButton.Click += syntaxButton_Click;
            // 
            // singleLineConsole
            // 
            singleLineConsole.BackColor = SystemColors.InfoText;
            singleLineConsole.BorderStyle = BorderStyle.FixedSingle;
            singleLineConsole.Font = new Font("Lucida Console", 12F, FontStyle.Regular, GraphicsUnit.Point);
            singleLineConsole.ForeColor = Color.Lime;
            singleLineConsole.Location = new Point(32, 976);
            singleLineConsole.Name = "singleLineConsole";
            singleLineConsole.Size = new Size(900, 31);
            singleLineConsole.TabIndex = 3;
            singleLineConsole.KeyDown += singleLineConsole_KeyDown;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(150, 16);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(112, 34);
            loadButton.TabIndex = 4;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(32, 16);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(112, 34);
            saveButton.TabIndex = 5;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // drawingArea
            // 
            drawingArea.BackColor = Color.White;
            drawingArea.BorderStyle = BorderStyle.FixedSingle;
            drawingArea.Cursor = Cursors.Cross;
            drawingArea.Location = new Point(959, 57);
            drawingArea.Name = "drawingArea";
            drawingArea.Size = new Size(900, 950);
            drawingArea.TabIndex = 6;
            drawingArea.TabStop = false;
            // 
            // errorConsole
            // 
            errorConsole.BackColor = SystemColors.ActiveCaptionText;
            errorConsole.ForeColor = Color.Crimson;
            errorConsole.Location = new Point(32, 1103);
            errorConsole.Multiline = true;
            errorConsole.Name = "errorConsole";
            errorConsole.ReadOnly = true;
            errorConsole.Size = new Size(1827, 165);
            errorConsole.TabIndex = 7;
            // 
            // saveProgramDialog
            // 
            saveProgramDialog.Filter = "text document|*.txt";
            // 
            // loadProgramDialog
            // 
            loadProgramDialog.Filter = "text document|*.txt";
            // 
            // button1
            // 
            button1.Location = new Point(959, 1013);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 8;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1910, 1347);
            Controls.Add(button1);
            Controls.Add(errorConsole);
            Controls.Add(drawingArea);
            Controls.Add(saveButton);
            Controls.Add(loadButton);
            Controls.Add(singleLineConsole);
            Controls.Add(syntaxButton);
            Controls.Add(runButton);
            Controls.Add(multiLineConsole);
            ForeColor = SystemColors.ControlText;
            Name = "MainForm";
            Text = "Draw with words";
            ((System.ComponentModel.ISupportInitialize)drawingArea).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox multiLineConsole;
        private Button runButton;
        private Button syntaxButton;
        private TextBox singleLineConsole;
        private Button loadButton;
        private Button saveButton;
        private PictureBox drawingArea;
        private TextBox errorConsole;
        private SaveFileDialog saveProgramDialog;
        private OpenFileDialog loadProgramDialog;
        private Button button1;
    }
}