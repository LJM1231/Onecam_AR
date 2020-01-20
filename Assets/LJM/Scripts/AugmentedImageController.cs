using GoogleARCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentedImageController : MonoBehaviour
{
    [SerializeField] private AugmentedImageVisualizer _augmentedImageVisualizer;

    private readonly Dictionary<int, AugmentedImageVisualizer> _visualizers =
        new Dictionary<int, AugmentedImageVisualizer>();

    private readonly List<AugmentedImage> _images = new List<AugmentedImage>();


    private void Update()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        Session.GetTrackables(_images, TrackableQueryFilter.Updated);
        VisualizeTrackables();
    }

    private void VisualizeTrackables()
    {
        foreach (var image in _images)
        {
            var visualizer = GetVisualalizer(image);
        }
    }

    private AugmentedImageVisualizer GetVisualalizer(AugmentedImage image)
    {
        AugmentedImageVisualizer visualizer;
        _visualizers.TryGetValue(image.DatabaseIndex, out visualizer);
        return visualizer;
    }
}
