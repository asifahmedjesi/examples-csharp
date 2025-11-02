using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

public class Base 
{ 
    public Base(int a) 
    {
        
    } 
}

// public class Derived : Base { } // compile-time error

public class Derived : Base 
{ 
    Derived(int a) : base(a) 
    {
        
    } 
}

public class Fruit { }
public class Apple : Fruit { }
public class Banana : Fruit { }