public class AsteroidSpawner : Spawner
{
    public override float HorizontalSpacing { get { return 2f; } }
    public override float VerticalRange { get { return 2.8f; } }
    public override string ResourcePath { get { return "Asteroid"; } }
}
