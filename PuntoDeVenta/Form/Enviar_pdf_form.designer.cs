namespace punto_venta
{
    partial class enviar_pdf_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(enviar_pdf_form));
            this.label1 = new System.Windows.Forms.Label();
            this.correo_textbox = new System.Windows.Forms.TextBox();
            this.enviar_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Correo:";
            // 
            // correo_textbox
            // 
            this.correo_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correo_textbox.Location = new System.Drawing.Point(91, 6);
            this.correo_textbox.Name = "correo_textbox";
            this.correo_textbox.Size = new System.Drawing.Size(352, 29);
            this.correo_textbox.TabIndex = 4;
            this.correo_textbox.Leave += new System.EventHandler(this.cliente_textBox_Leave);
            // 
            // enviar_button
            // 
            this.enviar_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviar_button.Location = new System.Drawing.Point(142, 41);
            this.enviar_button.Name = "enviar_button";
            this.enviar_button.Size = new System.Drawing.Size(88, 32);
            this.enviar_button.TabIndex = 9;
            this.enviar_button.Text = "Enviar";
            this.enviar_button.UseVisualStyleBackColor = true;
            this.enviar_button.Click += new System.EventHandler(this.enviar_button_Click);
            // 
            // enviar_pdf_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 82);
            this.Controls.Add(this.enviar_button);
            this.Controls.Add(this.correo_textbox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "enviar_pdf_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar PDF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox correo_textbox;
        private System.Windows.Forms.Button enviar_button;
    }
}