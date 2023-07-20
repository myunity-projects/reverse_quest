using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignTextureToSideScreen : MonoBehaviour
{
    public RenderTexture sideScreenTexture;

    public RawImage sideScreenImage;

    public Camera sideCamera;

    void Start()
    {
        // ���� �������� ����������, �� �������� ������ �� ����� �� ����������� ����� � � ������
        if(AdjustRenderTexture.isTextureWidthChanged)
        {
            sideScreenImage.texture = AdjustRenderTexture.newSideScreenTexture;
            sideCamera.targetTexture = AdjustRenderTexture.newSideScreenTexture;
        }
    }
}
