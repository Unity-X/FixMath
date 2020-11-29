using System;
using Unity.Mathematics;

/// <summary>
/// Provides XNA-like 4-component vector math.
/// </summary>
[Serializable]
public struct fix4 : IEquatable<fix4>
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
    /// W component of the vector.
    /// </summary>
    public fix w;

    /// <summary>
    /// Constructs a new 3d vector.
    /// </summary>
    /// <param name="x">X component of the vector.</param>
    /// <param name="y">Y component of the vector.</param>
    /// <param name="z">Z component of the vector.</param>
    /// <param name="w">W component of the vector.</param>
    public fix4(in fix x, in fix y, in fix z, in fix w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    /// <summary>
    /// Constructs a new 3d vector.
    /// </summary>
    /// <param name="xyz">X, Y, and Z components of the vector.</param>
    /// <param name="w">W component of the vector.</param>
    public fix4(in fix3 xyz, in fix w)
    {
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
    }


    /// <summary>
    /// Constructs a new 3d vector.
    /// </summary>
    /// <param name="x">X component of the vector.</param>
    /// <param name="yzw">Y, Z, and W components of the vector.</param>
    public fix4(in fix x, in fix3 yzw)
    {
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
    }

    /// <summary>
    /// Constructs a new 3d vector.
    /// </summary>
    /// <param name="xy">X and Y components of the vector.</param>
    /// <param name="z">Z component of the vector.</param>
    /// <param name="w">W component of the vector.</param>
    public fix4(in fix2 xy, in fix z, in fix w)
    {
        this.x = xy.x;
        this.y = xy.y;
        this.z = z;
        this.w = w;
    }

    /// <summary>
    /// Constructs a new 3d vector.
    /// </summary>
    /// <param name="x">X component of the vector.</param>
    /// <param name="yz">Y and Z components of the vector.</param>
    /// <param name="w">W component of the vector.</param>
    public fix4(in fix x, in fix2 yz, in fix w)
    {
        this.x = x;
        this.y = yz.x;
        this.z = yz.y;
        this.w = w;
    }

    /// <summary>
    /// Constructs a new 3d vector.
    /// </summary>
    /// <param name="x">X component of the vector.</param>
    /// <param name="y">Y and Z components of the vector.</param>
    /// <param name="zw">W component of the vector.</param>
    public fix4(in fix x, in fix y, in fix2 zw)
    {
        this.x = x;
        this.y = y;
        this.z = zw.x;
        this.w = zw.y;
    }

    /// <summary>
    /// Constructs a new 3d vector.
    /// </summary>
    /// <param name="xy">X and Y components of the vector.</param>
    /// <param name="zw">Z and W components of the vector.</param>
    public fix4(in fix2 xy, in fix2 zw)
    {
        this.x = xy.x;
        this.y = xy.y;
        this.z = zw.x;
        this.w = zw.y;
    }

    /// <summary>
    /// Constructs a new four dimensional vector.
    /// </summary>
    public fix4(in fix v)
    {
        this.x = v;
        this.y = v;
        this.z = v;
        this.w = v;
    }

    /// <summary>
    /// Computes the squared length of the vector.
    /// </summary>
    /// <returns>Squared length of the vector.</returns>
    public fix lengthSquared => x * x + y * y + z * z + w * w;

    /// <summary>
    /// Computes the length of the vector.
    /// </summary>
    /// <returns>Length of the vector.</returns>
    public fix length => fix.Sqrt(x * x + y * y + z * z + w * w);

    /// <summary>
    /// Normalizes the vector.
    /// </summary>
    public void Normalize()
    {
        fix inverse = F64.C1 / fix.Sqrt(x * x + y * y + z * z + w * w);
        x *= inverse;
        y *= inverse;
        z *= inverse;
        w *= inverse;
    }

    /// <summary>
    /// Gets a string representation of the vector.
    /// </summary>
    /// <returns>String representing the vector.</returns>
    public override string ToString()
    {
        return "{" + x + ", " + y + ", " + z + ", " + w + "}";
    }

    /// <summary>
    /// Computes the dot product of two vectors.
    /// </summary>
    /// <param name="a">First vector in the product.</param>
    /// <param name="b">Second vector in the product.</param>
    /// <returns>Resulting dot product.</returns>
    public static fix Dot(in fix4 a, in fix4 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
    }

    /// <summary>
    /// Computes the dot product of two vectors.
    /// </summary>
    /// <param name="a">First vector in the product.</param>
    /// <param name="b">Second vector in the product.</param>
    /// <param name="product">Resulting dot product.</param>
    public static void Dot(in fix4 a, in fix4 b, out fix product)
    {
        product = a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
    }
    /// <summary>
    /// Adds two vectors together.
    /// </summary>
    /// <param name="a">First vector to add.</param>
    /// <param name="b">Second vector to add.</param>
    /// <param name="sum">Sum of the two vectors.</param>
    public static void Add(in fix4 a, in fix4 b, out fix4 sum)
    {
        sum.x = a.x + b.x;
        sum.y = a.y + b.y;
        sum.z = a.z + b.z;
        sum.w = a.w + b.w;
    }
    /// <summary>
    /// Subtracts two vectors.
    /// </summary>
    /// <param name="a">Vector to subtract from.</param>
    /// <param name="b">Vector to subtract from the first vector.</param>
    /// <param name="difference">Result of the subtraction.</param>
    public static void Subtract(in fix4 a, in fix4 b, out fix4 difference)
    {
        difference.x = a.x - b.x;
        difference.y = a.y - b.y;
        difference.z = a.z - b.z;
        difference.w = a.w - b.w;
    }
    /// <summary>
    /// Scales a vector.
    /// </summary>
    /// <param name="v">Vector to scale.</param>
    /// <param name="scale">Amount to scale.</param>
    /// <param name="result">Scaled vector.</param>
    public static void Multiply(in fix4 v, fix scale, out fix4 result)
    {
        result.x = v.x * scale;
        result.y = v.y * scale;
        result.z = v.z * scale;
        result.w = v.w * scale;
    }


    /// <summary>
    /// Multiplies two vectors on a per-component basis.
    /// </summary>
    /// <param name="a">First vector to multiply.</param>
    /// <param name="b">Second vector to multiply.</param>
    /// <param name="result">Result of the componentwise multiplication.</param>
    public static void Multiply(in fix4 a, in fix4 b, out fix4 result)
    {
        result.x = a.x * b.x;
        result.y = a.y * b.y;
        result.z = a.z * b.z;
        result.w = a.w * b.w;
    }


    /// <summary>
    /// Divides a vector's components by some amount.
    /// </summary>
    /// <param name="v">Vector to divide.</param>
    /// <param name="divisor">Value to divide the vector's components.</param>
    /// <param name="result">Result of the division.</param>
    public static void Divide(in fix4 v, fix divisor, out fix4 result)
    {
        fix inverse = F64.C1 / divisor;
        result.x = v.x * inverse;
        result.y = v.y * inverse;
        result.z = v.z * inverse;
        result.w = v.w * inverse;
    }
    /// <summary>
    /// Scales a vector.
    /// </summary>
    /// <param name="v">Vector to scale.</param>
    /// <param name="f">Amount to scale.</param>
    /// <returns>Scaled vector.</returns>
    public static fix4 operator *(in fix4 v, in fix f)
    {
        fix4 toReturn;
        toReturn.x = v.x * f;
        toReturn.y = v.y * f;
        toReturn.z = v.z * f;
        toReturn.w = v.w * f;
        return toReturn;
    }
    /// <summary>
    /// Scales a vector.
    /// </summary>
    /// <param name="v">Vector to scale.</param>
    /// <param name="f">Amount to scale.</param>
    /// <returns>Scaled vector.</returns>
    public static fix4 operator *(in fix f, in fix4 v)
    {
        fix4 toReturn;
        toReturn.x = v.x * f;
        toReturn.y = v.y * f;
        toReturn.z = v.z * f;
        toReturn.w = v.w * f;
        return toReturn;
    }


    /// <summary>
    /// Multiplies two vectors on a per-component basis.
    /// </summary>
    /// <param name="a">First vector to multiply.</param>
    /// <param name="b">Second vector to multiply.</param>
    /// <returns>Result of the componentwise multiplication.</returns>
    public static fix4 operator *(in fix4 a, in fix4 b)
    {
        fix4 result;
        Multiply(in a, in b, out result);
        return result;
    }


    /// <summary>
    /// Divides a vector's components by some amount.
    /// </summary>
    /// <param name="v">Vector to divide.</param>
    /// <param name="f">Value to divide the vector's components.</param>
    /// <returns>Result of the division.</returns>
    public static fix4 operator /(in fix4 v, fix f)
    {
        fix4 toReturn;
        f = F64.C1 / f;
        toReturn.x = v.x * f;
        toReturn.y = v.y * f;
        toReturn.z = v.z * f;
        toReturn.w = v.w * f;
        return toReturn;
    }

    /// <summary>
    /// Divides a vector.
    /// </summary>
    public static fix4 operator /(in fix4 v1, fix4 v2)
    {
        return new fix4(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z, v1.w / v2.w);
    }

    public static fix4 operator /(in fix v, fix4 v2)
    {
        return new fix4(v / v2.x, v / v2.y, v / v2.z, v / v2.w);
    }

    /// <summary>
    /// Subtracts two vectors.
    /// </summary>
    /// <param name="a">Vector to subtract from.</param>
    /// <param name="b">Vector to subtract from the first vector.</param>
    /// <returns>Result of the subtraction.</returns>
    public static fix4 operator -(in fix4 a, in fix4 b)
    {
        fix4 v;
        v.x = a.x - b.x;
        v.y = a.y - b.y;
        v.z = a.z - b.z;
        v.w = a.w - b.w;
        return v;
    }
    /// <summary>
    /// Adds two vectors together.
    /// </summary>
    /// <param name="a">First vector to add.</param>
    /// <param name="b">Second vector to add.</param>
    /// <returns>Sum of the two vectors.</returns>
    public static fix4 operator +(in fix4 a, in fix4 b)
    {
        fix4 v;
        v.x = a.x + b.x;
        v.y = a.y + b.y;
        v.z = a.z + b.z;
        v.w = a.w + b.w;
        return v;
    }


    /// <summary>
    /// Negates the vector.
    /// </summary>
    /// <param name="v">Vector to negate.</param>
    /// <returns>Negated vector.</returns>
    public static fix4 operator -(in fix4 v)
    {
        return new fix4(-v.x, -v.y, -v.z, -v.w);
    }
    /// <summary>
    /// Tests two vectors for componentwise equivalence.
    /// </summary>
    /// <param name="a">First vector to test for equivalence.</param>
    /// <param name="b">Second vector to test for equivalence.</param>
    /// <returns>Whether the vectors were equivalent.</returns>
    public static bool operator ==(in fix4 a, in fix4 b)
    {
        return a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
    }
    /// <summary>
    /// Tests two vectors for componentwise inequivalence.
    /// </summary>
    /// <param name="a">First vector to test for inequivalence.</param>
    /// <param name="b">Second vector to test for inequivalence.</param>
    /// <returns>Whether the vectors were inequivalent.</returns>
    public static bool operator !=(in fix4 a, in fix4 b)
    {
        return a.x != b.x || a.y != b.y || a.z != b.z || a.w != b.w;
    }

    public static bool4 operator >(in fix4 a, in fix4 b)
    {
        return new bool4(a.x > b.x, a.y > b.y, a.z > b.z, a.w > b.w);
    }

    public static bool4 operator <(in fix4 a, in fix4 b)
    {
        return new bool4(a.x < b.x, a.y < b.y, a.z < b.z, a.w < b.w);
    }

    public static bool4 operator >=(in fix4 a, in fix4 b)
    {
        return new bool4(a.x >= b.x, a.y >= b.y, a.z >= b.z, a.w >= b.w);
    }

    public static bool4 operator <=(in fix4 a, in fix4 b)
    {
        return new bool4(a.x <= b.x, a.y <= b.y, a.z <= b.z, a.w <= b.w);
    }

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <returns>
    /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
    /// </returns>
    /// <param name="other">An object to compare with this object.</param>
    public bool Equals(fix4 other)
    {
        return x == other.x && y == other.y && z == other.z && w == other.w;
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
        if (obj is fix4)
        {
            return Equals((fix4)obj);
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
        return x.GetHashCode() + y.GetHashCode() + z.GetHashCode() + w.GetHashCode();
    }

    /// <summary>
    /// Computes the squared distance between two vectors.
    /// </summary>
    /// <param name="a">First vector.</param>
    /// <param name="b">Second vector.</param>
    /// <param name="distanceSquared">Squared distance between the two vectors.</param>
    public static void DistanceSquared(in fix4 a, in fix4 b, out fix distanceSquared)
    {
        fix x = a.x - b.x;
        fix y = a.y - b.y;
        fix z = a.z - b.z;
        fix w = a.w - b.w;
        distanceSquared = x * x + y * y + z * z + w * w;
    }

    /// <summary>
    /// Computes the distance between two two vectors.
    /// </summary>
    /// <param name="a">First vector.</param>
    /// <param name="b">Second vector.</param>
    /// <param name="distance">Distance between the two vectors.</param>
    public static void Distance(in fix4 a, in fix4 b, out fix distance)
    {
        fix x = a.x - b.x;
        fix y = a.y - b.y;
        fix z = a.z - b.z;
        fix w = a.w - b.w;
        distance = fix.Sqrt(x * x + y * y + z * z + w * w);
    }
    /// <summary>
    /// Computes the distance between two two vectors.
    /// </summary>
    /// <param name="a">First vector.</param>
    /// <param name="b">Second vector.</param>
    /// <returns>Distance between the two vectors.</returns>
    public static fix Distance(in fix4 a, in fix4 b)
    {
        fix toReturn;
        Distance(in a, in b, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Gets the zero vector.
    /// </summary>
    public static fix4 Zero
    {
        get
        {
            return new fix4();
        }
    }

    /// <summary>
    /// Gets a vector pointing along the X axis.
    /// </summary>
    public static fix4 UnitX
    {
        get { return new fix4 { x = F64.C1 }; }
    }

    /// <summary>
    /// Gets a vector pointing along the Y axis.
    /// </summary>
    public static fix4 UnitY
    {
        get { return new fix4 { y = F64.C1 }; }
    }

    /// <summary>
    /// Gets a vector pointing along the Z axis.
    /// </summary>
    public static fix4 UnitZ
    {
        get { return new fix4 { z = F64.C1 }; }
    }

    /// <summary>
    /// Gets a vector pointing along the W axis.
    /// </summary>
    public static fix4 UnitW
    {
        get { return new fix4 { w = F64.C1 }; }
    }

    /// <summary>
    /// Normalizes the given vector.
    /// </summary>
    /// <param name="v">Vector to normalize.</param>
    /// <returns>Normalized vector.</returns>
    public static fix4 Normalize(fix4 v)
    {
        fix4 toReturn;
        fix4.Normalize(in v, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Normalizes the given vector.
    /// </summary>
    /// <param name="v">Vector to normalize.</param>
    /// <param name="result">Normalized vector.</param>
    public static void Normalize(in fix4 v, out fix4 result)
    {
        fix inverse = F64.C1 / fix.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z + v.w * v.w);
        result.x = v.x * inverse;
        result.y = v.y * inverse;
        result.z = v.z * inverse;
        result.w = v.w * inverse;
    }

    /// <summary>
    /// Negates a vector.
    /// </summary>
    /// <param name="v">Vector to negate.</param>
    /// <param name="negated">Negated vector.</param>
    public static void Negate(in fix4 v, out fix4 negated)
    {
        negated.x = -v.x;
        negated.y = -v.y;
        negated.z = -v.z;
        negated.w = -v.w;
    }


    /// <summary>
    /// Computes the absolute value of the input vector.
    /// </summary>
    /// <param name="v">Vector to take the absolute value of.</param>
    /// <param name="result">Vector with nonnegative elements.</param>
    public static void Abs(in fix4 v, out fix4 result)
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
        if (v.w < F64.C0)
            result.w = -v.w;
        else
            result.w = v.w;
    }

    /// <summary>
    /// Computes the absolute value of the input vector.
    /// </summary>
    /// <param name="v">Vector to take the absolute value of.</param>
    /// <returns>Vector with nonnegative elements.</returns>
    public static fix4 Abs(in fix4 v)
    {
        fix4 result;
        Abs(in v, out result);
        return result;
    }

    /// <summary>
    /// Creates a vector from the lesser values in each vector.
    /// </summary>
    /// <param name="a">First input vector to compare values from.</param>
    /// <param name="b">Second input vector to compare values from.</param>
    /// <param name="min">Vector containing the lesser values of each vector.</param>
    public static void Min(in fix4 a, in fix4 b, out fix4 min)
    {
        min.x = a.x < b.x ? a.x : b.x;
        min.y = a.y < b.y ? a.y : b.y;
        min.z = a.z < b.z ? a.z : b.z;
        min.w = a.w < b.w ? a.w : b.w;
    }

    /// <summary>
    /// Creates a vector from the lesser values in each vector.
    /// </summary>
    /// <param name="a">First input vector to compare values from.</param>
    /// <param name="b">Second input vector to compare values from.</param>
    /// <returns>Vector containing the lesser values of each vector.</returns>
    public static fix4 Min(in fix4 a, in fix4 b)
    {
        fix4 result;
        Min(in a, in b, out result);
        return result;
    }


    /// <summary>
    /// Creates a vector from the greater values in each vector.
    /// </summary>
    /// <param name="a">First input vector to compare values from.</param>
    /// <param name="b">Second input vector to compare values from.</param>
    /// <param name="max">Vector containing the greater values of each vector.</param>
    public static void Max(in fix4 a, in fix4 b, out fix4 max)
    {
        max.x = a.x > b.x ? a.x : b.x;
        max.y = a.y > b.y ? a.y : b.y;
        max.z = a.z > b.z ? a.z : b.z;
        max.w = a.w > b.w ? a.w : b.w;
    }

    /// <summary>
    /// Creates a vector from the greater values in each vector.
    /// </summary>
    /// <param name="a">First input vector to compare values from.</param>
    /// <param name="b">Second input vector to compare values from.</param>
    /// <returns>Vector containing the greater values of each vector.</returns>
    public static fix4 Max(in fix4 a, in fix4 b)
    {
        fix4 result;
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
    public static fix4 Lerp(in fix4 start, in fix4 end, in fix interpolationAmount)
    {
        fix4 toReturn;
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
    public static void Lerp(in fix4 start, in fix4 end, in fix interpolationAmount, out fix4 result)
    {
        fix startAmount = F64.C1 - interpolationAmount;
        result.x = start.x * startAmount + end.x * interpolationAmount;
        result.y = start.y * startAmount + end.y * interpolationAmount;
        result.z = start.z * startAmount + end.z * interpolationAmount;
        result.w = start.w * startAmount + end.w * interpolationAmount;
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
    public static void Hermite(in fix4 value1, in fix4 tangent1, in fix4 value2, in fix4 tangent2, in fix interpolationAmount, out fix4 result)
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
        result.w = value1.w * value1Blend + value2.w * value2Blend + tangent1.w * tangent1Blend + tangent2.w * tangent2Blend;
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
    public static fix4 Hermite(in fix4 value1, in fix4 tangent1, in fix4 value2, in fix4 tangent2, in fix interpolationAmount)
    {
        fix4 toReturn;
        Hermite(in value1, in tangent1, in value2, in tangent2, interpolationAmount, out toReturn);
        return toReturn;
    }
}