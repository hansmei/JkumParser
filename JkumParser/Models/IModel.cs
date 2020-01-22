using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace JkumParser
{
    public interface IModel
    {
        string ToJson(JsonSerializerSettings settings);
        T FromJson<T>(string jsonString, JsonSerializerSettings settings);
    }
}
