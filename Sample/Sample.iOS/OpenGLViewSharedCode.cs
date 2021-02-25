﻿using System;
using OpenTK.Graphics.ES30;
using Sample.Helpers;
using Sample.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenGLViewSharedCode))]
namespace Sample.iOS
{
    public class OpenGLViewSharedCode : IOpenGLViewSharedCode
    {
        DateTime startTime = DateTime.Now;

        public void RenderLoop(Rectangle rect)
        {
            // Seconds since the program started
            double seconds = (DateTime.Now - startTime).TotalSeconds;

            // t from 0 to 1 every 5 seconds
            double t = (seconds % 5) / 5;

            // Find a Xamarin.Forms color
            Color color = Color.FromHsla(t, 1.0, 0.5, 1.0);

            // Set background color using OpenGL
            GL.ClearColor((float)color.R, (float)color.G, (float)color.B, 1.0f);
            GL.Clear((ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit));
        }
    }
}
