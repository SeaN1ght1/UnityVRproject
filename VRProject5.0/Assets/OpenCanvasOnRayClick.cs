using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]
public class OpenCanvasOnRayClick : MonoBehaviour
{
    [Header("要打开的 Canvas")]
    [SerializeField] private GameObject canvasRoot;

    [Header("是否点击切换 Canvas")]
    [SerializeField] private bool toggleCanvas = false;

    private XRSimpleInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        if (canvasRoot != null && !toggleCanvas)
        {
            canvasRoot.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelected);
        }
    }

    private void OnDisable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelected);
        }
    }

    private void OnSelected(SelectEnterEventArgs args)
    {
        Debug.Log("点击到了物体");

        if (canvasRoot == null)
            return;

        if (toggleCanvas)
        {
            canvasRoot.SetActive(!canvasRoot.activeSelf);
        }
        else
        {
            canvasRoot.SetActive(true);
        }
    }
}