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
using static BitmapLibrary.Utils;

namespace BitmapLibrary {

    public class BitmapOffScreen : Bitmap {

        private IntPtr p;
        private IntPtr hBitmap;

        unsafe public BitmapOffScreen(ushort width, ushort height, byte depth) {

            this.width = width;
            this.height = height;
            this.depth = depth;

            this.hDC = CreateCompatibleDC((IntPtr)null);

            BITMAPINFO info = new BITMAPINFO {biSize = (uint)sizeof(BITMAPINFO), biWidth = width, biHeight = -height, biPlanes = 1, biBitCount = depth,
                biCompression = (uint)BitmapCompressionMode.BI_RGB, biSizeImage = (uint)getSize(), biXPelsPerMeter = 0, biYPelsPerMeter = 0, 
                biClrUsed = 0, biClrImportant = 0};


            this.hBitmap = CreateDIBSection(IntPtr.Zero, ref info, 0, out this.p, IntPtr.Zero, 0);             //Para poder escribir en el bitmap (esa zona de memoria)
            SelectObject(this.hDC, this.hBitmap);

        }

        [DllImport("gdi32.dll", EntryPoint = "CreateDIBSection")]
        private static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO pbmi, uint iUsage, out IntPtr ppvBits,
            IntPtr hSection, uint dwOffset);

        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        private static extern IntPtr SelectObject(IntPtr hDC, IntPtr h);     //Cambia el objeto activo (cambia el lienzo (una cosa del DC concreta))

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]               //Para el bitmap
        private static extern bool DeleteObject(IntPtr hObject);


        public IntPtr getData() {
            return this.p;
        }

        public IntPtr getHBitmap() {
            return this.hBitmap;
        }


        public int getSize() {
            return this.width * this.height * (this.depth/ 8);
        }


        public void copyTo(Bitmap bitmap) {
            BitBlt(bitmap.getHDC(), 0, 0, this.width, this.height, this.hDC, 0, 0, (int)TernaryRasterOperations.SRCCOPY);            //Destino, origen
        }

        public void copyTo(IntPtr canvas_dc, int width, int height) {
            StretchBlt(canvas_dc, 0, 0, width, height, this.hDC, 0, 0, this.width, this.height, TernaryRasterOperations.SRCCOPY);
        }


        public void copyFrom(Bitmap bitmap) {
            BitBlt(this.hDC, 0, 0, this.width, this.height, bitmap.getHDC(), 0, 0, (int)TernaryRasterOperations.SRCCOPY);            //Destino, origen
        }

    }

}
