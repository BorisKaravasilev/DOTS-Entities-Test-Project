using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct FloatingObjectData : IComponentData
{
	public float speed;
}