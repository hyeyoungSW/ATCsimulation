namespace RadarATC
{
    partial class RadarATC
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layout_Direct = new System.Windows.Forms.Panel();
            this.label_direct = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_heading = new System.Windows.Forms.TextBox();
            this.label_heading = new System.Windows.Forms.Label();
            this.textBox_altitude = new System.Windows.Forms.TextBox();
            this.label_altitude = new System.Windows.Forms.Label();
            this.label_speed = new System.Windows.Forms.Label();
            this.textBox_speed = new System.Windows.Forms.TextBox();
            this.layout_list = new System.Windows.Forms.TableLayoutPanel();
            this.panel_list = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label_list = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.layout_Direct.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.layout_list.SuspendLayout();
            this.panel_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // layout_Direct
            // 
            this.layout_Direct.Controls.Add(this.label_direct);
            this.layout_Direct.Controls.Add(this.tableLayoutPanel1);
            this.layout_Direct.Location = new System.Drawing.Point(12, 12);
            this.layout_Direct.Name = "layout_Direct";
            this.layout_Direct.Size = new System.Drawing.Size(497, 188);
            this.layout_Direct.TabIndex = 0;
            // 
            // label_direct
            // 
            this.label_direct.AutoSize = true;
            this.label_direct.Font = new System.Drawing.Font("Leelawadee UI", 12F);
            this.label_direct.ForeColor = System.Drawing.Color.Lime;
            this.label_direct.Location = new System.Drawing.Point(3, 8);
            this.label_direct.Name = "label_direct";
            this.label_direct.Size = new System.Drawing.Size(161, 32);
            this.label_direct.TabIndex = 3;
            this.label_direct.Text = "Direct Aircraft";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.21978F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.78022F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_heading, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_heading, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_altitude, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_altitude, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_speed, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_speed, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 42);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(493, 144);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox_heading
            // 
            this.textBox_heading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_heading.BackColor = System.Drawing.Color.Black;
            this.textBox_heading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_heading.Font = new System.Drawing.Font("Leelawadee UI", 11F);
            this.textBox_heading.ForeColor = System.Drawing.Color.ForestGreen;
            this.textBox_heading.Location = new System.Drawing.Point(103, 85);
            this.textBox_heading.Name = "textBox_heading";
            this.textBox_heading.Size = new System.Drawing.Size(387, 37);
            this.textBox_heading.TabIndex = 0;
            this.textBox_heading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_heading
            // 
            this.label_heading.AutoSize = true;
            this.label_heading.Font = new System.Drawing.Font("Leelawadee UI", 10F);
            this.label_heading.ForeColor = System.Drawing.Color.White;
            this.label_heading.Location = new System.Drawing.Point(3, 82);
            this.label_heading.Name = "label_heading";
            this.label_heading.Size = new System.Drawing.Size(86, 28);
            this.label_heading.TabIndex = 0;
            this.label_heading.Text = "Heading";
            // 
            // textBox_altitude
            // 
            this.textBox_altitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_altitude.BackColor = System.Drawing.Color.Black;
            this.textBox_altitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_altitude.Font = new System.Drawing.Font("Leelawadee UI", 11F);
            this.textBox_altitude.ForeColor = System.Drawing.Color.ForestGreen;
            this.textBox_altitude.Location = new System.Drawing.Point(103, 3);
            this.textBox_altitude.Name = "textBox_altitude";
            this.textBox_altitude.Size = new System.Drawing.Size(387, 37);
            this.textBox_altitude.TabIndex = 2;
            this.textBox_altitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_altitude
            // 
            this.label_altitude.AutoSize = true;
            this.label_altitude.Font = new System.Drawing.Font("Leelawadee UI", 10F);
            this.label_altitude.ForeColor = System.Drawing.Color.White;
            this.label_altitude.Location = new System.Drawing.Point(3, 0);
            this.label_altitude.Name = "label_altitude";
            this.label_altitude.Size = new System.Drawing.Size(82, 28);
            this.label_altitude.TabIndex = 0;
            this.label_altitude.Text = "Altitude";
            // 
            // label_speed
            // 
            this.label_speed.AutoSize = true;
            this.label_speed.Font = new System.Drawing.Font("Leelawadee UI", 10F);
            this.label_speed.ForeColor = System.Drawing.Color.White;
            this.label_speed.Location = new System.Drawing.Point(3, 41);
            this.label_speed.Name = "label_speed";
            this.label_speed.Size = new System.Drawing.Size(67, 28);
            this.label_speed.TabIndex = 3;
            this.label_speed.Text = "Speed";
            // 
            // textBox_speed
            // 
            this.textBox_speed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_speed.BackColor = System.Drawing.Color.Black;
            this.textBox_speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_speed.Font = new System.Drawing.Font("Leelawadee UI", 11F);
            this.textBox_speed.ForeColor = System.Drawing.Color.ForestGreen;
            this.textBox_speed.Location = new System.Drawing.Point(103, 44);
            this.textBox_speed.Name = "textBox_speed";
            this.textBox_speed.Size = new System.Drawing.Size(387, 37);
            this.textBox_speed.TabIndex = 4;
            this.textBox_speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // layout_list
            // 
            this.layout_list.ColumnCount = 1;
            this.layout_list.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 497F));
            this.layout_list.Controls.Add(this.panel_list, 0, 1);
            this.layout_list.Controls.Add(this.label_list, 0, 0);
            this.layout_list.Location = new System.Drawing.Point(12, 206);
            this.layout_list.Name = "layout_list";
            this.layout_list.RowCount = 2;
            this.layout_list.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.layout_list.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout_list.Size = new System.Drawing.Size(497, 373);
            this.layout_list.TabIndex = 0;
            // 
            // panel_list
            // 
            this.panel_list.Controls.Add(this.label2);
            this.panel_list.Controls.Add(this.label1);
            this.panel_list.Controls.Add(this.listBox2);
            this.panel_list.Controls.Add(this.listBox1);
            this.panel_list.Location = new System.Drawing.Point(3, 45);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(487, 322);
            this.panel_list.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(250, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Arriving";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Departing";
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.SystemColors.WindowText;
            this.listBox2.DisplayMember = "AircraftID";
            this.listBox2.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.ForeColor = System.Drawing.Color.Lime;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 28;
            this.listBox2.Location = new System.Drawing.Point(255, 28);
            this.listBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(221, 284);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.ListBox2_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.listBox1.DisplayMember = "aircraftID";
            this.listBox1.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.Lime;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 28;
            this.listBox1.Location = new System.Drawing.Point(5, 28);
            this.listBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(221, 284);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // label_list
            // 
            this.label_list.AutoSize = true;
            this.label_list.BackColor = System.Drawing.Color.Transparent;
            this.label_list.Font = new System.Drawing.Font("Leelawadee UI", 12F);
            this.label_list.ForeColor = System.Drawing.Color.Lime;
            this.label_list.Location = new System.Drawing.Point(3, 0);
            this.label_list.Name = "label_list";
            this.label_list.Size = new System.Drawing.Size(133, 32);
            this.label_list.TabIndex = 3;
            this.label_list.Text = "Aircraft List";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RadarATC.Properties.Resources.satBG;
            this.pictureBox1.Location = new System.Drawing.Point(550, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 750);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.listBox3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(15, 588);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.40425F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(494, 195);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // listBox3
            // 
            this.listBox3.BackColor = System.Drawing.SystemColors.WindowText;
            this.listBox3.DisplayMember = "aircraftID";
            this.listBox3.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox3.ForeColor = System.Drawing.Color.Lime;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 28;
            this.listBox3.Location = new System.Drawing.Point(5, 53);
            this.listBox3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(484, 116);
            this.listBox3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Runway Queue";
            // 
            // RadarATC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1417, 872);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.layout_list);
            this.Controls.Add(this.layout_Direct);
            this.Name = "RadarATC";
            this.Text = "RadarATC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.layout_Direct.ResumeLayout(false);
            this.layout_Direct.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.layout_list.ResumeLayout(false);
            this.layout_list.PerformLayout();
            this.panel_list.ResumeLayout(false);
            this.panel_list.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel layout_Direct;
        private System.Windows.Forms.TableLayoutPanel layout_list;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_altitude;
        private System.Windows.Forms.TextBox textBox_heading;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label_direct;
        private System.Windows.Forms.Label label_list;
        private System.Windows.Forms.Label label_altitude;
        private System.Windows.Forms.Label label_heading;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_speed;
        private System.Windows.Forms.TextBox textBox_speed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label3;
    }
}

