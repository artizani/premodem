
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Int
{
    public class ExpenseTransformer
    {

        public static void Transform()
        {
            var csv = new ReadCsv();
//            var st = csv.Read(csv.getFileFromResource("expense.csv"));
//            Console.WriteLine("olu"+System.Reflection.Assembly.GetExecutingAssembly().Location);
//            Console.WriteLine(Environment.CurrentDirectory);
//            Console.WriteLine("ooooooooo");
            using (var stream = typeof(ExpenseTransformer).GetTypeInfo().Assembly
                .GetManifestResourceStream("Premodem.Test.Int.data.expense.csv"))
                Console.WriteLine(stream.Length);
            var strFilePath = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, "data");
            var ll = Path.Combine(strFilePath, "expense.csv");
//            var file = csv.Read("/tmp/expense.csv").ToList();
//            using (var stream = Assembly.GetExecutingAssembly().GetFile()
////            {
////            //"xyz.project.Folder1.Folder2.SomeFile.Txt"))
////            
////                TextReader tr = new StreamReader(stream);
////                string fileContents = tr.ReadToEnd();
////            } 8AHYA7
//////            file.Where(exp =>
////            {
////                exp.
////            })

        }
       
    }
}