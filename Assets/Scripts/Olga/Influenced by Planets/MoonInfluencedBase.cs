using UnityEngine;

public abstract class MoonInfluencedBase : MonoBehaviour
{

    Moon[] moons;

   public virtual void Awake()
    {
        moons = FindObjectsOfType<Moon>();
    }


    public virtual void OnEnable()
    {
        foreach (var moon in moons)
        {
            moon.MoonRiseEvent += MoonRiseResponse;
            moon.MoonSetEvent += MoonSetResponse;
        }
    }
    public virtual void OnDisable()
    {
        foreach (var moon in moons)
        {
            moon.MoonRiseEvent -= MoonRiseResponse;
            moon.MoonSetEvent -= MoonSetResponse;
        }


    }

    abstract public void MoonRiseResponse(MoonTypes moonType);

    abstract public void MoonSetResponse(MoonTypes moonType);


   }
