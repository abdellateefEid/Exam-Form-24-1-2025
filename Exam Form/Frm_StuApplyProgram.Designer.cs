namespace Exam_Form
{
    partial class Frm_StuApplyProgram
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
            btn_applyPro = new Button();
            SuspendLayout();
            // 
            // btn_applyPro
            // 
            btn_applyPro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_applyPro.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_applyPro.ForeColor = Color.Red;
            btn_applyPro.Location = new Point(237, 195);
            btn_applyPro.Name = "btn_applyPro";
            btn_applyPro.Size = new Size(360, 45);
            btn_applyPro.TabIndex = 0;
            btn_applyPro.Text = "Apply your program";
            btn_applyPro.UseVisualStyleBackColor = true;
            // 
            // Frm_StuApplyProgram
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 451);
            Controls.Add(btn_applyPro);
            Name = "Frm_StuApplyProgram";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Erm_StuApplyProgram";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_applyPro;
    }
}