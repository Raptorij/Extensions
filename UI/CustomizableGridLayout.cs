using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizableGridLayout : MonoBehaviour
{
    public Vector2 cellSize = new Vector2(100, 100);
    public Vector2 spacing = new Vector2(0, 0);
    public RectOffset padding;
    public TextAnchor childAligment;
    public int maxCount;

    private void LateUpdate()
    {
        int children = transform.childCount;
        var childs =new List<Transform>();
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                childs.Add(transform.GetChild(i));
            }
        }

        float minX = GetComponent<RectTransform>().rect.xMin;
        float maxY = GetComponent<RectTransform>().rect.yMax - cellSize.y;
        var startPos = new Vector2(minX, maxY);

        int offset = 0;

        for (int i = 0; i < childs.Count; i++)
        {
            int row = i / maxCount;
            offset = row * maxCount;
            childs[i].localPosition = startPos + (cellSize / 2f) - row * cellSize.y * Vector2.up + (i - offset) * cellSize.x * Vector2.right;
            childs[i].GetComponent<RectTransform>().sizeDelta = cellSize;
        }

        var end = childs[childs.Count - 1].localPosition + (Vector3)cellSize / 2f + Vector3.up * cellSize.y;
        GetComponent<RectTransform>().sizeDelta = end;
    }
}
