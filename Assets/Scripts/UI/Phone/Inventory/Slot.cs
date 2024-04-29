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

    public Sprite pressedSprite; // Pressed ���¿��� ������ �̹��� ��������Ʈ
    public bool isChanged; // ��ư�� ���ȴ��� ����

    private Button button; // ��ư ������Ʈ�� ���� ����
    private Image buttonImage; // ��ư �̹��� ������Ʈ�� ���� ����
    private Sprite originalSprite; // ��ư�� ���� �̹��� ��������Ʈ

    void Start()
    {
        // �ش� ���� ������Ʈ�� �پ��ִ� ��ư ������Ʈ�� ������
        button = GetComponent<Button>();

        // �ش� ���� ������Ʈ�� �پ��ִ� �̹��� ������Ʈ�� ������
        buttonImage = GetComponent<Image>();

        // �� ��ư�� �ڽ��� ���� �̹��� ��������Ʈ�� �����ϵ��� ��
        originalSprite = buttonImage.sprite;

        // ��ư�� ������ ���� ������ ó���� �̺�Ʈ �����ʸ� �߰�
        button.onClick.AddListener(ChangeImage);
    }

    public void ChangeImage()
    {
        // ��ư�� �̹����� Pressed Sprite�� ����
        isChanged = true;
        buttonImage.sprite = pressedSprite;
        FindAnyObjectByType<InventoryUI>().RevertSlotImage();

        // ��ư�� �ٽ� �������� �̹����� ���� Sprite�� �ǵ���
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(RevertImage);
    }

    public void RevertImage()
    {
        // ��ư�� �̹����� ���� Sprite�� �ǵ���
        buttonImage.sprite = originalSprite;

        // �̹����� �����ϴ� �̺�Ʈ �����ʸ� �ٽ� �߰�
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ChangeImage);
    }
}
