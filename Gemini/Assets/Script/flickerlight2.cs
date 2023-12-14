using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickerlight2 : MonoBehaviour
{
    public float minIntensity = 0.6f;
    public float maxIntensity = 1.74f;
    public float minFlickerTime = 0.1f;
    public float maxFlickerTime = 0.5f;

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
            float duration = Random.Range(minFlickerTime, maxFlickerTime);

            while (t < 1f)
            {
                t += Time.deltaTime / duration;
                float intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.Sin(t * Mathf.PI));
                spotlight.intensity = intensity;
                yield return null;
            }

            yield return new WaitForSeconds(Random.Range(minFlickerTime, maxFlickerTime));
        }
    }
}
