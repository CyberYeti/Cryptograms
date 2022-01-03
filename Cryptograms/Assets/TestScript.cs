using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    RectTransform upperLeftCorner;
    RectTransform lowerRightCorner;

    TextBlock textBlock;

    public Vector3 UpperLeftCorner
    {
        get { return upperLeftCorner.position; }
        set { upperLeftCorner.position = value; }
    }
    public Vector3 LowerRightCorner
    {
        get { return lowerRightCorner.position; }
        set { lowerRightCorner.position = value; }
    }

    
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);

        textBlock = GetComponentInChildren<TextBlock>();
        textBlock.Text = "Apple sause is cool!";
    }
    
    /*
    private void OnDrawGizmosSelected()
    {
        Vector3 ul = upperLeftCorner.position;
        Vector3 lr = lowerRightCorner.position;
        Gizmos.DrawLine(ul, new Vector3(ul.x, lr.y, ul.z));
        Gizmos.DrawLine(ul, new Vector3(lr.x, ul.y, ul.z));
        Gizmos.DrawLine(lr, new Vector3(ul.x, lr.y, ul.z));
        Gizmos.DrawLine(lr, new Vector3(lr.x, ul.y, ul.z));

        
    }
    */
}
