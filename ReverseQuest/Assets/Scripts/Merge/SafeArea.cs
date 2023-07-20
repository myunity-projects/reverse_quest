using UnityEngine;

public class SafeArea : MonoBehaviour
{
    private Rect _safeArea;
    private RectTransform _rectTransform;

    private Vector2 _anchorMin;
    private Vector2 _anchorMax;

    private void Start()
    {
        _safeArea = Screen.safeArea;
        _rectTransform = GetComponent<RectTransform>();

        _anchorMin = _safeArea.position;
        _anchorMax = _safeArea.position + _safeArea.size;

        _anchorMin.x /= Screen.width;
        _anchorMin.y /= Screen.height;
        _anchorMax.x /= Screen.width;
        _anchorMax.y /= Screen.height;

        _rectTransform.anchorMin = _anchorMin;
        _rectTransform.anchorMax = _anchorMax;
    }
}
