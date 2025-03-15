namespace RadioPlayer
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cbCountries = new ComboBox();
            lbStations = new ListBox();
            btnPlay = new Button();
            label1 = new Label();
            label2 = new Label();
            btnStop = new Button();
            cbVolumeSlider = new NAudio.Gui.VolumeSlider();
            label3 = new Label();
            pbLogo = new PictureBox();
            lbTitle = new Label();
            lblNoLogo = new Label();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // cbCountries
            // 
            cbCountries.BackColor = Color.FromArgb(45, 45, 48);
            cbCountries.DisplayMember = "Name";
            cbCountries.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCountries.ForeColor = Color.White;
            cbCountries.FormattingEnabled = true;
            cbCountries.Location = new Point(8, 70);
            cbCountries.Name = "cbCountries";
            cbCountries.Size = new Size(420, 28);
            cbCountries.TabIndex = 0;
            cbCountries.SelectedIndexChanged += cbCountries_SelectedIndexChanged;
            // 
            // lbStations
            // 
            lbStations.BackColor = Color.FromArgb(45, 45, 48);
            lbStations.BorderStyle = BorderStyle.FixedSingle;
            lbStations.DisplayMember = "Name";
            lbStations.ForeColor = Color.White;
            lbStations.FormattingEnabled = true;
            lbStations.Location = new Point(4, 124);
            lbStations.Name = "lbStations";
            lbStations.Size = new Size(424, 142);
            lbStations.TabIndex = 1;
            lbStations.SelectedIndexChanged += lbStations_SelectedIndexChanged;
            lbStations.DoubleClick += lbStations_DoubleClick;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.FromArgb(100, 100, 255);
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.ForeColor = Color.White;
            btnPlay.Location = new Point(77, 333);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(133, 41);
            btnPlay.TabIndex = 4;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(6, 43);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 5;
            label1.Text = "Countries";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(4, 101);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 6;
            label2.Text = "Stations";
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(192, 64, 0);
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(233, 333);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(133, 41);
            btnStop.TabIndex = 7;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // cbVolumeSlider
            // 
            cbVolumeSlider.Location = new Point(12, 302);
            cbVolumeSlider.Name = "cbVolumeSlider";
            cbVolumeSlider.Size = new Size(416, 25);
            cbVolumeSlider.TabIndex = 8;
            cbVolumeSlider.VolumeChanged += cbVolumeSlider_VolumeChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(8, 273);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 9;
            label3.Text = "Volume";
            // 
            // pbLogo
            // 
            pbLogo.Location = new Point(133, 3);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(150, 44);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 10;
            pbLogo.TabStop = false;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbTitle.Location = new Point(10, 399);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(131, 28);
            lbTitle.TabIndex = 11;
            lbTitle.Text = "Radio Player";
            // 
            // lblNoLogo
            // 
            lblNoLogo.AutoSize = true;
            lblNoLogo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNoLogo.ForeColor = SystemColors.ActiveCaptionText;
            lblNoLogo.Location = new Point(164, 15);
            lblNoLogo.Name = "lblNoLogo";
            lblNoLogo.Size = new Size(77, 20);
            lblNoLogo.TabIndex = 12;
            lblNoLogo.Text = "NO LOGO";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(448, 440);
            Controls.Add(lblNoLogo);
            Controls.Add(lbTitle);
            Controls.Add(pbLogo);
            Controls.Add(label3);
            Controls.Add(cbVolumeSlider);
            Controls.Add(btnStop);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnPlay);
            Controls.Add(lbStations);
            Controls.Add(cbCountries);
            ForeColor = SystemColors.ActiveCaption;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cbCountries;
        private ListBox lbStations;
        private Button btnPlay;
        private Label label1;
        private Label label2;
        private Button btnStop;
        private NAudio.Gui.VolumeSlider cbVolumeSlider;
        private Label label3;
        private PictureBox pbLogo;
        private Label lbTitle;
        private Label lblNoLogo;
    }
}
