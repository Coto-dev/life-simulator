interface IAlive {
	void Live<T1, T2>();
	void Move();
	void Eat();
	bool IsHungry();
	void Die();
	void Chase<T1, T2>();
}
