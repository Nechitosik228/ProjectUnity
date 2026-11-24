using System.Collections.Concurrent;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCStats", menuName = "create Stats", order = 1)]
public class NPCStats : ScriptableObject
{
    [SerializeField] private NPCType _type;
    [SerializeField] private NPCName _name;
    [SerializeField] private int _health;
    [SerializeField] private int _attack;
    [SerializeField] private int _speed;

    public int Health => _health;
    public int Attack => _attack;
    public int Speed => _speed;
    public NPCType Type => _type;
    public NPCName Name => _name;
}

public enum NPCType
{
    ENEMY = 0,
    FRIENDLY = 1,
}

public enum NPCName
{
    BOB = 0,
    PETER = Consts._enemyStart,
}

public static class Consts
{
    public const int _enemyStart = 500;
}