using System.Collections;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;
    [SerializeField] private float fadeSpeed = 0.5f;

    private void Start()
    {
        // Set initial alpha to 0
        myUIGroup.alpha = 0f;
    }

    private void Update()
    {
        // If alpha is less than 1, increase it
        if (myUIGroup.alpha < 1.0f)
        {
            myUIGroup.alpha += Time.deltaTime * fadeSpeed;

            // Ensure that alpha stays within the 0 to 1 range
            myUIGroup.alpha = Mathf.Clamp01(myUIGroup.alpha);
        }
    }
}
