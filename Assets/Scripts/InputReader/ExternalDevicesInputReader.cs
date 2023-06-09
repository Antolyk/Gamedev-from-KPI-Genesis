﻿using Core.Services.Updater;
using InputReader;
using System;
using UnityEngine;

public class ExternalDevicesInputReader : IEntityInputSource, IDisposable
{
    public float HorizontalDirection => Input.GetAxisRaw("Horizontal");
    public bool Jump { get; private set; }

    public ExternalDevicesInputReader()
    {
        ProjectUpdater.Instance.UpdateCalled += OnUpdate;
    }

    public void Dispose() => ProjectUpdater.Instance.UpdateCalled -= OnUpdate;

    public void ResetOneTimeActions() => Jump = false;

    private void OnUpdate()
    {
        if (Input.GetButtonDown("Jump"))     
            Jump = true;
    }
}

 