using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;

public class AR_Make_Child_aply_action : MonoBehaviour
{
    // Start is called before the first frame update

    //private GameObject selectedObject;
    //private static Vector3 worldPosition;
    public string objectBaseName = "Object"; // 새로 생성될 오브젝트의 기본 이름
    public static bool copy_Transform(Transform selectedTransform, GameObject toBechild)
        
    // 위치값 그룹 copiedObject
    // 애니 emptyAni
    // 원본 selectedTransform
    {
        //selectedObject = EditorGUILayout.ObjectField(selectedObject, typeof(GameObject), true) as GameObject;
        
       // worldPosition = selectedTransform.position;

        // 원본 복사해서 위치값 그룹 생성
        GameObject copiedObject = Instantiate(toBechild.gameObject);
        copiedObject.transform.position= selectedTransform.position;
        copiedObject.transform.rotation = selectedTransform.rotation;
        copiedObject.transform.localScale = selectedTransform.localScale;


        // 복사 이름 설정
        //string numbering = ExtractNumbering(selectedTransform.name);
        copiedObject.name = selectedTransform.gameObject.name ;

        // 선택된 게임 오브젝트의 부모
        Transform parentTransform = selectedTransform.transform.parent;
        // 자식의 부모를 선택된 게임 오브젝트의 부모로 설정
        copiedObject.transform.SetParent(parentTransform);


        // 선택된 오브젝트를 삭제합니다.
        DestroyImmediate(selectedTransform.gameObject);


        return true;
    }
    static string ExtractNumbering(string input)
    {  
        System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(input, @"\d+");
        if (match.Success)
        {
            return match.Value;
        }

        return null;
    }
}
