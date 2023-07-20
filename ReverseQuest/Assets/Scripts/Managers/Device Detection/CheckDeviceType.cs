using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeviceType : MonoBehaviour
{
    public static bool IsTablet()
    {
        float aspectRatio = (float)Screen.width / Screen.height;
        // Если аспект больше 0.65, то это по идее планшет, а все что меньше телефон
        bool isTablet = aspectRatio > 0.65f;

        Debug.Log("Aspect Ratio = " + aspectRatio);

        return isTablet;
    }
}
