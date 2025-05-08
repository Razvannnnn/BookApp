namespace BookApp;

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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tabControl1 = new System.Windows.Forms.TabControl();
        tabPage1 = new System.Windows.Forms.TabPage();
        comboBox1 = new System.Windows.Forms.ComboBox();
        button2 = new System.Windows.Forms.Button();
        button1 = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        textBoxFilter = new System.Windows.Forms.TextBox();
        buttonDelete = new System.Windows.Forms.Button();
        dataGridView1 = new System.Windows.Forms.DataGridView();
        tabPage2 = new System.Windows.Forms.TabPage();
        label2 = new System.Windows.Forms.Label();
        textBoxQuantity = new System.Windows.Forms.TextBox();
        label5 = new System.Windows.Forms.Label();
        textBoxTitle = new System.Windows.Forms.TextBox();
        label4 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        textBoxAuthor = new System.Windows.Forms.TextBox();
        buttonAddBook = new System.Windows.Forms.Button();
        tabPage3 = new System.Windows.Forms.TabPage();
        label8 = new System.Windows.Forms.Label();
        dataGridView2 = new System.Windows.Forms.DataGridView();
        comboBoxBook = new System.Windows.Forms.ComboBox();
        comboBoxBorrower = new System.Windows.Forms.ComboBox();
        buttonReturn = new System.Windows.Forms.Button();
        buttonBorrow = new System.Windows.Forms.Button();
        label7 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        tabPage4 = new System.Windows.Forms.TabPage();
        label11 = new System.Windows.Forms.Label();
        textBoxEmail = new System.Windows.Forms.TextBox();
        buttonBorrower = new System.Windows.Forms.Button();
        label10 = new System.Windows.Forms.Label();
        textBoxName = new System.Windows.Forms.TextBox();
        label9 = new System.Windows.Forms.Label();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        tabPage2.SuspendLayout();
        tabPage3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
        tabPage4.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Controls.Add(tabPage3);
        tabControl1.Controls.Add(tabPage4);
        tabControl1.Location = new System.Drawing.Point(-1, -2);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new System.Drawing.Size(1242, 837);
        tabControl1.TabIndex = 0;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(comboBox1);
        tabPage1.Controls.Add(button2);
        tabPage1.Controls.Add(button1);
        tabPage1.Controls.Add(label1);
        tabPage1.Controls.Add(textBoxFilter);
        tabPage1.Controls.Add(buttonDelete);
        tabPage1.Controls.Add(dataGridView1);
        tabPage1.Location = new System.Drawing.Point(4, 34);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new System.Windows.Forms.Padding(3);
        tabPage1.Size = new System.Drawing.Size(1234, 799);
        tabPage1.TabIndex = 1;
        tabPage1.Text = "Library";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(134, 44);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(138, 33);
        comboBox1.TabIndex = 10;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(1052, 47);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(136, 31);
        button2.TabIndex = 9;
        button2.Text = "Show All";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(596, 47);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(88, 31);
        button1.TabIndex = 8;
        button1.Text = "Search";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(37, 47);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(135, 31);
        label1.TabIndex = 5;
        label1.Text = "Search by:";
        // 
        // textBoxFilter
        // 
        textBoxFilter.Location = new System.Drawing.Point(278, 46);
        textBoxFilter.Name = "textBoxFilter";
        textBoxFilter.Size = new System.Drawing.Size(312, 31);
        textBoxFilter.TabIndex = 4;
        // 
        // buttonDelete
        // 
        buttonDelete.Location = new System.Drawing.Point(520, 732);
        buttonDelete.Name = "buttonDelete";
        buttonDelete.Size = new System.Drawing.Size(193, 33);
        buttonDelete.TabIndex = 1;
        buttonDelete.Text = "Delete Book";
        buttonDelete.UseVisualStyleBackColor = true;
        buttonDelete.Click += buttonDelete_Click;
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeight = 34;
        dataGridView1.Location = new System.Drawing.Point(37, 113);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 62;
        dataGridView1.Size = new System.Drawing.Size(1151, 584);
        dataGridView1.TabIndex = 0;
        dataGridView1.CellClick += dataGridView1_CellClick;
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(label2);
        tabPage2.Controls.Add(textBoxQuantity);
        tabPage2.Controls.Add(label5);
        tabPage2.Controls.Add(textBoxTitle);
        tabPage2.Controls.Add(label4);
        tabPage2.Controls.Add(label3);
        tabPage2.Controls.Add(textBoxAuthor);
        tabPage2.Controls.Add(buttonAddBook);
        tabPage2.Location = new System.Drawing.Point(4, 34);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new System.Windows.Forms.Padding(3);
        tabPage2.Size = new System.Drawing.Size(1234, 799);
        tabPage2.TabIndex = 0;
        tabPage2.Text = "Add book";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 22F);
        label2.Location = new System.Drawing.Point(327, 97);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(579, 77);
        label2.TabIndex = 17;
        label2.Text = "Add new book in the Library";
        // 
        // textBoxQuantity
        // 
        textBoxQuantity.Location = new System.Drawing.Point(495, 431);
        textBoxQuantity.Name = "textBoxQuantity";
        textBoxQuantity.Size = new System.Drawing.Size(313, 31);
        textBoxQuantity.TabIndex = 16;
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(405, 434);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(84, 30);
        label5.TabIndex = 15;
        label5.Text = "Quantity";
        // 
        // textBoxTitle
        // 
        textBoxTitle.Location = new System.Drawing.Point(495, 362);
        textBoxTitle.Name = "textBoxTitle";
        textBoxTitle.Size = new System.Drawing.Size(313, 31);
        textBoxTitle.TabIndex = 14;
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(417, 363);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(45, 30);
        label4.TabIndex = 13;
        label4.Text = "Title";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(405, 297);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(72, 30);
        label3.TabIndex = 12;
        label3.Text = "Author";
        // 
        // textBoxAuthor
        // 
        textBoxAuthor.Location = new System.Drawing.Point(495, 294);
        textBoxAuthor.Name = "textBoxAuthor";
        textBoxAuthor.Size = new System.Drawing.Size(313, 31);
        textBoxAuthor.TabIndex = 11;
        // 
        // buttonAddBook
        // 
        buttonAddBook.Location = new System.Drawing.Point(531, 600);
        buttonAddBook.Name = "buttonAddBook";
        buttonAddBook.Size = new System.Drawing.Size(150, 44);
        buttonAddBook.TabIndex = 10;
        buttonAddBook.Text = "Add book";
        buttonAddBook.UseVisualStyleBackColor = true;
        buttonAddBook.Click += buttonAddBook_Click;
        // 
        // tabPage3
        // 
        tabPage3.Controls.Add(label8);
        tabPage3.Controls.Add(dataGridView2);
        tabPage3.Controls.Add(comboBoxBook);
        tabPage3.Controls.Add(comboBoxBorrower);
        tabPage3.Controls.Add(buttonReturn);
        tabPage3.Controls.Add(buttonBorrow);
        tabPage3.Controls.Add(label7);
        tabPage3.Controls.Add(label6);
        tabPage3.Location = new System.Drawing.Point(4, 34);
        tabPage3.Name = "tabPage3";
        tabPage3.Padding = new System.Windows.Forms.Padding(3);
        tabPage3.Size = new System.Drawing.Size(1234, 799);
        tabPage3.TabIndex = 2;
        tabPage3.Text = "Borrow/Return";
        tabPage3.UseVisualStyleBackColor = true;
        // 
        // label8
        // 
        label8.Font = new System.Drawing.Font("Segoe UI", 15F);
        label8.Location = new System.Drawing.Point(504, 179);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(312, 40);
        label8.TabIndex = 9;
        label8.Text = "Books Borrowed";
        // 
        // dataGridView2
        // 
        dataGridView2.ColumnHeadersHeight = 34;
        dataGridView2.Location = new System.Drawing.Point(69, 234);
        dataGridView2.Name = "dataGridView2";
        dataGridView2.RowHeadersWidth = 62;
        dataGridView2.Size = new System.Drawing.Size(1106, 479);
        dataGridView2.TabIndex = 8;
        dataGridView2.CellClick += dataGridView2_CellClick;
        // 
        // comboBoxBook
        // 
        comboBoxBook.FormattingEnabled = true;
        comboBoxBook.Location = new System.Drawing.Point(401, 107);
        comboBoxBook.Name = "comboBoxBook";
        comboBoxBook.Size = new System.Drawing.Size(336, 33);
        comboBoxBook.TabIndex = 7;
        // 
        // comboBoxBorrower
        // 
        comboBoxBorrower.FormattingEnabled = true;
        comboBoxBorrower.Location = new System.Drawing.Point(401, 48);
        comboBoxBorrower.Name = "comboBoxBorrower";
        comboBoxBorrower.Size = new System.Drawing.Size(336, 33);
        comboBoxBorrower.TabIndex = 6;
        comboBoxBorrower.SelectedIndexChanged += comboBoxBorrower_SelectedIndexChanged;
        // 
        // buttonReturn
        // 
        buttonReturn.Location = new System.Drawing.Point(546, 732);
        buttonReturn.Name = "buttonReturn";
        buttonReturn.Size = new System.Drawing.Size(151, 41);
        buttonReturn.TabIndex = 3;
        buttonReturn.Text = "Return";
        buttonReturn.UseVisualStyleBackColor = true;
        buttonReturn.Click += buttonReturn_Click;
        // 
        // buttonBorrow
        // 
        buttonBorrow.Location = new System.Drawing.Point(820, 68);
        buttonBorrow.Name = "buttonBorrow";
        buttonBorrow.Size = new System.Drawing.Size(151, 41);
        buttonBorrow.TabIndex = 2;
        buttonBorrow.Text = "Borrow";
        buttonBorrow.UseVisualStyleBackColor = true;
        buttonBorrow.Click += buttonBorrow_Click;
        // 
        // label7
        // 
        label7.Location = new System.Drawing.Point(296, 107);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(56, 30);
        label7.TabIndex = 1;
        label7.Text = "Book";
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(282, 48);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(107, 30);
        label6.TabIndex = 0;
        label6.Text = "Borrower";
        // 
        // tabPage4
        // 
        tabPage4.Controls.Add(label11);
        tabPage4.Controls.Add(textBoxEmail);
        tabPage4.Controls.Add(buttonBorrower);
        tabPage4.Controls.Add(label10);
        tabPage4.Controls.Add(textBoxName);
        tabPage4.Controls.Add(label9);
        tabPage4.Location = new System.Drawing.Point(4, 34);
        tabPage4.Name = "tabPage4";
        tabPage4.Padding = new System.Windows.Forms.Padding(3);
        tabPage4.Size = new System.Drawing.Size(1234, 799);
        tabPage4.TabIndex = 3;
        tabPage4.Text = "Add Borrower";
        tabPage4.UseVisualStyleBackColor = true;
        // 
        // label11
        // 
        label11.Location = new System.Drawing.Point(430, 362);
        label11.Name = "label11";
        label11.Size = new System.Drawing.Size(72, 30);
        label11.TabIndex = 23;
        label11.Text = "Email";
        // 
        // textBoxEmail
        // 
        textBoxEmail.Location = new System.Drawing.Point(508, 359);
        textBoxEmail.Name = "textBoxEmail";
        textBoxEmail.Size = new System.Drawing.Size(313, 31);
        textBoxEmail.TabIndex = 22;
        // 
        // buttonBorrower
        // 
        buttonBorrower.Location = new System.Drawing.Point(554, 603);
        buttonBorrower.Name = "buttonBorrower";
        buttonBorrower.Size = new System.Drawing.Size(150, 44);
        buttonBorrower.TabIndex = 21;
        buttonBorrower.Text = "Add Borrower";
        buttonBorrower.UseVisualStyleBackColor = true;
        buttonBorrower.Click += buttonBorrower_Click;
        // 
        // label10
        // 
        label10.Location = new System.Drawing.Point(430, 288);
        label10.Name = "label10";
        label10.Size = new System.Drawing.Size(72, 30);
        label10.TabIndex = 20;
        label10.Text = "Name";
        // 
        // textBoxName
        // 
        textBoxName.Location = new System.Drawing.Point(508, 288);
        textBoxName.Name = "textBoxName";
        textBoxName.Size = new System.Drawing.Size(313, 31);
        textBoxName.TabIndex = 19;
        // 
        // label9
        // 
        label9.Font = new System.Drawing.Font("Segoe UI", 22F);
        label9.Location = new System.Drawing.Point(417, 98);
        label9.Name = "label9";
        label9.Size = new System.Drawing.Size(579, 77);
        label9.TabIndex = 18;
        label9.Text = "Add a new Borrower";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1240, 836);
        Controls.Add(tabControl1);
        Text = "Form1";
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        tabPage2.ResumeLayout(false);
        tabPage2.PerformLayout();
        tabPage3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
        tabPage4.ResumeLayout(false);
        tabPage4.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button buttonBorrower;
    private System.Windows.Forms.TextBox textBoxEmail;
    private System.Windows.Forms.Label label11;

    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Label label10;

    private System.Windows.Forms.Label label9;

    private System.Windows.Forms.TabPage tabPage4;

    private System.Windows.Forms.DataGridView dataGridView2;
    private System.Windows.Forms.Label label8;

    private System.Windows.Forms.ComboBox comboBoxBook;

    private System.Windows.Forms.ComboBox comboBoxBorrower;

    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.ComboBox comboBox1;

    private System.Windows.Forms.TextBox textBoxTitle;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBoxQuantity;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.TextBox textBoxAuthor;
    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Button buttonAddBook;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.TextBox textBoxFilter;

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button buttonDelete;
    private System.Windows.Forms.Button buttonBorrow;
    private System.Windows.Forms.Button buttonReturn;

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;

    #endregion
}