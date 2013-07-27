namespace CRM
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.btnEditCust = new System.Windows.Forms.Button();
            this.btnRemCust = new System.Windows.Forms.Button();
            this.btnAddCust = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHlp = new System.Windows.Forms.Button();
            this.pBarMood = new CRM.NewProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditCust
            // 
            this.btnEditCust.Location = new System.Drawing.Point(93, 332);
            this.btnEditCust.Name = "btnEditCust";
            this.btnEditCust.Size = new System.Drawing.Size(75, 23);
            this.btnEditCust.TabIndex = 0;
            this.btnEditCust.Text = "Edit";
            this.btnEditCust.UseVisualStyleBackColor = true;
            this.btnEditCust.Click += new System.EventHandler(this.btnEditCust_Click);
            // 
            // btnRemCust
            // 
            this.btnRemCust.Location = new System.Drawing.Point(174, 332);
            this.btnRemCust.Name = "btnRemCust";
            this.btnRemCust.Size = new System.Drawing.Size(75, 23);
            this.btnRemCust.TabIndex = 0;
            this.btnRemCust.Text = "Remove";
            this.btnRemCust.UseVisualStyleBackColor = true;
            this.btnRemCust.Click += new System.EventHandler(this.btnRemCust_Click);
            // 
            // btnAddCust
            // 
            this.btnAddCust.Location = new System.Drawing.Point(12, 332);
            this.btnAddCust.Name = "btnAddCust";
            this.btnAddCust.Size = new System.Drawing.Size(75, 23);
            this.btnAddCust.TabIndex = 0;
            this.btnAddCust.Text = "Add";
            this.btnAddCust.UseVisualStyleBackColor = true;
            this.btnAddCust.Click += new System.EventHandler(this.btnAddCust_Click);
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(13, 13);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(690, 268);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(492, 332);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(573, 332);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(343, 287);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnHlp
            // 
            this.btnHlp.Location = new System.Drawing.Point(654, 332);
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(49, 23);
            this.btnHlp.TabIndex = 5;
            this.btnHlp.Text = "Help";
            this.btnHlp.UseVisualStyleBackColor = true;
            this.btnHlp.Click += new System.EventHandler(this.btnHlp_Click);
            // 
            // pBarMood
            // 
            this.pBarMood.Location = new System.Drawing.Point(255, 332);
            this.pBarMood.Maximum = 200;
            this.pBarMood.Name = "pBarMood";
            this.pBarMood.Size = new System.Drawing.Size(231, 23);
            this.pBarMood.Step = 200;
            this.pBarMood.TabIndex = 4;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 358);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pBarMood);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnAddCust);
            this.Controls.Add(this.btnRemCust);
            this.Controls.Add(this.btnEditCust);
            this.Name = "MainView";
            this.Text = "5";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEditCust;
        private System.Windows.Forms.Button btnRemCust;
        private System.Windows.Forms.Button btnAddCust;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.PictureBox pictureBox1;
        private NewProgressBar pBarMood;
        private System.Windows.Forms.Button btnHlp;



    }
}

