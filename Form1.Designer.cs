﻿namespace OTRS_Counting_Variations
{
    partial class Form1
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
            this.browseButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.combinationLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.combinationListBox = new System.Windows.Forms.ListBox();
            this.countListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(536, 78);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(87, 27);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.textBox1.Location = new System.Drawing.Point(192, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(316, 27);
            this.textBox1.TabIndex = 1;
            // 
            // combinationLabel
            // 
            this.combinationLabel.AutoSize = true;
            this.combinationLabel.Location = new System.Drawing.Point(209, 172);
            this.combinationLabel.Name = "combinationLabel";
            this.combinationLabel.Size = new System.Drawing.Size(95, 20);
            this.combinationLabel.TabIndex = 3;
            this.combinationLabel.Text = "Combination";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(456, 172);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(89, 20);
            this.countLabel.TabIndex = 4;
            this.countLabel.Text = "Times Eaten";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(301, 111);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(85, 27);
            this.calculateButton.TabIndex = 5;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Visible = false;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // combinationListBox
            // 
            this.combinationListBox.FormattingEnabled = true;
            this.combinationListBox.ItemHeight = 20;
            this.combinationListBox.Location = new System.Drawing.Point(209, 214);
            this.combinationListBox.Name = "combinationListBox";
            this.combinationListBox.Size = new System.Drawing.Size(256, 164);
            this.combinationListBox.TabIndex = 6;
            // 
            // countListBox
            // 
            this.countListBox.FormattingEnabled = true;
            this.countListBox.ItemHeight = 20;
            this.countListBox.Location = new System.Drawing.Point(456, 214);
            this.countListBox.Name = "countListBox";
            this.countListBox.Size = new System.Drawing.Size(151, 164);
            this.countListBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.countListBox);
            this.Controls.Add(this.combinationListBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.combinationLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.browseButton);
            this.Name = "Form1";
            this.Text = "Icecream Counter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button browseButton;
        private TextBox textBox1;
        private Label combinationLabel;
        private Label countLabel;
        private Button calculateButton;
        private ListBox combinationListBox;
        private ListBox countListBox;
    }
}