using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public static class FixRandomExtensions
{
    public static bool2 NextBool2(this ref FixRandom random)                                           => new bool2(random.NextBool(), random.NextBool());
    public static bool3 NextBool3(this ref FixRandom random)                                           => new bool3(random.NextBool(), random.NextBool(), random.NextBool());
    public static bool4 NextBool4(this ref FixRandom random)                                           => new bool4(random.NextBool(), random.NextBool(), random.NextBool(), random.NextBool());
    public static fix2 NextFix2(this ref FixRandom random)                                 => new fix2(random.NextFix(), random.NextFix());
    public static fix2 NextFix2(this ref FixRandom random, fix2 max)                 => new fix2(random.NextFix(max.x), random.NextFix(max.y));
    public static fix2 NextFix2(this ref FixRandom random, fix2 min, fix2 max) => new fix2(random.NextFix(min.x, max.x), random.NextFix(min.y, max.y));
    public static fix3 NextFix3(this ref FixRandom random)                                 => new fix3(random.NextFix(), random.NextFix(), random.NextFix());
    public static fix3 NextFix3(this ref FixRandom random, fix3 max)                 => new fix3(random.NextFix(max.x), random.NextFix(max.y), random.NextFix(max.z));
    public static fix3 NextFix3(this ref FixRandom random, fix3 min, fix3 max) => new fix3(random.NextFix(min.x, max.x), random.NextFix(min.y, max.y), random.NextFix(min.z, max.z));
    public static fix4 NextFix4(this ref FixRandom random)                                 => new fix4(random.NextFix(), random.NextFix(), random.NextFix(), random.NextFix());
    public static fix4 NextFix4(this ref FixRandom random, fix4 max)                 => new fix4(random.NextFix(max.x), random.NextFix(max.y), random.NextFix(max.z), random.NextFix(max.w));
    public static fix4 NextFix4(this ref FixRandom random, fix4 min, fix4 max) => new fix4(random.NextFix(min.x, max.x), random.NextFix(min.y, max.y), random.NextFix(min.z, max.z), random.NextFix(min.w, max.w));
    public static int2 NextInt2(this ref FixRandom random)                                             => new int2(random.NextInt(), random.NextInt());
    public static int2 NextInt2(this ref FixRandom random, int2 max)                                   => new int2(random.NextInt(max.x), random.NextInt(max.y));
    public static int2 NextInt2(this ref FixRandom random, int2 min, int2 max)                         => new int2(random.NextInt(min.x, max.x), random.NextInt(min.y, max.y));
    public static int3 NextInt3(this ref FixRandom random)                                             => new int3(random.NextInt(), random.NextInt(), random.NextInt());
    public static int3 NextInt3(this ref FixRandom random, int3 max)                                   => new int3(random.NextInt(max.x), random.NextInt(max.y), random.NextInt(max.z));
    public static int3 NextInt3(this ref FixRandom random, int3 min, int3 max)                         => new int3(random.NextInt(min.x, max.x), random.NextInt(min.y, max.y), random.NextInt(min.z, max.z));
    public static int4 NextInt4(this ref FixRandom random)                                             => new int4(random.NextInt(), random.NextInt(), random.NextInt(), random.NextInt());
    public static int4 NextInt4(this ref FixRandom random, int4 max)                                   => new int4(random.NextInt(max.x), random.NextInt(max.y), random.NextInt(max.z), random.NextInt(max.w));
    public static int4 NextInt4(this ref FixRandom random, int4 min, int4 max)                         => new int4(random.NextInt(min.x, max.x), random.NextInt(min.y, max.y), random.NextInt(min.z, max.z), random.NextInt(min.w, max.w));
    public static uint2 NextUInt2(this ref FixRandom random)                                           => new uint2(random.NextUInt(), random.NextUInt());
    public static uint3 NextUInt3(this ref FixRandom random)                                           => new uint3(random.NextUInt(), random.NextUInt(), random.NextUInt());
    public static uint4 NextUInt4(this ref FixRandom random)                                           => new uint4(random.NextUInt(), random.NextUInt(), random.NextUInt(), random.NextUInt());

    // methods that were not yet ported from Unity.Mathematic.Random
    //public static uint2 NextUInt2(this ref FixRandom random, uint2 max)                                => new uint2(random.NextUInt(max.x), random.NextUInt(max.y));
    //public static uint3 NextUInt3(this ref FixRandom random, uint3 max)                                => new uint3(random.NextUInt(max.x), random.NextUInt(max.y), random.NextUInt(max.z));
    //public static uint4 NextUInt4(this ref FixRandom random, uint4 max)                                => new uint4(random.NextUInt(max.x), random.NextUInt(max.y), random.NextUInt(max.z), random.NextUInt(max.w));
    //public static uint2 NextUInt2(this ref FixRandom random, uint2 min, uint2 max)                     => new uint2(random.NextUInt(), random.NextUInt());
    //public static uint3 NextUInt3(this ref FixRandom random, uint3 min, uint3 max)                     => new uint3(random.NextUInt(), random.NextUInt());
    //public static uint4 NextUInt4(this ref FixRandom random, uint4 min, uint4 max)                     => new uint4(random.NextUInt(), random.NextUInt());
    //public static quaternion NextQuaternionRotation(this ref FixRandom random);

    /// <summary>
    /// Vector will be normalized
    /// </summary>
    public static fix2 NextFixVector2Direction(this ref FixRandom random)
    {
        fix angle = random.NextFixRatio() * fix.PiTimes2;

        return new fix2(
            fix.Cos(angle),   // x
            fix.Sin(angle));  // y
    }

    /// <summary>
    /// Vector will be normalized
    /// </summary>
    public static fix3 NextFixVector3Direction(this ref FixRandom random)
    {
        fix phi = random.NextFixRatio() * fix.PiTimes2;
        fix costheta = random.NextFix(-1, 1);
        fix theta = fix.Acos(costheta);

        return new fix3(
            fix.Sin(theta) * fix.Cos(phi), // x
            fix.Sin(theta) * fix.Sin(phi), // y
            fix.Cos(theta));               // z
    }

    /// <summary>
    /// Shuffle your list with simulation random
    /// </summary>
    public static void Shuffle<T>(this ref FixRandom random, List<T> collection)
    {
        T temp;
        for (int i = collection.Count - 1; i >= 1; i--)
        {
            int chosen = random.NextInt(0, i + 1);
            if (chosen == i)
                continue;

            temp = collection[chosen];
            collection[chosen] = collection[i];
            collection[i] = temp;
        }
    }

    public static void Shuffle<T>(this ref FixRandom random, T[] collection)
    {
        T temp;
        for (int i = collection.Length - 1; i >= 1; i--)
        {
            int chosen = random.NextInt(0, i + 1);
            if (chosen == i)
                continue;

            temp = collection[chosen];
            collection[chosen] = collection[i];
            collection[i] = temp;
        }
    }
}
