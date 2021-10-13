using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class FloatingSystem : SystemBase
{
	protected override void OnUpdate()
	{
		float currentTime = UnityEngine.Time.time;

		Entities.ForEach((ref LocalToWorld localToWorld, in FloatingObjectData floatingObjectData) =>
		{
			Quaternion rotation = localToWorld.Rotation;

			float3 position = localToWorld.Position;
			position.y = (float) Math.Sin(currentTime + position.x);

			localToWorld.Value = new float4x4(rotation, position);
		}).ScheduleParallel();
	}
}
