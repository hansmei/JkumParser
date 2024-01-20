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
namespace JkumTests
{
    class Program
    {

        private static string debugFolder;
        private static string simpleTestFile = "testfil.jkum";
        private static string generatedSchema = "outputSchema.jkum";

        static void Main(string[] args)
        {
            debugFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Console.WriteLine("***************");
            Console.WriteLine("Starting tests");
            Console.WriteLine("");

            WriteSimpleFile();
            ValidateSimpleFile();

            Console.WriteLine("");

            WriteModelToSchema();
            ValidateModelSchema();

            Console.WriteLine("\nPress any key to exit the process...");
            Console.ReadKey();
        }

        private static void WriteModelToSchema()
        {
            Console.WriteLine("Writing a schema from the current model");
            string path = Path.Combine(debugFolder, generatedSchema);

            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(typeof(Jkum));

            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    using (JsonTextWriter jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Formatting.Indented;
                        jw.IndentChar = ' ';
                        jw.Indentation = 2;

                        schema.WriteTo(jw);
                    }
                }
            }
        }
        private static void ValidateModelSchema()
        {
            Console.WriteLine("Validating the generated schema file");

            JkumSchemaValidator validator = new JkumSchemaValidator();

            string path = Path.Combine(debugFolder, generatedSchema);
            string jsonString = File.ReadAllText(simpleTestFile);

            JsonTextReader reader = new JsonTextReader(new StringReader(jsonString));
            string readContent = reader.ToString();

            JSchemaValidatingReader validatingReader = new JSchemaValidatingReader(reader);
            string currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string schemaFile = Path.Combine(currentFolder, "Schema", "jkum-schema-1.0.json");
            string jsonSchema = File.ReadAllText(schemaFile);
            validatingReader.Schema = JSchema.Parse(jsonSchema, new JSchemaReaderSettings());

            JsonSerializer serializer = new JsonSerializer();
            Jkum jkum = serializer.Deserialize<Jkum>(validatingReader);

            bool success = validator.IsValid(jsonString);

            if (success)
                Console.WriteLine("Validation succeeded!");
            else
                Console.WriteLine("Validation failed...");
        }

        private static void ValidateSimpleFile()
        {
            Console.WriteLine("Validating the test file");

            JkumSchemaValidator validator = new JkumSchemaValidator();

            string path = Path.Combine(debugFolder, simpleTestFile);
            string jsonString = File.ReadAllText(path);

            bool success = validator.IsValid(jsonString);

            if(success)
                Console.WriteLine("Validation succeeded!");
            else
                Console.WriteLine("Validation failed...");
        }

        private static void WriteSimpleFile()
        {
            Console.WriteLine("Writing simple test file");

            JkumWriter writer = new JkumWriter();
            writer.SetHead(25832, "Hans Martin Eikerol");

            Guid guid = Guid.NewGuid();

            Manhole manhole = new Manhole();
            manhole.Guid = guid.ToString("D");
            manhole.Sid = "556001";
            manhole.BottomCenter = new Point3d(588447.155, 6642743.891, 52.714);
            manhole.Shape = "Circular";
            manhole.Diameter = 1600;
            manhole.Lids = new List<Lid>()
            {
                new Lid()
                {
                    Position = new Point3d(588447.155, 6642743.826, 55.145),
                    Diameter = 650
                }
            };
            manhole.PipeConnections = new List<PipeConnection>()
            {
                new PipeConnection()
                {
                    Guid = Guid.NewGuid().ToString(),
                    Sid = "548861",
                    Medium = "Water",
                    Pressurized = true,
                    Elevation = 53.11,
                    ClockPosition = 20,
                    Diameter = 150
                },
                new PipeConnection()
                {
                    Guid = Guid.NewGuid().ToString(),
                    Sid = "548862",
                    Medium = "Water",
                    Pressurized = true,
                    Elevation = 53.11,
                    ClockPosition = 200,
                    Diameter = 150
                },
                new PipeConnection()
                {
                    Guid = Guid.NewGuid().ToString(),
                    Sid = "548864",
                    Medium = "Water",
                    Pressurized = true,
                    Elevation = 53.11,
                    ClockPosition = 110,
                    Diameter = 150
                },
            };

            writer.AddManhole(manhole);


            Manhole manhole2 = new Manhole();
            manhole2.Guid = Guid.NewGuid().ToString("D");
            manhole2.Sid = "522431";
            manhole2.BottomCenter = new Point3d(588429.23, 6642811.51, 53.218);
            manhole2.Shape = "Rectangular";
            manhole2.Width = 3000;
            manhole2.Length = 1200;
            manhole2.Lids = new List<Lid>()
            {
                new Lid()
                {
                    Position = new Point3d(588428.23, 6642811.71, 55.16),
                    Diameter = 650,
                    Ladder = "Yes",
                    Classification = "D400"
                },
                new Lid()
                {
                    Position = new Point3d(588430.23, 6642811.31, 55.16),
                    Diameter = 650
                },
            };
            manhole2.PipeConnections = new List<PipeConnection>()
            {
                new PipeConnection()
                {
                    Guid = Guid.NewGuid().ToString(),
                    Medium = "Water",
                    Pressurized = true,
                    Elevation = 53.65,
                    ClockPosition = 20,
                    Diameter = 150
                },
                new PipeConnection()
                {
                    Guid = Guid.NewGuid().ToString(),
                    Medium = "Water",
                    Pressurized = true,
                    Elevation = 53.65,
                    ClockPosition = 200,
                    Diameter = 150
                },
                new PipeConnection()
                {
                    Guid = Guid.NewGuid().ToString(),
                    Medium = "Water",
                    Pressurized = true,
                    Elevation = 53.65,
                    ClockPosition = 110,
                    Diameter = 150
                },
                new PipeConnection()
                {
                    Guid = Guid.NewGuid().ToString(),
                    Medium = "StormWater",
                    Direction = "Ingoing",
                    Pressurized = false,
                    Elevation = 53.11,
                    ClockPosition = 110,
                    Diameter = 160
                },
                new PipeConnection()
                {
                    Guid = Guid.NewGuid().ToString(),
                    Medium = "StormWater",
                    Direction = "Outgoing",
                    Pressurized = false,
                    Elevation = 53.07,
                    ClockPosition = 230,
                    Diameter = 300
                },
            };

            writer.AddManhole(manhole2);

            string path = Path.Combine(debugFolder, simpleTestFile);
            writer.SaveAs(path);
        }
    }
}
