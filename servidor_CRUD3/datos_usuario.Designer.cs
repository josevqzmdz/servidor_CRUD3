namespace servidor_CRUD3
{
    partial class datos_usuario
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
            this.modificar_btn = new System.Windows.Forms.Button();
            this.nombre_lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ID_lbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contra_lbl = new System.Windows.Forms.Label();
            this.agregar_btn = new System.Windows.Forms.Button();
            this.eliminar_btn = new System.Windows.Forms.Button();
            this.salir_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "nombre";
            // 
            // modificar_btn
            // 
            this.modificar_btn.Location = new System.Drawing.Point(29, 176);
            this.modificar_btn.Name = "modificar_btn";
            this.modificar_btn.Size = new System.Drawing.Size(85, 34);
            this.modificar_btn.TabIndex = 1;
            this.modificar_btn.Text = "modificar";
            this.modificar_btn.UseVisualStyleBackColor = true;
            this.modificar_btn.Click += new System.EventHandler(this.modificar_btn_Click);
            // 
            // nombre_lbl
            // 
            this.nombre_lbl.AutoSize = true;
            this.nombre_lbl.Location = new System.Drawing.Point(179, 45);
            this.nombre_lbl.Name = "nombre_lbl";
            this.nombre_lbl.Size = new System.Drawing.Size(46, 17);
            this.nombre_lbl.TabIndex = 2;
            this.nombre_lbl.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "ID";
            // 
            // ID_lbl
            // 
            this.ID_lbl.AutoSize = true;
            this.ID_lbl.Location = new System.Drawing.Point(182, 82);
            this.ID_lbl.Name = "ID_lbl";
            this.ID_lbl.Size = new System.Drawing.Size(46, 17);
            this.ID_lbl.TabIndex = 4;
            this.ID_lbl.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "contraseña";
            // 
            // contra_lbl
            // 
            this.contra_lbl.AutoSize = true;
            this.contra_lbl.Location = new System.Drawing.Point(179, 129);
            this.contra_lbl.Name = "contra_lbl";
            this.contra_lbl.Size = new System.Drawing.Size(46, 17);
            this.contra_lbl.TabIndex = 6;
            this.contra_lbl.Text = "label6";
            // 
            // agregar_btn
            // 
            this.agregar_btn.Location = new System.Drawing.Point(149, 229);
            this.agregar_btn.Name = "agregar_btn";
            this.agregar_btn.Size = new System.Drawing.Size(88, 33);
            this.agregar_btn.TabIndex = 7;
            this.agregar_btn.Text = "agregar";
            this.agregar_btn.UseVisualStyleBackColor = true;
            this.agregar_btn.Click += new System.EventHandler(this.agregar_btn_Click);
            // 
            // eliminar_btn
            // 
            this.eliminar_btn.Location = new System.Drawing.Point(149, 176);
            this.eliminar_btn.Name = "eliminar_btn";
            this.eliminar_btn.Size = new System.Drawing.Size(88, 34);
            this.eliminar_btn.TabIndex = 8;
            this.eliminar_btn.Text = "eliminar";
            this.eliminar_btn.UseVisualStyleBackColor = true;
            this.eliminar_btn.Click += new System.EventHandler(this.eliminar_btn_Click);
            // 
            // salir_btn
            // 
            this.salir_btn.Location = new System.Drawing.Point(29, 229);
            this.salir_btn.Name = "salir_btn";
            this.salir_btn.Size = new System.Drawing.Size(85, 33);
            this.salir_btn.TabIndex = 9;
            this.salir_btn.Text = "salir";
            this.salir_btn.UseVisualStyleBackColor = true;
            this.salir_btn.Click += new System.EventHandler(this.salir_btn_Click);
            // 
            // datos_usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 307);
            this.Controls.Add(this.salir_btn);
            this.Controls.Add(this.eliminar_btn);
            this.Controls.Add(this.agregar_btn);
            this.Controls.Add(this.contra_lbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ID_lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nombre_lbl);
            this.Controls.Add(this.modificar_btn);
            this.Controls.Add(this.label1);
            this.Name = "datos_usuario";
            this.Text = "datos_usuario";
            this.Load += new System.EventHandler(this.datos_usuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button modificar_btn;
        private System.Windows.Forms.Label nombre_lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ID_lbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label contra_lbl;
        private System.Windows.Forms.Button agregar_btn;
        private System.Windows.Forms.Button eliminar_btn;
        private System.Windows.Forms.Button salir_btn;
    }
}