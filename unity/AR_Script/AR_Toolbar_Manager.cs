using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AR_Toolbar_Manager
{
    // 툴바 관련
    int toolbarIndex = 0;
    string[] AR_toolbar_Names;
    AR_Toolbar[] AR_toolbars;

    public AR_Toolbar_Manager(string[] AR_toolbar_Names, AR_Toolbar[] AR_toolbars)
    {
        this.AR_toolbar_Names = AR_toolbar_Names;
        this.AR_toolbars = AR_toolbars;
        if (AR_toolbar_Names.Length != AR_toolbars.Length)
        {
            bool result = EditorUtility.DisplayDialog("경고!", "AR_toolbar_Names\nAR_toolbars\n갯수를 통일해 주세요", "OK");
        }
        

    }

    public void OnGUI(Rect treeViewRect)
    {
        //using (var areaScope = new GUILayout.AreaScope(treeViewRect))
        //{
        //    toolbarIndex = GUILayout.Toolbar(toolbarIndex, AR_toolbar_Names);
        //    AR_toolbars[toolbarIndex].OnGUI();
        //}
        using (var areaScope = new GUILayout.AreaScope(treeViewRect))
        {
            GUILayout.BeginHorizontal(); // 가로로 툴바 버튼을 배치하기 위한 시작 지점

            for (int i = 0; i < AR_toolbar_Names.Length; i++)
            {
                if (i % 5 == 0 && i != 0)
                {
                    GUILayout.EndHorizontal(); // 툴바 버튼을 5개씩 배치한 후 다음 줄로 넘어감
                    GUILayout.BeginHorizontal();
                }

                if (GUILayout.Toggle(toolbarIndex == i, AR_toolbar_Names[i], "Button"))
                {
                    toolbarIndex = i;
                }
            }

            GUILayout.EndHorizontal(); // 툴바 버튼 배치 마침
            GUILayout.Space(20);

            AR_toolbars[toolbarIndex].OnGUI();

            
        }

    }

}

public interface AR_Toolbar
{
    public void OnGUI();
}
class AR_Toolbar_3 : AR_Toolbar 
{
    public void OnGUI() 
    {
        GUILayout.Label("Bold Label", EditorStyles.boldLabel);
        GUILayout.Label("Help Box", EditorStyles.helpBox);
        GUILayout.Label("Mini Bold Label", EditorStyles.miniBoldLabel);
        
        GUILayout.Button("Mini Button", EditorStyles.miniButton);
        GUILayout.Button("Mini Button Left", EditorStyles.miniButtonLeft);
       
        GUILayout.Button("Mini Button Mid", EditorStyles.miniButtonMid);
        GUILayout.Button("Mini Button Right", EditorStyles.miniButtonRight);
        
        GUILayout.Label("Mini Label", EditorStyles.miniLabel);
        GUILayout.TextField("Mini Text Field", EditorStyles.miniTextField);
        
        GUILayout.Label("Number Field", EditorStyles.numberField);
        GUILayout.Label("Object Field", EditorStyles.objectField);
        
        
        GUILayout.Label("Object Field Mini Thumb", EditorStyles.objectFieldMiniThumb);
        GUILayout.Space(20);
        GUILayout.Label("Object Field Thumb", EditorStyles.objectFieldThumb);
        
        GUILayout.Label("Popup", EditorStyles.popup);
        GUILayout.Button("Radio Button", EditorStyles.radioButton);
        
        GUILayout.TextArea("Text Area", EditorStyles.textArea);
        GUILayout.TextField("Text Field", EditorStyles.textField);
        
        GUILayout.Label("Toggle", EditorStyles.toggle);
        GUILayout.Label("Toggle Group", EditorStyles.toggleGroup);
        
        GUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.Button("Toolbar Button", EditorStyles.toolbarButton);
        GUILayout.Button("Toolbar Drop Down", EditorStyles.toolbarDropDown);
        GUILayout.Button("Toolbar Popup", EditorStyles.toolbarPopup);
        GUILayout.TextField("Toolbar Text Field", EditorStyles.toolbarTextField);
        GUILayout.EndHorizontal();
        
        GUILayout.Label("White Bold Label", EditorStyles.whiteBoldLabel);
        GUILayout.Label("White Label", EditorStyles.whiteLabel);
        GUILayout.Label("White Large Label", EditorStyles.whiteLargeLabel);
        GUILayout.Label("White Mini Label", EditorStyles.whiteMiniLabel);
        
        GUILayout.Label("Word Wrapped Label", EditorStyles.wordWrappedLabel);
        GUILayout.Label("Word Wrapped Mini Label", EditorStyles.wordWrappedMiniLabel);
    }
}
class AR_Toolbar_2 : AR_Toolbar
{
    string myString = "La La Land is a 2016 American musical romantic drama film" +
        "written and directed by Damien Chazelle, and starring Ryan Gosling and Emma Stone" +
        "as a musician and an aspiring actress who meet and fall in love in Los Angeles." +
        "The film's title refers both to the city of Los Angeles and to the idiom" +
        "for being out of touch with reality.";

    bool myBool = true;
    float myFloat = 1.23f;
    int toolbarIndex = 0;
    string[] toolbars = { "toolbar1", "toolbar2", "toolbar3" };
    public float sliderValue = 1.0F;

    public void OnGUI() 
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.RepeatButton("Repeat\nButton")) Debug.Log("Repeat Button");
        if (GUILayout.Button("Button")) Debug.Log("Button");
        GUILayout.FlexibleSpace();

        GUILayout.BeginVertical();
        GUILayout.Box("Value:" + Mathf.Round(sliderValue));
        sliderValue = GUILayout.HorizontalSlider(sliderValue, 0.0F, 10);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUILayout.Label("Label");
        GUILayout.Space(30);

        myBool = GUILayout.Toggle(myBool, "Toggle");
        toolbarIndex = GUILayout.Toolbar(toolbarIndex, toolbars);
        myString = GUILayout.TextArea(myString);
        myString = GUILayout.TextField(myString);
        myString = GUILayout.PasswordField(myString, '#');

        myFloat = GUILayout.HorizontalSlider(myFloat, 0f, 5f);
        myFloat = GUILayout.VerticalSlider(myFloat, 0f, 5f);
    }
}
class AR_Toolbar_1 : AR_Toolbar
{
    private string myString = "Hello World";
    private bool groupEnabled;
    private bool myBool = true;
    private float myFloat = 1.23f;

    private Texture2D displayImg;
    private float sliderValue = 1.0f;
    private float maxSliderValue = 10.0f;

    /// <summary>
    /// GUI를 표시한다
    /// </summary>
    /// 레이아웃 방법 1. 
    /// GUILayout.BeginArea(new Rect());
    /// GUILayout.EndArea();
    /// 
    /// 레이아웃 방법 2.
    /// using (var areaScope = new GUILayout.AreaScope(new Rect()))
    /// {
    /// }
    public void OnGUI() 
    {
        // 꾹 눌리는 버튼 누르기
        using (var horizontalScope = new GUILayout.HorizontalScope())
        {
            // Place a Button normally
            if (GUILayout.RepeatButton("꾹 눌리는 버튼\n누르기"))
            {
                maxSliderValue += 3.0f * Time.deltaTime;
            }

            using (var verticalScope = new GUILayout.VerticalScope())
            {
                GUILayout.Box("Slider Value: " + Mathf.Round(sliderValue));
                sliderValue = GUILayout.HorizontalSlider(sliderValue, 0.0f, maxSliderValue);
            }
        }

        GUILayout.Space(30f); // 픽셀의 간격을 추가

        // 기본 설정
        GUILayout.Label("기본 설정", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        using (var toggleScope = new EditorGUILayout.ToggleGroupScope("Optional Settings", groupEnabled))
        {
            groupEnabled = toggleScope.enabled;
            myBool = EditorGUILayout.Toggle("Toggle", myBool);
            myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        }

        GUILayout.Space(10f); // 10 픽셀의 간격을 추가

        // 이미지 추가
        using (var verticalScope = new GUILayout.VerticalScope())
        {
            GUILayout.Label("Image Display", EditorStyles.boldLabel);
            if (displayImg != null)
            {
                GUILayout.Label(displayImg, GUILayout.MaxHeight(200), GUILayout.MaxWidth(200));
            }

            // 이미지를 로드하는 버튼을 추가합니다.
            if (GUILayout.Button("Load Image"))
            {
                string imagePath = EditorUtility.OpenFilePanel("Select Image", "", "png,jpg,jpeg");
                if (!string.IsNullOrEmpty(imagePath))
                {
                    displayImg = new Texture2D(1, 1);
                    byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
                    displayImg.LoadImage(imageData);
                }
            }
        }
    }
}