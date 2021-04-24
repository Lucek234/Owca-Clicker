using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NozyczkiScript : MonoBehaviour
{
    RectTransform rectTransform =>        GetComponent<RectTransform>();
    // Start is called before the first frame update
    void Start()
    {
        UpdatePos(StartPos);
    }


    void UpdatePos(float x)
    {
        var pos = rectTransform.anchoredPosition;
        pos.x = x;
        rectTransform.anchoredPosition = pos;
    }

    public float StartPos = -300;
    public float EndPos = 300;
    public float CutTime = 0.5f;

    float timer = 0;
    bool isDestroyed = false;

    // Update is called once per frame
    void Update()
    {
        if (isDestroyed) return;
        timer += Time.deltaTime;
        var alpha = timer / CutTime;
        var currentPos = StartPos +  (EndPos - StartPos)* alpha;
        UpdatePos(currentPos);

        if (alpha > 1)
        {
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
