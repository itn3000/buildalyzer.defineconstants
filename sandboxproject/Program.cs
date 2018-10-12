using System;

namespace sandboxproject
{
    #if DEF1
    public class X1
    {
        // this should be included because DEF1 defined in csproj
    }
    #endif
    #if DEF2
    public class X2
    {
        // this should not be included 
    }
    #endif
    public class X3
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
