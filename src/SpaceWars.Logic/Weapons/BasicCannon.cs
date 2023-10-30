namespace SpaceWars.Logic.Weapons;

public class BasicCannon : Weapon
{
    public BasicCannon() : base("Basic Cannon")
    {
        Ranges = [new WeaponRange(20, 100)];
        Power = 50;
        Cost = 200;
        ShotCost = 25;
        ChargeTurns = 1;
    }

    public override void Fire(Player player, GameMap map)
    {
        throw new NotImplementedException();
    }
}

/*
    public bool TryHit(Player player, out (Player hitPlayer, int distance)? result)
    {
        Vector2 pLocation = new Vector2(player.Ship.Location.X, player.Ship.Location.Y);
        Vector2 pHeading = new Vector2((float)Math.Cos(player.Ship.Heading), (float)Math.Sin(player.Ship.Heading));
        foreach (var otherPlayer in players)
        {
            var otherLocation = new Vector2(otherPlayer.Ship.Location.X, otherPlayer.Ship.Location.Y);
            var distance = (int)Vector2.Distance(pLocation, otherLocation);
        }

        result = null;
        return false;
    }


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

*/
