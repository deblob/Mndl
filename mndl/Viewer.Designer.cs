namespace mndl
{
    partial class Viewer
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
            this.numScale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numXOffset = new System.Windows.Forms.NumericUpDown();
            this.numYOffset = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numPreviewHeight = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numPreviewWidth = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numRenderWidth = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numRenderHeight = new System.Windows.Forms.NumericUpDown();
            this.btnRender = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.barProgress = new System.Windows.Forms.ProgressBar();
            this.pbViewNew = new mndl.Controls.ctrlPictureBox();
            this.clrEndNew = new mndl.Controls.ctrlColorSelector();
            this.clrStartNew = new mndl.Controls.ctrlColorSelector();
            this.cbCuda = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numXOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreviewHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreviewWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRenderWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRenderHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewNew)).BeginInit();
            this.SuspendLayout();
            // 
            // numScale
            // 
            this.numScale.DecimalPlaces = 10;
            this.numScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numScale.Location = new System.Drawing.Point(97, 608);
            this.numScale.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numScale.Name = "numScale";
            this.numScale.Size = new System.Drawing.Size(92, 20);
            this.numScale.TabIndex = 1;
            this.numScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 611);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scale:";
            // 
            // numXOffset
            // 
            this.numXOffset.DecimalPlaces = 10;
            this.numXOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numXOffset.Location = new System.Drawing.Point(97, 634);
            this.numXOffset.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numXOffset.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.numXOffset.Name = "numXOffset";
            this.numXOffset.Size = new System.Drawing.Size(92, 20);
            this.numXOffset.TabIndex = 3;
            // 
            // numYOffset
            // 
            this.numYOffset.DecimalPlaces = 10;
            this.numYOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numYOffset.Location = new System.Drawing.Point(97, 660);
            this.numYOffset.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numYOffset.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.numYOffset.Name = "numYOffset";
            this.numYOffset.Size = new System.Drawing.Size(92, 20);
            this.numYOffset.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 636);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X offset:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 662);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y offset:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 637);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "End color:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 611);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Start color:";
            // 
            // numPreviewHeight
            // 
            this.numPreviewHeight.Location = new System.Drawing.Point(532, 608);
            this.numPreviewHeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPreviewHeight.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numPreviewHeight.Name = "numPreviewHeight";
            this.numPreviewHeight.Size = new System.Drawing.Size(60, 20);
            this.numPreviewHeight.TabIndex = 11;
            this.numPreviewHeight.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(514, 611);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "X";
            // 
            // numPreviewWidth
            // 
            this.numPreviewWidth.Location = new System.Drawing.Point(449, 608);
            this.numPreviewWidth.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPreviewWidth.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numPreviewWidth.Name = "numPreviewWidth";
            this.numPreviewWidth.Size = new System.Drawing.Size(60, 20);
            this.numPreviewWidth.TabIndex = 13;
            this.numPreviewWidth.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(347, 611);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Preview resolution:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(350, 636);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Render resolution:";
            // 
            // numRenderWidth
            // 
            this.numRenderWidth.Location = new System.Drawing.Point(449, 634);
            this.numRenderWidth.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numRenderWidth.Minimum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numRenderWidth.Name = "numRenderWidth";
            this.numRenderWidth.Size = new System.Drawing.Size(60, 20);
            this.numRenderWidth.TabIndex = 17;
            this.numRenderWidth.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(514, 637);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "X";
            // 
            // numRenderHeight
            // 
            this.numRenderHeight.Location = new System.Drawing.Point(532, 634);
            this.numRenderHeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numRenderHeight.Minimum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numRenderHeight.Name = "numRenderHeight";
            this.numRenderHeight.Size = new System.Drawing.Size(60, 20);
            this.numRenderHeight.TabIndex = 15;
            this.numRenderHeight.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(517, 662);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(75, 23);
            this.btnRender.TabIndex = 19;
            this.btnRender.Text = "Render...";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(434, 662);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 20;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // numIterations
            // 
            this.numIterations.Location = new System.Drawing.Point(263, 660);
            this.numIterations.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numIterations.Name = "numIterations";
            this.numIterations.Size = new System.Drawing.Size(50, 20);
            this.numIterations.TabIndex = 21;
            this.numIterations.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(204, 663);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Iterations:";
            // 
            // barProgress
            // 
            this.barProgress.Location = new System.Drawing.Point(12, 691);
            this.barProgress.Name = "barProgress";
            this.barProgress.Size = new System.Drawing.Size(580, 23);
            this.barProgress.TabIndex = 23;
            // 
            // pbViewNew
            // 
            this.pbViewNew.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbViewNew.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pbViewNew.Location = new System.Drawing.Point(2, 2);
            this.pbViewNew.Name = "pbViewNew";
            this.pbViewNew.Size = new System.Drawing.Size(600, 600);
            this.pbViewNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbViewNew.TabIndex = 26;
            this.pbViewNew.TabStop = false;
            this.pbViewNew.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbViewNew_MouseClick);
            // 
            // clrEndNew
            // 
            this.clrEndNew.BackColor = System.Drawing.Color.Black;
            this.clrEndNew.Location = new System.Drawing.Point(263, 634);
            this.clrEndNew.Name = "clrEndNew";
            this.clrEndNew.SelectedColor = System.Drawing.Color.Black;
            this.clrEndNew.Size = new System.Drawing.Size(50, 20);
            this.clrEndNew.TabIndex = 25;
            // 
            // clrStartNew
            // 
            this.clrStartNew.BackColor = System.Drawing.Color.HotPink;
            this.clrStartNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clrStartNew.Location = new System.Drawing.Point(263, 608);
            this.clrStartNew.Name = "clrStartNew";
            this.clrStartNew.SelectedColor = System.Drawing.Color.HotPink;
            this.clrStartNew.Size = new System.Drawing.Size(50, 20);
            this.clrStartNew.TabIndex = 24;
            // 
            // cbCuda
            // 
            this.cbCuda.AutoSize = true;
            this.cbCuda.Location = new System.Drawing.Point(12, 720);
            this.cbCuda.Name = "cbCuda";
            this.cbCuda.Size = new System.Drawing.Size(133, 17);
            this.cbCuda.TabIndex = 27;
            this.cbCuda.Text = "OpenCL (experimental)";
            this.cbCuda.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(497, 723);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Dedicated to Amy";
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 741);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbCuda);
            this.Controls.Add(this.pbViewNew);
            this.Controls.Add(this.clrEndNew);
            this.Controls.Add(this.clrStartNew);
            this.Controls.Add(this.barProgress);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numIterations);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numRenderWidth);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numRenderHeight);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numPreviewWidth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numPreviewHeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numYOffset);
            this.Controls.Add(this.numXOffset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numScale);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Viewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Mandelbrot Viewer by Marc D.";
            ((System.ComponentModel.ISupportInitialize)(this.numScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numXOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreviewHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreviewWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRenderWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRenderHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewNew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numXOffset;
        private System.Windows.Forms.NumericUpDown numYOffset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numPreviewHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numPreviewWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numRenderWidth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numRenderHeight;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar barProgress;
        private Controls.ctrlColorSelector clrStartNew;
        private Controls.ctrlColorSelector clrEndNew;
        private Controls.ctrlPictureBox pbViewNew;
        private System.Windows.Forms.CheckBox cbCuda;
        private System.Windows.Forms.Label label11;
    }
}