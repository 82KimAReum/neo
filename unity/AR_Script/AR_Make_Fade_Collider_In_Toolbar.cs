using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AR_Make_Fade_Collider_In_Toolbar : AR_Toolbar
{
    public void OnGUI()
    {
        GUILayout.Label("���̵��ݶ��̴�", EditorStyles.boldLabel); 
        if (GUILayout.Button("���� �ϱ�", EditorStyles.miniButtonMid))
        {
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                if (obj.transform.childCount > 0) continue;
                AR_Make_Fade_Collider.copy_Transform(obj.transform);
            }
        }
        //
        if (GUILayout.Button("���û���", EditorStyles.miniButtonMid))
        {
            //Debug.LogWarning("������ư����");
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
                    //Debug.LogWarning("�ڼ�����");
                }
            }
        }

        GUILayout.Space(30);
        GUILayout.Label("Ŀ�����̵�", EditorStyles.boldLabel);
        if (GUILayout.Button("���� �ϱ�", EditorStyles.miniButtonMid))
        {
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                if (obj.transform.childCount > 0) continue;
                AR_Make_RemoveCover_Collider.copy_Transform(obj.transform);
            }
        }
        //
        if (GUILayout.Button("���û���", EditorStyles.miniButtonMid))
        {
            //Debug.LogWarning("������ư����");
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
                    //Debug.LogWarning("�ڼ�����");
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
        // ������Ʈ �ʵ带 �����Ͽ� ���� ������Ʈ�� ������ �� �ְ� �մϴ�.
        selectedObject = EditorGUILayout.ObjectField(selectedObject, typeof(GameObject), true) as GameObject;


        if (GUILayout.Button("���� �ϱ�", EditorStyles.miniButtonMid))
        {
            // ���� ������Ʈ�� ������ ������Ʈ�� �����ɴϴ�.
            Renderer renderer = selectedObject.GetComponent<Renderer>();

            if (renderer != null)
            {
                // ���� ������Ʈ�� ���׸��� �迭�� �����ɴϴ�.
                Material[] materials = renderer.sharedMaterials;

                foreach (Material material in materials)
                {
                    // ���׸����� �̸��� ����մϴ�.
                    Debug.Log("���׸��� �̸�: " + material.name);
                }
            }
            else
            {
                Debug.LogError("Renderer ������Ʈ�� ã�� �� �����ϴ�.");
            }
        }

    }
}