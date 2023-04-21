namespace LabWork3
{
    partial class GalyaForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GalyaForm));
            this.gridPopulation = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnShowGrid = new System.Windows.Forms.Button();
            this.chartPopulation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.gridPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPopulation)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPopulation
            // 
            this.gridPopulation.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridPopulation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPopulation.ColumnHeadersVisible = false;
            this.gridPopulation.Location = new System.Drawing.Point(12, 12);
            this.gridPopulation.Name = "gridPopulation";
            this.gridPopulation.RowHeadersVisible = false;
            this.gridPopulation.Size = new System.Drawing.Size(303, 461);
            this.gridPopulation.TabIndex = 16;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnShowGrid
            // 
            this.btnShowGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(184)))));
            this.btnShowGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnShowGrid.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnShowGrid.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(127)))), ((int)(((byte)(198)))));
            this.btnShowGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.btnShowGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowGrid.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowGrid.ForeColor = System.Drawing.Color.White;
            this.btnShowGrid.Location = new System.Drawing.Point(21, 490);
            this.btnShowGrid.Margin = new System.Windows.Forms.Padding(12, 14, 12, 14);
            this.btnShowGrid.Name = "btnShowGrid";
            this.btnShowGrid.Size = new System.Drawing.Size(200, 48);
            this.btnShowGrid.TabIndex = 19;
            this.btnShowGrid.Text = "Show Population Stats";
            this.btnShowGrid.UseVisualStyleBackColor = false;
            this.btnShowGrid.Click += new System.EventHandler(this.btnShowGrid_Click);
            // 
            // chartPopulation
            // 
            this.chartPopulation.BackColor = System.Drawing.Color.Silver;
            this.chartPopulation.BorderlineColor = System.Drawing.Color.DimGray;
            chartArea1.Name = "ChartArea1";
            this.chartPopulation.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPopulation.Legends.Add(legend1);
            this.chartPopulation.Location = new System.Drawing.Point(367, 12);
            this.chartPopulation.Name = "chartPopulation";
            this.chartPopulation.Size = new System.Drawing.Size(1205, 461);
            this.chartPopulation.TabIndex = 20;
            this.chartPopulation.Text = " ";
            // 
            // GalyaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.chartPopulation);
            this.Controls.Add(this.btnShowGrid);
            this.Controls.Add(this.gridPopulation);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GalyaForm";
            this.Text = "Population";
            this.Load += new System.EventHandler(this.Var14Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPopulation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gridPopulation;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnShowGrid;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPopulation;
    }
}