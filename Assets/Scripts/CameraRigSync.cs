using UnityEngine;

public class CameraRigSync : MonoBehaviour {

    #region PosRot
    public class PosRot {

        public PosRot(Vector3 Position, Quaternion Rotation) {
            _position = Position;
            _rotation = Rotation;
        }

        public static PosRot zero {
            get { return new PosRot(Vector3.zero, new Quaternion()); }
        }

        Vector3 _position;

        public Vector3 position {
            get { return _position; }
            set { _position = value; }
        }

        Quaternion _rotation;

        public Quaternion rotation {
            get { return _rotation; }
            set { _rotation = value; }
        }
    }
    #endregion
    #region CameraRigPosition
    public class CameraRigPosition {

        public CameraRigPosition(PosRot Head, PosRot LeftHand, PosRot RightHand) {
            head = Head;
            leftHand = LeftHand;
            rightHand = RightHand;
        }

        public CameraRigPosition() {
            head = PosRot.zero;
            leftHand = PosRot.zero;
            rightHand = PosRot.zero;
        }

        PosRot _head;

        public Vector3 offset = new Vector3(0, 0, 0);

        public PosRot head {
            get { return _head; }
            set { _head = value; }
        }

        PosRot _leftHand;

        public PosRot leftHand {
            get { return _leftHand; }
            set { _leftHand = value; }
        }

        PosRot _rightHand;

        public PosRot rightHand {
            get { return _rightHand; }
            set { _rightHand = value; }
        }

        public static void UpdatePositions(CameraRigPosition positions, CameraRigContainer container) {
            positions.head.position = container.head.position;
            positions.leftHand.position = container.leftHand.position;
            positions.rightHand.position = container.rightHand.position;

            positions.head.rotation = container.head.rotation;
            positions.leftHand.rotation = container.leftHand.rotation;
            positions.rightHand.rotation = container.rightHand.rotation;
        }

        public static void UpdatePositions(CameraRigContainer container, CameraRigPosition positions) {
            UpdatePositions(positions, container);
        }

        public void UpdatePositions(CameraRigContainer container) {
            _head.position = container.head.position + offset;
            _leftHand.position = container.leftHand.position + offset;
            _rightHand.position = container.rightHand.position + offset;

            _head.rotation = container.head.rotation;
            _leftHand.rotation = container.leftHand.rotation;
            _rightHand.rotation = container.rightHand.rotation;
        }
    }
    #endregion
    #region CameraRigContainer
    public class CameraRigContainer {

        public CameraRigContainer(Transform CameraRig) {
            _cameraRig = CameraRig;
            _UpdateTransforms();
        }

        public CameraRigContainer() {
            // Doesn't really need to do anything.
        }

        Transform _cameraRig;

        public Transform cameraRig {
            get { return _cameraRig; }
            set { _cameraRig = value;
                  _UpdateTransforms();
            }
        }

        void _UpdateTransforms() {
            _head = _cameraRig.FindChild("Camera (eye)");
            _leftHand = _cameraRig.FindChild("Controller (left)");
            _rightHand = _cameraRig.FindChild("Controller (right)");
        }

        Transform _head;

        public Transform head {
            get { return _head; }
            set { _head = value; }
        }

        Transform _leftHand;

        public Transform leftHand {
            get { return _leftHand; }
            set { _leftHand = value; }
        }

        Transform _rightHand;

        public Transform rightHand {
            get { return _rightHand; }
            set { _rightHand = value; }
        }

        public void UpdatePositions(CameraRigPosition otherPlayer) {
            if (_head != null) {
                _head.position = otherPlayer.head.position;
                _head.rotation = otherPlayer.head.rotation;
            }

            if (_leftHand != null) {
                _leftHand.position = otherPlayer.leftHand.position;
                _leftHand.rotation = otherPlayer.leftHand.rotation;
            }

            if (_rightHand != null) {
                _rightHand.position = otherPlayer.rightHand.position;
                _rightHand.rotation = otherPlayer.rightHand.rotation;
            }
        }

    }
    #endregion
    #region Variables
    CameraRigPosition _otherPlayer;

    CameraRigPosition otherPlayer {
        get { return _otherPlayer; }
        set { _otherPlayer = value; }
    }

    CameraRigPosition _localPlayerPositions = new CameraRigPosition();

    CameraRigPosition localPlayer {
        get { return _localPlayerPositions; }
        set { _localPlayerPositions = value; }
    }

    public Transform localCameraRig;

    public Transform otherPlayerRig;

    public Vector3 offset = new Vector3(0, 0, 2.3908f);

    CameraRigContainer _localPlayerTransformContainer;

    CameraRigContainer _otherPlayerContainer;

    CameraRigContainer otherPlayerContainer {
        get { return _otherPlayerContainer; }
        set { _otherPlayerContainer = value; }
    }
    #endregion

    void Start() {
        _localPlayerTransformContainer = new CameraRigContainer(localCameraRig);
        _localPlayerPositions.UpdatePositions(_localPlayerTransformContainer);

        _localPlayerPositions.offset = offset;

        _otherPlayerContainer = new CameraRigContainer(otherPlayerRig);
    }

    void FixedUpdate() {
        Receive(Request());
    }

    void UpdateLocalRigPos() {  
        _localPlayerPositions.UpdatePositions(_localPlayerTransformContainer);
    }

    /// <summary>
    /// Returns local players positions
    /// </summary>
    /// <returns></returns>
    public CameraRigPosition Request() {
        UpdateLocalRigPos();
        return _localPlayerPositions;
    }

    /// <summary>
    /// Update other players positions
    /// </summary>
    /// <param name="rigPos"></param>
    public void Receive(CameraRigPosition rigPos) {
        _otherPlayer = rigPos;
        _otherPlayerContainer.UpdatePositions(_otherPlayer);
    }

}
