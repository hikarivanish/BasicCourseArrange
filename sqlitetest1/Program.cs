using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
namespace sqlitetest1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //获取加载失败的程序集的全名
            var assName = new AssemblyName(args.Name).FullName;
            //if (args.Name == "System.Data.SQLite, Version=1.0.92.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139")
            //{
            //读取资源
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("sqlitetest1.System.Data.SQLite.dll"))
            {
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                return Assembly.Load(bytes);//加载资源文件中的dll,代替加载失败的程序集
            }
            //}
            //throw new DllNotFoundException(assName);
        }
        static Program()
        {
            //这个绑定事件必须要在引用到TestLibrary1这个程序集的方法之前,注意是方法之前,不是语句之间,就算语句是在方法最后一行,在进入方法的时候就会加载程序集,如果这个时候没有绑定事件,则直接抛出异常,或者程序终止了
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }
    }
}
