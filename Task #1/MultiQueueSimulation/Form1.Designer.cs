namespace MultiQueueSimulation
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FileName = new System.Windows.Forms.Label();
            this.show_graphs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.avg_wating_time = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.max_queue_length = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.customer_probability = new System.Windows.Forms.Label();
            this.customer_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomInterArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomServiceDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeServiceBegins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeServiceEnds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(94, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 57);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.show_graphs);
            this.panel1.Controls.Add(this.FileName);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 653);
            this.panel1.TabIndex = 1;
            // 
            // FileName
            // 
            this.FileName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FileName.AutoSize = true;
            this.FileName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.FileName.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FileName.Location = new System.Drawing.Point(51, 116);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(219, 23);
            this.FileName.TabIndex = 2;
            this.FileName.Text = "7amasa.txt file was added";
            // 
            // show_graphs
            // 
            this.show_graphs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.show_graphs.Location = new System.Drawing.Point(55, 186);
            this.show_graphs.Name = "show_graphs";
            this.show_graphs.Size = new System.Drawing.Size(215, 57);
            this.show_graphs.TabIndex = 3;
            this.show_graphs.Text = "show graphs";
            this.show_graphs.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(352, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Simulation Table :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customer_number,
            this.randomInterArrivalTime,
            this.interArrivalTime,
            this.arrivalTime,
            this.randomServiceDuration,
            this.serviceDuration,
            this.serverIndex,
            this.timeServiceBegins,
            this.timeServiceEnds,
            this.totalDelay});
            this.dataGridView1.Location = new System.Drawing.Point(357, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1030, 323);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(352, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Performance for the system :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(353, 466);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Average waiting time (in the queue) = ";
            // 
            // avg_wating_time
            // 
            this.avg_wating_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.avg_wating_time.AutoSize = true;
            this.avg_wating_time.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avg_wating_time.Location = new System.Drawing.Point(664, 466);
            this.avg_wating_time.Name = "avg_wating_time";
            this.avg_wating_time.Size = new System.Drawing.Size(76, 23);
            this.avg_wating_time.TabIndex = 6;
            this.avg_wating_time.Text = "98.15654";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(353, 512);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Maximum queue length = ";
            // 
            // max_queue_length
            // 
            this.max_queue_length.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.max_queue_length.AutoSize = true;
            this.max_queue_length.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max_queue_length.Location = new System.Drawing.Point(574, 512);
            this.max_queue_length.Name = "max_queue_length";
            this.max_queue_length.Size = new System.Drawing.Size(76, 23);
            this.max_queue_length.TabIndex = 8;
            this.max_queue_length.Text = "98.15654";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(353, 557);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(377, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "Probability that a customer wait in the queue = ";
            // 
            // customer_probability
            // 
            this.customer_probability.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.customer_probability.AutoSize = true;
            this.customer_probability.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_probability.Location = new System.Drawing.Point(736, 557);
            this.customer_probability.Name = "customer_probability";
            this.customer_probability.Size = new System.Drawing.Size(76, 23);
            this.customer_probability.TabIndex = 10;
            this.customer_probability.Text = "98.15654";
            // 
            // customer_number
            // 
            this.customer_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.customer_number.HeaderText = "Customer No";
            this.customer_number.MinimumWidth = 6;
            this.customer_number.Name = "customer_number";
            // 
            // randomInterArrivalTime
            // 
            this.randomInterArrivalTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.randomInterArrivalTime.HeaderText = "Random_Ai";
            this.randomInterArrivalTime.MinimumWidth = 6;
            this.randomInterArrivalTime.Name = "randomInterArrivalTime";
            // 
            // interArrivalTime
            // 
            this.interArrivalTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.interArrivalTime.HeaderText = "Ai";
            this.interArrivalTime.MinimumWidth = 6;
            this.interArrivalTime.Name = "interArrivalTime";
            // 
            // arrivalTime
            // 
            this.arrivalTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.arrivalTime.HeaderText = "Ti";
            this.arrivalTime.MinimumWidth = 6;
            this.arrivalTime.Name = "arrivalTime";
            // 
            // randomServiceDuration
            // 
            this.randomServiceDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.randomServiceDuration.HeaderText = "Random_Si";
            this.randomServiceDuration.MinimumWidth = 6;
            this.randomServiceDuration.Name = "randomServiceDuration";
            // 
            // serviceDuration
            // 
            this.serviceDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.serviceDuration.HeaderText = "Si";
            this.serviceDuration.MinimumWidth = 6;
            this.serviceDuration.Name = "serviceDuration";
            // 
            // serverIndex
            // 
            this.serverIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.serverIndex.HeaderText = "Server index";
            this.serverIndex.MinimumWidth = 6;
            this.serverIndex.Name = "serverIndex";
            // 
            // timeServiceBegins
            // 
            this.timeServiceBegins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeServiceBegins.HeaderText = "Service Begin";
            this.timeServiceBegins.MinimumWidth = 6;
            this.timeServiceBegins.Name = "timeServiceBegins";
            // 
            // timeServiceEnds
            // 
            this.timeServiceEnds.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeServiceEnds.HeaderText = "Service End";
            this.timeServiceEnds.MinimumWidth = 6;
            this.timeServiceEnds.Name = "timeServiceEnds";
            // 
            // totalDelay
            // 
            this.totalDelay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.totalDelay.HeaderText = "Total delay";
            this.totalDelay.MinimumWidth = 6;
            this.totalDelay.Name = "totalDelay";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1399, 653);
            this.Controls.Add(this.customer_probability);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.max_queue_length);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.avg_wating_time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button show_graphs;
        private System.Windows.Forms.Label FileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label avg_wating_time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label max_queue_length;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label customer_probability;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomInterArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn interArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomServiceDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeServiceBegins;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeServiceEnds;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDelay;
    }
}

