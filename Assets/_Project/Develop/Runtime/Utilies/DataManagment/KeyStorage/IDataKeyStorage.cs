
public interface IDataKeyStorage
{
    string GetKeyFor<TData>() where TData : ISaveData;
}
