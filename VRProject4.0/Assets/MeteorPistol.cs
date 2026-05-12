using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem particles;
    public LayerMask layerMask;
    public Transform shootSource;
    public float distance = 10f;

    private bool rayActivate = false;

    void Start()
    {
        Debug.Log("MeteorPistol Start");

        XRGrabInteractable grabInteractable =
            GetComponent<XRGrabInteractable>();

        if (grabInteractable == null)
        {
            Debug.LogError("没有 XRGrabInteractable !");
            return;
        }

        Debug.Log("XRGrabInteractable 找到了");

        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());

        if (particles == null)
            Debug.LogError("particles 没拖");

        if (shootSource == null)
            Debug.LogError("shootSource 没拖");
    }

    public void StartShoot()
    {
        Debug.Log("开始射击");

        rayActivate = true;

        if (particles != null)
            particles.Play();
    }

    public void StopShoot()
    {
        Debug.Log("停止射击");

        rayActivate = false;

        if (particles != null)
        {
            particles.Stop(
                true,
                ParticleSystemStopBehavior.StopEmittingAndClear
            );
        }
    }

    void Update()
    {
        if (rayActivate)
        {
            Debug.Log("正在发射 Ray");

            RayCastCheck();
        }
    }

    void RayCastCheck()
    {
        if (shootSource == null)
        {
            Debug.LogError("shootSource 为 null");
            return;
        }

        Debug.DrawRay(
            shootSource.position,
            shootSource.forward * distance,
            Color.red
        );

        if (Physics.Raycast(
            shootSource.position,
            shootSource.forward,
            out RaycastHit hit,
            distance,
            layerMask
        ))
        {
            Debug.Log("命中对象: " + hit.transform.name);
            Debug.Log("完整路径: " + GetFullPath(hit.transform));

            BreakableGlass glass = hit.collider.GetComponent<BreakableGlass>();
            if (glass != null)
            {
                glass.Break();
                return;
            }

            Breakable breakable = hit.collider.GetComponent<Breakable>();
            if (breakable != null)
            {
                Debug.Log("找到 Breakable");
                breakable.Break();
                return;
            }

            Debug.LogError("没找到可破坏组件");
        }
    }
    string GetFullPath(Transform current)
    {
        string path = current.name;

        while (current.parent != null)
        {
            current = current.parent;

            path = current.name + "/" + path;
        }

        return path;
    }
}