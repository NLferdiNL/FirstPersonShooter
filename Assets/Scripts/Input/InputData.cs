using UnityEngine;

public class InputData : MonoBehaviour {

    Vector3 _movement = new Vector3(0, 0, 0); // x and z used to do movement forward and left and y for jump
    Vector2 _cameraMovement = new Vector2(0, 0); // used for camera movement

    [SerializeField]
    bool _leftClick, 
         _leftClickDown,
         _rightClick, 
         _rightClickDown,
         _interact; // actions such as shoot, aim and interact

    int  _scroll = 0; // used for weapon selection

    public bool leftClick {
        get { return _leftClick; }
        set { _leftClick = value; }
    }

    public bool leftClickDown {
        get { return _leftClickDown; }
        set { _leftClickDown = value; }
    }

    public bool rightClick {
        get { return _rightClick; }
        set { _rightClick = value; }
    }

    public bool rightClickDown {
        get { return _rightClickDown; }
        set { _rightClickDown = value; }
    }

    public bool interact {
        get { return _interact; }
        set { _interact = value; }
    }

    public int scroll {
        get { return _scroll; }
        set {
            if (value <= -1)
                _scroll = -1;
            else if (value >= 1)
                _scroll = 1;
            else
                _scroll = 0;
        }
    }

    public Vector3 movement {
        get {
            return _movement;
        }
        set {
            if (value.x <= -1)
                _movement.x = -1;
            else if (value.x >= 1)
                _movement.x = 1;
            else
                _movement.x *= 0.7f;

            if (value.y >= 1)
                _movement.y = 1;
            else
                _movement.y = 0;

            if (value.z <= -1)
                _movement.z = -1;
            else if (value.z >= 1)
                _movement.z = 1;
            else
                _movement.z *= 0.7f;
        }
    }

    public Vector2 cameraMovement {
        get {
            return _cameraMovement;
        }
        set {
            _cameraMovement = value;
        }
    }

    public bool forward {
        set {
            if (_movement.x == -1)
                _movement.x = 0;
            else if (value)
                _movement.x = 1;
            else
                _movement.x *= 0.7f;
        }
        get {
            return _movement.x == 1;
        }
    }

    public bool down {
        set {
            if (_movement.x == 1)
                _movement.x = 0;
            else if (value)
                _movement.x = -1;
            else
                _movement.x *= 0.7f;
        }
        get {
            return _movement.x == -1;
        }
    }

    public bool left {
        set {
            if (_movement.y == -1)
                _movement.y = 0;
            else if (value)
                _movement.y = 1;
            else
                _movement.y *= 0.7f;
        }
        get {
            return _movement.y == 1;
        }
    }

    public bool right {
        set {
            if (_movement.y == 1)
                _movement.y = 0;
            else if (value)
                _movement.y = -1;
            else
                _movement.y *= 0.7f;
        }
        get {
            return _movement.y == -1;
        }
    }

}
