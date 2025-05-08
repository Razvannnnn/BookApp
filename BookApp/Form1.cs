using BookApp.Domain;
using BookApp.Observer;
using BookApp.Service;
using BookApp.Utils;

namespace BookApp;

public partial class Form1 : Form, IObserver
{
    private Service.Service _service;
    private Dictionary<string, long> _borrowerDict = new();
    private Dictionary<string, long> _bookDict = new();
    
    // Constructor
    public Form1(Service.Service service)
    {
        InitializeComponent();
        _service = service;
        _service.RegisterObserver(this);
        InitModel();
    }

    // InitModel initializes the model for the form
    private void InitModel()
    {
        InitDataGridView1();
        InitDataGridView2();
        LoadComboBoxes();
        comboBox1.Items.Add("Title");
        comboBox1.Items.Add("Author");
        comboBox1.SelectedIndex = 0;
        
        comboBoxBorrower.DropDownStyle = ComboBoxStyle.DropDown;
        comboBoxBorrower.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        comboBoxBorrower.AutoCompleteSource = AutoCompleteSource.ListItems;

    }

    // InitDataGridView1 initializes the first DataGridView with book data
    private async void InitDataGridView1()
    {
        dataGridView1.Columns.Clear();
        dataGridView1.Columns.Add("Title", "Title");
        dataGridView1.Columns.Add("Author", "Author");
        dataGridView1.Columns.Add("Available", "Available");
        dataGridView1.Columns.Add("Quantity", "Quantity");
        dataGridView1.Columns[0].DataPropertyName = "Title";
        dataGridView1.Columns[1].DataPropertyName = "Author";
        dataGridView1.Columns[2].DataPropertyName = "Available";
        dataGridView1.Columns[3].DataPropertyName = "Quantity";
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.Columns[0].Width = 550;
        dataGridView1.Columns[1].Width = 300;
        dataGridView1.Columns[2].Width = 100;
        dataGridView1.Columns[3].Width = 100;

        try
        {
            var books = _service.GetAllBooks().ToList();
            dataGridView1.DataSource = books;
        } catch (Exception ex)
        {
            MessageBox.Show("Error loading books: " + ex.Message);
        }
    }

    
    // InitDataGridView2 initializes the second DataGridView with borrow records
    private async void InitDataGridView2()
    {
        dataGridView2.Columns.Clear();
        dataGridView2.Columns.Add("Title", "Title");
        dataGridView2.Columns.Add("Author", "Author");
        dataGridView2.Columns.Add("Borrow Date", "Borrow Date");
        dataGridView2.Columns.Add("Return Date", "Return Date");
        dataGridView2.Columns[0].DataPropertyName = "TitleN";
        dataGridView2.Columns[1].DataPropertyName = "AuthorN";
        dataGridView2.Columns[2].DataPropertyName = "BorrowDate";
        dataGridView2.Columns[3].DataPropertyName = "ReturnDate";
        dataGridView2.AutoGenerateColumns = false;
        dataGridView2.Columns[0].Width = 400;
        dataGridView2.Columns[1].Width = 300;
        dataGridView2.Columns[2].Width = 175;
        dataGridView2.Columns[3].Width = 175;
        
        buttonReturn.Enabled = false;
        
        try
        {
            if(comboBoxBorrower == null || string.IsNullOrEmpty(comboBoxBorrower.Text))
            {
                return;
            }
            var borrowRecords = _service.GetAllBorrowRecordsForBorrower(_borrowerDict[comboBoxBorrower.Text]);
            dataGridView2.DataSource = borrowRecords;
        } catch (Exception ex)
        {
            MessageBox.Show("Error loading borrow records: " + ex.Message);
        }
    }

    // LoadComboBoxes loads the borrowers and books into the combo boxes
    private void LoadComboBoxes()
    {
        var borrowers = _service.GetAllBorrowers();
        var books = _service.GetAllBooks();

        comboBoxBorrower.Items.Clear();
        comboBoxBook.Items.Clear();
        _borrowerDict.Clear();
        _bookDict.Clear();

        foreach (var b in borrowers)
        {
            comboBoxBorrower.Items.Add(b.Name);
            _borrowerDict[b.Name] = b.Id;
        }
        foreach (var b in books)
        {
            comboBoxBook.Items.Add(b.Title);
            _bookDict[b.Title] = b.Id;
        }
    }
    
    // Event handler for the delete button
    private void buttonDelete_Click(object sender, EventArgs e)
    {
        var book = GetSelectedBook();
        if (book == null)
        {
            MessageBox.Show("No book selected.");
            return;
        }
        var result = MessageBox.Show("Are you sure you want to delete this book?", "Delete Book", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            _service.DeleteBook(book.Id);
        }
    }

    // Event handler for the DataGridView cell click
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            buttonDelete.Enabled = true;
        }
        else
        {
            buttonDelete.Enabled = false;
        }
        
    }
    
    // GetSelectedBook gets the selected book from the DataGridView
    private Book? GetSelectedBook()
    {
        if (dataGridView1.CurrentRow?.DataBoundItem is Book book)
            return book;
        return null;
    }

    // Event handler for the form closed event
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _service.RemoveObserver(this);
        base.OnFormClosed(e);
    }
    
    // Event handler for the update view event
    public void updateView()
    {
        InitModel();
    }

    // Event handler for the add book button
    private void buttonAddBook_Click(object sender, EventArgs e)
    {
        string author = textBoxAuthor.Text;
        string title = textBoxTitle.Text;
        string quantityText = textBoxQuantity.Text;
        
        if (string.IsNullOrEmpty(author) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(quantityText))
        {
            MessageBox.Show("Please fill in all fields.");
            return;
        }
        
        if (!long.TryParse(quantityText, out long quantity))
        {
            MessageBox.Show("Quantity must be a number.");
            return;
        }
        
        if (quantity < 0)
        {
            MessageBox.Show("Quantity cannot be negative.");
            return;
        }
        
        var book = new Book(0, title, author, quantity, quantity);
        
        try
        {
            _service.AddBook(book);
            textBoxAuthor.Clear();
            textBoxTitle.Clear();
            textBoxQuantity.Clear();
            MessageBox.Show("Book added successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error adding book: " + ex.Message);
        }
    }

    // Event handler for the filter button
    private void button1_Click(object sender, EventArgs e)
    {
        string filter = textBoxFilter.Text;
        if (string.IsNullOrEmpty(filter))
        {
            MessageBox.Show("Please enter a filter.");
            return;
        }
        string filterType = comboBox1.SelectedItem.ToString();
        if (filterType == "Author")
        {
            var books = _service.GetAllBooks().Where(b => b.Author.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            dataGridView1.DataSource = books;
        }
        else if (filterType == "Title")
        {
            var books = _service.GetAllBooks().Where(b => b.Title.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            dataGridView1.DataSource = books;
        }
        else
        {
            MessageBox.Show("Invalid filter type.");
        }
        textBoxFilter.Clear();
    }

    // Event handler for the show all books button
    private void button2_Click(object sender, EventArgs e)
    {
        dataGridView1.DataSource = _service.GetAllBooks().ToList();
    }

    // Event handler for the borrow button
    private void buttonBorrow_Click(object sender, EventArgs e)
    {
        Borrower borrower = _service.FindBorrower(_borrowerDict[comboBoxBorrower.Text]);
        if (borrower == null)
        {
            MessageBox.Show("Please select a borrower.");
            return;
        }
        Book book = _service.FindBook(_bookDict[comboBoxBook.Text]);
        if (book == null)
        {
            MessageBox.Show("Please select a book.");
            return;
        }
        BorrowRecord borrowRecord = new BorrowRecord(0, borrower.Id, book.Id, DateTime.Now, null);
        if (book.Available == 0)
        {
            MessageBox.Show("No available copies of this book.");
            return;
        }
        _service.AddBorrowRecord(borrowRecord);
        MessageBox.Show("Book borrowed successfully.");
    }

    // Event handler for the return button
    private void buttonReturn_Click(object sender, EventArgs e)
    {
        var selectedRow = dataGridView2.CurrentRow;
        if (selectedRow == null)
        {
            MessageBox.Show("No borrow record selected.");
            return;
        }

        dynamic borrowRecord = selectedRow.DataBoundItem;

        if (borrowRecord == null)
        {
            MessageBox.Show("No borrow record selected.");
            return;
        }

        var result = MessageBox.Show("Are you sure you want to return this book?", "Return Book", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            _service.ReturnBook(borrowRecord.IdBook, borrowRecord.IdBorrowRecord);
            MessageBox.Show("Book returned successfully.");
        }
    }
    
    // Event handler for the book combo box selection change
    private void comboBoxBorrower_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitDataGridView2();
    }

    // Event handler for the book combo box selection change
    private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            var selectedRow = dataGridView2.Rows[e.RowIndex];
            var returnDate = selectedRow.Cells["Return Date"].Value;

            if (returnDate == null)
            {
                buttonReturn.Enabled = true;
            }
            else
            {
                buttonReturn.Enabled = false;
            }
        }
        else
        {
            buttonReturn.Enabled = false;
        }
    }
    
    // Event handler for the add borrower button
    private void buttonBorrower_Click(object sender, EventArgs e)
    {
        var borrowerName = textBoxName.Text;
        var borrowerEmail = textBoxEmail.Text;
        EmailChecker emailChecker = new EmailChecker();
        if (emailChecker.IsValidEmail(borrowerEmail) == false)
        {
            MessageBox.Show("Invalid email address.");
            return;
        }
        if (string.IsNullOrEmpty(borrowerName) || string.IsNullOrEmpty(borrowerEmail))
        {
            MessageBox.Show("Please fill in all fields.");
            return;
        }
        var borrower = new Borrower(0, borrowerName, borrowerEmail);
        try
        {
            _service.AddBorrower(borrower);
            textBoxName.Clear();
            textBoxEmail.Clear();
            MessageBox.Show("Borrower added successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error adding borrower: " + ex.Message);
        }
    }
}