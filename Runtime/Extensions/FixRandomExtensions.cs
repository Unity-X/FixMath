using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

public static class FixRandomExtensions
{
    public static fix2 NextFix2(this ref FixRandom random) => new fix2(random.NextFix(), random.NextFix());
    public static fix2 NextFix2(this ref FixRandom random, fix2 max) => new fix2(random.NextFix(max.x), random.NextFix(max.y));
    public static fix2 NextFix2(this ref FixRandom random, fix2 min, fix2 max) => new fix2(random.NextFix(min.x, max.x), random.NextFix(min.y, max.y));
    public static fix3 NextFix3(this ref FixRandom random) => new fix3(random.NextFix(), random.NextFix(), random.NextFix());
    public static fix3 NextFix3(this ref FixRandom random, fix3 max) => new fix3(random.NextFix(max.x), random.NextFix(max.y), random.NextFix(max.z));
    public static fix3 NextFix3(this ref FixRandom random, fix3 min, fix3 max) => new fix3(random.NextFix(min.x, max.x), random.NextFix(min.y, max.y), random.NextFix(min.z, max.z));
    public static fix4 NextFix4(this ref FixRandom random) => new fix4(random.NextFix(), random.NextFix(), random.NextFix(), random.NextFix());
    public static fix4 NextFix4(this ref FixRandom random, fix4 max) => new fix4(random.NextFix(max.x), random.NextFix(max.y), random.NextFix(max.z), random.NextFix(max.w));
    public static fix4 NextFix4(this ref FixRandom random, fix4 min, fix4 max) => new fix4(random.NextFix(min.x, max.x), random.NextFix(min.y, max.y), random.NextFix(min.z, max.z), random.NextFix(min.w, max.w));

    // methods that were not yet ported from Unity.Mathematic.Random
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

    /// <summary>
    /// Shuffle your list with simulation random
    /// </summary>
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

    /// <summary>
    /// Shuffle your list with simulation random
    /// </summary>
    public static unsafe void Shuffle<T>(this ref FixRandom random, void* collection, int length) where T : struct
    {
        T temp;
        for (int i = length - 1; i >= 1; i--)
        {
            int chosen = random.NextInt(0, i + 1);
            if (chosen == i)
                continue;

            temp = UnsafeUtility.ArrayElementAsRef<T>(collection, chosen);
            UnsafeUtility.ArrayElementAsRef<T>(collection, chosen) = UnsafeUtility.ArrayElementAsRef<T>(collection, i);
            UnsafeUtility.ArrayElementAsRef<T>(collection, i) = temp;
        }
    }

    /// <summary>
    /// Shuffle your list with simulation random
    /// </summary>
    public static void Shuffle<T>(this ref FixRandom random, NativeArray<T> collection) where T : struct
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

    /// <summary>
    /// Shuffle your list with simulation random
    /// </summary>
    public static void Shuffle<T>(this ref FixRandom random, NativeList<T> collection) where T : unmanaged
    {
        Shuffle(ref random, collection.AsArray());
    }

    public static T NextElement<T>(this ref FixRandom random, NativeArray<T> collection) where T : unmanaged
    {
        int idx = random.NextInt(collection.Length);
        return collection[idx];
    }

    public static T NextElement<T>(this ref FixRandom random, NativeList<T> collection) where T : unmanaged
    {
        int idx = random.NextInt(collection.Length);
        return collection[idx];
    }
}
