namespace ClockMqtt.Builders
{
    public interface IBuilder<TBuilder, TTarget>
        where TBuilder : class
        where TTarget : class
    {
        
        /// <summary>
        /// Gets an object of type <typeparamref name="TTarget"/>.</typeparam>.
        /// </summary>
        TTarget Create { get; }

        /// <summary>
        /// Resets the values of the builder type <typeparamref name="TBuilder"></typeparam>.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the object to reset values.</typeparam>
        TBuilder Reset { get; }
    }
}
