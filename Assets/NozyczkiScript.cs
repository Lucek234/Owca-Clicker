using UnityEngine;

public class NozyczkiScript : MonoBehaviour
{
    public float CutTime = 0.5f;
    public float EndPos = 300;
    private bool isDestroyed;

    public float StartPos = -300;

    private float timer;

    private RectTransform rectTransform => GetComponent<RectTransform>();

    // Start is called before the first frame update
    private void Start()
    {
        UpdatePos(StartPos);
    }


    private void UpdatePos(float x)
    {
        var pos = rectTransform.anchoredPosition;
        pos.x = x;
        rectTransform.anchoredPosition = pos;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDestroyed) return;
        timer += Time.deltaTime;
        var alpha = timer / CutTime;
        var currentPos = StartPos + (EndPos - StartPos) * alpha;
        UpdatePos(currentPos);

        if (alpha > 1)
        {
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}