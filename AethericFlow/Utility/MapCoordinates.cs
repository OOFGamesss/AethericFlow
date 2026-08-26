using System;

namespace AethericFlow.Utility;

/// <summary>
/// Converts raw map marker positions into the map coordinates shown in game and measures distance between them.
/// </summary>
public static class MapCoordinates
{
    private const float MarkerSpan = 2048f;
    private const float MapSpan = 41f;

    public static (float X, float Y) FromMarker(float markerX, float markerY, float sizeFactor)
    {
        return (ToMapCoordinate(markerX, sizeFactor), ToMapCoordinate(markerY, sizeFactor));
    }

    public static float DistanceBetween(float x1, float y1, float x2, float y2)
    {
        return MathF.Sqrt(MathF.Pow(x2 - x1, 2) + MathF.Pow(y2 - y1, 2));
    }

    private static float ToMapCoordinate(float marker, float sizeFactor)
    {
        return (marker * MapSpan / MarkerSpan / sizeFactor * 100f) + 1f;
    }
}
