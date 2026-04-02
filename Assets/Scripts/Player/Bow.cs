using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    public Transform bow;
    public Animator animator;
    public GameObject arrowPrefab;
    public GameObject sound;

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.C) && GetComponentInParent<Stats>().power == 4) {
            GetComponentInParent<Stats>().power = 0;
            Shoot();
        }
        
    }

    void Shoot() {
        // Shooting date animation
        animator.SetTrigger("attackBow");
    }

    void ShootArrow() {
        // Shoot the arrow 
        Instantiate(arrowPrefab, bow.position, bow.rotation);

        //Sound
        Instantiate(sound);
    }

    public void AttackButton() {
        if (GetComponentInParent<Stats>().power == 4) {
            GetComponentInParent<Stats>().power = 0;
            Shoot();
        }
    }
}
