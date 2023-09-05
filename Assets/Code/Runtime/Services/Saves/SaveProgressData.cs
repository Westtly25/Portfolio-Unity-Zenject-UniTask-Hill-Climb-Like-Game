using System;

namespace Assets.Code.Runtime.Services.Saves
{
    /// <summary>
    /// Пример
    /// Модель игрока с данными для сохранения
    /// </summary>
    [Serializable]
    public sealed class SaveProgressData
    {
        public int CoinsAmount { get; set; }
    }
}