namespace GuardiansOfTheCode.Player
{
    public sealed class PrimaryPlayer
    {
        public static PrimaryPlayer Instance { get; }
        private PrimaryPlayer() { }

        /// <summary>
        /// A static  constructor is called only before
        /// the first initialization of a class.
        /// This is perfect for a singleton.
        /// </summary>
        static PrimaryPlayer()
        {
            Instance = new PrimaryPlayer()
            {
                Name = "Raptor",
                Level = 1
            };
        }

        public string Name { get; set; }
        public int Level { get; set; }
    }
}
