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
            this.TxtNoteID = new System.Windows.Forms.TextBox();
            this.TxtNoteValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.TxtJsonResult.Size = new System.Drawing.Size(185, 378);
            this.TxtJsonResult.TabIndex = 1;
            this.TxtJsonResult.Text = "JsonResult";
            // 
            // DGVNotes
            // 
            this.DGVNotes.AllowUserToAddRows = false;
            this.DGVNotes.AllowUserToDeleteRows = false;
            this.DGVNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVNotes.Location = new System.Drawing.Point(209, 40);
            this.DGVNotes.Name = "DGVNotes";
            this.DGVNotes.Size = new System.Drawing.Size(304, 378);
            this.DGVNotes.TabIndex = 2;
            this.DGVNotes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVNotes_CellClick);
            // 
            // TxtNoteID
            // 
            this.TxtNoteID.Location = new System.Drawing.Point(549, 53);
            this.TxtNoteID.Name = "TxtNoteID";
            this.TxtNoteID.Size = new System.Drawing.Size(65, 20);
            this.TxtNoteID.TabIndex = 3;
            // 
            // TxtNoteValue
            // 
            this.TxtNoteValue.Location = new System.Drawing.Point(620, 53);
            this.TxtNoteValue.Name = "TxtNoteValue";
            this.TxtNoteValue.Size = new System.Drawing.Size(135, 20);
            this.TxtNoteValue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(546, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNoteValue);
            this.Controls.Add(this.TxtNoteID);
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
        private System.Windows.Forms.TextBox TxtNoteID;
        private System.Windows.Forms.TextBox TxtNoteValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

