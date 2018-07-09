using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
		private Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;
		public float xMaxClamp = 80f;
		public float xMinClamp = -12f;
		public float yMaxClamp = 6f;
		public float yMinClamp = 4f;

		public bool clampCam = false;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

		public float yOffset;
		public float xOffset = 9f;

        // Use this for initialization
        private void Start()
        {
			target = GameObject.FindGameObjectWithTag ("MyPlayer").transform;
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
			if (target == null) {
				SearchPlayer ();
				return;
			}
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

			float xScale = target.Find("Graphics").localScale.x;
			Vector3 offsetPos;

			if (xScale > 0) {
			 	offsetPos = new Vector3 (xOffset, yOffset, 0);
			} else {
				offsetPos = new Vector3 (-xOffset, yOffset, 0);
			}

			Vector3 aheadTargetPos = target.position+ offsetPos + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

			if (clampCam) {
				newPos.x = Mathf.Clamp (newPos.x, xMinClamp, xMaxClamp);
				newPos.y = Mathf.Clamp (newPos.y, yMinClamp, yMaxClamp);
			}

            transform.position = newPos;
            m_LastTargetPosition = target.position;
        }

		void SearchPlayer(){
			if (GameObject.FindGameObjectWithTag ("MyPlayer")) {
				target = GameObject.FindGameObjectWithTag ("MyPlayer").transform;
			}
		}
    }
}
