
namespace kockapoker
{
    partial class Form1
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
            this.RollDiceBtn = new System.Windows.Forms.Button();
            this.TablePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // RollDiceBtn
            // 
            this.RollDiceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RollDiceBtn.Location = new System.Drawing.Point(123, 320);
            this.RollDiceBtn.Name = "RollDiceBtn";
            this.RollDiceBtn.Size = new System.Drawing.Size(153, 64);
            this.RollDiceBtn.TabIndex = 0;
            this.RollDiceBtn.Text = "Roll Dice";
            this.RollDiceBtn.UseVisualStyleBackColor = true;
            this.RollDiceBtn.Click += new System.EventHandler(this.RollDiceBtn_Click);
            // 
            // TablePanel
            // 
            this.TablePanel.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.TablePanel.Location = new System.Drawing.Point(368, 44);
            this.TablePanel.Name = "TablePanel";
            this.TablePanel.Size = new System.Drawing.Size(420, 340);
            this.TablePanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TablePanel);
            this.Controls.Add(this.RollDiceBtn);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Yahtzee";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RollDiceBtn;
        private System.Windows.Forms.Panel TablePanel;
    }
}

