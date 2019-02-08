﻿// Copyright (C) 2019 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.Collections.Generic;

namespace Mors.Ranges.Generation.Tests
{
    internal readonly struct ClosedRange
    {
        private readonly int _start;
        private readonly int _end;
        private readonly bool _nonEmpty;

        public ClosedRange(int start, int end)
        {
            _nonEmpty = true;
            _start = start;
            _end = end;
        }

        public IEnumerable<OpenRange> ToOpenRanges()
        {
            var x = new OpenRanges();
            if (!_nonEmpty)
            {
                yield return x.Empty();
            }
            else
            {
                yield return x.Range(_start, _end, isStartOpen: true, isEndOpen: true);
                yield return x.Range(_start, _end, isStartOpen: true, isEndOpen: false);
                yield return x.Range(_start, _end, isStartOpen: false, isEndOpen: true);
                yield return x.Range(_start, _end, isStartOpen: false, isEndOpen: false);
            }
        }

        public override string ToString() =>
            _nonEmpty ? $"[{_start}, {_end}]" : "∅";
    }
}
