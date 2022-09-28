using life_simulator.Classes;
using System;

interface IAlive {
	void Live<T1, T2>();
    void Move();
    void Eat();
    bool IsHungry();
    void Pair<T>(T partner);
    void Die();
	void Chase<T1, T2>();
}
