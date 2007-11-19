﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Indy.IL2CPU.CustomImplementation.System {
	public static class StringImpl {
		[MethodAlias(Name = "System.String System.String.FastAllocateString(System.Int32)")]
		public static String FastAllocateString(int aLength) {
			Char[] xItems = new Char[aLength];
			return new String(xItems);
		}

		[MethodAlias(Name = "System.Void System.String..ctor(System.Char[],System.Int32,System.Int32)")]
		public static void Ctor(String aThis, [FieldAccess(Name = "$$Storage$$")]ref Char[] aStorage, Char[] aChars, int aStartIndex, int aLength) {
			Char[] newChars = new Char[aLength];
			Array.Copy(aChars, aStartIndex, newChars, 0, aLength);
			aStorage = newChars;
		}

		[MethodAlias(Name = "System.Void System.String..ctor(System.Char[])")]
		public static void Ctor(String aThis, [FieldAccess(Name = "$$Storage$$")] ref Char[] aStorage, Char[] aChars) {
			aStorage = aChars;
		}

		public static uint GetStorage(string aString) {
			return 0;
		}
	}
}
