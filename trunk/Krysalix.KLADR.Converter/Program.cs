using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Krysalix.KLADR.Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.Write("Usage: {0} DbfFilename outfilename level format СС РРР ГГГ ППП\n\n", Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location));
                Console.Write("{0} DbfFilename outfilename level format\n\n", Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location));

                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location), "c:\\KLADR.DBF", "out.xml", "1", "\"<NODE NAME=\\\"{0}\\\" SS=\\\"{8}\\\" RRR=\\\"{9}\\\" GGG=\\\"{10}\\\" PPP=\\\"{11}\\\" AA=\\\"{12}\\\" />\"", "36", "011", "000", "028");
                Console.WriteLine("");
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location), "c:\\STREET.DBF", "out.xml", "5", "\"<NODE NAME=\\\"{0}\\\" SS=\\\"{7}\\\" RRR=\\\"{8}\\\" GGG=\\\"{9}\\\" PPP=\\\"{10}\\\" UUUU=\\\"{11}\\\" AA=\\\"{12}\\\" />\"", "36", "011", "000", "028");
                System.Threading.Thread.Sleep(10000);
                return;
            }

            //string fileName = "c:\\temp\\share\\base\\KLADR.DBF";
            string fileName = args[0];
            string outputfile = args[1];
            string level = args[2];
            string format = args[3];

            string ss = null;
            string rrr = null;
            string ggg = null;
            string ppp = null;

            if (args.Length >= 5) ss = args[4];
            if (args.Length >= 6) rrr = args[5];
            if (args.Length >= 7) ggg = args[6];
            if (args.Length >= 8) ppp = args[7];

            Krysalix.KLADR.Format.Parser parser = new Krysalix.KLADR.Format.Parser(fileName);
            //StringBuilder sb = new StringBuilder();

            FileStream sr = File.Create(outputfile);
            StreamWriter writer = new StreamWriter(sr, Encoding.GetEncoding("utf-8"));

            StringBuilder sb = null;
            
            //sb.Append("<RESULT>");
            //sb.Append(parser.Level5ConvertToFormat("<NODE NAME=\"{0}\" SS=\"{8}\" RRR=\"{9}\" GGG=\"{10}\" PPP=\"{11}\" AA=\"{12}\" />"));
            //sb.Append("</RESULT>");

            /*
            switch(args[2])
            {
                case "1": sb.Append(parser.Level1ConvertToFormat(args[3])); break;
                case "2": sb.Append(parser.Level2ConvertToFormat(args[3])); break;
                case "3": sb.Append(parser.Level3ConvertToFormat(args[3])); break;
                case "4": sb.Append(parser.Level4ConvertToFormat(args[3])); break;
                case "5": sb.Append(parser.Level5ConvertToFormat(args[3])); break;
                default: sb.Append(parser.Level14ConvertToFormat(args[3])); break;
            }
            
            */

            switch (level)
            {
                case "1": sb = parser.Level14ConvertToFormat(format, writer, ss, rrr, ggg, ppp); break;
                case "2": sb = parser.Level14ConvertToFormat(format, writer, ss, rrr, ggg, ppp); break;
                case "3": sb = parser.Level14ConvertToFormat(format, writer, ss, rrr, ggg, ppp); break;
                case "4": sb = parser.Level14ConvertToFormat(format, writer, ss, rrr, ggg, ppp); break;
                case "5": sb = parser.Level5ConvertToFormat(format, writer, ss, rrr, ggg, ppp); break;
                default: sb = parser.Level14ConvertToFormat(format, writer, ss, rrr, ggg, ppp); break;
            }

            /*
            if (args.Count() >= 5)
                sb.Insert(0, args[4]);

            if (args.Count() >= 6)
                sb.Append(args[5]);
            */

            //string res = sb.ToString();

            //Console.Write(sb.ToString());

            //Console.WriteLine(String.Format("{0} {1}", "RESULT:", sb.Length));



            //writer.Write(sb.ToString());
            //writer.Write(sb);
            //writer.Flush();

            writer.Close();
            sr.Close();
            

            /*
            using (TextWriter writer = File.CreateText(outputfile))
            {
                writer.Write(sb);
            }
            */

        }
    }
}
