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
    public string objectBaseName = "Object"; // ���� ������ ������Ʈ�� �⺻ �̸�
    public static bool copy_Transform(Transform selectedTransform, GameObject toBechild)
        
    // ��ġ�� �׷� copiedObject
    // �ִ� emptyAni
    // ���� selectedTransform
    {
        //selectedObject = EditorGUILayout.ObjectField(selectedObject, typeof(GameObject), true) as GameObject;
        
       // worldPosition = selectedTransform.position;

        // ���� �����ؼ� ��ġ�� �׷� ����
        GameObject copiedObject = Instantiate(toBechild.gameObject);
        copiedObject.transform.position= selectedTransform.position;
        copiedObject.transform.rotation = selectedTransform.rotation;
        copiedObject.transform.localScale = selectedTransform.localScale;


        // ���� �̸� ����
        //string numbering = ExtractNumbering(selectedTransform.name);
        copiedObject.name = selectedTransform.gameObject.name ;

        // ���õ� ���� ������Ʈ�� �θ�
        Transform parentTransform = selectedTransform.transform.parent;
        // �ڽ��� �θ� ���õ� ���� ������Ʈ�� �θ�� ����
        copiedObject.transform.SetParent(parentTransform);


        // ���õ� ������Ʈ�� �����մϴ�.
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
