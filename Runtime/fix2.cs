using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// Provides XNA-like 2D vector math.
/// </summary>
[Serializable]
[JsonObject(IsReference =false)]
public struct fix2 : IEquatable<fix2>
{
    /// <summary>
    /// X component of the vector.
    /// </summary>
    public fix x;

    /// <summary>
    /// Y component of the vector.
    /// </summary>
    public fix y;

    /// <summary>
    /// Constructs a new two dimensional vector.
    /// </summary>
    /// <param name="x">X component of the vector.</param>
    /// <param name="y">Y component of the vector.</param>
    public fix2(in fix x, in fix y)
    {
        this.x = x;
        this.y = y;
    }
    /// <summary>
    /// Constructs a new two dimensional vector.
    /// </summary>
    public fix2(in fix v)
    {
        this.x = v;
        this.y = v;
    }

    /// <summary>
    /// Computes the squared length of the vector.
    /// </summary>
    /// <returns>Squared length of the vector.</returns>
    public fix lengthSquared => x * x + y * y;

    /// <summary>
    /// Computes the length of the vector.
    /// </summary>
    /// <returns>Length of the vector.</returns>
    public fix length => fix.Sqrt(x * x + y * y);

    /// <summary>
    /// Gets a string representation of the vector.
    /// </summary>
    /// <returns>String representing the vector.</returns>
    public override string ToString()
    {
        return "{" + x + ", " + y + "}";
    }

    /// <summary>
    /// Adds two vectors together.
    /// </summary>
    /// <param name="a">First vector to add.</param>
    /// <param name="b">Second vector to add.</param>
    /// <param name="sum">Sum of the two vectors.</param>
    public static void Add(in fix2 a, in fix2 b, out fix2 sum)
    {
        sum.x = a.x + b.x;
        sum.y = a.y + b.y;
    }

    /// <summary>
    /// Subtracts two vectors.
    /// </summary>
    /// <param name="a">Vector to subtract from.</param>
    /// <param name="b">Vector to subtract from the first vector.</param>
    /// <param name="difference">Result of the subtraction.</param>
    public static void Subtract(in fix2 a, in fix2 b, out fix2 difference)
    {
        difference.x = a.x - b.x;
        difference.y = a.y - b.y;
    }

    /// <summary>
    /// Scales a vector.
    /// </summary>
    /// <param name="v">Vector to scale.</param>
    /// <param name="scale">Amount to scale.</param>
    /// <param name="result">Scaled vector.</param>
    public static void Multiply(in fix2 v, fix scale, out fix2 result)
    {
        result.x = v.x * scale;
        result.y = v.y * scale;
    }

    /// <summary>
    /// Multiplies two vectors on a per-component basis.
    /// </summary>
    /// <param name="a">First vector to multiply.</param>
    /// <param name="b">Second vector to multiply.</param>
    /// <param name="result">Result of the componentwise multiplication.</param>
    public static void Multiply(in fix2 a, in fix2 b, out fix2 result)
    {
        result.x = a.x * b.x;
        result.y = a.y * b.y;
    }

    /// <summary>
    /// Divides a vector's components by some amount.
    /// </summary>
    /// <param name="v">Vector to divide.</param>
    /// <param name="divisor">Value to divide the vector's components.</param>
    /// <param name="result">Result of the division.</param>
    public static void Divide(in fix2 v, fix divisor, out fix2 result)
    {
        fix inverse = F64.C1 / divisor;
        result.x = v.x * inverse;
        result.y = v.y * inverse;
    }

    /// <summary>
    /// Computes the dot product of the two vectors.
    /// </summary>
    /// <param name="a">First vector of the dot product.</param>
    /// <param name="b">Second vector of the dot product.</param>
    /// <param name="dot">Dot product of the two vectors.</param>
    public static void Dot(in fix2 a, in fix2 b, out fix dot)
    {
        dot = a.x * b.x + a.y * b.y;
    }

    /// <summary>
    /// Computes the dot product of the two vectors.
    /// </summary>
    /// <param name="a">First vector of the dot product.</param>
    /// <param name="b">Second vector of the dot product.</param>
    /// <returns>Dot product of the two vectors.</returns>
    public static fix Dot(in fix2 a, in fix2 b)
    {
        return a.x * b.x + a.y * b.y;
    }

    /// <summary>
    /// Normalizes the vector.
    /// </summary>
    /// <param name="v">Vector to normalize.</param>
    /// <returns>Normalized copy of the vector.</returns>
    public static fix2 Normalize(in fix2 v)
    {
        fix2 toReturn;
        fix2.Normalize(in v, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Normalizes the vector.
    /// </summary>
    /// <param name="v">Vector to normalize.</param>
    /// <param name="result">Normalized vector.</param>
    public static void Normalize(in fix2 v, out fix2 result)
    {
        fix inverse = F64.C1 / fix.Sqrt(v.x * v.x + v.y * v.y);
        result.x = v.x * inverse;
        result.y = v.y * inverse;
    }

    /// <summary>
    /// Negates the vector.
    /// </summary>
    /// <param name="v">Vector to negate.</param>
    /// <param name="negated">Negated version of the vector.</param>
    public static void Negate(in fix2 v, out fix2 negated)
    {
        negated.x = -v.x;
        negated.y = -v.y;
    }

    /// <summary>
    /// Computes the absolute value of the input vector.
    /// </summary>
    /// <param name="v">Vector to take the absolute value of.</param>
    /// <param name="result">Vector with nonnegative elements.</param>
    public static void Abs(in fix2 v, out fix2 result)
    {
        if (v.x < F64.C0)
            result.x = -v.x;
        else
            result.x = v.x;
        if (v.y < F64.C0)
            result.y = -v.y;
        else
            result.y = v.y;
    }

    /// <summary>
    /// Computes the absolute value of the input vector.
    /// </summary>
    /// <param name="v">Vector to take the absolute value of.</param>
    /// <returns>Vector with nonnegative elements.</returns>
    public static fix2 Abs(in fix2 v)
    {
        fix2 result;
        Abs(in v, out result);
        return result;
    }

    /// <summary>
    /// Creates a vector from the lesser values in each vector.
    /// </summary>
    /// <param name="a">First input vector to compare values from.</param>
    /// <param name="b">Second input vector to compare values from.</param>
    /// <param name="min">Vector containing the lesser values of each vector.</param>
    public static void Min(in fix2 a, in fix2 b, out fix2 min)
    {
        min.x = a.x < b.x ? a.x : b.x;
        min.y = a.y < b.y ? a.y : b.y;
    }

    /// <summary>
    /// Creates a vector from the lesser values in each vector.
    /// </summary>
    /// <param name="a">First input vector to compare values from.</param>
    /// <param name="b">Second input vector to compare values from.</param>
    /// <returns>Vector containing the lesser values of each vector.</returns>
    public static fix2 Min(in fix2 a, in fix2 b)
    {
        fix2 result;
        Min(in a, in b, out result);
        return result;
    }

    /// <summary>
    /// Creates a vector from the greater values in each vector.
    /// </summary>
    /// <param name="a">First input vector to compare values from.</param>
    /// <param name="b">Second input vector to compare values from.</param>
    /// <param name="max">Vector containing the greater values of each vector.</param>
    public static void Max(in fix2 a, in fix2 b, out fix2 max)
    {
        max.x = a.x > b.x ? a.x : b.x;
        max.y = a.y > b.y ? a.y : b.y;
    }

    /// <summary>
    /// Creates a vector from the greater values in each vector.
    /// </summary>
    /// <param name="a">First input vector to compare values from.</param>
    /// <param name="b">Second input vector to compare values from.</param>
    /// <returns>Vector containing the greater values of each vector.</returns>
    public static fix2 Max(in fix2 a, in fix2 b)
    {
        fix2 result;
        Max(in a, in b, out result);
        return result;
    }

    /// <summary>
    /// Normalizes the vector.
    /// </summary>
    public void Normalize()
    {
        fix inverse = F64.C1 / fix.Sqrt(x * x + y * y);
        x *= inverse;
        y *= inverse;
    }

    /// <summary>
    /// Returns a normalized version of the vector.
    /// </summary>
    public fix2 normalized
    {
        get
        {
            fix inverse = F64.C1 / fix.Sqrt(x * x + y * y);
            return new fix2(x * inverse, y * inverse);
        }
    }

    /// <summary>
    /// Scales a vector.
    /// </summary>
    /// <param name="v">Vector to scale.</param>
    /// <param name="f">Amount to scale.</param>
    /// <returns>Scaled vector.</returns>
    public static fix2 operator *(in fix2 v, in fix f)
    {
        fix2 toReturn;
        toReturn.x = v.x * f;
        toReturn.y = v.y * f;
        return toReturn;
    }
    /// <summary>
    /// Scales a vector.
    /// </summary>
    /// <param name="v">Vector to scale.</param>
    /// <param name="f">Amount to scale.</param>
    /// <returns>Scaled vector.</returns>
    public static fix2 operator *(in fix f, in fix2 v)
    {
        fix2 toReturn;
        toReturn.x = v.x * f;
        toReturn.y = v.y * f;
        return toReturn;
    }

    /// <summary>
    /// Multiplies two vectors on a per-component basis.
    /// </summary>
    /// <param name="a">First vector to multiply.</param>
    /// <param name="b">Second vector to multiply.</param>
    /// <returns>Result of the componentwise multiplication.</returns>
    public static fix2 operator *(in fix2 a, in fix2 b)
    {
        fix2 result;
        Multiply(in a, in b, out result);
        return result;
    }

    /// <summary>
    /// Divides a vector.
    /// </summary>
    /// <param name="v">Vector to divide.</param>
    /// <param name="f">Amount to divide.</param>
    /// <returns>Divided vector.</returns>
    public static fix2 operator /(in fix2 v, fix f)
    {
        fix2 toReturn;
        f = F64.C1 / f;
        toReturn.x = v.x * f;
        toReturn.y = v.y * f;
        return toReturn;
    }

    /// <summary>
    /// Divides a vector.
    /// </summary>
    /// <param name="v">Vector 1 to divide.</param>
    /// <param name="f">Vector 2 to divide.</param>
    /// <returns>Divided vector.</returns>
    public static fix2 operator /(in fix2 v1, fix2 v2)
    {
        return new fix2(v1.x / v2.x, v1.y / v2.y);
    }

    public static fix2 operator /(in fix v, fix2 v2)
    {
        return new fix2(v / v2.x, v / v2.y);
    }

    /// <summary>
    /// Subtracts two vectors.
    /// </summary>
    /// <param name="a">Vector to be subtracted from.</param>
    /// <param name="b">Vector to subtract from the first vector.</param>
    /// <returns>Resulting difference.</returns>
    public static fix2 operator -(in fix2 a, in fix2 b)
    {
        fix2 v;
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        return v;
    }

    /// <summary>
    /// Adds two vectors.
    /// </summary>
    /// <param name="a">First vector to add.</param>
    /// <param name="b">Second vector to add.</param>
    /// <returns>Sum of the addition.</returns>
    public static fix2 operator +(in fix2 a, in fix2 b)
    {
        fix2 v;
        v.x = a.x + b.x;
        v.y = a.y + b.y;
        return v;
    }

    /// <summary>
    /// Negates the vector.
    /// </summary>
    /// <param name="v">Vector to negate.</param>
    /// <returns>Negated vector.</returns>
    public static fix2 operator -(in fix2 v)
    {
        return new fix2(-v.x, -v.y);
    }

    /// <summary>
    /// Tests two vectors for componentwise equivalence.
    /// </summary>
    /// <param name="a">First vector to test for equivalence.</param>
    /// <param name="b">Second vector to test for equivalence.</param>
    /// <returns>Whether the vectors were equivalent.</returns>
    public static bool operator ==(in fix2 a, in fix2 b)
    {
        return a.x == b.x && a.y == b.y;
    }
    /// <summary>
    /// Tests two vectors for componentwise inequivalence.
    /// </summary>
    /// <param name="a">First vector to test for inequivalence.</param>
    /// <param name="b">Second vector to test for inequivalence.</param>
    /// <returns>Whether the vectors were inequivalent.</returns>
    public static bool operator !=(in fix2 a, in fix2 b)
    {
        return a.x != b.x || a.y != b.y;
    }
    
    public static bool2 operator >(in fix2 a, in fix2 b)
    {
        return new bool2(a.x > b.x, a.y > b.y);
    }

    public static bool2 operator <(in fix2 a, in fix2 b)
    {
        return new bool2(a.x < b.x, a.y < b.y);
    }

    public static bool2 operator >=(in fix2 a, in fix2 b)
    {
        return new bool2(a.x >= b.x, a.y >= b.y);
    }

    public static bool2 operator <=(in fix2 a, in fix2 b)
    {
        return new bool2(a.x <= b.x, a.y <= b.y);
    }

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <returns>
    /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
    /// </returns>
    /// <param name="other">An object to compare with this object.</param>
    public bool Equals(fix2 other)
    {
        return x == other.x && y == other.y;
    }

    /// <summary>
    /// Indicates whether this instance and a specified object are equal.
    /// </summary>
    /// <returns>
    /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
    /// </returns>
    /// <param name="obj">Another object to compare to. </param><filterpriority>2</filterpriority>
    public override bool Equals(object obj)
    {
        if (obj is fix2)
        {
            return Equals((fix2)obj);
        }
        return false;
    }

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>
    /// A 32-bit signed integer that is the hash code for this instance.
    /// </returns>
    /// <filterpriority>2</filterpriority>
    public override int GetHashCode()
    {
        return x.GetHashCode() + y.GetHashCode();
    }

    public static readonly fix2 Zero = new fix2(0, 0);
    public static readonly fix2 Right = new fix2(1, 0);
    public static readonly fix2 Left = new fix2(-1, 0);
    public static readonly fix2 Up = new fix2(0, 1);
    public static readonly fix2 Down = new fix2(0, -1);

    public static explicit operator int2(in fix2 v) => new int2((int)v.x, (int)v.y);
    public static explicit operator fix2(in int2 v) => new fix2(v.x, v.y);
    public static explicit operator fix2(in Vector2 v) => new fix2((fix)v.x, (fix)v.y);
    public static explicit operator fix2(in float2 v) => new fix2((fix)v.x, (fix)v.y);
    public static explicit operator Vector2(in fix2 v) => new Vector2((float)v.x, (float)v.y);
    public static explicit operator float2(in fix2 v) => new float2((float)v.x, (float)v.y);
    public static implicit operator fix3(in fix2 v) => new fix3(v.x, v.y, 0);
}
