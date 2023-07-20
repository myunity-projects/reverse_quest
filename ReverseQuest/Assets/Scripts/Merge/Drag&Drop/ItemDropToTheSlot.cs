using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropToTheSlot : MonoBehaviour, IDropHandler
{
    private int _maxPossibleMerge = 4;

    public void OnDrop(PointerEventData eventData)
    {
        Transform itemTransform = eventData.pointerDrag.transform; //получаем transform объект брошенного в слот
        if (transform.childCount == 1) //если есть дочерний объект, то меняем местами или объединяем
        {
            Transform itemInTheSlotTransform = transform.GetChild(0); //получаем transform объекта находящегося в слоте
            string itemInTheSlotTag = itemInTheSlotTransform.tag;
            if (itemTransform.CompareTag(itemInTheSlotTag) == false) //если теги не совпадают, то меняем местами
            {
                //меняем их местами
                itemInTheSlotTransform.SetParent(itemTransform.parent);
                itemInTheSlotTransform.localPosition = Vector3.zero;
            }
            else
            {
                int previousItemLastIndex = System.Convert.ToInt32(itemInTheSlotTag.Substring(itemInTheSlotTag.Length - 1));
                itemInTheSlotTag = itemInTheSlotTag.Remove(itemInTheSlotTag.Length - 1); //удаляем последний символ
                if (previousItemLastIndex < _maxPossibleMerge && itemTransform != itemInTheSlotTransform) //если элемент не максимально возможного объединения и не брошен в тот же слот
                {
                    string newItemLastIndex = System.Convert.ToString(previousItemLastIndex + 1); //создаем новый последний символ
                    string newItemTag = "Images/" + itemInTheSlotTag + newItemLastIndex; //т.к. в моем случае теги идентичны именам, то имя нового предмета будет таким же
                    GameObject newItemTransform = Resources.Load(newItemTag) as GameObject;

                    //создание нового и удаление старых объектов
                    Destroy(itemTransform.gameObject);
                    Destroy(itemInTheSlotTransform.gameObject);
                    itemTransform = Instantiate(newItemTransform).transform;
                    AudioManager.Instance.PlaySfx(AudioClipName.MergeMaxLevelCreature);
                }
                else //если элемент максимально возможного объединения или брошен в тот же слот
                {
                    return;
                }
            }
        }
        //помещение объекта внутрь слота
        itemTransform.SetParent(transform);
        itemTransform.localPosition = Vector3.zero;
        itemTransform.localScale = Vector3.one;
    }
}
