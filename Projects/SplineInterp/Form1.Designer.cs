namespace SplineInterp
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
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eZDataGridViewXY = new eZstd.eZDataGridView();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eZDataGridViewID = new eZstd.eZDataGridView();
            this.ColumnI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eZDataGridViewXY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eZDataGridViewID)).BeginInit();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 42);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.eZDataGridViewXY);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.eZDataGridViewID);
            this.splitContainer1.Size = new System.Drawing.Size(760, 397);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(697, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 457);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(665, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "jsut use Ctrl + C and Ctrl + V to paste the data from InterpY column to the Excel" +
    ". Make sure the Excel is not in the selection mode.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(567, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter the source X , source Y and refined X, and then click Calculate.";
            // 
            // eZDataGridViewXY
            // 
            this.eZDataGridViewXY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eZDataGridViewXY.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnX,
            this.ColumnY});
            this.eZDataGridViewXY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eZDataGridViewXY.KeyDelete = false;
            this.eZDataGridViewXY.Location = new System.Drawing.Point(0, 0);
            this.eZDataGridViewXY.ManipulateRows = false;
            this.eZDataGridViewXY.Name = "eZDataGridViewXY";
            this.eZDataGridViewXY.RowHeadersWidth = 60;
            this.eZDataGridViewXY.RowTemplate.Height = 23;
            this.eZDataGridViewXY.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.eZDataGridViewXY.ShowRowNumber = false;
            this.eZDataGridViewXY.Size = new System.Drawing.Size(380, 397);
            this.eZDataGridViewXY.SupportPaste = false;
            this.eZDataGridViewXY.TabIndex = 0;
            this.eZDataGridViewXY.TabStop = false;
            this.eZDataGridViewXY.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.eZDataGridViewXY_DataError);
            // 
            // ColumnX
            // 
            this.ColumnX.HeaderText = "Source X";
            this.ColumnX.Name = "ColumnX";
            // 
            // ColumnY
            // 
            this.ColumnY.HeaderText = "Source Y";
            this.ColumnY.Name = "ColumnY";
            // 
            // eZDataGridViewID
            // 
            this.eZDataGridViewID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eZDataGridViewID.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnI,
            this.ColumnD});
            this.eZDataGridViewID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eZDataGridViewID.KeyDelete = false;
            this.eZDataGridViewID.Location = new System.Drawing.Point(0, 0);
            this.eZDataGridViewID.ManipulateRows = false;
            this.eZDataGridViewID.Name = "eZDataGridViewID";
            this.eZDataGridViewID.RowHeadersWidth = 60;
            this.eZDataGridViewID.RowTemplate.Height = 23;
            this.eZDataGridViewID.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.eZDataGridViewID.ShowRowNumber = false;
            this.eZDataGridViewID.Size = new System.Drawing.Size(376, 397);
            this.eZDataGridViewID.SupportPaste = false;
            this.eZDataGridViewID.TabIndex = 0;
            this.eZDataGridViewID.TabStop = false;
            this.eZDataGridViewID.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.eZDataGridViewID_DataError);
            // 
            // ColumnI
            // 
            this.ColumnI.HeaderText = "Refined X";
            this.ColumnI.Name = "ColumnI";
            // 
            // ColumnD
            // 
            this.ColumnD.HeaderText = "Interp Y";
            this.ColumnD.Name = "ColumnD";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 501);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(800, 540);
            this.Name = "Form1";
            this.Text = "SplineInterp";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eZDataGridViewXY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eZDataGridViewID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private eZstd.eZDataGridView eZDataGridViewXY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnY;
        private eZstd.eZDataGridView eZDataGridViewID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

