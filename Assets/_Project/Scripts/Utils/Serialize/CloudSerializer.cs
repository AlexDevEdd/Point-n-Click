using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Sirenix.Utilities;
using Unity.Services.CloudSave;

namespace Utils
{
    public sealed class CloudSerializer : ISerializer
    {
        private bool _isInProgressNow;
        
        public bool TryDeserialize<TData>(string serializedData, out TData data)
        {
            data = JsonConvert.DeserializeObject<TData>(serializedData);
            return  data != null;
        }
        
        public bool TrySerialize<TData>(TData data, out string serializedData)
        {
            serializedData = JsonConvert.SerializeObject(data);
            return !serializedData.IsNullOrWhitespace();
        }
        
        public async UniTaskVoid SaveAsync<TData>(string key, TData data)
        {
            if(_isInProgressNow) return;

            try
            {
                _isInProgressNow = true;
                TrySerialize(data, out var serializedData);
            
                var dict = new Dictionary<string, object> { { key, serializedData } };
                await CloudSaveService.Instance.Data.Player.SaveAsync(dict);
            
                _isInProgressNow = false;
            }
            catch (Exception e)
            {
                _isInProgressNow = false;
                throw new ArgumentException($"Something went wrong : {e}");
            }
        }
        
        public async UniTask<TData> LoadAsync<TData>(string key)
        {
            try
            {
                var playerData =
                    await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string>() { key });

                if (playerData.TryGetValue(key, out var data))
                {
                    TryDeserialize<TData>(data.Value.GetAs<string>(), out var deserializedData);
                    return deserializedData;
                }
            }
            catch (Exception e)
            {
                Log.ColorLogDebugOnly(e.ToString(), ColorType.Red, LogStyle.Error);
                return default;
            }

            return default;
        }
        
        
        [Obsolete("Obsolete")]
        public async void Remove(string key)
        {
            await CloudSaveService.Instance.Data.Player.DeleteAsync(key);
        }
    }
}