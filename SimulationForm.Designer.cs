namespace DiffusionWinForms
{
    partial class SimulationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationForm));
            resetButton = new Button();
            showLabel = new Label();
            hScrollBar1 = new HScrollBar();
            timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // resetButton
            // 
            resetButton.BackColor = Color.Black;
            resetButton.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            resetButton.ForeColor = SystemColors.Control;
            resetButton.Location = new Point(344, 392);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(111, 46);
            resetButton.TabIndex = 0;
            resetButton.Text = "Сбросить";
            resetButton.UseVisualStyleBackColor = false;
            resetButton.Click += resetButton_Click;
            // 
            // showLabel
            // 
            showLabel.AutoSize = true;
            showLabel.BackColor = Color.FromArgb(255, 192, 128);
            showLabel.Image = (Image)resources.GetObject("showLabel.Image");
            showLabel.ImageAlign = ContentAlignment.MiddleLeft;
            showLabel.Location = new Point(12, 9);
            showLabel.Name = "showLabel";
            showLabel.Size = new Size(112, 15);
            showLabel.TabIndex = 1;
            showLabel.Text = "Скорость дифузии:";
            // 
            // hScrollBar1
            // 
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(141, 9);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(184, 17);
            hScrollBar1.TabIndex = 2;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // SimulationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(hScrollBar1);
            Controls.Add(showLabel);
            Controls.Add(resetButton);
            Name = "SimulationForm";
            Text = "Симуляция дифузии";
            Load += SimulationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button resetButton;
        private Label showLabel;
        private HScrollBar hScrollBar1;
        private System.Windows.Forms.Timer timer;
    }
}
