using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security;

namespace DouglasDwyer.CasCore.Tests;

public static class TestMemorySafety
{
    [TestException(typeof(TypeInitializationException))]
    public static unsafe int TestInvalidPointerWrite()
    {
        var x = 1;
        var y = &x + 1;
        *y = 2;
        return x;
    }

    [TestException(typeof(TypeInitializationException))]
    public static unsafe int TestInvalidPointerRead()
    {
        var x = 1;
        var y = &x + 1;
        var z = *y;
        return z;
    }

	/*
	[TestException(typeof(TypeInitializationException))]
    public static unsafe int* TestInvalidStackalloc()
    {
        int* data = stackalloc int[28];
        return data;
	}
	*/

	[TestSuccessful]
	//[TestException(typeof(TypeInitializationException))]
	public static int TestSafeStackAlloc() {
		Span<int> test = stackalloc int[4];
		return test[0];
	}

	[TestSuccessful]
	//[TestException(typeof(TypeInitializationException))]
	public static int TestSafeStackAllocUnknownArg() {
		return TestSafeStackAlloc(8);
	}

	//[TestException(typeof(TypeInitializationException))]
	public static int TestSafeStackAlloc(int length) {
		Span<int> test = stackalloc int[length];
		return test[0];
	}

	[TestException(typeof(TypeInitializationException))]
	public static unsafe int TestFixedPtr() {
		Span<int> test = stackalloc int[4];
		fixed (int* fv = &test[0]) {
			return *fv;
		}
	}

	[TestException(typeof(SecurityException))]
	public static unsafe void TestIntToPointerCast() {
		nint address = 0x0000000000000000;
		Span<byte> nullptr = new Span<byte>((void*)address, 1);
	}

	[TestException(typeof(SecurityException))]
	public static void TestStartNotepad() {
		Process.Start("notepad");
	}

	[TestSuccessful]
    public static unsafe int TestRefRead()
    {
        var x = 1;
        ref var y = ref x;
        return y;
    }

    [TestSuccessful]
    public static unsafe int TestRefWrite()
    {
        var x = 1;
        ref var y = ref x;
        y += 1;
        return x;
    }

    [TestException(typeof(SecurityException))]
    public static void TestGcAllocateUninitArray()
    {
        GC.AllocateUninitializedArray<int>(29);
    }

    [TestSuccessful]
    public static void TestGcAllocateArray()
    {
        GC.AllocateArray<int>(29);
    }

    [TestException(typeof(SecurityException))]
    public static void TestUnsafe()
    {
        var x = 29;
        Unsafe.Add(ref x, 29) = 30;
    }

    [TestException(typeof(SecurityException))]
    public static void TestEmit()
    {
        AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(), AssemblyBuilderAccess.RunAndCollect);
    }

    [TestException(typeof(SecurityException))]
    public static void TestRuntimeHelpersGetUninitObject()
    {
        RuntimeHelpers.GetUninitializedObject(typeof(MethodBuilder));
    }
}