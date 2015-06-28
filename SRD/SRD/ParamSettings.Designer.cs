namespace SRD
{
    partial class ParamSettings
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
            this.paramsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.paramsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // paramsDataGridView
            // 
            this.paramsDataGridView.AllowUserToAddRows = false;
            this.paramsDataGridView.AllowUserToDeleteRows = false;
            this.paramsDataGridView.AllowUserToOrderColumns = true;
            this.paramsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paramsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paramsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.paramsDataGridView.Name = "paramsDataGridView";
            this.paramsDataGridView.ReadOnly = true;
            this.paramsDataGridView.Size = new System.Drawing.Size(623, 278);
            this.paramsDataGridView.TabIndex = 0;
            // 
            // ParamSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 278);
            this.Controls.Add(this.paramsDataGridView);
            this.Name = "ParamSettings";
            this.Text = "ParamSettings";
            ((System.ComponentModel.ISupportInitialize)(this.paramsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView paramsDataGridView;
    }
}