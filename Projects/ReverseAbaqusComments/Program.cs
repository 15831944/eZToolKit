using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseAbaqusComments
{
    /// <summary>
    /// 对 Abaqus 脚本项目中的注释进行转换
    /// </summary>
    class Program
    {
        private const string LineFeed = "\r\n";
        private const int MaxCheckingLine = 20;
        private static Encoding Enc = new UTF8Encoding(true, true);
        private static readonly string[] sep = new string[] { LineFeed };

        public static void Main(string[] args)
        {
            UI();
        }

        private static void NoneUI()
        {
            string dir = @"E:\GitHubProjects\SDSS\AbaqusSolver";
            var changedFiles = ReverseCommentsInDir(dir);

            // 结果反馈
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"注释文件转换成功，修改的文件有{changedFiles.Count}个。");
            Console.WriteLine();
            foreach (var f in changedFiles)
            {
                Console.WriteLine(f);
            }
        }

        private static void UI()
        {
            string dir = @"E:\GitHubProjects\SDSS\AbaqusSolver";

            Console.WriteLine(@"指定要搜索的文件夹。或者按下 Enter 以搜索本程序所在文件夹");
            Console.WriteLine(@"提示：如果要输入相对路径， .表示当前文件夹， ..表示父文件夹");
            Console.WriteLine();
            string dirPath = Console.ReadLine();
            if (string.IsNullOrEmpty(dirPath))
            {
                dir = Directory.GetCurrentDirectory();
            }
            else if (Directory.Exists(dirPath))
            {
                dir = Path.GetFullPath(dirPath);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"指定的文件夹无效！");
                Console.Read();
                return;
            }

            var changedFiles = ReverseCommentsInDir(dir);

            // 结果反馈
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"注释文件转换成功，修改的文件有{changedFiles.Count}个。");
            Console.WriteLine();
            foreach (var f in changedFiles)
            {
                Console.WriteLine(f);
            }
            Console.Read();
        }


        /// <summary>
        /// 将指定文件夹及其子文件夹中的所有 .py 文件中，关于 Abaqus 的引用 全部注释或者取消注释
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static List<string> ReverseCommentsInDir(string dir)
        {
            List<string> changedFiles = new List<string>();
            var files = Directory.GetFiles(dir, "*.py", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                // 读取
                string[] text = ReadOneFile(file);

                //检查
                Dictionary<int, bool> tagLines = null;

                // 如果文本中没有与 Abaqus 引用相关的代码，则不用修改此文本
                bool needReWrite = CheckComment(text, out tagLines);

                // 写入
                if (needReWrite)
                {
                    string[] contents = ReverseTextComment(text, tagLines);

                    WriteOneFile(file, contents);
                    changedFiles.Add(file);
                }
            }
            return changedFiles;
        }

        #region ---   读取文本

        static string[] ReadOneFile(string filePath)
        {
            // FileShare.ReadWrite 可以在其他进程正在使用此文本文件时，依然对其进行读取并生效。
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                byte[] bs = new byte[fs.Length];
                fs.Read(bs, 0, (int)fs.Length);
                // 
                string text = Enc.GetString(bs);

                var lines = text.Split(sep, StringSplitOptions.None);
                return lines;
            }
        }

        #endregion

        #region ---   ！ 检查文本

        /// <summary>
        /// 检查代码文件中的数据，确定要对哪些行进行注释或者取消注释
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="tagLines">键表示行号，值如果为true，表示此行要添加注释，如果为false，表示此行要取消注释</param>
        /// <returns></returns>
        private static bool CheckComment(string[] lines, out Dictionary<int, bool> tagLines)
        {
            tagLines = new Dictionary<int, bool>();
            bool needRewrite = false; // 如果需要对文件进行重新修改，则返回 true
            string line;
            int maxLineCount = lines.Length > MaxCheckingLine ? MaxCheckingLine : lines.Length;
            for (int i = 0; i < maxLineCount; i++)
            {
                line = lines[i];
                bool addComment = false; // true 表示后期要对其添加注释， false 表示要删除注释
                if (CheckTag(line, "from abaqus", ref addComment))
                {
                    tagLines.Add(i, addComment);
                    needRewrite = true;
                }
                else if (CheckTag(line, "import part", ref addComment))
                {
                    tagLines.Add(i, addComment);
                    needRewrite = true;
                }
                else if (CheckTag(line, "from odbAccess", ref addComment))
                {
                    tagLines.Add(i, addComment);
                    needRewrite = true;
                }
                else if (CheckTag(line, "from textRepr", ref addComment))
                {
                    tagLines.Add(i, addComment);
                    needRewrite = true;
                }
                else if (CheckTag(line, "from symbolicConstants", ref addComment))
                {
                    tagLines.Add(i, addComment);
                    needRewrite = true;
                }
            }
            return needRewrite;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="tag"></param>
        /// <param name="addComment">true 表示后期要对其添加注释， false 表示要删除注释 </param>
        /// <returns>如果需要对文件进行重新修改，则返回 true </returns>>
        private static bool CheckTag(string line, string tag, ref bool addComment)
        {
            bool needRewrite = false;
            if (line.StartsWith(tag, StringComparison.Ordinal))
            {
                // 添加注释
                needRewrite = true;
                addComment = true;
            }
            else if (line.StartsWith("# " + tag, StringComparison.Ordinal))
            {
                // 解除注释
                needRewrite = true;
                addComment = false;
            }
            return needRewrite;
        }

        private static string[] ReverseTextComment(string[] lines, Dictionary<int, bool> tagLines)
        {
            // 修改指定行的注释情况
            foreach (var tg in tagLines)
            {
                lines[tg.Key] = ReverseLineComment(lines[tg.Key], tg.Value);
            }
            return lines;
        }

        private static string ReverseLineComment(string line, bool addComment)
        {
            string newLine = null;
            if (addComment)
            {
                // 添加注释
                newLine = "# " + line;
            }
            else
            {
                // 解除注释
                newLine = line.Substring(2);
            }
            return newLine;
        }

        #endregion

        #region ---   写入文本

        private static void WriteOneFile(string filePath, string[] lines)
        {

            int count = lines.Length;
            string line;
            List<byte> bytes = new List<byte>();
            //
            for (int i = 0; i < count - 1; i++)
            {
                bytes.AddRange(Enc.GetBytes(lines[i] + LineFeed));
            }
            // 最后一行不用添加换行符
            bytes.AddRange(Enc.GetBytes(lines[count - 1]));


            // FileShare.ReadWrite 可以在其他进程正在使用此文本文件时，依然对其进行修改并生效。
            using (FileStream fs = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite))
            {
                byte[] bytesArray = bytes.ToArray();
                fs.Write(bytesArray, 0, bytesArray.Length);
            }
        }

        #endregion
    }
}
