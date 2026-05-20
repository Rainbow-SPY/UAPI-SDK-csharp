using System;
using System.Windows.Forms;

namespace UAPI
{
    /// <summary/>
    public class Joker
    {
        public class 对象
        {
            public 对象()
            {

            }

            public void 分手() => Environment.Exit(-520);

            public bool 复合 => false;

            /// <summary>
            /// 释放不掉的对象, 让它自己去死吧
            /// </summary>
            public void Dispose() => this.Dispose();
        }
    }

    public class Heart
    {
        public static bool IsStuilRunning => false;

        public static void Wait()
        {

        }
    }
}
