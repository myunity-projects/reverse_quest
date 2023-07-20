using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    [SerializeField] private int _damage;

    private void Update()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ally"))
        {
            other.GetComponent<Ally>().GetDamage(_damage);
            Destroy(gameObject);
        }
    }
}
