using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDimensions : MonoBehaviour
{
    [SerializeField] RectTransform upperLeft;
    [SerializeField] RectTransform bottomRight;
    
    public Vector2 Dimensions
    {
        get
        {
            float x = bottomRight.position.x - upperLeft.position.x;
            float y = upperLeft.position.y - bottomRight.position.y;
            return (new Vector2(x,y));
        }
    }
}
