using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Mathematics;
using static Unity.Mathematics.math;

/// <summary>
/// Contains helper math methods.
/// </summary>
public static partial class fixMath
{
#pragma warning disable IDE1006 // Naming Styles
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool samesign(fix a, fix b)
    {
        return sign(a) == sign(b);
    }

    /// <summary>
    /// Calculate remainder of of Fix64 division using same algorithm
    /// as Math.IEEERemainder
    /// </summary>
    /// <param name="dividend">Dividend</param>
    /// <param name="divisor">Divisor</param>
    /// <returns>Remainder</returns>
    internal static fix IEEERemainder(fix dividend,  fix divisor)
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
    internal static fix Clamp(fix value,  fix min,  fix max)
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
    internal static fix Max(fix a,  fix b)
    {
        return a > b ? a : b;
    }

    /// <summary>
    /// Returns the lower value of the two parameters.
    /// </summary>
    /// <param name="a">First value.</param>
    /// <param name="b">Second value.</param>
    /// <returns>Lower value of the two parameters.</returns>
    internal static fix Min(fix a,  fix b)
    {
        return a < b ? a : b;
    }

    /// <summary>
    /// Converts degrees to radians.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix rad(fix degrees) => degrees * F64.CPiOver180;
    
    /// <summary>
    /// Converts radians to degrees.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix deg(fix radians) => radians * F64.C180OverPi;

    public static bool3 almostEqual(fix3 a,  fix3 b) => almostEqual(a, b, fix(0.0001));
    public static bool2 almostEqual(fix2 a,  fix2 b) => almostEqual(a, b, fix(0.0001));
    public static bool almostEqual(fix a,  fix b) => almostEqual(a, b, fix(0.0001));

    public static bool3 almostEqual(fix3 a,  fix3 b,  fix epsilon)
    {
        return bool3(almostEqual(a.x, b.x, epsilon), almostEqual(a.y, b.y, epsilon), almostEqual(a.z, b.z, epsilon));
    }
    public static bool2 almostEqual(fix2 a,  fix2 b,  fix epsilon)
    {
        return bool2(almostEqual(a.x, b.x, epsilon), almostEqual(a.y, b.y, epsilon));
    }
    public static bool almostEqual(fix a,  fix b,  fix epsilon)
    {
        return length(a - b) < epsilon;
    }

    public static fix moveTowards(fix current, fix target, fix maxDistanceDelta)
    {
        fix delta = target - current;
        fix dir = sign(delta);
        if (delta == 0 || delta * dir <= maxDistanceDelta) // delta * dir = abs(delta)
            return target;
        return current + (dir * maxDistanceDelta);
    }

    public static fix2 moveTowards(fix2 current, fix2 target, fix maxDistanceDelta)
    {
        fix2 delta = target - current;
        fix sqdist = lengthsq(delta);

        if (sqdist == 0 || sqdist <= maxDistanceDelta * maxDistanceDelta)
            return target;

        fix dist = sqrt(sqdist);
        fix2 dir = delta / dist;

        return current + (dir * maxDistanceDelta);
    }

    public static fix2 rotateTowards(fix2 currentVector, fix targetAngle, fix maxDeltaAngle)
    {
        fix angle = angle2d(currentVector);

        fix newAngle = moveTowardsAngle(angle, targetAngle, maxDeltaAngle);

        return rotate(currentVector, newAngle - angle);
    }

    public static fix moveTowardsAngle(fix current, fix target, fix maxDelta)
    {
        fix deltaAngle = distanceAngle(current, target);
        if (-maxDelta < deltaAngle && deltaAngle < maxDelta)
            return target;
        target = current + deltaAngle;
        return moveTowards(current, target, maxDelta);
    }

    /// <summary>
    /// Calculates the shortest difference between two given angles.
    /// </summary>
    public static fix distanceAngle(fix current, fix target)
    {
        fix delta = repeat(target - current, TwoPi);
        if (delta > Pi)
            delta -= TwoPi;
        return delta;
    }

    /// <summary>
    /// Loops the value t, so that it is never larger than length and never smaller than 0. 
    /// </summary>
    public static fix repeat(fix t, fix length)
    {
        return clamp(t - floor(t / length) * length, 0, length);
    }

    public static fix2 clampLength(fix2 v, fix min, fix max)
    {
        fix l = length(v);
        if (l <= global::fix.Epsilon)
            return new fix2(min, 0);
        return clamp(l, min, max) * (v / l);
    }

    public static fix3 clampLength(fix3 v, fix min, fix max)
    {
        fix l = length(v);
        if (l <= global::fix.Epsilon)
            return new fix3(min, 0, 0);
        return clamp(l, min, max) * (v / l);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix fix(int value)                                => new fix(value);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix fix(float value)                              => (fix)value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix fix(double value)                             => (fix)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 fix2(fix v)                                => new fix2(v, v);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(fix v)                                => new fix3(v, v, v);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 fix4(fix v)                                => new fix4(v, v, v, v);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 fix2(fix x,  fix y)                      => new fix2(x, y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(fix x,  fix y,  fix z)            => new fix3(x, y, z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 fix4(fix x,  fix y,  fix z,  fix w)  => new fix4(x, y, z, w);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 fix2(int x,  int y)                      => new fix2(x, y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(int x,  int y,  int z)            => new fix3(x, y, z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 fix4(int x,  int y,  int z,  int w)  => new fix4(x, y, z, w);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(fix2 xy,  fix z)                    => new fix3(xy.x, xy.y, z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(fix x,  fix2 yz)                    => new fix3(x, yz.x, yz.y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(fix2 xy,  int z)                    => new fix3(xy.x, xy.y, z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(int x,  fix2 yz)                    => new fix3(x, yz.x, yz.y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(int2 xy,  int z)                    => new fix3(xy.x, xy.y, z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 fix3(int x,  int2 yz)                    => new fix3(x, yz.x, yz.y);

    public static int  roundToInt(fix v)  =>      global::fix.RoundToInt(v);
    public static int2 roundToInt(fix2 v) => int2(global::fix.RoundToInt(v.x), global::fix.RoundToInt(v.y));
    public static int3 roundToInt(fix3 v) => int3(global::fix.RoundToInt(v.x), global::fix.RoundToInt(v.y), global::fix.RoundToInt(v.z));
    public static int4 roundToInt(fix4 v) => int4(global::fix.RoundToInt(v.x), global::fix.RoundToInt(v.y), global::fix.RoundToInt(v.z), global::fix.RoundToInt(v.w));
    
    public static int  floorToInt(fix v)  =>      global::fix.FloorToInt(v);
    public static int2 floorToInt(fix2 v) => int2(global::fix.FloorToInt(v.x), global::fix.FloorToInt(v.y));
    public static int3 floorToInt(fix3 v) => int3(global::fix.FloorToInt(v.x), global::fix.FloorToInt(v.y), global::fix.FloorToInt(v.z));
    public static int4 floorToInt(fix4 v) => int4(global::fix.FloorToInt(v.x), global::fix.FloorToInt(v.y), global::fix.FloorToInt(v.z), global::fix.FloorToInt(v.w));
    
    public static int  ceilToInt(fix v)  =>      global::fix.CeilingToInt(v);
    public static int2 ceilToInt(fix2 v) => int2(global::fix.CeilingToInt(v.x), global::fix.CeilingToInt(v.y));
    public static int3 ceilToInt(fix3 v) => int3(global::fix.CeilingToInt(v.x), global::fix.CeilingToInt(v.y), global::fix.CeilingToInt(v.z));
    public static int4 ceilToInt(fix4 v) => int4(global::fix.CeilingToInt(v.x), global::fix.CeilingToInt(v.y), global::fix.CeilingToInt(v.z), global::fix.CeilingToInt(v.w));

    public static fix lengthmanhattan(fix2 v) => abs(v.x) + abs(v.y);
    public static fix lengthmanhattan(fix3 v) => abs(v.x) + abs(v.y) + abs(v.z);
    public static fix lengthmanhattan(fix4 v) => abs(v.x) + abs(v.y) + abs(v.z) + abs(v.w);

    public static fix distancemanhattan(fix x, fix y) { return abs(y - x); }
    public static fix distancemanhattan(fix2 x, fix2 y) { return lengthmanhattan(y - x); }
    public static fix distancemanhattan(fix3 x, fix3 y) { return lengthmanhattan(y - x); }
    public static fix distancemanhattan(fix4 x, fix4 y) { return lengthmanhattan(y - x); }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix angle2d(fix2 v)
    {
        return atan2(v.y, v.x);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix angle2d(fixQuaternion v)
    {
        return fixQuaternion.EulerZ(v);
    }

    /// <summary>
    /// Rotate the vector v by the given radian value
    /// </summary>
    public static fix2 rotate(fix2 v, fix radians)
    {
        fix sin = fixMath.sin(radians);
        fix cos = fixMath.cos(radians);

        return new fix2(
            (cos * v.x) - (sin * v.y),    // x
            (sin * v.x) + (cos * v.y));   // y
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
    public static fix log(fix x) => global::fix.Ln(x);

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
#pragma warning restore IDE1006 // Naming Styles
}
