using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Quantum : MonoBehaviour
{
    public SpriteRenderer spriteRendererToChange;
    public int framesToChange = 60; // Number of frames for the transition
    private int currentFrame = 0;

    void Start()
    {
        // Assuming you have a SpriteRenderer component attached to the GameObject
        if (spriteRendererToChange == null)
        {
            spriteRendererToChange = GetComponent<SpriteRenderer>();
        }

        StartCoroutine(ChangeSpriteRendererAlphaOverTime());
    }

    IEnumerator ChangeSpriteRendererAlphaOverTime()
    {
        Color startColor = spriteRendererToChange.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Target alpha is 1 (fully opaque)

        while (currentFrame < framesToChange)
        {
            float lerpValue = (float)currentFrame / framesToChange;
            spriteRendererToChange.color = Color.Lerp(startColor, targetColor, lerpValue);

            currentFrame++;
            yield return null;
        }

        // Ensure the sprite renderer is fully opaque at the end
        spriteRendererToChange.color = targetColor;
    }
}