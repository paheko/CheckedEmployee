namespace punto_venta
{
    partial class Chequeo_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chequeo_form));
            this.codigo_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Agregar_usuarios_Button = new System.Windows.Forms.Button();
            this.privilegios_combo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // codigo_textbox
            // 
            this.codigo_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigo_textbox.Location = new System.Drawing.Point(103, 100);
            this.codigo_textbox.Name = "codigo_textbox";
            this.codigo_textbox.Size = new System.Drawing.Size(372, 26);
            this.codigo_textbox.TabIndex = 2;
            this.codigo_textbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.codigo_textbox_MouseClick);
            this.codigo_textbox.Enter += new System.EventHandler(this.codigo_textbox_Enter);
            this.codigo_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nombre_textbox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 24);
            this.label1.TabIndex = 31;
            this.label1.Text = "Código del usuario";
            // 
            // Agregar_usuarios_Button
            // 
            this.Agregar_usuarios_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Agregar_usuarios_Button.Location = new System.Drawing.Point(222, 132);
            this.Agregar_usuarios_Button.Name = "Agregar_usuarios_Button";
            this.Agregar_usuarios_Button.Size = new System.Drawing.Size(145, 45);
            this.Agregar_usuarios_Button.TabIndex = 32;
            this.Agregar_usuarios_Button.Text = "Agregar";
            this.Agregar_usuarios_Button.UseVisualStyleBackColor = true;
            this.Agregar_usuarios_Button.Click += new System.EventHandler(this.Agregar_usuarios_Button_Click);
            // 
            // privilegios_combo
            // 
            this.privilegios_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.privilegios_combo.FormattingEnabled = true;
            this.privilegios_combo.Location = new System.Drawing.Point(179, 42);
            this.privilegios_combo.Name = "privilegios_combo";
            this.privilegios_combo.Size = new System.Drawing.Size(252, 28);
            this.privilegios_combo.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(218, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 24);
            this.label2.TabIndex = 34;
            this.label2.Text = "Selecciona tu status";
            // 
            // Chequeo_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 189);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.privilegios_combo);
            this.Controls.Add(this.Agregar_usuarios_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codigo_textbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chequeo_form";
            this.Text = "Entradas/salidas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codigo_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Agregar_usuarios_Button;
        private System.Windows.Forms.ComboBox privilegios_combo;
        private System.Windows.Forms.Label label2;

    }
}