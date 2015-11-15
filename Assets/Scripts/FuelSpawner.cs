public class FuelSpawner : Spawner
{
    public override float HorizontalSpacing { get { return 10f; } }
    public override float VerticalRange { get { return 3.3f; } }
    public override string ResourcePath { get { return "Fuel"; } }
    public override bool FirstSpawnSideToggleValue { get { return true; } }
}
