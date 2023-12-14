//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class flickerlight : MonoBehaviour
//{
//    public float minIntensity = 0.6f;
//    public float maxIntensity = 1.74f;
//    public float flickerSpeed = 17.6f;

//    private UnityEngine.Rendering.Universal.Light2D spotlight;

//    void Start()
//    {
//        spotlight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
//        StartCoroutine(Flicker());
//    }

//    IEnumerator Flicker()
//    {
//        while (true)
//        {
//            float targetIntensity = Random.Range(minIntensity, maxIntensity);
//            float currentIntensity = spotlight.intensity;

//            // Linear interpolation to smoothly transition between current and target intensity
//            float t = 0f;
//            while (t < 1f)
//            {
//                t += Time.deltaTime * flickerSpeed;
//                spotlight.intensity = Mathf.Lerp(currentIntensity, targetIntensity, t);
//                yield return null;
//            }

//            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
//        }
//    }
//}

using System.Collections;
using UnityEngine;

public class flickerlight : MonoBehaviour
{
    public float minIntensity = 0.6f;
    public float maxIntensity = 1.74f;
    public float flickerSpeed = 5f;

    private UnityEngine.Rendering.Universal.Light2D spotlight;

    void Start()
    {
        spotlight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            float t = 0f;
            float duration = 1f / flickerSpeed;

            while (t < 1f)
            {
                t += Time.deltaTime / duration;
                float intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.Sin(t * Mathf.PI));
                spotlight.intensity = intensity;
                yield return null;
            }

            yield return new WaitForSeconds(0.1f); // Small pause between flickers
        }
    }
}
