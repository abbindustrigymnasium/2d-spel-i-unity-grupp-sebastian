using UnityEngine;
using System.Collections; // Add this line

public class PanelOpacityAnimation : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeInDuration = 2.0f;
    public float fadeOutDuration = 2.0f;

    private void Start()
    {
        // Initialize the alpha to fully transparent
        canvasGroup.alpha = 0.0f;

        // Start the fade-in animation
        FadeIn();
    }

    public void FadeIn()
    {
        // Set the alpha to 0 (transparent)
        canvasGroup.alpha = 0.0f;

        // Use a Coroutine to smoothly animate the alpha
        StartCoroutine(FadeAlpha(canvasGroup, 1.0f, fadeInDuration));
    }

    public void FadeOut()
    {
        // Set the alpha to 1 (fully opaque)
        canvasGroup.alpha = 1.0f;

        // Use a Coroutine to smoothly animate the alpha
        StartCoroutine(FadeAlpha(canvasGroup, 0.0f, fadeOutDuration));
    }

    private IEnumerator FadeAlpha(CanvasGroup cg, float targetAlpha, float duration)
    {
        float startAlpha = cg.alpha;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            cg.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cg.alpha = targetAlpha; // Ensure the final alpha is set correctly
    }
}

