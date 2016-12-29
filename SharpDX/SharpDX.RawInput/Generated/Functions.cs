// Copyright (c) 2010-2014 SharpDX - Alexandre Mutel
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

//------------------------------------------------------------------------------
// <auto-generated>
//     Types declaration for SharpDX.RawInput namespace.
//     This code was generated by a tool.
//     Date : 6/25/2016 10:38:17 PM
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;
using System.Security;
namespace SharpDX.RawInput {

#pragma warning disable 419
#pragma warning disable 1587
#pragma warning disable 1574

        /// <summary>	
        /// Functions	
        /// </summary>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='SharpDX.RawInput.RawInputFunctions']/*"/>	
    static  partial class RawInputFunctions {   
        
        /// <summary>	
        /// <p>Enumerates the raw input devices attached to the system. </p>	
        /// </summary>	
        /// <param name="rawInputDeviceListRef"><dd>  <p>An array of <strong><see cref="SharpDX.RawInput.RawInputDevicelist"/></strong> structures for the devices attached to the system. If <strong><c>null</c></strong>, the number of devices are returned in *<em>puiNumDevices</em>. </p> </dd></param>	
        /// <param name="uiNumDevicesRef"><dd>  <p>If <em>pRawInputDeviceList</em> is <strong><c>null</c></strong>, the function populates this variable with the number of devices attached to the system; otherwise, this variable specifies the number of <strong><see cref="SharpDX.RawInput.RawInputDevicelist"/></strong> structures that can be contained in the buffer to which <em>pRawInputDeviceList</em> points. If this value is less than the number of devices attached to the system, the function returns the actual number of devices in this variable and fails with <strong><see cref="SharpDX.Win32.ErrorCode.InsufficientBuffer"/></strong>.</p> </dd></param>	
        /// <param name="cbSize"><dd>  <p>The size of a <strong><see cref="SharpDX.RawInput.RawInputDevicelist"/></strong> structure, in bytes.</p> </dd></param>	
        /// <returns><p>If the function is successful, the return value is the number of devices stored in the buffer pointed to by  <em>pRawInputDeviceList</em>.</p><p>On any other error, the function returns (<strong>UINT</strong>) -1 and  <strong>GetLastError</strong> returns the error indication.</p></returns>	
        /// <remarks>	
        /// <p>The devices returned from this function are the mouse, the keyboard, and other Human Interface Device (HID) devices.</p><p>To get more detailed information about the attached devices, call <strong>GetRawInputDeviceInfo</strong> using the hDevice from <strong><see cref="SharpDX.RawInput.RawInputDevicelist"/></strong>. </p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='GetRawInputDeviceList']/*"/>	
        /// <msdn-id>ms645598</msdn-id>	
        /// <unmanaged>unsigned int GetRawInputDeviceList([Out, Buffer, Optional] RAWINPUTDEVICELIST* pRawInputDeviceList,[InOut] unsigned int* puiNumDevices,[In] unsigned int cbSize)</unmanaged>	
        /// <unmanaged-short>GetRawInputDeviceList</unmanaged-short>	
        public static int GetRawInputDeviceList(SharpDX.RawInput.RawInputDevicelist[] rawInputDeviceListRef, ref int uiNumDevicesRef, int cbSize) {
            unsafe {
                SharpDX.RawInput.RawInputDevicelist[] rawInputDeviceListRef__ = rawInputDeviceListRef;
                int __result__;
                fixed (void* rawInputDeviceListRef_ = rawInputDeviceListRef__)
                    fixed (void* uiNumDevicesRef_ = &uiNumDevicesRef)
                        __result__= 
        				GetRawInputDeviceList_(rawInputDeviceListRef_, uiNumDevicesRef_, cbSize);		
                return __result__;
            }
        }
        [DllImport("user32.dll", EntryPoint = "GetRawInputDeviceList", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern int GetRawInputDeviceList_(void* arg0,void* arg1,int arg2);
        
        /// <summary>	
        /// <p>Retrieves information about the raw input device.</p>	
        /// </summary>	
        /// <param name="hDevice"><dd>  <p>A handle to the raw input device. This comes from the  <em>lParam</em> of the <strong>WM_INPUT</strong> message, from the <strong>hDevice</strong> member of <strong><see cref="SharpDX.RawInput.RawInputHeader"/></strong>, or from <strong>GetRawInputDeviceList</strong>. It can also be <strong><c>null</c></strong> if an application inserts input data, for example, by using <strong>SendInput</strong>. </p> </dd></param>	
        /// <param name="uiCommand"><dd>  <p>Specifies what data will be returned in  <em>pData</em>. This parameter can be one of the following values. </p> <table> <tr><th>Value</th><th>Meaning</th></tr> <tr><td><dl> <dt><strong><see cref="SharpDX.RawInput.RawInputDeviceInfoType.DeviceName"/></strong></dt> <dt>0x20000007</dt> </dl> </td><td> <p><em>pData</em> points to a string that contains the device name. </p> <p>For this  <em>uiCommand</em> only, the value in  <em>pcbSize</em> is the character count (not the byte count).</p> </td></tr> <tr><td><dl> <dt><strong><see cref="SharpDX.RawInput.RawInputDeviceInfoType.DeviceInfo"/></strong></dt> <dt>0x2000000b</dt> </dl> </td><td> <p><em>pData</em> points to an <strong><see cref="SharpDX.RawInput.RawDeviceInformation"/></strong> structure.</p> </td></tr> <tr><td><dl> <dt><strong><see cref="SharpDX.RawInput.RawInputDeviceInfoType.PreparsedData"/></strong></dt> <dt>0x20000005</dt> </dl> </td><td> <p><em>pData</em> points to the previously parsed data.</p> </td></tr> </table> <p>?</p> </dd></param>	
        /// <param name="dataRef"><dd>  <p>A reference to a buffer that contains the information specified by  <em>uiCommand</em>. If  <em>uiCommand</em> is <strong><see cref="SharpDX.RawInput.RawInputDeviceInfoType.DeviceInfo"/></strong>, set the <strong>cbSize</strong> member of <strong><see cref="SharpDX.RawInput.RawDeviceInformation"/></strong> to <code>sizeof(<see cref="SharpDX.RawInput.RawDeviceInformation"/>)</code> before calling <strong>GetRawInputDeviceInfo</strong>. </p> </dd></param>	
        /// <param name="cbSizeRef"><dd>  <p>The size, in bytes, of the data in  <em>pData</em>. </p> </dd></param>	
        /// <returns><p>If successful, this function returns a non-negative number indicating the number of bytes copied to  <em>pData</em>. </p><p>If  <em>pData</em> is not large enough for the data, the function returns -1. If  <em>pData</em> is <strong><c>null</c></strong>, the function returns a value of zero. In both of these cases,  <em>pcbSize</em> is set to the minimum size required for the  <em>pData</em> buffer.</p><p>Call <strong>GetLastError</strong> to identify any other errors.</p></returns>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='GetRawInputDeviceInfoW']/*"/>	
        /// <msdn-id>ms645597</msdn-id>	
        /// <unmanaged>unsigned int GetRawInputDeviceInfoW([In, Optional] void* hDevice,[In] RAW_INPUT_DEVICE_INFO_TYPE uiCommand,[Out, Buffer, Optional] void* pData,[InOut] unsigned int* pcbSize)</unmanaged>	
        /// <unmanaged-short>GetRawInputDeviceInfoW</unmanaged-short>	
        public static int GetRawInputDeviceInfo(System.IntPtr hDevice, SharpDX.RawInput.RawInputDeviceInfoType uiCommand, System.IntPtr dataRef, ref int cbSizeRef) {
            unsafe {
                int __result__;
                fixed (void* cbSizeRef_ = &cbSizeRef)
                    __result__= 
    				GetRawInputDeviceInfoW_((void*)hDevice, unchecked((int)uiCommand), (void*)dataRef, cbSizeRef_);		
                return __result__;
            }
        }
        [DllImport("user32.dll", EntryPoint = "GetRawInputDeviceInfoW", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern int GetRawInputDeviceInfoW_(void* arg0,int arg1,void* arg2,void* arg3);
        
        /// <summary>	
        /// <p>Retrieves the raw input from the specified device.</p>	
        /// </summary>	
        /// <param name="hRawInput"><dd>  <p>A handle to the <strong><see cref="SharpDX.RawInput.RawInput"/></strong> structure. This comes from the  <em>lParam</em> in <strong>WM_INPUT</strong>. </p> </dd></param>	
        /// <param name="uiCommand"><dd>  <p>The command flag. This parameter can be one of the following values. </p> <table> <tr><th>Value</th><th>Meaning</th></tr> <tr><td><dl> <dt><strong><see cref="SharpDX.RawInput.RawInputDataType.Header"/></strong></dt> <dt>0x10000005</dt> </dl> </td><td> <p>Get the header information from the <strong><see cref="SharpDX.RawInput.RawInput"/></strong> structure.</p> </td></tr> <tr><td><dl> <dt><strong><see cref="SharpDX.RawInput.RawInputDataType.Input"/></strong></dt> <dt>0x10000003</dt> </dl> </td><td> <p>Get the raw data from the <strong><see cref="SharpDX.RawInput.RawInput"/></strong> structure.</p> </td></tr> </table> <p>?</p> </dd></param>	
        /// <param name="dataRef"><dd>  <p>A reference to the data that comes from the <strong><see cref="SharpDX.RawInput.RawInput"/></strong> structure. This depends on the value of  <em>uiCommand</em>. If  <em>pData</em> is <strong><c>null</c></strong>, the required size of the buffer is returned in *<em>pcbSize</em>. </p> </dd></param>	
        /// <param name="cbSizeRef"><dd>  <p>The size, in bytes, of the data in  <em>pData</em>. </p> </dd></param>	
        /// <param name="cbSizeHeader"><dd>  <p>The size, in bytes, of the <strong><see cref="SharpDX.RawInput.RawInputHeader"/></strong> structure. </p> </dd></param>	
        /// <returns><p>If  <em>pData</em> is <strong><c>null</c></strong> and the function is successful, the return value is 0. If  <em>pData</em> is not <strong><c>null</c></strong> and the function is successful, the return value is the number of bytes copied into pData.</p><p>If there is an error, the return value is (<strong>UINT</strong>)-1.</p></returns>	
        /// <remarks>	
        /// <p><strong>GetRawInputData</strong> gets the raw input one <strong><see cref="SharpDX.RawInput.RawInput"/></strong> structure at a time. In contrast, <strong>GetRawInputBuffer</strong> gets an array of <strong><see cref="SharpDX.RawInput.RawInput"/></strong> structures.</p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='GetRawInputData']/*"/>	
        /// <msdn-id>ms645596</msdn-id>	
        /// <unmanaged>unsigned int GetRawInputData([In] HRAWINPUT hRawInput,[In] RAW_INPUT_DATA_TYPE uiCommand,[Out, Buffer, Optional] void* pData,[InOut] unsigned int* pcbSize,[In] unsigned int cbSizeHeader)</unmanaged>	
        /// <unmanaged-short>GetRawInputData</unmanaged-short>	
        public static int GetRawInputData(System.IntPtr hRawInput, SharpDX.RawInput.RawInputDataType uiCommand, System.IntPtr dataRef, ref int cbSizeRef, int cbSizeHeader) {
            unsafe {
                int __result__;
                fixed (void* cbSizeRef_ = &cbSizeRef)
                    __result__= 
    				GetRawInputData_((void*)hRawInput, unchecked((int)uiCommand), (void*)dataRef, cbSizeRef_, cbSizeHeader);		
                return __result__;
            }
        }
        [DllImport("user32.dll", EntryPoint = "GetRawInputData", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern int GetRawInputData_(void* arg0,int arg1,void* arg2,void* arg3,int arg4);
        
        /// <summary>	
        /// <p>Registers the devices that supply the raw input data.</p>	
        /// </summary>	
        /// <param name="rawInputDevicesRef"><dd>  <p>An array of <strong><see cref="SharpDX.RawInput.RawInputDevice"/></strong> structures that represent the devices that supply the raw input.</p> </dd></param>	
        /// <param name="uiNumDevices"><dd>  <p>The number of <strong><see cref="SharpDX.RawInput.RawInputDevice"/></strong> structures pointed to by <em>pRawInputDevices</em>.</p> </dd></param>	
        /// <param name="cbSize"><dd>  <p>The size, in bytes, of a <strong><see cref="SharpDX.RawInput.RawInputDevice"/></strong> structure.</p> </dd></param>	
        /// <returns><p><strong>TRUE</strong> if the function succeeds; otherwise, <strong><see cref="SharpDX.Result.False"/></strong>. If the function fails, call <strong>GetLastError</strong> for more information.</p></returns>	
        /// <remarks>	
        /// <p>To receive <strong>WM_INPUT</strong> messages, an application must first register the raw input devices using <strong>RegisterRawInputDevices</strong>. By default, an application does not receive raw input.</p><p>To receive <strong>WM_INPUT_DEVICE_CHANGE</strong> messages, an application must specify the  <see cref="SharpDX.RawInput.DeviceFlags.DeviceNotify"/> flag for each device class that is specified by the usUsagePage and usUsage fields of the  <strong><see cref="SharpDX.RawInput.RawInputDevice"/></strong> structure  .  By default, an application does not receive  <strong>WM_INPUT_DEVICE_CHANGE</strong> notifications for raw input device arrival and removal.</p><p>If a <strong><see cref="SharpDX.RawInput.RawInputDevice"/></strong> structure has the <see cref="SharpDX.RawInput.DeviceFlags.Remove"/> flag set and the hwndTarget parameter is not set to <c>null</c>, then parameter validation will fail. </p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='RegisterRawInputDevices']/*"/>	
        /// <msdn-id>ms645600</msdn-id>	
        /// <unmanaged>BOOL RegisterRawInputDevices([In, Buffer] const RAWINPUTDEVICE* pRawInputDevices,[In] unsigned int uiNumDevices,[In] unsigned int cbSize)</unmanaged>	
        /// <unmanaged-short>RegisterRawInputDevices</unmanaged-short>	
        public static SharpDX.Mathematics.Interop.RawBool RegisterRawInputDevices(SharpDX.RawInput.RawInputDevice[] rawInputDevicesRef, int uiNumDevices, int cbSize) {
            unsafe {
                SharpDX.Mathematics.Interop.RawBool __result__;
                fixed (void* rawInputDevicesRef_ = rawInputDevicesRef)
                    __result__= 
    				RegisterRawInputDevices_(rawInputDevicesRef_, uiNumDevices, cbSize);		
                return __result__;
            }
        }
        [DllImport("user32.dll", EntryPoint = "RegisterRawInputDevices", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern SharpDX.Mathematics.Interop.RawBool RegisterRawInputDevices_(void* arg0,int arg1,int arg2);
        
        /// <summary>	
        /// <p>Performs a buffered read of the raw input data.</p>	
        /// </summary>	
        /// <param name="dataRef"><dd>  <p>A reference to a buffer of <strong><see cref="SharpDX.RawInput.RawInput"/></strong> structures that contain the raw input data. If <strong><c>null</c></strong>, the minimum required buffer, in bytes, is returned in *<em>pcbSize</em>. </p> </dd></param>	
        /// <param name="cbSizeRef"><dd>  <p>The size, in bytes, of a <strong><see cref="SharpDX.RawInput.RawInput"/></strong> structure. </p> </dd></param>	
        /// <param name="cbSizeHeader"><dd>  <p>The size, in bytes, of the <strong><see cref="SharpDX.RawInput.RawInputHeader"/></strong> structure. </p> </dd></param>	
        /// <returns><p>If  <em>pData</em> is <c>null</c> and the function is successful, the return value is zero. If  <em>pData</em> is not <c>null</c> and the function is successful, the return value is the number of <strong><see cref="SharpDX.RawInput.RawInput"/></strong> structures written to  <em>pData</em>.</p><p>If an error occurs, the return value is (<strong>UINT</strong>)-1. Call <strong>GetLastError</strong> for the error code.</p></returns>	
        /// <remarks>	
        /// <p>Using <strong>GetRawInputBuffer</strong>, the raw input data is buffered in the array of <strong><see cref="SharpDX.RawInput.RawInput"/></strong> structures. For an unbuffered read, use the <strong>GetMessage</strong> function to read in the raw input data. </p><p>The <strong>NEXTRAWINPUTBLOCK</strong> macro allows an application to traverse an array of <strong><see cref="SharpDX.RawInput.RawInput"/></strong> structures.</p><p><strong>Note</strong>??To get the correct size of the raw input buffer, do not use *<em>pcbSize</em>, use *<em>pcbSize</em> * 8 instead.   To ensure <strong>GetRawInputBuffer</strong> behaves properly on WOW64, you must align the <strong><see cref="SharpDX.RawInput.RawInput"/></strong> structure by 8 bytes. The following code shows how to align <strong><see cref="SharpDX.RawInput.RawInput"/></strong> for WOW64.  </p><pre>[StructLayout(LayoutKind.Explicit)]	
        /// internal struct <see cref="SharpDX.RawInput.RawInput"/>	
        /// { [FieldOffset(0)] public <see cref="SharpDX.RawInput.RawInputHeader"/> header; [FieldOffset(16+8)] public <see cref="SharpDX.RawInput.RawMouse"/> mouse; [FieldOffset(16+8)] public <see cref="SharpDX.RawInput.RawKeyboard"/> keyboard; [FieldOffset(16+8)] public <see cref="SharpDX.RawInput.RawHid"/> hid;	
        /// }	
        /// </pre>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='GetRawInputBuffer']/*"/>	
        /// <msdn-id>ms645595</msdn-id>	
        /// <unmanaged>unsigned int GetRawInputBuffer([Out, Buffer, Optional] RAWINPUT* pData,[InOut] unsigned int* pcbSize,[In] unsigned int cbSizeHeader)</unmanaged>	
        /// <unmanaged-short>GetRawInputBuffer</unmanaged-short>	
        public static int GetRawInputBuffer(SharpDX.RawInput.RawInput[] dataRef, ref int cbSizeRef, int cbSizeHeader) {
            unsafe {
                SharpDX.RawInput.RawInput[] dataRef__ = dataRef;
                int __result__;
                fixed (void* dataRef_ = dataRef__)
                    fixed (void* cbSizeRef_ = &cbSizeRef)
                        __result__= 
        				GetRawInputBuffer_(dataRef_, cbSizeRef_, cbSizeHeader);		
                return __result__;
            }
        }
        [DllImport("user32.dll", EntryPoint = "GetRawInputBuffer", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern int GetRawInputBuffer_(void* arg0,void* arg1,int arg2);
        
        /// <summary>	
        /// <p>Retrieves the information about the raw input devices for the current application.</p>	
        /// </summary>	
        /// <param name="rawInputDevicesRef"><dd>  <p>An array of <strong><see cref="SharpDX.RawInput.RawInputDevice"/></strong> structures for the application. </p> </dd></param>	
        /// <param name="uiNumDevicesRef"><dd>  <p>The number of <strong><see cref="SharpDX.RawInput.RawInputDevice"/></strong> structures in *<em>pRawInputDevices</em>. </p> </dd></param>	
        /// <param name="cbSize"><dd>  <p>The size, in bytes, of a <strong><see cref="SharpDX.RawInput.RawInputDevice"/></strong> structure. </p> </dd></param>	
        /// <returns><p>If successful, the function returns a non-negative number that is the number of <strong><see cref="SharpDX.RawInput.RawInputDevice"/></strong> structures written to the buffer. </p><p>If the <em>pRawInputDevices</em> buffer is too small or <strong><c>null</c></strong>, the function sets the last error as <strong><see cref="SharpDX.Win32.ErrorCode.InsufficientBuffer"/></strong>, returns -1, and sets <em>puiNumDevices</em> to the required number of devices. If the function fails for any other reason, it returns -1. For more details, call <strong>GetLastError</strong>. </p></returns>	
        /// <remarks>	
        /// <p>To receive raw input from a device, an application must register it by using <strong>RegisterRawInputDevices</strong>. </p>	
        /// </remarks>	
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='GetRegisteredRawInputDevices']/*"/>	
        /// <msdn-id>ms645599</msdn-id>	
        /// <unmanaged>unsigned int GetRegisteredRawInputDevices([Out, Buffer, Optional] RAWINPUTDEVICE* pRawInputDevices,[InOut] unsigned int* puiNumDevices,[In] unsigned int cbSize)</unmanaged>	
        /// <unmanaged-short>GetRegisteredRawInputDevices</unmanaged-short>	
        public static int GetRegisteredRawInputDevices(SharpDX.RawInput.RawInputDevice[] rawInputDevicesRef, ref int uiNumDevicesRef, int cbSize) {
            unsafe {
                SharpDX.RawInput.RawInputDevice[] rawInputDevicesRef__ = rawInputDevicesRef;
                int __result__;
                fixed (void* rawInputDevicesRef_ = rawInputDevicesRef__)
                    fixed (void* uiNumDevicesRef_ = &uiNumDevicesRef)
                        __result__= 
        				GetRegisteredRawInputDevices_(rawInputDevicesRef_, uiNumDevicesRef_, cbSize);		
                return __result__;
            }
        }
        [DllImport("user32.dll", EntryPoint = "GetRegisteredRawInputDevices", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern int GetRegisteredRawInputDevices_(void* arg0,void* arg1,int arg2);
    }
}