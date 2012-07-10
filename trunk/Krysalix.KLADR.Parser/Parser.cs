using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Krysalix.KLADR.Format
{
    public class Parser
    {
        string fileName;

        public Parser(string filename)
        {
            this.fileName = filename;
        }

        public StringBuilder Level14ConvertToFormat(string format)
        {
            return Level14ConvertToFormat(format, null, null, null, null, null);
        }

        public StringBuilder Level14ConvertToFormat(string format, string SS, string RRR, string GGG, string PPP)
        {
            return Level14ConvertToFormat(format, null, SS, RRR, GGG, PPP);
        }

        // format params: NAME	SOCR	CODE	INDEX	GNINMB	UNO	OCATD	STATUS	СС	РРР	ГГГ	ППП	АА
        public StringBuilder Level14ConvertToFormat(string format, StreamWriter writer, string SS, string RRR, string GGG, string PPP)
        {

            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path.GetDirectoryName(fileName) + ";Extended Properties=dBASE IV;User ID=;Password=;");
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                OleDbDataAdapter da = new OleDbDataAdapter("select * from " + Path.GetFileName(fileName), con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                int n = ds.Tables[0].Rows.Count;

                //string res = string.Empty;

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < n; ++i)
                {
                    string code = ds.Tables[0].Rows[i][2].ToString();

                    string ss = code.Substring(0, 2);
                    string rrr = code.Substring(2, 3);
                    string ggg = code.Substring(5, 3);
                    string ppp = code.Substring(8, 3);
                    string aa = code.Substring(11, 2);

                    if ((SS == null || ss == SS) && (RRR == null || rrr == RRR) && (GGG == null || ggg == GGG) && (PPP==null || ppp == PPP))
                    {
                        if (writer != null)
                            writer.Write(format, ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4], ds.Tables[0].Rows[i][5], ds.Tables[0].Rows[i][6], ds.Tables[0].Rows[i][7], ss, rrr, ggg, ppp, aa);
                        else
                            sb.AppendFormat(format, ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4], ds.Tables[0].Rows[i][5], ds.Tables[0].Rows[i][6], ds.Tables[0].Rows[i][7], ss, rrr, ggg, ppp, aa);
                    }
                }

                //return sb.ToString();

                return sb;

                //return true;
            }
            catch
            {
                //return false;
            }

            return null;

        }

        public StringBuilder Level5ConvertToFormat(string format)
        {
            return Level5ConvertToFormat(format, null, null, null, null, null);
        }

        public StringBuilder Level5ConvertToFormat(string format, string SS, string RRR, string GGG, string PPP)
        {
            return Level5ConvertToFormat(format, null, SS, RRR, GGG, PPP);
        }

        // NAME	SOCR	CODE	INDEX	GNINMB	UNO	OCATD	СС	РРР	ГГГ	ППП	УУУУ	АА
        public StringBuilder Level5ConvertToFormat(string format, StreamWriter writer, string SS, string RRR, string GGG, string PPP)
        {

            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path.GetDirectoryName(fileName) + ";Extended Properties=dBASE IV;User ID=;Password=;");
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                OleDbDataAdapter da = new OleDbDataAdapter("select * from " + Path.GetFileName(fileName), con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                int n = ds.Tables[0].Rows.Count;

                string res = string.Empty;

                StringBuilder sb = new StringBuilder();

                //StringBuilder sb = new StringBuilder(Int32.MaxValue, Int32.MaxValue);

                for (int i = 0; i < n; ++i)
                {
                    string code = ds.Tables[0].Rows[i][2].ToString();

                    string ss = code.Substring(0, 2);
                    string rrr = code.Substring(2, 3);
                    string ggg = code.Substring(5, 3);
                    string ppp = code.Substring(8, 3);
                    string uuuu = code.Substring(11, 4);
                    string aa = code.Substring(15, 2);

                    if ((SS == null || ss == SS) && (RRR == null || rrr == RRR) && (GGG == null || ggg == GGG) && (PPP == null || ppp == PPP))
                    {
                        if (writer != null)
                            writer.Write(format, ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4], ds.Tables[0].Rows[i][5], ds.Tables[0].Rows[i][6], ss, rrr, ggg, ppp, uuuu, aa);
                        else
                            sb.AppendFormat(format, ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4], ds.Tables[0].Rows[i][5], ds.Tables[0].Rows[i][6], ss, rrr, ggg, ppp, uuuu, aa);

                        //res += string.Format(format, ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4], ds.Tables[0].Rows[i][5], ds.Tables[0].Rows[i][6], ss, rrr, ggg, ppp, uuuu, aa);

                        /*
                        if (i % 100000 == 0 || i == (n - 1))
                        {
                            //res += sb.ToString();
                            //sb.Clear();

                            Console.WriteLine(String.Format("{0} {1}", i, sb.Length));
                        }
                        */
                    }
                    
                }

                //Console.WriteLine(String.Format("{0} {1}", "result:", sb.Length));

                return sb;

                //return sb.ToString();

                //return res;

                //return true;
            }
            catch
            {
                //return false;
            }

            return null;

        }

        /*
        public StringBuilder Level1ConvertToFormat(string format)
        {
            return Level14ConvertToFormat(format);
        }

        public StringBuilder Level2ConvertToFormat(string format)
        {
            return Level14ConvertToFormat(format);
        }

        public StringBuilder Level3ConvertToFormat(string format)
        {
            return Level14ConvertToFormat(format);
        }

        public StringBuilder Level4ConvertToFormat(string format)
        {
            return Level14ConvertToFormat(format);
        }

        public StringBuilder Level1ConvertToFormat(string format, StreamWriter writer)
        {
            return Level14ConvertToFormat(format, writer, null, null, null, null);
        }

        public StringBuilder Level2ConvertToFormat(string format, StreamWriter writer)
        {
            return Level14ConvertToFormat(format, writer, null, null, null, null);
        }

        public StringBuilder Level3ConvertToFormat(string format, StreamWriter writer)
        {
            return Level14ConvertToFormat(format, writer, null, null, null, null);
        }

        public StringBuilder Level4ConvertToFormat(string format, StreamWriter writer)
        {
            return Level14ConvertToFormat(format, writer, null, null, null, null);
        }
        */

        public StringBuilder Level14ConvertToFormat(string format, StreamWriter writer)
        {
            return Level14ConvertToFormat(format, writer, null, null, null, null);
        }

        public StringBuilder Level5ConvertToFormat(string format, StreamWriter writer)
        {
            return Level5ConvertToFormat(format, writer, null, null, null, null);
        }

        /*
        public StringBuilder Level14ConvertToFormat(string format, StreamWriter writer, string SS, string RRR, string GGG, string PPP)
        {
            return Level14ConvertToFormat(format, writer, SS, RRR, GGG, PPP);
        }

        public StringBuilder Level5ConvertToFormat(string format, StreamWriter writer, string SS, string RRR, string GGG, string PPP)
        {
            return Level5ConvertToFormat(format, writer, SS, RRR, GGG, PPP);
        }
        */
    }
}
