using System.Collections;
using UnityEngine;

namespace ModelReplacement
{

    public class Blinker : MonoBehaviour
    {

        public bool Blink = true;
        [Tooltip("Minimum seconds between blinks")]
        public float MinTime = 5f;
        [Tooltip("Maximum seconds between blinks")]
        public float MaxTime = 15f;
        [Tooltip("Duration of a single blink")]
        public float BlinkDuration = 0.1f; // Duration of the blink

        private SkinnedMeshRenderer thisMesh;
        private Material instanceMaterial;
        private Vector2 originalOffset;
        private bool isBlinking = false;

        void Start()
        {
            thisMesh = GetComponent<SkinnedMeshRenderer>();

            // Create a unique material instance
            if (thisMesh.materials.Length > 0)
            {
                instanceMaterial = thisMesh.materials[0];
                originalOffset = instanceMaterial.mainTextureOffset;
                StartCoroutine(BlinkRoutine());
            }
            else
            {
                Blink = false;
          //      Debug.LogWarning("This Mesh doesn't seem to have any materials");
            }
        }

        public void DeadEyes()
        {
            StopCoroutine(BlinkRoutine());
            thisMesh = GetComponent<SkinnedMeshRenderer>();
            Blink = false;

            if (thisMesh.materials.Length > 0)
            {
                instanceMaterial = thisMesh.materials[0];
                instanceMaterial.mainTextureOffset = new Vector2(0.01469f, 0.53901f);
            }
            else { Debug.LogError("Didn't find heawd after attaching for dead eyes method"); }

        }
        IEnumerator BlinkRoutine()
        {
            while (Blink)
            {
                yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));

                // Start blinking
                isBlinking = true;
                instanceMaterial.mainTextureOffset = new Vector2(0.01469f, 0.53901f);

                // Wait for the duration of the blink
                yield return new WaitForSeconds(BlinkDuration);

                // Stop blinking
                isBlinking = false;
                instanceMaterial.mainTextureOffset = originalOffset;
            }
        }
    }
}