using UnityEngine;
using UnityEngine.XR;

public class SwitchController : MonoBehaviour
{
    [Header("Left Hand")]
    [SerializeField] GameObject RayLeft;
    [SerializeField] GameObject DirectLeft;

    [Header("Right Hand")]
    [SerializeField] GameObject RayRight;
    [SerializeField] GameObject DirectRight;

    private InputDevice leftHand;
    private InputDevice rightHand;

    private bool leftPrimaryButton;
    private bool prevLeftPrimaryButton;

    private bool rightPrimaryButton;
    private bool prevRightPrimaryButton;

    void Start()
    {
        leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    void Update()
    {
        // 防止 VR 设备热插拔失效
        if (!leftHand.isValid)
            leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        if (!rightHand.isValid)
            rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        // 读取 VR 手柄按钮
        leftHand.TryGetFeatureValue(CommonUsages.primaryButton, out leftPrimaryButton);
        rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out rightPrimaryButton);

        // =========================
        // 左手切换
        // =========================

        // Mock HMD 键盘 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleLeftHand();
        }

        // VR 手柄左手主按钮（Quest X）
        if (leftPrimaryButton && !prevLeftPrimaryButton)
        {
            ToggleLeftHand();
        }

        // =========================
        // 右手切换
        // =========================

        // Mock HMD 键盘 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleRightHand();
        }

        // VR 手柄右手主按钮（Quest A）
        if (rightPrimaryButton && !prevRightPrimaryButton)
        {
            ToggleRightHand();
        }

        // 保存上一帧状态
        prevLeftPrimaryButton = leftPrimaryButton;
        prevRightPrimaryButton = rightPrimaryButton;
    }

    void ToggleLeftHand()
    {
        bool isRayMode = RayLeft.activeSelf;

        RayLeft.SetActive(!isRayMode);
        DirectLeft.SetActive(isRayMode);
    }

    void ToggleRightHand()
    {
        bool isRayMode = RayRight.activeSelf;

        RayRight.SetActive(!isRayMode);
        DirectRight.SetActive(isRayMode);
    }
}