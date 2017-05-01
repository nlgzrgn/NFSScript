﻿using Maths = System.Math;

namespace NFSScript.Math
{
    /// <summary>
    /// Represents an ordered pair of integer x and y coordinates that defines a <see cref="Point"/> in a two-dimensional plane.
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// Returns the x-coordinate of this <see cref="Point"/>.
        /// </summary>
        public int x { get; private set; }

        /// <summary>
        /// Returns the y-coordinate of this <see cref="Point"/>.
        /// </summary>
        public int y { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class using coordinates specified by an interger value.
        /// </summary>
        /// <param name="value"></param>
        public Point(int value)
        {
            x = value;
            y = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Set the XY values of this <see cref="Point"/>.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Set(int x, int y)
        {
            this.x = x;
            this.y = x;
        }

        /// <summary>
        /// Returns the distance between two points.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Distance(Point a, Point b)
        {
            return (int)Maths.Sqrt(Maths.Pow((b.x - a.x), 2) + Maths.Pow((b.y - a.y), 2));
        }

        /// <summary>
        /// Returns a value determining whether the two Point values are equal.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==(Point l, Point r)
        {
            return Equals(l, r);
        }

        /// <summary>
        /// Returns a value determining whether the two Point values aren't equal.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator !=(Point l, Point r)
        {
            return !Equals(l, r);
        }

        /// <summary>
        /// Returns a hash code for this <see cref="Point"/>.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() << 2;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Point"/> is equal to the current <see cref="Point"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Point) || obj == null)
                return false;
            else return Equals(this, (Point)obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Point"/> values are equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool Equals(Point a, Point b)
        {
            return (a.x == b.x && a.y == b.y);
        }

        /// <summary>
        /// Returns a formatted <see cref="Point"/> string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("X = {0} Y = {1}", x, y);
        }

        /// <summary>
        /// Returns a formmated <see cref="Point"/> string with a specified number format.
        /// </summary>
        /// <returns></returns>
        public string ToString(string numberFormat)
        {
            return string.Format("X = {0} Y = {1}", x.ToString(numberFormat), y.ToString(numberFormat));
        }
    }
}
