namespace Assets._Project.Develop.Runtime.Utilies.DataManagment.Serializes
{
    public interface IDataSerializer
    {
        string Serialize<TData>(TData data);

        TData Deserialize<TData>(string serializedData);
    }
}