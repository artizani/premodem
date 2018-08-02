using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Xunit;

namespace Int
{
    public class ReadCsv
    {
        [Fact]
        public void ReadTest()
        {
            var view =  Read("expense.csv");
            List<ExpenseSheet> result = new List<ExpenseSheet>();

            foreach (var expense in view)
            {
                expense.ExpenseDate = DateTime.ParseExact(expense.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                expense.ExpenseAmount = decimal.Parse(string.Format("{0:N}", expense.Amount), System.Globalization.NumberStyles.Currency);
                result.Add(expense);
            }
        }

        
        public IEnumerable<ExpenseSheet>  Read(string path)
        {

            List<ExpenseSheet> result = new List<ExpenseSheet>();
            using (TextReader fileReader = File.OpenText(path))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = true;
                return csv.GetRecords<ExpenseSheet>().ToList();
            }

        }
        
        public string getFileFromResource(String fileName)
        {
            String strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            String strFilePath = Path.Combine(strAppPath, "data");
            return Path.Combine(strFilePath, fileName);
        }
        
        
        [Fact]
        public void check()
        {
            ExpenseTransformer.Transform();
            var tets = " ";

        }
    }
}