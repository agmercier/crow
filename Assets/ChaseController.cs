using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer.Mechanics
{
public class ChaseController : MonoBehaviour
{
    public GameObject[] enemyArray;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject enemy in enemyArray)
            {
                enemy.GetComponent<Flyingbat3>().chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject enemy in enemyArray)
            {
                enemy.GetComponent<Flyingbat3>().chase = false;
            }
        }
        
    }
}
}