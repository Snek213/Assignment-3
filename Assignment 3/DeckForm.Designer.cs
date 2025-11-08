namespace Assignment_3
{
    partial class DeckForm
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
            lblCards = new Label();
            lstDeckBox = new ListBox();
            imgPictureBox = new PictureBox();
            btnUp = new Button();
            btnDown = new Button();
            ((System.ComponentModel.ISupportInitialize)imgPictureBox).BeginInit();
            SuspendLayout();
            // 
            // lblCards
            // 
            lblCards.AutoSize = true;
            lblCards.Location = new Point(132, 62);
            lblCards.Name = "lblCards";
            lblCards.Size = new Size(46, 20);
            lblCards.TabIndex = 0;
            lblCards.Text = "&Cards";
            // 
            // lstDeckBox
            // 
            lstDeckBox.FormattingEnabled = true;
            lstDeckBox.Location = new Point(132, 85);
            lstDeckBox.Name = "lstDeckBox";
            lstDeckBox.Size = new Size(253, 264);
            lstDeckBox.TabIndex = 1;
            lstDeckBox.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // imgPictureBox
            // 
            imgPictureBox.Location = new Point(514, 85);
            imgPictureBox.Name = "imgPictureBox";
            imgPictureBox.Size = new Size(215, 264);
            imgPictureBox.TabIndex = 2;
            imgPictureBox.TabStop = false;
            // 
            // btnUp
            // 
            btnUp.Location = new Point(403, 85);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(94, 29);
            btnUp.TabIndex = 3;
            btnUp.Text = "&Up";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.Location = new Point(403, 320);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(94, 29);
            btnDown.TabIndex = 4;
            btnDown.Text = "&Down";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // DeckForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDown);
            Controls.Add(btnUp);
            Controls.Add(imgPictureBox);
            Controls.Add(lstDeckBox);
            Controls.Add(lblCards);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DeckForm";
            Text = "Deck Form";
            Load += DeckForm_Load;
            ((System.ComponentModel.ISupportInitialize)imgPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCards;
        private ListBox lstDeckBox;
        private PictureBox imgPictureBox;
        private Button btnUp;
        private Button btnDown;
    }
}