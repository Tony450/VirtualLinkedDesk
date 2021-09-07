/*****************************************************************************
* Copyright (C) 2021 Antonio Manuel Hernández De León, <tony450.vld@gmail.com>.
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
* 
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
* 
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <https://www.gnu.org/licenses/>.
*****************************************************************************/

using System;
using System.Runtime.InteropServices;

unsafe public struct BITMAPINFO {
    public uint biSize;
    public int biWidth;
    public int biHeight;
    public ushort biPlanes;
    public ushort biBitCount;
    public BitmapCompressionMode biCompression;
    public uint biSizeImage;
    public int biXPelsPerMeter;
    public int biYPelsPerMeter;
    public uint biClrUsed;
    public uint biClrImportant;

    public void Init() {
        biSize = (uint)Marshal.SizeOf(this);
    }
}


public enum BitmapCompressionMode : uint {
    BI_RGB = 0,
    BI_RLE8 = 1,
    BI_RLE4 = 2,
    BI_BITFIELDS = 3,
    BI_JPEG = 4,
    BI_PNG = 5
}


public enum DIB_Color_Mode : uint {                     //Color indexado o directo (paleta o directo). Si la paleta es rgb o hace referencia a un hpallete.

    DIB_RGB_COLORS = 0,                             //Color indexado normal (tabla del otro dia)
    DIB_PAL_COLORS = 1                                  //Paleta gdi
}

public enum TernaryRasterOperations : uint {             //TODO: Fichero aparte

    SRCCOPY = 0x00CC0020,
    SRCPAINT = 0x00EE0086,
    SRCAND = 0x008800C6,
    SRCINVERT = 0x00660046,
    SRCERASE = 0x00440328,
    NOTSRCCOPY = 0x00330008,
    NOTSRCERASE = 0x001100A6,
    MERGECOPY = 0x00C000CA,
    MERGEPAINT = 0x00BB0226,
    PATCOPY = 0x00F00021,
    PATPAINT = 0x00FB0A09,
    PATINVERT = 0x005A0049,
    DSTINVERT = 0x00550009,
    BLACKNESS = 0x00000042,
    WHITENESS = 0x00FF0062,
    CAPTUREBLT = 0x40000000 //only if WinVer >= 5.0.0 (see wingdi.h)
}


public enum SystemMetric : int {
    SM_CXSCREEN = 0,  // 0x00
    SM_CYSCREEN = 1,  // 0x01
    SM_CXVSCROLL = 2,  // 0x02
    SM_CYHSCROLL = 3,  // 0x03
    SM_CYCAPTION = 4,  // 0x04
    SM_CXBORDER = 5,  // 0x05
    SM_CYBORDER = 6,  // 0x06
    SM_CXDLGFRAME = 7,  // 0x07
    SM_CXFIXEDFRAME = 7,  // 0x07
    SM_CYDLGFRAME = 8,  // 0x08
    SM_CYFIXEDFRAME = 8,  // 0x08
    SM_CYVTHUMB = 9,  // 0x09
    SM_CXHTHUMB = 10, // 0x0A
    SM_CXICON = 11, // 0x0B
    SM_CYICON = 12, // 0x0C
    SM_CXCURSOR = 13, // 0x0D
    SM_CYCURSOR = 14, // 0x0E
    SM_CYMENU = 15, // 0x0F
    SM_CXFULLSCREEN = 16, // 0x10
    SM_CYFULLSCREEN = 17, // 0x11
    SM_CYKANJIWINDOW = 18, // 0x12
    SM_MOUSEPRESENT = 19, // 0x13
    SM_CYVSCROLL = 20, // 0x14
    SM_CXHSCROLL = 21, // 0x15
    SM_DEBUG = 22, // 0x16
    SM_SWAPBUTTON = 23, // 0x17
    SM_CXMIN = 28, // 0x1C
    SM_CYMIN = 29, // 0x1D
    SM_CXSIZE = 30, // 0x1E
    SM_CYSIZE = 31, // 0x1F
    SM_CXSIZEFRAME = 32, // 0x20
    SM_CXFRAME = 32, // 0x20
    SM_CYSIZEFRAME = 33, // 0x21
    SM_CYFRAME = 33, // 0x21
    SM_CXMINTRACK = 34, // 0x22
    SM_CYMINTRACK = 35, // 0x23
    SM_CXDOUBLECLK = 36, // 0x24
    SM_CYDOUBLECLK = 37, // 0x25
    SM_CXICONSPACING = 38, // 0x26
    SM_CYICONSPACING = 39, // 0x27
    SM_MENUDROPALIGNMENT = 40, // 0x28
    SM_PENWINDOWS = 41, // 0x29
    SM_DBCSENABLED = 42, // 0x2A
    SM_CMOUSEBUTTONS = 43, // 0x2B
    SM_SECURE = 44, // 0x2C
    SM_CXEDGE = 45, // 0x2D
    SM_CYEDGE = 46, // 0x2E
    SM_CXMINSPACING = 47, // 0x2F
    SM_CYMINSPACING = 48, // 0x30
    SM_CXSMICON = 49, // 0x31
    SM_CYSMICON = 50, // 0x32
    SM_CYSMCAPTION = 51, // 0x33
    SM_CXSMSIZE = 52, // 0x34
    SM_CYSMSIZE = 53, // 0x35
    SM_CXMENUSIZE = 54, // 0x36
    SM_CYMENUSIZE = 55, // 0x37
    SM_ARRANGE = 56, // 0x38
    SM_CXMINIMIZED = 57, // 0x39
    SM_CYMINIMIZED = 58, // 0x3A
    SM_CXMAXTRACK = 59, // 0x3B
    SM_CYMAXTRACK = 60, // 0x3C
    SM_CXMAXIMIZED = 61, // 0x3D
    SM_CYMAXIMIZED = 62, // 0x3E
    SM_NETWORK = 63, // 0x3F
    SM_CLEANBOOT = 67, // 0x43
    SM_CXDRAG = 68, // 0x44
    SM_CYDRAG = 69, // 0x45
    SM_SHOWSOUNDS = 70, // 0x46
    SM_CXMENUCHECK = 71, // 0x47
    SM_CYMENUCHECK = 72, // 0x48
    SM_SLOWMACHINE = 73, // 0x49
    SM_MIDEASTENABLED = 74, // 0x4A
    SM_MOUSEWHEELPRESENT = 75, // 0x4B
    SM_XVIRTUALSCREEN = 76, // 0x4C
    SM_YVIRTUALSCREEN = 77, // 0x4D
    SM_CXVIRTUALSCREEN = 78, // 0x4E
    SM_CYVIRTUALSCREEN = 79, // 0x4F
    SM_CMONITORS = 80, // 0x50
    SM_SAMEDISPLAYFORMAT = 81, // 0x51
    SM_IMMENABLED = 82, // 0x52
    SM_CXFOCUSBORDER = 83, // 0x53
    SM_CYFOCUSBORDER = 84, // 0x54
    SM_TABLETPC = 86, // 0x56
    SM_MEDIACENTER = 87, // 0x57
    SM_STARTER = 88, // 0x58
    SM_SERVERR2 = 89, // 0x59
    SM_MOUSEHORIZONTALWHEELPRESENT = 91, // 0x5B
    SM_CXPADDEDBORDER = 92, // 0x5C
    SM_DIGITIZER = 94, // 0x5E
    SM_MAXIMUMTOUCHES = 95, // 0x5F

    SM_REMOTESESSION = 0x1000, // 0x1000
    SM_SHUTTINGDOWN = 0x2000, // 0x2000
    SM_REMOTECONTROL = 0x2001, // 0x2001


    SM_CONVERTIBLESLATEMODE = 0x2003,
    SM_SYSTEMDOCKED = 0x2004,
}


[StructLayout(LayoutKind.Sequential)]
public struct POINT {
    public int X;
    public int Y;

    public POINT(int x, int y) {
        this.X = x;
        this.Y = y;
    }

    public static implicit operator System.Drawing.Point(POINT p) {
        return new System.Drawing.Point(p.X, p.Y);
    }

    public static implicit operator POINT(System.Drawing.Point p) {
        return new POINT(p.X, p.Y);
    }
}



[StructLayout(LayoutKind.Sequential)]
public struct CURSORINFO {
    public Int32 cbSize;
    public Int32 flags;
    public IntPtr hCursor;
    public POINT ptScreenPos;
}



[StructLayout(LayoutKind.Sequential)]
public struct RECT {
    public int Left, Top, Right, Bottom;

    public RECT(int left, int top, int right, int bottom) {
        Left = left;
        Top = top;
        Right = right;
        Bottom = bottom;
    }

    public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

    public int X {
        get { return Left; }
        set { Right -= (Left - value); Left = value; }
    }

    public int Y {
        get { return Top; }
        set { Bottom -= (Top - value); Top = value; }
    }

    public int Height {
        get { return Bottom - Top; }
        set { Bottom = value + Top; }
    }

    public int Width {
        get { return Right - Left; }
        set { Right = value + Left; }
    }

    public System.Drawing.Point Location {
        get { return new System.Drawing.Point(Left, Top); }
        set { X = value.X; Y = value.Y; }
    }

    public System.Drawing.Size Size {
        get { return new System.Drawing.Size(Width, Height); }
        set { Width = value.Width; Height = value.Height; }
    }

    public static implicit operator System.Drawing.Rectangle(RECT r) {
        return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
    }

    public static implicit operator RECT(System.Drawing.Rectangle r) {
        return new RECT(r);
    }

    public static bool operator ==(RECT r1, RECT r2) {
        return r1.Equals(r2);
    }

    public static bool operator !=(RECT r1, RECT r2) {
        return !r1.Equals(r2);
    }

    public bool Equals(RECT r) {
        return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
    }

    public override bool Equals(object obj) {
        if (obj is RECT)
            return Equals((RECT)obj);
        else if (obj is System.Drawing.Rectangle)
            return Equals(new RECT((System.Drawing.Rectangle)obj));
        return false;
    }

    public override int GetHashCode() {
        return ((System.Drawing.Rectangle)this).GetHashCode();
    }

    public override string ToString() {
        return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
    }
}


namespace BitmapLibrary {
    public abstract class Bitmap {


        protected ushort width;
        protected ushort height;
        protected byte depth;
        protected IntPtr hDC;

        public ushort getWidth() {
            return this.width;
        }

        public ushort getHeight() {
            return this.height;
        }

        public byte getDepth() {
            return this.depth;
        }
        public IntPtr getHDC() {
            return this.hDC;
        }



        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow", SetLastError = true)]
        protected static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", EntryPoint = "GetDC", SetLastError = true)]
        protected static extern IntPtr GetDC(IntPtr ptr);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        protected static extern IntPtr CreateCompatibleDC(IntPtr hDC);        //IntPtr: Entero lo suficientemente grande para alojar un puntero

        [DllImport("gdi32.dll", EntryPoint = "BitBlt", SetLastError = true)]
        protected static extern IntPtr BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC,
            int xSrc, int ySrc, int dwRop);

        [DllImport("gdi32.dll", EntryPoint = "StretchBlt", SetLastError = true)]
        protected static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest,
            int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, 
            TernaryRasterOperations dwRop);

        [DllImport("gdi32.dll", EntryPoint = "DeleteDC", SetLastError = true)]
        protected static extern int DeleteDC(IntPtr hdc);

        [DllImport("user32.dll", EntryPoint = "ReleaseDC", SetLastError = true)]
        protected static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);



    }
}
