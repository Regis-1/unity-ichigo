using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioController : MonoBehaviour
{
    [System.Serializable]
    public class AudioArea
    {
        public EventReference fmodEvent;
        public BoxCollider2D areaCollider;
        public string parameterName;

        [HideInInspector]
        public FMOD.Studio.PARAMETER_ID parameterId;
    };

    [System.Serializable]
    public class AudioAreaRuntime
    {
        public AudioArea data;
        public EventInstance instance;
    };

    [SerializeField]
    private StudioEventEmitter bgm;
    private EventInstance bgmInstance;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private AudioArea[] areas;

    private List<AudioAreaRuntime> runtimeAreas = new List<AudioAreaRuntime>();

    void Start()
    {
        bgmInstance = bgm.EventInstance;
        bgmInstance.start();

        foreach (var area in areas)
        {
            AudioAreaRuntime runtime = new AudioAreaRuntime();
            runtime.data = area;

            runtime.instance = RuntimeManager.CreateInstance(area.fmodEvent);
            runtime.instance.start();

            var eventDescription = RuntimeManager.GetEventDescription(area.fmodEvent);
            eventDescription.getParameterDescriptionByName(
                area.parameterName,
                out FMOD.Studio.PARAMETER_DESCRIPTION paramDesc
            );

            area.parameterId = paramDesc.id;

            runtimeAreas.Add(runtime);
        }
    }

    void Update()
    {
        float maxProximity = 0f;

        foreach (var area in runtimeAreas)
        {
            float proximity = CalculateProximity(area.data.areaCollider);

            area.instance.setParameterByID(
                area.data.parameterId,
                proximity
            );

            if (proximity > maxProximity)
            {
                maxProximity = proximity;
            }
        }

        bgmInstance.setParameterByName(
            "BiomeProximity",
            maxProximity
        );
    }

    void Destroy()
    {
        foreach (var area in runtimeAreas)
        {
            area.instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            area.instance.release();
        }

        bgmInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        bgmInstance.release();
    }

    private float CalculateProximity(BoxCollider2D areaCollider)
    {
        Vector2 playerPos = playerTransform.position;

        Vector2 closestPoint = areaCollider.ClosestPoint(playerPos);

        float distance = Vector2.Distance(playerPos, closestPoint);

        float fadeDistance = 10f;

        return 1f - Mathf.Clamp01(distance / fadeDistance);
    }
}
