namespace Schiffe_Versenken
{
    partial class Host
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
            this.ip_label = new System.Windows.Forms.Label();
            this.port_label = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.general = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Game Port:";
            // 
            // ip_label
            // 
            this.ip_label.AutoSize = true;
            this.ip_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip_label.ForeColor = System.Drawing.Color.White;
            this.ip_label.Location = new System.Drawing.Point(225, 70);
            this.ip_label.Name = "ip_label";
            this.ip_label.Size = new System.Drawing.Size(26, 29);
            this.ip_label.TabIndex = 2;
            this.ip_label.Text = "#";
            // 
            // port_label
            // 
            this.port_label.AutoSize = true;
            this.port_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.port_label.ForeColor = System.Drawing.Color.White;
            this.port_label.Location = new System.Drawing.Point(225, 141);
            this.port_label.Name = "port_label";
            this.port_label.Size = new System.Drawing.Size(26, 29);
            this.port_label.TabIndex = 3;
            this.port_label.Text = "#";
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.Tomato;
            this.button_start.Enabled = false;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.Location = new System.Drawing.Point(125, 365);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(242, 80);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_join_Click);
            // 
            // general
            // 
            this.general.Enabled = true;
            this.general.Interval = 1000;
            this.general.Tick += new System.EventHandler(this.general_Tick);
            // 
            // Host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(504, 528);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.port_label);
            this.Controls.Add(this.ip_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Host";
            this.Text = "Host";
            this.Load += new System.EventHandler(this.Host_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ip_label;
        private System.Windows.Forms.Label port_label;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Timer general;
    }
}