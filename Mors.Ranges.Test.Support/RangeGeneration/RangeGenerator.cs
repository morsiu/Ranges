﻿// Copyright (C) 2013 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using Mors.Ranges.Test.Support.Extensions;
using Mors.Ranges.Test.Support.RangeGeneration.Options;

namespace Mors.Ranges.Test.Support.RangeGeneration
{
    internal static class RangeGenerator
    {
        public static IEnumerable<IRange<int>> GenerateRanges(RangeKind rangeType)
        {
            switch (rangeType)
            {
                case RangeKind.NonEmpty:
                    foreach (var range in GenerateNonEmptyRanges()) yield return range;
                    break;
                case RangeKind.Empty:
                    yield return Range.Empty<int>();
                    break;
                case RangeKind.Null:
                    yield return null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(rangeType));
            }
        }

        private static IEnumerable<IRange<int>> GenerateNonEmptyRanges()
        {
            foreach (var rangeEnd in new AllRangeEnds())
            {
                yield return GenerateNonEmptyRange(1, 3, rangeEnd);
            }
        }

        private static IRange<int> GenerateNonEmptyRange(int start, int end, RangeEnds ends)
        {
            var hasOpenStart = ends == RangeEnds.LeftOpen;
            var hasOpenEnd = ends == RangeEnds.RightOpen;
            var range = Range.Create(start, end, hasOpenStart, hasOpenEnd);
            return range;
        }
    }
}
