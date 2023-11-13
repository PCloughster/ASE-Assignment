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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            multiLineConsole.Size = new Size(865, 889);
            multiLineConsole.TabIndex = 0;
            // 
            // runButton
            // 
            runButton.Location = new Point(32, 1008);
            runButton.Name = "runButton";
            runButton.Size = new Size(112, 34);
            runButton.TabIndex = 1;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = true;
            // 
            // syntaxButton
            // 
            syntaxButton.Location = new Point(165, 1008);
            syntaxButton.Name = "syntaxButton";
            syntaxButton.Size = new Size(112, 34);
            syntaxButton.TabIndex = 2;
            syntaxButton.TabStop = false;
            syntaxButton.Text = "Syntax";
            syntaxButton.UseVisualStyleBackColor = true;
            // 
            // singleLineConsole
            // 
            singleLineConsole.BackColor = SystemColors.InfoText;
            singleLineConsole.BorderStyle = BorderStyle.FixedSingle;
            singleLineConsole.Font = new Font("Lucida Console", 12F, FontStyle.Regular, GraphicsUnit.Point);
            singleLineConsole.ForeColor = Color.Lime;
            singleLineConsole.Location = new Point(32, 962);
            singleLineConsole.Name = "singleLineConsole";
            singleLineConsole.Size = new Size(865, 31);
            singleLineConsole.TabIndex = 3;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(150, 16);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(112, 34);
            loadButton.TabIndex = 4;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(32, 16);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(112, 34);
            saveButton.TabIndex = 5;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.HighlightText;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Cursor = Cursors.Cross;
            pictureBox1.Location = new Point(959, 57);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(785, 936);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1788, 1068);
            Controls.Add(pictureBox1);
            Controls.Add(saveButton);
            Controls.Add(loadButton);
            Controls.Add(singleLineConsole);
            Controls.Add(syntaxButton);
            Controls.Add(runButton);
            Controls.Add(multiLineConsole);
            ForeColor = SystemColors.ControlText;
            Name = "MainForm";
            Text = "Draw with words";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}