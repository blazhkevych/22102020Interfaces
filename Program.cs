using System;
using System.Runtime.Serialization;

namespace Test
{
    public interface IWriter
    {
        void WriteFile();
    }

    public class FileBase
    {
        public virtual void SetName()
        {
            Console.WriteLine("Setting name in the base Writer class.");
        }
    }

    public interface IFormatter
    {
        void FormatFile();
    }

    public class XmlWriter : FileBase, IWriter, IFormatter
    {
        public void WriteFile()
        {
            Console.WriteLine("Writing file in the XmlWriter class.");
        }

        public override void SetName()
        {
            Console.WriteLine("Setting name in the XmlWriter class.");
        }

        public void FormatFile()
        {
            Console.WriteLine("Formatting file in XmlWriter class.");
        }
    }

    public class JsonWriter : FileBase, IWriter
    {
        public void WriteFile()
        {
            Console.WriteLine("Writing file in the JsonWritter class.");
        }

        public override void SetName()
        {
            Console.WriteLine("Setting name in the JsonWriter class.");
        }
    }

    public class FileWriter
    {
        private readonly IWriter _writer;

        public FileWriter(IWriter writer)
        {
            _writer = writer;
        }

        public void Write()
        {
            _writer.WriteFile();
        }
    }

    public interface Interface1
    {
        void MethodExample();
    }

    public interface Interface2
    {
        void MethodExample();
    }

    public class ExampleClass : Interface1, Interface2
    {
        void Interface1.MethodExample()
        {
            Console.WriteLine("");
        }

        void Interface2.MethodExample()
        {
            Console.WriteLine("");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //XmlWriter writer = new XmlWriter();
            //writer.SetName();
            //writer.WriteFile();

            //XmlWriter xmlWriter = new XmlWriter();
            //FileWriter fileWriter = new FileWriter(xmlWriter);
            //fileWriter.Write();

            XmlWriter xmlWriter = new XmlWriter();
            JsonWriter jsonWriter = new JsonWriter();

            FileWriter fileWriter = new FileWriter(xmlWriter);
            fileWriter.Write();

            fileWriter = new FileWriter(jsonWriter);
            fileWriter.Write();

            Console.ReadKey();
        }
    }
}
