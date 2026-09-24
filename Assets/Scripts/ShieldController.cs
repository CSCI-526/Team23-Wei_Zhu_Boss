using UnityEngine;
using UnityEngine.InputSystem;

public class ShieldController : MonoBehaviour
{
    public Transform core;
    public Transform shield;

    public float radius = 1.5f;
    public float height = 0.6f;

    // 四个位置：从左到右 D F J K
    // 这里改成球的“上半边”
    private float[] angles =
    {
        -15f,   // D
        -5f,   // F
        5f,   // J
        15f     // K
    };

    void Start()
    {
        SetShieldPosition(1);
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.dKey.wasPressedThisFrame)
            SetShieldPosition(0);

        if (Keyboard.current.fKey.wasPressedThisFrame)
            SetShieldPosition(1);

        if (Keyboard.current.jKey.wasPressedThisFrame)
            SetShieldPosition(2);

        if (Keyboard.current.kKey.wasPressedThisFrame)
            SetShieldPosition(3);
    }

    public void SelectD()
    {
        SetShieldPosition(0);
    }

    public void SelectF()
    {
        SetShieldPosition(1);
    }

    public void SelectJ()
    {
        SetShieldPosition(2);
    }

    public void SelectK()
    {
        SetShieldPosition(3);
    }

    void SetShieldPosition(int index)
    {
        float rad = angles[index] * Mathf.Deg2Rad;

        Vector3 direction = new Vector3(
            Mathf.Sin(rad),
            0f,
            Mathf.Cos(rad)
        );

        // 直接以 Core 为中心计算世界位置
        Vector3 position =
            core.position +
            direction * radius;

        position.y = height;

        shield.position = position;

        // 让盾牌横在子弹和球之间
        shield.rotation =
            Quaternion.LookRotation(direction, Vector3.up);
    }
}