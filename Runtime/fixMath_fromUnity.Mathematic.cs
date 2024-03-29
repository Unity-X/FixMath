using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

public static partial class fixMath
{
    /// <summary>The mathematical constant e also known as Euler's number. Approximately 2.72. This is a f64/double precision constant.</summary>
    public const double E_DBL = 2.71828182845904523536;

    /// <summary>The base 2 logarithm of e. Approximately 1.44. This is a f64/double precision constant.</summary>
    public const double LOG2E_DBL = 1.44269504088896340736;

    /// <summary>The base 10 logarithm of e. Approximately 0.43. This is a f64/double precision constant.</summary>
    public const double LOG10E_DBL = 0.434294481903251827651;

    /// <summary>The natural logarithm of 2. Approximately 0.69. This is a f64/double precision constant.</summary>
    public const double LN2_DBL = 0.693147180559945309417;

    /// <summary>The natural logarithm of 10. Approximately 2.30. This is a f64/double precision constant.</summary>
    public const double LN10_DBL = 2.30258509299404568402;

    /// <summary>The mathematical constant pi. Approximately 3.14. This is a f64/double precision constant.</summary>
    public const double PI_DBL = 3.14159265358979323846;

    /// <summary>The square root 2. Approximately 1.41. This is a f64/double precision constant.</summary>
    public const double SQRT2_DBL = 1.41421356237309504880;

    /// <summary>The smallest positive normal number representable in a fix.</summary>
    public static fix FLT_MIN_NORMAL => global::fix.Epsilon;

    /// <summary>The mathematical constant e also known as Euler's number. Approximately 2.72.</summary>
    public static fix E => (fix)E_DBL;

    /// <summary>The base 2 logarithm of e. Approximately 1.44.</summary>
    public static fix LOG2E => (fix)LOG2E_DBL;

    /// <summary>The base 10 logarithm of e. Approximately 0.43.</summary>
    public static fix LOG10E => (fix)LOG10E_DBL;

    /// <summary>The natural logarithm of 2. Approximately 0.69.</summary>
    public static fix LN2 => (fix)LN2_DBL;

    /// <summary>The natural logarithm of 10. Approximately 2.30.</summary>
    public static fix LN10 => (fix)LN10_DBL;

    /// <summary>The mathematical constant pi. Approximately 3.14.</summary>
    public static fix PI => (fix)PI_DBL;

    /// <summary>The square root 2. Approximately 1.41.</summary>
    public static fix SQRT2 => (fix)SQRT2_DBL;

    /// <summary>Returns the minimum of two fix values.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix min(fix x, fix y) { return x < y ? x : y; }

    /// <summary>Returns the componentwise minimum of two fix2 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 min(fix2 x, fix2 y) { return new fix2(min(x.x, y.x), min(x.y, y.y)); }

    /// <summary>Returns the componentwise minimum of two fix3 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 min(fix3 x, fix3 y) { return new fix3(min(x.x, y.x), min(x.y, y.y), min(x.z, y.z)); }

    /// <summary>Returns the componentwise minimum of two fix4 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 min(fix4 x, fix4 y) { return new fix4(min(x.x, y.x), min(x.y, y.y), min(x.z, y.z), min(x.w, y.w)); }


    /// <summary>Returns the maximum of two fix values.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix max(fix x, fix y) { return x > y ? x : y; }

    /// <summary>Returns the componentwise maximum of two fix2 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 max(fix2 x, fix2 y) { return new fix2(max(x.x, y.x), max(x.y, y.y)); }

    /// <summary>Returns the componentwise maximum of two fix3 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 max(fix3 x, fix3 y) { return new fix3(max(x.x, y.x), max(x.y, y.y), max(x.z, y.z)); }

    /// <summary>Returns the componentwise maximum of two fix4 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 max(fix4 x, fix4 y) { return new fix4(max(x.x, y.x), max(x.y, y.y), max(x.z, y.z), max(x.w, y.w)); }


    /// <summary>Returns the result of linearly interpolating from x to y using the interpolation parameter s.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix lerp(fix x, fix y, fix s) { return x + s * (y - x); }

    /// <summary>Returns the result of a componentwise linear interpolating from x to y using the interpolation parameter s.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 lerp(fix2 x, fix2 y, fix s) { return x + s * (y - x); }

    /// <summary>Returns the result of a componentwise linear interpolating from x to y using the interpolation parameter s.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 lerp(fix3 x, fix3 y, fix s) { return x + s * (y - x); }

    /// <summary>Returns the result of a componentwise linear interpolating from x to y using the interpolation parameter s.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 lerp(fix4 x, fix4 y, fix s) { return x + s * (y - x); }


    /// <summary>Returns the result of a componentwise linear interpolating from x to y using the corresponding components of the interpolation parameter s.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 lerp(fix2 x, fix2 y, fix2 s) { return x + s * (y - x); }

    /// <summary>Returns the result of a componentwise linear interpolating from x to y using the corresponding components of the interpolation parameter s.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 lerp(fix3 x, fix3 y, fix3 s) { return x + s * (y - x); }

    /// <summary>Returns the result of a componentwise linear interpolating from x to y using the corresponding components of the interpolation parameter s.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 lerp(fix4 x, fix4 y, fix4 s) { return x + s * (y - x); }


    /// <summary>Returns the result of normalizing a fixing point value x to a range [a, b]. The opposite of lerp. Equivalent to (x - a) / (b - a).</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix unlerp(fix a, fix b, fix x) { return (x - a) / (b - a); }

    /// <summary>Returns the componentwise result of normalizing a fixing point value x to a range [a, b]. The opposite of lerp. Equivalent to (x - a) / (b - a).</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 unlerp(fix2 a, fix2 b, fix2 x) { return (x - a) / (b - a); }

    /// <summary>Returns the componentwise result of normalizing a fixing point value x to a range [a, b]. The opposite of lerp. Equivalent to (x - a) / (b - a).</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 unlerp(fix3 a, fix3 b, fix3 x) { return (x - a) / (b - a); }

    /// <summary>Returns the componentwise result of normalizing a fixing point value x to a range [a, b]. The opposite of lerp. Equivalent to (x - a) / (b - a).</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 unlerp(fix4 a, fix4 b, fix4 x) { return (x - a) / (b - a); }


    /// <summary>Returns the result of a non-clamping linear remapping of a value x from [a, b] to [c, d].</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix remap(fix a, fix b, fix c, fix d, fix x) { return lerp(c, d, unlerp(a, b, x)); }

    /// <summary>Returns the componentwise result of a non-clamping linear remapping of a value x from [a, b] to [c, d].</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 remap(fix2 a, fix2 b, fix2 c, fix2 d, fix2 x) { return lerp(c, d, unlerp(a, b, x)); }

    /// <summary>Returns the componentwise result of a non-clamping linear remapping of a value x from [a, b] to [c, d].</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 remap(fix3 a, fix3 b, fix3 c, fix3 d, fix3 x) { return lerp(c, d, unlerp(a, b, x)); }

    /// <summary>Returns the componentwise result of a non-clamping linear remapping of a value x from [a, b] to [c, d].</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 remap(fix4 a, fix4 b, fix4 c, fix4 d, fix4 x) { return lerp(c, d, unlerp(a, b, x)); }


    /// <summary>Returns the result of a multiply-add operation (a * b + c) on 3 fix values.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix mad(fix a, fix b, fix c) { return a * b + c; }

    /// <summary>Returns the result of a componentwise multiply-add operation (a * b + c) on 3 fix2 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 mad(fix2 a, fix2 b, fix2 c) { return a * b + c; }

    /// <summary>Returns the result of a componentwise multiply-add operation (a * b + c) on 3 fix3 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 mad(fix3 a, fix3 b, fix3 c) { return a * b + c; }

    /// <summary>Returns the result of a componentwise multiply-add operation (a * b + c) on 3 fix4 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 mad(fix4 a, fix4 b, fix4 c) { return a * b + c; }


    /// <summary>Returns the result of clamping the value x into the interval [a, b], where x, a and b are fix values.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix clamp(fix x, fix a, fix b) { return max(a, min(b, x)); }

    /// <summary>Returns the result of a componentwise clamping of the value x into the interval [a, b], where x, a and b are fix2 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 clamp(fix2 x, fix2 a, fix2 b) { return max(a, min(b, x)); }

    /// <summary>Returns the result of a componentwise clamping of the value x into the interval [a, b], where x, a and b are fix3 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 clamp(fix3 x, fix3 a, fix3 b) { return max(a, min(b, x)); }

    /// <summary>Returns the result of a componentwise clamping of the value x into the interval [a, b], where x, a and b are fix4 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 clamp(fix4 x, fix4 a, fix4 b) { return max(a, min(b, x)); }


    /// <summary>Returns the result of clamping the fix value x into the interval [0, 1].</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix saturate(fix x) { return clamp(x, fix(0), fix(1)); }

    /// <summary>Returns the result of a componentwise clamping of the fix2 vector x into the interval [0, 1].</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 saturate(fix2 x) { return clamp(x, new fix2(0), new fix2(1)); }

    /// <summary>Returns the result of a componentwise clamping of the fix3 vector x into the interval [0, 1].</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 saturate(fix3 x) { return clamp(x, new fix3(0), new fix3(1)); }

    /// <summary>Returns the result of a componentwise clamping of the fix4 vector x into the interval [0, 1].</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 saturate(fix4 x) { return clamp(x, new fix4(0), new fix4(1)); }


    /// <summary>Returns the absolute value of a fix value.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix abs(fix x) { return global::fix.Abs(x); }

    /// <summary>Returns the componentwise absolute value of a fix2 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 abs(fix2 x) { return new fix2(abs(x.x), abs(x.y)); }

    /// <summary>Returns the componentwise absolute value of a fix3 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 abs(fix3 x) { return new fix3(abs(x.x), abs(x.y), abs(x.z)); }

    /// <summary>Returns the componentwise absolute value of a fix4 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 abs(fix4 x) { return new fix4(abs(x.x), abs(x.y), abs(x.z), abs(x.w)); }


    /// <summary>Returns the dot product of two fix values. Equivalent to multiplication.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix dot(fix x, fix y) { return x * y; }

    /// <summary>Returns the dot product of two fix2 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix dot(fix2 x, fix2 y) { return x.x * y.x + x.y * y.y; }

    /// <summary>Returns the dot product of two fix3 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix dot(fix3 x, fix3 y) { return x.x * y.x + x.y * y.y + x.z * y.z; }

    /// <summary>Returns the dot product of two fix4 vectors.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix dot(fix4 x, fix4 y) { return x.x * y.x + x.y * y.y + x.z * y.z + x.w * y.w; }


    /// <summary>Returns the tangent of a fix value.</summary>
    public static fix tan(fix x) { return global::fix.Tan(x); }

    /// <summary>Returns the componentwise tangent of a fix2 vector.</summary>
    public static fix2 tan(fix2 x) { return new fix2(tan(x.x), tan(x.y)); }

    /// <summary>Returns the componentwise tangent of a fix3 vector.</summary>
    public static fix3 tan(fix3 x) { return new fix3(tan(x.x), tan(x.y), tan(x.z)); }

    /// <summary>Returns the componentwise tangent of a fix4 vector.</summary>
    public static fix4 tan(fix4 x) { return new fix4(tan(x.x), tan(x.y), tan(x.z), tan(x.w)); }
    

    /// <summary>Returns the arctangent of a fix value.</summary>
    public static fix atan(fix x) { return global::fix.Atan(x); }

    /// <summary>Returns the componentwise arctangent of a fix2 vector.</summary>
    public static fix2 atan(fix2 x) { return new fix2(atan(x.x), atan(x.y)); }

    /// <summary>Returns the componentwise arctangent of a fix3 vector.</summary>
    public static fix3 atan(fix3 x) { return new fix3(atan(x.x), atan(x.y), atan(x.z)); }

    /// <summary>Returns the componentwise arctangent of a fix4 vector.</summary>
    public static fix4 atan(fix4 x) { return new fix4(atan(x.x), atan(x.y), atan(x.z), atan(x.w)); }

    /// <summary>Returns the cosine of a fix value.</summary>
    public static fix cos(fix x) { return global::fix.Cos(x); }

    /// <summary>Returns the componentwise cosine of a fix2 vector.</summary>
    public static fix2 cos(fix2 x) { return new fix2(cos(x.x), cos(x.y)); }

    /// <summary>Returns the componentwise cosine of a fix3 vector.</summary>
    public static fix3 cos(fix3 x) { return new fix3(cos(x.x), cos(x.y), cos(x.z)); }

    /// <summary>Returns the componentwise cosine of a fix4 vector.</summary>
    public static fix4 cos(fix4 x) { return new fix4(cos(x.x), cos(x.y), cos(x.z), cos(x.w)); }


    /// <summary>Returns the arccosine of a fix value.</summary>
    public static fix acos(fix x) { return global::fix.Acos(x); }

    /// <summary>Returns the componentwise arccosine of a fix2 vector.</summary>
    public static fix2 acos(fix2 x) { return new fix2(acos(x.x), acos(x.y)); }

    /// <summary>Returns the componentwise arccosine of a fix3 vector.</summary>
    public static fix3 acos(fix3 x) { return new fix3(acos(x.x), acos(x.y), acos(x.z)); }

    /// <summary>Returns the componentwise arccosine of a fix4 vector.</summary>
    public static fix4 acos(fix4 x) { return new fix4(acos(x.x), acos(x.y), acos(x.z), acos(x.w)); }


    /// <summary>Returns the sine of a fix value.</summary>
    public static fix sin(fix x) { return global::fix.Sin(x); }

    /// <summary>Returns the componentwise sine of a fix2 vector.</summary>
    public static fix2 sin(fix2 x) { return new fix2(sin(x.x), sin(x.y)); }

    /// <summary>Returns the componentwise sine of a fix3 vector.</summary>
    public static fix3 sin(fix3 x) { return new fix3(sin(x.x), sin(x.y), sin(x.z)); }

    /// <summary>Returns the componentwise sine of a fix4 vector.</summary>
    public static fix4 sin(fix4 x) { return new fix4(sin(x.x), sin(x.y), sin(x.z), sin(x.w)); }


    // ASIN IS NOT IMPLEMENTED YET
    ///// <summary>Returns the arcsine of a fix value.</summary>
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static fix asin(fix x) { return (fix)global::fix.ASin((fix)x); }

    ///// <summary>Returns the componentwise arcsine of a fix2 vector.</summary>
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static fix2 asin(fix2 x) { return new fix2(asin(x.x), asin(x.y)); }

    ///// <summary>Returns the componentwise arcsine of a fix3 vector.</summary>
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static fix3 asin(fix3 x) { return new fix3(asin(x.x), asin(x.y), asin(x.z)); }

    ///// <summary>Returns the componentwise arcsine of a fix4 vector.</summary>
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static fix4 asin(fix4 x) { return new fix4(asin(x.x), asin(x.y), asin(x.z), asin(x.w)); }


    /// <summary>Returns the result of rounding a fix value up to the nearest integral value less or equal to the original value.</summary>
    public static fix floor(fix x) { return global::fix.Floor(x); }

    /// <summary>Returns the result of rounding each component of a fix2 vector value down to the nearest value less or equal to the original value.</summary>
    public static fix2 floor(fix2 x) { return new fix2(floor(x.x), floor(x.y)); }

    /// <summary>Returns the result of rounding each component of a fix3 vector value down to the nearest value less or equal to the original value.</summary>
    public static fix3 floor(fix3 x) { return new fix3(floor(x.x), floor(x.y), floor(x.z)); }

    /// <summary>Returns the result of rounding each component of a fix4 vector value down to the nearest value less or equal to the original value.</summary>
    public static fix4 floor(fix4 x) { return new fix4(floor(x.x), floor(x.y), floor(x.z), floor(x.w)); }

    /// <summary>Returns the result of rounding a fix value up to the nearest integral value greater or equal to the original value.</summary>
    public static fix ceil(fix x) { return global::fix.Ceiling(x); }

    /// <summary>Returns the result of rounding each component of a fix2 vector value up to the nearest value greater or equal to the original value.</summary>
    public static fix2 ceil(fix2 x) { return new fix2(ceil(x.x), ceil(x.y)); }

    /// <summary>Returns the result of rounding each component of a fix3 vector value up to the nearest value greater or equal to the original value.</summary>
    public static fix3 ceil(fix3 x) { return new fix3(ceil(x.x), ceil(x.y), ceil(x.z)); }

    /// <summary>Returns the result of rounding each component of a fix4 vector value up to the nearest value greater or equal to the original value.</summary>
    public static fix4 ceil(fix4 x) { return new fix4(ceil(x.x), ceil(x.y), ceil(x.z), ceil(x.w)); }


    /// <summary>Returns the result of rounding a fix value to the nearest integral value.</summary>
    public static fix round(fix x) { return global::fix.Round(x); }

    /// <summary>Returns the result of rounding each component of a fix2 vector value to the nearest integral value.</summary>
    public static fix2 round(fix2 x) { return new fix2(round(x.x), round(x.y)); }

    /// <summary>Returns the result of rounding each component of a fix3 vector value to the nearest integral value.</summary>
    public static fix3 round(fix3 x) { return new fix3(round(x.x), round(x.y), round(x.z)); }

    /// <summary>Returns the result of rounding each component of a fix4 vector value to the nearest integral value.</summary>
    public static fix4 round(fix4 x) { return new fix4(round(x.x), round(x.y), round(x.z), round(x.w)); }


    /// <summary>Returns the fractional part of a fix value.</summary>
    public static fix frac(fix x) { return x - floor(x); }

    /// <summary>Returns the componentwise fractional parts of a fix2 vector.</summary>
    public static fix2 frac(fix2 x) { return x - floor(x); }

    /// <summary>Returns the componentwise fractional parts of a fix3 vector.</summary>
    public static fix3 frac(fix3 x) { return x - floor(x); }

    /// <summary>Returns the componentwise fractional parts of a fix4 vector.</summary>
    public static fix4 frac(fix4 x) { return x - floor(x); }


    /// <summary>Returns the reciprocal a fix value.</summary>
    public static fix rcp(fix x) { return fix(1) / x; }

    /// <summary>Returns the componentwise reciprocal a fix2 vector.</summary>
    public static fix2 rcp(fix2 x) { return fix(1) / x; }

    /// <summary>Returns the componentwise reciprocal a fix3 vector.</summary>
    public static fix3 rcp(fix3 x) { return fix(1) / x; }

    /// <summary>Returns the componentwise reciprocal a fix4 vector.</summary>
    public static fix4 rcp(fix4 x) { return fix(1) / x; }


    /// <summary>Returns the sign of a fix value. -fix(1) if it is less than zero, fix(0) if it is zero and fix(1) if it greater than zero.</summary>
    public static fix sign(fix x) { return global::fix.Sign(x); }

    /// <summary>Returns the componentwise sign of a fix2 value. fix(1) for positive components, fix(0) for zero components and -fix(1) for negative components.</summary>
    public static fix2 sign(fix2 x) { return new fix2(sign(x.x), sign(x.y)); }

    /// <summary>Returns the componentwise sign of a fix3 value. fix(1) for positive components, fix(0) for zero components and -fix(1) for negative components.</summary>
    public static fix3 sign(fix3 x) { return new fix3(sign(x.x), sign(x.y), sign(x.z)); }

    /// <summary>Returns the componentwise sign of a fix4 value. fix(1) for positive components, fix(0) for zero components and -fix(1) for negative components.</summary>
    public static fix4 sign(fix4 x) { return new fix4(sign(x.x), sign(x.y), sign(x.z), sign(x.w)); }


    /// <summary>Returns x raised to the power y.</summary>
    public static fix pow(fix x, fix y) { return global::fix.Pow(x, y); }

    /// <summary>Returns the componentwise result of raising x to the power y.</summary>
    public static fix2 pow(fix2 x, fix2 y) { return new fix2(pow(x.x, y.x), pow(x.y, y.y)); }

    /// <summary>Returns the componentwise result of raising x to the power y.</summary>
    public static fix3 pow(fix3 x, fix3 y) { return new fix3(pow(x.x, y.x), pow(x.y, y.y), pow(x.z, y.z)); }

    /// <summary>Returns the componentwise result of raising x to the power y.</summary>
    public static fix4 pow(fix4 x, fix4 y) { return new fix4(pow(x.x, y.x), pow(x.y, y.y), pow(x.z, y.z), pow(x.w, y.w)); }


    /// <summary>Returns the base-e exponential of x.</summary>
    public static fix exp(fix x) { return global::fix.Pow(E, x); }

    /// <summary>Returns the componentwise base-e exponential of x.</summary>
    public static fix2 exp(fix2 x) { return new fix2(exp(x.x), exp(x.y)); }

    /// <summary>Returns the componentwise base-e exponential of x.</summary>
    public static fix3 exp(fix3 x) { return new fix3(exp(x.x), exp(x.y), exp(x.z)); }

    /// <summary>Returns the componentwise base-e exponential of x.</summary>
    public static fix4 exp(fix4 x) { return new fix4(exp(x.x), exp(x.y), exp(x.z), exp(x.w)); }


    /// <summary>Returns the base-2 exponential of x.</summary>
    public static fix exp2(fix x) { return global::fix.Pow(fix(2), x); }

    /// <summary>Returns the componentwise base-2 exponential of x.</summary>
    public static fix2 exp2(fix2 x) { return new fix2(exp2(x.x), exp2(x.y)); }

    /// <summary>Returns the componentwise base-2 exponential of x.</summary>
    public static fix3 exp2(fix3 x) { return new fix3(exp2(x.x), exp2(x.y), exp2(x.z)); }

    /// <summary>Returns the componentwise base-2 exponential of x.</summary>
    public static fix4 exp2(fix4 x) { return new fix4(exp2(x.x), exp2(x.y), exp2(x.z), exp2(x.w)); }


    /// <summary>Returns the base-10 exponential of x.</summary>
    public static fix exp10(fix x) { return global::fix.Pow(fix(10), x); }

    /// <summary>Returns the componentwise base-10 exponential of x.</summary>
    public static fix2 exp10(fix2 x) { return new fix2(exp10(x.x), exp10(x.y)); }

    /// <summary>Returns the componentwise base-10 exponential of x.</summary>
    public static fix3 exp10(fix3 x) { return new fix3(exp10(x.x), exp10(x.y), exp10(x.z)); }

    /// <summary>Returns the componentwise base-10 exponential of x.</summary>
    public static fix4 exp10(fix4 x) { return new fix4(exp10(x.x), exp10(x.y), exp10(x.z), exp10(x.w)); }


    /// <summary>Returns the fixing point remainder of x/y.</summary>
    public static fix fmod(fix x, fix y) { return x % y; }

    /// <summary>Returns the componentwise fixing point remainder of x/y.</summary>
    public static fix2 fmod(fix2 x, fix2 y) { return new fix2(x.x % y.x, x.y % y.y); }

    /// <summary>Returns the componentwise fixing point remainder of x/y.</summary>
    public static fix3 fmod(fix3 x, fix3 y) { return new fix3(x.x % y.x, x.y % y.y, x.z % y.z); }

    /// <summary>Returns the componentwise fixing point remainder of x/y.</summary>
    public static fix4 fmod(fix4 x, fix4 y) { return new fix4(x.x % y.x, x.y % y.y, x.z % y.z, x.w % y.w); }

    /// <summary>Returns the square root of a fix value.</summary>
    public static fix sqrt(fix x) { return global::fix.Sqrt(x); }

    /// <summary>Returns the componentwise square root of a fix2 vector.</summary>
    public static fix2 sqrt(fix2 x) { return new fix2(sqrt(x.x), sqrt(x.y)); }

    /// <summary>Returns the componentwise square root of a fix3 vector.</summary>
    public static fix3 sqrt(fix3 x) { return new fix3(sqrt(x.x), sqrt(x.y), sqrt(x.z)); }

    /// <summary>Returns the componentwise square root of a fix4 vector.</summary>
    public static fix4 sqrt(fix4 x) { return new fix4(sqrt(x.x), sqrt(x.y), sqrt(x.z), sqrt(x.w)); }


    /// <summary>Returns the reciprocal square root of a fix value.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix rsqrt(fix x) { return fix(1) / sqrt(x); }

    /// <summary>Returns the componentwise reciprocal square root of a fix2 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 rsqrt(fix2 x) { return fix(1) / sqrt(x); }

    /// <summary>Returns the componentwise reciprocal square root of a fix3 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 rsqrt(fix3 x) { return fix(1) / sqrt(x); }

    /// <summary>Returns the componentwise reciprocal square root of a fix4 vector</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 rsqrt(fix4 x) { return fix(1) / sqrt(x); }


    /// <summary>Returns a normalized version of the fix2 vector x by scaling it by 1 / length(x).</summary>
    public static fix2 normalize(fix2 x) { return rsqrt(dot(x, x)) * x; }

    /// <summary>Returns a normalized version of the fix3 vector x by scaling it by 1 / length(x).</summary>
    public static fix3 normalize(fix3 x) { return rsqrt(dot(x, x)) * x; }

    /// <summary>Returns a normalized version of the fix4 vector x by scaling it by 1 / length(x).</summary>
    public static fix4 normalize(fix4 x) { return rsqrt(dot(x, x)) * x; }

    /// <summary>
    /// Returns a safe normalized version of the fix2 vector x by scaling it by 1 / length(x).
    /// Returns the given default value when 1 / length(x) does not produce a finite number.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public fix2 normalizesafe(fix2 x, fix2 defaultvalue = new fix2())
    {
        fix len = dot(x, x);
        return len > FLT_MIN_NORMAL ? x * rsqrt(len) : defaultvalue;
    }

    /// <summary>
    /// Returns a safe normalized version of the float3 vector x by scaling it by 1 / length(x).
    /// Returns the given default value when 1 / length(x) does not produce a finite number.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public fix3 normalizesafe(fix3 x, fix3 defaultvalue = new fix3())
    {
        fix len = dot(x, x);
        return len > FLT_MIN_NORMAL ? x * rsqrt(len) : defaultvalue;
    }

    /// <summary>
    /// Returns a safe normalized version of the float4 vector x by scaling it by 1 / length(x).
    /// Returns the given default value when 1 / length(x) does not produce a finite number.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static public fix4 normalizesafe(fix4 x, fix4 defaultvalue = new fix4())
    {
        fix len = dot(x, x);
        return len > FLT_MIN_NORMAL ? x * rsqrt(len) : defaultvalue;
    }


    /// <summary>Returns the length of a fix value. Equivalent to the absolute value.</summary>
    public static fix length(fix x) { return abs(x); }

    /// <summary>Returns the length of a fix2 vector.</summary>
    public static fix length(fix2 x) { return sqrt(dot(x, x)); }

    /// <summary>Returns the length of a fix3 vector.</summary>
    public static fix length(fix3 x) { return sqrt(dot(x, x)); }

    /// <summary>Returns the length of a fix4 vector.</summary>
    public static fix length(fix4 x) { return sqrt(dot(x, x)); }


    /// <summary>Returns the squared length of a fix value. Equivalent to squaring the value.</summary>
    public static fix lengthsq(fix x) { return x * x; }

    /// <summary>Returns the squared length of a fix2 vector.</summary>
    public static fix lengthsq(fix2 x) { return dot(x, x); }

    /// <summary>Returns the squared length of a fix3 vector.</summary>
    public static fix lengthsq(fix3 x) { return dot(x, x); }

    /// <summary>Returns the squared length of a fix4 vector.</summary>
    public static fix lengthsq(fix4 x) { return dot(x, x); }


    /// <summary>Returns the distance between two fix values.</summary>
    public static fix distance(fix x, fix y) { return abs(y - x); }

    /// <summary>Returns the distance between two fix2 vectors.</summary>
    public static fix distance(fix2 x, fix2 y) { return length(y - x); }

    /// <summary>Returns the distance between two fix3 vectors.</summary>
    public static fix distance(fix3 x, fix3 y) { return length(y - x); }

    /// <summary>Returns the distance between two fix4 vectors.</summary>
    public static fix distance(fix4 x, fix4 y) { return length(y - x); }


    /// <summary>Returns the distance between two fix values.</summary>
    public static fix distancesq(fix x, fix y) { return (y - x) * (y - x); }

    /// <summary>Returns the distance between two fix2 vectors.</summary>
    public static fix distancesq(fix2 x, fix2 y) { return lengthsq(y - x); }

    /// <summary>Returns the distance between two fix3 vectors.</summary>
    public static fix distancesq(fix3 x, fix3 y) { return lengthsq(y - x); }

    /// <summary>Returns the distance between two fix4 vectors.</summary>
    public static fix distancesq(fix4 x, fix4 y) { return lengthsq(y - x); }


    /// <summary>Returns the cross product of two fix3 vectors.</summary>
    public static fix3 cross(fix3 x, fix3 y) { return (x * y.yzx - x.yzx * y).yzx; }

    /// <summary>Returns the cross product of two double3 vectors.</summary>
    public static double3 cross(double3 x, double3 y) { return (x * y.yzx - x.yzx * y).yzx; }


    /// <summary>Returns a smooth Hermite interpolation between fix(0) and fix(1) when x is in [a, b].</summary>
    public static fix smoothstep(fix a, fix b, fix x)
    {
        var t = saturate((x - a) / (b - a));
        return t * t * (fix(3) - (fix(2) * t));
    }

    /// <summary>Returns a componentwise smooth Hermite interpolation between fix(0) and fix(1) when x is in [a, b].</summary>
    public static fix2 smoothstep(fix2 a, fix2 b, fix2 x)
    {
        var t = saturate((x - a) / (b - a));
        return t * t * (fix2(3) - (fix(2) * t));
    }

    /// <summary>Returns a componentwise smooth Hermite interpolation between fix(0) and fix(1) when x is in [a, b].</summary>
    public static fix3 smoothstep(fix3 a, fix3 b, fix3 x)
    {
        var t = saturate((x - a) / (b - a));
        return t * t * (fix3(3) - (fix(2) * t));
    }

    /// <summary>Returns a componentwise smooth Hermite interpolation between fix(0) and fix(1) when x is in [a, b].</summary>
    public static fix4 smoothstep(fix4 a, fix4 b, fix4 x)
    {
        var t = saturate((x - a) / (b - a));
        return t * t * (fix4(3) - (fix(2) * t));
    }

    /// <summary>Returns true if any component of the input fix2 vector is non-zero, false otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool any(fix2 x) { return x.x != fix(0) || x.y != fix(0); }

    /// <summary>Returns true if any component of the input fix3 vector is non-zero, false otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool any(fix3 x) { return x.x != fix(0) || x.y != fix(0) || x.z != fix(0); }

    /// <summary>Returns true if any component of the input fix4 vector is non-zero, false otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool any(fix4 x) { return x.x != fix(0) || x.y != fix(0) || x.z != fix(0) || x.w != fix(0); }

    /// <summary>Returns true if all components of the input fix2 vector are non-zero, false otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool all(fix2 x) { return x.x != fix(0) && x.y != fix(0); }

    /// <summary>Returns true if all components of the input fix3 vector are non-zero, false otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool all(fix3 x) { return x.x != fix(0) && x.y != fix(0) && x.z != fix(0); }

    /// <summary>Returns true if all components of the input fix4 vector are non-zero, false otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool all(fix4 x) { return x.x != fix(0) && x.y != fix(0) && x.z != fix(0) && x.w != fix(0); }


    /// <summary>Returns b if c is true, a otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix select(fix a, fix b, bool c) { return c ? b : a; }

    /// <summary>Returns b if c is true, a otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 select(fix2 a, fix2 b, bool c) { return c ? b : a; }

    /// <summary>Returns b if c is true, a otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 select(fix3 a, fix3 b, bool c) { return c ? b : a; }

    /// <summary>Returns b if c is true, a otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 select(fix4 a, fix4 b, bool c) { return c ? b : a; }


    /// <summary>
    /// Returns a componentwise selection between two fix2 vectors a and b based on a bool2 selection mask c.
    /// Per component, the component from b is selected when c is true, otherwise the component from a is selected.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 select(fix2 a, fix2 b, bool2 c) { return new fix2(c.x ? b.x : a.x, c.y ? b.y : a.y); }

    /// <summary>
    /// Returns a componentwise selection between two fix3 vectors a and b based on a bool3 selection mask c.
    /// Per component, the component from b is selected when c is true, otherwise the component from a is selected.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 select(fix3 a, fix3 b, bool3 c) { return new fix3(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z); }

    /// <summary>
    /// Returns a componentwise selection between two fix4 vectors a and b based on a bool4 selection mask c.
    /// Per component, the component from b is selected when c is true, otherwise the component from a is selected.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 select(fix4 a, fix4 b, bool4 c) { return new fix4(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z, c.w ? b.w : a.w); }

    /// <summary>Computes a step function. Returns fix(1) when x >= y, fix(0) otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix step(fix y, fix x) { return select(fix(0), fix(1), x >= y); }

    /// <summary>Returns the result of a componentwise step function where each component is fix(1) when x >= y and fix(0) otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 step(fix2 y, fix2 x) { return select(fix2(0), fix2(1), x >= y); }

    /// <summary>Returns the result of a componentwise step function where each component is fix(1) when x >= y and fix(0) otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 step(fix3 y, fix3 x) { return select(fix3(0), fix3(1), x >= y); }

    /// <summary>Returns the result of a componentwise step function where each component is fix(1) when x >= y and fix(0) otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 step(fix4 y, fix4 x) { return select(fix4(0), fix4(1), x >= y); }

    /// <summary>Given an incident vector i and a normal vector n, returns the reflection vector r = i - 2.0f * dot(i, n) * n.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 reflect(fix2 i, fix2 n) { return i - fix(2) * n * dot(i, n); }

    /// <summary>Given an incident vector i and a normal vector n, returns the reflection vector r = i - 2.0f * dot(i, n) * n.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 reflect(fix3 i, fix3 n) { return i - fix(2) * n * dot(i, n); }

    /// <summary>Given an incident vector i and a normal vector n, returns the reflection vector r = i - 2.0f * dot(i, n) * n.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 reflect(fix4 i, fix4 n) { return i - fix(2) * n * dot(i, n); }


    /// <summary>Returns the refraction vector given the incident vector i, the normal vector n and the refraction index eta.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 refract(fix2 i, fix2 n, fix eta)
    {
        fix ni = dot(n, i);
        fix k = fix(1) - eta * eta * (fix(1) - ni * ni);
        return select(fix2(0), eta * i - (eta * ni + sqrt(k)) * n, k >= 0);
    }

    /// <summary>Returns the refraction vector given the incident vector i, the normal vector n and the refraction index eta.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 refract(fix3 i, fix3 n, fix eta)
    {
        fix ni = dot(n, i);
        fix k = fix(1) - eta * eta * (fix(1) - ni * ni);
        return select(fix3(0), eta * i - (eta * ni + sqrt(k)) * n, k >= 0);
    }

    /// <summary>Returns the refraction vector given the incident vector i, the normal vector n and the refraction index eta.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 refract(fix4 i, fix4 n, fix eta)
    {
        fix ni = dot(n, i);
        fix k = fix(1) - eta * eta * (fix(1) - ni * ni);
        return select(fix4(0), eta * i - (eta * ni + sqrt(k)) * n, k >= 0);
    }


    /// <summary>Conditionally flips a vector n to face in the direction of i. Returns n if dot(i, ng) < 0, -n otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 faceforward(fix2 n, fix2 i, fix2 ng) { return select(n, -n, dot(ng, i) >= fix(0)); }

    /// <summary>Conditionally flips a vector n to face in the direction of i. Returns n if dot(i, ng) < 0, -n otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 faceforward(fix3 n, fix3 i, fix3 ng) { return select(n, -n, dot(ng, i) >= fix(0)); }

    /// <summary>Conditionally flips a vector n to face in the direction of i. Returns n if dot(i, ng) < 0, -n otherwise.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 faceforward(fix4 n, fix4 i, fix4 ng) { return select(n, -n, dot(ng, i) >= fix(0)); }


    /// <summary>Returns the sine and cosine of the input fix value x through the out parameters s and c.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void sincos(fix x, out fix s, out fix c) { s = sin(x); c = cos(x); }

    /// <summary>Returns the componentwise sine and cosine of the input fix2 vector x through the out parameters s and c.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void sincos(fix2 x, out fix2 s, out fix2 c) { s = sin(x); c = cos(x); }

    /// <summary>Returns the componentwise sine and cosine of the input fix3 vector x through the out parameters s and c.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void sincos(fix3 x, out fix3 s, out fix3 c) { s = sin(x); c = cos(x); }

    /// <summary>Returns the componentwise sine and cosine of the input fix4 vector x through the out parameters s and c.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void sincos(fix4 x, out fix4 s, out fix4 c) { s = sin(x); c = cos(x); }

    /// <summary>Returns the result of converting a fix value from degrees to radians.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix radians(fix x) { return x * fix(0.0174532925f); }

    /// <summary>Returns the result of a componentwise conversion of a fix2 vector from degrees to radians.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 radians(fix2 x) { return x * fix(0.0174532925f); }

    /// <summary>Returns the result of a componentwise conversion of a fix3 vector from degrees to radians.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 radians(fix3 x) { return x * fix(0.0174532925f); }

    /// <summary>Returns the result of a componentwise conversion of a fix4 vector from degrees to radians.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 radians(fix4 x) { return x * fix(0.0174532925f); }


    /// <summary>Returns the result of converting a double value from radians to degrees.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix degrees(fix x) { return x * fix(57.295779513f); }

    /// <summary>Returns the result of a componentwise conversion of a double2 vector from radians to degrees.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 degrees(fix2 x) { return x * fix(57.295779513f); }

    /// <summary>Returns the result of a componentwise conversion of a double3 vector from radians to degrees.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 degrees(fix3 x) { return x * fix(57.295779513f); }

    /// <summary>Returns the result of a componentwise conversion of a double4 vector from radians to degrees.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 degrees(fix4 x) { return x * fix(57.295779513f); }


    /// <summary>Returns the minimum component of a fix2 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix cmin(fix2 x) { return min(x.x, x.y); }

    /// <summary>Returns the minimum component of a fix3 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix cmin(fix3 x) { return min(min(x.x, x.y), x.z); }

    /// <summary>Returns the maximum component of a fix3 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix cmin(fix4 x) { return min(min(x.x, x.y), min(x.z, x.w)); }

    /// <summary>Returns the maximum component of a fix2 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix cmax(fix2 x) { return max(x.x, x.y); }

    /// <summary>Returns the maximum component of a fix3 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix cmax(fix3 x) { return max(max(x.x, x.y), x.z); }

    /// <summary>Returns the maximum component of a fix4 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix cmax(fix4 x) { return max(max(x.x, x.y), max(x.z, x.w)); }


    /// <summary>Returns the horizontal sum of components of a fix2 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix csum(fix2 x) { return x.x + x.y; }

    /// <summary>Returns the horizontal sum of components of a fix3 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix csum(fix3 x) { return x.x + x.y + x.z; }

    /// <summary>Returns the horizontal sum of components of a fix4 vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix csum(fix4 x) { return (x.x + x.y) + (x.z + x.w); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 up() { return new fix3(fix(0), fix(1), fix(0)); }  // for compatibility

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2x2 inverse(fix2x2 a)
    {
        fix2x2.Invert(ref a, out a);
        return a;
    }

    /// <summary>Returns the fix value result of a matrix multiplication between a fix value and a fix value.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix mul(fix a, fix b)
    {
        return a * b;
    }

    /// <summary>Returns the fix value result of a matrix multiplication between a fix2 row vector and a fix2 column vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix mul(fix2 a, fix2 b)
    {
        return a.x * b.x + a.y * b.y;
    }

    /// <summary>Returns the fix2 row vector result of a matrix multiplication between a fix2 row vector and a fix2x2 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 mul(fix2 a, fix2x2 b)
    {
        return new fix2(
            a.x * b.M11 + a.y * b.M21,
            a.x * b.M12 + a.y * b.M22);
    }

    /// <summary>Returns the fix3 row vector result of a matrix multiplication between a fix2 row vector and a fix2x3 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 mul(fix2 a, fix2x3 b)
    {
        return new fix3(
            a.x * b.M11 + a.y * b.M21,
            a.x * b.M12 + a.y * b.M22,
            a.x * b.M13 + a.y * b.M23);
    }

    /// <summary>Returns the fix value result of a matrix multiplication between a fix3 row vector and a fix3 column vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix mul(fix3 a, fix3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

    /// <summary>Returns the fix2 row vector result of a matrix multiplication between a fix3 row vector and a fix3x2 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 mul(fix3 a, fix3x2 b)
    {
        return new fix2(
            a.x * b.M11 + a.y * b.M21 + a.z * b.M31,
            a.x * b.M12 + a.y * b.M22 + a.z * b.M32);
    }

    /// <summary>Returns the fix3 row vector result of a matrix multiplication between a fix3 row vector and a fix3x3 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 mul(fix3 a, fix3x3 b)
    {
        return new fix3(
            a.x * b.M11 + a.y * b.M21 + a.z * b.M31,
            a.x * b.M12 + a.y * b.M22 + a.z * b.M32,
            a.x * b.M13 + a.y * b.M23 + a.z * b.M33);
    }

    /// <summary>Returns the fix value result of a matrix multiplication between a fix4 row vector and a fix4 column vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix mul(fix4 a, fix4 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
    }

    /// <summary>Returns the fix4 row vector result of a matrix multiplication between a fix4 row vector and a fix4x4 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 mul(fix4 a, fix4x4 b)
    {
        return new fix4(
            a.x * b.M11 + a.y * b.M21 + a.z * b.M31 + a.w * b.M41,
            a.x * b.M12 + a.y * b.M22 + a.z * b.M32 + a.w * b.M42,
            a.x * b.M13 + a.y * b.M23 + a.z * b.M33 + a.w * b.M43,
            a.x * b.M14 + a.y * b.M24 + a.z * b.M34 + a.w * b.M44);
    }

    /// <summary>Returns the fix2 column vector result of a matrix multiplication between a fix2x2 matrix and a fix2 column vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 mul(fix2x2 a, fix2 b)
    {
        return new fix2(
            a.M11 * b.x + a.M12 * b.y,
            a.M21 * b.x + a.M22 * b.y);
    }

    /// <summary>Returns the fix2x2 matrix result of a matrix multiplication between a fix2x2 matrix and a fix2x2 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2x2 mul(fix2x2 a, fix2x2 b)
    {
        return new fix2x2(
            a.M11 * b.M11 + a.M12 * b.M21,
            a.M11 * b.M12 + a.M12 * b.M22,
            a.M21 * b.M11 + a.M22 * b.M21,
            a.M21 * b.M12 + a.M22 * b.M22
            );
    }

    /// <summary>Returns the fix2x3 matrix result of a matrix multiplication between a fix2x2 matrix and a fix2x3 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2x3 mul(fix2x2 a, fix2x3 b)
    {
        return new fix2x3(
            a.M11 * b.M11 + a.M12 * b.M21,
            a.M11 * b.M12 + a.M12 * b.M22,
            a.M11 * b.M13 + a.M12 * b.M23,

            a.M21 * b.M11 + a.M22 * b.M21,
            a.M21 * b.M12 + a.M22 * b.M22,
            a.M21 * b.M13 + a.M22 * b.M23
            );
    }

    /// <summary>Returns the fix2 column vector result of a matrix multiplication between a fix2x3 matrix and a fix3 column vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2 mul(fix2x3 a, fix3 b)
    {
        return new fix2(
            a.M11 * b.x + a.M12 * b.y + a.M13 * b.z,
            a.M21 * b.x + a.M22 * b.y + a.M23 * b.z);
    }

    /// <summary>Returns the fix2x2 matrix result of a matrix multiplication between a fix2x3 matrix and a fix3x2 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2x2 mul(fix2x3 a, fix3x2 b)
    {
        return new fix2x2(
            a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
            a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
            a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
            a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32
            );
    }

    /// <summary>Returns the fix2x3 matrix result of a matrix multiplication between a fix2x3 matrix and a fix3x3 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix2x3 mul(fix2x3 a, fix3x3 b)
    {
        return new fix2x3(
            a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
            a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
            a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,

            a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
            a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
            a.M21 * b.M13 + a.M12 * b.M23 + a.M23 * b.M33
            );
    }

    /// <summary>Returns the fix3 column vector result of a matrix multiplication between a fix3x2 matrix and a fix2 column vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 mul(fix3x2 a, fix2 b)
    {
        return new fix3(
            a.M11 * b.x + a.M12 * b.y,
            a.M21 * b.x + a.M22 * b.y,
            a.M31 * b.x + a.M32 * b.y);
    }

    /// <summary>Returns the fix3x2 matrix result of a matrix multiplication between a fix3x2 matrix and a fix2x2 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3x2 mul(fix3x2 a, fix2x2 b)
    {
        return new fix3x2(
            a.M11 * b.M11 + a.M12 * b.M21,
            a.M11 * b.M12 + a.M12 * b.M22,

            a.M21 * b.M11 + a.M22 * b.M21,
            a.M21 * b.M12 + a.M22 * b.M22,

            a.M31 * b.M11 + a.M32 * b.M21,
            a.M31 * b.M12 + a.M32 * b.M22
            );
    }

    /// <summary>Returns the fix3x3 matrix result of a matrix multiplication between a fix3x2 matrix and a fix2x3 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3x3 mul(fix3x2 a, fix2x3 b)
    {
        return new fix3x3(
            a.M11 * b.M11 + a.M12 * b.M21,
            a.M11 * b.M12 + a.M12 * b.M22,
            a.M11 * b.M13 + a.M12 * b.M23,

            a.M21 * b.M11 + a.M22 * b.M21,
            a.M21 * b.M12 + a.M22 * b.M22,
            a.M21 * b.M13 + a.M22 * b.M23,

            a.M31 * b.M11 + a.M32 * b.M21,
            a.M31 * b.M12 + a.M32 * b.M22,
            a.M31 * b.M13 + a.M32 * b.M23
            );
    }

    /// <summary>Returns the fix3 column vector result of a matrix multiplication between a fix3x3 matrix and a fix3 column vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3 mul(fix3x3 a, fix3 b)
    {
        return new fix3(
            a.M11 * b.x + a.M12 * b.y + a.M13 * b.z,
            a.M21 * b.x + a.M22 * b.y + a.M23 * b.z,
            a.M31 * b.x + a.M32 * b.y + a.M33 * b.z);
    }

    /// <summary>Returns the fix3x2 matrix result of a matrix multiplication between a fix3x3 matrix and a fix3x2 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3x2 mul(fix3x3 a, fix3x2 b)
    {
        return new fix3x2(
            a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
            a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,

            a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
            a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,

            a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
            a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32);
    }

    /// <summary>Returns the fix3x3 matrix result of a matrix multiplication between a fix3x3 matrix and a fix3x3 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix3x3 mul(fix3x3 a, fix3x3 b)
    {
        return new fix3x3(
            a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
            a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
            a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,

            a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
            a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
            a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33,

            a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
            a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32,
            a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33
            );
    }

    /// <summary>Returns the fix4 column vector result of a matrix multiplication between a fix4x4 matrix and a fix4 column vector.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4 mul(fix4x4 a, fix4 b)
    {
        return new fix4(
            a.M11 * b.x + a.M12 * b.y + a.M13 * b.z + a.M14 * b.w,
            a.M21 * b.x + a.M22 * b.y + a.M23 * b.z + a.M24 * b.w,
            a.M31 * b.x + a.M32 * b.y + a.M33 * b.z + a.M34 * b.w,
            a.M41 * b.x + a.M42 * b.y + a.M43 * b.z + a.M44 * b.w);
    }

    /// <summary>Returns the fix4x4 matrix result of a matrix multiplication between a fix4x4 matrix and a fix4x4 matrix.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static fix4x4 mul(fix4x4 a, fix4x4 b)
    {
        return new fix4x4(
            a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
            a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,
            a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43,
            a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44,

            a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
            a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,
            a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43,
            a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44,

            a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
            a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42,
            a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43,
            a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44,

            a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41,
            a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42,
            a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43,
            a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44
            );
    }
}
