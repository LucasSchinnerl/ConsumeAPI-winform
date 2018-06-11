namespace ConsumeAPI_winform
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
            this.BtnGo = new System.Windows.Forms.Button();
            this.TxtJsonResult = new System.Windows.Forms.TextBox();
            this.DGVNotes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnGo
            // 
            this.BtnGo.Location = new System.Drawing.Point(0, 0);
            this.BtnGo.Name = "BtnGo";
            this.BtnGo.Size = new System.Drawing.Size(75, 23);
            this.BtnGo.TabIndex = 0;
            this.BtnGo.Text = "Go";
            this.BtnGo.UseVisualStyleBackColor = true;
            this.BtnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // TxtJsonResult
            // 
            this.TxtJsonResult.Location = new System.Drawing.Point(0, 40);
            this.TxtJsonResult.Multiline = true;
            this.TxtJsonResult.Name = "TxtJsonResult";
            this.TxtJsonResult.Size = new System.Drawing.Size(509, 201);
            this.TxtJsonResult.TabIndex = 1;
            this.TxtJsonResult.Text = "JsonResult";
            // 
            // DGVNotes
            // 
            this.DGVNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVNotes.Location = new System.Drawing.Point(530, 40);
            this.DGVNotes.Name = "DGVNotes";
            this.DGVNotes.Size = new System.Drawing.Size(240, 378);
            this.DGVNotes.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DGVNotes);
            this.Controls.Add(this.TxtJsonResult);
            this.Controls.Add(this.BtnGo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DGVNotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGo;
        private System.Windows.Forms.TextBox TxtJsonResult;
        private System.Windows.Forms.DataGridView DGVNotes;
    }
}

