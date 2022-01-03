/*
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestScript))]
public class TextAreaBoxEditor : Editor
{
    TestScript creator;

    Vector3 UpperLeftCorner;
    Vector3 LowerRightCorner;

    private void OnSceneGUI()
    {
        Draw();
    }

    private void Draw()
    {
        Handles.color = Color.red;
        Vector3 newPosUL = Handles.FreeMoveHandle(UpperLeftCorner, Quaternion.identity, 50f, Vector2.zero, Handles.CylinderHandleCap);
        Vector3 newPosLR = Handles.FreeMoveHandle(LowerRightCorner, Quaternion.identity, 50f, Vector2.zero, Handles.CylinderHandleCap);

        Undo.RecordObject(creator, "Move Point");
        creator.UpperLeftCorner = newPosUL;
        creator.LowerRightCorner = newPosLR;
    }

    private void OnEnable()
    {
        creator = (TestScript)target;
        UpperLeftCorner = creator.UpperLeftCorner;
        LowerRightCorner = creator.LowerRightCorner;
    }
}
*/