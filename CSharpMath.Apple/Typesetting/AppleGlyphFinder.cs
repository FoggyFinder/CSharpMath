﻿using CSharpMath.FrontEnd;
using TGlyph = System.UInt16;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace CSharpMath.Apple {
  public class AppleGlyphFinder : IGlyphFinder<TGlyph> {

    public AppleGlyphFinder() {
    }
    public ushort FindGlyphForCharacterAtIndex(int index, string str) {
      var unicodeIndexes = StringInfo.ParseCombiningCharacters(str);
      int start = 0;
      int end = str.Length;
      foreach (var unicodeIndex in unicodeIndexes) {
        if (unicodeIndex <= index) {
          start = unicodeIndex;
        } else {
          end = unicodeIndex;
          break;
        }
      }

      var encoding = new UnicodeEncoding();
      var substring = str.Substring(start, end - start);
      var encodeSubstring = encoding.GetBytes(substring);
      return encodeSubstring[0];
    }

    //public string GetString(TGlyph[] glyphs) {
    //  var encoding = new UnicodeEncoding();
    //  int charCount = encoding.GetCharCount()
    //}

    private IEnumerable<ushort> FindGlyphsInternal(string str) {
      // not completely sure this is correct. Need an actual
      // example of a composed character sequence coming from LaTeX.
      var unicodeIndexes = StringInfo.ParseCombiningCharacters(str);
      foreach (var index in unicodeIndexes) {
        yield return FindGlyphForCharacterAtIndex(index, str);
      }
    }

    public ushort[] FindGlyphs(string str)
      => FindGlyphsInternal(str).ToArray();
  }
}
