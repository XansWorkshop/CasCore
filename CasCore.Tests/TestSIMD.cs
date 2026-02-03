using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace DouglasDwyer.CasCore.Tests;
public static class TestSIMD {


	[TestSuccessful]
	public static void TrySSE2() {
		Sse2.Add(System.Runtime.Intrinsics.Vector128.Create(0f, 0f, 0f, 0f), System.Runtime.Intrinsics.Vector128.Create(0f, 0f, 0f, 1f));
	}

}
