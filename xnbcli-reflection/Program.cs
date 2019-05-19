using Newtonsoft.Json;
using System;
using System.Reflection;

namespace xnbcli_reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine(JsonConvert.SerializeObject(Response.Error("Invalid number of arguments.")));
                return;
            }

            // TODO: don't load static URL here
            var assembly = Assembly.ReflectionOnlyLoadFrom(@".\StardewValley.DummyGameData.dll");

            var type = assembly.GetType(args[0]);
            var fields = type.GetFields();

            Console.WriteLine(string.Join<FieldInfo>(",", fields));

            Console.ReadKey();
        }
    }

    class Response
    {
        public string error;

        public static Response Error(string error) => new Response() { error = error };
    }
}
