using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using static Unity.Mathematics.math;

/// <summary>
/// Contains helper math methods.
/// </summary>
public static partial class fixMath
{
    /// <summary>
    /// Approximate value of Pi.
    /// </summary>
    internal static readonly fix Pi = global::fix.Pi;

    /// <summary>
    /// Approximate value of Pi multiplied by two.
    /// </summary>
    internal static readonly fix TwoPi = global::fix.PiTimes2;

    /// <summary>
    /// Approximate value of Pi divided by two.
    /// </summary>
    internal static readonly fix PiOver2 = global::fix.PiOver2;

    /// <summary>
    /// Approximate value of Pi divided by four.
    /// </summary>
    internal static readonly fix PiOver4 = global::fix.Pi / new fix(4);

    /// <summary>
    /// Calculate remainder of of Fix64 division using same algorithm
    /// as Math.IEEERemainder
    /// </summary>
    /// <param name="dividend">Dividend</param>
    /// <param name="divisor">Divisor</param>
    /// <returns>Remainder</returns>
    internal static fix IEEERemainder(in fix dividend, in fix divisor)
    {
        return dividend - (divisor * global::fix.Round(dividend / divisor));
    }

    /// <summary>
    /// Reduces the angle into a range from -Pi to Pi.
    /// </summary>
    /// <param name="angle">Angle to wrap.</param>
    /// <returns>Wrapped angle.</returns>
    public static fix WrapAngle(fix angle)
    {
        angle = IEEERemainder(angle, TwoPi);
        if (angle < -Pi)
        {
            angle += TwoPi;
            return angle;
        }
        if (angle >= Pi)
        {
            angle -= TwoPi;
        }
        return angle;

    }

    /// <summary>
    /// Clamps a value between a minimum and maximum value.
    /// </summary>
    /// <param name="value">Value to clamp.</param>
    /// <param name="min">Minimum value.  If the value is less than this, the minimum is returned instead.</param>
    /// <param name="max">Maximum value.  If the value is more than this, the maximum is returned instead.</param>
    /// <returns>Clamped value.</returns>
    internal static fix Clamp(in fix value, in fix min, in fix max)
    {
        if (value < min)
            return min;
        else if (value > max)
            return max;
        return value;
    }

    /// <summary>
    /// Returns the higher value of the two parameters.
    /// </summary>
    /// <param name="a">First value.</param>
    /// <param name="b">Second value.</param>
    /// <returns>Higher value of the two parameters.</returns>
    internal static fix Max(in fix a, in fix b)
    {
        return a > b ? a : b;
    }

    /// <summary>
    /// Returns the lower value of the two parameters.
    /// </summary>
    /// <param name="a">First value.</param>
    /// <param name="b">Second value.</param>
    /// <returns>Lower value of the two parameters.</returns>
    internal static fix Min(in fix a, in fix b)
    {
        return a < b ? a : b;
    }

    /// <summary>
    /// Converts degrees to radians.
    /// </summary>
    /// <param name="degrees">Degrees to convert.</param>
    /// <returns>Radians equivalent to the input degrees.</returns>
    internal static fix ToRadians(in fix degrees)
    {
        return degrees * (Pi / F64.C180);
    }

    /// <summary>
    /// Converts radians to degrees.
    /// </summary>
    /// <param name="radians">Radians to convert.</param>
    /// <returns>Degrees equivalent to the input radians.</returns>
    internal static fix ToDegrees(in fix radians)
    {
        return radians * (F64.C180 / Pi);
    }

    public static bool3 almostEqual(in fix3 a, in fix3 b) => almostEqual(a, b, fix(0.0001));
    public static bool2 almostEqual(in fix2 a, in fix2 b) => almostEqual(a, b, fix(0.0001));
    public static bool almostEqual(in fix a, in fix b) => almostEqual(a, b, fix(0.0001));

    public static bool3 almostEqual(in fix3 a, in fix3 b, in fix epsilon)
    {
        return bool3(almostEqual(a.x, b.x, epsilon), almostEqual(a.y, b.y, epsilon), almostEqual(a.z, b.z, epsilon));
    }
    public static bool2 almostEqual(in fix2 a, in fix2 b, in fix epsilon)
    {
        return bool2(almostEqual(a.x, b.x, epsilon), almostEqual(a.y, b.y, epsilon));
    }
    public static bool almostEqual(in fix a, in fix b, in fix epsilon)
    {
        return length(a - b) < epsilon;
    }





    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix fix(int value)                                => new fix(value);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix fix(float value)                              => (fix)value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix fix(double value)                             => (fix)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 fix2(in fix v)                                => new fix2(v, v);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(in fix v)                                => new fix3(v, v, v);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 fix4(in fix v)                                => new fix4(v, v, v, v);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 fix2(in fix x, in fix y)                      => new fix2(x, y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(in fix x, in fix y, in fix z)            => new fix3(x, y, z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 fix4(in fix x, in fix y, in fix z, in fix w)  => new fix4(x, y, z, w);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 fix2(in int x, in int y)                      => new fix2(x, y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(in int x, in int y, in int z)            => new fix3(x, y, z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 fix4(in int x, in int y, in int z, in int w)  => new fix4(x, y, z, w);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(in fix2 xy, in fix z)                    => new fix3(xy.x, xy.y, z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(in fix x, in fix2 yz)                    => new fix3(x, yz.x, yz.y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(in fix2 xy, in int z)                    => new fix3(xy.x, xy.y, z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(in int x, in fix2 yz)                    => new fix3(x, yz.x, yz.y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(in int2 xy, in int z)                    => new fix3(xy.x, xy.y, z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(in int x, in int2 yz)                    => new fix3(x, yz.x, yz.y);

    public static int  roundToInt(in fix v)  =>      global::fix.RoundToInt(v);
    public static int2 roundToInt(in fix2 v) => int2(global::fix.RoundToInt(v.x), global::fix.RoundToInt(v.y));
    public static int3 roundToInt(in fix3 v) => int3(global::fix.RoundToInt(v.x), global::fix.RoundToInt(v.y), global::fix.RoundToInt(v.z));
    public static int4 roundToInt(in fix4 v) => int4(global::fix.RoundToInt(v.x), global::fix.RoundToInt(v.y), global::fix.RoundToInt(v.z), global::fix.RoundToInt(v.w));
    
    public static int  floorToInt(in fix v)  =>      global::fix.FloorToInt(v);
    public static int2 floorToInt(in fix2 v) => int2(global::fix.FloorToInt(v.x), global::fix.FloorToInt(v.y));
    public static int3 floorToInt(in fix3 v) => int3(global::fix.FloorToInt(v.x), global::fix.FloorToInt(v.y), global::fix.FloorToInt(v.z));
    public static int4 floorToInt(in fix4 v) => int4(global::fix.FloorToInt(v.x), global::fix.FloorToInt(v.y), global::fix.FloorToInt(v.z), global::fix.FloorToInt(v.w));
    
    public static int  ceilToInt(in fix v)  =>      global::fix.CeilingToInt(v);
    public static int2 ceilToInt(in fix2 v) => int2(global::fix.CeilingToInt(v.x), global::fix.CeilingToInt(v.y));
    public static int3 ceilToInt(in fix3 v) => int3(global::fix.CeilingToInt(v.x), global::fix.CeilingToInt(v.y), global::fix.CeilingToInt(v.z));
    public static int4 ceilToInt(in fix4 v) => int4(global::fix.CeilingToInt(v.x), global::fix.CeilingToInt(v.y), global::fix.CeilingToInt(v.z), global::fix.CeilingToInt(v.w));

    public static fix lengthmanhattan(fix2 v) => abs(v.x) +abs(v.y);
    public static fix lengthmanhattan(fix3 v) => abs(v.x) + abs(v.y) + abs(v.z);
    public static fix lengthmanhattan(fix4 v) => abs(v.x) + abs(v.y) + abs(v.z) + abs(v.w);
    public static int lengthmanhattan(int2 v) => math.abs(v.x) + math.abs(v.y);
    public static int lengthmanhattan(int3 v) => math.abs(v.x) + math.abs(v.y) + math.abs(v.z);
    public static int lengthmanhattan(int4 v) => math.abs(v.x) + math.abs(v.y) + math.abs(v.z) + math.abs(v.w);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix angle2d(fix2 v)
    {
        return atan2(v.y, v.x);
    }

    /// <summary>
    /// Returns 2 raised to the specified power.
    /// Provides at least 6 decimals of accuracy.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix pow2(fix x) => global::fix.Pow2(x);

    /// <summary>
    /// Returns the base-2 logarithm of a specified number.
    /// Provides at least 9 decimals of accuracy.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The argument was non-positive
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix log2(fix x) => global::fix.Log2(x);

    /// <summary>
    /// Returns the natural logarithm of a specified number.
    /// Provides at least 7 decimals of accuracy.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The argument was non-positive
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix ln(fix x) => global::fix.Ln(x);

    /// <summary>
    /// Returns a rough approximation of the Sine of x.
    /// This is at least 3 times faster than Sin() on x86 and slightly faster than Math.Sin(),
    /// however its accuracy is limited to 4-5 decimals, for small enough values of x.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix fsin(fix x) => global::fix.FastSin(x);

    /// <summary>
    /// Returns a rough approximation of the cosine of x.
    /// See FastSin for more details.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix fcos(fix x) => global::fix.FastCos(x);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix atan2(fix y, fix x) => global::fix.Atan2(y, x);

    //public static fix sqrt(fix x) { return global::fix.Sqrt(x); }
    //public static fix2 sqrt(fix2 x) { return new fix2(sqrt(x.x), sqrt(x.y)); }
    //public static fix3 sqrt(fix3 x) { return new fix3(sqrt(x.x), sqrt(x.y), sqrt(x.z)); }
    //public static fix4 sqrt(fix4 x) { return new fix4(sqrt(x.x), sqrt(x.y), sqrt(x.z), sqrt(x.w)); }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static fix dot(fix x, fix y) { return x * y; }
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static fix dot(fix2 x, fix2 y) { return x.x * y.x + x.y * y.y; }
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static fix dot(fix3 x, fix3 y) { return x.x * y.x + x.y * y.y + x.z * y.z; }
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static fix dot(fix4 x, fix4 y) { return x.x * y.x + x.y * y.y + x.z * y.z + x.w * y.w; }
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static fix rsqrt(fix x) { return 1 / sqrt(x); }
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static fix2 rsqrt(fix2 x) { return 1 / sqrt(x); }
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static fix3 rsqrt(fix3 x) { return 1 / sqrt(x); }
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static fix4 rsqrt(fix4 x) { return fix4(1) / sqrt(x); }


    //public static fix length(in fix2 v)   => v.length;
    //public static fix length(in fix3 v)   => v.length;
    //public static fix length(in fix4 v)   => v.length;
    //public static fix lengthsq(in fix2 v) => v.lengthSquared;
    //public static fix lengthsq(in fix3 v) => v.lengthSquared;
    //public static fix lengthsq(in fix4 v) => v.lengthSquared;

    //public static fix2 normalize(in fix2 v) => global::fix2.Normalize(v);
    //public static fix3 normalize(in fix3 v) => global::fix3.Normalize(v);
    //public static fix4 normalize(in fix4 v) => global::fix4.Normalize(v);

    //public static fix  round(in fix v)  =>      global::fix.Round(v);
    //public static fix2 round(in fix2 v) => fix2(global::fix.Round(v.x), global::fix.Round(v.y));
    //public static fix3 round(in fix3 v) => fix3(global::fix.Round(v.x), global::fix.Round(v.y), global::fix.Round(v.z));
    //public static fix4 round(in fix4 v) => fix4(global::fix.Round(v.x), global::fix.Round(v.y), global::fix.Round(v.z), global::fix.Round(v.w));

}
