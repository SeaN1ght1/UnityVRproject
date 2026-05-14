using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolPortal : MonoBehaviour
{
    [Header("特效")]
    public ParticleSystem particles;

    [Header("生成位置")]
    public Transform shootSource;
    public float spawnDistance = 2f;

    [Header("场景里已经做好的两个传送门")]
    public GameObject portalA;
    public GameObject portalB;

    private XRGrabInteractable grabInteractable;
    private bool nextSpawnIsA = true;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogError("没有 XRGrabInteractable！");
            enabled = false;
            return;
        }

        grabInteractable.activated.AddListener(OnActivated);
        grabInteractable.deactivated.AddListener(OnDeactivated);

        if (portalA != null) portalA.SetActive(false);
        if (portalB != null) portalB.SetActive(false);
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.activated.RemoveListener(OnActivated);
            grabInteractable.deactivated.RemoveListener(OnDeactivated);
        }
    }

    private void OnActivated(ActivateEventArgs args)
    {
        if (particles != null)
            particles.Play();

        SpawnPortal();
    }

    private void OnDeactivated(DeactivateEventArgs args)
    {
        if (particles != null)
        {
            particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    private void SpawnPortal()
    {
        if (shootSource == null)
        {
            Debug.LogError("shootSource 为 null");
            return;
        }

        GameObject currentPortalObj = nextSpawnIsA ? portalA : portalB;
        GameObject otherPortalObj = nextSpawnIsA ? portalB : portalA;

        if (currentPortalObj == null)
        {
            Debug.LogError("portalA / portalB 还没有拖到 Inspector");
            return;
        }

        // 生成在枪口前方
        Vector3 spawnPos = shootSource.position + shootSource.forward * spawnDistance;

        // 这里先用枪口朝向；如果你的门模型朝向不对，
        // 可以改成 Quaternion.LookRotation(-shootSource.forward, Vector3.up)
        Quaternion spawnRot = shootSource.rotation;

        currentPortalObj.transform.SetPositionAndRotation(spawnPos, spawnRot);
        currentPortalObj.SetActive(true);

        VRRelativePortal currentPortal = currentPortalObj.GetComponent<VRRelativePortal>();
        VRRelativePortal otherPortal = otherPortalObj != null ? otherPortalObj.GetComponent<VRRelativePortal>() : null;

        if (currentPortal == null)
        {
            Debug.LogError(currentPortalObj.name + " 上没有挂 VRRelativePortal");
            return;
        }

        // 如果另一个门已经存在，就互相绑定；否则当前门不能传送
        if (otherPortalObj != null && otherPortalObj.activeInHierarchy && otherPortal != null)
        {
            currentPortal.targetPortal = otherPortalObj.transform;
            otherPortal.targetPortal = currentPortalObj.transform;
        }
        else
        {
            currentPortal.targetPortal = null;
        }

        // 下一次切换到 A/B
        nextSpawnIsA = !nextSpawnIsA;
    }
}