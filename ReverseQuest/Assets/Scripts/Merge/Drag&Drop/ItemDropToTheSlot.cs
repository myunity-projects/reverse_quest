using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropToTheSlot : MonoBehaviour, IDropHandler
{
    private int _maxPossibleMerge = 4;

    public void OnDrop(PointerEventData eventData)
    {
        Transform itemTransform = eventData.pointerDrag.transform; //�������� transform ������ ���������� � ����
        if (transform.childCount == 1) //���� ���� �������� ������, �� ������ ������� ��� ����������
        {
            Transform itemInTheSlotTransform = transform.GetChild(0); //�������� transform ������� ������������ � �����
            string itemInTheSlotTag = itemInTheSlotTransform.tag;
            if (itemTransform.CompareTag(itemInTheSlotTag) == false) //���� ���� �� ���������, �� ������ �������
            {
                //������ �� �������
                itemInTheSlotTransform.SetParent(itemTransform.parent);
                itemInTheSlotTransform.localPosition = Vector3.zero;
            }
            else
            {
                int previousItemLastIndex = System.Convert.ToInt32(itemInTheSlotTag.Substring(itemInTheSlotTag.Length - 1));
                itemInTheSlotTag = itemInTheSlotTag.Remove(itemInTheSlotTag.Length - 1); //������� ��������� ������
                if (previousItemLastIndex < _maxPossibleMerge && itemTransform != itemInTheSlotTransform) //���� ������� �� ����������� ���������� ����������� � �� ������ � ��� �� ����
                {
                    string newItemLastIndex = System.Convert.ToString(previousItemLastIndex + 1); //������� ����� ��������� ������
                    string newItemTag = "Images/" + itemInTheSlotTag + newItemLastIndex; //�.�. � ���� ������ ���� ��������� ������, �� ��� ������ �������� ����� ����� ��
                    GameObject newItemTransform = Resources.Load(newItemTag) as GameObject;

                    //�������� ������ � �������� ������ ��������
                    Destroy(itemTransform.gameObject);
                    Destroy(itemInTheSlotTransform.gameObject);
                    itemTransform = Instantiate(newItemTransform).transform;
                    AudioManager.Instance.PlaySfx(AudioClipName.MergeMaxLevelCreature);
                }
                else //���� ������� ����������� ���������� ����������� ��� ������ � ��� �� ����
                {
                    return;
                }
            }
        }
        //��������� ������� ������ �����
        itemTransform.SetParent(transform);
        itemTransform.localPosition = Vector3.zero;
        itemTransform.localScale = Vector3.one;
    }
}
