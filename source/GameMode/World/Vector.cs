﻿using System;

namespace GameMode.World
{
    public class Vector
    {
        public static Vector Zero = NewZero();
        public static Vector One = NewOne();

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector()
        {
            X = 0.0f;
            Y = 0.0f;
            Z = 0.0f;
        }

        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(float xyz)
        {
            X = xyz;
            Y = xyz;
            Z = xyz;
        }

        public Vector(Vector vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public static Vector NewZero()
        {
            return new Vector(0.0f);
        }

        public static Vector NewOne()
        {
            return new Vector(1.0f);
        }

        public float DotProduct(Vector other)
        {
            return X*other.X + Y*other.Y + Z*other.Z;
        }

        public static Vector operator +(Vector left, Vector right)
        {
            return new Vector(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector operator -(Vector left, Vector right)
        {
            return new Vector(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Vector operator -(Vector vector)
        {
            return new Vector(-vector.X, -vector.Y, -vector.Z);
        }

        public static Vector operator *(Vector vector, float scalar)
        {
            return new Vector(vector.X*scalar, vector.Y*scalar, vector.Z*scalar);
        }

        public static Vector operator /(Vector vector, float scalar)
        {
            return new Vector(vector.X/scalar, vector.Y/scalar, vector.Z/scalar);
        }

        public static bool operator ==(Vector left, Vector right)
        {
            try
            {
                return left.Equals(right);
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public static bool operator !=(Vector left, Vector right)
        {
            try
            {
                return !left.Equals(right);
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public static Vector CrossProduct(Vector a, Vector b)
        {
            return new Vector(a.Y*b.Z - a.Z*b.Y, a.Z*b.X - a.X*b.Z, a.X*b.Y - a.Y*b.X);
        }

        public Vector Add(Vector v)
        {
            X += v.X;
            Y += v.Y;
            Z += v.Z;
            return this;
        }

        public float DistanceTo(Vector v)
        {
            float dx = X - v.X;
            float dy = Y - v.Y;
            float dz = Z - v.Z;
            return (float) Math.Sqrt(dx*dx + dy*dy + dz*dz);
        }

        public float Size()
        {
            return DistanceTo(Zero);
        }

        public Vector Normalize()
        {
            float size = Size();
            X /= size;
            Y /= size;
            Z /= size;
            return this;
        }

        public Vector Clone()
        {
            return new Vector(this);
        }

        protected bool Equals(Vector other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Vector)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ", " + Z + ")";
        }
    }
}
