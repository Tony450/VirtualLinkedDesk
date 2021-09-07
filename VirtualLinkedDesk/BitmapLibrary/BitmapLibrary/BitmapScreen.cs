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
    public class BitmapScreen : Bitmap {



        //private aqui de GetSystemMetrics

        public BitmapScreen() {

            IntPtr desktop_hwnd = GetDesktopWindow();
            this.hDC = GetDC(desktop_hwnd);

            this.width = (ushort)GetSystemMetrics(SystemMetric.SM_CXVIRTUALSCREEN);
            this.height = (ushort)GetSystemMetrics(SystemMetric.SM_CYVIRTUALSCREEN);
            this.depth = 0;                     //HAY QUE COGERLA DE LA PANTALLA

        }


        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics", SetLastError = true)]
        protected static extern int GetSystemMetrics(SystemMetric smIndex);

        //Cursor

        [DllImport("user32.dll", EntryPoint = "GetCursorInfo", SetLastError = true)]
        protected static extern bool GetCursorInfo(ref CURSORINFO pci);

        [DllImport("user32.dll", EntryPoint = "DrawIconEx", SetLastError = true)]
        protected static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyHeight,
            int istepIfAniCur, IntPtr hbrFlickerFreeDraw, int diFlags);


        unsafe public void copyTo(Bitmap bitmap) {

            CURSORINFO pci = new CURSORINFO { cbSize = sizeof(CURSORINFO) };
            GetCursorInfo(ref pci);

            BitBlt(bitmap.getHDC(), 0, 0, this.width, this.height, this.hDC, 0, 0, (int)TernaryRasterOperations.SRCCOPY);            //Destino, origen

            DrawIconEx(bitmap.getHDC(), pci.ptScreenPos.X, pci.ptScreenPos.Y, pci.hCursor, 0, 0, 0, (IntPtr)null, 0x0003);

        }


        public void copyFrom(Bitmap bitmap) {
            BitBlt(this.hDC, 0, 0, this.width, this.height, bitmap.getHDC(), 0, 0, (int)TernaryRasterOperations.SRCCOPY);            //Destino, origen
        }
    }
}
