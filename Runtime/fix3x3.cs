using System;


/// <summary>
/// 3 row, 3 column matrix.
/// </summary>
[Serializable]
public struct fix3x3
{
    /// <summary>
    /// Value at row 1, column 1 of the matrix.
    /// </summary>
    public fix M11;

    /// <summary>
    /// Value at row 1, column 2 of the matrix.
    /// </summary>
    public fix M12;

    /// <summary>
    /// Value at row 1, column 3 of the matrix.
    /// </summary>
    public fix M13;

    /// <summary>
    /// Value at row 2, column 1 of the matrix.
    /// </summary>
    public fix M21;

    /// <summary>
    /// Value at row 2, column 2 of the matrix.
    /// </summary>
    public fix M22;

    /// <summary>
    /// Value at row 2, column 3 of the matrix.
    /// </summary>
    public fix M23;

    /// <summary>
    /// Value at row 3, column 1 of the matrix.
    /// </summary>
    public fix M31;

    /// <summary>
    /// Value at row 3, column 2 of the matrix.
    /// </summary>
    public fix M32;

    /// <summary>
    /// Value at row 3, column 3 of the matrix.
    /// </summary>
    public fix M33;

    /// <summary>
    /// Constructs a new 3 row, 3 column matrix.
    /// </summary>
    /// <param name="m11">Value at row 1, column 1 of the matrix.</param>
    /// <param name="m12">Value at row 1, column 2 of the matrix.</param>
    /// <param name="m13">Value at row 1, column 3 of the matrix.</param>
    /// <param name="m21">Value at row 2, column 1 of the matrix.</param>
    /// <param name="m22">Value at row 2, column 2 of the matrix.</param>
    /// <param name="m23">Value at row 2, column 3 of the matrix.</param>
    /// <param name="m31">Value at row 3, column 1 of the matrix.</param>
    /// <param name="m32">Value at row 3, column 2 of the matrix.</param>
    /// <param name="m33">Value at row 3, column 3 of the matrix.</param>
    public fix3x3(fix m11, fix m12, fix m13, fix m21, fix m22, fix m23, fix m31, fix m32, fix m33)
    {
        M11 = m11;
        M12 = m12;
        M13 = m13;
        M21 = m21;
        M22 = m22;
        M23 = m23;
        M31 = m31;
        M32 = m32;
        M33 = m33;
    }

    /// <summary>
    /// Gets the 3x3 identity matrix.
    /// </summary>
    public static fix3x3 Identity
    {
        get { return new fix3x3(F64.C1, F64.C0, F64.C0, F64.C0, F64.C1, F64.C0, F64.C0, F64.C0, F64.C1); }
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
            vector.x = M31;
            vector.y = M32;
            vector.z = M33;
            return vector;
        }
        set
        {
            M31 = value.x;
            M32 = value.y;
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
            vector.x = -M21;
            vector.y = -M22;
            vector.z = -M23;
            return vector;
        }
        set
        {
            M21 = -value.x;
            M22 = -value.y;
            M23 = -value.z;
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
            vector.x = -M31;
            vector.y = -M32;
            vector.z = -M33;
            return vector;
        }
        set
        {
            M31 = -value.x;
            M32 = -value.y;
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
            vector.y = -M12;
            vector.z = -M13;
            return vector;
        }
        set
        {
            M11 = -value.x;
            M12 = -value.y;
            M13 = -value.z;
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
            vector.y = M12;
            vector.z = M13;
            return vector;
        }
        set
        {
            M11 = value.x;
            M12 = value.y;
            M13 = value.z;
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
            vector.x = M21;
            vector.y = M22;
            vector.z = M23;
            return vector;
        }
        set
        {
            M21 = value.x;
            M22 = value.y;
            M23 = value.z;
        }
    }

    /// <summary>
    /// Adds the two matrices together on a per-element basis.
    /// </summary>
    /// <param name="a">First matrix to add.</param>
    /// <param name="b">Second matrix to add.</param>
    /// <param name="result">Sum of the two matrices.</param>
    public static void Add(in fix3x3 a, in fix3x3 b, out fix3x3 result)
    {
        fix m11 = a.M11 + b.M11;
        fix m12 = a.M12 + b.M12;
        fix m13 = a.M13 + b.M13;

        fix m21 = a.M21 + b.M21;
        fix m22 = a.M22 + b.M22;
        fix m23 = a.M23 + b.M23;

        fix m31 = a.M31 + b.M31;
        fix m32 = a.M32 + b.M32;
        fix m33 = a.M33 + b.M33;

        result.M11 = m11;
        result.M12 = m12;
        result.M13 = m13;

        result.M21 = m21;
        result.M22 = m22;
        result.M23 = m23;

        result.M31 = m31;
        result.M32 = m32;
        result.M33 = m33;
    }

    /// <summary>
    /// Adds the two matrices together on a per-element basis.
    /// </summary>
    /// <param name="a">First matrix to add.</param>
    /// <param name="b">Second matrix to add.</param>
    /// <param name="result">Sum of the two matrices.</param>
    public static void Add(in fix4x4 a, in fix3x3 b, out fix3x3 result)
    {
        fix m11 = a.M11 + b.M11;
        fix m12 = a.M21 + b.M12;
        fix m13 = a.M31 + b.M13;

        fix m21 = a.M12 + b.M21;
        fix m22 = a.M22 + b.M22;
        fix m23 = a.M32 + b.M23;

        fix m31 = a.M13 + b.M31;
        fix m32 = a.M23 + b.M32;
        fix m33 = a.M33 + b.M33;

        result.M11 = m11;
        result.M12 = m12;
        result.M13 = m13;

        result.M21 = m21;
        result.M22 = m22;
        result.M23 = m23;

        result.M31 = m31;
        result.M32 = m32;
        result.M33 = m33;
    }

    /// <summary>
    /// Adds the two matrices together on a per-element basis.
    /// </summary>
    /// <param name="a">First matrix to add.</param>
    /// <param name="b">Second matrix to add.</param>
    /// <param name="result">Sum of the two matrices.</param>
    public static void Add(in fix3x3 a, in fix4x4 b, out fix3x3 result)
    {
        fix m11 = a.M11 + b.M11;
        fix m12 = a.M12 + b.M21;
        fix m13 = a.M13 + b.M31;

        fix m21 = a.M21 + b.M12;
        fix m22 = a.M22 + b.M22;
        fix m23 = a.M23 + b.M32;

        fix m31 = a.M31 + b.M13;
        fix m32 = a.M32 + b.M23;
        fix m33 = a.M33 + b.M33;

        result.M11 = m11;
        result.M12 = m12;
        result.M13 = m13;

        result.M21 = m21;
        result.M22 = m22;
        result.M23 = m23;

        result.M31 = m31;
        result.M32 = m32;
        result.M33 = m33;
    }

    /// <summary>
    /// Adds the two matrices together on a per-element basis.
    /// </summary>
    /// <param name="a">First matrix to add.</param>
    /// <param name="b">Second matrix to add.</param>
    /// <param name="result">Sum of the two matrices.</param>
    public static void Add(in fix4x4 a, in fix4x4 b, out fix3x3 result)
    {
        fix m11 = a.M11 + b.M11;
        fix m12 = a.M21 + b.M21;
        fix m13 = a.M31 + b.M31;

        fix m21 = a.M12 + b.M12;
        fix m22 = a.M22 + b.M22;
        fix m23 = a.M32 + b.M32;

        fix m31 = a.M13 + b.M13;
        fix m32 = a.M23 + b.M23;
        fix m33 = a.M33 + b.M33;

        result.M11 = m11;
        result.M12 = m12;
        result.M13 = m13;

        result.M21 = m21;
        result.M22 = m22;
        result.M23 = m23;

        result.M31 = m31;
        result.M32 = m32;
        result.M33 = m33;
    }

    /// <summary>
    /// Creates a skew symmetric matrix M from vector A such that M * B for some other vector B is equivalent to the cross product of A and B.
    /// </summary>
    /// <param name="v">Vector to base the matrix on.</param>
    /// <param name="result">Skew-symmetric matrix result.</param>
    public static void CreateCrossProduct(in fix3 v, out fix3x3 result)
    {
        result.M11 = F64.C0;
        result.M12 = -v.z;
        result.M13 = v.y;
        result.M21 = v.z;
        result.M22 = F64.C0;
        result.M23 = -v.x;
        result.M31 = -v.y;
        result.M32 = v.x;
        result.M33 = F64.C0;
    }

    /// <summary>
    /// Creates a 3x3 matrix from an XNA 4x4 matrix.
    /// </summary>
    /// <param name="matrix4X4">FixMatrix to extract a 3x3 matrix from.</param>
    /// <param name="matrix3X3">Upper 3x3 matrix extracted from the XNA matrix.</param>
    public static void CreateFromMatrix(in fix4x4 matrix4X4, out fix3x3 matrix3X3)
    {
        matrix3X3.M11 = matrix4X4.M11;
        matrix3X3.M12 = matrix4X4.M21;
        matrix3X3.M13 = matrix4X4.M31;

        matrix3X3.M21 = matrix4X4.M12;
        matrix3X3.M22 = matrix4X4.M22;
        matrix3X3.M23 = matrix4X4.M32;

        matrix3X3.M31 = matrix4X4.M13;
        matrix3X3.M32 = matrix4X4.M23;
        matrix3X3.M33 = matrix4X4.M33;
    }
    /// <summary>
    /// Creates a 3x3 matrix from an XNA 4x4 matrix.
    /// </summary>
    /// <param name="matrix4X4">FixMatrix to extract a 3x3 matrix from.</param>
    /// <returns>Upper 3x3 matrix extracted from the XNA matrix.</returns>
    public static fix3x3 CreateFromMatrix(fix4x4 matrix4X4)
    {
        fix3x3 matrix3X3;
        matrix3X3.M11 = matrix4X4.M11;
        matrix3X3.M12 = matrix4X4.M21;
        matrix3X3.M13 = matrix4X4.M31;

        matrix3X3.M21 = matrix4X4.M12;
        matrix3X3.M22 = matrix4X4.M22;
        matrix3X3.M23 = matrix4X4.M32;

        matrix3X3.M31 = matrix4X4.M13;
        matrix3X3.M32 = matrix4X4.M23;
        matrix3X3.M33 = matrix4X4.M33;
        return matrix3X3;
    }

    /// <summary>
    /// Constructs a uniform scaling matrix.
    /// </summary>
    /// <param name="scale">Value to use in the diagonal.</param>
    /// <param name="matrix">Scaling matrix.</param>
    public static void CreateScale(fix scale, out fix3x3 matrix)
    {
        matrix = new fix3x3 { M11 = scale, M22 = scale, M33 = scale };
    }

    /// <summary>
    /// Constructs a uniform scaling matrix.
    /// </summary>
    /// <param name="scale">Value to use in the diagonal.</param>
    /// <returns>Scaling matrix.</returns>
    public static fix3x3 CreateScale(fix scale)
    {
        var matrix = new fix3x3 { M11 = scale, M22 = scale, M33 = scale };
        return matrix;
    }

    /// <summary>
    /// Constructs a non-uniform scaling matrix.
    /// </summary>
    /// <param name="scale">Values defining the axis scales.</param>
    /// <param name="matrix">Scaling matrix.</param>
    public static void CreateScale(in fix3 scale, out fix3x3 matrix)
    {
        matrix = new fix3x3 { M11 = scale.x, M22 = scale.y, M33 = scale.z };
    }

    /// <summary>
    /// Constructs a non-uniform scaling matrix.
    /// </summary>
    /// <param name="scale">Values defining the axis scales.</param>
    /// <returns>Scaling matrix.</returns>
    public static fix3x3 CreateScale(in fix3 scale)
    {
        var matrix = new fix3x3 { M11 = scale.x, M22 = scale.y, M33 = scale.z };
        return matrix;
    }


    /// <summary>
    /// Constructs a non-uniform scaling matrix.
    /// </summary>
    /// <param name="x">Scaling along the x axis.</param>
    /// <param name="y">Scaling along the y axis.</param>
    /// <param name="z">Scaling along the z axis.</param>
    /// <param name="matrix">Scaling matrix.</param>
    public static void CreateScale(fix x, fix y, fix z, out fix3x3 matrix)
    {
        matrix = new fix3x3 { M11 = x, M22 = y, M33 = z };
    }

    /// <summary>
    /// Constructs a non-uniform scaling matrix.
    /// </summary>
    /// <param name="x">Scaling along the x axis.</param>
    /// <param name="y">Scaling along the y axis.</param>
    /// <param name="z">Scaling along the z axis.</param>
    /// <returns>Scaling matrix.</returns>
    public static fix3x3 CreateScale(fix x, fix y, fix z)
    {
        var matrix = new fix3x3 { M11 = x, M22 = y, M33 = z };
        return matrix;
    }

    /// <summary>
    /// Inverts the given matix.
    /// </summary>
    /// <param name="matrix">FixMatrix to be inverted.</param>
    /// <param name="result">Inverted matrix.</param>
    /// <returns>false if matrix is singular, true otherwise</returns>
    public static bool Invert(in fix3x3 matrix, out fix3x3 result)
    {
        return fix3x6.Invert(in matrix, out result);
    }

    /// <summary>
    /// Inverts the given matix.
    /// </summary>
    /// <param name="matrix">FixMatrix to be inverted.</param>
    /// <returns>Inverted matrix.</returns>
    public static fix3x3 Invert(fix3x3 matrix)
    {
        fix3x3 toReturn;
        Invert(in matrix, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Inverts the largest nonsingular submatrix in the matrix, excluding 2x2's that involve M13 or M31, and excluding 1x1's that include nondiagonal elements.
    /// </summary>
    /// <param name="matrix">FixMatrix to be inverted.</param>
    /// <param name="result">Inverted matrix.</param>
    public static void AdaptiveInvert(in fix3x3 matrix, out fix3x3 result)
    {
        // Perform full Gauss-invert and return if successful
        if (Invert(in matrix, out result))
            return;

        int submatrix;
        fix determinantInverse = F64.C1 / matrix.AdaptiveDeterminant(out submatrix);
        fix m11, m12, m13, m21, m22, m23, m31, m32, m33;
        switch (submatrix)
        {
            case 1: //Upper left matrix, m11, m12, m21, m22.
                m11 = matrix.M22 * determinantInverse;
                m12 = -matrix.M12 * determinantInverse;
                m13 = F64.C0;

                m21 = -matrix.M21 * determinantInverse;
                m22 = matrix.M11 * determinantInverse;
                m23 = F64.C0;

                m31 = F64.C0;
                m32 = F64.C0;
                m33 = F64.C0;
                break;
            case 2: //Lower right matrix, m22, m23, m32, m33.
                m11 = F64.C0;
                m12 = F64.C0;
                m13 = F64.C0;

                m21 = F64.C0;
                m22 = matrix.M33 * determinantInverse;
                m23 = -matrix.M23 * determinantInverse;

                m31 = F64.C0;
                m32 = -matrix.M32 * determinantInverse;
                m33 = matrix.M22 * determinantInverse;
                break;
            case 3: //Corners, m11, m31, m13, m33.
                m11 = matrix.M33 * determinantInverse;
                m12 = F64.C0;
                m13 = -matrix.M13 * determinantInverse;

                m21 = F64.C0;
                m22 = F64.C0;
                m23 = F64.C0;

                m31 = -matrix.M31 * determinantInverse;
                m32 = F64.C0;
                m33 = matrix.M11 * determinantInverse;
                break;
            case 4: //M11
                m11 = F64.C1 / matrix.M11;
                m12 = F64.C0;
                m13 = F64.C0;

                m21 = F64.C0;
                m22 = F64.C0;
                m23 = F64.C0;

                m31 = F64.C0;
                m32 = F64.C0;
                m33 = F64.C0;
                break;
            case 5: //M22
                m11 = F64.C0;
                m12 = F64.C0;
                m13 = F64.C0;

                m21 = F64.C0;
                m22 = F64.C1 / matrix.M22;
                m23 = F64.C0;

                m31 = F64.C0;
                m32 = F64.C0;
                m33 = F64.C0;
                break;
            case 6: //M33
                m11 = F64.C0;
                m12 = F64.C0;
                m13 = F64.C0;

                m21 = F64.C0;
                m22 = F64.C0;
                m23 = F64.C0;

                m31 = F64.C0;
                m32 = F64.C0;
                m33 = F64.C1 / matrix.M33;
                break;
            default: //Completely singular.
                m11 = F64.C0; m12 = F64.C0; m13 = F64.C0; m21 = F64.C0; m22 = F64.C0; m23 = F64.C0; m31 = F64.C0; m32 = F64.C0; m33 = F64.C0;
                break;
        }

        result.M11 = m11;
        result.M12 = m12;
        result.M13 = m13;

        result.M21 = m21;
        result.M22 = m22;
        result.M23 = m23;

        result.M31 = m31;
        result.M32 = m32;
        result.M33 = m33;
    }

    /// <summary>
    /// <para>Computes the adjugate transpose of a matrix.</para>
    /// <para>The adjugate transpose A of matrix M is: det(M) * transpose(invert(M))</para>
    /// <para>This is necessary when transforming normals (bivectors) with general linear transformations.</para>
    /// </summary>
    /// <param name="matrix">FixMatrix to compute the adjugate transpose of.</param>
    /// <param name="result">Adjugate transpose of the input matrix.</param>
    public static void AdjugateTranspose(in fix3x3 matrix, out fix3x3 result)
    {
        //Despite the relative obscurity of the operation, this is a fairly straightforward operation which is actually faster than a true invert (by virtue of cancellation).
        //Conceptually, this is implemented as transpose(det(M) * invert(M)), but that's perfectly acceptable:
        //1) transpose(invert(M)) == invert(transpose(M)), and
        //2) det(M) == det(transpose(M))
        //This organization makes it clearer that the invert's usual division by determinant drops out.

        fix m11 = (matrix.M22 * matrix.M33 - matrix.M23 * matrix.M32);
        fix m12 = (matrix.M13 * matrix.M32 - matrix.M33 * matrix.M12);
        fix m13 = (matrix.M12 * matrix.M23 - matrix.M22 * matrix.M13);

        fix m21 = (matrix.M23 * matrix.M31 - matrix.M21 * matrix.M33);
        fix m22 = (matrix.M11 * matrix.M33 - matrix.M13 * matrix.M31);
        fix m23 = (matrix.M13 * matrix.M21 - matrix.M11 * matrix.M23);

        fix m31 = (matrix.M21 * matrix.M32 - matrix.M22 * matrix.M31);
        fix m32 = (matrix.M12 * matrix.M31 - matrix.M11 * matrix.M32);
        fix m33 = (matrix.M11 * matrix.M22 - matrix.M12 * matrix.M21);

        //Note transposition.
        result.M11 = m11;
        result.M12 = m21;
        result.M13 = m31;

        result.M21 = m12;
        result.M22 = m22;
        result.M23 = m32;

        result.M31 = m13;
        result.M32 = m23;
        result.M33 = m33;
    }

    /// <summary>
    /// <para>Computes the adjugate transpose of a matrix.</para>
    /// <para>The adjugate transpose A of matrix M is: det(M) * transpose(invert(M))</para>
    /// <para>This is necessary when transforming normals (bivectors) with general linear transformations.</para>
    /// </summary>
    /// <param name="matrix">FixMatrix to compute the adjugate transpose of.</param>
    /// <returns>Adjugate transpose of the input matrix.</returns>
    public static fix3x3 AdjugateTranspose(fix3x3 matrix)
    {
        fix3x3 toReturn;
        AdjugateTranspose(in matrix, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Multiplies the two matrices.
    /// </summary>
    /// <param name="a">First matrix to multiply.</param>
    /// <param name="b">Second matrix to multiply.</param>
    /// <returns>Product of the multiplication.</returns>
    public static fix3x3 operator *(fix3x3 a, fix3x3 b)
    {
        fix3x3 result;
        fix3x3.Multiply(in a, in b, out result);
        return result;
    }

    /// <summary>
    /// Scales all components of the matrix by the given value.
    /// </summary>
    /// <param name="m">First matrix to multiply.</param>
    /// <param name="f">Scaling value to apply to all components of the matrix.</param>
    /// <returns>Product of the multiplication.</returns>
    public static fix3x3 operator *(fix3x3 m, fix f)
    {
        fix3x3 result;
        Multiply(in m, f, out result);
        return result;
    }

    /// <summary>
    /// Scales all components of the matrix by the given value.
    /// </summary>
    /// <param name="m">First matrix to multiply.</param>
    /// <param name="f">Scaling value to apply to all components of the matrix.</param>
    /// <returns>Product of the multiplication.</returns>
    public static fix3x3 operator *(fix f, fix3x3 m)
    {
        fix3x3 result;
        Multiply(in m, f, out result);
        return result;
    }

    /// <summary>
    /// Multiplies the two matrices.
    /// </summary>
    /// <param name="a">First matrix to multiply.</param>
    /// <param name="b">Second matrix to multiply.</param>
    /// <param name="result">Product of the multiplication.</param>
    public static void Multiply(in fix3x3 a, in fix3x3 b, out fix3x3 result)
    {
        fix resultM11 = a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31;
        fix resultM12 = a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32;
        fix resultM13 = a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33;

        fix resultM21 = a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31;
        fix resultM22 = a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32;
        fix resultM23 = a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33;

        fix resultM31 = a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31;
        fix resultM32 = a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32;
        fix resultM33 = a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33;

        result.M11 = resultM11;
        result.M12 = resultM12;
        result.M13 = resultM13;

        result.M21 = resultM21;
        result.M22 = resultM22;
        result.M23 = resultM23;

        result.M31 = resultM31;
        result.M32 = resultM32;
        result.M33 = resultM33;
    }

    /// <summary>
    /// Multiplies the two matrices.
    /// </summary>
    /// <param name="a">First matrix to multiply.</param>
    /// <param name="b">Second matrix to multiply.</param>
    /// <param name="result">Product of the multiplication.</param>
    public static void Multiply(in fix3x3 a, in fix4x4 b, out fix3x3 result)
    {
        fix resultM11 = a.M11 * b.M11 + a.M12 * b.M12 + a.M13 * b.M13;
        fix resultM12 = a.M11 * b.M21 + a.M12 * b.M22 + a.M13 * b.M23;
        fix resultM13 = a.M11 * b.M31 + a.M12 * b.M32 + a.M13 * b.M33;

        fix resultM21 = a.M21 * b.M11 + a.M22 * b.M12 + a.M23 * b.M13;
        fix resultM22 = a.M21 * b.M21 + a.M22 * b.M22 + a.M23 * b.M23;
        fix resultM23 = a.M21 * b.M31 + a.M22 * b.M32 + a.M23 * b.M33;

        fix resultM31 = a.M31 * b.M11 + a.M32 * b.M12 + a.M33 * b.M13;
        fix resultM32 = a.M31 * b.M21 + a.M32 * b.M22 + a.M33 * b.M23;
        fix resultM33 = a.M31 * b.M31 + a.M32 * b.M32 + a.M33 * b.M33;

        result.M11 = resultM11;
        result.M12 = resultM12;
        result.M13 = resultM13;

        result.M21 = resultM21;
        result.M22 = resultM22;
        result.M23 = resultM23;

        result.M31 = resultM31;
        result.M32 = resultM32;
        result.M33 = resultM33;
    }

    /// <summary>
    /// Multiplies the two matrices.
    /// </summary>
    /// <param name="a">First matrix to multiply.</param>
    /// <param name="b">Second matrix to multiply.</param>
    /// <param name="result">Product of the multiplication.</param>
    public static void Multiply(in fix4x4 a, in fix3x3 b, out fix3x3 result)
    {
        fix resultM11 = a.M11 * b.M11 + a.M21 * b.M21 + a.M31 * b.M31;
        fix resultM12 = a.M11 * b.M12 + a.M21 * b.M22 + a.M31 * b.M32;
        fix resultM13 = a.M11 * b.M13 + a.M21 * b.M23 + a.M31 * b.M33;

        fix resultM21 = a.M12 * b.M11 + a.M22 * b.M21 + a.M32 * b.M31;
        fix resultM22 = a.M12 * b.M12 + a.M22 * b.M22 + a.M32 * b.M32;
        fix resultM23 = a.M12 * b.M13 + a.M22 * b.M23 + a.M32 * b.M33;

        fix resultM31 = a.M13 * b.M11 + a.M23 * b.M21 + a.M33 * b.M31;
        fix resultM32 = a.M13 * b.M12 + a.M23 * b.M22 + a.M33 * b.M32;
        fix resultM33 = a.M13 * b.M13 + a.M23 * b.M23 + a.M33 * b.M33;

        result.M11 = resultM11;
        result.M12 = resultM12;
        result.M13 = resultM13;

        result.M21 = resultM21;
        result.M22 = resultM22;
        result.M23 = resultM23;

        result.M31 = resultM31;
        result.M32 = resultM32;
        result.M33 = resultM33;
    }


    /// <summary>
    /// Multiplies a transposed matrix with another matrix.
    /// </summary>
    /// <param name="matrix">FixMatrix to be multiplied.</param>
    /// <param name="transpose">FixMatrix to be transposed and multiplied.</param>
    /// <param name="result">Product of the multiplication.</param>
    public static void MultiplyTransposed(in fix3x3 transpose, in fix3x3 matrix, out fix3x3 result)
    {
        fix resultM11 = transpose.M11 * matrix.M11 + transpose.M21 * matrix.M21 + transpose.M31 * matrix.M31;
        fix resultM12 = transpose.M11 * matrix.M12 + transpose.M21 * matrix.M22 + transpose.M31 * matrix.M32;
        fix resultM13 = transpose.M11 * matrix.M13 + transpose.M21 * matrix.M23 + transpose.M31 * matrix.M33;

        fix resultM21 = transpose.M12 * matrix.M11 + transpose.M22 * matrix.M21 + transpose.M32 * matrix.M31;
        fix resultM22 = transpose.M12 * matrix.M12 + transpose.M22 * matrix.M22 + transpose.M32 * matrix.M32;
        fix resultM23 = transpose.M12 * matrix.M13 + transpose.M22 * matrix.M23 + transpose.M32 * matrix.M33;

        fix resultM31 = transpose.M13 * matrix.M11 + transpose.M23 * matrix.M21 + transpose.M33 * matrix.M31;
        fix resultM32 = transpose.M13 * matrix.M12 + transpose.M23 * matrix.M22 + transpose.M33 * matrix.M32;
        fix resultM33 = transpose.M13 * matrix.M13 + transpose.M23 * matrix.M23 + transpose.M33 * matrix.M33;

        result.M11 = resultM11;
        result.M12 = resultM12;
        result.M13 = resultM13;

        result.M21 = resultM21;
        result.M22 = resultM22;
        result.M23 = resultM23;

        result.M31 = resultM31;
        result.M32 = resultM32;
        result.M33 = resultM33;
    }

    /// <summary>
    /// Multiplies a matrix with a transposed matrix.
    /// </summary>
    /// <param name="matrix">FixMatrix to be multiplied.</param>
    /// <param name="transpose">FixMatrix to be transposed and multiplied.</param>
    /// <param name="result">Product of the multiplication.</param>
    public static void MultiplyByTransposed(in fix3x3 matrix, in fix3x3 transpose, out fix3x3 result)
    {
        fix resultM11 = matrix.M11 * transpose.M11 + matrix.M12 * transpose.M12 + matrix.M13 * transpose.M13;
        fix resultM12 = matrix.M11 * transpose.M21 + matrix.M12 * transpose.M22 + matrix.M13 * transpose.M23;
        fix resultM13 = matrix.M11 * transpose.M31 + matrix.M12 * transpose.M32 + matrix.M13 * transpose.M33;

        fix resultM21 = matrix.M21 * transpose.M11 + matrix.M22 * transpose.M12 + matrix.M23 * transpose.M13;
        fix resultM22 = matrix.M21 * transpose.M21 + matrix.M22 * transpose.M22 + matrix.M23 * transpose.M23;
        fix resultM23 = matrix.M21 * transpose.M31 + matrix.M22 * transpose.M32 + matrix.M23 * transpose.M33;

        fix resultM31 = matrix.M31 * transpose.M11 + matrix.M32 * transpose.M12 + matrix.M33 * transpose.M13;
        fix resultM32 = matrix.M31 * transpose.M21 + matrix.M32 * transpose.M22 + matrix.M33 * transpose.M23;
        fix resultM33 = matrix.M31 * transpose.M31 + matrix.M32 * transpose.M32 + matrix.M33 * transpose.M33;

        result.M11 = resultM11;
        result.M12 = resultM12;
        result.M13 = resultM13;

        result.M21 = resultM21;
        result.M22 = resultM22;
        result.M23 = resultM23;

        result.M31 = resultM31;
        result.M32 = resultM32;
        result.M33 = resultM33;
    }

    /// <summary>
    /// Scales all components of the matrix.
    /// </summary>
    /// <param name="matrix">FixMatrix to scale.</param>
    /// <param name="scale">Amount to scale.</param>
    /// <param name="result">Scaled matrix.</param>
    public static void Multiply(in fix3x3 matrix, fix scale, out fix3x3 result)
    {
        result.M11 = matrix.M11 * scale;
        result.M12 = matrix.M12 * scale;
        result.M13 = matrix.M13 * scale;

        result.M21 = matrix.M21 * scale;
        result.M22 = matrix.M22 * scale;
        result.M23 = matrix.M23 * scale;

        result.M31 = matrix.M31 * scale;
        result.M32 = matrix.M32 * scale;
        result.M33 = matrix.M33 * scale;
    }

    /// <summary>
    /// Negates every element in the matrix.
    /// </summary>
    /// <param name="matrix">FixMatrix to negate.</param>
    /// <param name="result">Negated matrix.</param>
    public static void Negate(in fix3x3 matrix, out fix3x3 result)
    {
        result.M11 = -matrix.M11;
        result.M12 = -matrix.M12;
        result.M13 = -matrix.M13;

        result.M21 = -matrix.M21;
        result.M22 = -matrix.M22;
        result.M23 = -matrix.M23;

        result.M31 = -matrix.M31;
        result.M32 = -matrix.M32;
        result.M33 = -matrix.M33;
    }

    /// <summary>
    /// Subtracts the two matrices from each other on a per-element basis.
    /// </summary>
    /// <param name="a">First matrix to subtract.</param>
    /// <param name="b">Second matrix to subtract.</param>
    /// <param name="result">Difference of the two matrices.</param>
    public static void Subtract(in fix3x3 a, in fix3x3 b, out fix3x3 result)
    {
        fix m11 = a.M11 - b.M11;
        fix m12 = a.M12 - b.M12;
        fix m13 = a.M13 - b.M13;

        fix m21 = a.M21 - b.M21;
        fix m22 = a.M22 - b.M22;
        fix m23 = a.M23 - b.M23;

        fix m31 = a.M31 - b.M31;
        fix m32 = a.M32 - b.M32;
        fix m33 = a.M33 - b.M33;

        result.M11 = m11;
        result.M12 = m12;
        result.M13 = m13;

        result.M21 = m21;
        result.M22 = m22;
        result.M23 = m23;

        result.M31 = m31;
        result.M32 = m32;
        result.M33 = m33;
    }

    /// <summary>
    /// Creates a 4x4 matrix from a 3x3 matrix.
    /// </summary>
    /// <param name="a">3x3 matrix.</param>
    /// <param name="b">Created 4x4 matrix.</param>
    public static void ToMatrix4X4(in fix3x3 a, out fix4x4 b)
    {
#if !WINDOWS
        b = new fix4x4();
#endif
        b.M11 = a.M11;
        b.M21 = a.M12;
        b.M31 = a.M13;

        b.M12 = a.M21;
        b.M22 = a.M22;
        b.M32 = a.M23;

        b.M13 = a.M31;
        b.M23 = a.M32;
        b.M33 = a.M33;

        b.M44 = F64.C1;
        b.M41 = F64.C0;
        b.M42 = F64.C0;
        b.M43 = F64.C0;
        b.M14 = F64.C0;
        b.M24 = F64.C0;
        b.M34 = F64.C0;
    }

    /// <summary>
    /// Creates a 4x4 matrix from a 3x3 matrix.
    /// </summary>
    /// <param name="a">3x3 matrix.</param>
    /// <returns>Created 4x4 matrix.</returns>
    public static fix4x4 ToMatrix4X4(fix3x3 a)
    {
#if !WINDOWS
        fix4x4 b = new fix4x4();
#else
            FixMatrix b;
#endif
        b.M11 = a.M11;
        b.M21 = a.M12;
        b.M31 = a.M13;

        b.M12 = a.M21;
        b.M22 = a.M22;
        b.M32 = a.M23;

        b.M13 = a.M31;
        b.M23 = a.M32;
        b.M33 = a.M33;

        b.M44 = F64.C1;
        b.M41 = F64.C0;
        b.M42 = F64.C0;
        b.M43 = F64.C0;
        b.M14 = F64.C0;
        b.M24 = F64.C0;
        b.M34 = F64.C0;
        return b;
    }

    /// <summary>
    /// Transforms the vector by the matrix.
    /// </summary>
    /// <param name="v">FixVector3 to transform.</param>
    /// <param name="matrix">FixMatrix to use as the transformation.</param>
    /// <param name="result">Product of the transformation.</param>
    public static void Transform(in fix3 v, in fix3x3 matrix, out fix3 result)
    {
        fix vX = v.x;
        fix vY = v.y;
        fix vZ = v.z;
#if !WINDOWS
        result = new fix3();
#endif
        result.x = vX * matrix.M11 + vY * matrix.M21 + vZ * matrix.M31;
        result.y = vX * matrix.M12 + vY * matrix.M22 + vZ * matrix.M32;
        result.z = vX * matrix.M13 + vY * matrix.M23 + vZ * matrix.M33;
    }


    /// <summary>
    /// Transforms the vector by the matrix.
    /// </summary>
    /// <param name="v">FixVector3 to transform.</param>
    /// <param name="matrix">FixMatrix to use as the transformation.</param>
    /// <returns>Product of the transformation.</returns>
    public static fix3 Transform(fix3 v, fix3x3 matrix)
    {
        fix3 result;
#if !WINDOWS
        result = new fix3();
#endif
        fix vX = v.x;
        fix vY = v.y;
        fix vZ = v.z;

        result.x = vX * matrix.M11 + vY * matrix.M21 + vZ * matrix.M31;
        result.y = vX * matrix.M12 + vY * matrix.M22 + vZ * matrix.M32;
        result.z = vX * matrix.M13 + vY * matrix.M23 + vZ * matrix.M33;
        return result;
    }

    /// <summary>
    /// Transforms the vector by the matrix's transpose.
    /// </summary>
    /// <param name="v">FixVector3 to transform.</param>
    /// <param name="matrix">FixMatrix to use as the transformation transpose.</param>
    /// <param name="result">Product of the transformation.</param>
    public static void TransformTranspose(in fix3 v, in fix3x3 matrix, out fix3 result)
    {
        fix vX = v.x;
        fix vY = v.y;
        fix vZ = v.z;
#if !WINDOWS
        result = new fix3();
#endif
        result.x = vX * matrix.M11 + vY * matrix.M12 + vZ * matrix.M13;
        result.y = vX * matrix.M21 + vY * matrix.M22 + vZ * matrix.M23;
        result.z = vX * matrix.M31 + vY * matrix.M32 + vZ * matrix.M33;
    }

    /// <summary>
    /// Transforms the vector by the matrix's transpose.
    /// </summary>
    /// <param name="v">FixVector3 to transform.</param>
    /// <param name="matrix">FixMatrix to use as the transformation transpose.</param>
    /// <returns>Product of the transformation.</returns>
    public static fix3 TransformTranspose(fix3 v, fix3x3 matrix)
    {
        fix vX = v.x;
        fix vY = v.y;
        fix vZ = v.z;
        fix3 result;
#if !WINDOWS
        result = new fix3();
#endif
        result.x = vX * matrix.M11 + vY * matrix.M12 + vZ * matrix.M13;
        result.y = vX * matrix.M21 + vY * matrix.M22 + vZ * matrix.M23;
        result.z = vX * matrix.M31 + vY * matrix.M32 + vZ * matrix.M33;
        return result;
    }

    /// <summary>
    /// Computes the transposed matrix of a matrix.
    /// </summary>
    /// <param name="matrix">FixMatrix to transpose.</param>
    /// <param name="result">Transposed matrix.</param>
    public static void Transpose(in fix3x3 matrix, out fix3x3 result)
    {
        fix m21 = matrix.M12;
        fix m31 = matrix.M13;
        fix m12 = matrix.M21;
        fix m32 = matrix.M23;
        fix m13 = matrix.M31;
        fix m23 = matrix.M32;

        result.M11 = matrix.M11;
        result.M12 = m12;
        result.M13 = m13;
        result.M21 = m21;
        result.M22 = matrix.M22;
        result.M23 = m23;
        result.M31 = m31;
        result.M32 = m32;
        result.M33 = matrix.M33;
    }

    /// <summary>
    /// Computes the transposed matrix of a matrix.
    /// </summary>
    /// <param name="matrix">FixMatrix to transpose.</param>
    /// <param name="result">Transposed matrix.</param>
    public static void Transpose(in fix4x4 matrix, out fix3x3 result)
    {
        fix m21 = matrix.M21;
        fix m31 = matrix.M31;
        fix m12 = matrix.M12;
        fix m32 = matrix.M32;
        fix m13 = matrix.M13;
        fix m23 = matrix.M23;

        result.M11 = matrix.M11;
        result.M12 = m12;
        result.M13 = m13;
        result.M21 = m21;
        result.M22 = matrix.M22;
        result.M23 = m23;
        result.M31 = m31;
        result.M32 = m32;
        result.M33 = matrix.M33;
    }

    /// <summary>
    /// Transposes the matrix in-place.
    /// </summary>
    public void Transpose()
    {
        fix intermediate = M12;
        M12 = M21;
        M21 = intermediate;

        intermediate = M13;
        M13 = M31;
        M31 = intermediate;

        intermediate = M23;
        M23 = M32;
        M32 = intermediate;
    }


    /// <summary>
    /// Creates a string representation of the matrix.
    /// </summary>
    /// <returns>A string representation of the matrix.</returns>
    public override string ToString()
    {
        return "{" + M11 + ", " + M12 + ", " + M13 + "} " +
               "{" + M21 + ", " + M22 + ", " + M23 + "} " +
               "{" + M31 + ", " + M32 + ", " + M33 + "}";
    }

    /// <summary>
    /// Calculates the determinant of largest nonsingular submatrix, excluding 2x2's that involve M13 or M31, and excluding all 1x1's that involve nondiagonal elements.
    /// </summary>
    /// <param name="subMatrixCode">Represents the submatrix that was used to compute the determinant.
    /// 0 is the full 3x3.  1 is the upper left 2x2.  2 is the lower right 2x2.  3 is the four corners.
    /// 4 is M11.  5 is M22.  6 is M33.</param>
    /// <returns>The matrix's determinant.</returns>
    internal fix AdaptiveDeterminant(out int subMatrixCode)
    {
        // We do not try the full matrix. This is handled by the AdaptiveInverse.

        // We'll play it fast and loose here and assume the following won't overflow
        //Try m11, m12, m21, m22.
        fix determinant = M11 * M22 - M12 * M21;
        if (determinant != F64.C0)
        {
            subMatrixCode = 1;
            return determinant;
        }
        //Try m22, m23, m32, m33.
        determinant = M22 * M33 - M23 * M32;
        if (determinant != F64.C0)
        {
            subMatrixCode = 2;
            return determinant;
        }
        //Try m11, m13, m31, m33.
        determinant = M11 * M33 - M13 * M12;
        if (determinant != F64.C0)
        {
            subMatrixCode = 3;
            return determinant;
        }
        //Try m11.
        if (M11 != F64.C0)
        {
            subMatrixCode = 4;
            return M11;
        }
        //Try m22.
        if (M22 != F64.C0)
        {
            subMatrixCode = 5;
            return M22;
        }
        //Try m33.
        if (M33 != F64.C0)
        {
            subMatrixCode = 6;
            return M33;
        }
        //It's completely singular!
        subMatrixCode = -1;
        return F64.C0;
    }

    /// <summary>
    /// Creates a 3x3 matrix representing the orientation stored in the quaternion.
    /// </summary>
    /// <param name="quaternion">FixQuaternion to use to create a matrix.</param>
    /// <param name="result">FixMatrix representing the quaternion's orientation.</param>
    public static void CreateFromQuaternion(in fixQuaternion quaternion, out fix3x3 result)
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
        result.M21 = XY - ZW;
        result.M31 = XZ + YW;

        result.M12 = XY + ZW;
        result.M22 = F64.C1 - XX - ZZ;
        result.M32 = YZ - XW;

        result.M13 = XZ - YW;
        result.M23 = YZ + XW;
        result.M33 = F64.C1 - XX - YY;
    }

    /// <summary>
    /// Creates a 3x3 matrix representing the orientation stored in the quaternion.
    /// </summary>
    /// <param name="quaternion">FixQuaternion to use to create a matrix.</param>
    /// <returns>FixMatrix representing the quaternion's orientation.</returns>
    public static fix3x3 CreateFromQuaternion(fixQuaternion quaternion)
    {
        fix3x3 result;
        CreateFromQuaternion(in quaternion, out result);
        return result;
    }

    /// <summary>
    /// Computes the outer product of the given vectors.
    /// </summary>
    /// <param name="a">First vector.</param>
    /// <param name="b">Second vector.</param>
    /// <param name="result">Outer product result.</param>
    public static void CreateOuterProduct(in fix3 a, in fix3 b, out fix3x3 result)
    {
        result.M11 = a.x * b.x;
        result.M12 = a.x * b.y;
        result.M13 = a.x * b.z;

        result.M21 = a.y * b.x;
        result.M22 = a.y * b.y;
        result.M23 = a.y * b.z;

        result.M31 = a.z * b.x;
        result.M32 = a.z * b.y;
        result.M33 = a.z * b.z;
    }

    /// <summary>
    /// Creates a matrix representing a rotation of a given angle around a given axis.
    /// </summary>
    /// <param name="axis">Axis around which to rotate.</param>
    /// <param name="angle">Amount to rotate.</param>
    /// <returns>FixMatrix representing the rotation.</returns>
    public static fix3x3 CreateFromAxisAngle(fix3 axis, fix angle)
    {
        fix3x3 toReturn;
        CreateFromAxisAngle(in axis, angle, out toReturn);
        return toReturn;
    }

    /// <summary>
    /// Creates a matrix representing a rotation of a given angle around a given axis.
    /// </summary>
    /// <param name="axis">Axis around which to rotate.</param>
    /// <param name="angle">Amount to rotate.</param>
    /// <param name="result">FixMatrix representing the rotation.</param>
    public static void CreateFromAxisAngle(in fix3 axis, fix angle, out fix3x3 result)
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
        result.M21 = -axis.z * sinAngle + oneMinusCosAngle * xy;
        result.M31 = axis.y * sinAngle + oneMinusCosAngle * xz;

        result.M12 = axis.z * sinAngle + oneMinusCosAngle * xy;
        result.M22 = F64.C1 + oneMinusCosAngle * (yy - F64.C1);
        result.M32 = -axis.x * sinAngle + oneMinusCosAngle * yz;

        result.M13 = -axis.y * sinAngle + oneMinusCosAngle * xz;
        result.M23 = axis.x * sinAngle + oneMinusCosAngle * yz;
        result.M33 = F64.C1 + oneMinusCosAngle * (zz - F64.C1);
    }

}
