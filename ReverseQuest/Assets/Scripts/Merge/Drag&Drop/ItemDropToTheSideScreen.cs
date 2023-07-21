using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Cinemachine;

public class ItemDropToTheSideScreen : MonoBehaviour, IDropHandler
{
    private Transform _undeadSpawnPoint;
    private FindUnitsToAttack _findUnits;

    private void Start()
    {
        _undeadSpawnPoint = GameObject.Find("UndeadSpawnPoint").transform;
        _findUnits = GameObject.Find("FindEnemies").GetComponent<FindUnitsToAttack>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Transform itemTransform = eventData.pointerDrag.transform; //�������� transform ������ ���������� � side ����
        string itemTag = itemTransform.tag; //�������� tag ������� ���������� � side ����

        GameObject itemToInstantiateTransform = Resources.Load("GameObjects/" + itemTag) as GameObject;

        if (itemToInstantiateTransform != null)
        {
            AudioManager.Instance.PlaySfx(AudioClipName.DropUnitOnSideScreen);

            string nameWithoutLastSymbol = itemTag.Remove(itemTag.Length - 1); //����� ����� ���������� ��� ������ � �������

            //��������� �� side ����
            Destroy(itemTransform.gameObject);
            var createdObject = Instantiate(itemToInstantiateTransform, _undeadSpawnPoint, true);
            _findUnits.undeadWarriors.Add(createdObject);
        }
    }
}
