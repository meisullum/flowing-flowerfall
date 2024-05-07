using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGrowth : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer flower;
    public Sprite[] flowerStages;
    public Sprite flowerTemp;
    [SerializeField] ParticleSystem sparkleEffect;
    int i = 0;
    // public GameObject plant;
    [SerializeField] int particleCounter = 0;
    [SerializeField] bool harvestable;
    private FlowerSpawner flowerUpdater;

    void Start() {

        harvestable = false;
        particleCounter = 0;
        flowerUpdater = FindObjectOfType(typeof(FlowerSpawner)) as FlowerSpawner; // this works YAY!

    }

    void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("I've been watered :D");
        if ( other.CompareTag("balls")) {
            particleCounter++;
            
            sparkleEffect.Play();

            if (particleCounter >= 25 && !(harvestable)) { // 
                growPlant();
                particleCounter = 0;
            }
           
        }
    }

    void OnMouseDown()
    {
        if (harvestable)
        {
            // Remove the flower
            // Destroy(gameObject); // only if we delete the flower
            flower.sprite = flowerTemp; // change it back to flower
            i = 0;
            harvestable = false;
            PickupFlower();
            particleCounter = 0;
            // test the following out
            // value used to be != 1 but that was for the tutorial
            if (GameObject.Find("Scoreboard").GetComponent<ScoreScript>().GetMinFlowerRange() != 1) {
                flowerUpdater.OptimizationPoolSpawner(this.gameObject);
            }
        }
    }

    void PickupFlower() {
        GameObject.Find("Scoreboard").GetComponent<ScoreScript>().RegisterFlower();
    }

    void growPlant() {
        flower.sprite = flowerStages[i];
        i++;
        if (i == 2) {
            harvestable = true;
        }
    }

    public bool isHarvestable() {
        return harvestable;
    }

}
