using Newtonsoft.Json;
using System;
using System.ComponentModel;
using Unity.Mathematics;

/// <summary>
/// Provides XNA-like 3D vector math.
/// </summary>
[Serializable]
[JsonObject(IsReference = false)]
public struct fix3 : IEquatable<fix3>
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
    /// Z component of the vector.
    /// </summary>
    public fix z;

    /// <summary>
    /// Constructs a new 3d vector.
    /// </summary>
    /// <param name="x">X component of the vector.</param>
    /// <param name="y">Y component of the vector.</param>
    /// <param name="z">Z component of the vector.</param>
    public fix3(in fix x, in fix y, in fix z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    /// <summary>
    /// Constructs a new 3d vector.
    /// </summary>
    /// <param name="xy">X and Y components of the vector.</param>
    /// <param name="z">Z component of the vector.</param>
    public fix3(in fix2 xy, in fix z)
    {
        this.x = xy.x;
        this.y = xy.y;
        this.z = z;
    }

    /// <summary>
    /// Constructs a new 3d vector.
    /// </summary>
    /// <param name="x">X component of the vector.</param>
    /// <param name="yz">Y and Z components of the vector.</param>
    public fix3(in fix x, in fix2 yz)
    {
        this.x = x;
        this.y = yz.x;
        this.z = yz.y;
    }

    /// <summary>
    /// Constructs a new three dimensional vector.
    /// </summary>
    public fix3(in fix v)
    {
        this.x = v;
        this.y = v;
        this.z = v;
    }

    /// <summary>
    /// Computes the squared length of the vector.
    /// </summary>
    /// <returns>Squared length of the vector.</returns>
    public fix lengthSquared => x * x + y * y + z * z;

    /// <summary>
    /// Computes the length of the vector.
    /// </summary>
    /// <returns>Length of the vector.</returns>
    public fix length => fix.Sqrt(x * x + y * y + z * z);

    /// <summary>
    /// Normalizes the vector.
    /// </summary>
    public void Normalize()
    {
        fix inverse = F64.C1 / fix.Sqrt(x * x + y * y + z * z);
        x *= inverse;
        y *= inverse;
        z *= inverse;
    }

    /// <summary>
    /// Returns a normalized version of the vector.
    /// </summary>
    public fix3 normalized
    {
        get
        {
            fix inverse = F64.C1 / fix.Sqrt(x * x + y * y + z * z);
            return new fix3(x * inverse, y * inverse, z * inverse);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public fix3 yzx
    {
        get
        {
            return new fix3(y, z, x);
        }
        set
        {
            y = value.x;
            z = value.y;
            x = value.z;
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public fix2 xy
    {
        get
        {
            return new fix2(x, y);
        }
        set
        {
            x = value.x;
            y = value.y;
        }
    }

    /// <summary>
    /// Gets a string representation of the vector.
    /// </summary>
    /// <returns>String representing the vector.</returns>
    public override string ToString()
    {
        return "{" + x + ", " + y + ", " + z + "}";
    }

    /// <summary>
    /// Computes the dot product of two vectors.
    /// </summary>
    /// <param name="a">First vector in the product.</param>
    /// <param name="b">Second vector in the product.</param>
    /// <returns>Resulting dot product.</returns>
    public static fix Dot(in fix3 a, in fix3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

    /// <summary>
    /// Computes the dot product of two vectors.
    /// </summary>
    /// <param name="a">First vector in the product.</param>
    /// <param name="b">Second vector in the product.</param>
    /// <param name="product">Resulting dot product.</param>
    public static void Dot(in fix3 a, in fix3 b, out fix product)
    {
        product = a.x * b.x + a.y * b.y + a.z * b.z;
    }
    /// <summary>
    /// Adds two vectors together.
    /// </summary>
    /// <param name="a">First vector to add.</param>
    /// <param name="b">Second vector to add.</param>
    /// <param name="sum">Sum of the two vectors.</param>
    public static void Add(in fix3 a, in fix3 b, out fix3 sum)
    {
        sum.x = a.x + b.x;
        sum.y = a.y + b.y;
        sum.z = a.z + b.z;
    }
    /// <summary>
    /// Subtracts two vectors.
    /// </summary>
    /// <param name="a">Vector to subtract from.</param>
    /// <param name="b">Vector to subtract from the first vector.</param>
    /// <param name="difference">Result of the subtraction.</param>
    public static void Subtract(in fix3 a, in fix3 b, out fix3 difference)
    {
        difference.x = a.x - b.x;
        difference.y = a.y - b.y;
        difference.z = a.z - b.z;
    }
    /// <summary>
    /// Scales a vector.
    /// </summary>
    /// <param name="v">Vector to scale.</param>
    /// <param name="scale">Amount to scale.</param>
    /// <param name="result">Scaled vector.</param>
    public static void Multiply(in fix3 v, in fix scale, out fix3 result)
    {
        result.x = v.x * scale;
        result.y = v.y * scale;
        result.z = v.z * scale;
    }

    /// <summary>
    /// Multiplies two vectors on a per-component basis.
    /// </summary>
    /// <param name="a">First vector to multiply.</param>
    /// <param name="b">Second vector to multiply.</param>
    /// <param name="result">Result of the componentwise multiplication.</param>
    public static void Multiply(in fix3 a, in fix3 b, out fix3 result)
    {
        result.x = a.x * b.x;
        result.y = a.y * b.y;
        result.z = a.z * b.z;
    }

    /// <summary>
    /// Divides a vector's components by some amount.
    /// </summary>
    /// <param name="v">Vector to divide.</param>
    /// <param name="divisor">Value to divide the vector's components.</param>
    /// <param name="result">Result of the division.</param>
    public static void Divide(in fix3 v, in fix divisor, out fix3 result)
    {
        fix inverse = F64.C1 / divisor;
        result.x = v.x * inverse;
        result.y = v.y * inverse;
        result.z = v.z * inverse;
    }
    /// <summary>
    /// Scales a vector.
    /// </summary>
    /// <param name="v">Vector to scale.</param>
    /// <param name="f">Amount to scale.</param>
    /// <returns>Scaled vector.</returns>
    public static fix3 operator *(in fix3 v, in fix f)
    {
        fix3 toReturn;
        toReturn.x = v.x * f;
        toReturn.y = v.y * f;
        toReturn.z = v.z * f;
        return toReturn;
    }

    /// <summary>
    /// Scales a vector.
    /// </summary>
    /// <param name="v">Vector to scale.</param>
    /// <param name="f">Amount to scale.</param>
    /// <returns>Scaled vector.</returns>
    public static fix3 operator *(in fix f, in fix3 v)
    {
        fix3 toReturn;
        toReturn.x = v.x * f;
        toReturn.y = v.y * f;
        toReturn.z = v.z * f;
        return toReturn;
    }

    /// <summary>
    /// Multiplies two vectors on a per-component basis.
    /// </summary>
    /// <param name="a">First vector to multiply.</param>
    /// <param name="b">Second vector to multiply.</param>
    /// <returns>Result of the componentwise multiplication.</returns>
    public static fix3 operator *(in fix3 a, in fix3 b)
    {
        fix3 result;
        Multiply(in a, in b, out result);
        return result;
    }

    /// <summary>
    /// Divides a vector's components by some amount.
    /// </summary>
    /// <param name="v">Vector to divide.</param>
    /// <param name="f">Value to divide the vector's components.</param>
    /// <returns>Result of the division.</returns>
    public static fix3 operator /(in fix3 v, fix f)
    {
        fix3 toReturn;
        f = F64.C1 / f;
        toReturn.x = v.x * f;
        toReturn.y = v.y * f;
        toReturn.z = v.z * f;
        return toReturn;
    }


    /// <summary>
    /// Divides a vector.
    /// </summary>
    public static fix3 operator /(in fix3 v1, fix3 v2)
    {
        return new fix3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
    }

    public static fix3 operator /(in fix v, fix3 v2)
    {
        return new fix3(v / v2.x, v / v2.y, v / v2.z);
    }

    /// <summary>
    /// Subtracts two vectors.
    /// </summary>
    /// <param name="a">Vector to subtract from.</param>
    /// <param name="b">Vector to subtract from the first vector.</param>
    /// <returns>Result of the subtraction.</returns>
    public static fix3 operator -(in fix3 a, in fix3 b)
    {
        fix3 v;
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        v.z = a.z - b.z;
        return v;
    }
    /// <summary>
    /// Adds two vectors together.
    /// </summary>
    /// <param name="a">First vector to add.</param>
    /// <param name="b">Second vector to add.</param>
    /// <returns>Sum of the two vectors.</returns>
    public static fix3 operator +(in fix3 a, in fix3 b)
    {
        fix3 v;
        v.x = a.x + b.x;
        v.y = a.y + b.y;
        v.z = a.z + b.z;
        return v;
    }


    /// <summary>
    /// Negates the vector.
    /// </summary>
    /// <param name="v">Vector to negate.</param>
    /// <returns>Negated vector.</returns>
    public static fix3 operator -(in fix3 v)
    {
        return new fix3(-v.x, -v.y, -v.z);
    }
    /// <summary>
    /// Tests two vectors for componentwise equivalence.
    /// </summary>
    /// <param name="a">First vector to test for equivalence.</param>
    /// <param name="b">Second vector to test for equivalence.</param>
    /// <returns>Whether the vectors were equivalent.</returns>
    public static bool operator ==(in fix3 a, in fix3 b)
    {
        return a.x == b.x && a.y == b.y && a.z == b.z;
    }
    /// <summary>
    /// Tests two vectors for componentwise inequivalence.
    /// </summary>
    /// <param name="a">First vector to test for inequivalence.</param>
    /// <param name="b">Second vector to test for inequivalence.</param>
    /// <returns>Whether the vectors were inequivalent.</returns>
    public static bool operator !=(in fix3 a, in fix3 b)
    {
        return a.x != b.x || a.y != b.y || a.z != b.z;
    }

    public static bool3 operator >(in fix3 a, in fix3 b)
    {
        return new bool3(a.x > b.x, a.y > b.y, a.z > b.z);
    }

    public static bool3 operator <(in fix3 a, in fix3 b)
    {
        return new bool3(a.x < b.x, a.y < b.y, a.z < b.z);
    }

    public static bool3 operator >=(in fix3 a, in fix3 b)
    {
        return new bool3(a.x >= b.x, a.y >= b.y, a.z >= b.z);
    }

    public static bool3 operator <=(in fix3 a, in fix3 b)
    {
        return new bool3(a.x <= b.x, a.y <= b.y, a.z <= b.z);
    }

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <returns>
    /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
    /// </returns>
    /// <param name="other">An object to compare with this object.</param>
    public bool Equals(fix3 other)
    {
        return x == other.x && y == other.y && z == other.z;
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
        if (obj is fix3)
        {
            return Equals((fix3)obj);
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
        return x.GetHashCode() + y.GetHashCode() + z.GetHashCode();
    }


    /// <summary>
    /// Computes the squared distance between two vectors.
    /// </summary>
    /// <param name="a">First vector.</param>
    /// <param name="b">Second vector.</param>
    /// <param name="distanceSquared">Squared distance between the two vectors.</param>
    public static void DistanceSquared(in fix3 a, in fix3 b, out fix distanceSquared)
    {
        fix x = a.x - b.x;
        fix y = a.y - b.y;
        fix z = a.z - b.z;
        distanceSquared = x * x + y * y + z * z;
    }

    /// <summary>
    /// Computes the squared distance between two vectors.
    /// </summary>
    /// <param name="a">First vector.</param>
    /// <param name="b">Second vector.</param>
    /// <returns>Squared distance between the two vectors.</returns>
    public static fix DistanceSquared(in fix3 a, in fix3 b)
    {
        fix x = a.x - b.x;
        fix y = a.y - b.y;
        fix z = a.z - b.z;
        return x * x + y * y + z * z;
    }


    /// <summary>
    /// Computes the distance between two two vectors.
    /// </summary>
    /// <param name="a">First vector.</param>
    /// <param name="b">Second vector.</param>
    /// <param name="distance">Distance between the two vectors.</param>
    public static void Distance(in fix3 a, in fix3 b, out fix distance)
    {
        fix x = a.x - b.x;
        fix y = a.y - b.y;
        fix z = a.z - b.z;
        distance = fix.Sqrt(x * x + y * y + z * z);
    }
    /// <summary>
    /// Computes the distance between two two vectors.
    /// </summary>
    /// <param name="a">First vector.</param>
    /// <param name="b">Second vector.</param>
    /// <returns>Distance between the two vectors.</returns>
    public static fix Distance(in fix3 a, in fix3 b)
    {
        fix toReturn;
        Distance(in a, in b, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Computes the cross product between two vectors.
    /// </summary>
    /// <param name="a">First vector.</param>
    /// <param name="b">Second vector.</param>
    /// <returns>Cross product of the two vectors.</returns>
    public static fix3 Cross(in fix3 a, in fix3 b)
    {
        fix3 toReturn;
        fix3.Cross(in a, in b, out toReturn);
        return toReturn;
    }
    /// <summary>
    /// Computes the cross product between two vectors.
    /// </summary>
    /// <param name="a">First vector.</param>
    /// <param name="b">Second vector.</param>
    /// <param name="result">Cross product of the two vectors.</param>
    public static void Cross(in fix3 a, in fix3 b, out fix3 result)
    {
        fix resultX = a.y * b.z - a.z * b.y;
        fix resultY = a.z * b.x - a.x * b.z;
        fix resultZ = a.x * b.y - a.y * b.x;
        result.x = resultX;
        result.y = resultY;
        result.z = resultZ;
    }

    /// <summary>
    /// Normalizes the given vector.
    /// </summary>
    /// <param name="v">Vector to normalize.</param>
    /// <returns>Normalized vector.</returns>
    public static fix3 Normalize(in fix3 v)
    {
        fix3 toReturn;
        fix3.Normalize(in v, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Normalizes the given vector.
    /// </summary>
    /// <param name="v">Vector to normalize.</param>
    /// <param name="result">Normalized vector.</param>
    public static void Normalize(in fix3 v, out fix3 result)
    {
        fix inverse = F64.C1 / fix.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        result.x = v.x * inverse;
        result.y = v.y * inverse;
        result.z = v.z * inverse;
    }

    /// <summary>
    /// Negates a vector.
    /// </summary>
    /// <param name="v">Vector to negate.</param>
    /// <param name="negated">Negated vector.</param>
    public static void Negate(in fix3 v, out fix3 negated)
    {
        negated.x = -v.x;
        negated.y = -v.y;
        negated.z = -v.z;
    }

    /// <summary>
    /// Computes the absolute value of the input vector.
    /// </summary>
    /// <param name="v">Vector to take the absolute value of.</param>
    /// <param name="result">Vector with nonnegative elements.</param>
    public static void Abs(in fix3 v, out fix3 result)
    {
        if (v.x < F64.C0)
            result.x = -v.x;
        else
            result.x = v.x;
        if (v.y < F64.C0)
            result.y = -v.y;
        else
            result.y = v.y;
        if (v.z < F64.C0)
            result.z = -v.z;
        else
            result.z = v.z;
    }

    /// <summary>
    /// Computes the absolute value of the input vector.
    /// </summary>
    /// <param name="v">Vector to take the absolute value of.</param>
    /// <returns>Vector with nonnegative elements.</returns>
    public static fix3 Abs(in fix3 v)
    {
        fix3 result;
        Abs(in v, out result);
        return result;
    }

    /// <summary>
    /// Creates a vector from the lesser values in each vector.
    /// </summary>
    /// <param name="a">First input vector to compare values from.</param>
    /// <param name="b">Second input vector to compare values from.</param>
    /// <param name="min">Vector containing the lesser values of each vector.</param>
    public static void Min(in fix3 a, in fix3 b, out fix3 min)
    {
        min.x = a.x < b.x ? a.x : b.x;
        min.y = a.y < b.y ? a.y : b.y;
        min.z = a.z < b.z ? a.z : b.z;
    }

    /// <summary>
    /// Creates a vector from the lesser values in each vector.
    /// </summary>
    /// <param name="a">First input vector to compare values from.</param>
    /// <param name="b">Second input vector to compare values from.</param>
    /// <returns>Vector containing the lesser values of each vector.</returns>
    public static fix3 Min(in fix3 a, in fix3 b)
    {
        fix3 result;
        Min(in a, in b, out result);
        return result;
    }


    /// <summary>
    /// Creates a vector from the greater values in each vector.
    /// </summary>
    /// <param name="a">First input vector to compare values from.</param>
    /// <param name="b">Second input vector to compare values from.</param>
    /// <param name="max">Vector containing the greater values of each vector.</param>
    public static void Max(in fix3 a, in fix3 b, out fix3 max)
    {
        max.x = a.x > b.x ? a.x : b.x;
        max.y = a.y > b.y ? a.y : b.y;
        max.z = a.z > b.z ? a.z : b.z;
    }

    /// <summary>
    /// Creates a vector from the greater values in each vector.
    /// </summary>
    /// <param name="a">First input vector to compare values from.</param>
    /// <param name="b">Second input vector to compare values from.</param>
    /// <returns>Vector containing the greater values of each vector.</returns>
    public static fix3 Max(in fix3 a, in fix3 b)
    {
        fix3 result;
        Max(in a, in b, out result);
        return result;
    }

    /// <summary>
    /// Computes an interpolated state between two vectors.
    /// </summary>
    /// <param name="start">Starting location of the interpolation.</param>
    /// <param name="end">Ending location of the interpolation.</param>
    /// <param name="interpolationAmount">Amount of the end location to use.</param>
    /// <returns>Interpolated intermediate state.</returns>
    public static fix3 Lerp(in fix3 start, in fix3 end, in fix interpolationAmount)
    {
        fix3 toReturn;
        Lerp(in start, in end, interpolationAmount, out toReturn);
        return toReturn;
    }
    /// <summary>
    /// Computes an interpolated state between two vectors.
    /// </summary>
    /// <param name="start">Starting location of the interpolation.</param>
    /// <param name="end">Ending location of the interpolation.</param>
    /// <param name="interpolationAmount">Amount of the end location to use.</param>
    /// <param name="result">Interpolated intermediate state.</param>
    public static void Lerp(in fix3 start, in fix3 end, fix interpolationAmount, out fix3 result)
    {
        fix startAmount = F64.C1 - interpolationAmount;
        result.x = start.x * startAmount + end.x * interpolationAmount;
        result.y = start.y * startAmount + end.y * interpolationAmount;
        result.z = start.z * startAmount + end.z * interpolationAmount;
    }

    /// <summary>
    /// Computes an intermediate location using hermite interpolation.
    /// </summary>
    /// <param name="value1">First position.</param>
    /// <param name="tangent1">Tangent associated with the first position.</param>
    /// <param name="value2">Second position.</param>
    /// <param name="tangent2">Tangent associated with the second position.</param>
    /// <param name="interpolationAmount">Amount of the second point to use.</param>
    /// <param name="result">Interpolated intermediate state.</param>
    public static void Hermite(in fix3 value1, in fix3 tangent1, in fix3 value2, in fix3 tangent2, in fix interpolationAmount, out fix3 result)
    {
        fix weightSquared = interpolationAmount * interpolationAmount;
        fix weightCubed = interpolationAmount * weightSquared;
        fix value1Blend = F64.C2 * weightCubed - F64.C3 * weightSquared + F64.C1;
        fix tangent1Blend = weightCubed - F64.C2 * weightSquared + interpolationAmount;
        fix value2Blend = -2 * weightCubed + F64.C3 * weightSquared;
        fix tangent2Blend = weightCubed - weightSquared;
        result.x = value1.x * value1Blend + value2.x * value2Blend + tangent1.x * tangent1Blend + tangent2.x * tangent2Blend;
        result.y = value1.y * value1Blend + value2.y * value2Blend + tangent1.y * tangent1Blend + tangent2.y * tangent2Blend;
        result.z = value1.z * value1Blend + value2.z * value2Blend + tangent1.z * tangent1Blend + tangent2.z * tangent2Blend;
    }
    /// <summary>
    /// Computes an intermediate location using hermite interpolation.
    /// </summary>
    /// <param name="value1">First position.</param>
    /// <param name="tangent1">Tangent associated with the first position.</param>
    /// <param name="value2">Second position.</param>
    /// <param name="tangent2">Tangent associated with the second position.</param>
    /// <param name="interpolationAmount">Amount of the second point to use.</param>
    /// <returns>Interpolated intermediate state.</returns>
    public static fix3 Hermite(in fix3 value1, in fix3 tangent1, in fix3 value2, in fix3 tangent2, in fix interpolationAmount)
    {
        fix3 toReturn;
        Hermite(in value1, in tangent1, in value2, in tangent2, interpolationAmount, out toReturn);
        return toReturn;
    }


    public static readonly fix3 zero = new fix3 { };
    public static readonly fix3 one = new fix3 { x = F64.C1, y = F64.C1, z = F64.C1 };
    public static readonly fix3 right = new fix3 { x = F64.C1 };
    public static readonly fix3 left = new fix3 { x = -F64.C1 };
    public static readonly fix3 up = new fix3 { y = F64.C1 };
    public static readonly fix3 down = new fix3 { y = -F64.C1 };
    public static readonly fix3 forward = new fix3 { z = F64.C1 };
    public static readonly fix3 backward = new fix3 { z = -F64.C1 };

    public static explicit operator fix2(in fix3 v) => new fix2(v.x, v.y);
    public static implicit operator fix3(in int3 v) => new fix3(v.x, v.y, v.z);
    
    public static explicit operator UnityEngine.Vector3(in fix3 v) => new UnityEngine.Vector3((float)v.x, (float)v.y, (float)v.z);
}