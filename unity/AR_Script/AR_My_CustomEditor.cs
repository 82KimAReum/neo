using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.IMGUI.Controls;

public class MyCustomEditor : EditorWindow
{
    private AR_Toolbar_Manager toolbar_Manager;
    private AR_TreeView_Manager treeView_Manager;

    /// <summary>
    /// (기본함수) 창을 열때 호출되는 함수 
    /// </summary>
    [MenuItem("Tools/AR/AR 커스텀 에디터")]
    public static void ShowMyEditor()
    {
        // This method is called when the user selects the menu item in the Editor
        EditorWindow wnd = GetWindow<MyCustomEditor>();
        wnd.titleContent = new GUIContent("Made by AR");

        // 창의 크기
        wnd.minSize = new Vector2(450, 200);
        wnd.maxSize = new Vector2(1920, 720);
    }

    /// <summary>
    /// (기본함수) 창을 열때 호출되는 함수 
    /// </summary>
    private void OnEnable()
    {
        // 트리뷰를 생성한다.
        treeView_Manager = new AR_TreeView_Manager("트랜스폼 목록");

        // 전역 변수로 등록.
        AR_Left_Area.treeView_Manager = treeView_Manager;

        // 툴바를 생성한다.
        string[] toolbar_names = {"toolbar1", "toolbar2", "toolbar3", "내 함수", "페이드 콜라이더", "애니"};
        AR_Toolbar[] toolbars = {
            new AR_Toolbar_1(),
            new AR_Toolbar_2(),
            new AR_Toolbar_3(),
            new myfunc(),
            new AR_Make_Fade_Collider_In_Toolbar(),
            new AR_Animation_aply()
        };
        toolbar_Manager = new AR_Toolbar_Manager(toolbar_names, toolbars);
    }

    /// <summary>
    /// (기본 함수)이벤트가 발생할 때마다 호출된다.
    /// </summary>
    private void OnGUI()
    {
        // 트리 뷰 표시 (왼쪽 화면)
        Rect treeViewRect = new Rect(6, 11, Screen.width * 0.4f, Screen.height - 35);
        treeView_Manager.OnGUI(treeViewRect);

        // 툴바 화면 (오른쪽 화면)
        Rect toolBarRect = new Rect(Screen.width * 0.4f + 20, 11, Screen.width - (Screen.width * 0.4f + 20) - 11, Screen.height - 35);
        toolbar_Manager.OnGUI(toolBarRect);
    }
}

// 그냥 전역 변수임
static class AR_Left_Area
{
    static public AR_TreeView_Manager treeView_Manager;
}