namespace Lab1IP1
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
            this.pictureGraph = new System.Windows.Forms.PictureBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonNextForm = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.labelStaticName = new System.Windows.Forms.Label();
            this.labelObjectName = new System.Windows.Forms.Label();
            this.buttonLoadCollection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureGraph
            // 
            this.pictureGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureGraph.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureGraph.Location = new System.Drawing.Point(9, 12);
            this.pictureGraph.Name = "pictureGraph";
            this.pictureGraph.Size = new System.Drawing.Size(220, 220);
            this.pictureGraph.TabIndex = 1;
            this.pictureGraph.TabStop = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(235, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(99, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add new form";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(235, 41);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(99, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete form";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(235, 70);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(99, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save collection";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.SaveCollection);
            // 
            // buttonNextForm
            // 
            this.buttonNextForm.Location = new System.Drawing.Point(235, 180);
            this.buttonNextForm.Name = "buttonNextForm";
            this.buttonNextForm.Size = new System.Drawing.Size(99, 23);
            this.buttonNextForm.TabIndex = 5;
            this.buttonNextForm.Text = "Next form";
            this.buttonNextForm.UseVisualStyleBackColor = true;
            this.buttonNextForm.Click += new System.EventHandler(this.ButtonNext);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(235, 209);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(99, 23);
            this.buttonPrevious.TabIndex = 6;
            this.buttonPrevious.Text = "Previous form";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.ButtonPrevious);
            // 
            // labelStaticName
            // 
            this.labelStaticName.AutoSize = true;
            this.labelStaticName.Location = new System.Drawing.Point(6, 242);
            this.labelStaticName.Name = "labelStaticName";
            this.labelStaticName.Size = new System.Drawing.Size(70, 13);
            this.labelStaticName.TabIndex = 7;
            this.labelStaticName.Text = "Object name:";
            // 
            // labelObjectName
            // 
            this.labelObjectName.Location = new System.Drawing.Point(77, 235);
            this.labelObjectName.Name = "labelObjectName";
            this.labelObjectName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelObjectName.Size = new System.Drawing.Size(257, 29);
            this.labelObjectName.TabIndex = 8;
            this.labelObjectName.Text = " test";
            this.labelObjectName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLoadCollection
            // 
            this.buttonLoadCollection.Location = new System.Drawing.Point(235, 99);
            this.buttonLoadCollection.Name = "buttonLoadCollection";
            this.buttonLoadCollection.Size = new System.Drawing.Size(99, 23);
            this.buttonLoadCollection.TabIndex = 9;
            this.buttonLoadCollection.Text = "Load collection";
            this.buttonLoadCollection.UseVisualStyleBackColor = true;
            this.buttonLoadCollection.Click += new System.EventHandler(this.LoadColection);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 264);
            this.Controls.Add(this.buttonLoadCollection);
            this.Controls.Add(this.labelObjectName);
            this.Controls.Add(this.labelStaticName);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNextForm);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.pictureGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Lab1 prob 1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureGraph;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonNextForm;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Label labelStaticName;
        private System.Windows.Forms.Label labelObjectName;
        private System.Windows.Forms.Button buttonLoadCollection;
    }
}

