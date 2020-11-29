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


    /// <summary>
    /// Uses MaxLimit or MinLimit depending on the 'max' vector direction
    /// </summary>
    public static fix2 LimitDirection(this in fix2 v, in fix2 max)
    {
        fix x;
        fix y;

        x = (max.x > 0) ? fixMath.Min(max.x, v.x) : fixMath.Max(max.x, v.x);
        y = (max.y > 0) ? fixMath.Min(max.y, v.y) : fixMath.Max(max.y, v.y);

        return new fix2(x, y);
    }
    /// <summary>
    /// Uses MaxLimit or MinLimit depending on the 'max' vector direction
    /// </summary>
    public static fix3 LimitDirection(this in fix3 v, in fix3 max)
    {
        fix x;
        fix y;
        fix z;

        x = (max.x > 0) ? fixMath.Min(max.x, v.x) : fixMath.Max(max.x, v.x);
        y = (max.y > 0) ? fixMath.Min(max.y, v.y) : fixMath.Max(max.y, v.y);
        z = (max.z > 0) ? fixMath.Min(max.z, v.z) : fixMath.Max(max.z, v.z);

        return new fix3(x, y, z);
    }

    /// <summary>
    /// Return a vector where each component is lower or equal to its equivalent in 'max'
    /// </summary>
    public static fix2 MaxLimit(this in fix2 v, in fix2 max)
    {
        return new fix2(fixMath.Min(v.x, max.x), fixMath.Min(v.y, max.y));
    }
    /// <summary>
    /// Return a vector where each component is lower or equal to its equivalent in 'max'
    /// </summary>
    public static fix3 MaxLimit(this in fix3 v, in fix3 max)
    {
        return new fix3(fixMath.Min(v.x, max.x), fixMath.Min(v.y, max.y), fixMath.Min(v.z, max.z));
    }

    /// <summary>
    /// Return a vector where each component is higher or equal to its equivalent in 'max'
    /// </summary>
    public static fix2 MinLimit(this in fix2 v, in fix2 min)
    {
        return new fix2(fixMath.Max(v.x, min.x), fixMath.Max(v.y, min.y));
    }
    /// <summary>
    /// Return a vector where each component is higher or equal to its equivalent in 'max'
    /// </summary>
    public static fix3 MinLimit(this in fix3 v, in fix3 min)
    {
        return new fix3(fixMath.Max(v.x, min.x), fixMath.Max(v.y, min.y), fixMath.Max(v.z, min.z));
    }
}