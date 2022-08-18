namespace ClockMqtt.Builders
{
    /// <summary>
    /// Interface for builder classes.
    /// </summary>
    /// <typeparam name="TBuilder">The <see cref="Type"/> of the builder.</typeparam>
    /// <typeparam name="TTarget">The <see cref="Type"/> of the object it wil build.</typeparam>
    public interface IBuilder<TBuilder, TTarget>
        where TBuilder : class
        where TTarget : class
    {
        
        /// <summary>
        /// Gets an object of type <typeparamref name="TTarget"/>.
        /// </summary>
        TTarget Create { get; }

        /// <summary>
        /// Gets an object of type <typeparamref name="TBuilder"/> with default values.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the object to reset values.</typeparam>
        TBuilder Reset { get; }
    }
}
