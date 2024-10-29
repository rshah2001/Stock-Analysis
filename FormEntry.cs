// Name: Rishil Shah
// U-Number: U69116245

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Namespace for the project 1.
namespace Project_1
{
    // Form class for entering candlestick data.
    public partial class FormEntry : Form
    {
        // List bound to UI components for candlestick data.
        private BindingList<aCandlestick> candlestickList { get; set; }

        // Temporary list for storing candlestick data.
        private List<aCandlestick> tempList;

        // Constructor that initializes the form components.
        public FormEntry()
        {
            InitializeComponent();
        }

        // Event handler for the "Load Stock Data" button click.
        private void button_LoadStockData_Click(object sender, EventArgs e)
        {
            // Show the open file dialog and proceed if a file is selected.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Updated reference string without "Ticker" and "Period" fields.
                String referenceString = "\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";

                // Get the selected file's path.
                String filename = openFileDialog1.FileName;

                // Retrieve all selected file paths in case of multi-file selection.
                string[] filenames = openFileDialog1.FileNames; //for multiselecting files

                // Open the selected file for reading.
                using (StreamReader sr = new StreamReader(filename))
                {
                    // Initialize the candlestickList and bind it to the data grid.
                    candlestickList = new BindingList<aCandlestick>();
                    dataGridView_Stock.DataSource = candlestickList;

                    string line;

                    // Read the first line from the file, which should be the header.
                    string header = sr.ReadLine();

                    // Check if the file's header matches the expected format.
                    if (header == referenceString)
                    {
                        // Initialize tempList with an estimated initial capacity.
                        tempList = new List<aCandlestick>(1024);

                        // Read and parse each line from the file.
                        while ((line = sr.ReadLine()) != null)
                        {
                            aCandlestick cs = new aCandlestick(line);
                            tempList.Add(cs);
                        }

                        // Filter data from tempList based on the selected date range and add to candlestickList.
                        for (int i = tempList.Count - 1; i >= 0; i--)
                        {
                            aCandlestick cs = tempList[i];
                            if (cs.date > dateTimePicker_EndDate.Value)
                                break;
                            if (cs.date >= dateTimePicker_StartDate.Value)
                            {
                                candlestickList.Add(cs);
                            }
                        }
                    }
                }
            }

            // Clear any existing titles from the chart and set a new title based on the file's name.
            chart1.Titles.Clear();
            chart1.Titles.Add(Path.GetFileNameWithoutExtension(openFileDialog1.FileName));

            // Bind the updated candlestickList to the chart and refresh the chart to reflect the new data.
            chart1.DataSource = candlestickList;
            chart1.DataBind();
        }

        // Event handler for the "Update" button click.
        private void button_Update_Click(object sender, EventArgs e)
        {
            // Check if the candlestickList has been initialized.
            if (candlestickList != null)
            {
                // Clear any existing data in the candlestickList.
                candlestickList.Clear();

                // Iterate through tempList in reverse order.
                for (int i = tempList.Count - 1; i >= 0; i--)
                {
                    aCandlestick cs = tempList[i];
                    if (cs.date > dateTimePicker_EndDate.Value)
                        break;
                    if (cs.date >= dateTimePicker_StartDate.Value)
                    {
                        candlestickList.Add(cs);
                    }
                }

                // Bind the updated candlestickList to the data grid view and chart controls.
                dataGridView_Stock.DataSource = candlestickList;
                chart1.DataSource = candlestickList;

                // Refresh the chart to reflect the updated data.
                chart1.DataBind();
            }
        }

        // Event handler for when a file is selected in the open file dialog.
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // No implementation needed here if no additional file selection logic is required.
        }

        // Event handler for when the start date is changed.
        private void dateTimePicker_startDate_ValueChanged(object sender, EventArgs e)
        {
            // No implementation needed here if no additional logic on date change is required.
        }

        // Event handler for when the stock chart is clicked.
        private void chart_stock_Click(object sender, EventArgs e)
        {
            // No implementation needed here if no click event logic is required for the chart.
            // No implementation needed here if no click event logic is required for the chart.
        }

        // Event handler for cell content click on the data grid.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // No implementation needed here if no additional logic on cell click is required.
        }

        // Event handler for when the end date is changed.
        private void dateTimePicker_endDate_ValueChanged(object sender, EventArgs e)
        {
            // No implementation needed here if no additional logic on date change is required.
        }

        // Background work process event handler.
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // No implementation needed here if no background processing logic is required.
        }
    }
}
