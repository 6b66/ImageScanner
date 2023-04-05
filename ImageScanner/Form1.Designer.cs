namespace ImageScanner
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            refBtn = new Button();
            label1 = new Label();
            refBox = new TextBox();
            panel2 = new Panel();
            useRegex_CheckBox = new CheckBox();
            caseSensitive_CheckBox = new CheckBox();
            searchBtn = new Button();
            searchBox = new TextBox();
            label2 = new Label();
            resultGrid = new DataGridView();
            imagePreview = new PictureBox();
            progressBar = new ProgressBar();
            statusLabel = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)resultGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imagePreview).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(refBtn);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(refBox);
            panel1.Name = "panel1";
            // 
            // refBtn
            // 
            resources.ApplyResources(refBtn, "refBtn");
            refBtn.Name = "refBtn";
            refBtn.UseVisualStyleBackColor = true;
            refBtn.Click += refBtn_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // refBox
            // 
            resources.ApplyResources(refBox, "refBox");
            refBox.Name = "refBox";
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.Controls.Add(useRegex_CheckBox);
            panel2.Controls.Add(caseSensitive_CheckBox);
            panel2.Controls.Add(searchBtn);
            panel2.Controls.Add(searchBox);
            panel2.Controls.Add(label2);
            panel2.Name = "panel2";
            // 
            // useRegex_CheckBox
            // 
            resources.ApplyResources(useRegex_CheckBox, "useRegex_CheckBox");
            useRegex_CheckBox.Name = "useRegex_CheckBox";
            useRegex_CheckBox.UseVisualStyleBackColor = true;
            // 
            // caseSensitive_CheckBox
            // 
            resources.ApplyResources(caseSensitive_CheckBox, "caseSensitive_CheckBox");
            caseSensitive_CheckBox.Name = "caseSensitive_CheckBox";
            caseSensitive_CheckBox.UseVisualStyleBackColor = true;
            // 
            // searchBtn
            // 
            resources.ApplyResources(searchBtn, "searchBtn");
            searchBtn.Name = "searchBtn";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // searchBox
            // 
            resources.ApplyResources(searchBox, "searchBox");
            searchBox.Name = "searchBox";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // resultGrid
            // 
            resources.ApplyResources(resultGrid, "resultGrid");
            resultGrid.AllowUserToAddRows = false;
            resultGrid.AllowUserToOrderColumns = true;
            resultGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultGrid.Name = "resultGrid";
            resultGrid.ReadOnly = true;
            resultGrid.RowTemplate.Height = 33;
            resultGrid.CellClick += resultGrid_CellClick;
            // 
            // imagePreview
            // 
            resources.ApplyResources(imagePreview, "imagePreview");
            imagePreview.Name = "imagePreview";
            imagePreview.TabStop = false;
            imagePreview.DoubleClick += imagePreview_Click;
            // 
            // progressBar
            // 
            resources.ApplyResources(progressBar, "progressBar");
            progressBar.Name = "progressBar";
            // 
            // statusLabel
            // 
            resources.ApplyResources(statusLabel, "statusLabel");
            statusLabel.Name = "statusLabel";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(statusLabel);
            Controls.Add(progressBar);
            Controls.Add(imagePreview);
            Controls.Add(resultGrid);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)resultGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)imagePreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox refBox;
        private Button refBtn;
        private Panel panel2;
        private CheckBox useRegex_CheckBox;
        private CheckBox caseSensitive_CheckBox;
        private Button searchBtn;
        private TextBox searchBox;
        private Label label2;
        private DataGridView resultGrid;
        private PictureBox imagePreview;
        private ProgressBar progressBar;
        private Label statusLabel;
    }
}