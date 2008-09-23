#region File Description
//-----------------------------------------------------------------------------
// Camera2D.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
#endregion

namespace SandTileEngine
{
    /// <summary>
    /// Basic 2D camera
    /// </summary>
    public class Camera
    {
        #region Fields

        public Vector2 position = Vector2.Zero;
        private float zoom = 1f;

        #endregion

        #region Constants

        public const float cMinZoom = 0.2f;
        public const float cMaxZoom = 2.0f;

        #endregion

        #region Public Properties

        /// <summary>
        /// Get/Set the zoom value of the camera
        /// </summary>
        public float Zoom
        {
            set 
            { 
                zoom = MathHelper.Clamp(value, cMinZoom, cMaxZoom); 
            }
            get { return zoom; }
        }

        #endregion
    }
}