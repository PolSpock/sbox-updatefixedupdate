using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Money
{
	public class Money : Component
	{

		[Property] public BoxCollider BoxCollider { get; set; }
		[Property] public Rigidbody Rigidbody { get; set; }

		protected override void OnAwake()
		{
			GameObject.Name = GetType().Name;

			BoxCollider ??= GameObject.Components.GetOrCreate<BoxCollider>();
			BoxCollider.Scale = new Vector3( 200, 200, 100 );
			BoxCollider.IsTrigger = true;

			Rigidbody ??= GameObject.Components.GetOrCreate<Rigidbody>();
			Rigidbody.RigidbodyFlags = RigidbodyFlags.DisableCollisionSounds;
			var physicsLock = new PhysicsLock();
			physicsLock.Pitch = true;
			physicsLock.Yaw = true;
			physicsLock.Roll = true;
			Rigidbody.Locking = physicsLock;
			Rigidbody.Gravity = false;
			Rigidbody.StartAsleep = false;
			Rigidbody.MotionEnabled = true;


			var goChild = new GameObject();
			goChild.SetParent( this.GameObject );
			goChild.Components.Create<ChildMoney>();
		}

	}
}
