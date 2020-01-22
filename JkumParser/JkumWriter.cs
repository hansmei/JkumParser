using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
namespace JkumParser
{
    public class JkumWriter
    {

        private Jkum jkum { get; set; }
        private JsonSerializerSettings serializerSettings;

        public JkumWriter()
        {
            this.jkum = new Jkum();
            this.jkum.Manholes = new List<Manhole>();

            serializerSettings = new JsonSerializerSettings();
            serializerSettings.Formatting = Formatting.Indented;
        }

        public void SetHead(Head head)
        {
            this.jkum.Head = head;
        }

        public void SetHead(string epsg)
        {
            Head head = new Head();
            head.EPSG = epsg;
            head.Date = DateTime.Now.ToString("yyyy-MM-dd");
            this.SetHead(head);
        }

        public void SetHead(string epsg, string author)
        {
            Head head = new Head();
            head.EPSG = epsg;
            head.Date = DateTime.Now.ToString("yyyy-MM-dd");
            head.Author = author;
            this.SetHead(head);
        }

        public void SetHead(string epsg, string author, string date)
        {
            Head head = new Head();
            head.EPSG = epsg;
            head.Date = date;
            head.Author = author;
            this.SetHead(head);
        }

        public void AddManhole(Manhole manhole)
        {
            this.jkum.Manholes.Add(manhole);
        }

        public string GetFileContents()
        {
            if (this.jkum.Head == null)
                throw new Exception("The head of a jkum-file is mandatory and must be set.");

            //string jsonString = "";
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    using (StreamWriter sw = new StreamWriter(ms))
            //    {
            //        using (JsonTextWriter jw = new JsonTextWriter(sw))
            //        {
            //            JSchemaValidatingWriter validatingWriter = new JSchemaValidatingWriter(jw);
            //            string currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //            string schemaFile = Path.Combine(currentFolder, "Schema", "jkum-schema-1.0.json");
            //            string jsonSchema = File.ReadAllText(schemaFile);
            //            validatingWriter.Schema = JSchema.Parse(jsonSchema, new JSchemaReaderSettings());

            //            JsonSerializer serializer = new JsonSerializer();
            //            serializer.Serialize(validatingWriter, this.jkum);

            //            jsonString = System.Text.Encoding.UTF8.GetString(ms.ToArray());
            //        }
            //    }
            //}

            string jsonString = this.jkum.ToJson(this.serializerSettings);
            return jsonString;
        }

        public void SaveAs(string destination)
        {
            string ext = Path.GetExtension(destination);
            if(ext != ".jkum")
                throw new Exception("Cannot write a jkum-file without using the proper jkum file extension. Please use only lowercase \".jkum\" as the file extension.");

            string fileContents = this.GetFileContents();
            File.WriteAllText(destination, fileContents);

            //using (FileStream fs = File.Open(destination, FileMode.OpenOrCreate))
            //{
            //    using (StreamWriter sw = new StreamWriter(fs))
            //    {
            //        using (JsonTextWriter jw = new JsonTextWriter(sw))
            //        {
            //            jw.Formatting = Formatting.Indented;
            //            jw.IndentChar = ' ';
            //            jw.Indentation = 4;

            //        }
            //    }
            //}
        }

    }
}
