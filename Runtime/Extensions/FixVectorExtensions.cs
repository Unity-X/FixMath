using UnityEngine;

public static class FixVectorExtensions
{
    public static Vector2 ToUnityVec(this in fix2 fixVec)
    {
        return new Vector2((float)fixVec.x, (float)fixVec.y);
    }
    public static Vector3 ToUnityVec(this in fix3 fixVec)
    {
        return new Vector3((float)fixVec.x, (float)fixVec.y, (float)fixVec.z);
    }
    public static Vector4 ToUnityVec(this in fix4 fixVec)
    {
        return new Vector4((float)fixVec.x, (float)fixVec.y, (float)fixVec.z, (float)fixVec.w);
    }
    public static fix2 ToFixVec(this in Vector2 vec)
    {
        return new fix2((fix)vec.x, (fix)vec.y);
    }
    public static fix3 ToFixVec(this in Vector3 vec)
    {
        return new fix3((fix)vec.x, (fix)vec.y, (fix)vec.z);
    }
    public static fix4 ToFixVec(this in Vector4 vec)
    {
        return new fix4((fix)vec.x, (fix)vec.y, (fix)vec.z, (fix)vec.w);
    }
}