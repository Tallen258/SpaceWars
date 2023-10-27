namespace SpaceWars.Logic.Actions;

public class Shoot(Weapon weapon) : GamePlayAction
{
    public Weapon Weapon { get; } = weapon;
    public override int Priority => 2;
    public override ActionResult Execute(Player player, GameMap map)
    {
        if (!player.Ship.Weapons.Contains(Weapon))
            return new ActionResult(false, $"You do not have the {Weapon.Name}");

        if (map.TryHit(player, out var hitResult))
        {
            hitResult!.Value.hitPlayer.Ship.TakeHit(Weapon.Power);
        }

        return new ActionResult(true, $"You fired the {Weapon.Name}");

        //Vector2 heading = new Vector2((float)Math.Cos((double)player.Ship.Heading), (float)Math.Sin((double)player.Ship.Heading));
        //Vector2 toOtherShip = new Vector2 otherShip.Position - player.Ship.Position;
        //float dotProduct = Vector2.Dot(heading, toOtherShip);
        //if (dotProduct > 0)
        //{
        //    // The other ship is in front of you
        //}
        //else if (dotProduct < 0)
        //{
        //    // The other ship is behind you
        //}
        //else
        //{
        //    // The other ship is perpendicular to you
        //}

    }

    //public static bool HitTest(Vector3 from, Vector3 to, Vector2 mouse, UIViewport viewport, float thickness)
    //{
    //    (Vector2 p0, Vector2 p1) = ScreenClipLine(from, to, viewport.mvp);
    //    if (p0 == p1)
    //        return false;
    //    Vector2 size = viewport.size;
    //    Vector2 z0 = p0 * size;
    //    Vector2 z1 = p1 * size;
    //    Vector2 a = mouse - viewport.leftTop;

    //    float d = Vector2.Distance(z1, z0);
    //    float d1 = Vector2.Dot(a - z0, z1 - z0) / d;

    //    if (d1 < 0 || d1 > d)
    //        return false;
    //    float s = Vector2.DistanceSquared(a, z0) - MathF.Pow(d1, 2);

    //    return s <= thickness * thickness;
    //}
}
