using System;

interface IAlive
{
    void move();
    void eat();
    void searchFood<T>(T food);
    bool isHungry();
    void pair<T>(T partner);
    void die();

}
