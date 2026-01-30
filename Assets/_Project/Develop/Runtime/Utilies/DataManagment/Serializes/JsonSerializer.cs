using Newtonsoft.Json;

namespace Assets._Project.Develop.Runtime.Utilies.DataManagment.Serializes
{
    public class JsonSerializer : IDataSerializer
    {
        public string Serialize<TData>(TData data) => JsonConvert.SerializeObject(data);

        public TData Deserialize<TData>(string serializedData) => JsonConvert.DeserializeObject<TData>(serializedData);
    }
}