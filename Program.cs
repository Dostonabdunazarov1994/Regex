using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("../../input.txt");
            string reg = File.ReadAllText("../../regex.txt");
            Regex regex = new Regex(reg);
            var output = new StringBuilder(EscapeCsvValue("Номер") + ";" + EscapeCsvValue("Группа1") +";"+ EscapeCsvValue("Группа2")
                + ";"+ EscapeCsvValue("Группа3") +";"+ EscapeCsvValue("Группа4"));
            output.AppendLine();
            int id = 1;
            foreach (Match m in regex.Matches(input))
            {
                output.Append(EscapeCsvValue($"Строка {id++}") + ";");
                output.AppendLine($"{EscapeCsvValue(m.Groups[1].Value.Replace("\t", "\\t"))};" +
                    $"{EscapeCsvValue(m.Groups[2].Value.Replace("\t", "\\t"))};" +
                    $"{EscapeCsvValue(m.Groups[3].Value.Replace("\t", "\\t"))};" +
                    $"{EscapeCsvValue(m.Groups[4].Value.Replace("\t", "\\t"))}");
            }
            Console.WriteLine(output);
            File.WriteAllText("../../output.csv", output.ToString(), Encoding.Default);
        }
        static string EscapeCsvValue(string s) => "\"" + s.Replace("\"", "\"\"") + "\"";
    }
}
