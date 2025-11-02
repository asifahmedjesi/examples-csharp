/**
 * Events enable an object to notify other objects when something of interest occurs. 
 *      a. The object that raises the event is called the publisher and 
 *      b. The objects that handle the event are called subscribers
 */

namespace Examples;

internal class MyEvents
{
    public static void Run()
    {
        Subscriber s = new Subscriber();
        Publisher p = new Publisher();
        p.ItemAdded += s.ItemAddedEventHandler;
        p.Add(10); // "ItemAddedEvent occurred"
    }
}


#region Publisher

/**
 * To demonstrate the use of events, a publisher will be created first. 
 * This will be a class that inherits from ArrayList, but this version will raise an event whenever an item is added to the list. 
 */
public class Publisher : System.Collections.ArrayList
{
    #region Event Delegate

    /**
     * ## EVENT DELEGATE ##
     * Before the event can be created, a delegate is needed that will hold the subscribers. 
     * This could be any kind of delegate, but the standard design pattern is to use a void delegate that accepts two parameters. 
     * The first parameter specifies the source object of the event, and the second parameter is a type that either is or inherits from the System.EventArgs class. 
     * This parameter usually contains the details of the event, but in this example there is no need to pass any event data, and so the base EventArgs class will be used as the parameter’s type.
     */
    public delegate void EventHandlerDelegate(object sender, System.EventArgs e);

    #endregion

    #region Event

    /**
     * ## EVENT (event Keyword) ##
     * With the delegate defined, the event can be created in the Publisher class using the event keyword followed by the delegate and the name of the event. 
     * The event keyword creates a special kind of delegate that can only be invoked from within the class where it is declared. 
     * Its access level is public so that other classes are allowed to subscribe to this event. 
     * The delegate that follows the event keyword is called the event delegate.
     * Alternatively, in place of this custom event delegate, the predefined System.EventHandler delegate could have been used.
     * This delegate is identical to the one defined previously, and it’s used in the.NET class libraries for creating events that have no event data.
     */
    public event EventHandlerDelegate ItemAdded;

    #endregion

    /**
     * ## EVENT CALLER ##
     * To invoke the event, an event caller can be created.
     * The method has the protected access level to prevent it from being called from an unrelated class, and it is marked as virtual to allow deriving classes to override it.
     * The method will raise the event only if it is not null, meaning only when the event has any registered subscribers.
     */
    protected virtual void ItemOnAdded(System.EventArgs e)
    {
        if (ItemAdded != null) ItemAdded(this, e);
    }

    /** 
     * ## RAISING EVENTS ##
     * Now that the class has an event and a method for calling it, the final step is to override the ArrayList’s Add method to make it raise the event. 
     * In this overridden version of the method, the base class’s Add method is first called, and the result is stored. 
     * The event is then raised with the OnAdded method, by passing to it the Empty field in the System.EventArgs class, which represents an event with no data. 
     * Finally, the result is returned to the caller.
     */
    public override int Add(object value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Value cannot be null");

        int i = base.Add(value);
        ItemOnAdded(System.EventArgs.Empty);

        return i;
    }
}

#endregion

#region Subscriber

public class Subscriber
{
    public void ItemAddedEventHandler(object sender, System.EventArgs e)
    {
        System.Console.WriteLine("Item added and ItemAddedEvent occurred");
    }
}

#endregion