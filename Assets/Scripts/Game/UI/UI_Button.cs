using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    enum Buttons
    {
        PointButton
    }
    enum Texts
    { 
        PointText,
        ScoreText
    }
    enum GameObjects
    {
        TestObject,
    }
    enum Images
    {
        ItemIcon,
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, ((PointerEventData data) => { go.gameObject.transform.position = data.position; }), Define.UIEvent.Drag);

        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);
    }
    
    int _score = 0;

    public void OnButtonClicked(PointerEventData data)
    {
        _score++;
        GetText((int)Texts.ScoreText).text = $"Score : {_score}";
    }
}