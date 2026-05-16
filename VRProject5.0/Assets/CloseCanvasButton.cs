using UnityEngine;

public class CloseCanvasButton : MonoBehaviour
{
    [Header("需要关闭的Canvas")]
    public GameObject canvasObject;

    public void CloseCanvas()
    {
        if (canvasObject != null)
        {
            canvasObject.SetActive(false);
        }
    }
}