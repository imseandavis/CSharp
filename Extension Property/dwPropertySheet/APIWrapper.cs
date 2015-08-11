using System;
using System.Runtime.InteropServices;

namespace Dotware.Components.PropertySheet
{
	/// <summary>
	/// Summary description for APIWrapper.
	/// </summary>
	public class APIWrapper
	{
		[DllImport("comctl32.dll", EntryPoint="CreatePropertySheetPage")]
		private static extern IntPtr CreatePropertySheetPage_(ref PROPSHEETPAGE psp);

		public static IntPtr CreatePropertySheetPage(ref PROPSHEETPAGE psp) 
		{
			IntPtr hPage = APIWrapper.CreatePropertySheetPage_(ref psp);
			if(hPage == IntPtr.Zero) throw new Exception("CreatePropertySheetPage failed");
			return hPage;
		}

		// Our C++ wrappers. dwWrapper.dll (attached file) needs to be on the path 
		// these  functions do some pointer playing that can't be done with in C# easily
		[DllImport("dwWrapper.dll", EntryPoint="CallCallback")]
		private static extern int CallCallback_(IntPtr lpfnAddPage, IntPtr hProp, IntPtr lParam);
		// Calls an unmanaged function using fptr, as below
		/* extern "C" WRAPPER_API int CallCallback(LPFNSVADDPROPSHEETPAGE lpfnAddPage, HPROPSHEETPAGE hProp, LPARAM lParam)
							   {
								   int res = (*lpfnAddPage)(hProp, lParam);
								   if(!res)
								   {
									   DestroyPropertySheetPage(hProp);
								   }
								   return res;
							   }
		*/


		public static int CallCallback(IntPtr lpfnAddPage, IntPtr hProp, IntPtr lParam) 
		{
			int res = APIWrapper.CallCallback_(lpfnAddPage, hProp, lParam);
			if(res == 0) throw new Exception("Callback failed");
			return res;
		}

		[DllImport("user32.dll",SetLastError=true)]
		public static extern uint RegisterClipboardFormat(
			string lpszFormat);					// name of new format - LPCTSTR 

		[DllImport("ole32",SetLastError=true)]	// SETLAST by us
		public static extern void ReleaseStgMedium(ref STGMEDIUM pmedium);

		[DllImport("user32.dll",SetLastError=true)] // SETLAST by us
		public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll",SetLastError=true)]
		public static extern long SetWindowLong(
			IntPtr hWnd,		// handle to window
			int nIndex,			// offset of value to set
			int dwNewLong		// new value // LONG
			);

		[DllImport("user32.dll",SetLastError=true)]
		public static extern IntPtr GetParent(IntPtr hWnd);
	}
}
