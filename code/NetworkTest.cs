using Sandbox.Money;

public sealed class NetworkTest : Component
{
	[Property] public CameraComponent Camera { get; set; }

	protected override void OnStart()
	{
		base.OnStart();

		Camera = Game.ActiveScene.GetAllComponents<CameraComponent>().FirstOrDefault();

	}

	protected override void OnUpdate()
	{
		if ( IsProxy )
			return;

		if ( Input.Pressed( "attack1" ) )
		{
			var goMoney = new GameObject();
			goMoney.Components.Create<Money>();

			goMoney.Transform.Position = Transform.Position + Vector3.Up * 64f;
		}

	}

	protected override void OnFixedUpdate()
	{
		if ( IsProxy )
			return;

		if ( Input.Pressed( "attack1" ) )
		{
			var goMoney = new GameObject();
			goMoney.Components.Create<Money>();

			goMoney.Transform.Position = Transform.Position + Vector3.Up * 64f;
		}

	}
}
