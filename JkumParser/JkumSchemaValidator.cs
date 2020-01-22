using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
namespace JkumParser
{
    public class JkumSchemaValidator
    {
        JSchema schema;
        public JkumSchemaValidator()
        {

            string currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string schemaFile = Path.Combine(currentFolder, "Schema", "jkum-schema-1.0.json");

            string jsonSchema = File.ReadAllText(schemaFile);
            this.schema = JSchema.Parse(jsonSchema);
        }

        public bool IsValid(string jsonString)
        {
            JObject data = JObject.Parse(jsonString);
            bool isValid = data.IsValid(this.schema);
            return isValid;
        }

    }
}
