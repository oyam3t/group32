using UnityEngine;

public class zamanigerial : MonoBehaviour
{
    private bool isRewinding = false;

    public KeyCode rewindButton = KeyCode.R;

    public float rewindDuration = 10f;

    private struct TimePoint
    {
        public float time;
        public Vector3 position;
        public Quaternion rotation;
    }

    private readonly System.Collections.Generic.Stack<TimePoint> timePoints = new System.Collections.Generic.Stack<TimePoint>();

    private void Update()
    {
        if (Input.GetKeyDown(rewindButton))
        {
            StartRewind();
        }
        else if (Input.GetKeyUp(rewindButton))
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            RewindTime();
        }
        else
        {
            RecordTime();
        }
    }

    private void StartRewind()
    {
        isRewinding = true;
        Time.timeScale = -1f;
        Invoke("StopRewind", rewindDuration);
    }

    private void StopRewind()
    {
        isRewinding = false;
        Time.timeScale = 1f;
    }

    private void RewindTime()
    {
        if (timePoints.Count > 0)
        {
            TimePoint point = timePoints.Pop();
            transform.position = point.position;
            transform.rotation = point.rotation;
        }
        else
        {
            StopRewind();
        }
    }

    private void RecordTime()
    {
        TimePoint point = new TimePoint();
        point.time = Time.time;
        point.position = transform.position;
        point.rotation = transform.rotation;
        timePoints.Push(point);
    }
}
