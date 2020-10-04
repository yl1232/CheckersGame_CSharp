namespace Ex05
{
    public partial class GameSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.doneButton = new System.Windows.Forms.Button();
            this.setSize6 = new System.Windows.Forms.RadioButton();
            this.setSize8 = new System.Windows.Forms.RadioButton();
            this.setSize10 = new System.Windows.Forms.RadioButton();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.playersLabel = new System.Windows.Forms.Label();
            this.player1Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.player2CheckBox = new System.Windows.Forms.CheckBox();
            this.player2Name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(269, 211);
            this.doneButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(86, 32);
            this.doneButton.TabIndex = 0;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // setSize6
            // 
            this.setSize6.AutoSize = true;
            this.setSize6.Location = new System.Drawing.Point(45, 42);
            this.setSize6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.setSize6.Name = "setSize6";
            this.setSize6.Size = new System.Drawing.Size(67, 24);
            this.setSize6.TabIndex = 1;
            this.setSize6.TabStop = true;
            this.setSize6.Text = "6 x 6";
            this.setSize6.UseVisualStyleBackColor = true;
            this.setSize6.CheckedChanged += new System.EventHandler(this.BoardSizeRadioButton_Click);
            // 
            // setSize8
            // 
            this.setSize8.AutoSize = true;
            this.setSize8.Location = new System.Drawing.Point(159, 42);
            this.setSize8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.setSize8.Name = "setSize8";
            this.setSize8.Size = new System.Drawing.Size(67, 24);
            this.setSize8.TabIndex = 2;
            this.setSize8.TabStop = true;
            this.setSize8.Text = "8 x 8";
            this.setSize8.UseVisualStyleBackColor = true;
            this.setSize8.CheckedChanged += new System.EventHandler(this.BoardSizeRadioButton_Click);
            // 
            // setSize10
            // 
            this.setSize10.AutoSize = true;
            this.setSize10.Location = new System.Drawing.Point(270, 42);
            this.setSize10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.setSize10.Name = "setSize10";
            this.setSize10.Size = new System.Drawing.Size(85, 24);
            this.setSize10.TabIndex = 3;
            this.setSize10.TabStop = true;
            this.setSize10.Text = "10 x 10";
            this.setSize10.UseVisualStyleBackColor = true;
            this.setSize10.CheckedChanged += new System.EventHandler(this.BoardSizeRadioButton_Click);
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.Location = new System.Drawing.Point(25, 12);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(91, 20);
            this.boardSizeLabel.TabIndex = 4;
            this.boardSizeLabel.Text = "Board Size:";
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Location = new System.Drawing.Point(25, 79);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(64, 20);
            this.playersLabel.TabIndex = 5;
            this.playersLabel.Text = "Players:";
            // 
            // player1Name
            // 
            this.player1Name.Location = new System.Drawing.Point(184, 118);
            this.player1Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(170, 26);
            this.player1Name.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Player 1:";
            // 
            // player2CheckBox
            // 
            this.player2CheckBox.AutoSize = true;
            this.player2CheckBox.Location = new System.Drawing.Point(50, 168);
            this.player2CheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.player2CheckBox.Name = "player2CheckBox";
            this.player2CheckBox.Size = new System.Drawing.Size(95, 24);
            this.player2CheckBox.TabIndex = 9;
            this.player2CheckBox.Text = "Player 2:";
            this.player2CheckBox.UseVisualStyleBackColor = true;
            this.player2CheckBox.CheckedChanged += new System.EventHandler(this.SecondPlayerCheckBox_Click);
            // 
            // player2Name
            // 
            this.player2Name.Enabled = false;
            this.player2Name.Location = new System.Drawing.Point(184, 165);
            this.player2Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(170, 26);
            this.player2Name.TabIndex = 10;
            this.player2Name.Text = "[Computer]";
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(377, 266);
            this.Controls.Add(this.player2Name);
            this.Controls.Add(this.player2CheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.player1Name);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.boardSizeLabel);
            this.Controls.Add(this.setSize10);
            this.Controls.Add(this.setSize8);
            this.Controls.Add(this.setSize6);
            this.Controls.Add(this.doneButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Checkers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.RadioButton setSize6;
        private System.Windows.Forms.RadioButton setSize8;
        private System.Windows.Forms.RadioButton setSize10;
        private System.Windows.Forms.Label boardSizeLabel;
        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.TextBox player1Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox player2CheckBox;
        private System.Windows.Forms.TextBox player2Name;
    }
}