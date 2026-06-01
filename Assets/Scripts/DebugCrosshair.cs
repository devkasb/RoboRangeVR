using UnityEngine;
using UnityEngine.XR;

public class DebugCrosshair : MonoBehaviour
{
   void Start()
    {
        gameObject.SetActive(!XRSettings.isDeviceActive);
    } 
}
