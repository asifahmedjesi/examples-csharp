using Examples;
using static Examples.MyInnerBase;

Console.WriteLine("ANOTHER ASSEMBLY");


/**
     * Protected Internal Access
     */
public class DerivedProtectedInternal : MyBase
{
    void Test()
    {
        myPublic = 0;           // allowed (from anywhere)
        myProtected = 0;        // allowed (derived class)
        // myPrivate    = 0;    // inaccessible (defining class only)
        myProtInt = 0;          // allowed (defining assembly or derived class)            
        // myPrivProt   = 0;    // inaccessible (derived class within defining assembly)
        // myInternal   = 0;    // inaccessible (defining assembly)
    }
}


/**
 * Public Access (from anywhere)
 */
public class AnyPublicClass
{
    void Test(MyBase m)
    {
        m.myPublic = 0;             // allowed 
        // m.myProtInt      = 0;    // inaccessible 
        // m.myPrivProt     = 0;    // inaccessible 
        // m.myInternal     = 0;    // inaccessible 
        // m.myProtected    = 0;    // inaccessible 
        // m.myPrivate      = 0;    // inaccessible
    }
}