using System;
using System.Data;
using System.Threading.Tasks;
using ZL.TushareClient.Core;
namespace ZL.TushareClient.Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Tushare.pro C# SDK演示。请先注册用户并获取Token：https://tushare.pro/register?reg=416231 ");
            Console.Write("请输入Token:");
            var token = Console.ReadLine();
            var client = new TuShareClient(token);

            Console.WriteLine("请输入命令（比如new_share），命令及权限参见：https://tushare.pro/document/1?doc_id=108，退出输入exit");
            Console.Write(">");
            var command = Console.ReadLine();
            while (command != "exit")
            {
                try
                {
                    var dt = await client.CallApiDataTable(command, new System.Collections.Generic.Dictionary<string, string>(), new System.Collections.Generic.List<string>());
                    foreach (DataColumn col in dt.Columns)
                    {
                        Console.Write(col.ColumnName + " ");
                    }
                    Console.WriteLine();
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            Console.Write(row[col.ColumnName] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("请输入命令（比如new_share），命令及权限参见：https://tushare.pro/document/1?doc_id=108，退出输入exit");
                Console.Write(">");
                command = Console.ReadLine();
            }
                
        }
    }
}
