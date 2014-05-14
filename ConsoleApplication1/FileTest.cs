using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApplication1
{
    public static class FileTest
    {
        public static void Replace()
        {
            string filePath = @"D:\Download\Chrome\iCloud vCards yidaochu (1) - Copy.vcf";
            List<string> list = ReadInfoFromFile(filePath);   //这个函数把文件的每一行读入list
            for (int j = 664; j < list.Count; j++)
            {
                string line = list[j];
                if (line.StartsWith("FN:"))
                {
                    string name = line.Split(new string[] { "FN:" }, StringSplitOptions.None)[1];
                    string first = name.Split(new string[] { "\t" }, StringSplitOptions.None)[0];
                    string last = name.Split(new string[] { "\t" }, StringSplitOptions.None)[1];
                    list[j] = "FN:" + last + " " + first;
                }
            }
            WriteInfoTofile(filePath, list);
        }

        /// <summary>
        /// 这个函数把文件的每一行读入list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static List<string> ReadInfoFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                List<string> list = new List<string>();
                // 打开文件时 一定要注意编码 也许你的那个文件并不是GBK编码的
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream) //读到结尾退出
                    {
                        list.Add(sr.ReadLine());
                    }
                }
                return list;
            }
            return null;
        }

        /// <summary>
        /// 这个函数把list中的每一行写入文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        private static void WriteInfoTofile(string filePath, List<string> list)
        {
            // 打开文件时 一定要注意编码 也许你的那个文件并不是GBK编码的
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                //一个string[] 是一行  ，一行中以tab键分隔
                foreach (string line in list)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
}
