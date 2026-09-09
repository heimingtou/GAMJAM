using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFitCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Tỷ lệ thiết kế chuẩn của Game (Ví dụ: 16:9)")]
    [SerializeField] private float targetWidth = 16f;
    [SerializeField] private float targetHeight = 9f;

    void Awake ()
    {
        // Đảm bảo Camera tự động xóa màn hình cũ bằng Solid Color màu đen

        Camera cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = Color.black;
        // Tính tỷ lệ khung hình mục tiêu (Target Aspect)
        float targetAspect = targetWidth / targetHeight;

        // Tính tỷ lệ khung hình thực tế của màn hình thiết bị hiện tại
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Tính tỷ lệ scale giữa thiết bị và thiết kế
        float scaleHeight = windowAspect / targetAspect;

        // Nếu màn hình thiết bị dài/hẹp hơn tỷ lệ chuẩn (thêm viền đen ở trên và dưới)
        if (scaleHeight < 1.0f)
        {
            Rect rect = cam.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            cam.rect = rect;
        }
        else // Nếu màn hình thiết bị rộng hơn tỷ lệ chuẩn (thêm viền đen ở hai bên trái và phải - Pillarbox)
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = cam.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            cam.rect = rect;
        }
    }
}
