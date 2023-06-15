namespace Pharmacy.PL
{
    partial class FRM_PRODUCTS_UPDATE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_PRODUCTS_UPDATE));
            this.txtfillprice = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtsellprice = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtbuyprice = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtfilling = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtfillprice
            // 
            this.txtfillprice.BackColor = System.Drawing.Color.White;
            this.txtfillprice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfillprice.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfillprice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtfillprice.Location = new System.Drawing.Point(133, 194);
            this.txtfillprice.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtfillprice.MaxLength = 30;
            this.txtfillprice.Name = "txtfillprice";
            this.txtfillprice.Size = new System.Drawing.Size(102, 26);
            this.txtfillprice.TabIndex = 137;
            this.txtfillprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onlynumber_KeyPress);
            this.txtfillprice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtfillprice_KeyUp);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(25, 193);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 22);
            this.label17.TabIndex = 149;
            this.label17.Text = "Fill Price";
            // 
            // txtsellprice
            // 
            this.txtsellprice.BackColor = System.Drawing.Color.White;
            this.txtsellprice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsellprice.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsellprice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtsellprice.Location = new System.Drawing.Point(133, 126);
            this.txtsellprice.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtsellprice.MaxLength = 30;
            this.txtsellprice.Name = "txtsellprice";
            this.txtsellprice.Size = new System.Drawing.Size(102, 26);
            this.txtsellprice.TabIndex = 134;
            this.txtsellprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onlynumber_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(25, 125);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 22);
            this.label16.TabIndex = 148;
            this.label16.Text = "Sell Price";
            // 
            // txtbuyprice
            // 
            this.txtbuyprice.BackColor = System.Drawing.Color.White;
            this.txtbuyprice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbuyprice.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuyprice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtbuyprice.Location = new System.Drawing.Point(133, 87);
            this.txtbuyprice.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtbuyprice.MaxLength = 30;
            this.txtbuyprice.Name = "txtbuyprice";
            this.txtbuyprice.Size = new System.Drawing.Size(102, 26);
            this.txtbuyprice.TabIndex = 133;
            this.txtbuyprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onlynumber_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(25, 87);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 22);
            this.label15.TabIndex = 147;
            this.label15.Text = "Buy Price";
            // 
            // txtfilling
            // 
            this.txtfilling.BackColor = System.Drawing.Color.White;
            this.txtfilling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfilling.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfilling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtfilling.Location = new System.Drawing.Point(133, 160);
            this.txtfilling.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtfilling.MaxLength = 30;
            this.txtfilling.Name = "txtfilling";
            this.txtfilling.Size = new System.Drawing.Size(102, 26);
            this.txtfilling.TabIndex = 136;
            this.txtfilling.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onlynumber_KeyPress);
            this.txtfilling.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtfilling_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(25, 160);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 22);
            this.label10.TabIndex = 146;
            this.label10.Text = "Fill";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(90, 254);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 33);
            this.btnSave.TabIndex = 142;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.Gainsboro;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtID.Location = new System.Drawing.Point(245, 88);
            this.txtID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(16, 26);
            this.txtID.TabIndex = 144;
            this.txtID.Visible = false;
            // 
            // FRM_PRODUCTS_UPDATE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 311);
            this.Controls.Add(this.txtfillprice);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtsellprice);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtbuyprice);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtfilling);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FRM_PRODUCTS_UPDATE";
            this.Resizable = false;
            this.Text = "Products Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtfillprice;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtsellprice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtbuyprice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtfilling;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtID;
    }
}