// 
// ExtensionFunctions.cs
//  
// Author:
//       M. David Peterson <m.david@3rdandurban.com>
// 
// Copyright (c) 2014 M. David Peterson
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Text;

namespace Nordstrom.CodingTest
{
	/// <summary>
	/// String extension methods. I made the reverse methods static extension methods for ease of reuse of commonly used string functions.
	/// In this particular case it's really not necessary (not a lot of need for reuse in this particular problem use case) but
	/// I placed them here to highlight what I consider to be best practice for extending the functionality of sealed classes such as the String class.
	/// </summary> 
	public static class StringExtensionMethods
	{
		/// <summary>
		/// Reverse the specified line.
		/// </summary>
		/// <param name="line">Line.</param>
		public static string Reverse (this string line)
		{
			if (string.IsNullOrEmpty (line))
				return line;
			int pivotPosition = line.Length / 2;
			for (int i = 0; i < pivotPosition; i++) {
				line = line.Insert (line.Length - i, line.Substring (i, 1)).Remove (i, 1);
				line = line.Insert (i, line.Substring (line.Length - (i + 2), 1)).Remove (line.Length - (i + 1), 1);
			}
			return line;
		}

		/// <summary>
		/// Reverse the specified builder.
		/// </summary>
		/// <param name="builder">Builder.</param>
		public static void Reverse(this StringBuilder builder)
		{
			if (builder.Length  > 1)
			{
				int pivotPosition = builder.Length / 2;
				for (int i = 0; i < pivotPosition; i++)
				{
					int iRight     = builder.Length - (i + 1);
					char rightChar = builder[i];
					char leftChar  = builder[iRight];
					builder[i]        = leftChar;
					builder[iRight]   = rightChar;
				}
			}
		}
	}
}