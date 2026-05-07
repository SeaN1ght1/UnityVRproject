using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableGlass : MonoBehaviour
{
    [Header("破碎效果（可选）")]
    public GameObject brokenPrefab;

    [Header("是否只允许破碎一次")]
    public bool destroyAfterBreak = true;

    private bool isBroken = false;

    public void Break()
    {
        if (isBroken) return;

        isBroken = true;

        // 1. 生成破碎版本（如果有）
        if (brokenPrefab != null)
        {
            Instantiate(
                brokenPrefab,
                transform.position,
                transform.rotation
            );
        }

        // 2. 可选：隐藏原物体
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // 3. 销毁原物体
        if (destroyAfterBreak)
        {
            Destroy(gameObject);
        }
    }
}
