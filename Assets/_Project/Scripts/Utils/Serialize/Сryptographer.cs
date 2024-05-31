using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Cysharp.Threading.Tasks;

namespace Utils
{
    public sealed class Сryptographer
    {
        private readonly byte[] _key = Convert.FromBase64String("AsISxq9OwdZag1163OJqwovXfSWG98m+sPjVwJecfe4=");
        private readonly byte[] _iv = Convert.FromBase64String("Aq0UThtJhjbuyWXtmZs1rw==");
        
        public byte[] DecryptData(string serializedData)
        {
            using var encryptor = Aes.Create();
            encryptor.Key = _key;
            encryptor.IV = _iv;

            var transform = encryptor.CreateEncryptor();
            var encryptedData = transform.TransformFinalBlock(Encoding.UTF8.GetBytes(serializedData),
                0, serializedData.Length);
            
            return encryptedData;
        }

        public async UniTask<string> EncryptData(string path)
        {
            var encryptedData = await File.ReadAllBytesAsync(path);
            
            using var deсryptor = Aes.Create();
            deсryptor.Key = _key;
            deсryptor.IV = _iv;

            var transform = deсryptor.CreateDecryptor();
            var decryptedData = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            var jsonData = Encoding.UTF8.GetString(decryptedData);
            return jsonData;
        }
    }
}