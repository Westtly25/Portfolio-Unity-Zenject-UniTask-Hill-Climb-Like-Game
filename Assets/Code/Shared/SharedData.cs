using Unity.VisualScripting;

namespace Assets.Code.Runtime.Shared
{
    public static class SharedData
    {
        public static class PlayerAdresses
        {
            public const string Player = "Vehicle";
        }

        public static class UIAdresses
        {
            public const string LoadingWindow = "LoadingCanvas";
            public const string MenuWindow = "MenuCanvas";
            public const string QuiteWindow = "QuiteCanvas";
            public const string PauseWindow = "PauseCanvas";
            public const string GameplayWindow = "GameplayCanvas";
            public const string CompleteWindow = "CompleteCanvas";
        }

        public static class FilesConstants
        {
            public const string SaveFilePath = "/Saves/";
            public const string SaveFileName = "User_Save.json";

            public const string ConfigFilePath = "/Configs/";
            public const string ConfigFileName = "App_Config.json";
        }
    }
}