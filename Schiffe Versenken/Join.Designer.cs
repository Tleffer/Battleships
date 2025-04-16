namespace Schiffe_Versenken
{
    partial class Join
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ip_box = new System.Windows.Forms.TextBox();
            this.port_box = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.tick = new System.Windows.Forms.Timer(this.components);
            this.button_start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Game Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Game IP:";
            // 
            // ip_box
            // 
            this.ip_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip_box.Location = new System.Drawing.Point(217, 90);
            this.ip_box.Name = "ip_box";
            this.ip_box.Size = new System.Drawing.Size(246, 26);
            this.ip_box.TabIndex = 4;
            // 
            // port_box
            // 
            this.port_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.port_box.Location = new System.Drawing.Point(217, 152);
            this.port_box.Name = "port_box";
            this.port_box.Size = new System.Drawing.Size(246, 26);
            this.port_box.TabIndex = 5;
            // 
            // button_connect
            // 
            this.button_connect.BackColor = System.Drawing.Color.YellowGreen;
            this.button_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_connect.Location = new System.Drawing.Point(138, 341);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(242, 80);
            this.button_connect.TabIndex = 6;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = false;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // tick
            // 
            this.tick.Enabled = true;
            this.tick.Interval = 1000;
            this.tick.Tick += new System.EventHandler(this.tick_Tick);
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.Tomato;
            this.button_start.Enabled = false;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.Location = new System.Drawing.Point(138, 439);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(242, 80);
            this.button_start.TabIndex = 7;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // Join
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(519, 549);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.port_box);
            this.Controls.Add(this.ip_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Join";
            this.Text = "Join";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ip_box;
        private System.Windows.Forms.TextBox port_box;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Timer tick;
        private System.Windows.Forms.Button button_start;
    }
}