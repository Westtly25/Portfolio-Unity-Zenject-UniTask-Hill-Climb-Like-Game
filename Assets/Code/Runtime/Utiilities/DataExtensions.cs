using UnityEngine;

namespace Assets.Code.Runtime.Utilities
{
    public static class DataExtensions
    {
        public static Vector2 AddXAndYOffset(this Vector2 vector, float x, float y)
        {
            vector.x = x;
            vector.y = y;
            return vector;
        }

        public static Vector2 AddXOffset(this Vector2 vector, float x)
        {
            vector.x = x;
            return vector;
        }

        public static Vector2 AddYOffset(this Vector2 vector, float y)
        {
            vector.y = y;
            return vector;
        }

        public static float SqrMagnitudeTo(this Vector3 from, Vector3 to) =>
            Vector3.SqrMagnitude(to - from);

        public static string ToJson(this object obj) =>
          JsonUtility.ToJson(obj);

        public static T ToDeserialized<T>(this string json) =>
          JsonUtility.FromJson<T>(json);
    }
}
