using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace MailSenderConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //MemberInfo
            //MethodInfo method = type.GetMethod("Main");
            //ParameterInfo paameter = method.GetParameters().FirstOrDefault();
            //ConstructorInfo
            //PropertyInfo
            //EventInfo
            //FieldInfo

            const string libFileName = "TestLib.dll";
            var libFilePath = Path.GetFullPath(libFileName);

            var lib = Assembly.LoadFile(libFilePath);

            //foreach (var type in lib.DefinedTypes)
            //    Console.WriteLine(type.FullName);

            var consolePrinterType = lib.GetType("TestLib.ConsolePrinter");

            //foreach (var method in consolePrinterType.GetMethods())
            //    Console.WriteLine("{0} {1}({2})",
            //        method.ReturnType.Name,
            //        method.Name,
            //        string.Join(", ", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}")));


            #region Вызов метода при помощи рефлексии

            var printerCtor = consolePrinterType.GetConstructor(new[] { typeof(string) });

            object printerObj = printerCtor.Invoke(new object[] { "PrinterPrefix> " });

            var printMethod = consolePrinterType.GetMethod("Print");

            printMethod.Invoke(printerObj, new object[] { "Data to print!" });

            #endregion
            #region Изменений приватного поля при помощи рефлексии

            var prefixField = consolePrinterType.GetField("_Prefix", BindingFlags.NonPublic | BindingFlags.Instance);

            string fieldValue = (string)prefixField.GetValue(printerObj);

            fieldValue += $"{DateTime.Now} |||";

            prefixField.SetValue(printerObj, fieldValue);

            #endregion
            #region Вызов приватного метода

            var getPrefixMethod = consolePrinterType.GetMethod("GetPrefixLength", BindingFlags.Instance | BindingFlags.NonPublic);

            var result = (int)getPrefixMethod.Invoke(printerObj, new object[] { 27, "Hello World!" });

            #endregion
            #region Динамический вызов метода

            //dynamic printer = Activator.CreateInstance(consolePrinterType, new object[] { "Hello World!" }, null);
            //printer.Print("QWE");

            #endregion


            #region DLR

            var S1 = Sum("QWE", "123");
            Console.WriteLine(S1);

            var V1 = Sum(42, 54);
            Console.WriteLine(V1);

            var V2 = Sum(42, 3.141592653589793238);
            Console.WriteLine(V2);

            var V3 = Sum(42, "Hello World!");
            Console.WriteLine(V3);

            //var V4 = Sum(42, new List<int>());

            var data = new object[]
            {
                "Hello World!",
                42,
                3.141592653589793238,
                true,
                new List<int>()
            };
            Console.Clear();
            //ProcessData(data);

            #endregion
            #region DLR Деревья выражений

            Func<string, int> strLen = str => str.Length;
            Expression<Func<string, int>> expr = str => str.Length;

            Expression<Func<int, int, int>> summExpr = (x, y) => x + y;

            var function = summExpr.Compile();

            var value = function(3, 5);


            var parameter = Expression.Parameter(typeof(string), "Message");
            var body = Expression.Call(
                Expression.Constant(printerObj),
                printMethod,
                parameter);

            var printExpr = Expression.Lambda<Action<string>>(
                body,
                parameter);

            var printAction = printExpr.Compile();

            printAction("123");


            var list = new List<int>();

            Console.WriteLine(MemberName(list, l => l.Count));
            Console.WriteLine(MemberName(list, l => l.Capacity));
            Console.WriteLine(MemberName(list, l => l.Remove(5)));

            #endregion

            Console.ReadLine();
        }

        private static dynamic Sum(dynamic X, dynamic Y) { return X + Y; }

        private static void ProcessData(object[] data)
        {
            //foreach (var value in data)
            //    switch (value)
            //    {
            //        case string v: Process(v); break;
            //        case int v: Process(v); break;
            //        case double v: Process(v); break;
            //        case bool v: Process(v); break;
            //    }

            foreach (var value in data)
            {
                dynamic v = value;
                Process(v);
            }
        }

        private static void Process(string value) => Console.WriteLine("string: {0}", value);
        private static void Process(int value) => Console.WriteLine("int: {0}", value);
        private static void Process(double value) => Console.WriteLine("double: {0}", value);
        private static void Process(bool value) => Console.WriteLine("bool: {0}", value);
        private static void Process(object value) => Console.WriteLine("object: {0}", value);

        public static string MemberName<T, TQ>(T item, Expression<Func<T, TQ>> expr)
        {
            var body = expr.Body;
            switch (body)
            {
                case MemberExpression member: return member.Member.Name;
            }

            return body.ToString();
        }

        //public virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        //{
        //    if (this.PropertyChanged == null)
        //        return;
        //    string propertyName = ObservableObject.GetPropertyName<T>(propertyExpression);
        //    if (string.IsNullOrEmpty(propertyName))
        //        return;
        //    this.RaisePropertyChanged(propertyName);
        //}
    }


}
