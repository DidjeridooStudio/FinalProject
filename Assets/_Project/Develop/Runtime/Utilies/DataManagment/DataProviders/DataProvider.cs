using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders
{
    public abstract class DataProvider<TData> where TData : ISaveData
    {
        private readonly ISaveLoadService _saveLoadService;

        private readonly List<IDataReader<TData>> _dataReaders = new List<IDataReader<TData>>();
        private readonly List<IDataWriter<TData>> _dataWriters = new List<IDataWriter<TData>>();

        private TData _data;

        protected DataProvider(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public void RegisterDataReader(IDataReader<TData> dataReader)
        {
            if (_dataReaders.Contains(dataReader))
                throw new ArgumentException(nameof(dataReader));

            _dataReaders.Add(dataReader);
        }

        public void RegisterDataWriters(IDataWriter<TData> dataWriters)
        {
            if (_dataWriters.Contains(dataWriters))
                throw new ArgumentException(nameof(dataWriters));

            _dataWriters.Add(dataWriters);
        }

        public IEnumerator LoadAsync()
        {
            yield return _saveLoadService.Load<TData>(loadedData => _data = loadedData);

            SendDataToReaders();
        }

        public IEnumerator SaveAsync()
        {
            UpdateDataFromWriters();

            yield return _saveLoadService.Save(_data);
        }

        public IEnumerator ExistsAsync(Action<bool> onExistsResult)
        {
            yield return _saveLoadService.Exists<TData>(result => onExistsResult?.Invoke(result));
        }

        public void Reset()
        {
            _data = GetOriginData();

            SendDataToReaders();
        }

        protected abstract TData GetOriginData();

        private void SendDataToReaders()
        {
            foreach (IDataReader<TData> dataReader in _dataReaders)
                dataReader.ReadFrom(_data);
        }

        private void UpdateDataFromWriters()
        {
            foreach (IDataWriter<TData> dataWriters in _dataWriters)
                dataWriters.WriteTo(_data);
        }
    }
}