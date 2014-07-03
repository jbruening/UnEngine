using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public struct Rect
    {
        public Rect (float left, float top, float width, float height)
        {
            x = left;
            y = top;
            this.width = width;
            this.height = height;
        }

        public float x;
        public float y;
        public float width;
        public float height;

        public float xMin { 
            get { return x; } 
            set { x = value; } 
        }
        public float xMax { 
            get { return x + width; } 
            set { width = value - x; } 
        }
        public float yMin { 
            get { return y; } 
            set { y = value; } 
        }
        public float yMax {
            get { return y + width; }
            set { width = value - y; }
        }

        public Vector2 center 
        {
            get
            {
                return new Vector2 ((x + width) / 2, (y + width) / 2);
            }
        }

        // TODO Contains, Set, ToString, MinMaxRect, operator==, operator!=
    }
}
