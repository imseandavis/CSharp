// Copyright 2002, Dotware Technologies. 
//
// General PropertySheet / Wizard classes in C#.
//
// Based on Microsoft PDC Sample.
// This file is the COM object code.

using System;
using System.Runtime.InteropServices;
using System.Collections;

namespace Dotware.Components.PropertySheet
{
	/// <summary>
	/// PropertyPage handler and loader class
	/// </summary>
	/// You must generate your Own GUID by uuidgen tool
	[Guid("6c1ff16f-b952-49cd-9ffe-e0612be42ccb"), ComVisible(true)]
	public class SheetLoader: IShellExtInit, IShellPropSheetExt
	{
		private IDataObject dobj = null;
		private string sClass;
		private string sObjADsPath;

		public SheetLoader()
		{
		}

		/// <summary>
		/// Get data about object we want properties for
		/// </summary>
		/// <param name="pidlFolder"></param>
		/// <param name="lpdobj"></param>
		/// <param name="hKeyProgID"></param>
		/// <returns></returns>
		int IShellExtInit.Initialize(IntPtr pidlFolder, IDataObject lpdobj, uint hKeyProgID)
		{
			dobj=lpdobj;
			return 0;
		}

		/// <summary>
		/// Add property page for this object
		/// </summary>
		/// <param name="lpfnAddPage"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		int IShellPropSheetExt.AddPages(IntPtr lpfnAddPage, IntPtr lParam)
		{
			try
			{
				// ADD PAGES HERE
				SheetControl samplePage;
				PROPSHEETPAGE psp;
				IntPtr hPage;
				
				// In ActiveDirectory extensions, Get type of object, and show page according to class
				// GetADPath();
				// if(sClass.ToLower() == "organizationalunit") {...}

				
				// create new inherited property page(s) and pass dobj to it
				samplePage = new Sample();
				psp = samplePage.GetPSP(250, 230); 

				hPage = APIWrapper.CreatePropertySheetPage(ref psp);
				APIWrapper.CallCallback(lpfnAddPage, hPage, lParam); 
				
				// We'll add reference manualy only if there is no exceptions
				samplePage.KeepAlive();
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			return 0;
		}

		/// <summary>
		/// Not Used here!
		/// </summary>
		/// <param name="uPageID"></param>
		/// <param name="lpfnReplacePage"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		int IShellPropSheetExt.ReplacePage(uint uPageID, IntPtr lpfnReplacePage, IntPtr lParam)
		{
			return 0;
		}

		
		/// <summary>
		/// Get object's ADS Path
		/// For properetysheets in Active Directory the code can 
		/// find what is the caller node .
		/// sClass , sObjADsPath will fill in this scenario.
		/// </summary>
		private unsafe void GetADPath()
		{
			FORMATETC fmt = new FORMATETC();
			fmt.cfFormat= (CLIPFORMAT)APIWrapper.RegisterClipboardFormat("DsObjectNames");//CLIPFORMAT.HDROP;
			fmt.ptd		= IntPtr.Zero;
			fmt.dwAspect= DVASPECT.CONTENT;
			fmt.lindex	= -1;
			fmt.tymed	= TYMED.HGLOBAL;

			STGMEDIUM medium = new STGMEDIUM();
			dobj.GetData(ref fmt, ref medium); // returned HRESULT

			DSOBJECTNAMES ds=(DSOBJECTNAMES) Marshal.PtrToStructure(
				medium.hGlobal, typeof(DSOBJECTNAMES));

			if(ds.cItems<1) 
			{
				System.Windows.Forms.MessageBox.Show("AD clipboard error!");
				return;
			}
			
			// aObjects[0]; also : can use Marshal.Copy to avoid pointers.
			IntPtr pClass = new IntPtr(ds.aObjects.offsetClass + (uint)medium.hGlobal);
			sClass = new string( (char*) pClass.ToPointer());

			IntPtr pObjADsPath = new IntPtr( ds.aObjects.offsetName + (uint)medium.hGlobal);
			sObjADsPath = new string((char*) pObjADsPath.ToPointer());

			APIWrapper.ReleaseStgMedium(ref medium); 
		}
	}
}