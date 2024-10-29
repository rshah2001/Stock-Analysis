// Name: Rishil Shah
// U-Number: U69116245


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    // Define an internal class named aCandlestick.
    internal class aCandlestick
    {
        // Define public properties for the candlestick values.
        public Decimal open { get; set; }
        public Decimal high { get; set; }
        public Decimal low { get; set; }
        public Decimal close { get; set; }
        public long volume { get; set; }
        public DateTime date { get; set; }

        // Default constructor.
        public aCandlestick() { }

        // Overloaded constructor that takes date, open, high, low, close, and volume values.
        public aCandlestick(DateTime date, decimal open = 0, decimal high = 0, decimal low = 0, decimal close = 0, long volume = 0)
        {
            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;
        }

        // Overloaded constructor that takes a string of data and parses it to populate the properties.
        public aCandlestick(String rowofData)
        {
            // Define comma as the separator for splitting the CSV string.
            char[] separators = new char[] { ',' };

            // Split the input string into substrings based on commas.
            string[] subs = rowofData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Temporary variables for parsing.
            Decimal temp;
            Boolean success;
            DateTime tempDate;

            // Parse the date from the first field and assign to the date property.
            success = DateTime.TryParse(subs[0].Trim('"'), out tempDate);
            date = tempDate;

            // Parse the open, high, low, and close values from subsequent fields.
            success = Decimal.TryParse(subs[1], out temp);
            open = temp;

            success = Decimal.TryParse(subs[2], out temp);
            high = temp;

            success = Decimal.TryParse(subs[3], out temp);
            low = temp;

            success = Decimal.TryParse(subs[4], out temp);
            close = temp;

            // Parse the volume from the last field.
            long tempVolume;
            success = long.TryParse(subs[5], out tempVolume);
            volume = tempVolume;
        }
    }
}
