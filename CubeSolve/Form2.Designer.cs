namespace CubeSolve
{
    partial class Cube
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
            this.btnRight = new System.Windows.Forms.Button();
            this.btnRightBack = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnLeftBack = new System.Windows.Forms.Button();
            this.btnFront = new System.Windows.Forms.Button();
            this.btnFrontBack = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnUpBack = new System.Windows.Forms.Button();
            this.txtMatrix = new System.Windows.Forms.TextBox();
            this.btnUpTrans = new System.Windows.Forms.Button();
            this.btnDownTrans = new System.Windows.Forms.Button();
            this.btnRightTrans = new System.Windows.Forms.Button();
            this.btnLeftTrans = new System.Windows.Forms.Button();
            this.btnDownBack = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(695, 91);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(35, 31);
            this.btnRight.TabIndex = 0;
            this.btnRight.Text = "R";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnRightBack
            // 
            this.btnRightBack.Location = new System.Drawing.Point(695, 128);
            this.btnRightBack.Name = "btnRightBack";
            this.btnRightBack.Size = new System.Drawing.Size(35, 31);
            this.btnRightBack.TabIndex = 1;
            this.btnRightBack.Text = "RB";
            this.btnRightBack.UseVisualStyleBackColor = true;
            this.btnRightBack.Click += new System.EventHandler(this.btnRightBack_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(613, 91);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(35, 31);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "L";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnLeftBack
            // 
            this.btnLeftBack.Location = new System.Drawing.Point(613, 128);
            this.btnLeftBack.Name = "btnLeftBack";
            this.btnLeftBack.Size = new System.Drawing.Size(35, 31);
            this.btnLeftBack.TabIndex = 3;
            this.btnLeftBack.Text = "LB";
            this.btnLeftBack.UseVisualStyleBackColor = true;
            this.btnLeftBack.Click += new System.EventHandler(this.btnLeftBack_Click);
            // 
            // btnFront
            // 
            this.btnFront.Location = new System.Drawing.Point(654, 91);
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(35, 31);
            this.btnFront.TabIndex = 4;
            this.btnFront.Text = "F";
            this.btnFront.UseVisualStyleBackColor = true;
            this.btnFront.Click += new System.EventHandler(this.btnFront_Click);
            // 
            // btnFrontBack
            // 
            this.btnFrontBack.Location = new System.Drawing.Point(654, 128);
            this.btnFrontBack.Name = "btnFrontBack";
            this.btnFrontBack.Size = new System.Drawing.Size(35, 31);
            this.btnFrontBack.TabIndex = 5;
            this.btnFrontBack.Text = "FB";
            this.btnFrontBack.UseVisualStyleBackColor = true;
            this.btnFrontBack.Click += new System.EventHandler(this.btnFrontBack_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(654, 17);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(35, 31);
            this.btnUp.TabIndex = 6;
            this.btnUp.Text = "U";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnUpBack
            // 
            this.btnUpBack.Location = new System.Drawing.Point(654, 54);
            this.btnUpBack.Name = "btnUpBack";
            this.btnUpBack.Size = new System.Drawing.Size(35, 31);
            this.btnUpBack.TabIndex = 7;
            this.btnUpBack.Text = "UB";
            this.btnUpBack.UseVisualStyleBackColor = true;
            this.btnUpBack.Click += new System.EventHandler(this.btnUpBack_Click);
            // 
            // txtMatrix
            // 
            this.txtMatrix.AcceptsReturn = true;
            this.txtMatrix.Location = new System.Drawing.Point(399, 294);
            this.txtMatrix.Multiline = true;
            this.txtMatrix.Name = "txtMatrix";
            this.txtMatrix.Size = new System.Drawing.Size(165, 167);
            this.txtMatrix.TabIndex = 16;
            // 
            // btnUpTrans
            // 
            this.btnUpTrans.Location = new System.Drawing.Point(639, 334);
            this.btnUpTrans.Name = "btnUpTrans";
            this.btnUpTrans.Size = new System.Drawing.Size(50, 31);
            this.btnUpTrans.TabIndex = 17;
            this.btnUpTrans.Text = "UP";
            this.btnUpTrans.UseVisualStyleBackColor = true;
            this.btnUpTrans.Click += new System.EventHandler(this.btnUpTrans_Click);
            // 
            // btnDownTrans
            // 
            this.btnDownTrans.Location = new System.Drawing.Point(639, 371);
            this.btnDownTrans.Name = "btnDownTrans";
            this.btnDownTrans.Size = new System.Drawing.Size(50, 31);
            this.btnDownTrans.TabIndex = 18;
            this.btnDownTrans.Text = "DOWN";
            this.btnDownTrans.UseVisualStyleBackColor = true;
            this.btnDownTrans.Click += new System.EventHandler(this.btnDownTrans_Click);
            // 
            // btnRightTrans
            // 
            this.btnRightTrans.Location = new System.Drawing.Point(695, 353);
            this.btnRightTrans.Name = "btnRightTrans";
            this.btnRightTrans.Size = new System.Drawing.Size(50, 31);
            this.btnRightTrans.TabIndex = 19;
            this.btnRightTrans.Text = "RIGHT";
            this.btnRightTrans.UseVisualStyleBackColor = true;
            this.btnRightTrans.Click += new System.EventHandler(this.btnRightTrans_Click);
            // 
            // btnLeftTrans
            // 
            this.btnLeftTrans.Location = new System.Drawing.Point(583, 353);
            this.btnLeftTrans.Name = "btnLeftTrans";
            this.btnLeftTrans.Size = new System.Drawing.Size(50, 31);
            this.btnLeftTrans.TabIndex = 20;
            this.btnLeftTrans.Text = "LEFT";
            this.btnLeftTrans.UseVisualStyleBackColor = true;
            this.btnLeftTrans.Click += new System.EventHandler(this.btnLeftTrans_Click);
            // 
            // btnDownBack
            // 
            this.btnDownBack.Location = new System.Drawing.Point(654, 202);
            this.btnDownBack.Name = "btnDownBack";
            this.btnDownBack.Size = new System.Drawing.Size(35, 31);
            this.btnDownBack.TabIndex = 9;
            this.btnDownBack.Text = "DB";
            this.btnDownBack.UseVisualStyleBackColor = true;
            this.btnDownBack.Click += new System.EventHandler(this.btnDownBack_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(654, 165);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(35, 31);
            this.btnDown.TabIndex = 8;
            this.btnDown.Text = "D";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(19, 426);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(79, 23);
            this.btnSolve.TabIndex = 21;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(104, 426);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(70, 23);
            this.btnPrev.TabIndex = 22;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(180, 426);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(66, 23);
            this.btnNext.TabIndex = 23;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Cube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 462);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.btnLeftTrans);
            this.Controls.Add(this.btnRightTrans);
            this.Controls.Add(this.btnDownTrans);
            this.Controls.Add(this.btnUpTrans);
            this.Controls.Add(this.txtMatrix);
            this.Controls.Add(this.btnDownBack);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUpBack);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnFrontBack);
            this.Controls.Add(this.btnFront);
            this.Controls.Add(this.btnLeftBack);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRightBack);
            this.Controls.Add(this.btnRight);
            this.Name = "Cube";
            this.Text = "Cube";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnRightBack;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnLeftBack;
        private System.Windows.Forms.Button btnFront;
        private System.Windows.Forms.Button btnFrontBack;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnUpBack;
        private System.Windows.Forms.TextBox txtMatrix;
        private System.Windows.Forms.Button btnUpTrans;
        private System.Windows.Forms.Button btnDownTrans;
        private System.Windows.Forms.Button btnRightTrans;
        private System.Windows.Forms.Button btnLeftTrans;
        private System.Windows.Forms.Button btnDownBack;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;

    }
}