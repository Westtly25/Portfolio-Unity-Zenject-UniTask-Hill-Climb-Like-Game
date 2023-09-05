using Assets.Code.Runtime.Logic;
using System.Threading.Tasks;
using Assets.Code.Runtime.Utilities;
using Assets.Code.Runtime.Shared;
using UnityEngine;

namespace Assets.Code.Runtime.Services.Saves
{
    public sealed class SaveLoadService : ISaveLoadService
    {
        private SaveProgressData saveData;

        private readonly string fullPath;
        private readonly IFileHandler fileHandler;

        public SaveLoadService(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
            fullPath = BuildPath();
        }

        public async Task Save()
        {
            string text = saveData.ToJson();
            await fileHandler.WriteAsync(fullPath, text);
        }

        public async Task Load()
        {
            string text = await fileHandler.ReadAsync(fullPath);

            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrEmpty(text))
            {
                saveData = new SaveProgressData();
                return;
            }
            else saveData = text.ToDeserialized<SaveProgressData>();
        }

        private string BuildPath() =>
            Application.persistentDataPath + SharedData.FilesConstants.SaveFilePath + SharedData.FilesConstants.SaveFileName;
    }
}