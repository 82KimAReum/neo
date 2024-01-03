using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AR_Animation_aply : AR_Toolbar
{
    private GameObject selectedObject;
    Vector3 rotation3 = new Vector3(0.0f, 0.0f, 0.0f);
    public void OnGUI()
    {
        rotation3 = EditorGUILayout.Vector3Field("Pivot Offset ", rotation3);
        GUILayout.Space(10f);
        GUILayout.Space(20);

        GUILayout.Label("�Ǻ��� �̵�", EditorStyles.boldLabel);
        if (GUILayout.Button("���� �ϱ�", EditorStyles.miniButtonMid))
        {
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {

                // ������Ʈ�� �ڽĵ��� ��� �����ɴϴ�.
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                // �� �ڽ� ������Ʈ�� ���ؼ� �̸��� �˻��մϴ�.
                foreach (Transform child in children)
                {
                    // �ڽ� ������Ʈ�� �̸��� "rotation"�� ���ԵǾ� �ִ��� Ȯ���մϴ�.
                    if (child.name.Contains("rotation"))
                    {
                        // "rotation"�� �����ϴ� �ڽ� ������Ʈ�� �ִٸ� ���⿡�� ���ϴ� �۾��� ������ �� �ֽ��ϴ�.
                        Debug.LogError("�ڽ� ������Ʈ �̸��� 'rotation'�� ���Ե� ������Ʈ�� ã�� �۾��� ���� �ʽ��ϴ�.: " + obj.name);
                    }
                    else
                    {
                        AR_Animation_aply_action.copy_Transform(obj.transform, rotation3);
                    }
                }
                //if (obj.transform.childCount > 0) continue;
                //AR_Animation_aply_action.copy_Transform(obj.transform);
            }
        }
        //
        if (GUILayout.Button("���û���", EditorStyles.miniButtonMid))
        {
            //Debug.LogWarning("������ư����");
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                //if (obj.transform.childCount == 0)
                //{
                //    continue;
                //}
                //else if (obj.transform.childCount > 0)
                //{
                //    //AR_Make_Fade_Collider.copy_Transform(obj.transform);
                //    AR_Delete_Fade_Collider.delete_Transform(obj.transform);
                //    //Debug.LogWarning("�ڼ�����");
                //}
                // ������Ʈ�� �ڽĵ��� ��� �����ɴϴ�.
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                // �� �ڽ� ������Ʈ�� ���ؼ� �̸��� �˻��մϴ�.
                foreach (Transform child in children)
                {
                    // �ڽ� ������Ʈ�� �̸��� "rotation"�� ���ԵǾ� �ִ��� Ȯ���մϴ�.
                    if (child.name.Contains("Rotation"))
                    {
                        //Debug.LogError("�����̼� �ڽ� ����. ��������. �ڽ��̸� " + child.name);
                        AR_Animation_delete_action._delete_action(obj.transform);
                        break;
                    }
                    else
                    {
                        
                    }
                    // "rotation"�� �����ϴ� �ڽ� ������Ʈ�� �ִٸ� ���⿡�� ���ϴ� �۾��� ������ �� �ֽ��ϴ�.
                    //Debug.LogError("�ڽ� ������Ʈ �̸��� 'rotation'�� ���Ե� ������Ʈ�� ���� �۾��� ���� �ʽ��ϴ�.: " + obj.name);
                }

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        GUILayout.Space(20);
        GUILayout.Label("�Ǻ� �̵�+ ����ȸ������������", EditorStyles.boldLabel);
        if (GUILayout.Button("���� �ϱ�", EditorStyles.miniButtonMid))
        {
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {

                // ������Ʈ�� �ڽĵ��� ��� �����ɴϴ�.
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                // �� �ڽ� ������Ʈ�� ���ؼ� �̸��� �˻��մϴ�.
                foreach (Transform child in children)
                {
                    // �ڽ� ������Ʈ�� �̸��� "rotation"�� ���ԵǾ� �ִ��� Ȯ���մϴ�.
                    if (child.name.Contains("rotation"))
                    {
                        // "rotation"�� �����ϴ� �ڽ� ������Ʈ�� �ִٸ� ���⿡�� ���ϴ� �۾��� ������ �� �ֽ��ϴ�.
                        Debug.LogError("�ڽ� ������Ʈ �̸��� 'rotation'�� ���Ե� ������Ʈ�� ã�� �۾��� ���� �ʽ��ϴ�.: " + obj.name);
                    }
                    else
                    {
                        AR_Animation_aply_action2.copy_Transform(obj.transform, rotation3);
                    }
                }
                //if (obj.transform.childCount > 0) continue;
                //AR_Animation_aply_action.copy_Transform(obj.transform);
            }
        }
        //
        if (GUILayout.Button("���û���", EditorStyles.miniButtonMid))
        {
            //Debug.LogWarning("������ư����");
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                //if (obj.transform.childCount == 0)
                //{
                //    continue;
                //}
                //else if (obj.transform.childCount > 0)
                //{
                //    //AR_Make_Fade_Collider.copy_Transform(obj.transform);
                //    AR_Delete_Fade_Collider.delete_Transform(obj.transform);
                //    //Debug.LogWarning("�ڼ�����");
                //}
                // ������Ʈ�� �ڽĵ��� ��� �����ɴϴ�.
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                // �� �ڽ� ������Ʈ�� ���ؼ� �̸��� �˻��մϴ�.
                foreach (Transform child in children)
                {
                    // �ڽ� ������Ʈ�� �̸��� "rotation"�� ���ԵǾ� �ִ��� Ȯ���մϴ�.
                    if (child.name.Contains("Rotation"))
                    {
                        //Debug.LogError("�����̼� �ڽ� ����. ��������. �ڽ��̸� " + child.name);
                        AR_Animation_delete_action2._delete_action(obj.transform);
                        break;
                    }
                    else
                    {

                    }
                    // "rotation"�� �����ϴ� �ڽ� ������Ʈ�� �ִٸ� ���⿡�� ���ϴ� �۾��� ������ �� �ֽ��ϴ�.
                    //Debug.LogError("�ڽ� ������Ʈ �̸��� 'rotation'�� ���Ե� ������Ʈ�� ���� �۾��� ���� �ʽ��ϴ�.: " + obj.name);
                }

            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////
        GUILayout.Space(20);
        GUILayout.Label("�Ǻ� �̵�+ ����ȸ������������+�ֻ�ܺθ� �����ϰ� ����", EditorStyles.boldLabel);
        if (GUILayout.Button("���� �ϱ�", EditorStyles.miniButtonMid))
        {
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {

                // ������Ʈ�� �ڽĵ��� ��� �����ɴϴ�.
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                // �� �ڽ� ������Ʈ�� ���ؼ� �̸��� �˻��մϴ�.
                foreach (Transform child in children)
                {
                    // �ڽ� ������Ʈ�� �̸��� "rotation"�� ���ԵǾ� �ִ��� Ȯ���մϴ�.
                    if (child.name.Contains("Rotation"))
                    {
                        // "rotation"�� �����ϴ� �ڽ� ������Ʈ�� �ִٸ� ���⿡�� ���ϴ� �۾��� ������ �� �ֽ��ϴ�.
                        Debug.LogError("�ڽ� ������Ʈ �̸��� 'rotation'�� ���Ե� ������Ʈ�� ã�� �۾��� ���� �ʽ��ϴ�.: " + obj.name);
                    }
                    else
                    {
                        AR_Animation_aply_action3.copy_Transform(obj.transform, rotation3);
                    }
                }
                //if (obj.transform.childCount > 0) continue;
                //AR_Animation_aply_action.copy_Transform(obj.transform);
            }
        }
        //
        if (GUILayout.Button("���û���", EditorStyles.miniButtonMid))
        {
            //Debug.LogWarning("������ư����");
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                //if (obj.transform.childCount == 0)
                //{
                //    continue;
                //}
                //else if (obj.transform.childCount > 0)
                //{
                //    //AR_Make_Fade_Collider.copy_Transform(obj.transform);
                //    AR_Delete_Fade_Collider.delete_Transform(obj.transform);
                //    //Debug.LogWarning("�ڼ�����");
                //}
                // ������Ʈ�� �ڽĵ��� ��� �����ɴϴ�.
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                // �� �ڽ� ������Ʈ�� ���ؼ� �̸��� �˻��մϴ�.
                foreach (Transform child in children)
                {
                    // �ڽ� ������Ʈ�� �̸��� "rotation"�� ���ԵǾ� �ִ��� Ȯ���մϴ�.
                    if (child.name.Contains("Rotation"))
                    {
                        //Debug.LogError("�����̼� �ڽ� ����. ��������. �ڽ��̸� " + child.name);
                        AR_Animation_delete_action3._delete_action(obj.transform);
                        break;
                    }
                    else
                    {

                    }
                    // "rotation"�� �����ϴ� �ڽ� ������Ʈ�� �ִٸ� ���⿡�� ���ϴ� �۾��� ������ �� �ֽ��ϴ�.
                    //Debug.LogError("�ڽ� ������Ʈ �̸��� 'rotation'�� ���Ե� ������Ʈ�� ���� �۾��� ���� �ʽ��ϴ�.: " + obj.name);
                }

            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////
        GUILayout.Space(20);
        GUILayout.Label("���� ������Ʈ -> Ʈ��������Ʈ ������ �ֱ�", EditorStyles.boldLabel);
        
        selectedObject = EditorGUILayout.ObjectField(selectedObject, typeof(GameObject), true) as GameObject;

        if (GUILayout.Button("���� �ϱ�", EditorStyles.miniButtonMid))
        {
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                AR_Make_Child_aply_action.copy_Transform(obj.transform, selectedObject);
            }
        }
        //
        if (GUILayout.Button("�ڽĻ���", EditorStyles.miniButtonMid))
        {
            //Debug.LogWarning("������ư����");
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                AR_Make_Child_delete_action._delete_action(obj.transform);

                

            }
        }

    }



}