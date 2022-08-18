using DisplayMqtt.Entities;

namespace DisplayMqtt.DisplayServices
{
    /// <summary>
    /// Interface for display <see cref="DisplayDataEntities"/>.
    /// </summary>
    public interface IDisplayService
    {
        /// <summary>
        /// Displays the given <paramref name="displayData"/>
        /// </summary>
        /// <param name="displayData">A collection of <see cref="DisplayDataEntity"/> as <see cref="DisplayDataEntities"/>too display.</param>
        void Display(DisplayDataEntities displayData);
    }
}
