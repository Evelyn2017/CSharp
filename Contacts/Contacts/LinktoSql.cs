using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    
    class LinktoSql
    {
        const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Contacts;Integrated Security=true;";
        public void linkSql()
        {
            try
            {
                // 连接数据库引擎
                using (dataDataContext aDataContext = new dataDataContext(ConnectionString))
                {
                    if (!aDataContext.DatabaseExists())
                    {
                        aDataContext.CreateDatabase();
                        Console.WriteLine("数据库已经创建！");
                    }
                    else
                    {
                        Console.WriteLine("数据库已经存在！");
                    }

                    // 读取数据表内容
                    var aUsers = from r in aDataContext.User select r;
                    foreach (User aUser in aUsers)
                    {
                        Console.WriteLine($"{aUser.id} : {aUser.password}");
                    }

                    Console.WriteLine("插入新记录……");
                    User aNewUser = new User { id = "131", password = "131" };
                    aDataContext.User.InsertOnSubmit(aNewUser);

                    

                    Console.WriteLine("提交数据……");
                    aDataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("按回车键退出……");
            Console.ReadLine();
        }
    }
}
