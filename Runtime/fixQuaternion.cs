using System;

/// <summary>
/// Provides XNA-like quaternion support.
/// </summary>
[Serializable]
public struct fixQuaternion : IEquatable<fixQuaternion>
{
    /// <summary>
    /// X component of the quaternion.
    /// </summary>
    public fix x;

    /// <summary>
    /// Y component of the quaternion.
    /// </summary>
    public fix y;

    /// <summary>
    /// Z component of the quaternion.
    /// </summary>
    public fix z;

    /// <summary>
    /// W component of the quaternion.
    /// </summary>
    public fix w;

    /// <summary>
    /// Constructs a new FixQuaternion.
    /// </summary>
    /// <param name="x">X component of the quaternion.</param>
    /// <param name="y">Y component of the quaternion.</param>
    /// <param name="z">Z component of the quaternion.</param>
    /// <param name="w">W component of the quaternion.</param>
    public fixQuaternion(in fix x, in fix y, in fix z, in fix w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    /// <summary>
    /// Adds two quaternions together.
    /// </summary>
    /// <param name="a">First quaternion to add.</param>
    /// <param name="b">Second quaternion to add.</param>
    /// <param name="result">Sum of the addition.</param>
    public static void Add(in fixQuaternion a, in fixQuaternion b, out fixQuaternion result)
    {
        result.x = a.x + b.x;
        result.y = a.y + b.y;
        result.z = a.z + b.z;
        result.w = a.w + b.w;
    }

    /// <summary>
    /// Multiplies two quaternions.
    /// </summary>
    /// <param name="a">First quaternion to multiply.</param>
    /// <param name="b">Second quaternion to multiply.</param>
    /// <param name="result">Product of the multiplication.</param>
    public static void Multiply(in fixQuaternion a, in fixQuaternion b, out fixQuaternion result)
    {
        fix x = a.x;
        fix y = a.y;
        fix z = a.z;
        fix w = a.w;
        fix bX = b.x;
        fix bY = b.y;
        fix bZ = b.z;
        fix bW = b.w;
        result.x = x * bW + bX * w + y * bZ - z * bY;
        result.y = y * bW + bY * w + z * bX - x * bZ;
        result.z = z * bW + bZ * w + x * bY - y * bX;
        result.w = w * bW - x * bX - y * bY - z * bZ;
    }

    /// <summary>
    /// Scales a quaternion.
    /// </summary>
    /// <param name="q">FixQuaternion to multiply.</param>
    /// <param name="scale">Amount to multiply each component of the quaternion by.</param>
    /// <param name="result">Scaled quaternion.</param>
    public static void Multiply(in fixQuaternion q, in fix scale, out fixQuaternion result)
    {
        result.x = q.x * scale;
        result.y = q.y * scale;
        result.z = q.z * scale;
        result.w = q.w * scale;
    }

    /// <summary>
    /// Multiplies two quaternions together in opposite order.
    /// </summary>
    /// <param name="a">First quaternion to multiply.</param>
    /// <param name="b">Second quaternion to multiply.</param>
    /// <param name="result">Product of the multiplication.</param>
    public static void Concatenate(in fixQuaternion a, in fixQuaternion b, out fixQuaternion result)
    {
        fix aX = a.x;
        fix aY = a.y;
        fix aZ = a.z;
        fix aW = a.w;
        fix bX = b.x;
        fix bY = b.y;
        fix bZ = b.z;
        fix bW = b.w;

        result.x = aW * bX + aX * bW + aZ * bY - aY * bZ;
        result.y = aW * bY + aY * bW + aX * bZ - aZ * bX;
        result.z = aW * bZ + aZ * bW + aY * bX - aX * bY;
        result.w = aW * bW - aX * bX - aY * bY - aZ * bZ;


    }

    /// <summary>
    /// Multiplies two quaternions together in opposite order.
    /// </summary>
    /// <param name="a">First quaternion to multiply.</param>
    /// <param name="b">Second quaternion to multiply.</param>
    /// <returns>Product of the multiplication.</returns>
    public static fixQuaternion Concatenate(in fixQuaternion a, in fixQuaternion b)
    {
        fixQuaternion result;
        Concatenate(in a, in b, out result);
        return result;
    }

    /// <summary>
    /// FixQuaternion representing the identity transform.
    /// </summary>
    public static fixQuaternion Identity
    {
        get
        {
            return new fixQuaternion(F64.C0, F64.C0, F64.C0, F64.C1);
        }
    }




    /// <summary>
    /// Constructs a quaternion from a rotation matrix.
    /// </summary>
    /// <param name="r">Rotation matrix to create the quaternion from.</param>
    /// <param name="q">FixQuaternion based on the rotation matrix.</param>
    public static void CreateFromRotationMatrix(in fix3x3 r, out fixQuaternion q)
    {
        fix trace = r.M11 + r.M22 + r.M33;
#if !WINDOWS
        q = new fixQuaternion();
#endif
        if (trace >= F64.C0)
        {
            var S = fix.Sqrt(trace + F64.C1) * F64.C2; // S=4*qw 
            var inverseS = F64.C1 / S;
            q.w = F64.C0p25 * S;
            q.x = (r.M23 - r.M32) * inverseS;
            q.y = (r.M31 - r.M13) * inverseS;
            q.z = (r.M12 - r.M21) * inverseS;
        }
        else if ((r.M11 > r.M22) & (r.M11 > r.M33))
        {
            var S = fix.Sqrt(F64.C1 + r.M11 - r.M22 - r.M33) * F64.C2; // S=4*qx 
            var inverseS = F64.C1 / S;
            q.w = (r.M23 - r.M32) * inverseS;
            q.x = F64.C0p25 * S;
            q.y = (r.M21 + r.M12) * inverseS;
            q.z = (r.M31 + r.M13) * inverseS;
        }
        else if (r.M22 > r.M33)
        {
            var S = fix.Sqrt(F64.C1 + r.M22 - r.M11 - r.M33) * F64.C2; // S=4*qy
            var inverseS = F64.C1 / S;
            q.w = (r.M31 - r.M13) * inverseS;
            q.x = (r.M21 + r.M12) * inverseS;
            q.y = F64.C0p25 * S;
            q.z = (r.M32 + r.M23) * inverseS;
        }
        else
        {
            var S = fix.Sqrt(F64.C1 + r.M33 - r.M11 - r.M22) * F64.C2; // S=4*qz
            var inverseS = F64.C1 / S;
            q.w = (r.M12 - r.M21) * inverseS;
            q.x = (r.M31 + r.M13) * inverseS;
            q.y = (r.M32 + r.M23) * inverseS;
            q.z = F64.C0p25 * S;
        }
    }

    /// <summary>
    /// Creates a quaternion from a rotation matrix.
    /// </summary>
    /// <param name="r">Rotation matrix used to create a new quaternion.</param>
    /// <returns>FixQuaternion representing the same rotation as the matrix.</returns>
    public static fixQuaternion CreateFromRotationMatrix(in fix3x3 r)
    {
        fixQuaternion toReturn;
        CreateFromRotationMatrix(in r, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Constructs a quaternion from a rotation matrix.
    /// </summary>
    /// <param name="r">Rotation matrix to create the quaternion from.</param>
    /// <param name="q">FixQuaternion based on the rotation matrix.</param>
    public static void CreateFromRotationMatrix(in fix4x4 r, out fixQuaternion q)
    {
        fix3x3 downsizedMatrix;
        fix3x3.CreateFromMatrix(in r, out downsizedMatrix);
        CreateFromRotationMatrix(in downsizedMatrix, out q);
    }

    /// <summary>
    /// Creates a quaternion from a rotation matrix.
    /// </summary>
    /// <param name="r">Rotation matrix used to create a new quaternion.</param>
    /// <returns>FixQuaternion representing the same rotation as the matrix.</returns>
    public static fixQuaternion CreateFromRotationMatrix(in fix4x4 r)
    {
        fixQuaternion toReturn;
        CreateFromRotationMatrix(in r, out toReturn);
        return toReturn;
    }


    /// <summary>
    /// Ensures the quaternion has unit length.
    /// </summary>
    /// <param name="quaternion">FixQuaternion to normalize.</param>
    /// <returns>Normalized quaternion.</returns>
    public static fixQuaternion Normalize(in fixQuaternion quaternion)
    {
        fixQuaternion toReturn;
        Normalize(in quaternion, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Ensures the quaternion has unit length.
    /// </summary>
    /// <param name="quaternion">FixQuaternion to normalize.</param>
    /// <param name="toReturn">Normalized quaternion.</param>
    public static void Normalize(in fixQuaternion quaternion, out fixQuaternion toReturn)
    {
        fix inverse = F64.C1 / fix.Sqrt(quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w);
        toReturn.x = quaternion.x * inverse;
        toReturn.y = quaternion.y * inverse;
        toReturn.z = quaternion.z * inverse;
        toReturn.w = quaternion.w * inverse;
    }

    /// <summary>
    /// Scales the quaternion such that it has unit length.
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
    /// Computes the squared length of the quaternion.
    /// </summary>
    /// <returns>Squared length of the quaternion.</returns>
    public fix lengthSquared => x * x + y * y + z * z + w * w;

    /// <summary>
    /// Computes the length of the quaternion.
    /// </summary>
    /// <returns>Length of the quaternion.</returns>
    public fix length => fix.Sqrt(x * x + y * y + z * z + w * w);


    /// <summary>
    /// Blends two quaternions together to get an intermediate state.
    /// </summary>
    /// <param name="start">Starting point of the interpolation.</param>
    /// <param name="end">Ending point of the interpolation.</param>
    /// <param name="interpolationAmount">Amount of the end point to use.</param>
    /// <param name="result">Interpolated intermediate quaternion.</param>
    public static void Slerp(in fixQuaternion start, fixQuaternion end, in fix interpolationAmount, out fixQuaternion result)
    {
        fix cosHalfTheta = start.w * end.w + start.x * end.x + start.y * end.y + start.z * end.z;
        if (cosHalfTheta < F64.C0)
        {
            //Negating a quaternion results in the same orientation, 
            //but we need cosHalfTheta to be positive to get the shortest path.
            end.x = -end.x;
            end.y = -end.y;
            end.z = -end.z;
            end.w = -end.w;
            cosHalfTheta = -cosHalfTheta;
        }
        // If the orientations are similar enough, then just pick one of the inputs.
        if (cosHalfTheta > F64.C1m1em12)
        {
            result.w = start.w;
            result.x = start.x;
            result.y = start.y;
            result.z = start.z;
            return;
        }
        // Calculate temporary values.
        fix halfTheta = fix.Acos(cosHalfTheta);
        fix sinHalfTheta = fix.Sqrt(F64.C1 - cosHalfTheta * cosHalfTheta);

        fix aFraction = fix.Sin((F64.C1 - interpolationAmount) * halfTheta) / sinHalfTheta;
        fix bFraction = fix.Sin(interpolationAmount * halfTheta) / sinHalfTheta;

        //Blend the two quaternions to get the result!
        result.x = (fix)(start.x * aFraction + end.x * bFraction);
        result.y = (fix)(start.y * aFraction + end.y * bFraction);
        result.z = (fix)(start.z * aFraction + end.z * bFraction);
        result.w = (fix)(start.w * aFraction + end.w * bFraction);




    }

    /// <summary>
    /// Blends two quaternions together to get an intermediate state.
    /// </summary>
    /// <param name="start">Starting point of the interpolation.</param>
    /// <param name="end">Ending point of the interpolation.</param>
    /// <param name="interpolationAmount">Amount of the end point to use.</param>
    /// <returns>Interpolated intermediate quaternion.</returns>
    public static fixQuaternion Slerp(in fixQuaternion start, in fixQuaternion end, in fix interpolationAmount)
    {
        fixQuaternion toReturn;
        Slerp(in start, end, interpolationAmount, out toReturn);
        return toReturn;
    }


    /// <summary>
    /// Computes the conjugate of the quaternion.
    /// </summary>
    /// <param name="quaternion">FixQuaternion to conjugate.</param>
    /// <param name="result">Conjugated quaternion.</param>
    public static void Conjugate(in fixQuaternion quaternion, out fixQuaternion result)
    {
        result.x = -quaternion.x;
        result.y = -quaternion.y;
        result.z = -quaternion.z;
        result.w = quaternion.w;
    }

    /// <summary>
    /// Computes the conjugate of the quaternion.
    /// </summary>
    /// <param name="quaternion">FixQuaternion to conjugate.</param>
    /// <returns>Conjugated quaternion.</returns>
    public static fixQuaternion Conjugate(in fixQuaternion quaternion)
    {
        fixQuaternion toReturn;
        Conjugate(in quaternion, out toReturn);
        return toReturn;
    }



    /// <summary>
    /// Computes the inverse of the quaternion.
    /// </summary>
    /// <param name="quaternion">FixQuaternion to invert.</param>
    /// <param name="result">Result of the inversion.</param>
    public static void Inverse(in fixQuaternion quaternion, out fixQuaternion result)
    {
        fix inverseSquaredNorm = quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w;
        result.x = -quaternion.x * inverseSquaredNorm;
        result.y = -quaternion.y * inverseSquaredNorm;
        result.z = -quaternion.z * inverseSquaredNorm;
        result.w = quaternion.w * inverseSquaredNorm;
    }

    /// <summary>
    /// Computes the inverse of the quaternion.
    /// </summary>
    /// <param name="quaternion">FixQuaternion to invert.</param>
    /// <returns>Result of the inversion.</returns>
    public static fixQuaternion Inverse(in fixQuaternion quaternion)
    {
        fixQuaternion result;
        Inverse(in quaternion, out result);
        return result;

    }

    /// <summary>
    /// Tests components for equality.
    /// </summary>
    /// <param name="a">First quaternion to test for equivalence.</param>
    /// <param name="b">Second quaternion to test for equivalence.</param>
    /// <returns>Whether or not the quaternions' components were equal.</returns>
    public static bool operator ==(in fixQuaternion a, in fixQuaternion b)
    {
        return a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
    }

    /// <summary>
    /// Tests components for inequality.
    /// </summary>
    /// <param name="a">First quaternion to test for equivalence.</param>
    /// <param name="b">Second quaternion to test for equivalence.</param>
    /// <returns>Whether the quaternions' components were not equal.</returns>
    public static bool operator !=(in fixQuaternion a, in fixQuaternion b)
    {
        return a.x != b.x || a.y != b.y || a.z != b.z || a.w != b.w;
    }

    /// <summary>
    /// Negates the components of a quaternion.
    /// </summary>
    /// <param name="a">FixQuaternion to negate.</param>
    /// <param name="b">Negated result.</param>
    public static void Negate(in fixQuaternion a, out fixQuaternion b)
    {
        b.x = -a.x;
        b.y = -a.y;
        b.z = -a.z;
        b.w = -a.w;
    }

    /// <summary>
    /// Negates the components of a quaternion.
    /// </summary>
    /// <param name="q">FixQuaternion to negate.</param>
    /// <returns>Negated result.</returns>
    public static fixQuaternion Negate(in fixQuaternion q)
    {
        Negate(in q, out var result);
        return result;
    }

    /// <summary>
    /// Negates the components of a quaternion.
    /// </summary>
    /// <param name="q">FixQuaternion to negate.</param>
    /// <returns>Negated result.</returns>
    public static fixQuaternion operator -(in fixQuaternion q)
    {
        Negate(in q, out var result);
        return result;
    }

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <returns>
    /// true if the current object is equal to the <paramin name="other"/> parameter; otherwise, false.
    /// </returns>
    /// <param name="other">An object to compare with this object.</param>
    public bool Equals(fixQuaternion other)
    {
        return x == other.x && y == other.y && z == other.z && w == other.w;
    }

    /// <summary>
    /// Indicates whether this instance and a specified object are equal.
    /// </summary>
    /// <returns>
    /// true if <paramin name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
    /// </returns>
    /// <param name="obj">Another object to compare to. </param><filterpriority>2</filterpriority>
    public override bool Equals(object obj)
    {
        if (obj is fixQuaternion)
        {
            return Equals((fixQuaternion)obj);
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
    /// Transforms the vector using a quaternion.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="rotation">Rotation to apply to the vector.</param>
    /// <param name="result">Transformed vector.</param>
    public static void Transform(in fix3 v, in fixQuaternion rotation, out fix3 result)
    {
        //This operation is an optimized-down version of v' = q * v * q^-1.
        //The expanded form would be to treat v as an 'axis only' quaternion
        //and perform standard quaternion multiplication.  Assuming q is normalized,
        //q^-1 can be replaced by a conjugation.
        fix x2 = rotation.x + rotation.x;
        fix y2 = rotation.y + rotation.y;
        fix z2 = rotation.z + rotation.z;
        fix xx2 = rotation.x * x2;
        fix xy2 = rotation.x * y2;
        fix xz2 = rotation.x * z2;
        fix yy2 = rotation.y * y2;
        fix yz2 = rotation.y * z2;
        fix zz2 = rotation.z * z2;
        fix wx2 = rotation.w * x2;
        fix wy2 = rotation.w * y2;
        fix wz2 = rotation.w * z2;
        //Defer the component setting since they're used in computation.
        fix transformedX = v.x * (F64.C1 - yy2 - zz2) + v.y * (xy2 - wz2) + v.z * (xz2 + wy2);
        fix transformedY = v.x * (xy2 + wz2) + v.y * (F64.C1 - xx2 - zz2) + v.z * (yz2 - wx2);
        fix transformedZ = v.x * (xz2 - wy2) + v.y * (yz2 + wx2) + v.z * (F64.C1 - xx2 - yy2);
        result.x = transformedX;
        result.y = transformedY;
        result.z = transformedZ;

    }

    /// <summary>
    /// Transforms the vector using a quaternion.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="rotation">Rotation to apply to the vector.</param>
    /// <returns>Transformed vector.</returns>
    public static fix3 Transform(in fix3 v, in fixQuaternion rotation)
    {
        fix3 toReturn;
        Transform(in v, in rotation, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Transforms a vector using a quaternion. Specialized for x,0,0 vectors.
    /// </summary>
    /// <param name="x">X component of the vector to transform.</param>
    /// <param name="rotation">Rotation to apply to the vector.</param>
    /// <param name="result">Transformed vector.</param>
    public static void TransformX(fix x, in fixQuaternion rotation, out fix3 result)
    {
        //This operation is an optimized-down version of v' = q * v * q^-1.
        //The expanded form would be to treat v as an 'axis only' quaternion
        //and perform standard quaternion multiplication.  Assuming q is normalized,
        //q^-1 can be replaced by a conjugation.
        fix y2 = rotation.y + rotation.y;
        fix z2 = rotation.z + rotation.z;
        fix xy2 = rotation.x * y2;
        fix xz2 = rotation.x * z2;
        fix yy2 = rotation.y * y2;
        fix zz2 = rotation.z * z2;
        fix wy2 = rotation.w * y2;
        fix wz2 = rotation.w * z2;
        //Defer the component setting since they're used in computation.
        fix transformedX = x * (F64.C1 - yy2 - zz2);
        fix transformedY = x * (xy2 + wz2);
        fix transformedZ = x * (xz2 - wy2);
        result.x = transformedX;
        result.y = transformedY;
        result.z = transformedZ;

    }

    /// <summary>
    /// Transforms a vector using a quaternion. Specialized for 0,y,0 vectors.
    /// </summary>
    /// <param name="y">Y component of the vector to transform.</param>
    /// <param name="rotation">Rotation to apply to the vector.</param>
    /// <param name="result">Transformed vector.</param>
    public static void TransformY(fix y, in fixQuaternion rotation, out fix3 result)
    {
        //This operation is an optimized-down version of v' = q * v * q^-1.
        //The expanded form would be to treat v as an 'axis only' quaternion
        //and perform standard quaternion multiplication.  Assuming q is normalized,
        //q^-1 can be replaced by a conjugation.
        fix x2 = rotation.x + rotation.x;
        fix y2 = rotation.y + rotation.y;
        fix z2 = rotation.z + rotation.z;
        fix xx2 = rotation.x * x2;
        fix xy2 = rotation.x * y2;
        fix yz2 = rotation.y * z2;
        fix zz2 = rotation.z * z2;
        fix wx2 = rotation.w * x2;
        fix wz2 = rotation.w * z2;
        //Defer the component setting since they're used in computation.
        fix transformedX = y * (xy2 - wz2);
        fix transformedY = y * (F64.C1 - xx2 - zz2);
        fix transformedZ = y * (yz2 + wx2);
        result.x = transformedX;
        result.y = transformedY;
        result.z = transformedZ;

    }

    /// <summary>
    /// Transforms a vector using a quaternion. Specialized for 0,0,z vectors.
    /// </summary>
    /// <param name="z">Z component of the vector to transform.</param>
    /// <param name="rotation">Rotation to apply to the vector.</param>
    /// <param name="result">Transformed vector.</param>
    public static void TransformZ(fix z, in fixQuaternion rotation, out fix3 result)
    {
        //This operation is an optimized-down version of v' = q * v * q^-1.
        //The expanded form would be to treat v as an 'axis only' quaternion
        //and perform standard quaternion multiplication.  Assuming q is normalized,
        //q^-1 can be replaced by a conjugation.
        fix x2 = rotation.x + rotation.x;
        fix y2 = rotation.y + rotation.y;
        fix z2 = rotation.z + rotation.z;
        fix xx2 = rotation.x * x2;
        fix xz2 = rotation.x * z2;
        fix yy2 = rotation.y * y2;
        fix yz2 = rotation.y * z2;
        fix wx2 = rotation.w * x2;
        fix wy2 = rotation.w * y2;
        //Defer the component setting since they're used in computation.
        fix transformedX = z * (xz2 + wy2);
        fix transformedY = z * (yz2 - wx2);
        fix transformedZ = z * (F64.C1 - xx2 - yy2);
        result.x = transformedX;
        result.y = transformedY;
        result.z = transformedZ;

    }


    /// <summary>
    /// Multiplies two quaternions.
    /// </summary>
    /// <param name="a">First quaternion to multiply.</param>
    /// <param name="b">Second quaternion to multiply.</param>
    /// <returns>Product of the multiplication.</returns>
    public static fixQuaternion operator *(in fixQuaternion a, in fixQuaternion b)
    {
        fixQuaternion toReturn;
        Multiply(in a, in b, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Creates a quaternion from an axis and angle.
    /// </summary>
    /// <param name="axis">Axis of rotation.</param>
    /// <param name="angle">Angle to rotate around the axis.</param>
    /// <returns>FixQuaternion representing the axis and angle rotation.</returns>
    public static fixQuaternion CreateFromAxisAngle(in fix3 axis, in fix angle)
    {
        fix halfAngle = angle * F64.C0p5;
        fix s = fix.Sin(halfAngle);
        fixQuaternion q;
        q.x = axis.x * s;
        q.y = axis.y * s;
        q.z = axis.z * s;
        q.w = fix.Cos(halfAngle);
        return q;
    }

    /// <summary>
    /// Creates a quaternion from an axis and angle.
    /// </summary>
    /// <param name="axis">Axis of rotation.</param>
    /// <param name="angle">Angle to rotate around the axis.</param>
    /// <param name="q">FixQuaternion representing the axis and angle rotation.</param>
    public static void CreateFromAxisAngle(in fix3 axis, in fix angle, out fixQuaternion q)
    {
        fix halfAngle = angle * F64.C0p5;
        fix s = fix.Sin(halfAngle);
        q.x = axis.x * s;
        q.y = axis.y * s;
        q.z = axis.z * s;
        q.w = fix.Cos(halfAngle);
    }

    /// <summary>
    /// Constructs a quaternion from yaw, pitch, and roll.
    /// </summary>
    /// <param name="yaw">Yaw of the rotation.</param>
    /// <param name="pitch">Pitch of the rotation.</param>
    /// <param name="roll">Roll of the rotation.</param>
    /// <returns>FixQuaternion representing the yaw, pitch, and roll.</returns>
    public static fixQuaternion FromEuler(in fix yaw, in fix pitch, in fix roll)
    {
        fixQuaternion toReturn;
        FromEuler(yaw, pitch, roll, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Constructs a quaternion from yaw, pitch, and roll.
    /// </summary>
    /// <param name="yaw">Yaw of the rotation.</param>
    /// <param name="pitch">Pitch of the rotation.</param>
    /// <param name="roll">Roll of the rotation.</param>
    /// <returns>FixQuaternion representing the yaw, pitch, and roll.</returns>
    public static fixQuaternion FromEuler(in fix3 euler)
    {
        fixQuaternion toReturn;
        FromEuler(euler.x, euler.y, euler.z, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Constructs a quaternion from yaw, pitch, and roll.
    /// </summary>
    /// <param name="yaw">Yaw of the rotation.</param>
    /// <param name="pitch">Pitch of the rotation.</param>
    /// <param name="roll">Roll of the rotation.</param>
    /// <param name="q">FixQuaternion representing the yaw, pitch, and roll.</param>
    public static void FromEuler(in fix yaw, in fix pitch, in fix roll, out fixQuaternion q)
    {
        fix halfRoll = roll * F64.C0p5;
        fix halfPitch = pitch * F64.C0p5;
        fix halfYaw = yaw * F64.C0p5;

        fix sinRoll = fix.Sin(halfRoll);
        fix sinPitch = fix.Sin(halfPitch);
        fix sinYaw = fix.Sin(halfYaw);

        fix cosRoll = fix.Cos(halfRoll);
        fix cosPitch = fix.Cos(halfPitch);
        fix cosYaw = fix.Cos(halfYaw);

        fix cosYawCosPitch = cosYaw * cosPitch;
        fix cosYawSinPitch = cosYaw * sinPitch;
        fix sinYawCosPitch = sinYaw * cosPitch;
        fix sinYawSinPitch = sinYaw * sinPitch;

        q.x = cosYawSinPitch * cosRoll + sinYawCosPitch * sinRoll;
        q.y = sinYawCosPitch * cosRoll - cosYawSinPitch * sinRoll;
        q.z = cosYawCosPitch * sinRoll - sinYawSinPitch * cosRoll;
        q.w = cosYawCosPitch * cosRoll + sinYawSinPitch * sinRoll;

    }

    /// <summary>
    /// Computes the angle change represented by a normalized quaternion.
    /// </summary>
    /// <param name="q">FixQuaternion to be converted.</param>
    /// <returns>Angle around the axis represented by the quaternion.</returns>
    public static fix GetAngleFromQuaternion(in fixQuaternion q)
    {
        fix qw = fix.Abs(q.w);
        if (qw > F64.C1)
            return F64.C0;
        return F64.C2 * fix.Acos(qw);
    }

    /// <summary>
    /// Computes the axis angle representation of a normalized quaternion.
    /// </summary>
    /// <param name="q">FixQuaternion to be converted.</param>
    /// <param name="axis">Axis represented by the quaternion.</param>
    /// <param name="angle">Angle around the axis represented by the quaternion.</param>
    public static void GetAxisAngleFromQuaternion(in fixQuaternion q, out fix3 axis, out fix angle)
    {
#if !WINDOWS
        axis = new fix3();
#endif
        fix qw = q.w;
        if (qw > F64.C0)
        {
            axis.x = q.x;
            axis.y = q.y;
            axis.z = q.z;
        }
        else
        {
            axis.x = -q.x;
            axis.y = -q.y;
            axis.z = -q.z;
            qw = -qw;
        }

        fix lengthSquared = axis.lengthSquared;
        if (lengthSquared > F64.C1em14)
        {
            fix3.Divide(in axis, fix.Sqrt(lengthSquared), out axis);
            angle = F64.C2 * fix.Acos(fixMath.Clamp(qw, -1, F64.C1));
        }
        else
        {
            axis = fix3.up;
            angle = F64.C0;
        }
    }

    /// <summary>
    /// Computes the quaternion rotation between two normalized vectors.
    /// </summary>
    /// <param name="v1">First unit-length vector.</param>
    /// <param name="v2">Second unit-length vector.</param>
    /// <param name="q">FixQuaternion representing the rotation from v1 to v2.</param>
    public static void GetQuaternionBetweenNormalizedVectors(in fix3 v1, in fix3 v2, out fixQuaternion q)
    {
        fix dot;
        fix3.Dot(v1, v2, out dot);
        //For non-normal vectors, the multiplying the axes length squared would be necessary:
        //Fix64 w = dot + (Fix64)Math.Sqrt(v1.lengthSquared * v2.lengthSquared);
        if (dot < F64.Cm0p9999) //parallel, opposing direction
        {
            //If this occurs, the rotation required is ~180 degrees.
            //The problem is that we could choose any perpendicular axis for the rotation. It's not uniquely defined.
            //The solution is to pick an arbitrary perpendicular axis.
            //Project onto the plane which has the lowest component magnitude.
            //On that 2d plane, perform a 90 degree rotation.
            fix absX = fix.Abs(v1.x);
            fix absY = fix.Abs(v1.y);
            fix absZ = fix.Abs(v1.z);
            if (absX < absY && absX < absZ)
                q = new fixQuaternion(F64.C0, -v1.z, v1.y, F64.C0);
            else if (absY < absZ)
                q = new fixQuaternion(-v1.z, F64.C0, v1.x, F64.C0);
            else
                q = new fixQuaternion(-v1.y, v1.x, F64.C0, F64.C0);
        }
        else
        {
            fix3 axis;
            fix3.Cross(in v1, in v2, out axis);
            q = new fixQuaternion(axis.x, axis.y, axis.z, dot + F64.C1);
        }
        q.Normalize();
    }

    //The following two functions are highly similar, but it's a bit of a brain teaser to phrase one in terms of the other.
    //Providing both simplifies things.

    /// <summary>
    /// Computes the rotation from the start orientation to the end orientation such that end = FixQuaternion.Concatenate(start, relative).
    /// </summary>
    /// <param name="start">Starting orientation.</param>
    /// <param name="end">Ending orientation.</param>
    /// <param name="relative">Relative rotation from the start to the end orientation.</param>
    public static void GetRelativeRotation(in fixQuaternion start, in fixQuaternion end, out fixQuaternion relative)
    {
        fixQuaternion startInverse;
        Conjugate(in start, out startInverse);
        Concatenate(in startInverse, in end, out relative);
    }


    /// <summary>
    /// Transforms the rotation into the local space of the target basis such that rotation = FixQuaternion.Concatenate(localRotation, targetBasis)
    /// </summary>
    /// <param name="rotation">Rotation in the original frame of inerence.</param>
    /// <param name="targetBasis">Basis in the original frame of inerence to transform the rotation into.</param>
    /// <param name="localRotation">Rotation in the local space of the target basis.</param>
    public static void GetLocalRotation(in fixQuaternion rotation, in fixQuaternion targetBasis, out fixQuaternion localRotation)
    {
        fixQuaternion basisInverse;
        Conjugate(in targetBasis, out basisInverse);
        Concatenate(in rotation, in basisInverse, out localRotation);
    }

    /// <summary>
    /// Gets a string representation of the quaternion.
    /// </summary>
    /// <returns>String representing the quaternion.</returns>
    public override string ToString()
    {
        return "{ X: " + x + ", Y: " + y + ", Z: " + z + ", W: " + w + "}";
    }
}
