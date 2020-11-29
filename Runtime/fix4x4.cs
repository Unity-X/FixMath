using System;
using UnityEngine;

/// <summary>
/// Provides XNA-like 4x4 matrix math.
/// </summary>
[Serializable]
public struct fix4x4
{
    /// <summary>
    /// Value at row 1, column 1 of the matrix.
    /// </summary>
    public fix M11;

    /// <summary>
    /// Value at row 2, column 1 of the matrix.
    /// </summary>
    public fix M21;

    /// <summary>
    /// Value at row 3, column 1 of the matrix.
    /// </summary>
    public fix M31;

    /// <summary>
    /// Value at row 4, column 1 of the matrix.
    /// </summary>
    public fix M41;

    /// <summary>
    /// Value at row 1, column 2 of the matrix.
    /// </summary>
    public fix M12;

    /// <summary>
    /// Value at row 2, column 2 of the matrix.
    /// </summary>
    public fix M22;

    /// <summary>
    /// Value at row 3, column 2 of the matrix.
    /// </summary>
    public fix M32;

    /// <summary>
    /// Value at row 4, column 2 of the matrix.
    /// </summary>
    public fix M42;

    /// <summary>
    /// Value at row 1, column 3 of the matrix.
    /// </summary>
    public fix M13;

    /// <summary>
    /// Value at row 2, column 3 of the matrix.
    /// </summary>
    public fix M23;

    /// <summary>
    /// Value at row 3, column 3 of the matrix.
    /// </summary>
    public fix M33;

    /// <summary>
    /// Value at row 4, column 3 of the matrix.
    /// </summary>
    public fix M43;

    /// <summary>
    /// Value at row 1, column 4 of the matrix.
    /// </summary>
    public fix M14;

    /// <summary>
    /// Value at row 2, column 4 of the matrix.
    /// </summary>
    public fix M24;

    /// <summary>
    /// Value at row 3, column 4 of the matrix.
    /// </summary>
    public fix M34;

    /// <summary>
    /// Value at row 4, column 4 of the matrix.
    /// </summary>
    public fix M44;

    /// <summary>
    /// Constructs a new 4 row, 4 column matrix.
    /// </summary>
    /// <param name="m11">Value at row 1, column 1 of the matrix.</param>
    /// <param name="m12">Value at row 1, column 2 of the matrix.</param>
    /// <param name="m13">Value at row 1, column 3 of the matrix.</param>
    /// <param name="m14">Value at row 1, column 4 of the matrix.</param>
    /// <param name="m21">Value at row 2, column 1 of the matrix.</param>
    /// <param name="m22">Value at row 2, column 2 of the matrix.</param>
    /// <param name="m23">Value at row 2, column 3 of the matrix.</param>
    /// <param name="m24">Value at row 2, column 4 of the matrix.</param>
    /// <param name="m31">Value at row 3, column 1 of the matrix.</param>
    /// <param name="m32">Value at row 3, column 2 of the matrix.</param>
    /// <param name="m33">Value at row 3, column 3 of the matrix.</param>
    /// <param name="m34">Value at row 3, column 4 of the matrix.</param>
    /// <param name="m41">Value at row 4, column 1 of the matrix.</param>
    /// <param name="m42">Value at row 4, column 2 of the matrix.</param>
    /// <param name="m43">Value at row 4, column 3 of the matrix.</param>
    /// <param name="m44">Value at row 4, column 4 of the matrix.</param>
    public fix4x4(fix m11, fix m12, fix m13, fix m14,
                  fix m21, fix m22, fix m23, fix m24,
                  fix m31, fix m32, fix m33, fix m34,
                  fix m41, fix m42, fix m43, fix m44)
    {
        this.M11 = m11;
        this.M21 = m12;
        this.M31 = m13;
        this.M41 = m14;

        this.M12 = m21;
        this.M22 = m22;
        this.M32 = m23;
        this.M42 = m24;

        this.M13 = m31;
        this.M23 = m32;
        this.M33 = m33;
        this.M43 = m34;

        this.M14 = m41;
        this.M24 = m42;
        this.M34 = m43;
        this.M44 = m44;
    }

    /// <summary>
    /// Gets or sets the translation component of the transform.
    /// </summary>
    public fix3 Translation
    {
        get
        {
            return new fix3()
            {
                x = M14,
                y = M24,
                z = M34
            };
        }
        set
        {
            M14 = value.x;
            M24 = value.y;
            M34 = value.z;
        }
    }

    /// <summary>
    /// Gets or sets the backward vector of the matrix.
    /// </summary>
    public fix3 Backward
    {
        get
        {
#if !WINDOWS
            fix3 vector = new fix3();
#else
                FixVector3 vector;
#endif
            vector.x = M13;
            vector.y = M23;
            vector.z = M33;
            return vector;
        }
        set
        {
            M13 = value.x;
            M23 = value.y;
            M33 = value.z;
        }
    }

    /// <summary>
    /// Gets or sets the down vector of the matrix.
    /// </summary>
    public fix3 Down
    {
        get
        {
#if !WINDOWS
            fix3 vector = new fix3();
#else
                FixVector3 vector;
#endif
            vector.x = -M12;
            vector.y = -M22;
            vector.z = -M32;
            return vector;
        }
        set
        {
            M12 = -value.x;
            M22 = -value.y;
            M32 = -value.z;
        }
    }

    /// <summary>
    /// Gets or sets the forward vector of the matrix.
    /// </summary>
    public fix3 Forward
    {
        get
        {
#if !WINDOWS
            fix3 vector = new fix3();
#else
                FixVector3 vector;
#endif
            vector.x = -M13;
            vector.y = -M23;
            vector.z = -M33;
            return vector;
        }
        set
        {
            M13 = -value.x;
            M23 = -value.y;
            M33 = -value.z;
        }
    }

    /// <summary>
    /// Gets or sets the left vector of the matrix.
    /// </summary>
    public fix3 Left
    {
        get
        {
#if !WINDOWS
            fix3 vector = new fix3();
#else
                FixVector3 vector;
#endif
            vector.x = -M11;
            vector.y = -M21;
            vector.z = -M31;
            return vector;
        }
        set
        {
            M11 = -value.x;
            M21 = -value.y;
            M31 = -value.z;
        }
    }

    /// <summary>
    /// Gets or sets the right vector of the matrix.
    /// </summary>
    public fix3 Right
    {
        get
        {
#if !WINDOWS
            fix3 vector = new fix3();
#else
                FixVector3 vector;
#endif
            vector.x = M11;
            vector.y = M21;
            vector.z = M31;
            return vector;
        }
        set
        {
            M11 = value.x;
            M21 = value.y;
            M31 = value.z;
        }
    }

    /// <summary>
    /// Gets or sets the up vector of the matrix.
    /// </summary>
    public fix3 Up
    {
        get
        {
#if !WINDOWS
            fix3 vector = new fix3();
#else
                FixVector3 vector;
#endif
            vector.x = M12;
            vector.y = M22;
            vector.z = M32;
            return vector;
        }
        set
        {
            M12 = value.x;
            M22 = value.y;
            M32 = value.z;
        }
    }


    /// <summary>
    /// Computes the determinant of the matrix.
    /// </summary>
    /// <returns></returns>
    public fix Determinant()
    {
        //Compute the re-used 2x2 determinants.
        fix det1 = M33 * M44 - M43 * M34;
        fix det2 = M23 * M44 - M43 * M24;
        fix det3 = M23 * M34 - M33 * M24;
        fix det4 = M13 * M44 - M43 * M14;
        fix det5 = M13 * M34 - M33 * M14;
        fix det6 = M13 * M24 - M23 * M14;
        return
            (M11 * ((M22 * det1 - M32 * det2) + M42 * det3)) -
            (M21 * ((M12 * det1 - M32 * det4) + M42 * det5)) +
            (M31 * ((M12 * det2 - M22 * det4) + M42 * det6)) -
            (M41 * ((M12 * det3 - M22 * det5) + M32 * det6));
    }

    /// <summary>
    /// Transposes the matrix in-place.
    /// </summary>
    public void Transpose()
    {
        fix intermediate = M21;
        M21 = M12;
        M12 = intermediate;

        intermediate = M31;
        M31 = M13;
        M13 = intermediate;

        intermediate = M41;
        M41 = M14;
        M14 = intermediate;

        intermediate = M32;
        M32 = M23;
        M23 = intermediate;

        intermediate = M42;
        M42 = M24;
        M24 = intermediate;

        intermediate = M43;
        M43 = M34;
        M34 = intermediate;
    }

    /// <summary>
    /// Creates a matrix representing the given axis and angle rotation.
    /// </summary>
    /// <param name="axis">Axis around which to rotate.</param>
    /// <param name="angle">Angle to rotate around the axis.</param>
    /// <returns>FixMatrix created from the axis and angle.</returns>
    public static fix4x4 CreateFromAxisAngle(in fix3 axis, in fix angle)
    {
        fix4x4 toReturn;
        CreateFromAxisAngle(in axis, angle, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Creates a matrix representing the given axis and angle rotation.
    /// </summary>
    /// <param name="axis">Axis around which to rotate.</param>
    /// <param name="angle">Angle to rotate around the axis.</param>
    /// <param name="result">FixMatrix created from the axis and angle.</param>
    public static void CreateFromAxisAngle(in fix3 axis, in fix angle, out fix4x4 result)
    {
        fix xx = axis.x * axis.x;
        fix yy = axis.y * axis.y;
        fix zz = axis.z * axis.z;
        fix xy = axis.x * axis.y;
        fix xz = axis.x * axis.z;
        fix yz = axis.y * axis.z;

        fix sinAngle = fix.Sin(angle);
        fix oneMinusCosAngle = F64.C1 - fix.Cos(angle);

        result.M11 = F64.C1 + oneMinusCosAngle * (xx - F64.C1);
        result.M12 = -axis.z * sinAngle + oneMinusCosAngle * xy;
        result.M13 = axis.y * sinAngle + oneMinusCosAngle * xz;
        result.M14 = F64.C0;

        result.M21 = axis.z * sinAngle + oneMinusCosAngle * xy;
        result.M22 = F64.C1 + oneMinusCosAngle * (yy - F64.C1);
        result.M23 = -axis.x * sinAngle + oneMinusCosAngle * yz;
        result.M24 = F64.C0;

        result.M31 = -axis.y * sinAngle + oneMinusCosAngle * xz;
        result.M32 = axis.x * sinAngle + oneMinusCosAngle * yz;
        result.M33 = F64.C1 + oneMinusCosAngle * (zz - F64.C1);
        result.M34 = F64.C0;

        result.M41 = F64.C0;
        result.M42 = F64.C0;
        result.M43 = F64.C0;
        result.M44 = F64.C1;
    }

    /// <summary>
    /// Creates a rotation matrix from a quaternion.
    /// </summary>
    /// <param name="quaternion">FixQuaternion to convert.</param>
    /// <param name="result">Rotation matrix created from the quaternion.</param>
    public static void CreateFromQuaternion(in fixQuaternion quaternion, out fix4x4 result)
    {
        fix qX2 = quaternion.x + quaternion.x;
        fix qY2 = quaternion.y + quaternion.y;
        fix qZ2 = quaternion.z + quaternion.z;
        fix XX = qX2 * quaternion.x;
        fix YY = qY2 * quaternion.y;
        fix ZZ = qZ2 * quaternion.z;
        fix XY = qX2 * quaternion.y;
        fix XZ = qX2 * quaternion.z;
        fix XW = qX2 * quaternion.w;
        fix YZ = qY2 * quaternion.z;
        fix YW = qY2 * quaternion.w;
        fix ZW = qZ2 * quaternion.w;

        result.M11 = F64.C1 - YY - ZZ;
        result.M12 = XY - ZW;
        result.M13 = XZ + YW;
        result.M14 = F64.C0;

        result.M21 = XY + ZW;
        result.M22 = F64.C1 - XX - ZZ;
        result.M23 = YZ - XW;
        result.M24 = F64.C0;

        result.M31 = XZ - YW;
        result.M32 = YZ + XW;
        result.M33 = F64.C1 - XX - YY;
        result.M34 = F64.C0;

        result.M41 = F64.C0;
        result.M42 = F64.C0;
        result.M43 = F64.C0;
        result.M44 = F64.C1;
    }

    /// <summary>
    /// Creates a rotation matrix from a quaternion.
    /// </summary>
    /// <param name="quaternion">FixQuaternion to convert.</param>
    /// <returns>Rotation matrix created from the quaternion.</returns>
    public static fix4x4 CreateFromQuaternion(in fixQuaternion quaternion)
    {
        fix4x4 toReturn;
        CreateFromQuaternion(in quaternion, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Multiplies two matrices together.
    /// </summary>
    /// <param name="a">First matrix to multiply.</param>
    /// <param name="b">Second matrix to multiply.</param>
    /// <param name="result">Combined transformation.</param>
    public static void Multiply(in fix4x4 a, in fix4x4 b, out fix4x4 result)
    {
        fix resultM11 = a.M11 * b.M11 + a.M21 * b.M12 + a.M31 * b.M13 + a.M41 * b.M14;
        fix resultM12 = a.M11 * b.M21 + a.M21 * b.M22 + a.M31 * b.M23 + a.M41 * b.M24;
        fix resultM13 = a.M11 * b.M31 + a.M21 * b.M32 + a.M31 * b.M33 + a.M41 * b.M34;
        fix resultM14 = a.M11 * b.M41 + a.M21 * b.M42 + a.M31 * b.M43 + a.M41 * b.M44;

        fix resultM21 = a.M12 * b.M11 + a.M22 * b.M12 + a.M32 * b.M13 + a.M42 * b.M14;
        fix resultM22 = a.M12 * b.M21 + a.M22 * b.M22 + a.M32 * b.M23 + a.M42 * b.M24;
        fix resultM23 = a.M12 * b.M31 + a.M22 * b.M32 + a.M32 * b.M33 + a.M42 * b.M34;
        fix resultM24 = a.M12 * b.M41 + a.M22 * b.M42 + a.M32 * b.M43 + a.M42 * b.M44;

        fix resultM31 = a.M13 * b.M11 + a.M23 * b.M12 + a.M33 * b.M13 + a.M43 * b.M14;
        fix resultM32 = a.M13 * b.M21 + a.M23 * b.M22 + a.M33 * b.M23 + a.M43 * b.M24;
        fix resultM33 = a.M13 * b.M31 + a.M23 * b.M32 + a.M33 * b.M33 + a.M43 * b.M34;
        fix resultM34 = a.M13 * b.M41 + a.M23 * b.M42 + a.M33 * b.M43 + a.M43 * b.M44;

        fix resultM41 = a.M14 * b.M11 + a.M24 * b.M12 + a.M34 * b.M13 + a.M44 * b.M14;
        fix resultM42 = a.M14 * b.M21 + a.M24 * b.M22 + a.M34 * b.M23 + a.M44 * b.M24;
        fix resultM43 = a.M14 * b.M31 + a.M24 * b.M32 + a.M34 * b.M33 + a.M44 * b.M34;
        fix resultM44 = a.M14 * b.M41 + a.M24 * b.M42 + a.M34 * b.M43 + a.M44 * b.M44;

        result.M11 = resultM11;
        result.M21 = resultM12;
        result.M31 = resultM13;
        result.M41 = resultM14;

        result.M12 = resultM21;
        result.M22 = resultM22;
        result.M32 = resultM23;
        result.M42 = resultM24;

        result.M13 = resultM31;
        result.M23 = resultM32;
        result.M33 = resultM33;
        result.M43 = resultM34;

        result.M14 = resultM41;
        result.M24 = resultM42;
        result.M34 = resultM43;
        result.M44 = resultM44;
    }


    /// <summary>
    /// Multiplies two matrices together.
    /// </summary>
    /// <param name="a">First matrix to multiply.</param>
    /// <param name="b">Second matrix to multiply.</param>
    /// <returns>Combined transformation.</returns>
    public static fix4x4 Multiply(in fix4x4 a, in fix4x4 b)
    {
        fix4x4 result;
        Multiply(in a, in b, out result);
        return result;
    }


    /// <summary>
    /// Scales all components of the matrix.
    /// </summary>
    /// <param name="matrix">FixMatrix to scale.</param>
    /// <param name="scale">Amount to scale.</param>
    /// <param name="result">Scaled matrix.</param>
    public static void Multiply(in fix4x4 matrix, in fix scale, out fix4x4 result)
    {
        result.M11 = matrix.M11 * scale;
        result.M21 = matrix.M21 * scale;
        result.M31 = matrix.M31 * scale;
        result.M41 = matrix.M41 * scale;

        result.M12 = matrix.M12 * scale;
        result.M22 = matrix.M22 * scale;
        result.M32 = matrix.M32 * scale;
        result.M42 = matrix.M42 * scale;

        result.M13 = matrix.M13 * scale;
        result.M23 = matrix.M23 * scale;
        result.M33 = matrix.M33 * scale;
        result.M43 = matrix.M43 * scale;

        result.M14 = matrix.M14 * scale;
        result.M24 = matrix.M24 * scale;
        result.M34 = matrix.M34 * scale;
        result.M44 = matrix.M44 * scale;
    }

    /// <summary>
    /// Multiplies two matrices together.
    /// </summary>
    /// <param name="a">First matrix to multiply.</param>
    /// <param name="b">Second matrix to multiply.</param>
    /// <returns>Combined transformation.</returns>
    public static fix4x4 operator *(in fix4x4 a, in fix4x4 b)
    {
        fix4x4 toReturn;
        Multiply(in a, in b, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Scales all components of the matrix by the given value.
    /// </summary>
    /// <param name="m">First matrix to multiply.</param>
    /// <param name="f">Scaling value to apply to all components of the matrix.</param>
    /// <returns>Product of the multiplication.</returns>
    public static fix4x4 operator *(in fix4x4 m, in fix f)
    {
        fix4x4 result;
        Multiply(in m, f, out result);
        return result;
    }

    /// <summary>
    /// Scales all components of the matrix by the given value.
    /// </summary>
    /// <param name="m">First matrix to multiply.</param>
    /// <param name="f">Scaling value to apply to all components of the matrix.</param>
    /// <returns>Product of the multiplication.</returns>
    public static fix4x4 operator *(in fix f, in fix4x4 m)
    {
        fix4x4 result;
        Multiply(in m, f, out result);
        return result;
    }

    /// <summary>
    /// Transforms a vector using a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to apply to the vector.</param>
    /// <param name="result">Transformed vector.</param>
    public static void Transform(in fix4 v, in fix4x4 matrix, out fix4 result)
    {
        fix vX = v.x;
        fix vY = v.y;
        fix vZ = v.z;
        fix vW = v.w;
        result.x = vX * matrix.M11 + vY * matrix.M12 + vZ * matrix.M13 + vW * matrix.M14;
        result.y = vX * matrix.M21 + vY * matrix.M22 + vZ * matrix.M23 + vW * matrix.M24;
        result.z = vX * matrix.M31 + vY * matrix.M32 + vZ * matrix.M33 + vW * matrix.M34;
        result.w = vX * matrix.M41 + vY * matrix.M42 + vZ * matrix.M43 + vW * matrix.M44;
    }

    /// <summary>
    /// Transforms a vector using a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to apply to the vector.</param>
    /// <returns>Transformed vector.</returns>
    public static fix4 Transform(in fix4 v, in fix4x4 matrix)
    {
        fix4 toReturn;
        Transform(in v, in matrix, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Transforms a vector using the transpose of a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
    /// <param name="result">Transformed vector.</param>
    public static void TransformTranspose(in fix4 v, in fix4x4 matrix, out fix4 result)
    {
        fix vX = v.x;
        fix vY = v.y;
        fix vZ = v.z;
        fix vW = v.w;
        result.x = vX * matrix.M11 + vY * matrix.M21 + vZ * matrix.M31 + vW * matrix.M41;
        result.y = vX * matrix.M12 + vY * matrix.M22 + vZ * matrix.M32 + vW * matrix.M42;
        result.z = vX * matrix.M13 + vY * matrix.M23 + vZ * matrix.M33 + vW * matrix.M43;
        result.w = vX * matrix.M14 + vY * matrix.M24 + vZ * matrix.M34 + vW * matrix.M44;
    }

    /// <summary>
    /// Transforms a vector using the transpose of a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
    /// <returns>Transformed vector.</returns>
    public static fix4 TransformTranspose(in fix4 v, in fix4x4 matrix)
    {
        fix4 toReturn;
        TransformTranspose(in v, in matrix, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Transforms a vector using a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to apply to the vector.</param>
    /// <param name="result">Transformed vector.</param>
    public static void Transform(in fix3 v, in fix4x4 matrix, out fix4 result)
    {
        result.x = v.x * matrix.M11 + v.y * matrix.M12 + v.z * matrix.M13 + matrix.M14;
        result.y = v.x * matrix.M21 + v.y * matrix.M22 + v.z * matrix.M23 + matrix.M24;
        result.z = v.x * matrix.M31 + v.y * matrix.M32 + v.z * matrix.M33 + matrix.M34;
        result.w = v.x * matrix.M41 + v.y * matrix.M42 + v.z * matrix.M43 + matrix.M44;
    }

    /// <summary>
    /// Transforms a vector using a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to apply to the vector.</param>
    /// <returns>Transformed vector.</returns>
    public static fix4 Transform(in fix3 v, in fix4x4 matrix)
    {
        fix4 toReturn;
        Transform(in v, in matrix, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Transforms a postion using a matrix.
    /// </summary>
    /// <param name="v">Position to transform.</param>
    /// <param name="matrix">Transform to apply to the vector.</param>
    /// <returns>Transformed vector.</returns>
    public static fix3 TransformPoint(in fix3 v, in fix4x4 matrix)
    {
        fix4 result;
        Transform(in v, in matrix, out result);
        return new fix3(result.x / result.w, result.y / result.w, result.z / result.w);
    }

    /// <summary>
    /// Transforms a vector using the transpose of a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
    /// <param name="result">Transformed vector.</param>
    public static void TransformTranspose(in fix3 v, in fix4x4 matrix, out fix4 result)
    {
        result.x = v.x * matrix.M11 + v.y * matrix.M21 + v.z * matrix.M31 + matrix.M41;
        result.y = v.x * matrix.M12 + v.y * matrix.M22 + v.z * matrix.M32 + matrix.M42;
        result.z = v.x * matrix.M13 + v.y * matrix.M23 + v.z * matrix.M33 + matrix.M43;
        result.w = v.x * matrix.M14 + v.y * matrix.M24 + v.z * matrix.M34 + matrix.M44;
    }

    /// <summary>
    /// Transforms a vector using the transpose of a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
    /// <returns>Transformed vector.</returns>
    public static fix4 TransformTranspose(in fix3 v, in fix4x4 matrix)
    {
        fix4 toReturn;
        TransformTranspose(in v, in matrix, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Transforms a vector using a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to apply to the vector.</param>
    /// <param name="result">Transformed vector.</param>
    public static void Transform(in fix3 v, in fix4x4 matrix, out fix3 result)
    {
        fix vX = v.x;
        fix vY = v.y;
        fix vZ = v.z;
        result.x = vX * matrix.M11 + vY * matrix.M12 + vZ * matrix.M13 + matrix.M14;
        result.y = vX * matrix.M21 + vY * matrix.M22 + vZ * matrix.M23 + matrix.M24;
        result.z = vX * matrix.M31 + vY * matrix.M32 + vZ * matrix.M33 + matrix.M34;
    }

    /// <summary>
    /// Transforms a vector using the transpose of a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
    /// <param name="result">Transformed vector.</param>
    public static void TransformTranspose(in fix3 v, in fix4x4 matrix, out fix3 result)
    {
        fix vX = v.x;
        fix vY = v.y;
        fix vZ = v.z;
        result.x = vX * matrix.M11 + vY * matrix.M21 + vZ * matrix.M31 + matrix.M41;
        result.y = vX * matrix.M12 + vY * matrix.M22 + vZ * matrix.M32 + matrix.M42;
        result.z = vX * matrix.M13 + vY * matrix.M23 + vZ * matrix.M33 + matrix.M43;
    }

    /// <summary>
    /// Transforms a vector using a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to apply to the vector.</param>
    /// <param name="result">Transformed vector.</param>
    public static void TransformNormal(in fix3 v, in fix4x4 matrix, out fix3 result)
    {
        fix vX = v.x;
        fix vY = v.y;
        fix vZ = v.z;
        result.x = vX * matrix.M11 + vY * matrix.M12 + vZ * matrix.M13;
        result.y = vX * matrix.M21 + vY * matrix.M22 + vZ * matrix.M23;
        result.z = vX * matrix.M31 + vY * matrix.M32 + vZ * matrix.M33;
    }

    /// <summary>
    /// Transforms a vector using a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to apply to the vector.</param>
    /// <returns>Transformed vector.</returns>
    public static fix3 TransformNormal(in fix3 v, in fix4x4 matrix)
    {
        fix3 toReturn;
        TransformNormal(in v, in matrix, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Transforms a vector using the transpose of a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
    /// <param name="result">Transformed vector.</param>
    public static void TransformNormalTranspose(in fix3 v, in fix4x4 matrix, out fix3 result)
    {
        fix vX = v.x;
        fix vY = v.y;
        fix vZ = v.z;
        result.x = vX * matrix.M11 + vY * matrix.M21 + vZ * matrix.M31;
        result.y = vX * matrix.M12 + vY * matrix.M22 + vZ * matrix.M32;
        result.z = vX * matrix.M13 + vY * matrix.M23 + vZ * matrix.M33;
    }

    /// <summary>
    /// Transforms a vector using the transpose of a matrix.
    /// </summary>
    /// <param name="v">Vector to transform.</param>
    /// <param name="matrix">Transform to tranpose and apply to the vector.</param>
    /// <returns>Transformed vector.</returns>
    public static fix3 TransformNormalTranspose(in fix3 v, in fix4x4 matrix)
    {
        fix3 toReturn;
        TransformNormalTranspose(in v, in matrix, out toReturn);
        return toReturn;
    }


    /// <summary>
    /// Transposes the matrix.
    /// </summary>
    /// <param name="m">FixMatrix to transpose.</param>
    /// <param name="transposed">FixMatrix to transpose.</param>
    public static void Transpose(in fix4x4 m, out fix4x4 transposed)
    {
        fix intermediate = m.M21;
        transposed.M21 = m.M12;
        transposed.M12 = intermediate;

        intermediate = m.M31;
        transposed.M31 = m.M13;
        transposed.M13 = intermediate;

        intermediate = m.M41;
        transposed.M41 = m.M14;
        transposed.M14 = intermediate;

        intermediate = m.M32;
        transposed.M32 = m.M23;
        transposed.M23 = intermediate;

        intermediate = m.M42;
        transposed.M42 = m.M24;
        transposed.M24 = intermediate;

        intermediate = m.M43;
        transposed.M43 = m.M34;
        transposed.M34 = intermediate;

        transposed.M11 = m.M11;
        transposed.M22 = m.M22;
        transposed.M33 = m.M33;
        transposed.M44 = m.M44;
    }

    /// <summary>
    /// Inverts the matrix.
    /// </summary>
    /// <param name="m">FixMatrix to invert.</param>
    /// <param name="inverted">Inverted version of the matrix.</param>
    public static void Invert(in fix4x4 m, out fix4x4 inverted)
    {
        fix4x8.Invert(in m, out inverted);
    }

    /// <summary>
    /// Inverts the matrix.
    /// </summary>
    /// <param name="m">FixMatrix to invert.</param>
    /// <returns>Inverted version of the matrix.</returns>
    public static fix4x4 Invert(in fix4x4 m)
    {
        fix4x4 inverted;
        Invert(in m, out inverted);
        return inverted;
    }

    /// <summary>
    /// Inverts the matrix using a process that only works for rigid transforms.
    /// </summary>
    /// <param name="m">FixMatrix to invert.</param>
    /// <param name="inverted">Inverted version of the matrix.</param>
    public static void InvertRigid(in fix4x4 m, out fix4x4 inverted)
    {
        //Invert (transpose) the upper left 3x3 rotation.
        fix intermediate = m.M21;
        inverted.M21 = m.M12;
        inverted.M12 = intermediate;

        intermediate = m.M31;
        inverted.M31 = m.M13;
        inverted.M13 = intermediate;

        intermediate = m.M32;
        inverted.M32 = m.M23;
        inverted.M23 = intermediate;

        inverted.M11 = m.M11;
        inverted.M22 = m.M22;
        inverted.M33 = m.M33;

        //Translation component
        var vX = m.M14;
        var vY = m.M24;
        var vZ = m.M34;
        inverted.M14 = -(vX * inverted.M11 + vY * inverted.M12 + vZ * inverted.M13);
        inverted.M24 = -(vX * inverted.M21 + vY * inverted.M22 + vZ * inverted.M23);
        inverted.M34 = -(vX * inverted.M31 + vY * inverted.M32 + vZ * inverted.M33);

        //Last chunk.
        inverted.M41 = F64.C0;
        inverted.M42 = F64.C0;
        inverted.M43 = F64.C0;
        inverted.M44 = F64.C1;
    }

    /// <summary>
    /// Inverts the matrix using a process that only works for rigid transforms.
    /// </summary>
    /// <param name="m">FixMatrix to invert.</param>
    /// <returns>Inverted version of the matrix.</returns>
    public static fix4x4 InvertRigid(fix4x4 m)
    {
        fix4x4 inverse;
        InvertRigid(in m, out inverse);
        return inverse;
    }

    /// <summary>
    /// Gets the 4x4 identity matrix.
    /// </summary>
    public static fix4x4 Identity
    {
        get
        {
            fix4x4 toReturn;
            toReturn.M11 = F64.C1;
            toReturn.M21 = F64.C0;
            toReturn.M31 = F64.C0;
            toReturn.M41 = F64.C0;

            toReturn.M12 = F64.C0;
            toReturn.M22 = F64.C1;
            toReturn.M32 = F64.C0;
            toReturn.M42 = F64.C0;

            toReturn.M13 = F64.C0;
            toReturn.M23 = F64.C0;
            toReturn.M33 = F64.C1;
            toReturn.M43 = F64.C0;

            toReturn.M14 = F64.C0;
            toReturn.M24 = F64.C0;
            toReturn.M34 = F64.C0;
            toReturn.M44 = F64.C1;
            return toReturn;
        }
    }

    /// <summary>
    /// Creates a right handed orthographic projection.
    /// </summary>
    /// <param name="left">Leftmost coordinate of the projected area.</param>
    /// <param name="right">Rightmost coordinate of the projected area.</param>
    /// <param name="bottom">Bottom coordinate of the projected area.</param>
    /// <param name="top">Top coordinate of the projected area.</param>
    /// <param name="zNear">Near plane of the projection.</param>
    /// <param name="zFar">Far plane of the projection.</param>
    /// <param name="projection">The resulting orthographic projection matrix.</param>
    public static void CreateOrthographicRH(in fix left, in fix right, in fix bottom, in fix top, in fix zNear, in fix zFar, out fix4x4 projection)
    {
        fix width = right - left;
        fix height = top - bottom;
        fix depth = zFar - zNear;
        projection.M11 = F64.C2 / width;
        projection.M21 = F64.C0;
        projection.M31 = F64.C0;
        projection.M41 = F64.C0;

        projection.M12 = F64.C0;
        projection.M22 = F64.C2 / height;
        projection.M32 = F64.C0;
        projection.M42 = F64.C0;

        projection.M13 = F64.C0;
        projection.M23 = F64.C0;
        projection.M33 = new fix(-1) / depth;
        projection.M43 = F64.C0;

        projection.M14 = (left + right) / -width;
        projection.M24 = (top + bottom) / -height;
        projection.M34 = zNear / -depth;
        projection.M44 = F64.C1;

    }

    /// <summary>
    /// Creates a right-handed perspective matrix.
    /// </summary>
    /// <param name="fieldOfView">Field of view of the perspective in radians.</param>
    /// <param name="aspectRatio">Width of the viewport over the height of the viewport.</param>
    /// <param name="nearClip">Near clip plane of the perspective.</param>
    /// <param name="farClip">Far clip plane of the perspective.</param>
    /// <param name="perspective">Resulting perspective matrix.</param>
    public static void CreatePerspectiveFieldOfViewRH(in fix fieldOfView, in fix aspectRatio, in fix nearClip, in fix farClip, out fix4x4 perspective)
    {
        fix h = F64.C1 / fix.Tan(fieldOfView / F64.C2);
        fix w = h / aspectRatio;
        perspective.M11 = w;
        perspective.M21 = F64.C0;
        perspective.M31 = F64.C0;
        perspective.M41 = F64.C0;

        perspective.M12 = F64.C0;
        perspective.M22 = h;
        perspective.M32 = F64.C0;
        perspective.M42 = F64.C0;

        perspective.M13 = F64.C0;
        perspective.M23 = F64.C0;
        perspective.M33 = farClip / (nearClip - farClip);
        perspective.M43 = -1;

        perspective.M14 = F64.C0;
        perspective.M24 = F64.C0;
        perspective.M44 = F64.C0;
        perspective.M34 = nearClip * perspective.M33;

    }

    /// <summary>
    /// Creates a right-handed perspective matrix.
    /// </summary>
    /// <param name="fieldOfView">Field of view of the perspective in radians.</param>
    /// <param name="aspectRatio">Width of the viewport over the height of the viewport.</param>
    /// <param name="nearClip">Near clip plane of the perspective.</param>
    /// <param name="farClip">Far clip plane of the perspective.</param>
    /// <returns>Resulting perspective matrix.</returns>
    public static fix4x4 CreatePerspectiveFieldOfViewRH(in fix fieldOfView, in fix aspectRatio, in fix nearClip, in fix farClip)
    {
        fix4x4 perspective;
        CreatePerspectiveFieldOfViewRH(fieldOfView, aspectRatio, nearClip, farClip, out perspective);
        return perspective;
    }

    /// <summary>
    /// Creates a view matrix pointing from a position to a target with the given up vector.
    /// </summary>
    /// <param name="position">Position of the camera.</param>
    /// <param name="target">Target of the camera.</param>
    /// <param name="upVector">Up vector of the camera.</param>
    /// <param name="viewMatrix">Look at matrix.</param>
    public static void CreateLookAtRH(in fix3 position, in fix3 target, in fix3 upVector, out fix4x4 viewMatrix)
    {
        fix3 forward;
        fix3.Subtract(in target, in position, out forward);
        CreateViewRH(in position, in forward, in upVector, out viewMatrix);
    }

    /// <summary>
    /// Creates a view matrix pointing from a position to a target with the given up vector.
    /// </summary>
    /// <param name="position">Position of the camera.</param>
    /// <param name="target">Target of the camera.</param>
    /// <param name="upVector">Up vector of the camera.</param>
    /// <returns>Look at matrix.</returns>
    public static fix4x4 CreateLookAtRH(in fix3 position, in fix3 target, in fix3 upVector)
    {
        fix4x4 lookAt;
        fix3 forward;
        fix3.Subtract(in target, in position, out forward);
        CreateViewRH(in position, in forward, in upVector, out lookAt);
        return lookAt;
    }


    /// <summary>
    /// Creates a view matrix pointing in a direction with a given up vector.
    /// </summary>
    /// <param name="position">Position of the camera.</param>
    /// <param name="forward">Forward direction of the camera.</param>
    /// <param name="upVector">Up vector of the camera.</param>
    /// <param name="viewMatrix">Look at matrix.</param>
    public static void CreateViewRH(in fix3 position, in fix3 forward, in fix3 upVector, out fix4x4 viewMatrix)
    {
        fix3 z;
        fix length = forward.length;
        fix3.Divide(in forward, -length, out z);
        fix3 x;
        fix3.Cross(in upVector, in z, out x);
        x.Normalize();
        fix3 y;
        fix3.Cross(in z, in x, out y);

        viewMatrix.M11 = x.x;
        viewMatrix.M21 = y.x;
        viewMatrix.M31 = z.x;
        viewMatrix.M41 = F64.C0;
        viewMatrix.M12 = x.y;
        viewMatrix.M22 = y.y;
        viewMatrix.M32 = z.y;
        viewMatrix.M42 = F64.C0;
        viewMatrix.M13 = x.z;
        viewMatrix.M23 = y.z;
        viewMatrix.M33 = z.z;
        viewMatrix.M43 = F64.C0;
        fix3.Dot(in x, in position, out viewMatrix.M14);
        fix3.Dot(in y, in position, out viewMatrix.M24);
        fix3.Dot(in z, in position, out viewMatrix.M34);
        viewMatrix.M14 = -viewMatrix.M14;
        viewMatrix.M24 = -viewMatrix.M24;
        viewMatrix.M34 = -viewMatrix.M34;
        viewMatrix.M44 = F64.C1;

    }

    /// <summary>
    /// Creates a view matrix pointing looking in a direction with a given up vector.
    /// </summary>
    /// <param name="position">Position of the camera.</param>
    /// <param name="forward">Forward direction of the camera.</param>
    /// <param name="upVector">Up vector of the camera.</param>
    /// <returns>Look at matrix.</returns>
    public static fix4x4 CreateViewRH(in fix3 position, in fix3 forward, in fix3 upVector)
    {
        fix4x4 lookat;
        CreateViewRH(in position, in forward, in upVector, out lookat);
        return lookat;
    }

    /// <summary>
    /// Creates a transform matrix with the given positon, rotation and scale
    /// </summary>
    public static fix4x4 CreateTRS(in fix3 position, in fixQuaternion rotation, in fix3 scale)
    {
        fix4x4 result;
        CreateTRS(position, rotation, scale, out result);
        return result;
    }


    /// <summary>
    /// Creates a transform matrix with the given positon, rotation and scale
    /// </summary>
    public static void CreateTRS(in fix3 position, in fixQuaternion rotation, in fix3 scale, out fix4x4 worldMatrix)
    {
        fix4x4 mat;

        // Scale
        CreateScale(scale, out worldMatrix);

        // Rotation
        CreateFromQuaternion(rotation, out mat);
        worldMatrix *= mat;

        // Translation
        CreateTranslation(in position, out mat);
        worldMatrix *= mat;
    }


    /// <summary>
    /// Creates a world matrix pointing from a position to a target with the given up vector.
    /// </summary>
    /// <param name="position">Position of the transform.</param>
    /// <param name="forward">Forward direction of the transformation.</param>
    /// <param name="upVector">Up vector which is crossed against the forward vector to compute the transform's basis.</param>
    /// <param name="worldMatrix">World matrix.</param>
    public static void CreateWorldRH(in fix3 position, in fix3 forward, in fix3 upVector, out fix4x4 worldMatrix)
    {
        fix3 z;
        fix length = forward.length;
        fix3.Divide(in forward, -length, out z);
        fix3 x;
        fix3.Cross(in upVector, in z, out x);
        x.Normalize();
        fix3 y;
        fix3.Cross(in z, in x, out y);

        worldMatrix.M11 = x.x;
        worldMatrix.M21 = x.y;
        worldMatrix.M31 = x.z;
        worldMatrix.M41 = F64.C0;
        worldMatrix.M12 = y.x;
        worldMatrix.M22 = y.y;
        worldMatrix.M32 = y.z;
        worldMatrix.M42 = F64.C0;
        worldMatrix.M13 = z.x;
        worldMatrix.M23 = z.y;
        worldMatrix.M33 = z.z;
        worldMatrix.M43 = F64.C0;

        worldMatrix.M14 = position.x;
        worldMatrix.M24 = position.y;
        worldMatrix.M34 = position.z;
        worldMatrix.M44 = F64.C1;

    }


    /// <summary>
    /// Creates a world matrix pointing from a position to a target with the given up vector.
    /// </summary>
    /// <param name="position">Position of the transform.</param>
    /// <param name="forward">Forward direction of the transformation.</param>
    /// <param name="upVector">Up vector which is crossed against the forward vector to compute the transform's basis.</param>
    /// <returns>World matrix.</returns>
    public static fix4x4 CreateWorldRH(in fix3 position, in fix3 forward, in fix3 upVector)
    {
        fix4x4 lookat;
        CreateWorldRH(in position, in forward, in upVector, out lookat);
        return lookat;
    }



    /// <summary>
    /// Creates a matrix representing a translation.
    /// </summary>
    /// <param name="translation">Translation to be represented by the matrix.</param>
    /// <param name="translationMatrix">FixMatrix representing the given translation.</param>
    public static void CreateTranslation(in fix3 translation, out fix4x4 translationMatrix)
    {
        translationMatrix = new fix4x4
        {
            M11 = F64.C1,
            M22 = F64.C1,
            M33 = F64.C1,
            M44 = F64.C1,
            M14 = translation.x,
            M24 = translation.y,
            M34 = translation.z
        };
    }

    /// <summary>
    /// Creates a matrix representing a translation.
    /// </summary>
    /// <param name="translation">Translation to be represented by the matrix.</param>
    /// <returns>FixMatrix representing the given translation.</returns>
    public static fix4x4 CreateTranslation(in fix3 translation)
    {
        fix4x4 translationMatrix;
        CreateTranslation(in translation, out translationMatrix);
        return translationMatrix;
    }

    /// <summary>
    /// Creates a matrix representing the given axis aligned scale.
    /// </summary>
    /// <param name="scale">Scale to be represented by the matrix.</param>
    /// <param name="scaleMatrix">FixMatrix representing the given scale.</param>
    public static void CreateScale(in fix3 scale, out fix4x4 scaleMatrix)
    {
        scaleMatrix = new fix4x4
        {
            M11 = scale.x,
            M22 = scale.y,
            M33 = scale.z,
            M44 = F64.C1
        };
    }

    /// <summary>
    /// Creates a matrix representing the given axis aligned scale.
    /// </summary>
    /// <param name="scale">Scale to be represented by the matrix.</param>
    /// <returns>FixMatrix representing the given scale.</returns>
    public static fix4x4 CreateScale(in fix3 scale)
    {
        fix4x4 scaleMatrix;
        CreateScale(in scale, out scaleMatrix);
        return scaleMatrix;
    }

    /// <summary>
    /// Creates a matrix representing the given axis aligned scale.
    /// </summary>
    /// <param name="x">Scale along the x axis.</param>
    /// <param name="y">Scale along the y axis.</param>
    /// <param name="z">Scale along the z axis.</param>
    /// <param name="scaleMatrix">FixMatrix representing the given scale.</param>
    public static void CreateScale(in fix x, in fix y, in fix z, out fix4x4 scaleMatrix)
    {
        scaleMatrix = new fix4x4
        {
            M11 = x,
            M22 = y,
            M33 = z,
            M44 = F64.C1
        };
    }

    /// <summary>
    /// Creates a matrix representing the given axis aligned scale.
    /// </summary>
    /// <param name="x">Scale along the x axis.</param>
    /// <param name="y">Scale along the y axis.</param>
    /// <param name="z">Scale along the z axis.</param>
    /// <returns>FixMatrix representing the given scale.</returns>
    public static fix4x4 CreateScale(in fix x, in fix y, in fix z)
    {
        fix4x4 scaleMatrix;
        CreateScale(x, y, z, out scaleMatrix);
        return scaleMatrix;
    }

    /// <summary>
    /// Creates a string representation of the matrix.
    /// </summary>
    /// <returns>A string representation of the matrix.</returns>
    public override string ToString()
    {
        return "{" + M11 + ", " + M21 + ", " + M31 + ", " + M41 + "} " +
               "{" + M12 + ", " + M22 + ", " + M32 + ", " + M42 + "} " +
               "{" + M13 + ", " + M23 + ", " + M33 + ", " + M43 + "} " +
               "{" + M14 + ", " + M24 + ", " + M34 + ", " + M44 + "}";
    }
}
