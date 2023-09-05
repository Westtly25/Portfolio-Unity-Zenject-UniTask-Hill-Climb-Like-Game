using UnityEngine;

namespace Assets.Code.Scripts.Runtime.Utilities
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class GpuInstancing : MonoBehaviour
    {
        private void Awake()
        {
            MaterialPropertyBlock materialPropertyBlock = new ();
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.SetPropertyBlock(materialPropertyBlock);
        }
    }
}