
namespace kockapoker
{
    partial class Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerCountCBox = new System.Windows.Forms.ComboBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kérem válassza ki a játékosok számát:";
            // 
            // PlayerCountCBox
            // 
            this.PlayerCountCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlayerCountCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PlayerCountCBox.FormattingEnabled = true;
            this.PlayerCountCBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.PlayerCountCBox.Location = new System.Drawing.Point(298, 15);
            this.PlayerCountCBox.Name = "PlayerCountCBox";
            this.PlayerCountCBox.Size = new System.Drawing.Size(57, 28);
            this.PlayerCountCBox.TabIndex = 2;
            // 
            // StartBtn
            // 
            this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StartBtn.Location = new System.Drawing.Point(131, 88);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(110, 41);
            this.StartBtn.TabIndex = 3;
            this.StartBtn.Text = "Játci";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 162);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.PlayerCountCBox);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PlayerCountCBox;
        private System.Windows.Forms.Button StartBtn;
    }
}