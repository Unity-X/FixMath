using UnityEngine;

public static class FixQuaternionExtensions
{
    public static Quaternion ToUnityQuat(this fixQuaternion fixQuat)
    {
        return new Quaternion((float)fixQuat.x, (float)fixQuat.y, (float)fixQuat.z, (float)fixQuat.w);
    }

    public static fixQuaternion ToFixQuat(this Quaternion fixQuat)
    {
        return new fixQuaternion((fix)fixQuat.x, (fix)fixQuat.y, (fix)fixQuat.z, (fix)fixQuat.w);
    }
}