namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Assets._Project.Develop.Runtime.Gameplay.Features.Tower.IsTower IsTowerC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Tower.IsTower>();

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTower()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Tower.IsTower() );
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Tower.IsPlayerEntity IsPlayerShootEntityC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Tower.IsPlayerEntity>();

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsPlayerShootEntity()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Tower.IsPlayerEntity() );
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team TeamC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams> Team => TeamC.Value;

		public bool TryGetTeam(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider BodyColliderC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public bool TryGetBodyCollider(out UnityEngine.CapsuleCollider value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.CapsuleCollider);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public bool TryGetContactsDetectingMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsColliderBuffer ContactsColliderBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsColliderBuffer>();

		public Assets._Project.Develop.Runtime.Utilies.Buffer<UnityEngine.Collider> ContactsColliderBuffer => ContactsColliderBufferC.Value;

		public bool TryGetContactsColliderBuffer(out Assets._Project.Develop.Runtime.Utilies.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsColliderBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Buffer<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsColliderBuffer(Assets._Project.Develop.Runtime.Utilies.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsColliderBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsEntitiesBuffer ContactsEntitiesBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsEntitiesBuffer>();

		public Assets._Project.Develop.Runtime.Utilies.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> ContactsEntitiesBuffer => ContactsEntitiesBufferC.Value;

		public bool TryGetContactsEntitiesBuffer(out Assets._Project.Develop.Runtime.Utilies.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsEntitiesBuffer(Assets._Project.Develop.Runtime.Utilies.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsEntitiesBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask DeathMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask>();

		public UnityEngine.LayerMask DeathMask => DeathMaskC.Value;

		public bool TryGetDeathMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask IsTouchDeathMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> IsTouchDeathMask => IsTouchDeathMaskC.Value;

		public bool TryGetIsTouchDeathMask(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam IsTouchAnotherTeamC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> IsTouchAnotherTeam => IsTouchAnotherTeamC.Value;

		public bool TryGetIsTouchAnotherTeam(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotateDirection RotateDirectionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotateDirection>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<UnityEngine.Vector3> RotateDirection => RotateDirectionC.Value;

		public bool TryGetRotateDirection(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotateDirection component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotateDirection()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotateDirection() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotateDirection(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotateDirection() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotateSpeed RotateSpeedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotateSpeed>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> RotateSpeed => RotateSpeedC.Value;

		public bool TryGetRotateSpeed(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotateSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotateSpeed()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotateSpeed() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotateSpeed(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotateSpeed() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.CanRotate CanRotateC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.CanRotate>();

		public Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition CanRotate => CanRotateC.Value;

		public bool TryGetCanRotate(out Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.CanRotate component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanRotate(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.CanRotate() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public bool TryGetMoveDirection(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public bool TryGetMoveSpeed(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving IsMovingC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> IsMoving => IsMovingC.Value;

		public bool TryGetIsMoving(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove CanMoveC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove>();

		public Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition CanMove => CanMoveC.Value;

		public bool TryGetCanMove(out Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanMove(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MainHero.IsMainHero IsMainHeroC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MainHero.IsMainHero>();

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMainHero()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MainHero.IsMainHero() );
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationRadius TeleportationRadiusC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationRadius>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> TeleportationRadius => TeleportationRadiusC.Value;

		public bool TryGetTeleportationRadius(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationRadius component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportationRadius()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationRadius() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportationRadius(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationRadius() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationDamage TeleportationDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationDamage>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> TeleportationDamage => TeleportationDamageC.Value;

		public bool TryGetTeleportationDamage(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportationDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationDamage() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportationDamage(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationDamageRadius TeleportationDamageRadiusC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationDamageRadius>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> TeleportationDamageRadius => TeleportationDamageRadiusC.Value;

		public bool TryGetTeleportationDamageRadius(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationDamageRadius component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportationDamageRadius()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationDamageRadius() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportationDamageRadius(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportationDamageRadius() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportCastRequest TeleportCastRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportCastRequest>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single, UnityEngine.Vector3> TeleportCastRequest => TeleportCastRequestC.Value;

		public bool TryGetTeleportCastRequest(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single, UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportCastRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single, UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportCastRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportCastRequest() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single, UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportCastRequest(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single, UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportCastRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportCastEvent TeleportCastEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportCastEvent>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent TeleportCastEvent => TeleportCastEventC.Value;

		public bool TryGetTeleportCastEvent(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportCastEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportCastEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportCastEvent() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportCastEvent(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportCastEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportContactsDetectingEvent TeleportContactsDetectingEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportContactsDetectingEvent>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent TeleportContactsDetectingEvent => TeleportContactsDetectingEventC.Value;

		public bool TryGetTeleportContactsDetectingEvent(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportContactsDetectingEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportContactsDetectingEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportContactsDetectingEvent() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeleportContactsDetectingEvent(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature.TeleportContactsDetectingEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.CurrentEnergy CurrentEnergyC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.CurrentEnergy>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> CurrentEnergy => CurrentEnergyC.Value;

		public bool TryGetCurrentEnergy(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.CurrentEnergy component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentEnergy()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.CurrentEnergy() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentEnergy(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.CurrentEnergy() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.MaxEnergy MaxEnergyC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.MaxEnergy>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> MaxEnergy => MaxEnergyC.Value;

		public bool TryGetMaxEnergy(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.MaxEnergy component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxEnergy()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.MaxEnergy() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxEnergy(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.MaxEnergy() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.EnergyRefillProcessInitialTime EnergyRefillProcessInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.EnergyRefillProcessInitialTime>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> EnergyRefillProcessInitialTime => EnergyRefillProcessInitialTimeC.Value;

		public bool TryGetEnergyRefillProcessInitialTime(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.EnergyRefillProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRefillProcessInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.EnergyRefillProcessInitialTime() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRefillProcessInitialTime(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.EnergyRefillProcessInitialTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.EnergyRefillProcessCurrentTime EnergyRefillProcessCurrentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.EnergyRefillProcessCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> EnergyRefillProcessCurrentTime => EnergyRefillProcessCurrentTimeC.Value;

		public bool TryGetEnergyRefillProcessCurrentTime(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.EnergyRefillProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRefillProcessCurrentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.EnergyRefillProcessCurrentTime() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEnergyRefillProcessCurrentTime(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.EnergyRefillProcessCurrentTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.InEnergyRefillProcess InEnergyRefillProcessC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.InEnergyRefillProcess>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> InEnergyRefillProcess => InEnergyRefillProcessC.Value;

		public bool TryGetInEnergyRefillProcess(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.InEnergyRefillProcess component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInEnergyRefillProcess()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.InEnergyRefillProcess() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInEnergyRefillProcess(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature.InEnergyRefillProcess() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public bool TryGetCurrentHealth(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth MaxHealthC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> MaxHealth => MaxHealthC.Value;

		public bool TryGetMaxHealth(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead IsDeadC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> IsDead => IsDeadC.Value;

		public bool TryGetIsDead(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public bool TryGetDeathProcessInitialTime(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public bool TryGetDeathProcessCurrentTime(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess InDeadProcessC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> InDeadProcess => InDeadProcessC.Value;

		public bool TryGetInDeadProcess(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeadProcess()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeadProcess(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeadProcess() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie MustDieC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie>();

		public Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition MustDie => MustDieC.Value;

		public bool TryGetMustDie(out Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustDie(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease MustSelfReleaseC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease>();

		public Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public bool TryGetMustSelfRelease(out Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustSelfRelease(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath>();

		public System.Collections.Generic.List<UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public bool TryGetDisableCollidersOnDeath(out System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.List<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() { Value = new System.Collections.Generic.List<UnityEngine.Collider>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> BodyContactDamage => BodyContactDamageC.Value;

		public bool TryGetBodyContactDamage(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowRadius BlowRadiusC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowRadius>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> BlowRadius => BlowRadiusC.Value;

		public bool TryGetBlowRadius(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowRadius component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBlowRadius()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowRadius() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBlowRadius(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowRadius() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowDamage BlowDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowDamage>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> BlowDamage => BlowDamageC.Value;

		public bool TryGetBlowDamage(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBlowDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowDamage() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBlowDamage(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowRequest BlowRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowRequest>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<UnityEngine.Vector3> BlowRequest => BlowRequestC.Value;

		public bool TryGetBlowRequest(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBlowRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowRequest() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBlowRequest(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowEvent BlowEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowEvent>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<UnityEngine.Vector3> BlowEvent => BlowEventC.Value;

		public bool TryGetBlowEvent(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBlowEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowEvent() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBlowEvent(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowContactsDetectingEvent BlowContactsDetectingEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowContactsDetectingEvent>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent BlowContactsDetectingEvent => BlowContactsDetectingEventC.Value;

		public bool TryGetBlowContactsDetectingEvent(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowContactsDetectingEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBlowContactsDetectingEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowContactsDetectingEvent() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBlowContactsDetectingEvent(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowContactsDetectingEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowEffectComponent BlowEffectC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowEffectComponent>();

		public UnityEngine.ParticleSystem BlowEffect => BlowEffectC.Value;

		public bool TryGetBlowEffect(out UnityEngine.ParticleSystem value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowEffectComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.ParticleSystem);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBlowEffect(UnityEngine.ParticleSystem value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Blow.BlowEffectComponent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest StartAttackRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public bool TryGetStartAttackRequest(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent StartAttackEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public bool TryGetStartAttackEvent(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack CanStartAttackC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack>();

		public Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition CanStartAttack => CanStartAttackC.Value;

		public bool TryGetCanStartAttack(out Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanStartAttack(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent EndAttackEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public bool TryGetEndAttackEvent(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime AttackProcessInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public bool TryGetAttackProcessInitialTime(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime AttackProcessCurrentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public bool TryGetAttackProcessCurrentTime(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess InAttackProcessC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> InAttackProcess => InAttackProcessC.Value;

		public bool TryGetInAttackProcess(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime AttackDelayTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> AttackDelayTime => AttackDelayTimeC.Value;

		public bool TryGetAttackDelayTime(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent AttackDelayEndEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent AttackDelayEndEvent => AttackDelayEndEventC.Value;

		public bool TryGetAttackDelayEndEvent(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage InstantAttackDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> InstantAttackDamage => InstantAttackDamageC.Value;

		public bool TryGetInstantAttackDamage(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint ShootPointC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint>();

		public UnityEngine.Transform ShootPoint => ShootPointC.Value;

		public bool TryGetShootPoint(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShootPoint(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack MustCancelAttackC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack>();

		public Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition MustCancelAttack => MustCancelAttackC.Value;

		public bool TryGetMustCancelAttack(out Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustCancelAttack(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent AttackCanceledEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent AttackCanceledEvent => AttackCanceledEventC.Value;

		public bool TryGetAttackCanceledEvent(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCanceledEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCanceledEvent(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCanceledEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime AttackCooldownInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> AttackCooldownInitialTime => AttackCooldownInitialTimeC.Value;

		public bool TryGetAttackCooldownInitialTime(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime AttackCooldownCurrentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> AttackCooldownCurrentTime => AttackCooldownCurrentTimeC.Value;

		public bool TryGetAttackCooldownCurrentTime(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown InAttackCooldownC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> InAttackCooldown => InAttackCooldownC.Value;

		public bool TryGetInAttackCooldown(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest TakeDamageRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public bool TryGetTakeDamageRequest(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent TakeDamageEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single> TakeDamageEvent => TakeDamageEventC.Value;

		public bool TryGetTakeDamageEvent(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage CanApplyDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage>();

		public Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition CanApplyDamage => CanApplyDamageC.Value;

		public bool TryGetCanApplyDamage(out Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanApplyDamage(Assets._Project.Develop.Runtime.Utilies.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget CurrentTargetC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget>();

		public Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> CurrentTarget => CurrentTargetC.Value;

		public bool TryGetCurrentTarget(out Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget() { Value = new Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget(Assets._Project.Develop.Runtime.Utilies.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public bool TryGetRigidbody(out UnityEngine.Rigidbody value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Rigidbody);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Common.TransformComponent TransformC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public bool TryGetTransform(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Common.TransformComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Common.TransformComponent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent CharacterControllerC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public bool TryGetCharacterController(out UnityEngine.CharacterController value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.CharacterController);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent() {Value = value});
		}

	}
}
