using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Title_script : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText;
    public int framesToChange = 240; // Number of frames for the transition
    private int currentFrame = 0;

    public int StartFrame = 0;

    public int frameToMove = 680;
    public float speed = 0.25F;

    public RectTransform Rect;

    void Start()
    {
        // Assuming you have a TextMeshProUGUI component attached to the GameObject
        if (textMeshProText == null)
        {
            textMeshProText = GetComponent<TextMeshProUGUI>();

            if (textMeshProText == null)
            {
                Debug.LogError("TextMeshProUGUI component not found in the parent Canvas hierarchy.");
                return;
            }
        }


        StartCoroutine(ChangeTextAlphaOverTime());
    }

    IEnumerator ChangeTextAlphaOverTime()
    {
        Color startColor = textMeshProText.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Target alpha is 1 (fully opaque)

        while (currentFrame < framesToChange)
        {
            float lerpValue = (float)currentFrame / framesToChange;
            textMeshProText.color = Color.Lerp(startColor, targetColor, lerpValue);

            currentFrame++;
            yield return null;
        }

        // Ensure the text is fully opaque at the end
        textMeshProText.color = targetColor;

        /*         while (currentFrame > frameToMove && currentFrame < frameToMove + 200)
                {
                    Debug.Log("In while");
                    Vector3 targetPosition = Rect.position;
                    targetPosition = new Vector3(Rect.position.x, Rect.position.y + speed, Rect.position.z);
                    Rect.position = targetPosition;
                } */
    }
}
