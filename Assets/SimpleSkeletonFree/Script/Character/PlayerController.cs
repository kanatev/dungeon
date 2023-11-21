using System;
using System.Collections.Generic;
using UnityEngine;

namespace SkeletonEditor
{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform _cameraDirection;
        [SerializeField] private int playerSpeed;
        private int healthPoints = 100;
        public int HealthPoints => healthPoints;
        public float mouseRotateSpeed;
        private Animator animator;
        private Quaternion initRotation;
        private int currentAnimation;
        private List<string> animations;
        private bool startMouseRotate;
        private Vector3 prevMousePosition;

        public static PlayerController Instance { get; private set; }

        void Awake() {
            if (Instance != null) {
                Destroy(this.gameObject);
            }
            Instance = this;
        }

        void Start() {
            animator = GetComponent<Animator>();
            initRotation = transform.rotation;

          
            animations = new List<string>()
            {
                "Hit1",
                "Fall1",
                "Attack1h1",    
            };
        }

        void Update() {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Attack1h1");
            }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            
            float degreesPerSecond = 360 * Time.deltaTime;

            Vector3 RawMovementInputs = Vector3.zero;
            float cameraHeading = _cameraDirection.eulerAngles.y;

            Quaternion controlRotation = Quaternion.Euler(0, cameraHeading, 0);

            Vector3 RotatedMoveInputs = controlRotation * RawMovementInputs;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, controlRotation, degreesPerSecond);

            Vector3 moving = new Vector3(h * playerSpeed, 0, v * playerSpeed);

            if (Mathf.Abs(h) > 0.001f)
                v = 0;

            var speed = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
            animator.SetFloat("speedv", speed);

            transform.Translate(moving * Time.deltaTime);
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("enemy_tag"))
            {
                healthPoints -= 1;
            }
        }
    }
}