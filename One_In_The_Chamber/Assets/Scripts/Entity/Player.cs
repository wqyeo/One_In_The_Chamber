﻿using UnityEngine;

using MyBox;

public class Player : Character {

    [Separator("Player controls")]
    [SerializeField, Tooltip("The button to press to fire the gun"), SearchableEnum]
    private KeyCode fireGunKeyCode;

    [Separator("Player Weapon")]

    [SerializeField, Tooltip("The gun this player holds"), MustBeAssigned]
    private Gun playerGun;

    private Camera gameCamera;

    private void Awake() {
        gameCamera = Camera.main;
    }

    private void Start() {
        SnapCharacterRotationToFacePosition(gameCamera.ScreenToWorldPoint(Input.mousePosition));
    }

    private void Update() {
        RotatePlayerBasedOnMousePosition(Time.deltaTime);

        if (Input.GetKeyDown(fireGunKeyCode)) {
            playerGun.FireGun();
        }
    }

    private void RotatePlayerBasedOnMousePosition(float deltaTime) {

        Vector3 positionToRotateTowards = gameCamera.ScreenToWorldPoint(Input.mousePosition);

        RotateCharacterToPositionOnFrame(positionToRotateTowards, deltaTime);
    }
}
