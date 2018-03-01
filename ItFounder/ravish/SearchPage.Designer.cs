namespace ITFounder
{
    partial class SearchPage
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
            this.SearchQueryBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.exitbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultList = new System.Windows.Forms.ListBox();
            this.errorLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SearchQueryBox
            // 
            this.SearchQueryBox.Location = new System.Drawing.Point(307, 43);
            this.SearchQueryBox.Name = "SearchQueryBox";
            this.SearchQueryBox.Size = new System.Drawing.Size(162, 20);
            this.SearchQueryBox.TabIndex = 0;
            this.SearchQueryBox.Text = "sec 62 noida\r\n";
           
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(321, 122);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButtonClick);
            // 
            // exitbutton
            // 
            this.exitbutton.Location = new System.Drawing.Point(402, 122);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(75, 23);
            this.exitbutton.TabIndex = 2;
            this.exitbutton.Text = "Exit";
            this.exitbutton.UseVisualStyleBackColor = true;
            this.exitbutton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Location";
            // 
            // ResultList
            // 
            this.ResultList.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultList.FormattingEnabled = true;
            this.ResultList.HorizontalScrollbar = true;
            this.ResultList.ItemHeight = 20;
            this.ResultList.Location = new System.Drawing.Point(12, 163);
            this.ResultList.Name = "ResultList";
            this.ResultList.Size = new System.Drawing.Size(712, 104);
            this.ResultList.TabIndex = 4;
         
            // 
            // errorLable
            // 
            this.errorLable.AutoSize = true;
            this.errorLable.BackColor = System.Drawing.SystemColors.HighlightText;
            this.errorLable.Location = new System.Drawing.Point(318, 83);
            this.errorLable.Name = "errorLable";
            this.errorLable.Size = new System.Drawing.Size(35, 13);
            this.errorLable.TabIndex = 5;
            this.errorLable.Text = "label2";
            this.errorLable.Visible = false;
            // 
            // SearchPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ravish.Properties.Resources.finalimage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(736, 295);
            this.Controls.Add(this.errorLable);
            this.Controls.Add(this.ResultList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchQueryBox);
            this.Name = "SearchPage";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchQueryBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ResultList;
        private System.Windows.Forms.Label errorLable;
    }
}

