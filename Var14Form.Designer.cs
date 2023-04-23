using System.Drawing;
using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GalyaForm));
            this.gridPopulation = new System.Windows.Forms.DataGridView();
            this.btnShowGrid = new System.Windows.Forms.Button();
            this.chartPopulation1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPopulation1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPopulation
            // 
            this.gridPopulation.AllowUserToAddRows = false;
            this.gridPopulation.AllowUserToDeleteRows = false;
            this.gridPopulation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridPopulation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridPopulation.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridPopulation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPopulation.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPopulation.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridPopulation.Location = new System.Drawing.Point(236, 490);
            this.gridPopulation.Name = "gridPopulation";
            this.gridPopulation.RowHeadersVisible = false;
            this.gridPopulation.Size = new System.Drawing.Size(1336, 360);
            this.gridPopulation.TabIndex = 16;
            // 
            // btnShowGrid
            // 
            this.btnShowGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(184)))));
            this.btnShowGrid.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnShowGrid.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(127)))), ((int)(((byte)(198)))));
            this.btnShowGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(111)))), ((int)(((byte)(192)))));
            this.btnShowGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowGrid.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowGrid.ForeColor = System.Drawing.Color.White;
            this.btnShowGrid.Location = new System.Drawing.Point(12, 790);
            this.btnShowGrid.Margin = new System.Windows.Forms.Padding(12, 14, 12, 14);
            this.btnShowGrid.Name = "btnShowGrid";
            this.btnShowGrid.Size = new System.Drawing.Size(200, 48);
            this.btnShowGrid.TabIndex = 19;
            this.btnShowGrid.Text = "Select file";
            this.btnShowGrid.UseVisualStyleBackColor = false;
            this.btnShowGrid.Click += new System.EventHandler(this.btnShowGrid_Click);
            // 
            // chartPopulation1
            // 
            this.chartPopulation1.BorderlineColor = System.Drawing.SystemColors.WindowText;
            this.chartPopulation1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Maximum = 2023D;
            chartArea1.AxisX.Minimum = 2007D;
            chartArea1.AxisX.Title = "Year";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LineColor = System.Drawing.Color.Empty;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Maximum = 14000000D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Population";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chartPopulation1.ChartAreas.Add(chartArea1);
            legend1.BorderColor = System.Drawing.Color.Gray;
            legend1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartPopulation1.Legends.Add(legend1);
            this.chartPopulation1.Location = new System.Drawing.Point(12, 12);
            this.chartPopulation1.Name = "chartPopulation1";
            this.chartPopulation1.Size = new System.Drawing.Size(1560, 472);
            this.chartPopulation1.TabIndex = 21;
            this.chartPopulation1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 756);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Select file to see stats";
            // 
            // GalyaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartPopulation1);
            this.Controls.Add(this.btnShowGrid);
            this.Controls.Add(this.gridPopulation);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GalyaForm";
            this.Text = "Population Data";
            this.Load += new System.EventHandler(this.Var14Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPopulation1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView gridPopulation;
        private System.Windows.Forms.Button btnShowGrid;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPopulation1;
        private System.Windows.Forms.Label label1;
    }
}

