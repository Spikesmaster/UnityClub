
using UnityEngine;


public class Planet : MonoBehaviour
    {
    /// Public Properties

    /// Serialized Fields for Editor
#pragma warning disable 0649
    [SerializeField]
    protected Transform centerOfOrbit;
    [SerializeField]
    float period;
    [SerializeField]
    float startingPhase;
    public float angularSpeed { get { return 360.0f / period; } }
#pragma warning restore 0649


    ///  private Fields
    bool isOrbiting = true;
    protected float orbitRadius;
    ///  Unity CallBacks Methods
    public virtual void Awake()
        {
        orbitRadius = (transform.position - centerOfOrbit.position).magnitude;
        }

    public virtual void OnEnable()
        {
        PauseMenu.PauseToggleEvent += ToggleOrbit;
        }

    public virtual void Start()
        {
        centerOfOrbit.Rotate((Vector3.forward * startingPhase));
        }

    public virtual void Update()
        {
        if (isOrbiting)
            Orbit();
        }

    public virtual void OnDisable()
        {
        PauseMenu.PauseToggleEvent -= ToggleOrbit;
    }


        ///  Public Methods



        ///  Private Methods
        void Orbit()
    {
        
        Vector3 rotationAxis = Vector3.forward;
        centerOfOrbit.Rotate(rotationAxis, angularSpeed * Time.deltaTime);
    }

    void ToggleOrbit(bool tof)
    {
        isOrbiting = tof;
    }

    }
