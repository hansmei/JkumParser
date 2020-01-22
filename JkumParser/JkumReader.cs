using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;

using JkumParser;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace JkumParser
{
    public class JkumReader
    {
        public JkumReader()
        {

        }

        public Jkum ReadFile(string fileToRead)
        {
            string jsonString = File.ReadAllText(fileToRead);

            JsonTextReader reader = new JsonTextReader(new StringReader(jsonString));
            string readContent = reader.ToString();

            JSchemaValidatingReader validatingReader = new JSchemaValidatingReader(reader);
            string currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string schemaFile = Path.Combine(currentFolder, "Schema", "jkum-schema-1.0.json");
            string jsonSchema = File.ReadAllText(schemaFile);
            validatingReader.Schema = JSchema.Parse(jsonSchema, new JSchemaReaderSettings());

            JsonSerializer serializer = new JsonSerializer();
            Jkum jkum = serializer.Deserialize<Jkum>(validatingReader);
            return jkum;
        }

    }
}
