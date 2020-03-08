namespace ProgramingSolutionOI1
{
    partial class AddMachine
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
            this.TxtMachineName = new System.Windows.Forms.TextBox();
            this.BtnAddMachine = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Upiši naziv stroja";
            // 
            // TxtMachineName
            // 
            this.TxtMachineName.Location = new System.Drawing.Point(16, 48);
            this.TxtMachineName.Name = "TxtMachineName";
            this.TxtMachineName.Size = new System.Drawing.Size(236, 22);
            this.TxtMachineName.TabIndex = 1;
            this.TxtMachineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMachineName_KeyDown);
            // 
            // BtnAddMachine
            // 
            this.BtnAddMachine.Location = new System.Drawing.Point(177, 102);
            this.BtnAddMachine.Name = "BtnAddMachine";
            this.BtnAddMachine.Size = new System.Drawing.Size(75, 23);
            this.BtnAddMachine.TabIndex = 2;
            this.BtnAddMachine.Text = "Dodaj";
            this.BtnAddMachine.UseVisualStyleBackColor = true;
            this.BtnAddMachine.Click += new System.EventHandler(this.BtnAddMachine_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(16, 102);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 3;
            this.BtnClose.Text = "Izađi";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // AddMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 137);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnAddMachine);
            this.Controls.Add(this.TxtMachineName);
            this.Controls.Add(this.label1);
            this.Name = "AddMachine";
            this.Text = "DodajStroj";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtMachineName;
        private System.Windows.Forms.Button BtnAddMachine;
        private System.Windows.Forms.Button BtnClose;
    }
}