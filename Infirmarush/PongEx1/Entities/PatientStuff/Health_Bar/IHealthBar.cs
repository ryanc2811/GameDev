using Microsoft.Xna.Framework;


namespace PongEx1.Entities.PatientStuff.Health_Bar
{
    /// <summary>
    /// Interface for the health bar, which represents the amount of health a patient has
    /// </summary>
    public interface IHealthBar
    {
        /// <summary>
        /// Updates the colour and scale of the health bar with the passed value
        /// </summary>
        /// <param name="health"></param>
        void UpdateHealth(double health);
        /// <summary>
        /// Gets the start position of the health bar
        /// </summary>
        Vector2 StartPos { get; }
    }
}
