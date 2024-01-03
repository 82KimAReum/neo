using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Animation_delete_action3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private static Quaternion savedRotation;
    public static void _delete_action(Transform selectedTransform)
    {


        // 선택된 오브젝트가 null이 아니면
        if (selectedTransform != null)
        {
            // 오브젝트의 자식들을 가져옵니다.
            Transform[] childTransforms = selectedTransform.GetComponentsInChildren<Transform>();
            // 선택된 게임 오브젝트의 부모
            Transform parentTransform = selectedTransform.transform.parent;


            //foreach (Transform child in childTransforms)
            //{
            //    if (child != selectedTransform.transform && child.name.Contains("Rotation"))
                   
            //    {
            //        savedRotation = child.localRotation;
            //    }

            //}
            foreach (Transform child in childTransforms)
            {
                if (child != selectedTransform.transform && !child.name.Contains("Rotation") && savedRotation != null)
                {
                    // 자식의 부모를 선택된 게임 오브젝트의 부모로 설정
                    child.SetParent(parentTransform);

                    // 월드 위치를 유지하도록 로컬 위치를 조정 + 회전값 원복
                    //child.localPosition = selectedTransform.localPosition;
                    //child.localRotation= savedRotation;

                }

            }


            // 선택된 오브젝트를 삭제합니다.
            DestroyImmediate(selectedTransform.gameObject);

            // 자식 오브젝트들은 그대로 남습니다.
            Debug.Log("선택된 오브젝트가 삭제되었습니다. 자식 오브젝트는 그대로 남습니다.");

            // 선택된 오브젝트를 null로 설정하여 인스펙터에서 연결을 끊을 수 있도록 합니다.
            selectedTransform = null;
        }
        else
        {
            Debug.LogError("삭제하려는 오브젝트가 지정되지 않았습니다.");
        }
    }

}
