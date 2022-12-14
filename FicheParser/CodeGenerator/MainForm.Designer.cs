namespace CodeGenerator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInsertedCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInsertedCode
            // 
            this.txtInsertedCode.Location = new System.Drawing.Point(54, 12);
            this.txtInsertedCode.Name = "txtInsertedCode";
            this.txtInsertedCode.Size = new System.Drawing.Size(126, 27);
            this.txtInsertedCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kod";
            // 
            // btnLook
            // 
            this.btnLook.Location = new System.Drawing.Point(203, 15);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(116, 29);
            this.btnLook.TabIndex = 2;
            this.btnLook.Text = "Sorgula";
            this.btnLook.UseVisualStyleBackColor = true;
            this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLook);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInsertedCode);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtInsertedCode;
        private Label label1;
        private Button btnLook;
    }
}