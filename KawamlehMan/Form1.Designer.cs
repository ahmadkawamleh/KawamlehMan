namespace KawamlehMan
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
            txt_URL = new TextBox();
            label1 = new Label();
            ActionGroup = new GroupBox();
            rb_DELETE = new RadioButton();
            rb_PUT = new RadioButton();
            rb_POST = new RadioButton();
            rb_GET = new RadioButton();
            requestBody = new TextBox();
            dgv_header = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            dgv_Params = new DataGridView();
            btn_testAPI = new Button();
            treeView1 = new TreeView();
            pictureBox1 = new PictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            ActionGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_header).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Params).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // txt_URL
            // 
            txt_URL.Location = new Point(70, 9);
            txt_URL.Name = "txt_URL";
            txt_URL.Size = new Size(1000, 31);
            txt_URL.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(52, 25);
            label1.TabIndex = 1;
            label1.Text = "URL: ";
            // 
            // ActionGroup
            // 
            ActionGroup.Controls.Add(rb_DELETE);
            ActionGroup.Controls.Add(rb_PUT);
            ActionGroup.Controls.Add(rb_POST);
            ActionGroup.Controls.Add(rb_GET);
            ActionGroup.Location = new Point(12, 58);
            ActionGroup.Name = "ActionGroup";
            ActionGroup.Size = new Size(1058, 150);
            ActionGroup.TabIndex = 2;
            ActionGroup.TabStop = false;
            ActionGroup.Text = "groupBox1";
            // 
            // rb_DELETE
            // 
            rb_DELETE.AutoSize = true;
            rb_DELETE.Location = new Point(447, 30);
            rb_DELETE.Name = "rb_DELETE";
            rb_DELETE.Size = new Size(94, 29);
            rb_DELETE.TabIndex = 3;
            rb_DELETE.TabStop = true;
            rb_DELETE.Text = "DELETE";
            rb_DELETE.UseVisualStyleBackColor = true;
            // 
            // rb_PUT
            // 
            rb_PUT.AutoSize = true;
            rb_PUT.Location = new Point(300, 30);
            rb_PUT.Name = "rb_PUT";
            rb_PUT.Size = new Size(68, 29);
            rb_PUT.TabIndex = 2;
            rb_PUT.TabStop = true;
            rb_PUT.Text = "PUT";
            rb_PUT.UseVisualStyleBackColor = true;
            // 
            // rb_POST
            // 
            rb_POST.AutoSize = true;
            rb_POST.Location = new Point(153, 30);
            rb_POST.Name = "rb_POST";
            rb_POST.Size = new Size(80, 29);
            rb_POST.TabIndex = 1;
            rb_POST.TabStop = true;
            rb_POST.Text = "POST";
            rb_POST.UseVisualStyleBackColor = true;
            // 
            // rb_GET
            // 
            rb_GET.AutoSize = true;
            rb_GET.Location = new Point(6, 30);
            rb_GET.Name = "rb_GET";
            rb_GET.Size = new Size(67, 29);
            rb_GET.TabIndex = 0;
            rb_GET.TabStop = true;
            rb_GET.Text = "GET";
            rb_GET.UseVisualStyleBackColor = true;
            // 
            // requestBody
            // 
            requestBody.Location = new Point(12, 214);
            requestBody.Multiline = true;
            requestBody.Name = "requestBody";
            requestBody.Size = new Size(1058, 46);
            requestBody.TabIndex = 3;
            requestBody.Visible = false;
            // 
            // dgv_header
            // 
            dgv_header.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_header.Location = new Point(18, 343);
            dgv_header.Name = "dgv_header";
            dgv_header.RowHeadersWidth = 62;
            dgv_header.Size = new Size(1052, 175);
            dgv_header.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 306);
            label2.Name = "label2";
            label2.Size = new Size(77, 25);
            label2.TabIndex = 5;
            label2.Text = "Headers";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 568);
            label3.Name = "label3";
            label3.Size = new Size(69, 25);
            label3.TabIndex = 6;
            label3.Text = "Params";
            // 
            // dgv_Params
            // 
            dgv_Params.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Params.Location = new Point(18, 606);
            dgv_Params.Name = "dgv_Params";
            dgv_Params.RowHeadersWidth = 62;
            dgv_Params.Size = new Size(1052, 225);
            dgv_Params.TabIndex = 7;
            // 
            // btn_testAPI
            // 
            btn_testAPI.Location = new Point(18, 855);
            btn_testAPI.Name = "btn_testAPI";
            btn_testAPI.Size = new Size(112, 34);
            btn_testAPI.TabIndex = 8;
            btn_testAPI.Text = "Test API";
            btn_testAPI.UseVisualStyleBackColor = true;
            btn_testAPI.Click += btn_testAPI_Click;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(18, 895);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(1052, 255);
            treeView1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(18, 1156);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1052, 185);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(18, 1347);
            webView21.Name = "webView21";
            webView21.Size = new Size(1052, 211);
            webView21.TabIndex = 11;
            webView21.ZoomFactor = 1D;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.Location = new Point(1076, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(200, 154);
            tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(192, 116);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(192, 116);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(1303, 1410);
            Controls.Add(tabControl1);
            Controls.Add(webView21);
            Controls.Add(pictureBox1);
            Controls.Add(treeView1);
            Controls.Add(btn_testAPI);
            Controls.Add(dgv_Params);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgv_header);
            Controls.Add(requestBody);
            Controls.Add(ActionGroup);
            Controls.Add(label1);
            Controls.Add(txt_URL);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ActionGroup.ResumeLayout(false);
            ActionGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_header).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Params).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_URL;
        private Label label1;
        private GroupBox ActionGroup;
        private RadioButton rb_DELETE;
        private RadioButton rb_PUT;
        private RadioButton rb_POST;
        private RadioButton rb_GET;
        private TextBox requestBody;
        private DataGridView dgv_header;
        private Label label2;
        private Label label3;
        private DataGridView dgv_Params;
        private Button btn_testAPI;
        private TreeView treeView1;
        private PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}