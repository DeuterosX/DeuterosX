﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Graphics;
using Teraluwide.Blackbird.Core.Properties;
using System.IO;
using Tao.OpenGl;
using System.Drawing;
using System.Drawing.Imaging;
using Teraluwide.Blackbird.Core.Gui;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a texture manager item.
	/// </summary>
	public sealed class TextureManagerItem : IDisposable
	{
        /// <summary>
        /// Represents texture internal animation data 
        /// </summary>
        public class AnimationData
        {
            /// <summary>
            /// Gets or set a value indicating number of animation frames
            /// </summary>
            public int AnimationFrames { get; set; }

            /// <summary>
            /// Gets or sets a value of animation time
            /// </summary>
            public int AnimationTime { get; set; }

            /// <summary>
            /// Gets or sets information when animation started
            /// </summary>
            public int AnimationStartedFromTick { get; set; }

            /// <summary>
            /// Contains animation texture ids
            /// </summary>
            public int[] TextureIds;

            public AnimationData(int animationFrames, int animationTime)
            {
                this.AnimationFrames = 0;
                this.AnimationTime = 0;
                this.AnimationStartedFromTick = -1;
                AnimationFrames = animationFrames;
                AnimationTime = animationTime;
                TextureIds = new int[animationFrames];
            }
        }

		private int userCount = 0;
		private TextureManager manager;
		private int textureId;

		/// <summary>
		/// Gets the unique identifier of this texture.
		/// </summary>
		/// <value>The unique identifier of this texture.</value>
		public string Id { get; private set; }

		/// <summary>
		/// Gets the name of the file.
		/// </summary>
		/// <value>The name of the file.</value>
		public string FileName { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this texture should be loaded on game load.
		/// </summary>
		/// <value><c>true</c> if the texture should be loaded when the game loads; otherwise, <c>false</c>.</value>
		public bool OnLoad { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this texture should be loaded on demand.
		/// </summary>
		/// <value><c>true</c> if [on demand]; otherwise, <c>false</c>.</value>
		public bool OnDemand { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether to allow scaling.
		/// </summary>
		/// <value><c>true</c> if scaling is allowed; otherwise, <c>false</c>.</value>
		public bool AllowScaling { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether to track users of this texture. If true and the texture loses all of its users, it is disposed. It may be reloaded
		/// again (on trigger or on demand if applicable).
		/// </summary>
		/// <value><c>true</c> if the texture should maintain its user count; otherwise, <c>false</c>.</value>
		public bool TrackUsers { get; private set; }

		/// <summary>
		/// Gets or sets the texture draw area.
		/// </summary>
		/// <value>The draw area.</value>
		public Rectangle DrawArea { get; private set; }

		/// <summary>
		/// Gets or sets the real size of the texture.
		/// </summary>
		/// <value>The real size of the texture.</value>
		public Size RealSize { get; private set; }

		/// <summary>
		/// Gets or sets the scaling modifier.
		/// </summary>
		/// <value>The scaling modifier.</value>
		public float ScalingModifier { get; private set; }

		RectangleF textureCoordinates;
		/// <summary>
		/// Gets the texture coordinates.
		/// </summary>
		/// <value>The texture coordinates.</value>
		RectangleF TextureCoordinates
		{
			get
			{
				if (textureCoordinates == RectangleF.Empty)
				{
					textureCoordinates = new RectangleF(
							(float)DrawArea.X / (float)RealSize.Width,
							(float)DrawArea.Y / (float)RealSize.Height,
							(float)DrawArea.Width / (float)RealSize.Width,
							(float)DrawArea.Height / (float)RealSize.Height
						);
				}

				return textureCoordinates;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether to enable smooth scaling.
		/// </summary>
		/// <value><c>true</c> if smooth scaling is enabled; otherwise, <c>false</c>.</value>
		public bool SmoothScale { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether texture is animation
        /// </summary>
        public bool IsAnimation { get; private set; }

        /// <summary>
        /// Gets or sets animation data
        /// </summary>
        public AnimationData Animation { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TextureManagerItem"/> class.
		/// </summary>
		/// <param name="manager">The manager.</param>
		/// <param name="id">The id.</param>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="onLoad">if set to <c>true</c> the texture will be loaded immediately.</param>
		/// <param name="onDemand">if set to <c>true</c> the texture will be loaded on demand.</param>
		/// <param name="trackUsers">if set to <c>true</c> the texture will have its users tracked.</param>
		public TextureManagerItem(TextureManager manager, string id, string fileName, bool onLoad, bool onDemand, bool trackUsers, Rectangle drawArea, bool smoothScale, bool allowScaling, float scalingModifier, int animationFrames, int animationTime)
		{
			this.manager = manager;
			this.Id = id;
			this.FileName = fileName;
			this.OnLoad = onLoad;
			this.OnDemand = onDemand;
			this.TrackUsers = trackUsers;
			this.DrawArea = drawArea;
			this.SmoothScale = smoothScale;
			this.AllowScaling = allowScaling;
			this.ScalingModifier = scalingModifier;

            if (animationFrames > 0)
            {
                IsAnimation = true;
                this.Animation = new AnimationData(animationFrames, animationTime);
            }
            else
                IsAnimation = false;
            
		}

		/// <summary>
		/// Gets the texture.
		/// </summary>
		/// <value>The texture.</value>
		public int TextureId
		{
			get
			{
                if (IsAnimation)
                {
                    
                    if (Animation.AnimationStartedFromTick == -1)
                        Animation.AnimationStartedFromTick = Environment.TickCount;
                    int frame = ((Environment.TickCount - Animation.AnimationStartedFromTick) / Animation.AnimationTime) % Animation.AnimationFrames;                   

                    if (!OnDemand)
                        throw new BlackbirdException(string.Format(Resources.TextureNotLoaded, Id));

                    if (Animation.TextureIds[frame] == 0)
                        LoadTexture(true);

                    if (Animation.TextureIds[frame] == 0)
                        throw new BlackbirdException(string.Format(Resources.TextureCouldNotBeLoaded, Id));

                    return Animation.TextureIds[frame];
                }
                else
                {
                    if (textureId != 0)
                        return textureId;

                    if (!OnDemand)
                        throw new BlackbirdException(string.Format(Resources.TextureNotLoaded, Id));

                    LoadTexture(true);

                    if (textureId == 0)
                        throw new BlackbirdException(string.Format(Resources.TextureCouldNotBeLoaded, Id));

                    return textureId;
                }
			}
		}

		/// <summary>
		/// Adds a user to the user counter.
		/// </summary>
		public void AddUser()
		{
			userCount++;
		}

		/// <summary>
		/// Removes a user from the user counter.
		/// </summary>
		public void RemoveUser()
		{
			userCount--;

			if (userCount < 0)
				throw new BlackbirdException(string.Format(Resources.TextureUserOverflow, Id));

			if (userCount == 0 && TrackUsers)
				Dispose();
		}

		/// <summary>
		/// Loads the texture.
		/// </summary>
		/// <param name="forced">if set to <c>true</c> the texture is reloaded even if it is already loaded.</param>
		public void LoadTexture(bool forced)
		{
			if (!forced && this.textureId != 0)
				return;

			Dispose();

			using (Stream stream = VirtualPathProvider.GetFile(VirtualPathProvider.EnsureModVirtualPath(FileName, manager.Game.ModName)))
			{
				Image buf = Image.FromStream(stream);
				Bitmap bmp;
				if (buf is Bitmap)
					bmp = buf as Bitmap;
				else
				{
					bmp = new Bitmap(buf.Width, buf.Height, PixelFormat.Format32bppArgb);
					using (Graphics gr = Graphics.FromImage(bmp))
					{
						gr.DrawImage(buf, 0, 0);
					}
					buf.Dispose();
				}

                if (IsAnimation)
                {
                    for (int i = 0; i < Animation.AnimationFrames; ++i)
                    {
                        // Lock the bitmap data of the texture.
                        int width = bmp.Width / Animation.AnimationFrames;
                        BitmapData data = bmp.LockBits(new Rectangle(width*i, 0, width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                        LoadTexture(data, i);

                        bmp.UnlockBits(data);   
                    }
                    bmp.Dispose();
                }
                else
                {
                    // Lock the bitmap data of the texture.
                    BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                    LoadTexture(data);

                    bmp.UnlockBits(data);
                    bmp.Dispose();
                }
				
			}
		}

		/// <summary>
		/// Loads the texture using the specified BitmapData (in 32bit ARGB format).
		/// </summary>
		/// <param name="data">The data.</param>
		public void LoadTexture(BitmapData data)
		{
			this.textureId = LoadTexture(data.Width, data.Height, data.Scan0);
		}

        /// <summary>
        /// Loads the texture using the specified BitmapData (in 32bit ARGB format). Version for animations.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="frame">Animation frame number</param>
        public void LoadTexture(BitmapData data, int frame)
        {
            this.Animation.TextureIds[frame] = LoadTexture(data.Width, data.Height, data.Scan0);
        }

		/// <summary>
		/// Loads the texture using the specified pointer to bitmap data. Texture ID is saved to this.textureId and it is also returned by function.
		/// </summary>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		/// <param name="data">The data.</param>
        /// <returns>Texture ID</returns>
		public int LoadTexture(int width, int height, IntPtr data)
		{
			// Update meta information about the texture
			RealSize = new Size(width, height);
			if (DrawArea == Rectangle.Empty)
				DrawArea = new Rectangle(new Point(0, 0), RealSize);

			// Create a new unique OpenGL texture id.
			int[] texids = new int[1];
			Gl.glGenTextures(1, texids);
			this.textureId = texids[0];

			// Load the texture.
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, this.textureId);
			Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, width, height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, data);

			Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, SmoothScale ? Gl.GL_LINEAR : Gl.GL_NEAREST);
			Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, SmoothScale ? Gl.GL_LINEAR : Gl.GL_NEAREST);
			Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_CLAMP);
			Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_CLAMP);

            return this.textureId;
		}

		/// <summary>
		/// Draws this texture to the specified area using the specified repeat style.
		/// </summary>
		/// <param name="x">The x-coordinate.</param>
		/// <param name="y">The y-coordinate.</param>
		/// <param name="w">The width of the area.</param>
		/// <param name="h">The height of the area.</param>
		/// <param name="repeat">The repeat style.</param>
		public void Draw(int x, int y, int w, int h, GuiRepeatStyle repeat)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Draws this texture to the specified coordinates.
		/// </summary>
		/// <param name="x">The x-coordinate.</param>
		/// <param name="y">The y-coordinate.</param>
		public void Draw(int x, int y)
		{
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glPushMatrix();
			Gl.glLoadIdentity();

			if (AllowScaling)
			{
				if (ScalingModifier == 1)
					Gl.glScalef(manager.Game.Scale, manager.Game.Scale, 1);
				else
				{
					float scale = (float)manager.Game.Scale * ScalingModifier;
					Gl.glScalef(scale, scale, 1);
				}
			}

			Gl.glTranslatef(x, y, 0);

			Gl.glBindTexture(Gl.GL_TEXTURE_2D, TextureId);

			RectangleF texCoords = TextureCoordinates;
			Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
			Gl.glBegin(Gl.GL_QUADS);
			Gl.glTexCoord2f(texCoords.Left, texCoords.Top); Gl.glVertex3f(DrawArea.Left, DrawArea.Top, 0);
			Gl.glTexCoord2f(texCoords.Right, texCoords.Top); Gl.glVertex3f(DrawArea.Right, DrawArea.Top, 0);
			Gl.glTexCoord2f(texCoords.Right, texCoords.Bottom); Gl.glVertex3f(DrawArea.Right, DrawArea.Bottom, 0);
			Gl.glTexCoord2f(texCoords.Left, texCoords.Bottom); Gl.glVertex3f(DrawArea.Left, DrawArea.Bottom, 0);
			Gl.glEnd();

			Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
			Gl.glPopMatrix();
		}

        /// <summary>
        /// Resets animation
        /// </summary>
        public void ResetAnimation()
        {
            if (IsAnimation)
                Animation.AnimationStartedFromTick = -1;
        }

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			if (this.textureId != 0)
			{
				Gl.glDeleteTextures(1, new int[] { textureId });

				this.textureId = 0;
			}
		}

		#endregion
	}
}
