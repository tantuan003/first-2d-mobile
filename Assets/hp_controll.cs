using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_controll : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform foregroundTransform; // Thanh máu phía trước
    public RectTransform backgroundTransform;
    private float originalWidth;
    void Start()
    {
        originalWidth = backgroundTransform.sizeDelta.x;
        foregroundTransform.pivot = new Vector2(0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealth(float healthPercentage)
    {
        foregroundTransform.sizeDelta = new Vector2(originalWidth * healthPercentage, foregroundTransform.sizeDelta.y);
    }
}
