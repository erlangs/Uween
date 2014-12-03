﻿using UnityEngine;
using System.Collections;

public abstract class TweenVec1 : TweenVec<float>
{
    protected static T Add<T>(GameObject g, float duration, float to) where T : TweenVec1
    {
        return Add<T, float>(g, duration, to);
    }

    override protected void UpdateValue(float f)
    {
        value = from + (to - from) * f;
    }
}

public static class TweenVec1Extensions
{
    public static T By<T>(this T tween) where T : TweenVec1
    {
        tween.to += tween.value;
        return tween;
    }

    public static T FromThat<T>(this T tween) where T : TweenVec1
    {
        return tween.FromThat<T, float>();
    }

    public static T FromThatBy<T>(this T tween) where T : TweenVec1
    {
        tween.from = tween.value + tween.to;
        tween.to = tween.value;
        return tween;
    }
}