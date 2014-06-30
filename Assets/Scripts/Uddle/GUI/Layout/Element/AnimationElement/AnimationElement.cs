using UnityEngine;
using System.Timers;
using Uddle.Observer.Interface;
using Uddle.Dependency.Interface;
using System;

namespace Uddle.GUI.Layout.Element.AnimationElement
{
    class AnimationElement : AbstractGUIElement, IObserver, IDependency
	{
        public event Action<IDependency> OnReleaseEvent;

        protected readonly Sprite[] sprites;
        protected readonly float frameRate = 0;
        protected int lenght = 0;
        protected int current = 0;
        protected float timer = 0;
        protected bool isPlaying = false;
        protected bool isStarted = false;
        protected bool isLoop = true;

        public AnimationElement(Sprite[] sprites, float frameRate = 1.0f) : base()
        {
            this.sprites = sprites;
            this.lenght = sprites.Length;
            this.frameRate = frameRate;
        }

        public void SetLoop(bool loop)
        {
            isLoop = loop;
        }

        public void Play()
        {
            isStarted = true;
        }

        public void Notify()
        {
            if (isStarted == true && isPlaying == false)
            {
                isPlaying = true;
                spriteRenderer.sprite = sprites[current];
            }

            if (isPlaying == false)
            {
                return;
            }

            timer += Time.deltaTime;

            if (timer > frameRate)
            {
                timer = 0;
                NextFrame();

            }
        }

        protected void NextFrame()
        {
            if (current >= lenght - 1)
            {
                FinishAnimation();
            }
            else
            {
                current++;
            }

            spriteRenderer.sprite = sprites[current];
        }

        protected void FinishAnimation()
        {
            if (true == isLoop)
            {
                current = 0;
            }
            else
            {
                isPlaying = false;
                isStarted = false;
                current = 0;
                timer = 0;

                if (null != OnReleaseEvent)
                {
                    OnReleaseEvent(this);
                }
            }
        }

        public override void Disappear()
        {
            base.Disappear();            
        }
	}
}