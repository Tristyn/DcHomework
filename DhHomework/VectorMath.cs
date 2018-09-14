using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DhHomework
{
    public static class VectorMath
    {
        // This one seems like a trick question
        // Let me know if I got it right
        // Copy-by-ref from c# 7.2 in action
        public static void RhsToLhs(in Vector3 rhs, out Vector3 lhs)
        {
            lhs = new Vector3(rhs.X, rhs.Y, -rhs.Z);
        }

        public static void RhsToLhs(in Vector4 rhs, out Vector4 lhs)
        {
            lhs = new Vector4(rhs.X, rhs.Y, -rhs.Z, rhs.W);
        }
    }
}
