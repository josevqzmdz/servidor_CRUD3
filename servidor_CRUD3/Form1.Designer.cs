namespace servidor_CRUD3
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ingresar_btn = new System.Windows.Forms.Button();
            this.registrar_btn = new System.Windows.Forms.Button();
            this.nombre_txt = new System.Windows.Forms.TextBox();
            this.contra_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ingresar_btn
            // 
            this.ingresar_btn.Location = new System.Drawing.Point(48, 158);
            this.ingresar_btn.Name = "ingresar_btn";
            this.ingresar_btn.Size = new System.Drawing.Size(75, 36);
            this.ingresar_btn.TabIndex = 0;
            this.ingresar_btn.Text = "ingresar";
            this.ingresar_btn.UseVisualStyleBackColor = true;
            this.ingresar_btn.Click += new System.EventHandler(this.ingresar_btn_Click);
            // 
            // registrar_btn
            // 
            this.registrar_btn.Location = new System.Drawing.Point(326, 158);
            this.registrar_btn.Name = "registrar_btn";
            this.registrar_btn.Size = new System.Drawing.Size(75, 36);
            this.registrar_btn.TabIndex = 1;
            this.registrar_btn.Text = "registrarse";
            this.registrar_btn.UseVisualStyleBackColor = true;
            this.registrar_btn.Click += new System.EventHandler(this.registrar_btn_Click);
            // 
            // nombre_txt
            // 
            this.nombre_txt.Location = new System.Drawing.Point(167, 39);
            this.nombre_txt.Name = "nombre_txt";
            this.nombre_txt.Size = new System.Drawing.Size(234, 22);
            this.nombre_txt.TabIndex = 2;
            // 
            // contra_txt
            // 
            this.contra_txt.Location = new System.Drawing.Point(167, 89);
            this.contra_txt.Name = "contra_txt";
            this.contra_txt.Size = new System.Drawing.Size(234, 22);
            this.contra_txt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "contraseña";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 234);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contra_txt);
            this.Controls.Add(this.nombre_txt);
            this.Controls.Add(this.registrar_btn);
            this.Controls.Add(this.ingresar_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ingresar_btn;
        private System.Windows.Forms.Button registrar_btn;
        private System.Windows.Forms.TextBox nombre_txt;
        private System.Windows.Forms.TextBox contra_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

