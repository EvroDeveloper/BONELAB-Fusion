﻿using Il2CppSLZ.Marrow;
using Il2CppSLZ.Marrow.Interaction;

namespace LabFusion.Entities;

public class RigPhysics
{
    private readonly MarrowEntity _entity = null;

    public RigPhysics(RigManager rigManager)
    {
        _entity = rigManager.physicsRig.marrowEntity;
    }

    public void CullPhysics(bool isInactive)
    {
        bool isEnabled = !isInactive;
        _entity.EnableColliders(isEnabled);
    }
}
