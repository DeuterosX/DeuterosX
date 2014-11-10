using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teraluwide.Blackbird.DataTypes
{
    /// <summary>
    /// This is the base class from which each main content type class inherits. It contains two members, Name and ContentType, which all main content type classes use.
    /// 
    /// The serializable part of the class is defined in DataFileSerializableClasses.cs.
    /// </summary>
    public partial class BaseLeafType
    {
        public override string ToString()
        {
            return ContentType + "." + nameField;
        }
    }
}
