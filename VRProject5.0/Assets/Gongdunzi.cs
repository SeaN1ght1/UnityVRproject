using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Gongdunzi : MonoBehaviour
{
    private float CurrentTime;

    private bool IsMove = false;

    public float FontMoveSpeed = 5;
    // Start is called before the first frame update
    void Awake()
    {
        this.transform.localPosition = new Vector3(0, -3500, 0);
    }

    // Update is called once per frame
    void Update()
    {
        FontMoveUp();
    }
    private void FontMoveUp()
    {
        CurrentTime += Time.deltaTime;
        if (CurrentTime >= 0.2f && this.transform.localPosition.y < 3500)
        {
            float y = this.transform.localPosition.y;
            this.transform.localPosition = new Vector3(0, y + FontMoveSpeed, 0);
            IsMove = true;

        }
        if (IsMove == true)
        {
            CurrentTime = 0;
            IsMove = false;
        }

    }

}
