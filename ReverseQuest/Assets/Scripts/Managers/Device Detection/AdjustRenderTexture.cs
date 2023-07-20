using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustRenderTexture : MonoBehaviour
{
    public static bool isTextureWidthChanged = false;

    public static RenderTexture newSideScreenTexture;

    public RenderTexture sideScreenTexture; 

    private bool _isTablet;

    private int _tabletSideScreenWidth = 960;
    private int _tabletSideScreenHeight = 480;
    private int _mobileSideScreenWidth = 720;
    private int _mobileSideScreenHeight = 720;

    void Awake()
    {
        _isTablet = CheckDeviceType.IsTablet();

        // меняем ширину текстуры согласно дивайсу
        if (_isTablet)
        {
            sideScreenTexture.width = _tabletSideScreenWidth;
            sideScreenTexture.height = _tabletSideScreenHeight;
        }
        else
        {
            sideScreenTexture.width = _mobileSideScreenWidth;
            sideScreenTexture.height = _mobileSideScreenHeight;
        }
        
        // Копируем измененнную текстуру в новую
        newSideScreenTexture = new RenderTexture(sideScreenTexture);

        // удаляем старую текстуру
        sideScreenTexture.Release();

        isTextureWidthChanged = true;
    }
}
