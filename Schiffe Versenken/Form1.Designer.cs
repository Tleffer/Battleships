namespace Schiffe_Versenken
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button_host = new System.Windows.Forms.Button();
            this.button_join = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(91, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Schiffe versenken";
            // 
            // button_host
            // 
            this.button_host.BackColor = System.Drawing.Color.LightSalmon;
            this.button_host.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_host.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_host.Location = new System.Drawing.Point(82, 121);
            this.button_host.Name = "button_host";
            this.button_host.Size = new System.Drawing.Size(242, 80);
            this.button_host.TabIndex = 1;
            this.button_host.Text = "Host";
            this.button_host.UseVisualStyleBackColor = false;
            this.button_host.Click += new System.EventHandler(this.button_host_Click);
            // 
            // button_join
            // 
            this.button_join.BackColor = System.Drawing.Color.YellowGreen;
            this.button_join.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_join.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_join.Location = new System.Drawing.Point(82, 267);
            this.button_join.Name = "button_join";
            this.button_join.Size = new System.Drawing.Size(242, 80);
            this.button_join.TabIndex = 2;
            this.button_join.Text = "Join";
            this.button_join.UseVisualStyleBackColor = false;
            this.button_join.Click += new System.EventHandler(this.button_join_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(415, 450);
            this.Controls.Add(this.button_join);
            this.Controls.Add(this.button_host);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_host;
        private System.Windows.Forms.Button button_join;
    }
}

