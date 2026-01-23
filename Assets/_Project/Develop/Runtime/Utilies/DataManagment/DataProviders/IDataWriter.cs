
public interface IDataWriter<TData> where TData : ISaveData
{
    void WriteTo(TData data);
}
