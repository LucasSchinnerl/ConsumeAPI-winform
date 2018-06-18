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
            this.TxtNoteIDEditOrDelete = new System.Windows.Forms.TextBox();
            this.TxtNoteValueEditOrDelete = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnEditContent = new System.Windows.Forms.Button();
            this.TxtNoteIDCreate = new System.Windows.Forms.TextBox();
            this.TxtNoteValueCreate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
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
            // TxtNoteIDEditOrDelete
            // 
            this.TxtNoteIDEditOrDelete.Location = new System.Drawing.Point(549, 53);
            this.TxtNoteIDEditOrDelete.Name = "TxtNoteIDEditOrDelete";
            this.TxtNoteIDEditOrDelete.ReadOnly = true;
            this.TxtNoteIDEditOrDelete.Size = new System.Drawing.Size(65, 20);
            this.TxtNoteIDEditOrDelete.TabIndex = 3;
            this.TxtNoteIDEditOrDelete.TextChanged += new System.EventHandler(this.TxtNoteID_TextChanged);
            // 
            // TxtNoteValueEditOrDelete
            // 
            this.TxtNoteValueEditOrDelete.Location = new System.Drawing.Point(620, 53);
            this.TxtNoteValueEditOrDelete.Name = "TxtNoteValueEditOrDelete";
            this.TxtNoteValueEditOrDelete.Size = new System.Drawing.Size(135, 20);
            this.TxtNoteValueEditOrDelete.TabIndex = 3;
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
            // BtnEditContent
            // 
            this.BtnEditContent.Location = new System.Drawing.Point(549, 90);
            this.BtnEditContent.Name = "BtnEditContent";
            this.BtnEditContent.Size = new System.Drawing.Size(75, 23);
            this.BtnEditContent.TabIndex = 5;
            this.BtnEditContent.Text = "edit";
            this.BtnEditContent.UseVisualStyleBackColor = true;
            this.BtnEditContent.Click += new System.EventHandler(this.BtnEditContent_Click);
            // 
            // TxtNoteIDCreate
            // 
            this.TxtNoteIDCreate.Location = new System.Drawing.Point(549, 163);
            this.TxtNoteIDCreate.Name = "TxtNoteIDCreate";
            this.TxtNoteIDCreate.ReadOnly = true;
            this.TxtNoteIDCreate.Size = new System.Drawing.Size(65, 20);
            this.TxtNoteIDCreate.TabIndex = 3;
            this.TxtNoteIDCreate.TextChanged += new System.EventHandler(this.TxtNoteID_TextChanged);
            // 
            // TxtNoteValueCreate
            // 
            this.TxtNoteValueCreate.Location = new System.Drawing.Point(620, 163);
            this.TxtNoteValueCreate.Name = "TxtNoteValueCreate";
            this.TxtNoteValueCreate.Size = new System.Drawing.Size(135, 20);
            this.TxtNoteValueCreate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(546, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(617, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "value";
            // 
            // BtnCreate
            // 
            this.BtnCreate.Location = new System.Drawing.Point(549, 200);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(75, 23);
            this.BtnCreate.TabIndex = 5;
            this.BtnCreate.Text = "new record";
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(643, 90);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 5;
            this.BtnDelete.Text = "delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCreate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnEditContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNoteValueCreate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNoteIDCreate);
            this.Controls.Add(this.TxtNoteValueEditOrDelete);
            this.Controls.Add(this.TxtNoteIDEditOrDelete);
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
        private System.Windows.Forms.TextBox TxtNoteIDEditOrDelete;
        private System.Windows.Forms.TextBox TxtNoteValueEditOrDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnEditContent;
        private System.Windows.Forms.TextBox TxtNoteIDCreate;
        private System.Windows.Forms.TextBox TxtNoteValueCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.Button BtnDelete;
    }
}

