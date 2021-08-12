using UnityEngineX;

public static partial class fixMath
{
    public static class Trajectory
    {
        /// <summary>
        /// Given a displacement and a gravity, returns the smallest launch required launch velocity for a projectile.
        /// <para/>
        /// <b>NB:</b> If gravity is 0, the return vector will be 0.
        /// </summary>
        /// <param name="dx">The horizontal displacement. finalPosition.x - startPosition.x</param>
        /// <param name="dy">The vertical displacement. finalPosition.y - startPosition.y</param>
        /// <param name="g">The 2D gravity.</param>
        /// <returns>The smallest launch required launch velocity.</returns>
        public static fix2 SmallestLaunchVelocity(fix dx, fix dy, fix2 g)
        {
            // No gravity ? return 0
            if (lengthsq(g) < global::fix.Epsilon)
                return new fix2(0, 0);

            // Gravity already 1D ? Don't rotate
            if (g.x == 0)
            {
                return SmallestLaunchVelocity(dx, dy, g.y);
            }

            // Rotate all the values so the gravity points downward
            fix gravityAngleAdjustment = angle2d(g) + global::fix.PiOver2;
            fix2x2 rot = fix2x2.Rotate(-gravityAngleAdjustment);

            fix2 d = new fix2(dx, dy);

            d = mul(rot, d);
            g = mul(rot, g);

            fix2 result = SmallestLaunchVelocity(d.x, d.y, g.y);

            // Rotate the result in opposite direction
            return mul(inverse(rot), result);
        }

        /// <summary>
        /// Given a displacement and a gravity, returns the smallest launch required launch velocity for a projectile.
        /// <para/>
        /// <b>NB:</b> If gravity is 0, the return vector will be 0.
        /// </summary>
        /// <param name="dx">The horizontal displacement. finalPosition.x - startPosition.x</param>
        /// <param name="dy">The vertical displacement. finalPosition.y - startPosition.y</param>
        /// <param name="g">The vertical gravity.</param>
        /// <returns>The smallest launch required launch velocity.</returns>
        public static fix2 SmallestLaunchVelocity(fix dx, fix dy, fix g)
        {
            fix angle = AngleForSmallestLaunchVelocity(dx, dy, g);
            fix speed = LaunchSpeed(dx, dy, angle, g);
            return new fix2(cos(angle) * speed, sin(angle) * speed);
        }

        /// <summary>
        /// Given a displacement and a gravity, returns the launch angle of a projectile which will require the smallest launch speed.
        /// </summary>
        /// <param name="dx">The horizontal displacement. finalPosition.x - startPosition.x</param>
        /// <param name="dy">The vertical displacement. finalPosition.y - startPosition.y</param>
        /// <param name="g">The vertical gravity.</param>
        /// <returns>The launch angle of a projectile which will require the smallest launch speed. Between -0.5*PI and 1.5*PI</returns>
        public static fix AngleForSmallestLaunchVelocity(fix dx, fix dy, fix g)
        {
            fix piOver2 = global::fix.PiOver2;

            if (dx == 0)
                return dy > 0
                    ? piOver2
                    : -piOver2;

            fix yOverX = dy / dx;

            if (yOverX == global::fix.MaxValue || yOverX == global::fix.MinValue)
                return dy > 0
                    ? piOver2
                    : -piOver2;

            fix pi = global::fix.Pi;
            fix angle = atan(yOverX);
            fix gSign = sign(g);

            if (dx > 0)
                return remap(piOver2 * gSign, piOver2 * -gSign, 0, piOver2 * -gSign, angle);
            else
                return remap(piOver2 * -gSign, piOver2 * gSign, pi, pi + (piOver2 * gSign), angle);
        }

        /// <summary>
        /// Given a displacement, a launch angle and a gravity, returns the required launch speed of a projectile.
        /// <para/>
        /// <b>NB:</b> If gravity is 0, the return value will be 0.
        /// </summary>
        /// <param name="dx">The horizontal displacement. finalPosition.x - startPosition.x</param>
        /// <param name="dy">The vertical displacement. finalPosition.y - startPosition.y</param>
        /// <param name="angle">The launch angle of the projectile.</param>
        /// <param name="g">The vertical gravity.</param>
        /// <returns>The required launch speed of a projectile.</returns>
        public static fix LaunchSpeed(fix dx, fix dy, fix angle, fix g)
        {
            // No gravity ? return 0
            if (abs(g) < global::fix.Epsilon)
                return 0;

            // With the following formulas, find v
            // dx = v * cos(angle) * t
            // dy = v * sin(angle) * t   +   (g * t^2) / 2

            // get angle sin/cos
            sincos(angle, out fix sin, out fix cos);

            // If cos is close to zero, this means the angle is vertical. To avoid calculation errors, treat the problem in 1D instead
            if (abs(cos) < (fix)0.0001f)
            {
                if (samesign(dy, g))
                {
                    return 0; // no need for any launch speed, the gravity will do all the work
                }
                else
                {
                    // 1D calculation
                    fix t = sqrt(-2 * dy / g);

                    return abs(t) < global::fix.Epsilon
                        ? 0
                        : -sign(g) * (dy - ((fix)0.5f * g * t * t)) / t;
                }
            }

            // 2D calculations
            return dx / (sqrt(2 * (dy - (dx * sin / cos)) / g) * cos);
        }

        public static fix2 Position(fix2 startingPosition, fix2 startVelocity, fix2 gravity, fix time)
        {
            return startingPosition + Displacement(startVelocity, gravity, time);
        }

        public static fix2 Displacement(fix2 startVelocity, fix2 gravity, fix time)
        {
            return time * startVelocity + (time * time * global::fix.Half * gravity);
        }

        public static fix2 Velocity(fix2 startVelocity, fix2 gravity, fix time)
        {
            return startVelocity + (time * gravity);
        }

        public static fix TravelDistance(fix2 velocity, fix2 gravity, fix time)
        {
            // based on this formula:
            // https://www.desmos.com/calculator/erz2yzyffy
            // It's the integral of the velocity function: sqrt((v1 + t*g1)^2 + (v2 + t*g2)^2)

            fix a = velocity.x;
            fix b = velocity.y;
            fix g = gravity.x;
            fix h = gravity.y;
            fix v = a * a + b * b;
            fix p = g * g + h * h;

            if (p <= global::fix.Epsilon)
            {
                return length(velocity) * time;
            }

            if (v <= global::fix.Epsilon)
            {
                return (time / (fix)2f) * sqrt(time * time * lengthsq(gravity));
            }

            fix x = time;

            fix k = 1 / (2 * pow(p, (fix)1.5f));
            fix srp = sqrt(p);
            fix srv = sqrt(v);
            fix ag = a * g;
            fix bh = b * h;
            fix bg = b * g;
            fix ah = a * h;
            fix bgah2 = (bg - ah) * (bg - ah);

            fix c = -k * (srp * (ag + bh) * srv + bgah2 * log(max(srp * srv + ag + bh, (fix)0.0001f)));
            fix longSquareRoot = sqrt(v + (2 * ag * x) + (2 * bh * x) + (p * x * x));
            return k * (srp * (ag + bh + x * p) * longSquareRoot + bgah2 * log(srp * longSquareRoot + ag + bh + g * g * x + h * h * x)) + c;
        }

        /// <summary>
        /// Precision: 0.01
        /// </summary>
        public static fix TravelDurationApprox(fix2 velocity, fix2 gravity, fix traveledDistance)
            => TravelDurationApprox(velocity, gravity, traveledDistance, (fix)0.01);

        public static fix TravelDurationApprox(fix2 velocity, fix2 gravity, fix traveledDistance, fix precision)
        {
            if (traveledDistance <= global::fix.Epsilon) // if distance 0, already reached!
                return 0;

            fix vl2 = lengthsq(velocity);
            fix gl2 = lengthsq(gravity);

            if (vl2 + gl2 < global::fix.Epsilon * 2) // if moving or accelerating to slow, takes infinit time
                return global::fix.MaxValue;


            // Try approximating the needed travel duration. Slowly getting closer to the real value
            // NB: With a precision of 0.01f, results usually take between 8 and 20 iterations
            // WHY ? Why not find the actual formula for this? Because it's hell'a complicated. Try to isolate X in the 'TraveledDistance' formula if you want.

            fix time = 5 + sqrt(traveledDistance / max(gl2, (fix)0.0001f));

            fix radius = time * global::fix.Half;
            bool maxRadiusSet = false;

            int iterations = 0;
            while (radius > precision)
            {
                var dist = Trajectory.TravelDistance(velocity, gravity, time);

                if (dist > traveledDistance)
                {
                    time -= radius;

                    maxRadiusSet = true;
                }
                else
                {
                    if (!maxRadiusSet)
                    {
                        time *= 2;
                        radius *= 2;
                    }
                    else
                    {
                        time += radius;
                    }
                }

                radius *= maxRadiusSet ? global::fix.Half : 1;
                iterations++;
            }

            //Log.Info($"Iterations: {iterations}");

            return time;
        }
    }
}
