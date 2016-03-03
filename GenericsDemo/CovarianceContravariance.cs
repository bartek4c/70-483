using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    #region Covariance

    //Auto and Sedan case
    //
    //http://www.codeproject.com/Articles/72467/C-4-0-Covariance-And-Contravariance-In-Generics
    //
    //variance - relation between a generic type definition and a particular generic type parameter
    //Base >= Derived
    //
    //OUT generic modifier

    public class Covariance
    {
        public Covariance()
        {
            //error
            //covariant [0] - string >= string
            //not covariant [1] - string < object

            object[] objectArray = new string[] { "string 1", "string 2" };
            objectArray[0] = "string 3";
            objectArray[1] = new object();
        }
        
    }

    public interface IEnumerable<out T>
    {
        IEnumerator<T> GetEnumerator; //method returning value
    }

    public interface IEnumerator<out T>
    {
        T Current { get; } //readolny
        bool MoveNext();
    }

    #endregion
    #region Contravariance

    public class Contravariance
    {

    }

    public interface IComparer<in T>
    {
        int Compare(T x, T y);
    }

    #endregion

    /* http://stackoverflow.com/questions/245607/how-is-generic-covariance-contra-variance-implemented-in-c-sharp-4-0
     * 
     * 
     * Variance will only be supported in a safe way - in fact, using the abilities that the CLR 
     * already has. So the examples I give in the book of trying to use a List<Banana> as a 
     * List<Fruit> (or whatever it was) still won't work - but a few other scenarios will.
     * 
     * Firstly, it will only be supported for interfaces and delegates.
     * 
     * Secondly, it requires the author of the interface/delegate to decorate the type parameters 
     * as in (for contravariance) or out (for covariance). The most obvious example is 
     * IEnumerable<T> which only ever lets you take values "out" of it - it doesn't let you add new ones. 
     * That will become IEnumerable<out T>. That doesn't hurt type safety at all, but lets you return 
     * an IEnumerable<string> from a method declared to return IEnumerable<object> for instance.
     * 
     * Contravariance is harder to give concrete examples for using interfaces, 
     * but it's easy with a delegate. Consider Action<T> - that just represents a 
     * method which takes a T parameter. It would be nice to be able to convert 
     * seamlessly use an Action<object> as an Action<string> - any method which takes an 
     * object parameter is going to be fine when it's presented with a string instead. 
     * Of course, C# 2 already has covariance and contravariance of delegates to some extent, 
     * but via an actual conversion from one delegate type to another (creating a new instance) - 
     * see P141-144 for examples. C# 4 will make this more generic, and (I believe) will 
     * avoid creating a new instance for the conversion. (It'll be a reference conversion instead.)
     * 
     */
}
