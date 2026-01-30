using Assets._Project.Develop.Runtime.Utilies.DataManagment;

namespace Assets._Project.Develop.Runtime.Utilies.DataManagment.KeyStorage
{
    public interface IDataKeyStorage
    {
        string GetKeyFor<TData>() where TData : ISaveData;
    }
}