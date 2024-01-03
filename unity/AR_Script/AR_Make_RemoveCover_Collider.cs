using UnityEditor; //�� �κи� �߰����ش�.
using UnityEngine;

public class AR_Make_RemoveCover_Collider : MonoBehaviour
{
    // �޴�â�� �߰�
    //[MenuItem("Tools/AR/Make Fade Collider", false, 0)]
    private static void AR_Make_RemoveCover_ColliderCommand(MenuCommand menuCommand)
    {
        // ������ ������Ʈ
        Transform[] selectedTransforms = Selection.transforms;

        // ���õ� ���� ������ ����
        if (selectedTransforms.Length == 0) return;
        foreach (Transform selectedTransform in selectedTransforms)
        {
            if (selectedTransform.childCount > 0) continue;
            copy_Transform(selectedTransform);
        }
    }

    public static bool copy_Transform(Transform selectedTransform)
    {
        //������ Ŀ������ ��ũ��Ʈ �߰� 
        insert_C_ObjRemoveCoverScript(selectedTransform);
        check_meshMaterials(selectedTransform);//���׸��� cover_meterial�� ����

        // ������Ʈ ����
        GameObject copiedObject = Instantiate(selectedTransform.gameObject, selectedTransform.parent);

        // ���� �̸� ����
        //copiedObject.name = selectedTransform.gameObject.name + " (Copy)";
        copiedObject.name = "Range";

        // ������ �θ� ����
        copiedObject.transform.SetParent(selectedTransform.transform);

        // Range�� �ڽ� �ݶ��̴� �߰�
        BoxCollider boxCollider = copiedObject.GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            boxCollider = copiedObject.AddComponent<BoxCollider>();
        }

        // ������ ����
        //copiedObject.transform.localPosition = new Vector3(0, 0, 0.5f);

        if (boxCollider != null)
        {

            // Is Trigger ���� true�� ����
            boxCollider.isTrigger = true;
        }
        else
        {
            //Debug.LogWarning("Box Collider ������Ʈ�� ã�� �� �����ϴ�.");
        }

        // Range�� MeshRenderer ������Ʈ ��������
        MeshRenderer[] meshRenderers = copiedObject.gameObject.GetComponentsInChildren<MeshRenderer>();

        // ������ MeshRenderer ������Ʈ ����
        foreach (MeshRenderer renderer in meshRenderers)
        {
            DestroyImmediate(renderer);
        }

        // Range�� MeshFilter ������Ʈ ��������
        MeshFilter meshFilter = copiedObject.gameObject.GetComponent<MeshFilter>();

        // ������ MeshFilter ������Ʈ ����
        if (meshFilter != null)
        {
            DestroyImmediate(meshFilter);
        }

        // ������Ʈ�� ���̾ 'UI'�� ����
        copiedObject.layer = LayerMask.NameToLayer("Range");//Range�� �����Ұ�!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        //
        insert_CRangeTrigger(copiedObject);

        delete_C_ObjRemoveCoverScript(copiedObject);
        delete_mesh_componenet(copiedObject);

        insert_C_ObjRemoveCover_range(selectedTransform);
        

        return true;
    }


    static void insert_CRangeTrigger(GameObject obj)
    {
        CRangeTrigger crt = obj.AddComponent<CRangeTrigger>();
        //crt.ins_emActType = EmPoolType.Size;
        //crt.ins_emRangeType = CRange.EmRangeType.Size;
        //crt.ins_emColRangeType = CRange.EmColliderType.Box;
        crt.ins_emActType = EmPoolType.Emotion;
        crt.ins_emRangeType = CRange.EmRangeType.Alert;
        crt.ins_emColRangeType = CRange.EmColliderType.Box;

        crt.m_fStopOffset = 0;
        // ���Ǿ� �����¿� ���� ������ ���µ� ���� ������ �� ��� �µ� .
        // �ϰ� Ȯ�� 
    }

    static void delete_C_ObjRemoveCoverScript(GameObject obj)
    {
        // "C Obj Fade" ��ũ��Ʈ ������Ʈ ����
        //CObjFade objFadeComponent = obj.GetComponent<CObjFade>();
        //if (objFadeComponent != null)
        //{
        //    DestroyImmediate(objFadeComponent);
        //}
        //else
        //{
        //    Debug.LogWarning("C Obj Fade ������Ʈ�� ã�� �� �����ϴ�.");
        //}

        CObjRemoveCover objRemoveComponent = obj.GetComponent<CObjRemoveCover>();
        if (objRemoveComponent != null)
        {
            DestroyImmediate(objRemoveComponent);
        }
        else
        {
            //Debug.LogWarning("C Obj Fade ������Ʈ�� ã�� �� �����ϴ�.");
        }

    }

    static void insert_C_ObjRemoveCoverScript(Transform obj)
    {//�θ𿡰� C_ObjFade �������� ���̰� , ins_rnaderer������


        delete_C_ObjRemoveCoverScript(obj.gameObject);

        CObjRemoveCover crc = obj.gameObject.AddComponent<CObjRemoveCover>();
        crc.ins_Renderer = obj.gameObject.GetComponentsInChildren<MeshRenderer>();
    }


    static void insert_C_ObjRemoveCover_range(Transform obj)
    {
        CObjRemoveCover crt = obj.GetComponent<CObjRemoveCover>();

        foreach (Transform child in obj)
        {
            if (child.name == "Range")
            {
                CRangeTrigger crt2 = child.GetComponent<CRangeTrigger>();
                crt.ins_scrRange = crt2;
            }

        }
    }


    static void delete_mesh_componenet(GameObject obj)
    {
        //�޽��ݶ��̴� ����
        MeshCollider meshCollider = obj.GetComponent<MeshCollider>();
        if (meshCollider != null)
        {
            DestroyImmediate(meshCollider);
        }
        else
        {
            Debug.LogWarning("meshCollider ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    static void check_meshMaterials(Transform obj)
    {
        //���͸��� ���̵����� Ȯ���� �ƴϸ� ����

        // ���õ� ��ü�� MeshRenderer ������Ʈ�� �ִ��� Ȯ��
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            // MeshRenderer�� �����ϸ� ù ��° Shared Material ��������
            Material sharedMaterial = meshRenderer.sharedMaterial;

            // Shared Material �̸� ���� "fade"�� ���ԵǾ� �ִ��� Ȯ��
            if (sharedMaterial.name.ToLower().StartsWith("cover"))
            {
                //Debug.Log("������Ʈ �̸��� 'cover'�� �����մϴ�.");
            }
            else
            {
                Debug.Log(obj.name+" ���͸����� 'cover'�� �������� �ʽ��ϴ�. ����: "+ sharedMaterial.name);
                // ���õ� ��ü�� Shared Material �̸��� "cover" �߰��� Material�� �ִ��� �˻�
                string newMaterialName = "cover_material";
                Material newMaterial = FindMaterialInScene(newMaterialName);

                if (newMaterial != null)
                {
                    meshRenderer.material = newMaterial;
                    Debug.Log(obj.name + " cover���͸���� ����� ��");
                }
                else
                {

                    Debug.LogError(obj.name + " cover���͸���� ����� ����");
                }
            }
        }
        else
        {
            Debug.Log(obj.name + "�ش������Ʈ�� �޽÷������� �����ϴ�. ");
        }
    
}

    // ������ �̸��� �´� Material�� �˻��ϴ� �Լ�
    static Material FindMaterialInScene(string materialName)
    {
        Material[] allMaterials = Resources.FindObjectsOfTypeAll<Material>();

        foreach (Material mat in allMaterials)
        {
            if (mat.name == materialName)
            {
                return mat;
            }
        }

        return null;
    }

}
