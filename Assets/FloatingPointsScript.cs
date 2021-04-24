using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloatingPointsScript : MonoBehaviour
{

    public RectTransform rectTransform => GetComponent<RectTransform>();

    // Start is called before the first frame update
    void Start()
    {
        //UpdatePos(StartPos);
        StartPos = rectTransform.anchoredPosition.y;
        EndPos = StartPos + DeltaPos;
    }

    // Update is called once per frame

    float StartPos = 0;
    float EndPos = 200;
    public float DeltaPos = 100;
    public float FloatTime = 10;
    float timer = 0;
    bool isDestroyed = false;

    void UpdatePos(float posVal)
    {
        var pos = rectTransform.anchoredPosition;
        pos.y = posVal;
        rectTransform.anchoredPosition = pos;

    }

    void Update()
    {
        if (isDestroyed) return;
        timer += Time.deltaTime;
        var alpha = timer / FloatTime;
        alpha *= alpha;
        var currentPos = StartPos + (EndPos - StartPos) * alpha;

        var color = GetComponent<Text>().color;
        color.a = 1 - alpha;
        GetComponent<Text>().color = color;

        UpdatePos(currentPos);

        if (alpha > 1)
        {
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
