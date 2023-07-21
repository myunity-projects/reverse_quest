using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindUnitsToAttack : MonoBehaviour
{
    public List<GameObject> humanWarriors;
    public List<GameObject> undeadWarriors;

    private GameObject undead;

    private void Awake()
    {
        humanWarriors.AddRange(GameObject.FindGameObjectsWithTag("Human"));
        undeadWarriors.AddRange(GameObject.FindGameObjectsWithTag("Undead"));
    }
}
