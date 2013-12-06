﻿// Copyright (C) 2013 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;

namespace Walrus.Ranges
{
    internal sealed class Range<T> : IRange<T>
        where T : IComparable<T>
    {
        private readonly T _start;
        private readonly T _end;
        private readonly bool _hasOpenStart;
        private readonly bool _hasOpenEnd;

        public Range(T start, T end, bool hasOpenStart, bool hasOpenEnd)
        {
            // Validation is done in Range static class
            _start = start;
            _end = end;
            _hasOpenStart = hasOpenStart;
            _hasOpenEnd = hasOpenEnd;
        }

        public bool IsEmpty
        {
            get { return false; }
        }

        public T Start
        {
            get { return _start; }
        }

        public T End
        {
            get { return _end; }
        }

        public bool HasOpenStart
        {
            get { return _hasOpenStart; }
        }

        public bool HasOpenEnd
        {
            get { return _hasOpenEnd; }
        }

        public override bool Equals(object obj)
        {
            return RangeEqualityComparer<T>.Instance.Equals(this, obj as IRange<T>);
        }

        public bool Equals(IRange<T> other)
        {
            return RangeEqualityComparer<T>.Instance.Equals(this, other);
        }
    }
}