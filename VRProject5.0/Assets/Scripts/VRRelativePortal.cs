using System.Collections;
using UnityEngine;

public class VRRelativePortal : MonoBehaviour
{
    [Header("绑定目标门")]
    public Transform targetPortal;
    public float exitOffset = 1.0f;

    [Header("冷却设置")]
    private static bool isTeleporting = false;
    public float cooldownTime = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        // 没有目标门时，不允许传送
        if (targetPortal == null || !targetPortal.gameObject.activeInHierarchy)
            return;

        if (!isTeleporting && other.CompareTag("Player"))
        {
            Transform playerRoot = other.transform.root;
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

        Vector3 localPos = transform.InverseTransformPoint(player.position);
        Vector3 targetLocalExitPos = new Vector3(localPos.x, localPos.y, exitOffset);
        Vector3 worldExitPos = targetPortal.TransformPoint(targetLocalExitPos);
        Quaternion worldExitRotation = Quaternion.LookRotation(targetPortal.forward);

        cc.enabled = false;
        player.position = worldExitPos;
        player.rotation = worldExitRotation;

        yield return new WaitForFixedUpdate();

        cc.enabled = true;

        yield return new WaitForSeconds(cooldownTime);
        isTeleporting = false;
    }
}