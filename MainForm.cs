namespace WinFormsApp;

public partial class MainForm : Form
{
    TextBox textBox;
    bool error;

    public MainForm()
    {
        string fontFamilyName = "Arial";

        Text = "Calculator";
        ClientSize = new Size(800, 1000);

        textBox = new TextBox();
        textBox.ReadOnly = true;
        textBox.Font = new Font(fontFamilyName, 18, FontStyle.Regular, GraphicsUnit.Point);
        textBox.TextAlign = HorizontalAlignment.Right;
        textBox.Dock = DockStyle.Top;

        TableLayoutPanel tableLayoutPanel = new();
        tableLayoutPanel.RowCount = 5;
        tableLayoutPanel.ColumnCount = 4;
        tableLayoutPanel.Dock = DockStyle.Fill;

        for (int i = 0; i < tableLayoutPanel.RowCount; i++)
        {
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
        }

        for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
        {
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
        }

        Controls.Add(tableLayoutPanel);
        Controls.Add(textBox);

        string[] buttonList =
        [
            " ", " ", "C", "/",
            "7", "8", "9", "*",
            "4", "5", "6", "+",
            "1", "2", "3", "-",
            " ", "0", ".", "="
        ];

        int index = 0;

        for (int row = 0; row < tableLayoutPanel.RowCount; row++)
        {
            for (int column = 0; column < tableLayoutPanel.ColumnCount; column++)
            {
                Button button = new();
                button.Text = buttonList[index];
                button.Dock = DockStyle.Fill;
                button.Font = new Font(fontFamilyName, 14, FontStyle.Regular, GraphicsUnit.Point);
                tableLayoutPanel.Controls.Add(button, column, row);

                if (button.Text != " ")
                {
                    button.Click += ClickAction;
                }

                index++;
            }
        }
    }

    void ClickAction(object? sender, EventArgs e)
    {
        if (sender is not Button button)
        {
            return;
        }

        if (error)
        {
            textBox.Text = "";
            error = false;
        }

        if (button.Text == "C")
        {
            textBox.Text = "";
        }
        else if (button.Text == "=")
        {
            try
            {
                double result = Compute(textBox.Text);
                textBox.Text = result.ToString();
            }
            catch (Exception exception)
            {
                textBox.Text += " " + exception.Message;
                error = true;
            }
        }
        else
        {
            textBox.Text += button.Text;
        }
    }

    double Compute(string expression)
    {
        DataTable dataTable = new();
        object value = dataTable.Compute(expression, "");
        return Convert.ToDouble(value);
    }
}
