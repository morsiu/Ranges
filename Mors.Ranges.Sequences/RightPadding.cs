﻿// Copyright (C) 2018 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;

namespace Mors.Ranges.Sequences
{
    public struct RightPadding
    {
        private readonly int _mainStart;
        private readonly int _mainLength;
        private readonly int _otherStart;
        private readonly int _otherLength;

        public RightPadding(int mainStart, int mainLength, int otherStart, int otherLength)
        {
            _mainStart = mainStart;
            _mainLength = mainLength;
            _otherStart = otherStart;
            _otherLength = otherLength;
        }

        public int End => Math.Max(_mainStart + _mainLength, _otherStart + _otherLength);

        public int Length => Math.Max(0, _otherStart + _otherLength - _mainStart - _mainLength);
    }
}