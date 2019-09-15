using Unity.Collections;
using Unity.Entities;

namespace Revolution
{
	public abstract class ComponentSnapshotSystem_Empty<TTag> : EmptySnapshotSystem<ComponentSnapshotSystem_Empty<TTag>, TTag>
		where TTag : IComponentData
	{
		public struct SharedData
		{
		}

		public override NativeArray<ComponentType> EntityComponents =>
			new NativeArray<ComponentType>(1, Allocator.Temp, NativeArrayOptions.UninitializedMemory)
			{
				[0] = typeof(TTag)
			};
	}
	
	public struct ExcludeFromTagging : IComponentData
	{}
	
	public class ComponentSnapshotSystemTag<TTag> : ComponentSnapshotSystem_Empty<TTag>
		where TTag : IComponentData
	{
		public override ComponentType ExcludeComponent => typeof(ExcludeFromTagging);
	}
}