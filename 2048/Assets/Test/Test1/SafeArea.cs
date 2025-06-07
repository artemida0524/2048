using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    private RectTransform safeAreaRectTransform;

    private void Awake()
    {
        safeAreaRectTransform = GetComponent<RectTransform>();
        UpdateSafeArea();
    }

    private void UpdateSafeArea()
    {
        Rect safeArea = Screen.safeArea;
        Vector2 anchorMin = safeArea.position / new Vector2(Screen.width, Screen.height);
        Vector2 anchorMax = (safeArea.position + safeArea.size) / new Vector2(Screen.width, Screen.height);

        safeAreaRectTransform.anchorMin = anchorMin;
        safeAreaRectTransform.anchorMax = anchorMax;
    }

    private void OnEnable()
    {
        UpdateSafeArea();
    }
}
