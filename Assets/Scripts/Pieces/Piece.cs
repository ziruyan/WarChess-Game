﻿

using System.Collections.Generic;
using UnityEngine;

public enum PieceType {Admiral, Major, Pikeman, Knight, Rook, Infantry};

// 所有棋子的父类
public abstract class Piece : MonoBehaviour
{
    public PieceType type;

	public string name;
	public int attack;
	public int defense;
	public int health;
	public int maxHealth;
	public int is_range;

	public HealthBar healthBar;

	// 新的通用特征，比如攻防血，加在这里
	// 水平和斜着两种通用移动方法，特殊移动方法如马在Piece的子类里
    protected Vector2Int[] RookDirections = {new Vector2Int(0,1), new Vector2Int(1, 0),
        new Vector2Int(0, -1), new Vector2Int(-1, 0)};
    protected Vector2Int[] BishopDirections = {new Vector2Int(1,1), new Vector2Int(1, -1),
        new Vector2Int(-1, -1), new Vector2Int(-1, 1)};

    public abstract List<Vector2Int> MoveLocations(Vector2Int gridPoint);

	public void Awake()
	{
		setup_attributes();
	}

	public virtual void setup_attributes()
	{
		name = "Soldiers";
		is_range = 0;
		attack = 2;
		defense = 1;
		health = 2;
		maxHealth = health;
	}

	public void attack_piece(Piece p2)
	{
		healthBar.SetMaxHealth(maxHealth);
		p2.healthBar.SetMaxHealth(p2.maxHealth);

		p2.health = p2.health - attack + p2.defense;
		if (is_range == 0)
		{
			health =  health - p2.attack + defense;
		}

		if (health < 1)
		{
			health=1;
		}
		
		if (p2.health < 0)
		{
			p2.health = 0;
		}

		healthBar.SetHealth(health);
		p2.healthBar.SetHealth(p2.health);
	}
}
