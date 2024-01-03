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

        GUILayout.Label("피봇만 이동", EditorStyles.boldLabel);
        if (GUILayout.Button("적용 하기", EditorStyles.miniButtonMid))
        {
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {

                // 오브젝트의 자식들을 모두 가져옵니다.
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                // 각 자식 오브젝트에 대해서 이름을 검사합니다.
                foreach (Transform child in children)
                {
                    // 자식 오브젝트의 이름에 "rotation"이 포함되어 있는지 확인합니다.
                    if (child.name.Contains("rotation"))
                    {
                        // "rotation"을 포함하는 자식 오브젝트가 있다면 여기에서 원하는 작업을 수행할 수 있습니다.
                        Debug.LogError("자식 오브젝트 이름에 'rotation'이 포함된 오브젝트를 찾아 작업을 하지 않습니다.: " + obj.name);
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
        if (GUILayout.Button("셋팅삭제", EditorStyles.miniButtonMid))
        {
            //Debug.LogWarning("삭제버튼눌림");
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
                //    //Debug.LogWarning("자손있음");
                //}
                // 오브젝트의 자식들을 모두 가져옵니다.
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                // 각 자식 오브젝트에 대해서 이름을 검사합니다.
                foreach (Transform child in children)
                {
                    // 자식 오브젝트의 이름에 "rotation"이 포함되어 있는지 확인합니다.
                    if (child.name.Contains("Rotation"))
                    {
                        //Debug.LogError("로테이션 자식 포함. 삭제실행. 자식이름 " + child.name);
                        AR_Animation_delete_action._delete_action(obj.transform);
                        break;
                    }
                    else
                    {
                        
                    }
                    // "rotation"을 포함하는 자식 오브젝트가 있다면 여기에서 원하는 작업을 수행할 수 있습니다.
                    //Debug.LogError("자식 오브젝트 이름에 'rotation'이 포함된 오브젝트가 없어 작업을 하지 않습니다.: " + obj.name);
                }

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        GUILayout.Space(20);
        GUILayout.Label("피봇 이동+ 원본회전값가져오기", EditorStyles.boldLabel);
        if (GUILayout.Button("적용 하기", EditorStyles.miniButtonMid))
        {
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {

                // 오브젝트의 자식들을 모두 가져옵니다.
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                // 각 자식 오브젝트에 대해서 이름을 검사합니다.
                foreach (Transform child in children)
                {
                    // 자식 오브젝트의 이름에 "rotation"이 포함되어 있는지 확인합니다.
                    if (child.name.Contains("rotation"))
                    {
                        // "rotation"을 포함하는 자식 오브젝트가 있다면 여기에서 원하는 작업을 수행할 수 있습니다.
                        Debug.LogError("자식 오브젝트 이름에 'rotation'이 포함된 오브젝트를 찾아 작업을 하지 않습니다.: " + obj.name);
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
        if (GUILayout.Button("셋팅삭제", EditorStyles.miniButtonMid))
        {
            //Debug.LogWarning("삭제버튼눌림");
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
                //    //Debug.LogWarning("자손있음");
                //}
                // 오브젝트의 자식들을 모두 가져옵니다.
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                // 각 자식 오브젝트에 대해서 이름을 검사합니다.
                foreach (Transform child in children)
                {
                    // 자식 오브젝트의 이름에 "rotation"이 포함되어 있는지 확인합니다.
                    if (child.name.Contains("Rotation"))
                    {
                        //Debug.LogError("로테이션 자식 포함. 삭제실행. 자식이름 " + child.name);
                        AR_Animation_delete_action2._delete_action(obj.transform);
                        break;
                    }
                    else
                    {

                    }
                    // "rotation"을 포함하는 자식 오브젝트가 있다면 여기에서 원하는 작업을 수행할 수 있습니다.
                    //Debug.LogError("자식 오브젝트 이름에 'rotation'이 포함된 오브젝트가 없어 작업을 하지 않습니다.: " + obj.name);
                }

            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////
        GUILayout.Space(20);
        GUILayout.Label("피봇 이동+ 원본회전값가져오기+최상단부모가 스케일값 갖기", EditorStyles.boldLabel);
        if (GUILayout.Button("적용 하기", EditorStyles.miniButtonMid))
        {
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {

                // 오브젝트의 자식들을 모두 가져옵니다.
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                // 각 자식 오브젝트에 대해서 이름을 검사합니다.
                foreach (Transform child in children)
                {
                    // 자식 오브젝트의 이름에 "rotation"이 포함되어 있는지 확인합니다.
                    if (child.name.Contains("Rotation"))
                    {
                        // "rotation"을 포함하는 자식 오브젝트가 있다면 여기에서 원하는 작업을 수행할 수 있습니다.
                        Debug.LogError("자식 오브젝트 이름에 'rotation'이 포함된 오브젝트를 찾아 작업을 하지 않습니다.: " + obj.name);
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
        if (GUILayout.Button("셋팅삭제", EditorStyles.miniButtonMid))
        {
            //Debug.LogWarning("삭제버튼눌림");
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
                //    //Debug.LogWarning("자손있음");
                //}
                // 오브젝트의 자식들을 모두 가져옵니다.
                Transform[] children = obj.GetComponentsInChildren<Transform>();
                // 각 자식 오브젝트에 대해서 이름을 검사합니다.
                foreach (Transform child in children)
                {
                    // 자식 오브젝트의 이름에 "rotation"이 포함되어 있는지 확인합니다.
                    if (child.name.Contains("Rotation"))
                    {
                        //Debug.LogError("로테이션 자식 포함. 삭제실행. 자식이름 " + child.name);
                        AR_Animation_delete_action3._delete_action(obj.transform);
                        break;
                    }
                    else
                    {

                    }
                    // "rotation"을 포함하는 자식 오브젝트가 있다면 여기에서 원하는 작업을 수행할 수 있습니다.
                    //Debug.LogError("자식 오브젝트 이름에 'rotation'이 포함된 오브젝트가 없어 작업을 하지 않습니다.: " + obj.name);
                }

            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////
        GUILayout.Space(20);
        GUILayout.Label("보기 오브젝트 -> 트리오브젝트 하위에 넣기", EditorStyles.boldLabel);
        
        selectedObject = EditorGUILayout.ObjectField(selectedObject, typeof(GameObject), true) as GameObject;

        if (GUILayout.Button("적용 하기", EditorStyles.miniButtonMid))
        {
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                AR_Make_Child_aply_action.copy_Transform(obj.transform, selectedObject);
            }
        }
        //
        if (GUILayout.Button("자식삭제", EditorStyles.miniButtonMid))
        {
            //Debug.LogWarning("삭제버튼눌림");
            var ObjectList = AR_Left_Area.treeView_Manager.ObjectList;

            foreach (var obj in ObjectList)
            {
                AR_Make_Child_delete_action._delete_action(obj.transform);

                

            }
        }

    }



}