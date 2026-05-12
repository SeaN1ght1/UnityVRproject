using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRelativePortal : MonoBehaviour
{
    [Header("绑定目标门")]
    public Transform targetPortal; // 目标传送门
    public float exitOffset = 1.0f; // 传送到目标门前的距离

    [Header("冷却设置")]
    private static bool isTeleporting = false; // 全局静态变量，防止两门间无限循环
    public float cooldownTime = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        // 1. 只有未在传送中且碰到的是 Player 标签物体才触发
        if (!isTeleporting && other.CompareTag("Player"))
        {
            // 2. 获取 XR Origin 的根节点 Transform
            // 注意：这里需要操作的是包含 CharacterController 的那个最外层物体
            Transform playerRoot = other.transform;
            CharacterController cc = playerRoot.GetComponent<CharacterController>();

            if (cc != null)
            {
                StartCoroutine(TeleportProcess(playerRoot, cc));
            }
        }
    }

    private IEnumerator TeleportProcess(Transform player, CharacterController cc)
    {
        isTeleporting = true;

        // --- 核心坐标计算 ---

        // A. 计算玩家相对于【当前门】的本地位置 (x为左右, y为上下, z为前后)
        Vector3 localPos = transform.InverseTransformPoint(player.position);

        // B. 构造在【目标门】处的本地坐标
        // 我们保留 x 和 y 的相对位置，但将 z 设为固定的 exitOffset (确保出现在门前)
        Vector3 targetLocalExitPos = new Vector3(localPos.x, localPos.y, exitOffset);

        // C. 将本地坐标转回世界坐标
        Vector3 worldExitPos = targetPortal.TransformPoint(targetLocalExitPos);

        // D. 计算旋转：让玩家看向目标门 Z 轴的正方向
        Quaternion worldExitRotation = Quaternion.LookRotation(targetPortal.forward);

        // --- 执行位移 ---

        // 必须禁用 CharacterController 才能手动修改 Position
        cc.enabled = false;

        player.position = worldExitPos;
        player.rotation = worldExitRotation;

        // 等待一帧物理刷新
        yield return new WaitForFixedUpdate();

        cc.enabled = true;

        // 冷却计时，防止玩家刚到 B 门又被 B 门传回 A 门
        yield return new WaitForSeconds(cooldownTime);
        isTeleporting = false;
    }
}
