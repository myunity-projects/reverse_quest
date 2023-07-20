using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ItemDropToTheSideScreen : MonoBehaviour, IDropHandler
{
    private Transform _allySpawnPoint;

    private Dictionary<string, Vector3> _allyCoordinates = new Dictionary<string, Vector3>()
    {
        {"Vampire", new Vector3(0, 0, -2) },
        {"Succubus", new Vector3(0, 0, 0) },
        {"Skeleton", new Vector3(0, 0, 2) },
    };

    private void Start()
    {
        _allySpawnPoint = GameObject.Find("AllySpawnPoint").transform;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Transform itemTransform = eventData.pointerDrag.transform; //получаем transform объект брошенного в side поле
        string itemTag = itemTransform.tag; //получаем tag объекта брошенного в side поле

        GameObject itemToInstantiateTransform = Resources.Load("GameObjects/" + itemTag) as GameObject;

        if (itemToInstantiateTransform != null)
        {
            AudioManager.Instance.PlaySfx(AudioClipName.DropUnitOnSideScreen);

            string nameWithoutLastSymbol = itemTag.Remove(itemTag.Length - 1); //чтобы найти координаты для спавна в словаре

            //добавляем на side поле
            Destroy(itemTransform.gameObject);
            var createdObject = Instantiate(itemToInstantiateTransform, _allySpawnPoint);
            createdObject.transform.localPosition = _allyCoordinates[nameWithoutLastSymbol];
        }
    }
}
