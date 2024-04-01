using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackingImage : MonoBehaviour
{
    [SerializeField] private GameObject imageCreater;
    [SerializeField] private Vector3 imageOffset;

    private GameObject _ColaCans;
    private ARTrackedImageManager _imageTracker;

    // Start is called before the first frame update
    private void OnEnable()
    {
        _imageTracker = GetComponent<ARTrackedImageManager>();
        _imageTracker.trackedImagesChanged += OnImageChanged;

    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs image)
    {
        foreach (ARTrackedImage i in image.added)
        {
            _ColaCans = Instantiate(imageCreater, i.transform);
            _ColaCans.transform.position += imageOffset;
        }
    }
}
