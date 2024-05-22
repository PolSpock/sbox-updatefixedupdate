using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Money
{
	public class ChildMoney : Component
	{
		[Property] public ModelRenderer ModelRenderer { get; set; }
		[Property] public BoxCollider BoxCollider { get; set; }

		protected override void OnAwake()
		{
			GameObject.Name = GetType().Name;

			GameObject.Tags.Add( "money" );

			Transform.LocalRotation = Rotation.FromPitch( 90f );
			// If the GameObject is created in `OnFixedUpdate()`, Clear Interpolation must be called
			//Transform.ClearInterpolation();

			ModelRenderer ??= GameObject.Components.GetOrCreate<ModelRenderer>();
			ModelRenderer.Model = Cloud.Model( "facepunch/cereal_closed" );

			BoxCollider ??= GameObject.Components.GetOrCreate<BoxCollider>();
			BoxCollider.Scale = new Vector3( 100f );

		}

		protected override void OnUpdate()
		{
			Log.Info( Transform.LocalRotation.Angles() );

			float spinAmount = 100f * Time.Delta;

			Transform.LocalRotation = Transform.LocalRotation.RotateAroundAxis( Vector3.Forward, spinAmount );
		}

	}
}
