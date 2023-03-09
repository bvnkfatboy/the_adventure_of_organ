using UnityEngine;
using System.Collections;
using MoreMountains.Tools;

namespace MoreMountains.InfiniteRunnerEngine
{	

	public class Parallax : MMObjectBounds
	{
		public enum PossibleDirections { Left, Right, Up, Down, Forwards, Backwards };


		public float ParallaxSpeed=0;

		public PossibleDirections ParallaxDirection = PossibleDirections.Left;
		
		protected GameObject _clone;
		protected Vector3 _movement;
		protected Vector3 _initialPosition;
		protected Vector3 _newPosition;
		protected Vector3 _direction;
		protected float _width;


	    protected virtual void Start()
		{
			if (ParallaxDirection==PossibleDirections.Left || ParallaxDirection==PossibleDirections.Right)
			{
				_width = GetBounds().size.x;
				_newPosition = new Vector3(transform.position.x+_width, transform.position.y, transform.position.z);
			}
			if (ParallaxDirection==PossibleDirections.Up || ParallaxDirection==PossibleDirections.Down)
			{
				_width = GetBounds().size.y;
				_newPosition = new Vector3(transform.position.x, transform.position.y+_width, transform.position.z);
			}
			if (ParallaxDirection==PossibleDirections.Forwards || ParallaxDirection==PossibleDirections.Backwards)
			{
				_width = GetBounds().size.z;
				_newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z+_width);
			}

			switch (ParallaxDirection)
			{
				case PossibleDirections.Backwards:
					_direction = Vector3.back;
					break;
				case PossibleDirections.Forwards:
					_direction = Vector3.forward;
					break;
				case PossibleDirections.Down:
					_direction = Vector3.down;
					break;
				case PossibleDirections.Up:
					_direction = Vector3.up;
					break;
				case PossibleDirections.Left:
					_direction = Vector3.left;
					break;
				case PossibleDirections.Right:
					_direction = Vector3.right;
					break;
			}


			_initialPosition=transform.position	;	
		

			_clone = (GameObject)Instantiate(gameObject, _newPosition, transform.rotation);

			Parallax parallaxComponent = _clone.GetComponent<Parallax>();
			Destroy(parallaxComponent);		
		}


	    protected virtual void Update()
		{		

	        if (LevelManager.Instance!= null)
	        { 
				_movement = _direction * (ParallaxSpeed/10) * LevelManager.Instance.Speed * Time.deltaTime;
	        }
	        else
	        {
				_movement = _direction * (ParallaxSpeed / 10) * Time.deltaTime;
	        }
	        _clone.transform.Translate(_movement);
			transform.Translate(_movement);


			if (ShouldResetPosition())
			{
				transform.Translate(-_direction * _width);
				_clone.transform.Translate(-_direction * _width);
			}		
		}

		protected virtual bool ShouldResetPosition()
		{
			switch (ParallaxDirection)
			{
				case PossibleDirections.Backwards:
					if (transform.position.z + _width < _initialPosition.z) { return true; } else { return false; }
				case PossibleDirections.Forwards:
					if (transform.position.z - _width > _initialPosition.z) { return true; } else { return false; }
				case PossibleDirections.Down:
					if (transform.position.y + _width < _initialPosition.y) { return true; } else { return false; }
				case PossibleDirections.Up:
					if (transform.position.y - _width > _initialPosition.y) { return true; } else { return false; }
				case PossibleDirections.Left:
					if (transform.position.x + _width < _initialPosition.x) { return true; } else { return false; }
				case PossibleDirections.Right:
					if (transform.position.x - _width > _initialPosition.x) { return true; } else { return false; }
			}
			return false;
		}
	}
}