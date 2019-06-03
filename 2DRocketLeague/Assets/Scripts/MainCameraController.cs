using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obscura
{
    public class MainCameraController : AbstractCameraController
    {
        
        private Camera ManagedCamera;
        private LineRenderer CameraLineRenderer;

        private void Awake()
        {
            this.ManagedCamera = this.gameObject.GetComponent<Camera>();
            this.CameraLineRenderer = this.gameObject.GetComponent<LineRenderer>();
        }

        //Use the LateUpdate message to avoid setting the camera's position before
        //GameObject locations are finalized.
        void LateUpdate()
        {
            var targetPosition = (this.Target_one.transform.position + this.Target_two.transform.position) / 2;
            var cameraPosition = this.ManagedCamera.transform.position;

            if (targetPosition != cameraPosition)
            {
                cameraPosition = new Vector3(targetPosition.x, targetPosition.y, cameraPosition.z);
            }

            this.ManagedCamera.transform.position = cameraPosition;

        }
    }
}
