﻿using UnityEngine;

public interface IProtector
{
    void StartProtection(GameObject invader);
    void FinishProtection(GameObject invader);
}