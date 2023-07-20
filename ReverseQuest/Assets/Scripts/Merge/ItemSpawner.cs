using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject _itemToSpawn;

    [SerializeField] private int _clicksToReload;
    [SerializeField] private int _reloadTime;

    private Image _image;
    private Button _button;

    private int _clicksCounter;

    private bool _needToReload;
    private bool _isDoubleClick;

    private void Start()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void Update()
    {
        if (_needToReload)
        {
            _image.fillAmount += 1.0f / _reloadTime * Time.deltaTime;

            if (_image.fillAmount == 1)
            {
                _button.interactable = true;
                _needToReload = false;
            }
        }
    }

    public void OnSpawnerClicked()
    {
        if (_isDoubleClick)
        {
            AudioManager.Instance.PlaySfx(AudioClipName.TapSpawner);

            _clicksCounter++;

            if (_clicksCounter == _clicksToReload)
            {
                _image.fillAmount = 0;
                _clicksCounter = 0;
                _button.interactable = false;
                _needToReload = true;
            }

            GameObject[] slots = GameObject.FindGameObjectsWithTag("Slot");
            foreach (GameObject slot in slots) //ищем свободный слот
            {
                if (slot.transform.childCount == 0)
                {
                    Instantiate(Resources.Load("Images/" + _itemToSpawn.name), slot.transform); //создаем
                    return;
                }
            }
        }

        StartCoroutine(IsDoubleClick());
    }

    private IEnumerator IsDoubleClick()
    {
        _isDoubleClick = true;
        yield return new WaitForSeconds(1);
        _isDoubleClick = false;
    }
}
