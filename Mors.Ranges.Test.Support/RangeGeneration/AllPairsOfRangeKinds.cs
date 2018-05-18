﻿// Copyright (C) 2018 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Mors.Ranges.Test.Support.RangeGeneration
{
    public sealed class AllPairsOfRangeKinds : IEnumerable<Tuple<RangeKind, RangeKind>>
    {
        public IEnumerator<Tuple<RangeKind, RangeKind>> GetEnumerator()
        {
            yield return Tuple.Create(RangeKind.Empty, RangeKind.Empty);
            yield return Tuple.Create(RangeKind.NonEmpty, RangeKind.Empty);
            yield return Tuple.Create(RangeKind.Empty, RangeKind.NonEmpty);
            yield return Tuple.Create(RangeKind.NonEmpty, RangeKind.NonEmpty);
            yield return Tuple.Create(RangeKind.Null, RangeKind.Null);
            yield return Tuple.Create(RangeKind.Null, RangeKind.Empty);
            yield return Tuple.Create(RangeKind.Empty, RangeKind.Null);
            yield return Tuple.Create(RangeKind.Null, RangeKind.NonEmpty);
            yield return Tuple.Create(RangeKind.NonEmpty, RangeKind.Null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}