// 
// Program.cs
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

/*
@Puzzle Instructions

Word Search Puzzle

Given a collection of letters which contain hidden words (in the file WORDSEARCH.TXT), find all of the words
in the word list (in the file WORDLIST.TXT) within the puzzle.  Remember, the words may be hidden left to right,
right to left, up, down or diagonally.

Create a console application which will search the puzzle for the words contained in the list.  Your output should
note which word you found, where you found it and one of the following designations for the direction the word takes:

LR – Left to right
RL – Right to left
U – Up
D – Down
DUL – Diagonal up left
DUR – Diagonal up right
DDL – Diagonal down left
DDR – Diagonal down right

Your deliverable for this exercise will be the console application and all supporting modules necessary to compile
and run your solution.

There is no “right” solution to this problem.  We are simply trying to determine how you approach the problem, how
comfortable you are with C# and the quality of the output you deliver.  Solid, well performing code always wins out
over clever code.  If you have any questions about this exercise, please contact me at dave.ferreira@nordstrom.com.

Good luck and happy coding!
*/

using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Nordstrom.CodingTest
{
	class WordSearch
	{
		/*
		LR – Left to right
		RL – Right to left
		U – Up
		D – Down
		DUL – Diagonal up left
		DUR – Diagonal up right
		DDL – Diagonal down left
		DDR – Diagonal down right
		*/

		public static void Main (string[] args)
		{
			string wordListFile = @".\WordList.txt";
			string wordSearchFile = @".\WordSearch.txt";
			IEnumerable<string> wordList = ReadLinesFromFile (wordListFile);
			IEnumerable<string> wordSearch = ReadLinesFromFile (wordSearchFile);

			foreach (string line in wordSearch) {

				foreach (string word in wordList) {

					bool lrLineContainsWord = LineContainsWord (line, word);

					if (lrLineContainsWord) {
						Console.WriteLine ("The word {0} was found LR in the line {1}", word, line);
					}
						
					bool rlLineContainsWord = LineContainsWord (line.Reverse (), word);

					if (rlLineContainsWord) {
						Console.WriteLine ("The word {0} was found RL in the line {1}", word, reverseLine);
					}
				}
			}

			Console.Read ();
		}

		static IEnumerable<string> ReadLinesFromFile (string fileName)
		{
			using (StreamReader reader = new StreamReader (fileName, Encoding.UTF8, true)) {
				while (true) {
					string line = reader.ReadLine ();
					if (string.IsNullOrEmpty(line))
						break;
					yield return line.ToUpperInvariant ().Replace (" ", "");
				}
			}
		}

		static bool LineContainsWord (string line, string word)
		{
			return line.Contains (word);
		}
	}
}