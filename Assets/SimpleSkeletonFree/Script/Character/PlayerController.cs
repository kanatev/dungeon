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
        
        
        // [SerializeField] private 
        
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

            //        if (Input.GetMouseButtonDown(1)) {
            //            startMouseRotate = true;
            //            prevMousePosition = Input.mousePosition;


            //}
            //        if (Input.GetMouseButtonUp(1)) {
            //            startMouseRotate = false;
            //        }
            //        if (Input.GetMouseButton(1)) {
            //transform.Rotate(new Vector3(0, (Input.mousePosition.x - prevMousePosition.x) * mouseRotateSpeed, 0));
            //            prevMousePosition = Input.mousePosition;
            //        }
            //        if (Input.GetKeyDown(KeyCode.E)) {
            //            animator.SetTrigger("Attack1h1");
            //        }
            //        if (Input.GetKeyDown(KeyCode.R))
            //        {
            //            animator.SetTrigger("Hit1");
            //        }
            //        if (Input.GetKeyDown(KeyCode.T))
            //        {
            //            animator.SetTrigger("Fall1");
            //        }
            //        if (Input.GetKeyDown(KeyCode.Y))
            //        {
            //            animator.SetTrigger("Up");
            //        }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // если нажата кнопка управления, то персонаж поворачивается в сторону камеры
            if (Input.anyKeyDown)
            {
                //Debug.Log("we are here");
            }
            float degreesPerSecond = 360 * Time.deltaTime;
            //Vector3 direction = _cameraDirection.transform.position;// + transform.position;

            //Vector3 direction = new Vector3(_cameraDirection.transform.position.x, 0, 0);
            //Vector3 direction = new Vector3(_cameraDirection.transform.forward.x, 0, 0);

            // работает во всех направлениях
            //Vector3 direction = _cameraDirection.transform.forward;

            // но нам надо чтобы только по Х работало
            // то есть надо определить направление в чистом Х куда камера смотрит.
            //Vector3 p = _cameraDirection.viewport //ViewportToWorldPoint(new Vector3(1, 1, _cameraDirection.nearClipPlane));

            //Vector3 direction = new Vector3(_cameraDirection.transform.forward.x, 0, 0);

            // работает, но только в пределах 90 градусов на которые смотрим изначально
            //Vector3 direction = new Vector3(_cameraDirection.transform.forward.x, transform.forward.y, transform.forward.z);  
            
            // рабочий блок
            //Vector3 direction = _cameraDirection.transform.forward;
            //Quaternion targetRotation = Quaternion.LookRotation(direction);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond);


            Vector3 RawMovementInputs = Vector3.zero;
            float cameraHeading = _cameraDirection.eulerAngles.y;

            Quaternion controlRotation = Quaternion.Euler(0, cameraHeading, 0);

            Vector3 RotatedMoveInputs = controlRotation * RawMovementInputs;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, controlRotation, degreesPerSecond);

            //if (!startMouseRotate) {
            //    if (h > 0.5f) {
            //        transform.rotation = Quaternion.Euler(initRotation.eulerAngles + new Vector3(0, -90, 0));
            //    }
            //    if (h < -0.5f) {
            //        transform.rotation = Quaternion.Euler(initRotation.eulerAngles + new Vector3(0, 90, 0));
            //    }
            //    if (v > 0.5f) {
            //        transform.rotation = Quaternion.Euler(initRotation.eulerAngles + new Vector3(0, -180, 0));
            //    }
            //    if (v < -0.5f) {
            //        transform.rotation = Quaternion.Euler(initRotation.eulerAngles);
            //    }
            //}

            Vector3 moving = new Vector3(h * playerSpeed, 0, v * playerSpeed);

            if (Mathf.Abs(h) > 0.001f)
                v = 0;




            var speed = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
            animator.SetFloat("speedv", speed);


            transform.Translate(moving * Time.deltaTime);
        }
        void OnCollisionEnter(Collision other)
        {
            // Debug.Log("Entered collision with " + objectName.tag);
            // if (other.gameObject.CompareTag("enemy_tag"))
            // {
            //     healthPoints -= 1;
            // }
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