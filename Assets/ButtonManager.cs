using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Vector3 targetPos, originalPos, originalScale, originalRotation;
    public Vector3 targetSize;
    public Vector3 originalDropScale;
    public Vector3 originalDropPosition;
    public Vector3 originalSlideScale;
    public Vector3 originalFlyPosition;
    public Vector2 flip;

    public GameObject targetGameObj;
    public Image leaf;

    public float moveSpeed;
    public float scaleSpeed;
    public float fadeDuration;
    public float flipDuration;
    public float flipFadeDuration;
    public float dropScale;
    public float dropDuration;
    public Vector3 dropPosition;
    public Vector3 flyPosition;
    public float flyDuration;

    private bool isScaled = true;
    private bool isZoomed = true;
    private bool isFaded = true;
    private bool isFlipped = true;
    private bool isDropped = true;
    private bool isFlew = true;

    //SLIDE
    public void ScaleTween()
    {
        targetGameObj.transform.DOScale(targetPos, moveSpeed).SetEase(Ease.InOutSine);
        fadeDuration = 0.25f;
        leaf.DOFade(0, fadeDuration).SetEase(Ease.InOutSine);
    }
    public void ScaleTweenClick()
    {
        if (isScaled)
        {
            ScaleTween();
            isScaled = false;
        }
        else
        {
            ReturnSlide();
            isScaled = true;
        }
    }
    public void ReturnSlide()
    {
        targetGameObj.transform.DOScale(originalScale, moveSpeed).SetEase(Ease.InOutSine);
        fadeDuration = 0.25f;    
        leaf.DOFade(1, fadeDuration).SetEase(Ease.InOutSine);
    }

    //ZOOM
    public void ZoomTween()
    {
        targetGameObj.transform.DOScale(Vector3.zero, scaleSpeed).SetEase(Ease.InOutSine);
    }
    public void ZoomTweenClick()
    {
        if (isZoomed)
        {
            ZoomTween();
            isZoomed = false;
        }
        else
        {
            ReturnPosScale();
            isZoomed = true;
        }
    }
    public void ReturnPosScale()
    {
        targetGameObj.transform.DOScale(originalScale, scaleSpeed).SetEase(Ease.InOutSine);
    }

    //FADE
    public void FadeTween()
    {
        fadeDuration = .5f;
        leaf.DOFade(0, fadeDuration).SetEase(Ease.InOutSine);
    }
    public void FadeTweenClick()
    {
        if (isFaded)
        {
            FadeTween();
            isFaded = false;
        }
        else
        {
            ReturnFade();
            isFaded = true;
        }
    }
    public void ReturnFade()
    {
        fadeDuration = .5f;
        leaf.DOFade(1, fadeDuration).SetEase(Ease.InOutSine);
    }

    //FLY
    public void FlyTween()
    {
        targetGameObj.transform.DOLocalMove(flyPosition, flyDuration).SetEase(Ease.InBack);
    }
    public void FlyTweenClick()
    {
        if (isFlew)
        {
            FlyTween();
            isFlew = false;
        }
        else
        {
            ReturnFly();
            isFlew = true;
        }
    }
    public void ReturnFly()
    {
        targetGameObj.transform.DOLocalMove(originalFlyPosition, flyDuration).SetEase(Ease.OutBack);
    }

    //FLIP
    public void FlipTween()
    {
        targetGameObj.transform.DORotate(flip, flipDuration).SetEase(Ease.InOutSine);
        fadeDuration = 1f;
        leaf.DOFade(0, flipFadeDuration).SetEase(Ease.InOutSine);
    }
    public void FlipTweenClick()
    {
        if (isFlipped)
        {
            FlipTween();
            isFlipped = false;
        }
        else
        {
            returnFlip();
            isFlipped = true;
        }
    }
    public void returnFlip()
    {
        targetGameObj.transform.DORotate(originalRotation, flipDuration).SetEase(Ease.InOutCubic);
        leaf.DOFade(1, flipFadeDuration).SetEase(Ease.InOutCubic);
    }

    //DROP
    public void DropTween()
    {
        targetGameObj.transform.DOScale(dropScale, dropDuration).SetEase(Ease.InOutSine);
        targetGameObj.transform.DOLocalMove(dropPosition, dropDuration).SetEase(Ease.InOutSine);
        fadeDuration = 0.25f;
        leaf.DOFade(0, fadeDuration).SetEase(Ease.InOutSine);
    }
    public void DropTweenClick()
    {
        if (isDropped)
        {
            DropTween();
            isDropped = false;
        }
        else
        {
            ReturnDrop();
            isDropped = true;
        }
    }
    public void ReturnDrop()
    {
        targetGameObj.transform.DOScale(originalDropScale, dropDuration).SetEase(Ease.InOutSine);
        targetGameObj.transform.DOLocalMove(originalDropPosition, dropDuration).SetEase(Ease.InOutSine);
        fadeDuration = 0.25f;
        leaf.DOFade(1, fadeDuration).SetEase(Ease.InOutSine);
    }
}   
