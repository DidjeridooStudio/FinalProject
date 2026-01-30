namespace Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders
{
    public interface IDataReader<TData> where TData : ISaveData
    {
        void ReadFrom(TData data);
    }
}