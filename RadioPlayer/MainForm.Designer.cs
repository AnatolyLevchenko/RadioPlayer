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
            SuspendLayout();
            // 
            // cbCountries
            // 
            cbCountries.BackColor = Color.FromArgb(45, 45, 48);
            cbCountries.DisplayMember = "Name";
            cbCountries.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCountries.ForeColor = Color.White;
            cbCountries.FormattingEnabled = true;
            cbCountries.Location = new Point(12, 32);
            cbCountries.Name = "cbCountries";
            cbCountries.Size = new Size(476, 28);
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
            lbStations.Location = new Point(12, 86);
            lbStations.Name = "lbStations";
            lbStations.Size = new Size(476, 142);
            lbStations.TabIndex = 1;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.FromArgb(100, 100, 255);
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.ForeColor = Color.White;
            btnPlay.Location = new Point(12, 300);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(172, 41);
            btnPlay.TabIndex = 4;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 5;
            label1.Text = "Countries";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(12, 63);
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
            btnStop.Location = new Point(212, 300);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(172, 41);
            btnStop.TabIndex = 7;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // cbVolumeSlider
            // 
            cbVolumeSlider.Location = new Point(12, 263);
            cbVolumeSlider.Name = "cbVolumeSlider";
            cbVolumeSlider.Size = new Size(476, 20);
            cbVolumeSlider.TabIndex = 8;
            cbVolumeSlider.VolumeChanged += cbVolumeSlider_VolumeChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 240);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 9;
            label3.Text = "Volume";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(513, 395);
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
            Text = "Radio Player";
            Load += MainForm_Load;
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
    }
}
