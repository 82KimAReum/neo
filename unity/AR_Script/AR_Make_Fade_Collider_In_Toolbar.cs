using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AR_Make_Fade_Collider_In_Toolbar : AR_Toolbar
{
    public void OnGUI()
    {
        GUILayout.Label("페이드콜라이더", EditorStyles.boldLabel); 
        if (GUILayout.Button("적용 하기", EditorStyles.miniButtonMid))
        {
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                if (obj.transform.childCount > 0) continue;
                AR_Make_Fade_Collider.copy_Transform(obj.transform);
            }
        }
        //
        if (GUILayout.Button("셋팅삭제", EditorStyles.miniButtonMid))
        {
            //Debug.LogWarning("삭제버튼눌림");
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                if (obj.transform.childCount == 0)
                {
                    continue;
                }
                else if (obj.transform.childCount > 0)
                {
                    //AR_Make_Fade_Collider.copy_Transform(obj.transform);
                    AR_Delete_Fade_Collider.delete_Transform(obj.transform);
                    //Debug.LogWarning("자손있음");
                }
            }
        }

        GUILayout.Space(30);
        GUILayout.Label("커버페이드", EditorStyles.boldLabel);
        if (GUILayout.Button("적용 하기", EditorStyles.miniButtonMid))
        {
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                if (obj.transform.childCount > 0) continue;
                AR_Make_RemoveCover_Collider.copy_Transform(obj.transform);
            }
        }
        //
        if (GUILayout.Button("셋팅삭제", EditorStyles.miniButtonMid))
        {
            //Debug.LogWarning("삭제버튼눌림");
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                if (obj.transform.childCount == 0)
                {
                    continue;
                }
                else if (obj.transform.childCount > 0)
                {
                    //AR_Make_Fade_Collider.copy_Transform(obj.transform);
                    AR_Delete_RemoveCover_Collider.delete_Transform(obj.transform);
                    //Debug.LogWarning("자손있음");
                }
            }
        }
    }
}

class myfunc : AR_Toolbar
{
    private GameObject selectedObject;
    public myfunc()
    {
    }

    public void OnGUI()
    {
        // 오브젝트 필드를 생성하여 게임 오브젝트를 선택할 수 있게 합니다.
        selectedObject = EditorGUILayout.ObjectField(selectedObject, typeof(GameObject), true) as GameObject;


        if (GUILayout.Button("적용 하기", EditorStyles.miniButtonMid))
        {
            // 게임 오브젝트의 렌더러 컴포넌트를 가져옵니다.
            Renderer renderer = selectedObject.GetComponent<Renderer>();

            if (renderer != null)
            {
                // 게임 오브젝트의 머테리얼 배열을 가져옵니다.
                Material[] materials = renderer.sharedMaterials;

                foreach (Material material in materials)
                {
                    // 머테리얼의 이름을 출력합니다.
                    Debug.Log("머테리얼 이름: " + material.name);
                }
            }
            else
            {
                Debug.LogError("Renderer 컴포넌트를 찾을 수 없습니다.");
            }
        }

    }
}