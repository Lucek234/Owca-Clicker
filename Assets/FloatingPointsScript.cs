using UnityEngine;
using UnityEngine.UI;

public class FloatingPointsScript : MonoBehaviour
{
    public float DeltaPos = 100;
    private float EndPos = 200;
    public float FloatTime = 10;
    private bool isDestroyed;

    // Update is called once per frame

    private float StartPos;
    private float timer;

    public RectTransform rectTransform => GetComponent<RectTransform>();

    // Start is called before the first frame update
    private void Start()
    {
        //UpdatePos(StartPos);
        StartPos = rectTransform.anchoredPosition.y;
        EndPos = StartPos + DeltaPos;
    }

    private void UpdatePos(float posVal)
    {
        var pos = rectTransform.anchoredPosition;
        pos.y = posVal;
        rectTransform.anchoredPosition = pos;
    }

    private void Update()
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