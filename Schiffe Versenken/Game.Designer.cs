namespace Schiffe_Versenken
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_do = new System.Windows.Forms.Label();
            this.button_placed = new System.Windows.Forms.Button();
            this.general = new System.Windows.Forms.Timer(this.components);
            this.button_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(204, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your Field:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(708, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Opponent Field:";
            // 
            // label_do
            // 
            this.label_do.AutoSize = true;
            this.label_do.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_do.ForeColor = System.Drawing.Color.White;
            this.label_do.Location = new System.Drawing.Point(300, 755);
            this.label_do.Name = "label_do";
            this.label_do.Size = new System.Drawing.Size(35, 37);
            this.label_do.TabIndex = 3;
            this.label_do.Text = "#";
            // 
            // button_placed
            // 
            this.button_placed.BackColor = System.Drawing.Color.YellowGreen;
            this.button_placed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_placed.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_placed.Location = new System.Drawing.Point(876, 755);
            this.button_placed.Name = "button_placed";
            this.button_placed.Size = new System.Drawing.Size(242, 80);
            this.button_placed.TabIndex = 4;
            this.button_placed.Text = "Finish";
            this.button_placed.UseVisualStyleBackColor = false;
            this.button_placed.Click += new System.EventHandler(this.button_placed_Click);
            // 
            // general
            // 
            this.general.Enabled = true;
            this.general.Interval = 1000;
            this.general.Tick += new System.EventHandler(this.general_Tick);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.OrangeRed;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exit.Location = new System.Drawing.Point(12, 773);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(125, 80);
            this.button_exit.TabIndex = 5;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1130, 865);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_placed);
            this.Controls.Add(this.label_do);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_do;
        private System.Windows.Forms.Button button_placed;
        private System.Windows.Forms.Timer general;
        private System.Windows.Forms.Button button_exit;
    }
}