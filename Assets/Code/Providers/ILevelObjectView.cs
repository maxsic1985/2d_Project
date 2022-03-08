using System;
using UnityEngine;

public interface ILevelObjectView
{
    public Action<ILevelObjectView> OnLevelObjectContact { get; set; }
    public Animation Animation { get; set; }
}