//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18331
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.17929.
// 
using System.Collections.Generic;
namespace Teraluwide.Blackbird.DataTypes {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://Teraluwide/Blackbird/DataFile")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://Teraluwide/Blackbird/DataFile", IsNullable=false)]
    public partial class GameData {
        
        private List<TileSetType> tileSetListField = new List<TileSetType>();
        
        private List<TextureType> textureListField = new List<TextureType>();
        
        private List<AnimationType> animationListField = new List<AnimationType>();
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
		[System.Xml.Serialization.XmlArrayItemAttribute("TileSet", Namespace = "http://Teraluwide/Blackbird/TileSet", IsNullable = false)]
		public List<TileSetType> TileSetList
		{
			get
			{
				return this.tileSetListField;
			}
			set
			{
				this.tileSetListField = value;
			}
		}
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
		[System.Xml.Serialization.XmlArrayItemAttribute("Texture", Namespace = "http://Teraluwide/Blackbird/Texture", IsNullable = false)]
		public List<TextureType> TextureList
		{
			get
			{
				return this.textureListField;
			}
			set
			{
				this.textureListField = value;
			}
		}
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
		[System.Xml.Serialization.XmlArrayItemAttribute("Animation", Namespace = "http://Teraluwide/Blackbird/Animation", IsNullable = false)]
		public List<AnimationType> AnimationList
		{
			get
			{
				return this.animationListField;
			}
			set
			{
				this.animationListField = value;
			}
		}
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Teraluwide/Blackbird/TileSet")]
    public partial class TileSetType : BaseLeafType {
        
        private string fileField;
        
        private int tileSetWidthField;
        
        private int tileSetHeightField;
        
        private int tileWidthField;
        
        private int tileHeightField;
        
        private int tilesXField;
        
        private int tilesYField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string File {
            get {
                return this.fileField;
            }
            set {
                this.fileField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TileSetWidth {
            get {
                return this.tileSetWidthField;
            }
            set {
                this.tileSetWidthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TileSetHeight {
            get {
                return this.tileSetHeightField;
            }
            set {
                this.tileSetHeightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TileWidth {
            get {
                return this.tileWidthField;
            }
            set {
                this.tileWidthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TileHeight {
            get {
                return this.tileHeightField;
            }
            set {
                this.tileHeightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TilesX {
            get {
                return this.tilesXField;
            }
            set {
                this.tilesXField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TilesY {
            get {
                return this.tilesYField;
            }
            set {
                this.tilesYField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TileSetType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TextureType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AnimationType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Teraluwide/Blackbird/BaseTypes")]
    public partial class BaseLeafType {
        
        private string nameField;
        
        private string contentTypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ContentType {
            get {
                return this.contentTypeField;
            }
            set {
                this.contentTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Teraluwide/Blackbird/Animation")]
    public partial class FrameType {
        
        private int tileXField;
        
        private int tileYField;
        
        private int sequenceField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TileX {
            get {
                return this.tileXField;
            }
            set {
                this.tileXField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TileY {
            get {
                return this.tileYField;
            }
            set {
                this.tileYField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Sequence {
            get {
                return this.sequenceField;
            }
            set {
                this.sequenceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Teraluwide/Blackbird/Texture")]
    public partial class TextureType : BaseLeafType {
        
        private string tileSetField;
        
        private int tileXField;
        
        private int tileYField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TileSet {
            get {
                return this.tileSetField;
            }
            set {
                this.tileSetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TileX {
            get {
                return this.tileXField;
            }
            set {
                this.tileXField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TileY {
            get {
                return this.tileYField;
            }
            set {
                this.tileYField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Teraluwide/Blackbird/Animation")]
    public partial class AnimationType : BaseLeafType {
        
        private List<FrameType> framesField = new List<FrameType>();
        
        private string tileSetField;
        
        private int frameDurationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
		[System.Xml.Serialization.XmlArrayItemAttribute("Frame", IsNullable = false)]
		public List<FrameType> Frames
		{
			get
			{
				return this.framesField;
			}
			set
			{
				this.framesField = value;
			}
		}
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TileSet {
            get {
                return this.tileSetField;
            }
            set {
                this.tileSetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int FrameDuration {
            get {
                return this.frameDurationField;
            }
            set {
                this.frameDurationField = value;
            }
        }
    }
}