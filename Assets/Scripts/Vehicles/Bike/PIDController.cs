using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoadFresh.Vehicle.Physics
{
    [RequireComponent(typeof(Rigidbody))]
    public class PIDController : MonoBehaviour
    {
        // Transform of a target
        [SerializeField]
        protected Transform _target = null;

        // class for pid gains
        [System.Serializable]
        public class Gain
        {
            public float p = 1.0f;

            public float i = 0.0f;

            public float d = 1.0f;
        }

        // [BoxGroup("PositionGain")]
        [SerializeField]
        // [SerializeField, InlineProperty, HideLabel]
        protected Gain _posGain = new Gain();

        // [BoxGroup("RotationGain")]
        [SerializeField]
        // [SerializeField, InlineProperty, HideLabel]
        protected Gain _rotGain = new Gain();

        [SerializeField]
        protected bool _gravityCompensation = true;

        // rigidbody of an attached gameobject
        private Rigidbody _rigidBody;

        // rigidbody of an attached gameobject
        private Transform _transform;

        // Position error
        private Vector3 _error = Vector3.zero;

        private Vector3 _prevError = Vector3.zero;

        private Vector3 _diffError = Vector3.zero;

        private Vector3 _intError = Vector3.zero;

        // Rotation error
        private Quaternion _rotError = Quaternion.identity;

        private Quaternion _prevRotError = Quaternion.identity;

        private Quaternion _diffRotError = Quaternion.identity;

        private Quaternion _intRotError = Quaternion.identity;

        private float _angleError = 0f;

        private Vector3 _errorAxis;

        private Vector3 _diffErrorAxis;

        private Vector3 _intErrorAxis;

        private float _diffAngleError = 0f;

        private float _intAngleError = 0f;

        private Vector3 _force = Vector3.zero;

        /**
        * @brief target transform
        * 
        */
        public Transform target
        {
            get
            {
                return _target;
            }
        }

        /**
        * @brief Position gains
        * 
        */
        public Gain positionGains
        {
            get
            {
                return _posGain;
            }
        }

        /**
        * @brief Rotation gains
        * 
        */
        public Gain rotationGains
        {
            get
            {
                return _rotGain;
            }
        }

        /**
        * @brief rotation axis
        * 
        */
        Vector3 RotAxis(Quaternion q)
        {
            var n = new Vector3(q.x, q.y, q.z);
            return n.normalized;
        }

        /**
        *
        */
        protected Quaternion RotOptimize(Quaternion q)
        {
            if (q.w < 0.0f)
            {
                q.x *= -1.0f;
                q.y *= -1.0f;
                q.z *= -1.0f;
                q.w *= -1.0f;
            }

            return q;
        }

        /**
        * @brief Position error
        * 
        **/
        public Vector3 posError
        {
            get
            {
                return _error;
            }
        }

        /**
        * @brief Set a target object
        * 
        * @param target target transform
        */
        public void SetTarget(Transform target)
        {
            _target = target;
        }

        /**
        * @brief Set pid gains for position control
        * 
        * @param p proportional gain
        * @param i integral gain
        * @param d differential gain
        */
        public void SetPositionGains(float p, float i, float d)
        {
            _posGain.p = p;
            _posGain.i = i;
            _posGain.d = d;
        }

        /**
        * @brief Set pid gains for rotation control
        * 
        * @param p proportional gain
        * @param i integral gain
        * @param d differential gain
        */
        public void SetRotationGains(float p, float i, float d)
        {
            _rotGain.p = p;
            _rotGain.i = i;
            _rotGain.d = d;
        }

        void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _transform = transform;
        }

        void FixedUpdate()
        {
            if (_target == null)
            {
                return;
            }

            /// position ///
            _error = _target.position - _transform.position;
            _intError += _error * Time.deltaTime; // integral
            _diffError = (_error - _prevError) / Time.deltaTime;
            _prevError = _error;

            _force =
                _posGain.p * _error +
                _posGain.i * _intError +
                _posGain.d * _diffError;

            if (_gravityCompensation && _rigidBody.useGravity)
            {
                _force += -_rigidBody.mass * UnityEngine.Physics.gravity;
            }

            /// rotation ///
            _rotError =
                RotOptimize(_target.rotation *
                Quaternion.Inverse(_transform.rotation));

            _rotError.ToAngleAxis(out _angleError, out _errorAxis);

            _angleError *= Mathf.Deg2Rad; // deg to rad
            var angularVelocity = _rotGain.p * _angleError * _errorAxis;

            if (_error.sqrMagnitude > 0.1f)
            {
                _rigidBody.AddForce(_force);
            }
            else if (_gravityCompensation && _rigidBody.useGravity)
            {
                _rigidBody.AddForce(-_rigidBody.mass * UnityEngine.Physics.gravity);
            }

            if (_angleError * _angleError > 0.01f)
            {
                _rigidBody.angularVelocity = angularVelocity;
            }
            _prevRotError = _rotError;
        }
    }
}