﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walrus.Ranges
{
    public static class RangeOperations
    {
        public static bool IntersectsWith<T>(IRange<T> x, IRange<T> y)
            where T : IComparable<T>
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            if (x.IsEmpty || y.IsEmpty) return false;
            if (x.Start.CompareTo(y.End) > 0) return false;
            if (x.End.CompareTo(y.Start) < 0) return false;
            if (x.Start.CompareTo(y.End) == 0) return !x.HasOpenStart && !y.HasOpenEnd;
            if (x.End.CompareTo(y.Start) == 0) return !x.HasOpenEnd && !y.HasOpenStart;
            return true;
        }

        public static IRange<T> Intersect<T>(IRange<T> x, IRange<T> y)
            where T : IComparable<T>
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            throw new NotImplementedException();
        }
    }
}
