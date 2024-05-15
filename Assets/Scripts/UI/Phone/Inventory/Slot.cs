using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public UIItem item;
    public Image itemIcon;

    public void UpdateSlot()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        itemIcon.sprite = null;
        itemIcon.gameObject.SetActive(false);
    }

    public Sprite pressedSprite; // Pressed 상태에서 적용할 이미지 스프라이트
    public bool isChanged; // 버튼이 눌렸는지 여부

    private Button button; // 버튼 컴포넌트에 대한 참조
    private Image buttonImage; // 버튼 이미지 컴포넌트에 대한 참조
    private Sprite originalSprite; // 버튼의 원래 이미지 스프라이트

    void Start()
    {
        // 해당 게임 오브젝트에 붙어있는 버튼 컴포넌트를 가져옴
        button = GetComponent<Button>();

        // 해당 게임 오브젝트에 붙어있는 이미지 컴포넌트를 가져옴
        buttonImage = GetComponent<Image>();

        // 각 버튼이 자신의 원래 이미지 스프라이트를 저장하도록 함
        originalSprite = buttonImage.sprite;

        // 버튼이 눌렸을 때의 동작을 처리할 이벤트 리스너를 추가
        button.onClick.AddListener(ChangeImage);
    }

    public void ChangeImage()
    {
        // 버튼의 이미지를 Pressed Sprite로 변경
        isChanged = true;
        buttonImage.sprite = pressedSprite;
        FindAnyObjectByType<InventoryUI>().RevertSlotImage();

        // 버튼이 다시 눌려지면 이미지를 원래 Sprite로 되돌림
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(RevertImage);
    }

    public void RevertImage()
    {
        // 버튼의 이미지를 원래 Sprite로 되돌림
        buttonImage.sprite = originalSprite;

        // 이미지를 변경하는 이벤트 리스너를 다시 추가
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ChangeImage);
    }
}
