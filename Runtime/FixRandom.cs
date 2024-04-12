using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public struct FixRandom
{
    Unity.Mathematics.Random _random;

    /// <summary>Initialises a new instance using an int value as seed.</summary>
    public FixRandom(int seed) : this((uint)seed) { }

    /// <summary>Initialises a new instance using an int value as seed.</summary>
    public FixRandom(uint seed)
    {
        _random = new(seed);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FixRandom CreateFromIndex(uint index)
    {
        var result = new FixRandom();
        result._random = Unity.Mathematics.Random.CreateFromIndex(index);
        return result;
    }

    /// <summary>Returns a uniformly random uint value in the interval [0, 4294967294].</summary>
    /// <returns>A uniformly random unsigned integer.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint NextUInt() => _random.NextUInt();

    /// <summary>Returns a uniformly random int value in the interval [-2147483647, 2147483647].</summary>
    /// <returns>A uniformly random integer value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int NextInt() => _random.NextInt();

    /// <summary>Returns a uniformly random bool value.</summary>
    /// <returns>A uniformly random boolean value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool NextBool() => _random.NextBool();


    /// <summary>Returns a uniformly random fix value in the interval [0, 1].</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public fix NextFixRatio() => new fix(NextInt(0, int.MaxValue)) / new fix(int.MaxValue);

    /// <summary>Returns a uniformly random int value in the interval [-2147483647, 2147483647].</summary>
    /// <returns>A uniformly random integer value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public fix NextFix() => NextInt();

    /// <summary> Returns a value between 0 and max</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public fix NextFix(fix max) => NextFixRatio() * max;

    /// <summary> Returns a value between min and max</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public fix NextFix(fix min, fix max) => (NextFixRatio() * (max - min)) + min;

    /// <summary>Returns a uniformly random int value in the interval [0, max).</summary>
    /// <param name="max">The maximum value to generate, exclusive.</param>
    /// <returns>A uniformly random int value in the range [0, max).</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int NextInt(int maxExclusive) => _random.NextInt(maxExclusive);

    /// <summary>Returns a uniformly random int value in the interval [min, max).</summary>
    /// <param name="min">The minimum value to generate, inclusive.</param>
    /// <param name="max">The maximum value to generate, exclusive.</param>
    /// <returns>A uniformly random integer between [min, max).</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int NextInt(int min, int maxExclusive) => _random.NextInt(min, maxExclusive);


    public int2 NextInt2() => _random.NextInt2();
    public int3 NextInt3() => _random.NextInt3();
    public int4 NextInt4() => _random.NextInt4();
    public uint2 NextUInt2() => _random.NextUInt2();
    public uint3 NextUInt3() => _random.NextUInt3();
    public uint4 NextUInt4() => _random.NextUInt4();
    public bool2 NextBool2() => _random.NextBool2();
    public bool3 NextBool3() => _random.NextBool3();
    public bool4 NextBool4() => _random.NextBool4();
    public int2 NextInt2(int2 max) => _random.NextInt2(max);
    public int3 NextInt3(int3 max) => _random.NextInt3(max);
    public int4 NextInt4(int4 max) => _random.NextInt4(max);
    public uint2 NextUInt2(uint2 max) => _random.NextUInt2(max);
    public uint3 NextUInt3(uint3 max) => _random.NextUInt3(max);
    public uint4 NextUInt4(uint4 max) => _random.NextUInt4(max);
    public int2 NextInt2(int2 min, int2 max) => _random.NextInt2(min, max);
    public int3 NextInt3(int3 min, int3 max) => _random.NextInt3(min, max);
    public int4 NextInt4(int4 min, int4 max) => _random.NextInt4(min, max);
    public uint2 NextUInt2(uint2 min, uint2 max) => _random.NextUInt2(min, max);
    public uint3 NextUInt3(uint3 min, uint3 max) => _random.NextUInt3(min, max);
    public uint4 NextUInt4(uint4 min, uint4 max) => _random.NextUInt4(min, max);
}
