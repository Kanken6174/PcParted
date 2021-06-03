using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PcGUI.PicturePersistance
{
    [Serializable]
    public class PicPers : ISerializable
    {
        Dictionary<string, BitmapImage> ToPersist;
        public PicPers(Dictionary<string, BitmapImage> toPersist)
        {
            ToPersist = toPersist;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
        }
    }
}
